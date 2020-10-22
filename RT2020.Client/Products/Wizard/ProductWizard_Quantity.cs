using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Windows.Forms;

using RT2020.DAL;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using RT2020.Client.Common;

namespace RT2020.Client.Products .Wizard
{
    public partial class ProductWizard_Quantity : UserControl
    {
        private Guid _ProductId = System.Guid.Empty;

        #region Pulbic Properties
        public Guid ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
            }
        }
        #endregion

        public ProductWizard_Quantity(Guid productid)
        {
            InitializeComponent();

            if (productid != System.Guid.Empty)
            {
                this.ProductId = productid;

                ShowQtyInfo();
                BindQtyTable();
                ShowRec();
            }
        }

        #region Qty Info
        private void ShowQtyInfo()
        {
            DAL.Product oProduct = DAL.Product.Load(_ProductId);
            if (oProduct != null)
            {
                txtMaxOLNQty.Text = oProduct.MaxOnLoanQty.ToString("n0");
            }

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

            string sql = "ProductId = '" + this.ProductId.ToString() + "' AND TxType IN (" + txType + ")" + type;
            InvtLedgerDetailsCollection oDetails = InvtLedgerDetails.LoadCollection(sql);
            for (int i = 0; i < oDetails.Count; i++)
            {
                switch (oDetails[i].TxType)
                {
                    case "REJ":
                        totalREJ += oDetails[i].Qty;
                        break;
                    case "REC":
                    case "CAP":
                        totalREC += oDetails[i].Qty;
                        break;
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

            string sql = "ProductId = '" + this.ProductId.ToString() + "' AND TxType IN (" + txType + ")" + type;
            PosLedgerDetailsCollection oDetails = PosLedgerDetails.LoadCollection(sql);
            for (int i = 0; i < oDetails.Count; i++)
            {
                switch (oDetails[i].TxType)
                {
                    case "CRT":
                    case "VOD":
                        totalVOD += oDetails[i].Qty;
                        break;
                    case "CAS":
                        totalCAS += oDetails[i].Qty;
                        break;
                }
            }

            result = totalCAS - totalVOD;

            return result;
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
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
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

            RT2020.DAL.WorkplaceCollection wList = RT2020.DAL.Workplace.LoadCollection(new string[] { "WorkplaceCode" }, true);
            foreach (RT2020.DAL.Workplace w in wList)
            {
                oTable.Columns.Add(w.WorkplaceCode, typeof(decimal));

                wpList.Add(w.WorkplaceCode);
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

        private void ShowRec()
        {
            string sql = "ProductId = '" + this.ProductId.ToString() + "'";
            ProductCurrentSummary oCurrentSummary = ProductCurrentSummary.LoadWhere(sql);
            if (oCurrentSummary != null)
            {
                this.txtOnHandQty.Text = oCurrentSummary.CDQTY.ToString("n0");

                txtAverageCost.Text = oCurrentSummary.AverageCost.ToString("n2");
                txtLastReceivingCost.Text = oCurrentSummary.LastCost.ToString("n2");
                txtLastPurDate.Text = oCurrentSummary.LastPurchasedOn.ToString(DateTimeHelper.GetDateFormat());
                txtLastSoldDate.Text = oCurrentSummary.LastSoldOn.ToString(DateTimeHelper.GetDateFormat());
            }
        }

        public bool SaveRec(Guid productId)
        {
            bool result = false;

            RT2020.DAL.Product oProduct = RT2020.DAL.Product.Load(productId);
            if (oProduct != null)
            {
                oProduct.MaxOnLoanQty = Convert.ToDecimal((txtMaxOLNQty.Text == string.Empty) ? "0" : txtMaxOLNQty.Text);

                oProduct.ModifiedBy = RT2020.DAL.Common.Config.CurrentUserId;
                oProduct.ModifiedOn = DateTime.Now;
                oProduct.Save();

                _ProductId = productId;
                result = true;
            }

            return result;
        }

        private void btnShowATSQty_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindQtyTable();
            Cursor.Current = Cursors.Default;
        }
    }
}