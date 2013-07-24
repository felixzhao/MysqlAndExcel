using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportToExcelFromDataTable;
using MySql.Data.MySqlClient;

namespace OLEDBAndExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            EGNALDB2Excel handler = new EGNALDB2Excel();
            handler.ExportToExcelFromDataTable();
        }
    }
}
