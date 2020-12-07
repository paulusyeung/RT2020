#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;

#endregion

namespace RT2020.Controls.ProductSearcher
{
    public partial class MatrixDetail : Form
    {
        private bool _ShowAllQty = false;
        private bool _ShowAllWHQty = false;

        public List<DetailData> ResultList { get; set; }
        public string StockCode { get; set; }
        public Common.Enums.TxType TxType { get; set; }

        public MatrixDetail()
        {
            InitializeComponent();

            ResultList = new List<DetailData>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.txtStockCode.Text = this.StockCode;

            SetCaptions();
            SetAttributes();
        }

        private void SetCaptions()
        {
            lblStockCode.Text = SystemInfo.Settings.GetSystemLabelByKey("STKCODE") + RT2020.Controls.Utility.Dictionary.GetColon();
            colAppendix1.HeaderText = SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.HeaderText = SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.HeaderText = SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");

            lblProductName.Text = RT2020.Controls.Utility.Dictionary.GetWordWithColon("description");
            lblTotalQty.Text = RT2020.Controls.Utility.Dictionary.GetWordWithColon("total_qty");
            lblTotalAmount.Text = RT2020.Controls.Utility.Dictionary.GetWordWithColon("total_amount");

            colQty.HeaderText = RT2020.Controls.Utility.Dictionary.GetWord("qty");
            colQtySubTotal.HeaderText = string.Format(RT2020.Controls.Utility.Dictionary.GetWord("subtotal_replace"), RT2020.Controls.Utility.Dictionary.GetWord("qty"));
            colUnitAmount.HeaderText = RT2020.Controls.Utility.Dictionary.GetWord("unit_amount");
            colAmountSubTotal.HeaderText = string.Format(RT2020.Controls.Utility.Dictionary.GetWord("subtotal_replace"), RT2020.Controls.Utility.Dictionary.GetWord("amount"));

            colUnitAmount.Visible = ShowPrices();
            colAmountSubTotal.Visible = ShowPrices();

            lblTotalAmount.Visible = ShowPrices();
            txtTotalAmount.Visible = ShowPrices();

            btnLoad.Text = RT2020.Controls.Utility.Dictionary.GetWord("load");
            btnOK.Text = RT2020.Controls.Utility.Dictionary.GetWord("ok");
            btnCancel.Text = RT2020.Controls.Utility.Dictionary.GetWord("cancel");
        }

        private void SetAttributes()
        {
            this.txtProductName.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            this.txtTotalQty.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            this.txtTotalAmount.BackColor = SystemInfo.ControlBackColor.DisabledBox;

            this.colWorkplace.Visible = false;
        }

        private bool ShowPrices()
        {
            bool result = true;

            switch (this.TxType)
            {
                case Common.Enums.TxType.ADJ:
                case Common.Enums.TxType.TXF:
                    result = false;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        private decimal GetPrice(Guid productId)
        {
            decimal result = 0;

            switch (this.TxType)
            {
                case Common.Enums.TxType.ADJ:
                    result = ModelEx.ProductCurrentSummaryEx.GetAverageCode(productId);
                    break;
                case Common.Enums.TxType.TXF:
                    DAL.Product product = DAL.Product.Load(productId);
                    if (product != null)
                    {
                        result = product.RetailPrice;
                    }
                    break;
            }

            return result;
        }

        #region Bind Data

        private void BindData()
        {
            if (txtStockCode.Text.Trim().Length > 0)
            {
                dgvDetailList.AutoGenerateColumns = false;
                dgvDetailList.DataSource = GetData();

                FormatCellStyle();
                CalcSubTotalQty();
            }
        }

        private DataTable GetData()
        {
            string sql = BuildQuery();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);
            DataTable oTable = ds.Tables[0];

            foreach (DetailData detail in ResultList)
            {
                DataRow[] row = oTable.Select(string.Format("ProductId = '{0}' AND WorkplaceCode = ''", detail.ProductId.ToString()));
                row[0].BeginEdit();
                row[0]["CDQTY"] = detail.Qty;
                row[0]["UnitAmount"] = detail.UnitAmount;
                row[0]["Amount"] = detail.UnitAmount * detail.Qty;
                row[0].EndEdit();
                row[0].AcceptChanges();
                oTable.AcceptChanges();
            }

            return oTable;
        }

        private string BuildQuery()
        {
            string sql = string.Empty;
            string pattern = "SELECT * FROM ({0} UNION ALL {1}) lst ";

            string queryProductList = @"
SELECT     ProductId, STKCODE, ProductName, APPENDIX1, APPENDIX2, APPENDIX3, '' AS WorkplaceCode, 0 AS BFQTY, 0 AS CDQTY, 0 AS UnitAmount, 0 AS Amount
FROM         dbo.vwProductList";

            string queryProductWithLocList = @"
SELECT     ProductId, STKCODE, '' AS ProductName, APPENDIX1, APPENDIX2, APPENDIX3, WorkplaceCode, BFQTY, CDQTY, 0 AS UnitAmount, 0 AS Amount
FROM         dbo.vwProductQtyListByWorkplace";

            string queryWHProductList = @"
SELECT     ProductId, STKCODE, '' AS ProductName, APPENDIX1, APPENDIX2, APPENDIX3, pwp.WorkplaceCode, pwp.BFQTY, pwp.CDQTY, 0 AS UnitAmount, 0 AS Amount
FROM         dbo.vwProductQtyListByWorkplace pwp LEFT OUTER JOIN  
             dbo.Workplace wp ON wp.WorkplaceCode = pwp.WorkplaceCode LEFT OUTER JOIN 
             dbo.WorkplaceNature wpn ON wp.NatureId = wpn.NatureId 
WHERE wpn.NatureCode = '2'"; // 2 => Workplace Nature: Warehouse

            string whereClause = string.Format(" WHERE [STKCODE] = '{0}' ", txtStockCode.Text);
            string orderBy = " ORDER BY APPENDIX1, APPENDIX2, APPENDIX3, WorkplaceCode, ProductName";

            if (_ShowAllQty)
            {
                sql = string.Format(pattern, queryProductList, queryProductWithLocList);
                sql += whereClause + orderBy;
            }
            else if (_ShowAllWHQty)
            {
                sql = string.Format(pattern, queryProductList, queryWHProductList);
                sql += whereClause + orderBy;
            }
            else
            {
                sql = queryProductList;
                sql += whereClause + orderBy;
            }

            return sql;
        }

        #endregion

        #region Grid related Events

        private void btnShowAllWorkplaceQty_Click(object sender, EventArgs e)
        {
            _ShowAllQty = btnShowAllWorkplaceQty.Text.Contains("Show");
            _ShowAllWHQty = false;

            this.colWorkplace.Visible = btnShowAllWorkplaceQty.Text.Contains("Show");

            btnShowAllWorkplaceQty.Text = btnShowAllWorkplaceQty.Text.Contains("Show") ? "<< &Hide All Loc. Qty" : "Show &All Loc. Qty";

            BindData();

            btnShowAllWarehouseQty.Enabled = !_ShowAllQty;
        }

        private void btnShowAllWarehouseQty_Click(object sender, EventArgs e)
        {
            _ShowAllQty = false;
            _ShowAllWHQty = btnShowAllWarehouseQty.Text.Contains("Show");

            this.colWorkplace.Visible = btnShowAllWarehouseQty.Text.Contains("Show");

            btnShowAllWarehouseQty.Text = btnShowAllWarehouseQty.Text.Contains("Show") ? "<< &Hide W/H Loc. Qty" : "Show &W/H Loc. Qty";

            BindData();

            btnShowAllWorkplaceQty.Enabled = !_ShowAllWHQty;
        }

        private void LoadProductList()
        {
            string where = string.Format("STKCODE = '{0}'", txtStockCode.Text.Trim());
            DAL.Product oProd = DAL.Product.LoadWhere(where);
            if (oProd != null)
            {
                this.txtProductName.Text = oProd.ProductName;
            }

            BindData();
        }

        private void txtStockCode_TextChanged(object sender, EventArgs e)
        {
            this.LoadProductList();
        }

        private void dgvDetailList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal qty = Convert.ToDecimal(dgvDetailList.Rows[e.RowIndex].Cells[5].Value.ToString()); // Qty
            decimal uamt = Convert.ToDecimal(dgvDetailList.Rows[e.RowIndex].Cells[7].Value.ToString()); // Unit Amount

            decimal amt = (decimal)qty * uamt;
            dgvDetailList.Rows[e.RowIndex].Cells[8].Value = amt; // Amount

            if (qty > 0)
            {
                dgvDetailList.Rows[e.RowIndex].Cells[5].Style.Font = new Font(dgvDetailList.DefaultCellStyle.Font, FontStyle.Bold);
                dgvDetailList.Rows[e.RowIndex].Cells[6].Style.Font = new Font(dgvDetailList.DefaultCellStyle.Font, FontStyle.Bold);
            }

            if (uamt > 0)
            {
                dgvDetailList.Rows[e.RowIndex].Cells[7].Style.Font = new Font(dgvDetailList.DefaultCellStyle.Font, FontStyle.Bold);
                dgvDetailList.Rows[e.RowIndex].Cells[8].Style.Font = new Font(dgvDetailList.DefaultCellStyle.Font, FontStyle.Bold);
            }

            if (DAL.Common.Utility.IsGUID(dgvDetailList.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                Guid productId = new Guid(dgvDetailList.Rows[e.RowIndex].Cells[0].Value.ToString());

                DetailData detail = ResultList.Find(d => d.ProductId == productId);

                decimal price = GetPrice(productId);

                if (detail == null)
                {
                    detail = new DetailData();
                    detail.ProductId = productId;
                    detail.Qty = qty;
                    detail.UnitAmount = price > 0 ? price : uamt;
                }
                else
                {
                    ResultList.Remove(detail);

                    detail.Qty = qty;
                    detail.UnitAmount = price > 0 ? price : uamt;
                }

                ResultList.Add(detail);
            }

            CalcSubTotalQty();
        }

        private void CalcSubTotalQty()
        {
            decimal qty = 0;
            decimal amt = 0;

            foreach (DetailData row in ResultList)
            {
                qty += row.Qty; // Qty
                amt += row.Qty * row.UnitAmount;
            }

            this.txtTotalQty.Text = qty.ToString("n0");
            this.txtTotalAmount.Text = amt.ToString("n2");
        }

        private void FormatCellStyle()
        {
            int i = 0;

            string firstA1Cell = string.Empty;
            string firstA2Cell = string.Empty;
            string firstA3Cell = string.Empty;

            foreach (DataGridViewRow row in dgvDetailList.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    bool ignore = false;

                    if (cell.ReadOnly)
                    {
                        cell.Style.BackColor = SystemInfo.ControlBackColor.DisabledBox;
                    }

                    if (cell.ColumnIndex == 4 && cell.Value.ToString().Trim().Length > 0) // Workplace
                    {
                        row.ReadOnly = true;
                        row.DefaultCellStyle.BackColor = SystemInfo.ControlBackColor.DisabledBox;
                        ignore = true;
                    }

                    if (cell.ColumnIndex == 5 || cell.ColumnIndex == 6 || cell.ColumnIndex == 7 || cell.ColumnIndex == 8) // Qty
                    {
                        if (Convert.ToDecimal(cell.Value.ToString()) > 0 && !ignore)
                        {
                            cell.Style.Font = new Font(dgvDetailList.DefaultCellStyle.Font, FontStyle.Bold);
                        }
                    }
                }

                if (i > 0)
                {
                    if (firstA1Cell == row.Cells[1].Value.ToString().Trim())
                    {
                        row.Cells[1].Value = string.Empty;
                    }
                    else
                    {
                        firstA1Cell = row.Cells[1].Value.ToString().Trim();
                    }

                    if (firstA2Cell == row.Cells[2].Value.ToString().Trim())
                    {
                        row.Cells[2].Value = string.Empty;
                    }
                    else
                    {
                        firstA2Cell = row.Cells[2].Value.ToString().Trim();
                    }

                    if (firstA3Cell == row.Cells[3].Value.ToString().Trim())
                    {
                        row.Cells[3].Value = string.Empty;
                    }
                    else
                    {
                        firstA3Cell = row.Cells[3].Value.ToString().Trim();
                    }
                }
                else
                {
                    firstA1Cell = row.Cells[1].Value.ToString().Trim();
                    firstA2Cell = row.Cells[2].Value.ToString().Trim();
                    firstA3Cell = row.Cells[3].Value.ToString().Trim();
                }

                i++;
            }
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.LoadProductList();
        }
    }

    #region Detail Data

    public class DetailData
    {
        public Guid ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitAmount { get; set; }
    }

    #endregion
}
