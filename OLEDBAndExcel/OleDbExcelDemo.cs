using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLEDBAndExcel
{
    public class OleDbExcelDemo
    {
        public static void CreatAndInsertExcel()
        {
            string connectstr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                           "Data Source=E:\\ExcelData1.xls;" +
                           "Extended Properties=\"Excel 8.0;HDR=YES\"";

            var conn = new OleDbConnection();
            conn.ConnectionString = connectstr;
            conn.Open();
            var cmd1 = new OleDbCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "CREATE TABLE EmployeeData (Id char(255), Name char(255), BirthDate date)";
            cmd1.ExecuteNonQuery();
            cmd1.CommandText = "INSERT INTO EmployeeData (Id, Name, BirthDate) values ('AAA', 'Andrew', '12/4/1955')";
            cmd1.ExecuteNonQuery();
            conn.Close();
        }

        public bool Insert3(string sheetName, string path, DataTable table)
        {
            bool result = true;

            string connectstr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                           "Data Source=E:\\ExcelData1.xls;" +
                           "Extended Properties=\"Excel 8.0;HDR=YES\"";

            var conn = new OleDbConnection();
            conn.ConnectionString = connectstr;
            conn.Open();
            var cmd1 = new OleDbCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "CREATE TABLE EmployeeData (Csg_Segment char(255), L0_Id char(255), AM_Effective_Month char(255))";
            cmd1.ExecuteNonQuery();
            cmd1.CommandText = "INSERT INTO EmployeeData (Csg_Segment, L0_Id, AM_Effective_Month) values ('AAA', 'Andrew', '12/4/1955')";
            cmd1.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}
