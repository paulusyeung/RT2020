////RT2020.Purchasing.Wizard
namespace RT2020.Purchasing.Wizard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Common.Resources;
    using Gizmox.WebGUI.Forms;


    using RT2020.Common.Helper;

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

        private void ReceivingFind_Load(object sender, EventArgs e)
        {
            
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

            string sql = "Status = 1 AND PostedBy <> '" + Guid.Empty + "' AND OrderNumber LIKE '%" + objPOnumber + "%' AND OrderType LIKE '%" + objType + "%'";
            string orderBy = "OrderNumber";

            using (var ctx = new EF6.RT2020Entities())
            {
                var objHeaders = ctx.PurchaseOrderHeader.SqlQuery(
                    string.Format("Select * from PurchaseOrderHeader Where {0} Order By {1}", sql, orderBy))
                    .AsNoTracking()
                    .ToList();

                foreach (var objHeader in objHeaders)
                {
                    string orderType = string.Empty;
                    switch (objHeader.OrderType)
                    {
                        case 0:
                            orderType = EnumHelper.POType.FPO.ToString();
                            break;
                        case 1:
                            orderType = EnumHelper.POType.LPO.ToString();
                            break;
                        case 2:
                            orderType = EnumHelper.POType.OPO.ToString();
                            break;
                    }

                    ListViewItem objItem = this.lisReceivingFindList.Items.Add(objHeader.OrderHeaderId.ToString()); //// OrderHeaderId
                    objItem.SubItems.Add(iCount.ToString());    //// Line Number
                    objItem.SubItems.Add(objHeader.OrderNumber);
                    objItem.SubItems.Add(orderType);

                    iCount++;
                }
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
                objReceiving.BindPOHeaderInfo(objReceiving.OrderHeaderId);
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