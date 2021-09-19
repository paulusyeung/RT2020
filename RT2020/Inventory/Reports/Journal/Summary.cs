#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.Reports.Journal
{
    public partial class Summary : UserControl
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

        public Summary()
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
            lblIgnorQty.Text = WestwindHelper.GetWordWithColon("reports.ignorZeroQty", "General");

            lblSTkFrom.TextAlign = lblFromDate.TextAlign = lblIgnorQty.TextAlign = ContentAlignment.MiddleRight;
            lblSTkTo.TextAlign = lbltoDate.TextAlign = ContentAlignment.MiddleRight;
        }

        private void SetAttributes()
        {
            WorkplaceEx.LoadHierarchyTree(ref tvwWorkplace);
            tvwWorkplace.Dock = DockStyle.Fill;
            tvwWorkplace.CheckBoxes = true;
            tvwWorkplace.AfterCheck += OnAfterCheck;

            cmdPreview.Enabled = cmdPDF.Enabled = cmdExcel.Enabled = false;

            this.txtFrom.Focus();
        }
        #endregion

        private void OnAfterCheck(object sender, TreeViewEventArgs e)
        {
            tvwWorkplace.BeginUpdate();

            var tvw = (TreeView)sender;
            var node = e.Node;
            bool chk = node.Checked;

            if (node.Nodes.Count > 0)
            {
                ToggleCheckedChildNode(ref node, chk);
            }

            tvwWorkplace.EndUpdate();
        }

        private void ToggleCheckedChildNode(ref TreeNode nodes, bool chk)
        {
            if (nodes.Nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Nodes.Count; ++i)
                {
                    var node = nodes.Nodes[i];
                    node.Checked = chk;
                    if (node.Nodes.Count > 0)
                    {
                        ToggleCheckedChildNode(ref node, chk);
                    }
                }
            }
        }

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;
            var nodes = TreeViewHelper.GetAllCheckedNodes(tvwWorkplace.Nodes, "Workplace");

            if (nodes.Count == 0)
            {
                result = false;
                MessageBox.Show("Range Error: Location ", "Message");
            }
            else if (String.Compare(txtFrom.Text.Trim(), txtTo.Text.Trim()) > 0 || (txtFrom.Text.Trim() == "" && txtTo.Text.Trim() == ""))
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

        #region prepare SqlParameter param
        private SqlParameter[] GetSelections()
        {
            SqlParameter[] result = {
             new SqlParameter("@fromSTKCODE",txtFrom.Text.Trim()),
             new SqlParameter("@toSTKCODE",txtTo.Text.Trim()),
             new SqlParameter("@fromDate",datFromDate.Value),
             new SqlParameter("@toDate",datToDate.Value),
             new SqlParameter("@SelectedWorkplaceCode",SelectedWorkplaceCodeList().Replace("'","")),
             new SqlParameter("@SelectedTYPE",SelectedDataType()),
             new SqlParameter("@ShowSkipZeroQty",chkZeroQty.Checked),
             new SqlParameter("@ShowReCalculatedCD",false)
            };

            return result;
        }

        private string SelectedDataType()
        {
            StringBuilder selectType = new StringBuilder();
            /** default ALL
            if (chkREC.Checked)
            {
                selectType.Append("REC" + ",");
            }
            if (chkCAP.Checked)
            {
                selectType.Append("CAP" + ",");
            }
            if (chkREJ.Checked)
            {
                selectType.Append("REJ" + ",");
            }
            if (chkSAL.Checked)
            {
                selectType.Append("SAL,SRT" + ",");
            }
            if (chkADJ.Checked)
            {
                selectType.Append("ADJ" + ",");
            }
            if (chkRetail.Checked)
            {
                selectType.Append("CRT,CAS,VOD" + ",");
            }
            if (chkTXI.Checked)
            {
                selectType.Append("TXI,TRI" + ",");
            }
            if (chkTXO.Checked)
            {
                selectType.Append("TXO,TRO" + ",");
            }
            */
            selectType.Append("REC" + ",");
            selectType.Append("CAP" + ",");
            selectType.Append("REJ" + ",");
            selectType.Append("SAL,SRT" + ",");
            selectType.Append("ADJ" + ",");
            selectType.Append("CRT,CAS,VOD" + ",");
            selectType.Append("TXI,TRI" + ",");
            selectType.Append("TXO,TRO" + ",");

            return selectType.ToString().Trim(',');
        }

        private string SelectedWorkplaceCodeList()
        {
            StringBuilder selectList = new StringBuilder();

            var nodes = TreeViewHelper.GetAllCheckedNodes(tvwWorkplace.Nodes, "Workplace");
            foreach (var item in nodes)
            {
                selectList.Append("'" + item.Text.Substring(0, 4) + "'" + ",");
            }
            return selectList.ToString().Trim(',');
        }
        #endregion

        private void OnCommandClick(object sender, EventArgs e)
        {
            if (!IsSelValid()) return;

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
                        var dl = new Controls.FileDownloadGateway();
                        dl.Filename = string.Format("{0}.{1}.pdf", WestwindHelper.GetWord("report.SA1330", "Setting"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        dl.SetContentType(RT2020.Controls.DownloadContentType.OctetStream);
                        dl.StartBytesDownload(this, pdf);
                    }
                    break;
                    #endregion
                case "cmdExcel":
                    #region export Excel
                    var xls = RT2020.Reports.Inventory.Journal.Monthly.Excel(txtFrom.Text.Trim(), txtTo.Text.Trim(), FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));

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
                    var pvt = RT2020.Reports.Inventory.Journal.Summary.Pivot(GetSelections());

                    if (pvt != null)
                    {
                        var dl = new Controls.FileDownloadGateway();
                        dl.Filename = string.Format("{0}.{1}.xlsx", WestwindHelper.GetWord("report.SA1340", "Setting"), DateTime.Now.ToString("yyyyMMddHHmmss"));
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