#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using DevExpress.XtraReports.UI;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web;
using RT2020.DAL;
using System.Data.Common;
using System.Configuration;
using RT2020.Helper;


#endregion

namespace RT2020.Product.Reports
{
    //public partial class RptProductMasterList : Form, IGatewayControl
    public partial class RptProductMasterList : Form
    {
        private static int _index = 0;
        private static int _index2 = 0;
        private int _rows = 0;
        private DataTable resultTable = null;

        public RptProductMasterList()
        {
            InitializeComponent();
        }

        private void RptProductMasterList_Load(object sender, EventArgs e)
        {
            SetSystemLabels();

            GetProductData();

            _index = 0;
            _rows = resultTable.Rows.Count;
            DataRow row = resultTable.Rows[0];
            if (row != null)
            {
                txtFromSTKCode.Text = row["STKCODE"].ToString();
                txtDesc.Text = row["ProductName"].ToString();
                txtRetail.Text = Convert.ToDecimal(row["RetailPrice"].ToString()).ToString("n2");
                lblNum.Text = (_index + 1).ToString();
                lblTotalNum.Text = _rows.ToString();
                btnFirst.Enabled = false;
                btnPre.Enabled = false;
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }

            _index2 = resultTable.Rows.Count - 1;
            row = resultTable.Rows[resultTable.Rows.Count - 1];
            if (row != null)
            {
                txtToSTKCode.Text = row["STKCODE"].ToString();
                txtDesc2.Text = row["ProductName"].ToString();
                txtRetail2.Text = Convert.ToDecimal(row["RetailPrice"].ToString()).ToString("n2");
                lblNum2.Text = (_index2 + 1).ToString();
                lblTotalNum2.Text = _rows.ToString();
                btnFirst2.Enabled = true;
                btnPre2.Enabled = true;
                btnNext2.Enabled = false;
                btnLast2.Enabled = false;
            }


        }

        #region Set System Labels
        private void SetSystemLabels()
        {
            string syslbl = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");

            this.lblSTKCode_From.Text = syslbl;
            this.lblSTKCode_To.Text = syslbl;
        }
        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string frmCode = txtFromSTKCode.Text.Trim();
            string toCode = txtToSTKCode.Text.Trim();

            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@frmSTKCode", frmCode), new SqlParameter("@toSTKCode", toCode) };

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "apProductList";
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterValues);

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }

        }

        private void GetProductData()
        {
            if (resultTable == null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"
SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY STKCODE) AS RowIndex, * FROM
(SELECT DISTINCT STKCODE,ProductName, RetailPrice FROM vwProductList) lst ORDER BY RowIndex,STKCODE,ProductName,RetailPrice";

                cmd.CommandTimeout = Common.Config.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                using (DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd))
                {
                    resultTable = ds.Tables[0];
                }
            }
        }
        #endregion

        //#region IGatewayControl Members

        //public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
        //{
        //    if (rbnPDF.Checked)
        //    {
        //        RT2020.Product.Reports.ProductMasterListRpt_Pdf report = new ProductMasterListRpt_Pdf();

        //        report.DataSource = BindData();
        //        report.FrmCode = txtSTKCode.Text.Trim();
        //        report.toCode = txtSTKCode2.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();

        //        // Export the report to PDF.
        //        report.ExportToPdf(memStream);
        //        objResponse.ContentType = "application/pdf";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=ProductList.pdf");

        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        RT2020.Product.Reports.ProductMasterListRpt_Xls reportc = new ProductMasterListRpt_Xls();

        //        reportc.DataSource = BindData();
        //        reportc.FrmCode = txtSTKCode.Text.Trim();
        //        reportc.toCode = txtSTKCode2.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();

        //        reportc.ExportToXls(memStream);
        //        objResponse.ContentType = "application/xls";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=ProductList.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        RT2020.Product.Reports.ProductMasterListRpt_Pdf rpt = new ProductMasterListRpt_Pdf();
        //        try
        //        {
        //            rpt.DataSource = BindData();
        //            rpt.FrmCode = txtSTKCode.Text.Trim();
        //            rpt.toCode = txtSTKCode2.Text.Trim();
        //            rpt.PrintDialog();
        //            rpt.Print();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //        return null;
        //    }
        //}

        //#endregion

        #region Event

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        #region From

        private bool SelectFromProduct(int index)
        {
            string rowIndex = (index + 1).ToString();
            string filterExpression = "RowIndex = '" + rowIndex + "'";
            DataRow[] selectedRows = resultTable.Select(filterExpression, "RowIndex, STKCODE");

            if (selectedRows.Length > 0)
            {
                DataRow row = selectedRows[0];
                if (row != null)
                {
                    txtFromSTKCode.Text = row["STKCODE"].ToString();
                    txtDesc.Text = row["ProductName"].ToString();
                    txtRetail.Text = Convert.ToDecimal(row["RetailPrice"].ToString()).ToString("n2");
                    lblNum.Text = rowIndex;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            _index = 0;

            if (SelectFromProduct(_index))
            {
                btnFirst.Enabled = false;
                btnPre.Enabled = false;
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            _index = _index - 1;

            // 2010-03-05 David: 得到用户输入中最近的记录
            _index = GetPreviousCustomRowIndex(_index, txtFromSTKCode.Text.Trim());

            if (SelectFromProduct(_index))
            {
                if (_index > 0)
                {
                    btnFirst.Enabled = true;
                    btnPre.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
                else
                {
                    btnFirst.Enabled = false;
                    btnPre.Enabled = false;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _index = _index + 1;

            // 2010-03-05 David: 得到用户输入中最近的记录
            _index = GetNextCustomRowIndex(_index, txtFromSTKCode.Text.Trim());

            if (SelectFromProduct(_index))
            {
                if (_index < _rows - 1)
                {
                    btnFirst.Enabled = true;
                    btnPre.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnPre.Enabled = true;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _index = _rows - 1;

            if (SelectFromProduct(_index))
            {
                btnFirst.Enabled = true;
                btnPre.Enabled = true;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
        }

        #endregion

        #region To

        private bool SelectToProduct(int index)
        {
            string rowIndex = (index + 1).ToString();
            string filterExpression = "RowIndex = '" + rowIndex + "'";
            DataRow[] selectedRows = resultTable.Select(filterExpression, "RowIndex, STKCODE");

            if (selectedRows.Length > 0)
            {
                DataRow row = selectedRows[0];
                if (row != null)
                {
                    txtToSTKCode.Text = row["STKCODE"].ToString();
                    txtDesc2.Text = row["ProductName"].ToString();
                    txtRetail2.Text = Convert.ToDecimal(row["RetailPrice"].ToString()).ToString("n2");
                    lblNum2.Text = rowIndex;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnFirst2_Click(object sender, EventArgs e)
        {
            _index2 = 0;

            if (SelectToProduct(_index2))
            {
                btnFirst2.Enabled = false;
                btnPre2.Enabled = false;
                btnNext2.Enabled = true;
                btnLast2.Enabled = true;
            }
        }

        private void btnPre2_Click(object sender, EventArgs e)
        {
            _index2 = _index2 - 1;

            // 2010-03-05 David: 得到用户输入中最近的记录
            _index2 = GetPreviousCustomRowIndex(_index2, txtToSTKCode.Text.Trim());

            if (SelectToProduct(_index2))
            {
                if (_index2 > 0)
                {
                    btnFirst2.Enabled = true;
                    btnPre2.Enabled = true;
                    btnNext2.Enabled = true;
                    btnLast2.Enabled = true;
                }
                else
                {
                    btnFirst2.Enabled = false;
                    btnPre2.Enabled = false;
                    btnNext2.Enabled = true;
                    btnLast2.Enabled = true;
                }
            }
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            _index2 = _index2 + 1;

            // 2010-03-05 David: 得到用户输入中最近的记录
            _index2 = GetNextCustomRowIndex(_index2, txtToSTKCode.Text.Trim());

            if (SelectToProduct(_index2))
            {
                if (_index2 < _rows - 1)
                {
                    btnFirst2.Enabled = true;
                    btnPre2.Enabled = true;
                    btnNext2.Enabled = true;
                    btnLast2.Enabled = true;
                }
                else
                {
                    btnFirst2.Enabled = true;
                    btnPre2.Enabled = true;
                    btnNext2.Enabled = false;
                    btnLast2.Enabled = false;
                }
            }
        }

        private void btnLast2_Click(object sender, EventArgs e)
        {
            _index2 = _rows - 1;

            if (SelectToProduct(_index2))
            {
                btnFirst2.Enabled = true;
                btnPre2.Enabled = true;
                btnNext2.Enabled = false;
                btnLast2.Enabled = false;
            }
        }

        #endregion

        private int GetPreviousCustomRowIndex(int currentIndex, string customStockCode)
        {
            int rowIndex = currentIndex;

            string sortExpression = "RowIndex DESC, STKCODE";
            string filterExpression = "RowIndex = " + currentIndex.ToString();
            DataRow[] selectedRows = resultTable.Select(filterExpression);

            if (selectedRows.Length > 0)
            {
                DataRow row = selectedRows[0];
                if (row != null)
                {
                    if (row["STKCODE"].ToString() != customStockCode)
                    {
                        filterExpression = "STKCODE < '" + customStockCode + "' AND RowIndex <= " + currentIndex.ToString();

                        selectedRows = resultTable.Select(filterExpression, sortExpression);

                        if (selectedRows.Length > 0)
                        {
                            row = selectedRows[0];
                            if (row != null)
                            {
                                rowIndex = Convert.ToInt32(row["RowIndex"].ToString());
                            }
                        }
                    }
                }
            }

            return rowIndex--;
        }

        private int GetNextCustomRowIndex(int currentIndex, string customStockCode)
        {
            int rowIndex = currentIndex;

            string sortExpression = "RowIndex, STKCODE";
            string filterExpression = "RowIndex = " + currentIndex.ToString();
            DataRow[] selectedRows = resultTable.Select(filterExpression);

            if (selectedRows.Length > 0)
            {
                DataRow row = selectedRows[0];
                if (row != null)
                {
                    if (row["STKCODE"].ToString() != customStockCode)
                    {
                        filterExpression = "STKCODE > '" + customStockCode + "'";

                        selectedRows = resultTable.Select(filterExpression, sortExpression);

                        if (selectedRows.Length > 0)
                        {
                            row = selectedRows[0];
                            if (row != null)
                            {
                                rowIndex = Convert.ToInt32(row["RowIndex"].ToString());
                            }
                        }
                    }
                }
            }

            return rowIndex;
        }

        #endregion

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (txtFromSTKCode.Text.CompareTo(txtToSTKCode.Text) <= 0)
            {
                string[,] param = {
              {"FromSTKCODE",this.txtFromSTKCode.Text.Trim()},
              {"ToSTKCODE",this.txtToSTKCode.Text.Trim()},
              {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
              {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
             };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apProductList";
                view.ReportName = "RT2020.Product.Reports.ProductMasterListRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
            else
            {
                MessageBox.Show("Out of range!", "ATTENTION");
            }
        }
    }
}