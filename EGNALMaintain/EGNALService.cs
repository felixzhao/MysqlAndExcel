using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BIG;

namespace EGNALMaintain
{
    public class EGNALService
    {
        const string Connectionstr = "server=bigccops;uid=root;pwd=345345;database=Test;pooling=true;min pool size=5;max pool size=128;Persist Security Info=True;";

        public bool UpdateEGNAL(DataSet ds)
        {
            bool result = true;

            #region Query String

            string sql = @"INSERT INTO eg_named_account_list (
Csg_Segment,
Stm,
L0_Id,
L0_Account,
Geography,
Province,
City,
City_Id,
A_Id,
L2_AMID,
L2_Account,
A_Id_City_Id,
Dta,
L2_Customer_Segment,
Siebel_Row_ID,
AM_SubTeam,
AM_Manager,
AM,
AM_Email,
AM_Effective_Month,
BCS_SubTeam,
BCS_Manager,
BCS,
BCS_Email,
BCS_Effective_Month,
ESS_SubTeam,
ESS_Manager,
ESS,
ESS_Email,
ESS_Effective_Month,
ISR_SubTeam,
ISR_Manager,
ISR_Manager_Phone,
ISR,
ISR_Phone,
ISR_Email,
ISR_SRID,
ISR_Effective_Month,
ISS_SubTeam,
ISS_Manager,
ISS,
ISS_Email,
ISS_Effective_Month,
SWD_SubTeam,
SWD_Manager,
SWD,
SWD_Email,
SWD_Effective_Month
) 
VALUES (
@Csg_Segment,
@Stm,
@L0_Id,
@L0_Account,
@Geography,
@Province,
@City,
@City_Id,
@A_Id,
@L2_AMID,
@L2_Account,
@A_Id_City_Id,
@Dta,
@L2_Customer_Segment,
@Siebel_Row_ID,
@AM_SubTeam,
@AM_Manager,
@AM,
@AM_Email,
@AM_Effective_Month,
@BCS_SubTeam,
@BCS_Manager,
@BCS,
@BCS_Email,
@BCS_Effective_Month,
@ESS_SubTeam,
@ESS_Manager,
@ESS,
@ESS_Email,
@ESS_Effective_Month,
@ISR_SubTeam,
@ISR_Manager,
@ISR_Manager_Phone,
@ISR,
@ISR_Phone,
@ISR_Email,
@ISR_SRID,
@ISR_Effective_Month,
@ISS_SubTeam,
@ISS_Manager,
@ISS,
@ISS_Email,
@ISS_Effective_Month,
@SWD_SubTeam,
@SWD_Manager,
@SWD,
@SWD_Email,
@SWD_Effective_Month
)";
            #endregion

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(Connectionstr))
            {
                conn.Open();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Csg_Segment", r["Csg Segment"]);
                    cmd.Parameters.AddWithValue("@Stm", r["Stm"]);
                    cmd.Parameters.AddWithValue("@L0_Id", r["L0 Id"]);
                    cmd.Parameters.AddWithValue("@L0_Account", r["L0 Account"]);
                    cmd.Parameters.AddWithValue("@Geography", r["Geography"]);
                    cmd.Parameters.AddWithValue("@Province", r["Province"]);
                    cmd.Parameters.AddWithValue("@City", r["City"]);
                    cmd.Parameters.AddWithValue("@City_Id", r["City Id"]);
                    cmd.Parameters.AddWithValue("@A_Id", r["A Id"]);
                    cmd.Parameters.AddWithValue("@L2_AMID", r["L2 AMID"]);
                    cmd.Parameters.AddWithValue("@L2_Account", r["L2 Account"]);
                    cmd.Parameters.AddWithValue("@A_Id_City_Id", r["A Id-City Id"]);
                    cmd.Parameters.AddWithValue("@Dta", r["Dta"]);
                    cmd.Parameters.AddWithValue("@L2_Customer_Segment", r["L2 Customer Segment"]);
                    cmd.Parameters.AddWithValue("@Siebel_Row_ID", r["Siebel Row ID"]);
                    cmd.Parameters.AddWithValue("@AM_SubTeam", r["AM SubTeam"]);
                    cmd.Parameters.AddWithValue("@AM_Manager", r["AM Manager"]);
                    cmd.Parameters.AddWithValue("@AM", r["AM"]);
                    cmd.Parameters.AddWithValue("@AM_Email", r["AM Email"]);
                    cmd.Parameters.AddWithValue("@AM_Effective_Month", r["AM Effective Month"]);
                    cmd.Parameters.AddWithValue("@BCS_SubTeam", r["BCS SubTeam"]);
                    cmd.Parameters.AddWithValue("@BCS_Manager", r["BCS Manager"]);
                    cmd.Parameters.AddWithValue("@BCS", r["BCS"]);
                    cmd.Parameters.AddWithValue("@BCS_Email", r["BCS Email"]);
                    cmd.Parameters.AddWithValue("@BCS_Effective_Month", r["BCS Effective Month"]);
                    cmd.Parameters.AddWithValue("@ESS_SubTeam", r["ESS SubTeam"]);
                    cmd.Parameters.AddWithValue("@ESS_Manager", r["ESS Manager"]);
                    cmd.Parameters.AddWithValue("@ESS", r["ESS"]);
                    cmd.Parameters.AddWithValue("@ESS_Email", r["ESS Email"]);
                    cmd.Parameters.AddWithValue("@ESS_Effective_Month", r["ESS Effective Month"]);
                    cmd.Parameters.AddWithValue("@ISR_SubTeam", r["ISR SubTeam"]);
                    cmd.Parameters.AddWithValue("@ISR_Manager", r["ISR Manager"]);
                    cmd.Parameters.AddWithValue("@ISR_Manager_Phone", "");// r["ISR Manager Phone"]);
                    cmd.Parameters.AddWithValue("@ISR", r["ISR"]);
                    cmd.Parameters.AddWithValue("@ISR_Phone", "");//r["ISR_Phone"]);
                    cmd.Parameters.AddWithValue("@ISR_Email", r["ISR Email"]);
                    cmd.Parameters.AddWithValue("@ISR_SRID", r["ISR SRID"]);
                    cmd.Parameters.AddWithValue("@ISR_Effective_Month", r["ISR Effective Month"]);
                    cmd.Parameters.AddWithValue("@ISS_SubTeam", r["ISS SubTeam"]);
                    cmd.Parameters.AddWithValue("@ISS_Manager", r["ISS Manager"]);
                    cmd.Parameters.AddWithValue("@ISS", r["ISS"]);
                    cmd.Parameters.AddWithValue("@ISS_Email", r["ISS Email"]);
                    cmd.Parameters.AddWithValue("@ISS_Effective_Month", r["ISS Effective Month"]);
                    cmd.Parameters.AddWithValue("@SWD_SubTeam", r["SWD SubTeam"]);
                    cmd.Parameters.AddWithValue("@SWD_Manager", r["SWD Manager"]);
                    cmd.Parameters.AddWithValue("@SWD", r["SWD"]);
                    cmd.Parameters.AddWithValue("@SWD_Email", r["SWD Email"]);
                    cmd.Parameters.AddWithValue("@SWD_Effective_Month", r["SWD Effective Month"]);
                    result &= cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

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