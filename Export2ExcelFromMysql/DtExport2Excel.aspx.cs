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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EGNALService service = new EGNALService();
                DataTable dt = service.GetEGNAL("上海").Tables[0];
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Btn_Export_Click(object sender, EventArgs e)
        {
            EGNALService service = new EGNALService();
            DataTable dt = service.GetEGNAL("上海").Tables[0];

            var ostr = GetExportData(dt);
            HttpResponse rsp = Page.Response;
            ExportToExcel(rsp, ostr);
        }

        private string GetExportData(DataTable table)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<BR><BR><BR>");
            result.Append("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {
                result.Append("<Td>");
                result.Append("<B>");
                result.Append(table.Columns[j].ColumnName);
                result.Append("</B>");
                result.Append("</Td>");
            }
            result.Append("</TR>");
            foreach (DataRow row in table.Rows)
            {
                result.Append("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append("<Td>");
                    result.Append(row[i].ToString());
                    result.Append("</Td>");
                }

                result.Append("</TR>");
            }
            result.Append("</Table>");
            result.Append("</font>");

            return result.ToString();
        }

        public void ExportToExcel(HttpResponse rsp, string ostring)
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
    }
}