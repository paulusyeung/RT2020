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
using RT2020.DAL;
using System.Data.Entity;

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
            txtTxNumber.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtWorkplace.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtHHTId.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtUploadedOn.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtTotalLine_HHTData.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtTotalLine_StockTake.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtTotalLine_MissingBarcode.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtTotalQty_HHTData.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtTotalQty_StockTake.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtTotalQty_MissingBarcode.BackColor = SystemInfo.ControlBackColor.DisabledBox;

            txtCreatedOn.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtCreatedBy.BackColor = SystemInfo.ControlBackColor.DisabledBox;

            colSTKCODE.Text = SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            colAPPENDIX1.Text = SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            colAPPENDIX2.Text = SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            colAPPENDIX3.Text = SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
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
                        txtWorkplace.Text = ModelEx.WorkplaceEx.GetWorkplaceCodeById(hhtHeader.WorkplaceId.Value);
                        txtHHTId.Text = hhtHeader.HHTId;
                        txtUploadedOn.Text = hhtHeader.UploadedOn.Value.ToString("dd MMM yyyy HH:mm:ss");
                        txtCreatedOn.Text = hhtHeader.CreatedOn.ToString("dd MMM yyyy HH:mm:ss");
                        txtCreatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(hhtHeader.CreatedBy);

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
            StockTakeDetails_HHTCollection hhtDetailList = StockTakeDetails_HHT.LoadCollection("HeaderId = '" + headerId.ToString() + "'", new string[] { "LineNumber" }, true);
            foreach (StockTakeDetails_HHT hhtDetail in hhtDetailList)
            {
                ListViewItem lvItem = lvDetailsList.Items.Add(hhtDetail.DetailsId.ToString());
                lvItem.SubItems.Add(hhtDetail.Barcode);
                lvItem.SubItems.Add(hhtDetail.Qty.ToString("n0"));

                string[] productCode = GetProductCode(hhtDetail.ProductId);
                lvItem.SubItems.Add(productCode[0]);
                lvItem.SubItems.Add(productCode[1]);
                lvItem.SubItems.Add(productCode[2]);
                lvItem.SubItems.Add(productCode[3]);

                lvItem.UseItemStyleForSubItems = false;
                lvItem.SubItems[1].BackColor = Color.WhiteSmoke;
                lvItem.SubItems[2].BackColor = Color.WhiteSmoke;

            }
        }

        private string[] GetProductCode(Guid productId)
        {
            List<string> productCode = new List<string>();

            RT2020.DAL.Product product = RT2020.DAL.Product.Load(productId);
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