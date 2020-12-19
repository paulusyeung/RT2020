using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;


using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using RT2020.Helper;

namespace RT2020.Product
{
    public partial class ProductWizard_Quantity : UserControl
    {
        public ProductWizard_Quantity(Guid productid)
        {
            InitializeComponent();
            this.ProductId = productid;

            ShowQtyInfo();
            BindQtyTable();
            ShowCurrentSummaryInfo();
        }

        #region Qty Info
        private void ShowQtyInfo()
        {
            txtMTDPurQty.Text = PurQty("'CAP', 'REC', 'REJ'", "M").ToString("n0");
            txtYTDPurQty.Text = PurQty("'CAP', 'REC', 'REJ'", "Y").ToString("n0");
            txtMTDSoldQty.Text = SoldQty("'CAS', 'CRT', 'VOD'", "M").ToString("n0");
            txtYTDSoldQty.Text = SoldQty("'CAS', 'CRT', 'VOD'", "Y").ToString("n0");
        }

        private decimal PurQty(string txType, string type)
        {
            decimal result = 0, totalREC = 0, totalREJ = 0;

            if (type == "M")
            {
                type = "AND YEAR(TxDate) = " + DateTime.Now.Year.ToString() + " AND MONTH(TxDate) = " + DateTime.Now.Month.ToString();
            }
            else
            {
                type = "AND YEAR(TxDate) = " + DateTime.Now.Year.ToString();
            }

            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + this.ProductId.ToString() + "' AND TxType IN (" + txType + ")" + type;
                var oDetails = ctx.InvtLedgerDetails.Where(x => x.ProductId == this.ProductId && txType.Contains(x.TxType)).AsNoTracking().ToList();
                foreach (var detail in oDetails)
                {
                    switch (detail.TxType)
                    {
                        case "REJ":
                            totalREJ += detail.Qty.Value;
                            break;
                        case "REC":
                        case "CAP":
                            totalREC += detail.Qty.Value;
                            break;
                    }
                }
            }

            result = totalREC - totalREJ;

            return result;
        }

        private decimal SoldQty(string txType, string type)
        {
            decimal result = 0, totalCAS = 0, totalVOD = 0;

            if (type == "M")
            {
                type = "AND YEAR(TxDate) = " + DateTime.Now.Year.ToString() + " AND MONTH(TxDate) = " + DateTime.Now.Month.ToString();
            }
            else
            {
                type = "AND YEAR(TxDate) = " + DateTime.Now.Year.ToString();
            }

            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + this.ProductId.ToString() + "' AND TxType IN (" + txType + ")" + type;
                var oDetails = ctx.PosLedgerDetails.Where(x => x.ProductId == this.ProductId && txType.Contains(x.TxType)).ToList();
                foreach (var detail in oDetails)
                {
                    switch (detail.TxType)
                    {
                        case "CRT":
                        case "VOD":
                            totalVOD += detail.Qty.Value;
                            break;
                        case "CAS":
                            totalCAS += detail.Qty.Value;
                            break;
                    }
                }
            }

            result = totalCAS - totalVOD;

            return result;
        }
        #endregion

        #region Properties
        private Guid productId = System.Guid.Empty;
        public Guid ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }
        #endregion

        private void BindQtyTable()
        {
            DataTable oTable = QtyTable("BFQty");
            oTable.Merge(QtyTable("CDQty"));
            oTable.Merge(QtyTable("FEPQTY"));
            oTable.Merge(QtyTable("RECQTY"));
            oTable.Merge(QtyTable("INVQTY"));
            oTable.Merge(QtyTable("POQTY"));
            oTable.Merge(QtyTable("SOQTY"));
            oTable.Merge(QtyTable("REJQTY"));
            oTable.Merge(QtyTable("EPQTY"));

            if (oTable.Rows.Count <= 0)
            {
                oTable = BuildEmptyTable();
            }

            dgvQtyList.DataSource = oTable;
        }

        private DataTable QtyTable(string qtyColumn)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            SqlParameter aggFunc = new SqlParameter("@Aggregate_Function", "SUM");
            paramList.Add(aggFunc);

            SqlParameter aggCol = new SqlParameter("@Aggregate_Column", qtyColumn);
            paramList.Add(aggCol);

            SqlParameter tableName = new SqlParameter("@TableOrView_Name", "vwProductQtyListByWorkplace");
            paramList.Add(tableName);

            SqlParameter selectCol = new SqlParameter("@Select_Column", "ProductId");
            paramList.Add(selectCol);

            SqlParameter pivotCol = new SqlParameter("@Pivot_Column", "WorkplaceCode");
            paramList.Add(pivotCol);

            SqlParameter ProductIdCol = new SqlParameter("@ProductId", this.ProductId.ToString());
            paramList.Add(ProductIdCol);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "apProductQtyByWorkplaceCode";
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddRange(paramList.ToArray());

            using (DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                // Remove the total row
                if (ds.Tables[0].Rows.Count > 1)
                {
                    ds.Tables[0].Rows.RemoveAt(ds.Tables[0].Rows.Count - 1);
                    // Change the columns
                    ds.Tables[0].Columns[0].ColumnName = "Description";
                    ds.Tables[0].Rows[0][0] = qtyColumn;
                }

                return ds.Tables[0];
            }
        }

        private DataTable BuildEmptyTable()
        {
            List<string> wpList = new List<string>();

            DataTable oTable = new DataTable();
            oTable.Columns.Add("Description", typeof(string));

            string[] qtyList = new string[] { "BFQty", "CDQty", "FEPQTY", "RECQTY", "INVQTY", "POQTY", "SOQTY", "REJQTY", "EPQTY" };

            using (var ctx = new EF6.RT2020Entities())
            {
                var wList = ctx.Workplace.OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                foreach (var w in wList)
                {
                    oTable.Columns.Add(w.WorkplaceCode, typeof(decimal));

                    wpList.Add(w.WorkplaceCode);
                }
            }

            for (int i = 0; i < qtyList.Length; i++)
            {
                DataRow row = oTable.NewRow();
                row["Description"] = qtyList[i];

                foreach (string wp in wpList)
                {
                    row[wp] = 0;
                }

                oTable.Rows.Add(row);
            }

            return oTable;
        }

        private void ShowCurrentSummaryInfo()
        {
            var oCurrentSummary = ModelEx.ProductCurrentSummaryEx.GetByProductCode(this.ProductId);
            if (oCurrentSummary != null)
            {
                this.txtOnHandQty.Text = oCurrentSummary.CDQTY.ToString("n0");

                txtAverageCost.Text = oCurrentSummary.AverageCost.ToString("n2");
                txtLastReceivingCost.Text = oCurrentSummary.LastCost.ToString("n2");
                txtLastPurDate.Text = oCurrentSummary.LastPurchasedOn.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat());
                txtLastSoldDate.Text = oCurrentSummary.LastSoldOn.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat());
            }
        }

        private void btnShowATSQty_Click(object sender, EventArgs e)
        {
            BindQtyTable();
        }
    }
}