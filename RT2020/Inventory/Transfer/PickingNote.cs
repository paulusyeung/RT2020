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
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace RT2020.Inventory.Transfer
{
    public partial class PickingNote : UserControl
    {
        public PickingNote(Guid txferId)
        {
            InitializeComponent();
            this.TxferId = txferId;
            BindTxferDetailsInfo();
        }

        #region Properties

        private Guid txferId = System.Guid.Empty;
        public Guid TxferId
        {
            get
            {
                return txferId;
            }
            set
            {
                txferId = value;
            }
        }

        private Guid txferDetailId = System.Guid.Empty;
        public Guid TxferDetailId
        {
            get
            {
                return txferDetailId;
            }
            set
            {
                txferDetailId = value;
            }
        }

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

        private int SelectedIndex = 0;
        #endregion

        #region Bind Picking Note Detail List
        private void BindTxferDetailsInfo()
        {
            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" QtyRequested, Remarks, ProductId ");
            sql.Append(" FROM vwTxferDetailsList ");
            sql.Append(" WHERE HeaderId = '").Append(this.TxferId.ToString()).Append("'");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem listItem = lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); // DetailsId
                    listItem.SubItems.Add(iCount.ToString()); // LineNumber
                    listItem.SubItems.Add(string.Empty);
                    listItem.SubItems.Add(reader.GetString(2)); // STKCode
                    listItem.SubItems.Add(reader.GetString(3)); // Appendix1
                    listItem.SubItems.Add(reader.GetString(4)); // Appendix2
                    listItem.SubItems.Add(reader.GetString(5)); // Appendix3
                    listItem.SubItems.Add(reader.GetString(6)); // ProductName
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0")); // QtyRequested
                    listItem.SubItems.Add(reader.GetString(8)); // Remarks
                    listItem.SubItems.Add(reader.GetGuid(9).ToString()); // ProductId

                    iCount++;
                }
            }

            lblLineCount.Text = (iCount - 1).ToString();
        }
        #endregion

        #region Load Picking Note Detail Info
        private void LoadTxferDetailsInfo(Guid detailId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" QtyRequested, Remarks, ProductId ");
            sql.Append(" FROM vwTxferDetailsList ");
            sql.Append(" WHERE DetailsId = '").Append(detailId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    SetStockCode(reader);

                    txtDescription.Text = reader.GetString(6);
                    txtRequiredQty.Text = reader.GetDecimal(7).ToString("n0");
                    txtRemarks_Detail.Text = reader.GetString(8);

                    this.ProductId = reader.GetGuid(9);
                }
            }
        }
        private void SetStockCode(SqlDataReader reader)
        {
            basicProduct.SelectedText = reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5);
            basicProduct.SelectedItem = reader.GetGuid(9);
        }
        #endregion

        #region Add/Edit/Remove Item
        private bool IsDuplicated(string stkCode, string appendix1, string appendix2, string appendix3)
        {
            bool isDuplicated = false;

            foreach (ListViewItem oItem in lvDetailsList.Items)
            {
                if (stkCode.Length > 0)
                {
                    isDuplicated = (oItem.SubItems[3].Text == stkCode);
                    isDuplicated = isDuplicated & (oItem.SubItems[4].Text == appendix1);
                    isDuplicated = isDuplicated & (oItem.SubItems[5].Text == appendix2);
                    isDuplicated = isDuplicated & (oItem.SubItems[6].Text == appendix3);
                }
            }

            return isDuplicated;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
            ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

            if (IsDuplicated(stkCode, appendix1, appendix2, appendix3))
            {
                //this.Invoke(new EventHandler(btnEditItem_Click), new object[] { this, e });
                MessageBox.Show(string.Format(Resources.Common.DuplicatedCode, "Stock Item"), string.Format(Resources.Common.DuplicatedCode, string.Empty));
            }
            else
            {
                if (this.ProductId != System.Guid.Empty)
                {
                    ListViewItem listItem = lvDetailsList.Items.Add(System.Guid.Empty.ToString());
                    listItem.SubItems.Add(lvDetailsList.Items.Count.ToString());
                    listItem.SubItems.Add("NEW"); // Status
                    listItem.SubItems.Add(stkCode); // Stock Code
                    listItem.SubItems.Add(appendix1); // Appendix1
                    listItem.SubItems.Add(appendix2); // Appendix2
                    listItem.SubItems.Add(appendix3); // Appendix3
                    listItem.SubItems.Add(txtDescription.Text); // Description
                    listItem.SubItems.Add(txtRequiredQty.Text.Length == 0 ? "0" : txtRequiredQty.Text); // Required Qty
                    listItem.SubItems.Add(txtRemarks_Detail.Text); // Remarks
                    listItem.SubItems.Add(this.ProductId.ToString()); // ProductId
                }
                else
                {
                    MessageBox.Show("Record not found!", "Warning");
                }
            }
        }

        private void ItemInfo(ref string stkCode, ref string appendix1, ref string appendix2, ref string appendix3)
        {
            if (basicProduct.SelectedItem != null)
            {
                string query = string.Empty;
                if (basicProduct.SelectedItem != null)
                {
                    query = "ProductId = '" + basicProduct.SelectedItem.ToString() + "'";
                }
                else if (basicProduct.cboFullStockCode.Text.Trim().Length > 0)
                {
                    query = BuildWhereClause(basicProduct.cboFullStockCode.Text.Trim());
                }

                if (query.Length > 0)
                {
                    var oProd = ModelEx.ProductEx.Get(query);
                    if (oProd != null)
                    {
                        stkCode = oProd.STKCODE;
                        appendix1 = oProd.APPENDIX1;
                        appendix2 = oProd.APPENDIX2;
                        appendix3 = oProd.APPENDIX3;

                        this.ProductId = oProd.ProductId;
                    }
                }
            }
        }

        private string BuildWhereClause(string value)
        {
            StringBuilder whereClause = new StringBuilder();
            string a1 = string.Empty, a2 = string.Empty, a3 = string.Empty;

            if (value.Contains(" "))
            {
                string[] prodCode = value.Split(new char[] { ' ' });
                switch (prodCode.Length)
                {
                    case 1:
                        whereClause.Append(" STKCODE = '").Append(prodCode[0]).Append("'");
                        break;
                    case 2:
                        whereClause.Append(" STKCODE = '").Append(prodCode[0]).Append("'");
                        whereClause.Append(" AND APPENDIX1 = '").Append(prodCode[1]).Append("'");
                        break;
                    case 3:
                        whereClause.Append(" STKCODE = '").Append(prodCode[0]).Append("'");
                        whereClause.Append(" AND APPENDIX1 = '").Append(prodCode[1]).Append("'");
                        whereClause.Append(" AND APPENDIX2 = '").Append(prodCode[2]).Append("'");
                        break;
                    case 4:
                        whereClause.Append(" STKCODE = '").Append(prodCode[0]).Append("'");
                        whereClause.Append(" AND APPENDIX1 = '").Append(prodCode[1]).Append("'");
                        whereClause.Append(" AND APPENDIX2 = '").Append(prodCode[2]).Append("'");
                        whereClause.Append(" AND APPENDIX3 = '").Append(prodCode[3]).Append("'");
                        break;
                }
            }
            else
            {
                whereClause.Append(" STKCODE LIKE '" + value + "%' ");
            }

            return whereClause.ToString();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
            ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

            if (lvDetailsList.SelectedItem != null)
            {
                ListViewItem listItem = lvDetailsList.SelectedItem;
                listItem.SubItems[2].Text = "EDIT"; // Status
                listItem.SubItems[3].Text = stkCode; // Stock Code
                listItem.SubItems[4].Text = appendix1; // Appendix1
                listItem.SubItems[5].Text = appendix2; // Appendix2
                listItem.SubItems[6].Text = appendix3; // Appendix3
                listItem.SubItems[7].Text = txtDescription.Text; // Description
                listItem.SubItems[8].Text = txtRequiredQty.Text; // Required Qty
                listItem.SubItems[9].Text = txtRemarks_Detail.Text; // Remarks
                listItem.SubItems[10].Text = this.ProductId.ToString(); // ProductId
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null)
            {
                if (lvDetailsList.SelectedItem.Text != System.Guid.Empty.ToString())
                {
                    ListViewItem listItem = lvDetailsList.SelectedItem;
                    listItem.SubItems[2].Text = "REMOVED"; // Status
                }
                else
                {
                    lvDetailsList.Items.Remove(lvDetailsList.SelectedItem);
                    lvDetailsList.Update();
                }
            }
        }
        #endregion

        private void basicProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        {
            txtDescription.Text = e.Description;
        }

        private void lvDetailsList_Click(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvDetailsList.SelectedItem.Text))
                {
                    LoadTxferDetailsInfo(new Guid(lvDetailsList.SelectedItem.Text));
                    this.TxferDetailId = new Guid(lvDetailsList.SelectedItem.Text);
                    this.SelectedIndex = lvDetailsList.SelectedIndex;
                    this.txtRemarks_Detail.Text = lvDetailsList.SelectedItem.SubItems[9].Text;
                }
            }
        }
    }
}