using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace EGNALMaintain
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnUplod_Click(object sender, EventArgs e)
        {
            // if you have Excel 2007 uncomment this line of code
            //  string excelConnectionString =string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0",path);

            string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            if (FuPath.HasFile)
            {
                //Check the Content Type of the file
                if (FuPath.PostedFile.ContentType == ExcelContentType || FuPath.PostedFile.ContentType == Excel2010ContentType)
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        string path = string.Concat(Server.MapPath("~/TempFiles/"), FuPath.FileName);
                        FuPath.SaveAs(path);
                        string sheetName = "Sheet1";
                        ds = ExcelHandler.ExportExcel2DataSet(path,sheetName);

                        //GridView1.DataSource = ds;
                        //GridView1.DataBind();

                        EGNALService service = new EGNALService();
                        service.UpdateEGNAL(ds);
                        Label1.Text = "导入数据成功. ";
                    }

                    catch (Exception ex)
                    {
                        Label1.Text = "导入数据失败。 " +ex.Message;
                    }
                }
            }
        }
    }
}