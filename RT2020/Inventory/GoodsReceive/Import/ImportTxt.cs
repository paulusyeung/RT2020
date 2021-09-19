#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using FileHelpers;
using System.IO;
using RT2020.Controls;
using FileHelpers.MasterDetail;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.GoodsReceive.Import
{
    public partial class ImportTxt : Form
    {
        string mstrDirectory = string.Empty;
        MasterDetails[] md = null;
        List<string> skippedList = new List<string>();

        public ImportTxt()
        {
            InitializeComponent();
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "Invt_CAP");
        }

        #region Events
        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.Title = "Choose the file ready for import";
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtFileName.Text = Utility.UploadFile(openFileDialog, mstrDirectory);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (this.lvImportedList.Items.Count > 0)
            {
                MessageBox.Show("Import Record(s)?", "Import Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(ImportMessageHandler));
            }
            else
            {
                MessageBox.Show("There's no record to import!", "Import Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ImportMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                int result = Import();
                if (result > 0)
                {
                    MessageBox.Show("Import " + result.ToString() + " Record(s) successfully", "Import Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Import " + result.ToString() + " Record(s) successfully", "Import Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            StringBuilder info = new StringBuilder();
            info.Append("File Structure").Append(" - CAP").Append("\n\r").Append("\n\r");
            info.Append("The record content is listed as follows : ").Append("\n\r");
            info.Append("** Each field in a line is separated by a <TAB>. **").Append("\n\r").Append("\n\r");
            info.Append("Start (Row)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Transaction Type        - (CAP) ").Append("\n\r").Append("\n\r");
            info.Append("Header (Column)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Record Type        - (HH)").Append("\n\r");
            info.Append("2 -     Location Code").Append("\n\r");
            info.Append("3 -     Operator Code").Append("\n\r");
            info.Append("4 -     Received Date        - (DDMMYYYY)").Append("\n\r");
            info.Append("5 -     Supplier Code").Append("\n\r");
            info.Append("6 -     Reference").Append("\n\r");
            info.Append("7 -     Remark(s)").Append("\n\r").Append("\n\r");
            info.Append("Detail (Column)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Record Type    - (DD)").Append("\n\r");
            info.Append("2 -     Stock Code").Append("\n\r");
            info.Append("3 -     Appendix1").Append("\n\r");
            info.Append("4 -     Appendix2").Append("\n\r");
            info.Append("5 -     Appendix3").Append("\n\r");
            info.Append("6 -     Received Qty").Append("\n\r");
            info.Append("7 -     Received unit Amount").Append("\n\r").Append("\n\r");
            info.Append("Footer (Row)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Total Header     - (TH + <TAB> + Number of Header)").Append("\n\r");
            info.Append("2 -     Total Detail     - (TD + <TAB> + Number of Detail)").Append("\n\r");
            info.Append("3 -     Record End     - (EE)").Append("\n\r");

            MessageBox.Show(info.ToString(), "Information for Transfer Import Txt file Structure");
        }

        private RecordAction RecSelector(string record)
        {
            string rec = record[0].ToString() + record[1].ToString();
            if (rec == "HH")
            {
                return RecordAction.Master;
            }
            else if (rec == "DD")
            {
                return RecordAction.Detail;
            }
            else
            {
                return RecordAction.Skip;
            }
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            MasterDetailEngine engine = new MasterDetailEngine(typeof(CAPTxtIEMaster), typeof(CAPTxtIEDetails), new MasterDetailSelector(RecSelector));

            md = engine.ReadFile(Path.Combine(mstrDirectory, txtFileName.Text));

            for (int i = 0; i < md.Length; i++)
            {
                CAPTxtIEMaster CAPItem = md[i].Master as CAPTxtIEMaster;

                ListViewItem oItem = lvImportedList.Items.Add(CAPItem.RecType);
                oItem.SubItems.Add(CAPItem.Location);
                oItem.SubItems.Add(CAPItem.Operator);
                oItem.SubItems.Add(DateTimeHelper.DateTimeToString(CAPItem.RecvDate, false));
                oItem.SubItems.Add(CAPItem.Supplier);
                oItem.SubItems.Add(CAPItem.RefNumber);
                oItem.SubItems.Add(CAPItem.Remarks);
                oItem.SubItems.Add(String.Empty);       // 2012.09.14 paulus: 加咗，咁個 colMessage 才有效
            }

            lblTxCount.Text = md.Length.ToString();
        }
        #endregion

        #region Import

        #region IDs

        private Guid GetProductId(CAPTxtIEDetails detail)
        {
            string sql = "STKCODE = '" + detail.StockCode + "' AND APPENDIX1 = '" + detail.Appendix1 + "' AND APPENDIX2 = '" + detail.Appendix2 + "' AND APPENDIX3 = '" + detail.Appendix3 + "'";
            var oItem = ProductEx.Get(sql);
            if (oItem != null)
            {
                return oItem.ProductId;
            }
            else
            {
                return System.Guid.Empty;
            }
        }

        #endregion

        private void UpdateListView(int i, string txNumber)
        {
            ListViewItem item = lvImportedList.Items[i];
            if (lvImportedList.Items[i].Text == "HH")
            {
                string skipped = string.Empty;

                lvImportedList.Items[i].Text = txNumber;

                if (skippedList.Count > 0)
                {
                    skipped = skippedList.Count.ToString()+" skipped: ";

                    for (int iCount = 0; iCount < skippedList.Count; iCount++)
                    {
                        if (iCount > 0)
                        {
                            skipped = ";";
                        }

                        skipped = skippedList[iCount];
                    }
                }

                // 2013.09.14 paulus: 應該係將啲 import 唔倒嘅 items 寫喺 colMessage
                //lvImportedList.Items[6].Text = skipped;
                lvImportedList.Items[i].SubItems[7].Text = skipped;

                lvImportedList.Update();
            }
        }

        private int Import()
        {
            int result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < md.Length; i++)
                        {
                            string txNumber = SystemInfoHelper.Settings.QueuingTxNumber(EnumHelper.TxType.CAP);

                            #region Guid headerId = ImportCAPHeader(md[i].Master as CAPTxtIEMaster, txNumber);
                            CAPTxtIEMaster master = md[i].Master as CAPTxtIEMaster;

                            var oHeader = new EF6.InvtBatchCAP_Header();
                            oHeader.HeaderId = Guid.NewGuid();
                            oHeader.TxType = EnumHelper.TxType.CAP.ToString();
                            oHeader.TxNumber = txNumber;
                            oHeader.TxDate = master.RecvDate;
                            oHeader.WorkplaceId = WorkplaceEx.GetWorkplaceIdByCode(master.Location);
                            oHeader.StaffId = StaffEx.GetStaffIdByStaffNumber(master.Operator);
                            oHeader.SupplierId = SupplierEx.GetSupplierIdBySupplierCode(master.Supplier);
                            oHeader.Status = Convert.ToInt32(EnumHelper.Status.Draft.ToString("d"));
                            oHeader.Reference = master.RefNumber;
                            oHeader.Remarks = master.Remarks;
                            oHeader.CurrencyCode = "HKD";
                            oHeader.ExchangeRate = (decimal)1;

                            oHeader.CreatedBy = ConfigHelper.CurrentUserId;
                            oHeader.CreatedOn = DateTime.Now;
                            oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                            oHeader.ModifiedOn = DateTime.Now;

                            ctx.InvtBatchCAP_Header.Add(oHeader);
                            ctx.SaveChanges();

                            Guid headerId = oHeader.HeaderId;
                            #endregion

                            decimal ttlAmt = 0;
                            #region decimal ttlAmt = ImportCAPDetails(md[i].Details, headerId, txNumber);
                            object[] details = md[i].Details;
                            if (details != null)
                            {
                                for (int j = 0; j < details.Length; j++)
                                {
                                    CAPTxtIEDetails detail = details[j] as CAPTxtIEDetails;
                                    Guid prodId = GetProductId(detail);

                                    if (prodId != Guid.Empty)
                                    {
                                        var oDetail = new EF6.InvtBatchCAP_Details();
                                        oDetail.DetailsId = Guid.NewGuid();
                                        oDetail.ProductId = prodId;
                                        oDetail.HeaderId = headerId;
                                        oDetail.LineNumber = j + 1;
                                        oDetail.TxNumber = txNumber;
                                        oDetail.TxType = EnumHelper.TxType.CAP.ToString();
                                        oDetail.Qty = detail.ReceivedQty;
                                        oDetail.UnitAmount = detail.ReceivedUnitAmount;
                                        oDetail.UnitAmountInForeignCurrency = detail.ReceivedUnitAmount;

                                        ctx.InvtBatchCAP_Details.Add(oDetail);
                                        ctx.SaveChanges();

                                        ttlAmt += oDetail.Qty.Value * oDetail.UnitAmount.Value;
                                    }
                                    else
                                    {
                                        string skippedProduct = String.Format("?{0} {1} {2} {3}",
                                            detail.StockCode, detail.Appendix1, detail.Appendix2, detail.Appendix3);
                                        skippedList.Add(skippedProduct);
                                    }
                                }
                            }
                            #endregion

                            oHeader = ctx.InvtBatchCAP_Header.Find(headerId);
                            if (oHeader != null)
                            {
                                oHeader.TotalAmount = ttlAmt;
                                ctx.SaveChanges();

                                UpdateListView(i, txNumber);

                                skippedList.Clear();
                            }

                            result++;
                        }
                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }

            return result;
        }
        /**
        private Guid ImportCAPHeader(CAPTxtIEMaster master, string txNumber)
        {
            System.Guid headerId = System.Guid.Empty;

            InvtBatchCAP_Header oHeader = new InvtBatchCAP_Header();

            oHeader.TxType = EnumHelper.TxType.CAP.ToString();
            oHeader.TxNumber = txNumber;
            oHeader.TxDate = master.RecvDate;
            oHeader.WorkplaceId = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(master.Location);
            oHeader.StaffId = ModelEx.StaffEx.GetStaffIdByStaffNumber(master.Operator);
            oHeader.SupplierId = ModelEx.SupplierEx.GetSupplierIdBySupplierCode(master.Supplier);
            oHeader.Status = Convert.ToInt32(EnumHelper.Status.Draft.ToString("d"));
            oHeader.Reference = master.RefNumber;
            oHeader.Remarks = master.Remarks;
            oHeader.CurrencyCode = "HKD";
            oHeader.ExchangeRate = (decimal)1;

            oHeader.CreatedBy = ConfigHelper.CurrentUserId;
            oHeader.CreatedOn = DateTime.Now;
            oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
            oHeader.ModifiedOn = DateTime.Now;

            oHeader.Save();

            headerId = oHeader.HeaderId;

            return headerId;
        }

        private decimal ImportCAPDetails(object[] details, Guid headerId, string txNumber)
        {
            decimal result = 0;
            if (details != null)
            {
                for (int i = 0; i < details.Length; i++)
                {
                    CAPTxtIEDetails detail = details[i] as CAPTxtIEDetails;
                    System.Guid prodId = GetProductId(detail);

                    InvtBatchCAP_Details oDetail = new InvtBatchCAP_Details();

                    oDetail.ProductId = prodId;
                    oDetail.HeaderId = headerId;
                    oDetail.LineNumber = i + 1;
                    oDetail.TxNumber = txNumber;
                    oDetail.TxType = EnumHelper.TxType.CAP.ToString();
                    oDetail.Qty = detail.ReceivedQty;
                    oDetail.UnitAmount = detail.ReceivedUnitAmount;
                    oDetail.UnitAmountInForeignCurrency = detail.ReceivedUnitAmount;

                    if (prodId != System.Guid.Empty)
                    {
                        oDetail.Save();
                        result += oDetail.Qty * oDetail.UnitAmount;
                    }
                    else
                    {
                        string skippedProduct = String.Format("?{0} {1} {2} {3}",
                            detail.StockCode, detail.Appendix1, detail.Appendix2, detail.Appendix3);
                        skippedList.Add(skippedProduct);
                    }
                }
            }
            return result;
        }
        */
        #endregion
    }
}