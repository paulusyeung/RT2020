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
using RT2020.Helper;

#endregion

namespace RT2020.PriceMgmt
{
    public partial class PriceMgmtWizard_Details : UserControl
    {
        private Guid _HeaderId = System.Guid.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceMgmtWizard_Details"/> class.
        /// </summary>
        public PriceMgmtWizard_Details()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.UserControl.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SetAttributes();

            this.BindingData();
        }

        #region Set Attributes

        /// <summary>
        /// Sets the attributes.
        /// </summary>
        private void SetAttributes()
        {
            txtSTKCODE.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            txtDescription.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            txtAverageCost.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            txtOldPrice.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            txtDifference.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            txtOldMarkUp.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            txtNewMarkUp.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            txtOldDiscount.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;

            colSTKCODE.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            colAPPENDIX1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            colAPPENDIX2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            colAPPENDIX3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");

            colClass1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1");
            colClass2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS2");
            colClass3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS3");
            colClass4.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS4");
            colClass5.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS5");
            colClass6.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS6");

            this.lvItemList.ListViewItemSorter = new ListViewItemSorter(this.lvItemList);

            // Hide some columns
            if (this.ListType == PriceUtility.PriceMgmtType.Price)
            {
                colOldPrice.Text = "Old Price";

                colOldDiscount.Visible = false;
                colNewDiscount.Visible = false;

                colOldMarkUp.Visible = true;
                colNewMarkUp.Visible = true;
                colNewPrice.Visible = true;
                colDiff.Visible = true;

                lblAverageCost.Visible = true;
                lblOldPrice.Visible = true;
                lblDifference.Visible = true;
                lblOldMarkUp.Visible = true;
                lblNewMarkUp.Visible = true;
                lblNewPrice.Visible = true;

                txtAverageCost.Visible = true;
                txtOldPrice.Visible = true;
                txtDifference.Visible = true;
                txtOldMarkUp.Visible = true;
                txtNewMarkUp.Visible = true;
                txtNewPrice.Visible = true;

                lblOldDiscount.Visible = false;
                lblNewDiscount.Visible = false;
                txtOldDiscount.Visible = false;
                txtNewDiscount.Visible = false;
            }
            else
            {
                colOldPrice.Text = "Retail Price";

                colOldDiscount.Visible = true;
                colNewDiscount.Visible = true;

                colOldMarkUp.Visible = false;
                colNewMarkUp.Visible = false;
                colNewPrice.Visible = false;
                colDiff.Visible = false;

                lblAverageCost.Visible = false;
                lblOldPrice.Visible = false;
                lblDifference.Visible = false;
                lblOldMarkUp.Visible = false;
                lblNewMarkUp.Visible = false;
                lblNewPrice.Visible = false;

                txtAverageCost.Visible = false;
                txtOldPrice.Visible = false;
                txtDifference.Visible = false;
                txtOldMarkUp.Visible = false;
                txtNewMarkUp.Visible = false;
                txtNewPrice.Visible = false;

                lblOldDiscount.Visible = true;
                lblOldDiscount.Location = lblAverageCost.Location;
                lblNewDiscount.Visible = true;
                lblNewDiscount.Location = lblOldPrice.Location;

                txtOldDiscount.Visible = true;
                txtOldDiscount.Location = txtAverageCost.Location;
                txtNewDiscount.Visible = true;
                txtNewDiscount.Location = txtOldPrice.Location;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// the type of the list.
        /// </summary>
        private PriceUtility.PriceMgmtType listType = PriceUtility.PriceMgmtType.Price;

        /// <summary>
        /// Gets or sets the type of the list.
        /// </summary>
        /// <value>The type of the list.</value>
        public PriceUtility.PriceMgmtType ListType
        {
            get
            {
                return listType;
            }
            set
            {
                listType = value;
            }
        }

        /// <summary>
        /// Gets or sets the header id.
        /// </summary>
        /// <value>The header id.</value>
        public Guid HeaderId
        {
            get
            {
                return _HeaderId;
            }
            set
            {
                _HeaderId = value;
            }
        }

        /// <summary>
        /// the detail id.
        /// </summary>
        private Guid detailId = System.Guid.Empty;

        /// <summary>
        /// Gets or sets the detail id.
        /// </summary>
        /// <value>The detail id.</value>
        public Guid DetailId
        {
            get
            {
                return detailId;
            }
            set
            {
                detailId = value;
            }
        }


        /// <summary>
        /// the product id.
        /// </summary>
        private Guid productId = System.Guid.Empty;

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>The product id.</value>
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

        #region Binding Data

        /// <summary>
        /// Bindings the data.
        /// </summary>
        private void BindingData()
        {
            int iCount = 0;
            lvItemList.Items.Clear();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = BuildQuery();
            cmd.CommandTimeout = 600;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    decimal avgCost = reader.GetDecimal(24); // Average Cost
                    decimal oldMu = 0, diff = 0, oldDiscount = 0, oldPrice = 0;
                    decimal newMu = 0, newPrice = 0, newDiscount = 0;

                    if (this.ListType == PriceUtility.PriceMgmtType.Price)
                    {
                        oldPrice = reader.GetDecimal(25); // OLD_FIGURE
                        newPrice = reader.GetDecimal(26); // NEW_FIGURE

                        if (avgCost > 0)
                        {
                            oldMu = ((oldPrice / avgCost) - 1) * 100;
                            newMu = ((newPrice / avgCost) - 1) * 100;
                        }

                        diff = newMu - oldMu;
                    }
                    else
                    {
                        oldPrice = reader.GetDecimal(17); // RetailPrice
                        oldDiscount = reader.GetDecimal(25); // OLD_FIGURE
                        newDiscount = reader.GetDecimal(26); // NEW_FIGURE
                    }

                    ListViewItem lvItem = lvItemList.Items.Add(reader.GetGuid(0).ToString()); // Detail Id
                    lvItem.SubItems.Add(string.Empty); // N = New
                    lvItem.SubItems.Add(reader.GetString(5)); // STKCODE
                    lvItem.SubItems.Add(reader.GetString(6)); // APPENDIX1
                    lvItem.SubItems.Add(reader.GetString(7)); // APPENDIX2
                    lvItem.SubItems.Add(reader.GetString(8)); // APPENDIX3
                    lvItem.SubItems.Add(avgCost.ToString()); // Average Cost
                    lvItem.SubItems.Add(oldPrice.ToString("n2")); // Old Price
                    lvItem.SubItems.Add(oldMu.ToString("n2")); // Old MarkUp
                    lvItem.SubItems.Add(newPrice.ToString("n2")); // New Price
                    lvItem.SubItems.Add(newMu.ToString("n2")); // New MarkUp
                    lvItem.SubItems.Add(diff.ToString("n2")); // Difference
                    lvItem.SubItems.Add(oldDiscount.ToString("n2")); // Old Discount
                    lvItem.SubItems.Add(newDiscount.ToString("n2")); // new Discount
                    lvItem.SubItems.Add(reader.GetString(16)); // Descritpion
                    lvItem.SubItems.Add(reader.GetString(9)); // Class1
                    lvItem.SubItems.Add(reader.GetString(10)); // Class2
                    lvItem.SubItems.Add(reader.GetString(11)); // Class3
                    lvItem.SubItems.Add(reader.GetString(12)); // Class4
                    lvItem.SubItems.Add(reader.GetString(13)); // Class5
                    lvItem.SubItems.Add(reader.GetString(14)); // Class6
                    lvItem.SubItems.Add("N"); // Update VIP Discount
                    lvItem.SubItems.Add((reader.GetBoolean(19) ? "Y" : "N")); // Fixed price item
                    lvItem.SubItems.Add(reader.GetDecimal(20).ToString()); // Discount For Fixed price Item
                    lvItem.SubItems.Add(reader.GetDecimal(21).ToString()); // Discount for Discount Item
                    lvItem.SubItems.Add(reader.GetDecimal(22).ToString()); // Disocunt for No Discount Item
                    lvItem.SubItems.Add(reader.GetDecimal(23).ToString()); // Staff Discount
                    lvItem.SubItems.Add(reader.GetGuid(15).ToString());

                    iCount++;
                }
            }

            txtNumberOfLine.Text = iCount.ToString();
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        private string BuildQuery()
        {
            string sql = @"
SELECT  pbd.DetailId, pbd.HeaderId, pbd.LineNumber, pbd.TxNumber, pbd.TxType, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, p.CLASS1, p.CLASS2, p.CLASS3, 
        p.CLASS4, p.CLASS5, p.CLASS6, p.ProductId, p.ProductName, p.RetailPrice, p.NormalDiscount, p.FixedPriceItem, ISNULL(ps.VipDiscount_FixedItem, 0) AS VipDiscount_FixedItem, 
        ISNULL(ps.VipDiscount_DiscountItem, 0) AS VipDiscount_DiscountItem, ISNULL(ps.VipDiscount_NoDiscountItem, 0) AS VipDiscount_NoDiscountItem, 
        ISNULL(ps.StaffDiscount, 0) AS StaffDiscount, ISNULL(pcs.AverageCost, 0) AS AverageCost, pbd.OLD_FIGURE, pbd.NEW_FIGURE
FROM    dbo.ProductCurrentSummary AS pcs RIGHT OUTER JOIN
        dbo.Product AS p ON pcs.ProductId = p.ProductId LEFT OUTER JOIN
        dbo.ProductSupplement AS ps ON p.ProductId = ps.ProductId RIGHT OUTER JOIN
        dbo.PriceManagementBatchDetails AS pbd ON p.ProductId = pbd.ProductId
WHERE pbd.HeaderId = '{0}'
ORDER BY p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3
";
            return String.Format(sql, _HeaderId.ToString());
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the chkUpdateDiscountInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkUpdateDiscountInfo_Click(object sender, EventArgs e)
        {
            chkFixedPriceItem.Enabled = chkUpdateDiscountInfo.Checked;

            lblDiscountForDiscountItem.Enabled = chkUpdateDiscountInfo.Checked;
            txtDiscountForDiscountItem.Enabled = chkUpdateDiscountInfo.Checked;

            lblDiscForFixedPriceItem.Enabled = chkUpdateDiscountInfo.Checked;
            txtDiscountForFixedPriceItem.Enabled = chkUpdateDiscountInfo.Checked;

            lblDiscountForNoDiscountItem.Enabled = chkUpdateDiscountInfo.Checked;
            txtDiscountForNoDiscountItem.Enabled = chkUpdateDiscountInfo.Checked;

            lblStaffDiscount.Enabled = chkUpdateDiscountInfo.Checked;
            txtStaffDiscount.Enabled = chkUpdateDiscountInfo.Checked;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnadditem":
                            this.AddItem();
                            break;
                        case "btnremoveitem":
                            this.RemoveItem();
                            break;
                        case "btnedititem":
                            this.EditItem();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        private void AddItem()
        {
            btnAddItem.Enabled = false;

            PriceMgmtWizard_AddItem wizAddItem = new PriceMgmtWizard_AddItem();
            wizAddItem.PriceDetails = this;
            wizAddItem.ListType = this.ListType;
            wizAddItem.Closed += new EventHandler(wizAddItem_Closed);
            wizAddItem.ShowDialog();
        }

        /// <summary>
        /// Handles the Closed event of the wizAddItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void wizAddItem_Closed(object sender, EventArgs e)
        {
            if (sender is PriceMgmtWizard_AddItem)
            {
                txtNumberOfLine.Text = lvItemList.Items.Count.ToString();

                btnAddItem.Enabled = true;
            }
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        private void RemoveItem()
        {
            ListViewItem lvItem = lvItemList.SelectedItem;
            lvItem.SubItems[1].Text = "D";
        }

        /// <summary>
        /// Edits the item.
        /// </summary>
        private void EditItem()
        {
            decimal avgCost = 0, oldPrice = 0, oldMu = 0, oldDiscount = 0;
            decimal newPrice = 0, newMu = 0, diff = 0, newDiscount = 0;

            if (this.ListType == PriceUtility.PriceMgmtType.Price)
            {
                decimal.TryParse(txtAverageCost.Text.Trim(), out avgCost);
                decimal.TryParse(txtOldPrice.Text.Trim(), out oldPrice);
                decimal.TryParse(txtNewPrice.Text.Trim(), out newPrice);

                if (avgCost != 0)
                {
                    oldMu = ((oldPrice / avgCost) - 1) * 100;
                    newMu = ((newPrice / avgCost) - 1) * 100;
                    diff = newMu - oldMu;
                }
            }
            else
            {
                decimal.TryParse(txtOldDiscount.Text.Trim(), out oldDiscount);
                decimal.TryParse(txtNewDiscount.Text.Trim(), out newDiscount);
            }

            ListViewItem lvItem = lvItemList.SelectedItem;
            lvItem.SubItems[1].Text = lvItem.SubItems[1].Text != "N" ? "E" : lvItem.SubItems[1].Text;

            lvItem.SubItems[8].Text = oldMu.ToString("n2"); // Old MarkUp
            lvItem.SubItems[9].Text = newPrice.ToString("n2"); // New Price
            lvItem.SubItems[10].Text = newMu.ToString("n2"); // New MarkUp
            lvItem.SubItems[11].Text = diff.ToString("n2"); // Difference
            lvItem.SubItems[13].Text = newDiscount.ToString("n2"); // new Discount

            lvItem.SubItems[21].Text = chkUpdateDiscountInfo.Checked ? "Y" : "N"; // Update VIP Discount
            lvItem.SubItems[22].Text = chkUpdateDiscountInfo.Checked ? (chkFixedPriceItem.Checked ? "Y" : "N") : lvItem.SubItems[22].Text; // Fixed price item
            lvItem.SubItems[23].Text = chkUpdateDiscountInfo.Checked ? txtDiscountForFixedPriceItem.Text : lvItem.SubItems[23].Text; // Discount For Fixed price Item
            lvItem.SubItems[24].Text = chkUpdateDiscountInfo.Checked ? txtDiscountForDiscountItem.Text : lvItem.SubItems[24].Text; // Discount for Discount Item
            lvItem.SubItems[25].Text = chkUpdateDiscountInfo.Checked ? txtDiscountForNoDiscountItem.Text : lvItem.SubItems[25].Text; // Disocunt for No Discount Item
            lvItem.SubItems[26].Text = chkUpdateDiscountInfo.Checked ? txtStaffDiscount.Text : lvItem.SubItems[26].Text; // Staff Discount
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lvItemList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem lvItem = lvItemList.SelectedItem;

            if (Common.Utility.IsGUID(lvItem.Text))
            {
                this.DetailId = new Guid(lvItem.Text);

                if (Common.Utility.IsGUID(lvItem.SubItems[27].Text))
                {
                    this.ProductId = new Guid(lvItem.SubItems[27].Text);
                }

                this.txtSTKCODE.Text = lvItem.SubItems[2].Text + " " + lvItem.SubItems[3].Text + " " + lvItem.SubItems[4].Text + " " + lvItem.SubItems[5].Text;
                this.txtDescription.Text = lvItem.SubItems[14].Text;

                if (this.ListType == PriceUtility.PriceMgmtType.Price)
                {
                    this.txtAverageCost.Text = lvItem.SubItems[6].Text;
                    this.txtOldPrice.Text = lvItem.SubItems[7].Text;
                    this.txtOldMarkUp.Text = lvItem.SubItems[8].Text;
                    this.txtNewPrice.Text = lvItem.SubItems[9].Text;
                    this.txtNewMarkUp.Text = lvItem.SubItems[10].Text;
                    this.txtDifference.Text = lvItem.SubItems[11].Text;
                }
                else
                {
                    this.txtOldDiscount.Text = lvItem.SubItems[12].Text;
                    this.txtNewDiscount.Text = lvItem.SubItems[13].Text;
                }

                this.chkUpdateDiscountInfo.Checked = (lvItem.SubItems[21].Text == "Y");
                this.chkUpdateDiscountInfo_Click(sender, e);

                this.chkFixedPriceItem.Checked = (lvItem.SubItems[22].Text == "Y");
                this.txtDiscountForFixedPriceItem.Text = lvItem.SubItems[23].Text;
                this.txtDiscountForDiscountItem.Text = lvItem.SubItems[24].Text;
                this.txtDiscountForNoDiscountItem.Text = lvItem.SubItems[25].Text;
                this.txtStaffDiscount.Text = lvItem.SubItems[26].Text;
            }
        }

        /// <summary>
        /// Handles the GotFocus event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox txtCtrl = sender as TextBox;
                if (txtCtrl != null)
                {
                    txtCtrl.SelectAll();
                }
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtNewPrice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtNewPrice_TextChanged(object sender, EventArgs e)
        {
            decimal avgCost = 0, oldPrice = 0, oldMu = 0;
            decimal newPrice = 0, newMu = 0, diff = 0;

            decimal.TryParse(txtAverageCost.Text.Trim(), out avgCost);
            decimal.TryParse(txtOldPrice.Text.Trim(), out oldPrice);
            decimal.TryParse(txtNewPrice.Text.Trim(), out newPrice);

            if (avgCost != 0)
            {
                oldMu = ((oldPrice / avgCost) - 1) * 100;
                newMu = ((newPrice / avgCost) - 1) * 100;
                diff = newMu - oldMu;
            }

            txtOldMarkUp.Text = oldMu.ToString("n2");
            txtNewMarkUp.Text = newMu.ToString("n2");
            txtDifference.Text = diff.ToString("n2");
        }
    }
}