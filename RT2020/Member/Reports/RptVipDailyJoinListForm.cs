#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Forms;
using ClosedXML.Excel;


using RT2020.Common.Helper;

#endregion

namespace RT2020.Member.Reports
{
    public partial class RptVipDailyJoinListForm : Form, IGatewayComponent
    {
        public RptVipDailyJoinListForm()
        {
            InitializeComponent();
        }

        #region Export to Excel

        private DataTable DataSource()
        {
            string from = dtpFromRegDate.Value.ToString("yyyy-MM-dd");
            string to = dtpToRegDate.Value.ToString("yyyy-MM-dd");

            string sql = @"
SELECT DateOfRegister, VipNumber, FirstName, Email, Phone_W, Phone_H, Phone_P, Fax, Phone_Other
FROM dbo.vwVIP_MemberList 
WHERE DateOfRegister >= '" + from + @"' AND DateOfRegister <= '" + to + @"'
ORDER BY DateOfRegister";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        private string ExportToExcel()
        {
            string outputPath = Path.Combine(Context.Config.GetDirectory("Upload"), "MemberReport");
            string excelFile = Path.Combine(outputPath, "VipDailyJoinList.xlsx");

            FileInfo xlsFile = new FileInfo(excelFile);
            if (xlsFile.Exists)
            {
                xlsFile.Delete();
                xlsFile = new FileInfo(excelFile);
            }

            var wb = new ClosedXML.Excel.XLWorkbook();
            var worksheet = wb.Worksheets.Add("Sheet1");

            // Set width of columns
            worksheet.Column(1).Width = 13d;
            worksheet.Column(2).Width = 15d;
            worksheet.Column(3).Width = 18d;
            worksheet.Column(4).Width = 18d;
            worksheet.Column(5).Width = 12d;
            worksheet.Column(6).Width = 12d;
            worksheet.Column(7).Width = 12d;
            worksheet.Column(8).Width = 12d;
            worksheet.Column(9).Width = 12d;
            // Setting first row
            // Title
            worksheet.Cell(1, 1).Value = "VIP2800 - VIP Daily Join In Report (Excel)";
            // Report Criteria
            worksheet.Cell(2, 1).Value = "DATE RANGE:";
            worksheet.Cell(2, 2).Value = dtpFromRegDate.Value.ToString(DateTimeHelper.GetDateFormat()) + " TO " + dtpToRegDate.Value.ToString(DateTimeHelper.GetDateFormat());
            worksheet.Cell(3, 1).Value = "PRINTED ON:";
            worksheet.Cell(3, 2).Value = DateTime.Now.ToString(DateTimeHelper.GetDateFormat());
            // Header
            worksheet.Cell(5, 1).Value = "REGISTRATION DATE";
            worksheet.Cell(5, 2).Value = "VIP#";
            worksheet.Cell(5, 3).Value = "NAME";
            worksheet.Cell(5, 4).Value = "EMAIL";
            worksheet.Cell(5, 5).Value = "TEL. WORK";
            worksheet.Cell(5, 6).Value = "TEL. HOME";
            worksheet.Cell(5, 7).Value = "PAGER";
            worksheet.Cell(5, 8).Value = "FAX";
            worksheet.Cell(5, 9).Value = "OTHER";

            // writing data
            DataTable oTable = DataSource();
            var rangeWithData = worksheet.Cell(7, 1).InsertData(oTable.AsEnumerable());


            // add some document properties to the spreadsheet 

            // set some core property values
            wb.Properties.Title = "VIP2800 - VIP Daily Join In Report (Excel)";
            wb.Properties.Author = "RT2020";
            wb.Properties.Subject = "VIP2800 - VIP Daily Join In Report (Excel)";
            wb.Properties.Keywords = "RT2020";
            wb.Properties.Category = "VIP2800 - VIP Daily Join In Report (Excel)";
            wb.Properties.Comments = "VIP2800 - VIP Daily Join In Report (Excel)";

            // set some extended property values
            wb.Properties.Company = "Synergy";

            // save our new workbook and we are done!
            wb.SaveAs(excelFile);

            return excelFile;
        }

        #endregion

        #region IGatewayComponent Members

        /// <summary>
        /// Provides a way to custom handle requests.
        /// </summary>
        /// <param name="objContext">The request context.</param>
        /// <param name="strAction">The request action.</param>
        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            string fileName = ExportToExcel();

            if (fileName.Length > 0)
            {
                Stream stream = File.Open(fileName, FileMode.Open);
                byte[] streamByte = SystemInfoHelper.Settings.ReadFully(stream, stream.Length);
                stream.Close();

                HttpResponse objResponse = this.Context.HttpContext.Response;
                objResponse.Clear();
                objResponse.ClearHeaders();
                objResponse.ContentType = "application/xlsx";
                objResponse.AddHeader("content-disposition", "attachment; filename=\"VIP Daily Join List.xlsx\"");
                objResponse.BinaryWrite(streamByte);
                objResponse.Flush();
                objResponse.End();
            }
        }

        #endregion

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Link.Open(new GatewayReference(this, "open"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}