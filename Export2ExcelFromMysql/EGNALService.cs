using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BIG;

namespace ExportToExcelFromDataTable
{
    public class EGNALService
    {
        const string Connectionstr = "server=bigccops;uid=root;pwd=345345;database=isr_metrics;pooling=true;min pool size=5;max pool size=128;Persist Security Info=True;";

        public DataSet GetEGNAL()
        {
            DataSet result = new DataSet();

            string sql = string.Format("SELECT * FROM eg_named_account_list ");

            var db = new MySqlHelper(Connectionstr);
            result = db.ExecuteDataSet(sql);

            return result;
        }

        public DataSet GetEGNALByName(string name)
        {
            DataSet result = new DataSet();

            string sql = string.Format("SELECT * FROM eg_named_account_list WHERE ISR_Manager = '{1}' LIMIT 10 ", name);

            var db = new MySqlHelper(Connectionstr);
            result = db.ExecuteDataSet(sql);

            return result;
        }
    }
}