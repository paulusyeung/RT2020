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
    public partial class List : UserControl
    {
        #region private properties
        String[] _StockCodeList = null;

        private DateTime FromDate
        {
            get
            {
                return datFromDate.Value;
            }
        }

        private DateTime ToDate
        {
            get
            {
                return datToDate.Value;
            }
        }
        #endregion

        public List()
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
            lblFromDate.Text = WestwindHelper.GetWordWithColon("transaction.date", "Transaction");
            lbltoDate.Text = "⇔ ";
            lblIgnorQty.Text = WestwindHelper.GetWordWithColon("reports.ignorStockTakeQty", "General");

            lblSTkFrom.TextAlign = lblFromDate.TextAlign = lblIgnorQty.TextAlign = ContentAlignment.MiddleRight;
            lblSTkTo.TextAlign = lbltoDate.TextAlign = ContentAlignment.MiddleRight;
        }

        private void SetAttributes()
        {
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

            if (String.Compare(txtFrom.Text.Trim(), txtTo.Text.Trim()) > 0)
            {
                result = false;
                MessageBox.Show("Range Error: STKCODE Error ", "Message");
            }
            else if (datFromDate.Value.ToString("yyyy-MM-dd").CompareTo(datToDate.Value.ToString("yyyy-MM-dd")) > 0)
            {
                result = false;
                MessageBox.Show("Range Error: Date", "Message");
            }
            return result;
        }
        #endregion

        private void OnCommandClick(object sender, EventArgs e)
        {
            if (!IsSelValid()) return;

            var cmd = (Button)sender;

            switch (cmd.Name)
            {
                case "cmdPreview":
                    htmlBox1.Html = RT2020.Reports.Inventory.Journal.List.HTML(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));
                    break;
                case "cmdPDF":
                    #region export PDF
                    var pdf = RT2020.Reports.Inventory.Journal.List.PDF(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));

                    if (pdf != null)
                    {
                        var dl = new Controls.FileDownloadGateway();
                        dl.Filename = string.Format("{0}.{1}.pdf", WestwindHelper.GetWord("report.SA1330", "Setting"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        dl.SetContentType(RT2020.Controls.DownloadContentType.OctetStream);
                        dl.StartBytesDownload(this, pdf);
                    }
                    break;
                    #endregion
                case "cmdExcel":
                    #region export Excel
                    var xls = RT2020.Reports.Inventory.Journal.List.Excel(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));

                    if (xls != null)
                    {
                        var dl = new Controls.FileDownloadGateway();
                        dl.Filename = string.Format("{0}.{1}.xlsx", WestwindHelper.GetWord("report.SA1330", "Setting"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        dl.SetContentType(RT2020.Controls.DownloadContentType.MicrosoftExcel);
                        dl.StartBytesDownload(this, xls);
                    }
                    break;
                    #endregion
                case "cmdPivot":
                    #region export PivotTable
                    var pvt = RT2020.Reports.Inventory.Journal.List.Pivot(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));

                    if (pvt != null)
                    {
                        var dl = new Controls.FileDownloadGateway();
                        dl.Filename = string.Format("{0}.{1}.xlsx", WestwindHelper.GetWord("report.SA1330", "Setting"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        dl.SetContentType(RT2020.Controls.DownloadContentType.MicrosoftExcel);
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

        private void datFromDate_ValueChanged(object sender, EventArgs e)
        {
            var dtp = (DateTimePicker)sender;

            datToDate.Value = dtp.Value.AddMonths(1).AddDays(-1) <= DateTime.Now.Date ? dtp.Value.AddMonths(1).AddDays(-1) : DateTime.Now;
        }
    }
}