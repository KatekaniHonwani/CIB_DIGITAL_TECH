using ABSAAutomation.Hooks;
using GoogleSheetsHelper;

using Microsoft.Graph;

using Microsoft.Graph.Auth;

using Microsoft.Identity.Client;

using Newtonsoft.Json;

using RestSharp;



using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace ABSAAutomation.Utilities

{

    class ExcelHelper

    {

        private readonly string user = config.ExcelUser;



        private GoogleSheetsHelper2 gsh;



        public string GetCellValue(WorkbookRange workbookRange, string columnName, int row)

        {

            string value = null;



            var worksheet = workbookRange;

            var worksheet2 = TestBase.rowValues;

            if (!config.DataType.ToUpper().Equals("GOOGLESHEETS"))

            {



                for (int col = 0; col < worksheet.ColumnCount; col++)

                    if (columnName.Trim().ToUpper() == worksheet.Values[0][col].ToString().Trim().ToUpper())

                        value = (string)worksheet.Values[row][col];

            }

            else

            {

                row = row - 1;

                for (int i = 0; i < worksheet2.Columns.Count; i++)

                {

                    if (worksheet2.Columns[i].ColumnName == columnName)

                    {

                        value = worksheet2.Rows[row][i].ToString();



                    }



                }

            }



            return value ?? throw new Exception($" Unable to get cell value. Column '{columnName}' could not be found!");

        }



        public async Task<WorkbookRange> GetSheetData(string SpreadsheetID, string sheetName)

        {

            var workbookRange = await GetGraphClient().Users[user].Drive.Items[SpreadsheetID].Workbook.Worksheets[sheetName]

            .UsedRange().Request().GetAsync();



            return workbookRange;

        }



        //Reasons for seperating the Range Address (e.g.from A1:F1) into two arguements (1 & A:F):

        //1. Row has to be verified whether it's invalid (i.e. < 1) or equivalent to 1 (reserved for the heading row)

        //2. It mitigates the chances of human mistakes such as making the range modify 2+ rows instead of only 1 (e.g. A3:AL4)

        //3. It's easy to understand/rely on and handle for when columns exceed ranges 'Z' or 'ZZ' instead of having

        //a function that extracts letters and numbers from an unconfined range expression such as A3:AL3

        public async Task SetCellValues_(string SpreadsheetID, string sheetName, int row, string range, List<Object> values)

        {

            var worksheet = GetSheetData(SpreadsheetID, sheetName).GetAwaiter().GetResult();



            row = row <= 1 ? ((int)worksheet.RowCount) + 1 : row;

            var address = $"{range.Substring(0, range.IndexOf(":"))}{row}:{range.Substring(range.IndexOf(":") + 1)}{row}";



            var updates = new WorkbookRange

            {

                Values = JsonConvert.SerializeObject("[['" + string.Join("', '", values.ToArray()) + "']]")

            };



            await GetGraphClient().Users[user].Drive.Items[SpreadsheetID].Workbook.Worksheets[sheetName].Range(address).Request().PatchAsync(updates);



            Console.WriteLine($"Row updated successfully: {updates.Values}");

        }



        //Reasons for seperating the Range Address (e.g.from A1:F1) into two arguements (1 & A:F):

        //1. Row has to be verified whether it's invalid (i.e. < 1) or equivalent to 1 (reserved for the heading row)

        //2. It mitigates the chances of human mistakes such as making the range modify 2+ rows instead of only 1 (e.g. A3:AL4)

        //3. It's easy to understand/rely on and handle for when columns exceed ranges 'Z' or 'ZZ' instead of having

        //a function that extracts letters and numbers from an unconfined range expression such as A3:AL3

        public async Task SetCellValues(string SpreadsheetID, string sheetName, int row, string range, List<Object> values)

        {

            string clientId = privateSettings.AppID;

            string tenantId = privateSettings.AppTenantID;

            string clientSecret = privateSettings.AppSecret;

            string[] scopes = new string[] { privateSettings.AppScopes };



            try

            {

                if (!config.DataType.ToUpper().Equals("GOOGLESHEETS"))

                {



                    IConfidentialClientApplication confidentialClient = ConfidentialClientApplicationBuilder

                .Create(clientId).WithClientSecret(clientSecret).WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}/v2.0")).Build();



                    // Retrieve an access token for Microsoft Graph (gets a fresh token if needed).

                    var authResult = await confidentialClient.AcquireTokenForClient(scopes).ExecuteAsync().ConfigureAwait(false);



                    var worksheet = GetSheetData(SpreadsheetID, sheetName).GetAwaiter().GetResult();



                    if (row <= 1)

                    {

                        row = ((int)worksheet.RowCount) + 1;

                        liberty.generatedDataRow = row + 1;

                    }



                    var address = $"{range.Substring(0, range.IndexOf(":"))}{row}:{range.Substring(range.IndexOf(":") + 1)}{row}";



                    var client = new RestClient($"https://graph.microsoft.com/v1.0/users/{user}");



                    var request = new RestRequest("/drive/items/" + SpreadsheetID + "/workbook/worksheets/" + sheetName + "/range(address='" + address + "')", Method.Patch);



                    request.AddHeader("Content-Type", "application/json");

                    request.AddHeader("Authorization", "Bearer " + authResult.AccessToken);



                    var param = "{'values': [['" + string.Join("', '", values) + "']]}";



                    request.AddJsonBody(param);



                    var response = client.Execute(request);



                    if (response.IsSuccessful)

                        Console.WriteLine($"Row updated successfully: {param}");

                    else

                        throw new Exception($"An error occured! Status Code: {response.StatusCode} \n Error Message: {response.ErrorMessage} \n Error Exception: {response.ErrorException}");

                }

                else

                {

                    gsh = new GoogleSheetsHelper.GoogleSheetsHelper2(SpreadsheetID);

                    var RowData = new GoogleSheetRow();

                    String[] ColumnStartEnd = range.Split(':');

                    int ColumnStart = ColumnStartEnd[0].Aggregate(0, (a, c) => a * 26 + c & 31);

                    int ColumnEnd = ColumnStartEnd[1].Aggregate(0, (a, c) => a * 26 + c & 31);

                    for (int i = 0; i < values.Count; i++)

                    {

                        RowData.Cells.AddRange(new List<GoogleSheetCell>() { new GoogleSheetCell() { CellValue = values[i].ToString() } });

                    }



                    int NextRow = gsh.GetGoogleSheetsData(new GoogleSheetParameters() { RangeColumnEnd = ColumnEnd, SheetName = sheetName }).Rows.Count + 2;

                    TestBase.generatedDataRow = NextRow;

                    gsh.AddCells(new GoogleSheetParameters() { SheetName = sheetName, RangeColumnStart = ColumnStart, RangeRowStart = NextRow },

                   new List<GoogleSheetRow>() { RowData });

                    //   RowData.Cells.AddRange(new List<GoogleSheetCell>() { new GoogleSheetCell() { CellValue = values });

                }//);



                //}

            }

            catch (Exception e)

            {

                Console.WriteLine($"An error occured: {e.Message}");

            }



        }



        private GraphServiceClient GetGraphClient()

        {

            string clientId = privateSettings.AppID;

            string tenantId = privateSettings.AppTenantID;

            string clientSecret = privateSettings.AppSecret;



            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder

                .Create(clientId).WithTenantId(tenantId).WithClientSecret(clientSecret).Build();



            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);



            return graphClient;

        }



    }

}