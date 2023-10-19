using Google.Apis.Auth.OAuth2;

using Google.Apis.Sheets.v4;

using Google.Apis.Sheets.v4.Data;

using Google.Apis.Services;

using Google.Apis.Util.Store;

using System.Dynamic;

using System.Data;
using ABSAAutomation.Hooks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Net.Http;
using System.Linq;

namespace GoogleSheetsHelper

{

    public class GoogleSheetsHelper2

    {

        static string[] Scopes = { SheetsService.Scope.Spreadsheets };

        static string ApplicationName = "GoogleSheetsHelper";

        private ValueRange response;

        private readonly SheetsService service;

        private readonly string _spreadsheetId;



        public GoogleSheetsHelper2(String SpreadsheetID)

        {

            UserCredential credential;



           // String Path = System.AppDomain.CurrentDomain.BaseDirectory;

           // Path = Path.Replace("bin\\Debug", "");



            using (var stream =

                new FileStream(Absa.sPath + "\\credentials.json", FileMode.Open, FileAccess.Read))

            {

                // The file token.json stores the user's access and refresh tokens, and is created

                // automatically when the authorization flow completes for the first time.

                


                string credPath = Absa.sPath + "\\token.json";





                // String folderPath = GetHomeDirectory();

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(

                   GoogleClientSecrets.Load(stream).Secrets,

                   Scopes,

                   "user",

                   CancellationToken.None,

                   new FileDataStore(credPath, true)).Result;

                Console.WriteLine("Credential file saved to: " + credPath);

                // credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);

            }





            // Create Google Sheets API service.

            service = new SheetsService(new BaseClientService.Initializer()

            {

                HttpClientInitializer = credential,

                ApplicationName = ApplicationName,

            });



            _spreadsheetId = SpreadsheetID;





        }







        private GoogleSheetParameters MakeGoogleSheetDataRangeColumnsZeroBased(GoogleSheetParameters googleSheetParameters)

        {

            googleSheetParameters.RangeColumnStart = googleSheetParameters.RangeColumnStart - 1;

            googleSheetParameters.RangeColumnEnd = googleSheetParameters.RangeColumnEnd - 1;

            return googleSheetParameters;

        }

        public List<ExpandoObject> GetDataFromSheet(GoogleSheetParameters googleSheetParameters)

        {

            googleSheetParameters = MakeGoogleSheetDataRangeColumnsZeroBased(googleSheetParameters);

            var range = $"{googleSheetParameters.SheetName}!{GetColumnName(googleSheetParameters.RangeColumnStart)}{googleSheetParameters.RangeRowStart}:{GetColumnName(googleSheetParameters.RangeColumnEnd)}{googleSheetParameters.RangeRowEnd}";



            SpreadsheetsResource.ValuesResource.GetRequest request =

                service.Spreadsheets.Values.Get(_spreadsheetId, range);



            var numberOfColumns = googleSheetParameters.RangeColumnEnd - googleSheetParameters.RangeColumnStart;

            var columnNames = new List<string>();

            var returnValues = new List<ExpandoObject>();



            if (!googleSheetParameters.FirstRowIsHeaders)

            {

                for (var i = 0; i <= numberOfColumns; i++)

                {

                    columnNames.Add($"Column{i}");

                }

            }



            var response = request.Execute();



            int rowCounter = 0;

            IList<IList<Object>> values = response.Values;

            if (values != null && values.Count > 0)

            {

                foreach (var row in values)

                {

                    if (googleSheetParameters.FirstRowIsHeaders && rowCounter == 0)

                    {

                        for (var i = 0; i <= numberOfColumns; i++)

                        {

                            columnNames.Add(row[i].ToString());

                        }

                        rowCounter++;

                        continue;

                    }



                    var expando = new ExpandoObject();

                    var expandoDict = expando as IDictionary<String, object>;

                    var columnCounter = 0;

                    foreach (var columnName in columnNames)

                    {

                        expandoDict.Add(columnName, row[columnCounter].ToString());

                        columnCounter++;

                    }

                    returnValues.Add(expando);

                    rowCounter++;

                }

            }



            return returnValues;

        }



        //var gsp = new GoogleSheetParameters() { RangeColumnStart = 1, RangeRowStart = 1, RangeColumnEnd = 4, RangeRowEnd = 3, FirstRowIsHeaders = true, SheetName = "sheet1" };

        public List<object> GetDataFromGoogleSheet(GoogleSheetParameters googleSheetParameters)

        {

            googleSheetParameters = MakeGoogleSheetDataRangeColumnsZeroBased(googleSheetParameters);

            var range = $"{googleSheetParameters.SheetName}!{GetColumnName(1)}{1}:{GetColumnName(googleSheetParameters.RangeColumnEnd)}";



            SpreadsheetsResource.ValuesResource.GetRequest request =

                service.Spreadsheets.Values.Get(_spreadsheetId, range);



            var numberOfColumns = googleSheetParameters.RangeColumnEnd - 1;

            var columnNames = new List<string>();

            var returnValues = new List<object>();





            var response = request.Execute();



            int rowCounter = 0;

            IList<IList<Object>> values = response.Values;

            if (values != null && values.Count > 0)

            {

                foreach (var row in values)

                {

                    if (rowCounter == 0)

                    {

                        for (var i = 0; i <= numberOfColumns; i++)

                        {

                            columnNames.Add(row[i].ToString());

                        }

                        rowCounter++;

                        continue;

                    }



                    var expando = new ExpandoObject();

                    Dictionary<String, string> My_dict1 =

                       new Dictionary<String, string>();

                    var columnCounter = 0;

                    foreach (var columnName in columnNames)

                    {

                        if (row[columnCounter].ToString() == "")

                            My_dict1.Add(columnName, row[columnCounter].ToString());

                        columnCounter++;

                    }

                    returnValues.Add(My_dict1);

                    rowCounter++;

                }

            }



            return returnValues;

        }





        public DataTable GetGoogleSheetsData(GoogleSheetParameters googleSheetParameters)

        {

            googleSheetParameters = MakeGoogleSheetDataRangeColumnsZeroBased(googleSheetParameters);

            var range = $"{googleSheetParameters.SheetName}!{GetColumnName(0)}{1}:{GetColumnName(googleSheetParameters.RangeColumnEnd)}";



            SpreadsheetsResource.ValuesResource.GetRequest request =

                service.Spreadsheets.Values.Get(_spreadsheetId, range);



            var numberOfColumns = googleSheetParameters.RangeColumnEnd - 1;

            var columnNames = new List<string>();

            // String sValue = null;





            try

            {

                response = request.Execute();

            }

            catch (HttpRequestException e)

            {

                Console.WriteLine(e.Message);

                //retry

                response = request.Execute();

            }

            DataTable dt = new DataTable();



            int rowCounter = 0;

            IList<IList<Object>> values = response.Values;

            if (values != null && values.Count > 0)

            {

                foreach (var row in values)

                {



                    if (rowCounter == 0)

                    {

                        for (var i = 0; i <= numberOfColumns; i++)

                        {



                            try

                            {

                                dt.Columns.Add(row[i].ToString());

                            }

                            catch (Exception e)

                            {

                                Console.WriteLine("End of Columns" + e.Message);

                                break;

                            }

                        }

                        rowCounter++;

                        //break;



                    }

                    else

                    {

                        DataRow rs = dt.NewRow();

                        for (var i = 0; i <= numberOfColumns; i++)

                        {

                            try

                            {

                                rs[dt.Columns[i].ColumnName] = row[i].ToString();

                            }

                            catch (Exception e)

                            {

                                Console.WriteLine("End of file" + e.Message);

                                break;

                            }

                        }

                        dt.Rows.Add(rs);

                    }



                }



            }

            return dt;

        }













        public void AddCells(GoogleSheetParameters googleSheetParameters, List<GoogleSheetRow> rows)

        {

            var requests = new BatchUpdateSpreadsheetRequest { Requests = new List<Request>() };



            var sheetId = GetSheetId(service, _spreadsheetId, googleSheetParameters.SheetName);



            GridCoordinate gc = new GridCoordinate

            {

                ColumnIndex = googleSheetParameters.RangeColumnStart - 1,

                RowIndex = googleSheetParameters.RangeRowStart - 1,

                SheetId = sheetId

            };



            var request = new Request { UpdateCells = new UpdateCellsRequest { Start = gc, Fields = "*" } };



            var listRowData = new List<RowData>();



            foreach (var row in rows)

            {

                var rowData = new RowData();

                var listCellData = new List<CellData>();

                foreach (var cell in row.Cells)

                {

                    var cellData = new CellData();

                    var extendedValue = new ExtendedValue { StringValue = cell.CellValue };



                    cellData.UserEnteredValue = extendedValue;

                    var cellFormat = new CellFormat { TextFormat = new TextFormat() };



                    if (cell.IsBold)

                    {

                        cellFormat.TextFormat.Bold = true;

                    }



                    cellFormat.BackgroundColor = new Color { Blue = (float)cell.BackgroundColor.B / 255, Red = (float)cell.BackgroundColor.R / 255, Green = (float)cell.BackgroundColor.G / 255 };



                    cellData.UserEnteredFormat = cellFormat;

                    listCellData.Add(cellData);

                }

                rowData.Values = listCellData;

                listRowData.Add(rowData);

            }

            request.UpdateCells.Rows = listRowData;



            // It's a batch request so you can create more than one request and send them all in one batch. Just use reqs.Requests.Add() to add additional requests for the same spreadsheet

            requests.Requests.Add(request);



            service.Spreadsheets.BatchUpdate(requests, _spreadsheetId).Execute();

        }



        private string GetColumnName(int index)

        {

            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";



            if (index >= letters.Length)

                value += letters[index / letters.Length - 1];



            value += letters[index % letters.Length];

            return value;

        }



        private int GetSheetId(SheetsService service, string spreadSheetId, string spreadSheetName)

        {

            var spreadsheet = service.Spreadsheets.Get(spreadSheetId).Execute();

            var sheet = spreadsheet.Sheets.FirstOrDefault(s => s.Properties.Title == spreadSheetName);

            int sheetId = (int)sheet.Properties.SheetId;

            return sheetId;

        }

    }



    public class GoogleSheetCell

    {

        public string CellValue { get; set; }

        public bool IsBold { get; set; }

        public System.Drawing.Color BackgroundColor { get; set; } = System.Drawing.Color.White;

    }



    public class GoogleSheetParameters

    {

        public int RangeColumnStart { get; set; }

        public int RangeRowStart { get; set; }

        public int RangeColumnEnd { get; set; }

        public int RangeRowEnd { get; set; }

        public string SheetName { get; set; }

        public bool FirstRowIsHeaders { get; set; }

    }



    public class GoogleSheetRow

    {

        public GoogleSheetRow() => Cells = new List<GoogleSheetCell>();



        public List<GoogleSheetCell> Cells { get; set; }

    }



}



/*      // Define request parameters.

  String spreadsheetId2 = "1-Ba--_HWs7-Ysmaj6OC6G95HlaCIz4pLWs3aHiSrDfk";

      String range = "Sheet1!A2:C";

      SpreadsheetsResource.ValuesResource.GetRequest request =

              service.Spreadsheets.Values.Get(spreadsheetId2, range);

 

      // Prints the names and majors of students in a sample spreadsheet:

      // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit

      ValueRange response = request.Execute();

      IList<IList<Object>> values = response.Values;

      if (values != null && values.Count > 0)

      {

          Console.WriteLine("Name, Major");

          foreach (var row in values)

          {

              // Print columns A and E, which correspond to indices 0 and 4.

              Console.WriteLine("{0}, {1}", row[0], row[4]);

          }

      }

      else

      {

          Console.WriteLine("No data found.");

      }

      Console.Read();

  }*/