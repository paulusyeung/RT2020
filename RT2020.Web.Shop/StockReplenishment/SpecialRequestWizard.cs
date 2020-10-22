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

namespace RT2020.Web.Shop.StockReplenishment
{
    public partial class SpecialRequestWizard : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialRequestWizard"/> class.
        /// </summary>
        public SpecialRequestWizard()
        {
            InitializeComponent();
        }

        #region Properties

        private System.Guid detailId = System.Guid.Empty;
        private System.Guid productId = System.Guid.Empty;
        private string txNumber = string.Empty;
        private System.Guid fromLocation = System.Guid.Empty;
        private System.Guid headerId = System.Guid.Empty;
        private int selectedIndex = -1;

        /// <summary>
        /// Gets or sets the header id.
        /// </summary>
        /// <value>The header id.</value>
        public System.Guid HeaderId
        {
            get
            {
                return headerId;
            }
            set
            {
                headerId = value;
            }
        }


        /// <summary>
        /// Gets or sets from location.
        /// </summary>
        /// <value>From location.</value>
        public System.Guid FromLocation
        {
            get
            {
                return fromLocation;
            }
            set
            {
                fromLocation = value;
            }
        }

        #endregion

        /// <summary>
        /// Handles the Load event of the SpecialRequestWizard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SpecialRequestWizard_Load(object sender, EventArgs e)
        {
            GetSystemLabels();
            FillStockList();

            if (this.HeaderId == System.Guid.Empty)
            {
                this.Text += " [Add New]";
                this.txtTxNumber.Text = "[Auto-Generated]";
                this.txtTotalReplenishQty.Text = "0";

                ShowFromLocation();
            }
            else
            {
                this.Text += " [Edit]";

                if (this.FromLocation == System.Guid.Empty)
                {
                    LoadHeaderInfo();
                }
            }

            BindData();
        }

        #region Custom Methods
        /// <summary>
        /// Gets the system labels.
        /// </summary>
        private void GetSystemLabels()
        {
            colSTKCODE.Text = Common.Utility.GetSystemLabelByKey("STKCODE");
            colAppendix1.Text = Common.Utility.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.Text = Common.Utility.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.Text = Common.Utility.GetSystemLabelByKey("APPENDIX3");
        }

        /// <summary>
        /// Fills the stock list.
        /// </summary>
        private void FillStockList()
        {
            FillStkCode();
            FillAppendix();
        }

        /// <summary>
        /// Fills the STKCODE.
        /// </summary>
        private void FillStkCode()
        {
            cboSTKCODE.Items.Clear();

            string sql = "SELECT DISTINCT STKCODE FROM Product ORDER BY STKCODE";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (System.Data.SqlClient.SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    cboSTKCODE.Items.Add(reader.GetString(0));
                }
            }
        }

        /// <summary>
        /// Fills the appendix.
        /// </summary>
        private void FillAppendix()
        {
            ProductAppendix1.LoadCombo(ref cboAppendix1, "Appendix1Code", false, true, string.Empty, string.Empty);
            ProductAppendix2.LoadCombo(ref cboAppendix2, "Appendix2Code", false, true, string.Empty, string.Empty);
            ProductAppendix3.LoadCombo(ref cboAppendix3, "Appendix3Code", false, true, string.Empty, string.Empty);
        }

        /// <summary>
        /// Shows from location.
        /// </summary>
        private void ShowFromLocation()
        {
            Workplace oWp = Workplace.Load(this.FromLocation);
            if (oWp != null)
            {
                txtFromLocation.Text = oWp.WorkplaceCode + " - " + oWp.WorkplaceName;
            }
            else
            {
                txtFromLocation.Text = string.Empty;
            }
        }

        /// <summary>
        /// Gets the on hand qty.
        /// </summary>
        /// <param name="workplaceId">The workplace id.</param>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        private decimal GetOnHandQty(Guid workplaceId, Guid productId)
        {
            string query = "ProductId = '" + productId.ToString() + "' AND WorkplaceId = '" + workplaceId.ToString() + "'";
            ProductWorkplace oPw = ProductWorkplace.LoadWhere(query);
            if (oPw != null)
            {
                return oPw.CDQTY;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        private void Clear()
        {
            txtBarcode.Text = string.Empty;
            cboSTKCODE.SelectedItem = string.Empty;
            cboAppendix1.SelectedItem = string.Empty;
            cboAppendix2.SelectedItem = string.Empty;
            cboAppendix3.SelectedItem = string.Empty;
            txtReplenishQty.Text = "0";

            selectedIndex = -1;
            detailId = System.Guid.Empty;
            productId = System.Guid.Empty;

            btnUpdate.Text = "Add";
        }
        #endregion

        #region Bind Data
        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData()
        {
            listView.Items.Clear();

            string query = @"
SELECT     TOP (100) PERCENT rd.DetailsId, rd.HeaderId, rd.TxNumber, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, ISNULL
                          ((SELECT     CDQTY
                              FROM         dbo.ProductWorkplace AS frompw
                              WHERE     (ProductId = rd.ProductId) AND (WorkplaceId = '" + this.FromLocation.ToString() + @"')), 0) AS From_CDQTY, ISNULL
                          ((SELECT     CDQTY
                              FROM         dbo.ProductWorkplace AS topw
                              WHERE     (ProductId = rd.ProductId) AND (WorkplaceId = '" + Common.Utility.CurrentWorkplaceId.ToString() + @"')), 0) AS To_CDQTY, rd.QtyRequested, p.ProductName
FROM         dbo.InvtBatchRPL_Details AS rd LEFT OUTER JOIN
                      dbo.Product AS p ON rd.ProductId = p.ProductId
WHERE     (rd.HeaderId = '" + this.HeaderId.ToString() + @"')
ORDER BY p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (System.Data.SqlClient.SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.listView.Items.Add(reader.GetGuid(0).ToString());
                    objItem.SubItems.Add(string.Empty); // Status
                    objItem.SubItems.Add(reader.GetString(3)); // STKCODE
                    objItem.SubItems.Add(reader.GetString(4));
                    objItem.SubItems.Add(reader.GetString(5));
                    objItem.SubItems.Add(reader.GetString(6));
                    objItem.SubItems.Add(reader.GetDecimal(7).ToString("n0")); // FM C/D
                    objItem.SubItems.Add(reader.GetDecimal(8).ToString("n0"));
                    objItem.SubItems.Add(reader.GetDecimal(9).ToString("n0")); // RPL
                    objItem.SubItems.Add(reader.GetString(10));
                }
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            SaveHeaderInfo();
            SaveDetailInfo();
        }

        /// <summary>
        /// Saves the header info.
        /// </summary>
        private void SaveHeaderInfo()
        {
            InvtBatchRPL_Header oRPL = InvtBatchRPL_Header.Load(this.HeaderId);
            if (oRPL == null)
            {
                oRPL = new InvtBatchRPL_Header();

                txNumber = Common.Utility.QueuingTxNumber(RT2020.DAL.Common.Enums.TxType.RPL);
                oRPL.TxNumber = txNumber;
                oRPL.TxDate = DateTime.Now;
                oRPL.FromLocation = GetLocationCode(this.FromLocation);
                oRPL.ToLocation = GetLocationCode(Common.Utility.CurrentWorkplaceId);
                oRPL.TXFOn = DateTime.Now;
                oRPL.Status = 1;
                oRPL.StaffId = Common.Utility.CurrentUserId;
                oRPL.Confirmed = false;
                oRPL.ConfirmedBy = Common.Utility.CurrentUserId;
                oRPL.ConfirmedOn = DateTime.Now;
                oRPL.SpecialRequest = true;
                oRPL.Posted = false;


                oRPL.CreatedBy = Common.Utility.CurrentUserId;
                oRPL.CreatedOn = DateTime.Now;
            }

            oRPL.ModifiedBy = Common.Utility.CurrentUserId;
            oRPL.ModifiedOn = DateTime.Now;
            oRPL.Retired = false;
            oRPL.RetiredBy = System.Guid.Empty;
            oRPL.RetiredOn = new DateTime(1900, 1, 1);

            oRPL.Save();

            this.HeaderId = oRPL.HeaderId;
        }

        /// <summary>
        /// Saves the detail info.
        /// </summary>
        private void SaveDetailInfo()
        {
            for (int i = 0; i < listView.Items.Count; i++)
            {
                ListViewItem oItem = listView.Items[i];

                if (!oItem.SubItems[1].Text.Contains("D"))
                {
                    string query = "STKCODE = '" + oItem.SubItems[2].Text + "' AND APPENDIX1 = '" + oItem.SubItems[3].Text + @"'
                        AND APPENDIX2 = '" + oItem.SubItems[4].Text + "' AND APPENDIX3 = '" + oItem.SubItems[5].Text + "'";
                    Product oProduct = Product.LoadWhere(query);
                    if (oProduct != null)
                    {
                        productId = oProduct.ProductId;

                        query = "ProductId = '" + productId.ToString() + "' AND DetailsId = '" + oItem.SubItems[0].Text + "'";
                        InvtBatchRPL_Details oDetail = InvtBatchRPL_Details.LoadWhere(query);
                        if (oDetail == null)
                        {
                            oDetail = new InvtBatchRPL_Details();

                            oDetail.HeaderId = this.HeaderId;
                            oDetail.TxNumber = txNumber;
                            oDetail.LineNumber = i + 1;
                            oDetail.ProductId = productId;
                        }
                        oDetail.QtyRequested = Convert.ToDecimal(oItem.SubItems[8].Text);

                        oDetail.Save();
                    }
                }
                else
                {
                    if (RT2020.DAL.Common.Utility.IsGUID(oItem.SubItems[0].Text))
                    {
                        InvtBatchRPL_Details oDetail = InvtBatchRPL_Details.Load(new Guid(oItem.SubItems[0].Text));
                        if (oDetail != null)
                        {
                            oDetail.Delete();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the location code.
        /// </summary>
        /// <param name="workplaceId">The workplace id.</param>
        /// <returns></returns>
        private string GetLocationCode(System.Guid workplaceId)
        {
            Workplace oWp = Workplace.Load(workplaceId);
            if (oWp != null)
            {
                return oWp.WorkplaceCode;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region Load
        /// <summary>
        /// Loads the header info.
        /// </summary>
        private void LoadHeaderInfo()
        {
            InvtBatchRPL_Header oHeader = InvtBatchRPL_Header.Load(this.HeaderId);
            if (oHeader != null)
            {
                this.txtTxNumber.Text = oHeader.TxNumber;

                string query = "WorkplaceCode = '" + oHeader.FromLocation + "'";
                Workplace oWp = Workplace.LoadWhere(query);
                if (oWp != null)
                {
                    this.FromLocation = oWp.WorkplaceId;
                }

                ShowFromLocation();
                CalcTotalRplQty();
            }
        }

        /// <summary>
        /// Calcs the total RPL qty.
        /// </summary>
        private void CalcTotalRplQty()
        {
            decimal totalQty = 0;

            string query = "HeaderId = '" + this.HeaderId.ToString() + "'";
            InvtBatchRPL_DetailsCollection oDetailList = InvtBatchRPL_Details.LoadCollection(query);
            foreach (InvtBatchRPL_Details oDetail in oDetailList)
            {
                totalQty += oDetail.QtyRequested;
            }

            txtTotalReplenishQty.Text = totalQty.ToString("n0");
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                listView.Items[selectedIndex].SubItems[1].Text = "E";
                listView.Items[selectedIndex].SubItems[8].Text = txtReplenishQty.Text;

                Clear();
            }
            else
            {
                string stkcode = string.Empty, a1 = string.Empty, a2 = string.Empty, a3 = string.Empty, desc = string.Empty;
                string query = string.Empty;
                Product oProduct;

                if (txtBarcode.Text.Trim().Length > 0)
                {
                    query = "Barcode = '" + txtBarcode.Text.Trim() + "'";

                    ProductBarcode oBarcode = ProductBarcode.LoadWhere(query);
                    if (oBarcode != null)
                    {
                        productId = oBarcode.ProductId;
                    }
                }

                if (productId == System.Guid.Empty)
                {
                    query = "STKCODE = '" + cboSTKCODE.SelectedItem.ToString() + "' AND APPENDIX1 = '" + cboAppendix1.SelectedItem.ToString() + @"'
                        AND APPENDIX2 = '" + cboAppendix2.SelectedItem.ToString() + "' AND APPENDIX3 = '" + cboAppendix3.SelectedItem.ToString() + "'";
                    oProduct = Product.LoadWhere(query);
                }
                else
                {
                    oProduct = Product.Load(productId);
                }

                if (oProduct != null)
                {
                    productId = oProduct.ProductId;
                    stkcode = oProduct.STKCODE;
                    a1 = oProduct.APPENDIX1;
                    a2 = oProduct.APPENDIX2;
                    a3 = oProduct.APPENDIX3;
                    desc = oProduct.ProductName;
                }

                if (productId != System.Guid.Empty)
                {
                    ListViewItem objItem = this.listView.Items.Add(System.Guid.Empty.ToString());
                    objItem.SubItems.Add("N"); // Status
                    objItem.SubItems.Add(stkcode); // STKCODE
                    objItem.SubItems.Add(a1);
                    objItem.SubItems.Add(a2);
                    objItem.SubItems.Add(a3);
                    objItem.SubItems.Add(GetOnHandQty(this.FromLocation, productId).ToString("n0")); // FM C/D
                    objItem.SubItems.Add(GetOnHandQty(Common.Utility.CurrentWorkplaceId, productId).ToString("n0"));
                    objItem.SubItems.Add(txtReplenishQty.Text); // RPL
                    objItem.SubItems.Add(desc);

                    Clear();
                }
                else
                {
                    MessageBox.Show("Stock code not found!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (!(listView.Items[selectedIndex].SubItems[1].Text.Contains("N") && listView.Items[selectedIndex].SubItems[1].Text.Contains("E")))
                {
                    listView.Items[selectedIndex].SubItems[1].Text = "D";
                }
            }
        }

        /// <summary>
        /// Handles the ButtonClick event of the toolBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs"/> instance containing the event data.</param>
        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Name.ToLower())
            {
                case "tbtnsave":
                    this.Save();
                    this.BindData();
                    this.CalcTotalRplQty();

                    MessageBox.Show("Save Successfully!", "Message");
                    break;
                case "tbtnprint":
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the listView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void listView_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                if (RT2020.DAL.Common.Utility.IsGUID(listView.SelectedItem.Text))
                {
                    selectedIndex = listView.SelectedIndex;
                    detailId = new Guid(listView.SelectedItem.Text);

                    cboSTKCODE.SelectedItem = listView.SelectedItem.SubItems[2].Text;
                    cboAppendix1.SelectedItem = listView.SelectedItem.SubItems[3].Text;
                    cboAppendix2.SelectedItem = listView.SelectedItem.SubItems[4].Text;
                    cboAppendix3.SelectedItem = listView.SelectedItem.SubItems[5].Text;

                    txtReplenishQty.Text = listView.SelectedItem.SubItems[8].Text;

                    btnUpdate.Text = "Update";
                }
            }
        }
    }
}