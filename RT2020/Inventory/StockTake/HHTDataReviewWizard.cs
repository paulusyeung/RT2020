#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.StockTake
{
    public partial class HHTDataReviewWizard : Form
    {
        public Guid HHTHeaderId { get; set; }

        public HHTDataReviewWizard()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetAttributes();
            LoadHeaderInfo();
        }

        private void SetAttributes()
        {
            txtTxNumber.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtWorkplace.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtHHTId.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtUploadedOn.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtTotalLine_HHTData.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtTotalLine_StockTake.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtTotalLine_MissingBarcode.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtTotalQty_HHTData.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtTotalQty_StockTake.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtTotalQty_MissingBarcode.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            txtCreatedOn.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtCreatedBy.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            colSTKCODE.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE");
            colAPPENDIX1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            colAPPENDIX2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2");
            colAPPENDIX3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3");
        }

        private void LoadHeaderInfo()
        {
            if (this.HHTHeaderId != null)
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    var hhtHeader = ctx.StocktakeHeader_HHT.Where(x => x.HeaderId == this.HHTHeaderId).AsNoTracking().FirstOrDefault();
                    if (hhtHeader != null)
                    {
                        txtTxNumber.Text = hhtHeader.TxNumber;
                        txtWorkplace.Text = WorkplaceEx.GetWorkplaceCodeById(hhtHeader.WorkplaceId.Value);
                        txtHHTId.Text = hhtHeader.HHTId;
                        txtUploadedOn.Text = hhtHeader.UploadedOn.Value.ToString("dd MMM yyyy HH:mm:ss");
                        txtCreatedOn.Text = hhtHeader.CreatedOn.ToString("dd MMM yyyy HH:mm:ss");
                        txtCreatedBy.Text = StaffEx.GetStaffNumberById(hhtHeader.CreatedBy);

                        txtTotalLine_HHTData.Text = hhtHeader.TotalRows.Value.ToString("n0");
                        txtTotalLine_StockTake.Text = hhtHeader.TotalRows.Value.ToString("n0");
                        txtTotalLine_MissingBarcode.Text = hhtHeader.MissingRows.Value.ToString("n0");

                        txtTotalQty_HHTData.Text = hhtHeader.TOTALQTY.Value.ToString("n0");
                        txtTotalQty_StockTake.Text = hhtHeader.TOTALQTY.Value.ToString("n0");
                        txtTotalQty_MissingBarcode.Text = hhtHeader.MissingQty.Value.ToString("n0");

                        LoadDetailsInfo(hhtHeader.HeaderId);
                    }
                }
            }
        }

        private void LoadDetailsInfo(Guid headerId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hhtDetailList = ctx.StockTakeDetails_HHT
                    .Where(x => x.HeaderId == headerId).OrderBy(x => x.LineNumber)
                    .AsNoTracking()
                    .ToList();
                foreach (var hhtDetail in hhtDetailList)
                {
                    ListViewItem lvItem = lvDetailsList.Items.Add(hhtDetail.DetailsId.ToString());
                    lvItem.SubItems.Add(hhtDetail.Barcode);
                    lvItem.SubItems.Add(hhtDetail.Qty.Value.ToString("n0"));

                    string[] productCode = GetProductCode(hhtDetail.ProductId.Value);
                    lvItem.SubItems.Add(productCode[0]);
                    lvItem.SubItems.Add(productCode[1]);
                    lvItem.SubItems.Add(productCode[2]);
                    lvItem.SubItems.Add(productCode[3]);

                    lvItem.UseItemStyleForSubItems = false;
                    lvItem.SubItems[1].BackColor = Color.WhiteSmoke;
                    lvItem.SubItems[2].BackColor = Color.WhiteSmoke;

                }
            }
        }

        private string[] GetProductCode(Guid productId)
        {
            List<string> productCode = new List<string>();

            var product = ProductEx.Get(productId);
            if (product != null)
            {
                productCode.Add(product.STKCODE);
                productCode.Add(product.APPENDIX1);
                productCode.Add(product.APPENDIX2);
                productCode.Add(product.APPENDIX3);
            }
            else
            {
                productCode.Add(string.Empty);
                productCode.Add(string.Empty);
                productCode.Add(string.Empty);
                productCode.Add(string.Empty);
            }

            return productCode.ToArray();
        }
    }
}