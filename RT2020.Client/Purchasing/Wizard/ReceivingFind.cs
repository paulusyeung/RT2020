using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RT2020.DAL;

namespace RT2020.Client.Purchasing.Wizard
{
    public partial class ReceivingFind : Form
    {
        public ReceivingFind()
        {
            InitializeComponent();
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
            DataTable dt = new DataTable();
            dt.Columns.Add("OrderHeaderId");
            dt.Columns.Add("Records");
            dt.Columns.Add("PONumber");
            dt.Columns.Add("Type");

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
                        orderType = DAL.Common.Enums.POType.FPO.ToString();
                        break;
                    case 1:
                        orderType = DAL.Common.Enums.POType.LPO.ToString();
                        break;
                    case 2:
                        orderType = DAL.Common.Enums.POType.OPO.ToString();
                        break;
                }

                DataRow row = dt.NewRow();
                row["OrderHeaderId"] = objHeader.OrderHeaderId.ToString(); //// OrderHeaderId
                row["Records"] = iCount.ToString();    //// Line Number
                row["PONumber"] = objHeader.OrderNumber;
                row["Type"] = orderType;

                dt.Rows.Add(row);

                iCount++;
            }

            dgvReceivingFindList.DataSource = dt;
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the BtnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this.dgvReceivingFindList.Rows.Count > 0)
            {
                this.Close();
                Receiving objReceiving = new Receiving();
                objReceiving.OrderHeaderId = PurchasingUtils.Convert.ToGuid(this.dgvReceivingFindList.Rows[dgvReceivingFindList.CurrentCell.RowIndex].Cells[0].Value);
                PurchaseOrderHeader objHeader = PurchaseOrderHeader.Load(objReceiving.OrderHeaderId);
                objReceiving.BindPOHeaderInfo(objHeader);
                objReceiving.ShowDialog();
                
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
