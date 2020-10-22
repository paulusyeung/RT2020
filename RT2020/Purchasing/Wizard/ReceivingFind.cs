////RT2020.Purchasing.Wizard
namespace RT2020.Purchasing.Wizard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;

    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Common.Resources;
    using Gizmox.WebGUI.Forms;

    using RT2020.DAL;

    /// <summary>
    /// Documentation for the second part of ReceivingFind.
    /// </summary>
    public partial class ReceivingFind : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivingFind"/> class.
        /// </summary>
        public ReceivingFind()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnFind control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnFind_Click(object sender, EventArgs e)
        {
            this.BindPurchaseList();
        }

        #region Bind Purchase List
        /// <summary>
        /// Binds the purchase list.
        /// </summary>
        private void BindPurchaseList()
        {
            this.lisReceivingFindList.Items.Clear();   ////清除lisPurchaseOrderList控件中的数据

            int iCount = 1;
            string objPOnumber = (this.txtPONumber.Text.Trim() == "*") ? string.Empty : PurchasingUtils.GenSafeChars(this.txtPONumber.Text.Trim());
            string objType = (this.txtType.Text.Trim() == "*") ? string.Empty : PurchasingUtils.GenSafeChars(this.txtType.Text.Trim());

            string sql = "Status = 1 AND PostedBy <> '" + System.Guid.Empty + "' AND OrderNumber LIKE '%" + objPOnumber + "%' AND OrderType LIKE '%" + objType + "%'";
            string[] objOrderBy = { "OrderNumber" };
            PurchaseOrderHeaderCollection objHeaders = PurchaseOrderHeader.LoadCollection(sql, objOrderBy, true);
            foreach (PurchaseOrderHeader objHeader in objHeaders)
            {
                string orderType = string.Empty;
                switch (objHeader.OrderType)
                {
                    case 0:
                        orderType = Common.Enums.POType.FPO.ToString();
                        break;
                    case 1:
                        orderType = Common.Enums.POType.LPO.ToString();
                        break;
                    case 2:
                        orderType = Common.Enums.POType.OPO.ToString();
                        break;
                }

                ListViewItem objItem = this.lisReceivingFindList.Items.Add(objHeader.OrderHeaderId.ToString()); //// OrderHeaderId
                objItem.SubItems.Add(iCount.ToString());    //// Line Number
                objItem.SubItems.Add(objHeader.OrderNumber);
                objItem.SubItems.Add(orderType);

                iCount++;
            }
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the BtnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this.lisReceivingFindList.Items.Count > 0)
            {
                this.Close();
                Receiving objReceiving = new Receiving();
                objReceiving.OrderHeaderId = PurchasingUtils.Convert.ToGuid(this.lisReceivingFindList.SelectedItem.Text);
                objReceiving.ShowDialog();
                PurchaseOrderHeader objHeader = PurchaseOrderHeader.Load(objReceiving.OrderHeaderId);
                objReceiving.BindPOHeaderInfo(objHeader);
            }
            else
            {
                MessageBox.Show("Please select at least one record!", "Error");
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}