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
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Inventory.StockTake
{
    public partial class AllItems : Form
    {
        public AllItems()
        {
            InitializeComponent();
            FillListView();
        }

        #region Fill ListView
        private void FillListView()
        {
            lvLocationList.Items.Clear();

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Workplace.OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                foreach (var wp in list)
                {
                    string locInfo = wp.WorkplaceCode + " - " + wp.WorkplaceInitial;
                    ListViewItem lvItem = lvLocationList.Items.Add(wp.WorkplaceId.ToString());
                    lvItem.SubItems.Add(locInfo);
                    lvItem.SubItems.Add(":");
                    lvItem.SubItems.Add(GetTxInfo(wp.WorkplaceId));
                }
            }
        }

        private string GetTxInfo(Guid workplaceId)
        {
            string result = string.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "WorkplaceId = '" + workplaceId.ToString() + "' AND YEAR(PostedOn) = 1900 AND LEN(ADJNUM) = 0";
                var oHeader = ctx.StockTakeHeader
                    .Where(x => x.WorkplaceId == workplaceId && x.PostedOn.Value.Year == 1900 && x.ADJNUM.Length == 0)
                    .AsNoTracking()
                    .FirstOrDefault();
                if (oHeader != null)
                {
                    result = oHeader.TxNumber + "  " + RT2020.SystemInfo.Settings.DateTimeToString(oHeader.TxDate.Value, false);
                }
            }
            return result;
        }
        #endregion

        #region Stock Take Creation
        private int CreateSTK()
        {
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = lvLocationList.CheckedItems.Count - 1;

            int iCount = 0;

            foreach (ListViewItem lvItem in lvLocationList.Items)
            {
                if (lvItem.Checked && Common.Utility.IsGUID(lvItem.Text))
                {
                    System.Guid wpId = new Guid(lvItem.Text);

                    string stkNum = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.TxType.STK);

                    SetProgress(iCount, "Creating Transaction# " + stkNum);

                    System.Guid headerId = CreateSTK(stkNum, wpId);

                    if (headerId != System.Guid.Empty)
                    {
                        CreateSTKDetails(headerId, stkNum, wpId);
                        iCount++;
                    }
                }
            }

            if (iCount == 0)
            {
                MessageBox.Show("Please select one location at least!", "Error");
            }

            return iCount;
        }

        private Guid CreateSTK(string txNumber, Guid workplaceId)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "WorkplaceId = '" + workplaceId.ToString() + "' ";
                var stkHeader = ctx.StockTakeHeader.Where(x => x.WorkplaceId == workplaceId).AsNoTracking().FirstOrDefault();
                if (stkHeader == null)
                {
                    stkHeader = new EF6.StockTakeHeader();
                    stkHeader.HeaderId = Guid.NewGuid();
                    stkHeader.TxNumber = txNumber;
                    stkHeader.TxDate = DateTime.Now;

                    stkHeader.CreatedBy = Common.Config.CurrentUserId;
                    stkHeader.CreatedOn = DateTime.Now;

                    ctx.StockTakeHeader.Add(stkHeader);
                }
                stkHeader.WorkplaceId = workplaceId;
                stkHeader.Status = (int)Common.Enums.Status.Draft;
                stkHeader.CapturedOn = DateTime.Now;
                stkHeader.CapturedQty = 0;
                stkHeader.CapturedAmount = 0;

                stkHeader.ModifiedBy = Common.Config.CurrentUserId;
                stkHeader.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = stkHeader.HeaderId;
            }

            return result;
        }

        private void CreateSTKDetails(System.Guid headerId, string txNumber, Guid workplaceId)
        {
            decimal amount = 0, qty = 0;

            string sql = "WorkplaceId = '" + workplaceId.ToString() + "' ";
            if (rbtnNonZeroQtyItems.Checked)
            {
                sql += " AND CDQTY > 0";
            }

            ProductWorkplaceCollection wpItemList = ProductWorkplace.LoadCollection(sql);
            foreach (ProductWorkplace wpItem in wpItemList)
            {
                decimal avgCost = GetAverageCost(wpItem.ProductId);
                StockTakeDetails stkDetail = new StockTakeDetails();
                stkDetail.TxNumber = txNumber;
                stkDetail.HeaderId = headerId;
                stkDetail.WorkplaceId = workplaceId;
                stkDetail.ProductId = wpItem.ProductId;
                stkDetail.CapturedQty = wpItem.CDQTY;
                stkDetail.AverageCost = avgCost;

                stkDetail.ModifiedBy = Common.Config.CurrentUserId;
                stkDetail.ModifiedOn = DateTime.Now;
                stkDetail.Save();

                qty += wpItem.CDQTY;
                amount += wpItem.CDQTY * avgCost;
            }

            using (var ctx = new EF6.RT2020Entities())
            {
                var oHeader = ctx.StockTakeHeader.Find(headerId);
                if (oHeader != null)
                {
                    oHeader.CapturedQty = qty;
                    oHeader.CapturedAmount = amount;
                    ctx.SaveChanges();
                }
            }
        }

        private void SetProgress(int value, string message)
        {
            progressBar1.Visible = true;
            progressBar1.Value = value;
            progressBar1.Text = message;

            progressBar1.Show();
        }

        private decimal GetAverageCost(Guid productId)
        {
            ProductCurrentSummary currSum = ProductCurrentSummary.LoadWhere("ProductId = '" + productId.ToString() + "'");
            if (currSum != null)
            {
                return currSum.AverageCost;
            }

            return 0;
        }

        #endregion

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int result = CreateSTK();
            if (result > 0)
            {
                RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                MessageBox.Show(result.ToString() + " Transaction(s) Creation Complete !", "Creation Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information, new EventHandler(CreationMessageHandler));
            }
            else
            {
                MessageBox.Show("Error Occurred, Creation Aborted!", "Creation Failed");
            }
        }

        private void CreationMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                FillListView();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvLocationList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string lvItem = lvLocationList.Items[e.Index].SubItems[3].Text;
            if (lvItem.Trim().Length > 0 && e.NewValue == CheckState.Checked)
            {
                MessageBox.Show("The location has its own stock take worksheet", "Message");
                lvLocationList.Items[e.Index].Checked = false;
            }
        }
    }
}