using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportToExcelFromDataTable;

namespace OLEDBAndExcel
{
    public class EGNALDB2Excel
    {
        public void ExportToExcelFromDataTable()
        {
            //EGNALOleDbExcel handler = new EGNALOleDbExcel();
            EGNALService service = new EGNALService();
            DataTable table = service.GetEGNAL().Tables[0];
            string sheetName = "Sheet1";

            string connectstr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                           "Data Source=E:\\ExcelData1.xls;" +
                           "Extended Properties=\"Excel 8.0;HDR=YES\"";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var conn = new OleDbConnection();
            conn.ConnectionString = connectstr;
            conn.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = GenCreateCommand(sheetName, table.Columns);
            cmd.ExecuteNonQuery();

            sw.Stop();
            Console.WriteLine("Stopwatch 时间精度：{0}ms", sw.ElapsedMilliseconds);
            Console.WriteLine("Create File Done.");
            Console.ReadKey();

            sw.Start();

            foreach (DataRow r in table.Rows)
            {
                Console.WriteLine("Write Row {0}",r[0].ToString());

                cmd.CommandText = GenInsertQuery(sheetName, table.Columns);
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    var columnName = table.Columns[i].ColumnName;
                    cmd.Parameters.AddWithValue(
                        string.Format("@{0}", columnName)
                        , r[columnName]);
                }
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = "INSERT INTO EmployeeData (Csg_Segment, L0_Id, AM_Effective_Month) values ('AAA', 'Andrew', '12/4/1955')";
            cmd.ExecuteNonQuery();
            conn.Close();

            sw.Stop();
            Console.WriteLine("Stopwatch 时间精度：{0}ms", sw.ElapsedMilliseconds);
            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        public string GenCreateCommand(string sheetName, DataColumnCollection columns)
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("CREATE TABLE {0} ", sheetName));
            result.Append(" ( ");
            for (int j = 0; j < columns.Count; j++)
            {
                result.Append(string.Format(" {0} char(255),", columns[j].ColumnName));
            }
            result.Remove(result.Length - 1, 1);
            result.Append(")");

            return result.ToString();
        }

        public string GenInsertQuery(string sheetName, DataColumnCollection columns)
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("INSERT INTO  {0} ", sheetName));
            // columns
            result.Append(" ( ");
            for (int j = 0; j < columns.Count; j++)
            {
                result.Append(string.Format(" {0},", columns[j].ColumnName));
            }
            result.Remove(result.Length - 1, 1);
            result.Append(")");
            // rows
            result.Append(" VALUES ( ");
            for (int i = 0; i < columns.Count; i++)
            {
                result.Append(string.Format(" @{0},", columns[i].ColumnName));
            }
            result.Remove(result.Length - 1, 1);
            result.Append(")");

            return result.ToString();
        }
    }
}
