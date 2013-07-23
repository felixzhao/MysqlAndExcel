using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Excel2DataSet
{
    public class ExcelHandler
    {
        public static DataSet ExportExcel2DataSet(string filePath, string sheetName)
        {
            DataSet ds = new DataSet();

            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", filePath);

            using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand(string.Format("Select * FROM [{0}$]",sheetName), connection))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                }
            }

            return ds;
        }
    }
}