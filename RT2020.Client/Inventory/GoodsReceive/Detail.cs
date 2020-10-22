using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RT2020.DAL;

namespace RT2020.Client.Inventory.GoodsReceive
{
    public partial class Detail : Form
    {
        private bool _ShowAllQty = false;
        private bool _ShowAllWHQty = false;

        public List<DetailData> ResultList { get; set; }
        public string StockCode { get; set; }

        public Detail()
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
            lblStockCode.Text = Common.Utility.GetSystemLabelByKey("STKCODE");
            colAppendix1.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX3");
        }

        private void SetAttributes()
        {
            this.txtProductName.BackColor = Common.Theme.ControlBackColor.DisabledBox;
            this.txtTotalQty.BackColor = Common.Theme.ControlBackColor.DisabledBox;
            this.txtTotalAmount.BackColor = Common.Theme.ControlBackColor.DisabledBox;

            this.colWorkplace.Visible = false;

            Cursor.Current = Cursors.Default;
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
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimeoutValue"]);
            cmd.CommandType = CommandType.Text;

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);
            DataTable oTable = ds.Tables[0];

            foreach (DetailData detail in ResultList)
            {
                DataRow[] row = oTable.Select(string.Format("ProductId = '{0}' AND WorkplaceCode = ''", detail.ProductId.ToString()));
                if (row.Length > 0)
                {
                    row[0].BeginEdit();
                    row[0]["CDQTY"] = detail.Qty;
                    row[0]["UnitAmount"] = detail.UnitAmount;
                    row[0]["Amount"] = detail.UnitAmount * detail.Qty;
                    row[0].EndEdit();
                    row[0].AcceptChanges();
                    oTable.AcceptChanges();
                }
            }

            return oTable;
        }

        private string BuildQuery()
        {
            string sql = string.Empty;
            string pattern = "SELECT * FROM ({0} UNION ALL {1}) lst ";

            string queryProductList = @"
SELECT     ProductId, STKCODE, ProductName, APPENDIX1, APPENDIX2, APPENDIX3, '' AS WorkplaceCode, 0 AS BFQTY, 0 AS CDQTY, 0.00 AS UnitAmount, 0.00 AS Amount
FROM         dbo.vwProductList";

            string queryProductWithLocList = @"
SELECT     ProductId, STKCODE, '' AS ProductName, APPENDIX1, APPENDIX2, APPENDIX3, WorkplaceCode, BFQTY, CDQTY, 0.00 AS UnitAmount, 0.00 AS Amount
FROM         dbo.vwProductQtyListByWorkplace";

            string queryWHProductList = @"
SELECT     ProductId, STKCODE, '' AS ProductName, APPENDIX1, APPENDIX2, APPENDIX3, pwp.WorkplaceCode, pwp.BFQTY, pwp.CDQTY, 0.00 AS UnitAmount, 0.00 AS Amount
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

        private void txtStockCode_TextChanged(object sender, EventArgs e)
        {
            string where = string.Format("STKCODE = '{0}'", txtStockCode.Text.Trim());
            Product oProd = Product.LoadWhere(where);
            if (oProd != null)
            {
                Wizard oForm = (Wizard)this.Owner;
                this.ResultList = oForm.SetDetailData(oProd.STKCODE);

                this.txtProductName.Text = oProd.ProductName;
                BindData();
            }

        }

        private void dgvDetailList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Decimal qty = Decimal.Zero, uamt = Decimal.Zero, amt = Decimal.Zero;
            try
            {
                qty = Convert.ToDecimal(dgvDetailList.Rows[e.RowIndex].Cells[5].Value.ToString()); // Qty
                uamt = Convert.ToDecimal(dgvDetailList.Rows[e.RowIndex].Cells[7].Value.ToString()); // Unit Amount

                amt = (decimal)qty * uamt;
            }
            catch { }

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

                if (detail == null)
                {
                    detail = new DetailData();
                    detail.ProductId = productId;
                    detail.Qty = qty;
                    detail.UnitAmount = uamt;
                }
                else
                {
                    ResultList.Remove(detail);

                    detail.Qty = qty;
                    detail.UnitAmount = uamt;
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
                        cell.Style.BackColor = Common.Theme.ControlBackColor.DisabledBox;
                    }

                    if (cell.ColumnIndex == 4 && cell.Value.ToString().Trim().Length > 0) // Workplace
                    {
                        row.ReadOnly = true;
                        row.DefaultCellStyle.BackColor = Common.Theme.ControlBackColor.DisabledBox;
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
            this.Close();
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
