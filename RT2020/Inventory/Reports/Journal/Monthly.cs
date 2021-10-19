#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;
using RT2020.Common.Helper;
using System.Collections;
using System.IO;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.Reports.Journal
{
    public partial class Monthly : UserControl
    {
        #region private properties
        String[] _StockCodeList = null;

        private int FromYear
        {
            get
            {
                return int.Parse(this.txtYear.Text.Trim());
            }
        }

        private int FromMonth
        {
            get
            {
                return int.Parse(this.txtMonth.Text.Trim());
            }
        }
        #endregion

        public Monthly()
        {
            InitializeComponent();
        }

        private void Monthly_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
        }

        #region SetCaptions & SetAttributes
        private void SetCaptions()
        {
            groupBox1.Text = WestwindHelper.GetWord("reports.selectedRange", "General");

            lblSTkFrom.Text = WestwindHelper.GetWordWithColon("article.code", "Product");
            lblSTkTo.Text = "⇔ ";
            lblYear.Text = string.Format("{0} (YYYY):", WestwindHelper.GetWord("glossary.year", "General"));
            lblMonth.Text = string.Format("{0} (MM):", WestwindHelper.GetWord("glossary.month", "General"));
            lblIgnorQty.Text = WestwindHelper.GetWordWithColon("reports.ignorStockTakeQty", "General");

            lblSTkFrom.TextAlign = lblIgnorQty.TextAlign = ContentAlignment.MiddleRight;
            lblSTkTo.TextAlign = ContentAlignment.MiddleRight;
        }

        private void SetAttributes()
        {
            txtYear.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear;
            txtMonth.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth;
            chkTakeQty.Checked = true;

            txtFrom.Focus();
        }
        #endregion

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;
            int year = 0;
            int month = 0;

            if (int.TryParse(this.txtMonth.Text.Trim(), out month) && int.TryParse(this.txtYear.Text.Trim(), out year))
            {
                if (month < 1 || month > 12)
                {
                    result = false;
                    MessageBox.Show("Format Error: Month Error", "Message");
                }
                else if (year < 0 || year > 9999)
                {
                    result = false;
                    MessageBox.Show("Format Error: Year Error", "Message");
                }
                else if (String.Compare(this.txtFrom.Text.Trim(), this.txtTo.Text.Trim()) > 0)
                {
                    result = false;
                    MessageBox.Show("Range Error: STKCODE Error ", "Message");
                }
            }
            else
            {
                result = false;
                MessageBox.Show("Format Error:Year and Month Must be a number of", "Message");
            }
            return result;
        }
        #endregion

        private void OnCommandClick(object sender, EventArgs e)
        {
            if (!IsSelValid()) return;

            DateTime FromDate = new DateTime(FromYear, FromMonth, 1);
            DateTime ToDate = new DateTime(FromYear, FromMonth, DateTime.DaysInMonth(FromYear, FromMonth));

            var cmd = (Button)sender;
            switch (cmd.Name)
            {
                case "cmdPreview":
                    htmlBox1.Html = RT2020.Reports.Inventory.Journal.Monthly.HTML(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));
                    break;
                case "cmdPDF":
                    #region export PDF
                    var pdf = RT2020.Reports.Inventory.Journal.Monthly.PDF(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));

                    if (pdf != null)
                    {
                        var dl = new FileDownloadGateway();
                        dl.FileName = string.Format("{0}.{1}.pdf", WestwindHelper.GetWord("report.SA1330", "Setting"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        dl.SetContentType(DownloadContentType.OctetStream);
                        dl.StartBytesDownload(this, pdf);
                    }
                    break;
                    #endregion
                case "cmdExcel":
                    #region export Excel
                    var xls = RT2020.Reports.Inventory.Journal.Monthly.Excel(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));

                    if (xls != null)
                    {
                        var dl = new FileDownloadGateway();
                        dl.FileName = string.Format("{0}.{1}.xlsx", WestwindHelper.GetWord("report.SA1330", "Setting"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        dl.SetContentType(DownloadContentType.MicrosoftExcel);
                        dl.StartBytesDownload(this, xls);
                    }
                    break;
                    #endregion
                case "cmdPivot":
                    #region export PivotTable
                    var pvt = RT2020.Reports.Inventory.Journal.Monthly.Pivot(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));

                    if (pvt != null)
                    {
                        var dl = new FileDownloadGateway();
                        dl.FileName = string.Format("{0}.{1}.xlsx", WestwindHelper.GetWord("report.SA1330", "Setting"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        dl.SetContentType(DownloadContentType.MicrosoftExcel);
                        dl.StartBytesDownload(this, pvt);
                    }
                    break;
                    #endregion
            }
        }

        private void txtFrom_Enter(object sender, EventArgs e)
        {
            txtFrom.SelectAll();
        }

        private void txtTo_Enter(object sender, EventArgs e)
        {
            if (txtTo.Text == "" & txtFrom.Text != "") txtTo.Text = txtFrom.Text + "Z";
            txtTo.SelectAll();
        }

        private void txtYear_Enter(object sender, EventArgs e)
        {
            txtYear.SelectAll();
        }

        private void txtMonth_Enter(object sender, EventArgs e)
        {
            txtMonth.SelectAll();
        }
    }
}