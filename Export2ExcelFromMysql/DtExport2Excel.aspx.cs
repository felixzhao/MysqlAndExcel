using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExportToExcelFromDataTable
{
    public partial class Practice : System.Web.UI.Page
    {
        const string filename = "EG_Named_Account_List_Export.xls";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //EGNALService service = new EGNALService();
                //DataTable dt = service.GetEGNAL().Tables[0];
                //GridView1.DataSource = dt.Select("L2_Account = '%上海%'");
                //GridView1.DataBind();
            }
        }

        protected void Btn_Export_Click(object sender, EventArgs e)
        {
            EGNALService service = new EGNALService();
            DataTable dt = service.GetEGNAL().Tables[0];

            string path = string.Concat(Server.MapPath("~/TempFiles/"), filename);
            var ostr = ExcelHandler.GetExportData(dt, path);
            //HttpResponse rsp = Page.Response;
            //ExcelHandler.ExportToExcel(rsp, ostr);
            DownLoadFile("");
        }

        private void DownLoadFile(string name)
        {
            var filePath = string.Concat(Server.MapPath("~/TempFiles/"), filename);
            if (!string.IsNullOrEmpty(name))
            {
                filePath = Server.MapPath("~/Data/EG_Named_Account_List(" + name + ").xlsx");
            }
            if (File.Exists(filePath))
            {
                var file = new FileInfo(filePath);
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name)); //解决中文文件名乱码    
                Response.AddHeader("Content-length", file.Length.ToString(CultureInfo.InvariantCulture));
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }
    }
}