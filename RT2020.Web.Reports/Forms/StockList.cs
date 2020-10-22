#region Using

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Microsoft.Reporting.WebForms;

#endregion

namespace RT2020.Web.Reports.Forms
{
    public partial class StockList : Controls.WizardBase
    {
        public StockList()
        {
            InitializeComponent();
            this.txtSTYLE.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.rptViewer.AutoSize = true;
            this.rptViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        #region Bind Data to Report(Search)
        private DataTable BindData()
        {
            string whereCaluse = string.Empty;

            if (this.txtSTYLE.Text.Trim().Length > 0)
            {
                whereCaluse = " STKCODE LIKE '" + txtSTYLE.Text.Trim() + "%'";
            }

            if (txtBarcode.Text.Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " AND " : "") + " Barcode = '" + txtBarcode.Text.Trim() + "'";
            }

            return Binding(whereCaluse);
        }
        #endregion

        #region Bind Data to Report(Lookup)
        private DataTable BindBarcodeDataToReport()
        {
            string whereCaluse = string.Empty;

            if (this.txtSTYLE.Text.Trim().Length > 0)
            {
                whereCaluse = " STKCODE LIKE '" + txtSTYLE.Text.Trim() + "%'";
            }

            if (txtBarcode.Text.Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " AND " : "")
                    + " STKCODE IN ( SELECT STKCODE FROM dbo.vwStockList WHERE Barcode = '" + txtBarcode.Text.Trim() + "')";
            }

            return Binding(whereCaluse);
        }
        #endregion

        private DataTable Binding(string whereCaluse)
        {
            string sql = @"
SELECT TOP 100 PERCENT * FROM dbo.vwStockList ";

            whereCaluse = string.Format(" WHERE {0}", whereCaluse);
            sql += whereCaluse;

            sql += " ORDER BY STKCODE,APPENDIX1,APPENDIX2,APPENDIX3";
            
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                DataTable dt = dataset.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Photo"].ToString().Length != 0 && !string.IsNullOrEmpty(Context.Config.GetDirectory("RTImages")))
                    {
                        row["Photo"] = System.IO.Path.Combine(System.IO.Path.Combine(Context.Config.GetDirectory("RTImages"), "Product"), row["Photo"].ToString());
                        if (!System.IO.File.Exists(row["Photo"].ToString()))
                        {
                            row["Photo"] = "file:///" + System.IO.Path.Combine(Context.Config.GetDirectory("Images"), "no_photo.jpg");
                        }
                        else
                        {
                            row["Photo"] = "file:///" + System.IO.Path.Combine(System.IO.Path.Combine(Context.Config.GetDirectory("RTImages"), "Product"), row["Photo"].ToString());
                        }
                    }
                    else
                    {
                        row["Photo"] = "file:///" + System.IO.Path.Combine(Context.Config.GetDirectory("Images"), "no_photo.jpg");
                    }
                }
                return dt;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSTYLE.Text.Length > 0 || txtBarcode.Text.Length > 0)
            {
                DataTable table = BindData();
                OnClick(table);
            }
            else
            {
                MessageBox.Show("STYLE or Barcode Are Required!", "Message");
            }
            this.txtSTYLE.Focus();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (txtSTYLE.Text.Length > 0 || txtBarcode.Text.Length > 0)
            {
                DataTable table = BindBarcodeDataToReport();
                OnClick(table);
            }
            else
            {
                MessageBox.Show("STYLE or Barcode Are Required!", "Message");
            }
            this.txtSTYLE.Focus();
        }

        private void OnClick(DataTable table)
        {
            List<ReportParameter> rptParam = new List<ReportParameter>();
            rptParam.Add(new ReportParameter("STKCODE",Common.Utility.GetSystemLabelByKey("STKCODE")));
            rptParam.Add(new ReportParameter("APPENDIX1",Common.Utility.GetSystemLabelByKey("APPENDIX1")));
            rptParam.Add(new ReportParameter("APPENDIX2",Common.Utility.GetSystemLabelByKey("APPENDIX2")));
            rptParam.Add(new ReportParameter("APPENDIX3",Common.Utility.GetSystemLabelByKey("APPENDIX3")));

            if (table.Rows.Count > 0)
            {
                this.rptViewer.Datasource = table;
                this.rptViewer.ReportDatasourceName = "DataSource_vwStockList";
                this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.StockListRdl.rdlc";
                this.rptViewer.Parameters = rptParam;

                this.rptViewer.PreviewReport();
            }
            else
            {
                MessageBox.Show("no record found.", "Message");
            }
        }
    }
}