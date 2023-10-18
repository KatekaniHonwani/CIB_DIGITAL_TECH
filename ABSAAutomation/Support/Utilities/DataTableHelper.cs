using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;

namespace ABSAAutomation.Support.Utilities
{
    class DataTableHelper
    {
        public static Dictionary<string,string> DataTableToDictionary(Table table)
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach(var row in table.Rows)
            {
                dict.Add(row[0], row[1]);
            }

            return dict;  

        }

        public static DataTable ToDataTable(Table table)
        {

            DataTable dataTable = new DataTable();

            foreach(var header in table.Header)
            {
                dataTable.Columns.Add(header,typeof(string));
            }

            foreach(var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                
                foreach(var header in table.Header)
                {
                    newRow.SetField(header, row[header]);
                }

                dataTable.Rows.Add(newRow);
            }

            return dataTable;

        }

    }

}
