using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace ExportToExcelFromDataTable
{
    public class ExcelHandler
    {
        public static DataSet ExportExcel2DataSet(string filePath, string sheetName)
        {
            DataSet ds = new DataSet();

            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", filePath);

            using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand(string.Format("Select * FROM [{0}$]", sheetName), connection))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                }
            }

            return ds;
        }

        #region Export
        public static string GetExportData(DataTable table, string path)
        {
            StringBuilder result = new StringBuilder();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                file.WriteLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                file.WriteLine("<meta http-equiv=Content-Type content=\"text/html; charset=UTF-8\">");
                file.WriteLine("<font style='font-size:10.0pt; font-family:Calibri;'>");
                file.WriteLine("<BR><BR><BR><Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
                int columnscount = table.Columns.Count;

                for (int j = 0; j < columnscount; j++)
                {
                    file.WriteLine("<Td><B>" + table.Columns[j].ColumnName + "</B></Td>");
                }
                file.WriteLine("</TR>");
                foreach (DataRow row in table.Rows)
                {
                    file.WriteLine("<TR>");
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        file.WriteLine("<Td>" + row[i].ToString() + "</Td>");
                    }

                    file.WriteLine("</TR>");
                }
                file.WriteLine("</Table>");
                file.WriteLine("</font>");
            }
            return result.ToString();
        }

        public static void ExportToExcel(HttpResponse rsp, string ostring)
        {
            rsp.Clear();
            rsp.Buffer = true;
            rsp.Charset = "UTF-8";
            rsp.ContentEncoding = System.Text.Encoding.UTF8;
            rsp.ContentType = "application/vnd.xls";
            rsp.AppendHeader("Content-Disposition",
                             "attachment;filename=" +
                             HttpUtility.UrlEncode(
                                 "EG_Named_Account_List.xls",
                                 System.Text.Encoding.UTF8).ToString(CultureInfo.InvariantCulture)); //FileName.xls");
            rsp.Write("<meta http-equiv=Content-Type content=\"text/html; charset=UTF-8\">"); //GB2312
            rsp.Output.Write(ostring);
            rsp.Flush();
            rsp.End();
        }
        #endregion
    }
}