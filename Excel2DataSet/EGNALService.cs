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

        public DataSet GetEGNAL(string query)
        {
            DataSet result = new DataSet();

            string sql = string.Format("SELECT * FROM eg_named_account_list where L2_Account like '%{0}%' LIMIT 10 ", query.Replace("*", "%"));

            var db = new MySqlHelper(Connectionstr);
            result = db.ExecuteDataSet(sql);

            return result;
        }

        public DataSet GetEGNALByName(string query, string name)
        {
            DataSet result = new DataSet();

            string sql = string.Format("SELECT * FROM eg_named_account_list WHERE L2_Account like '%{0}%' AND ISR_Manager = '{1}' LIMIT 10 ", query.Replace("*", "%"), name);

            var db = new MySqlHelper(Connectionstr);
            result = db.ExecuteDataSet(sql);

            return result;
        }
    }
}