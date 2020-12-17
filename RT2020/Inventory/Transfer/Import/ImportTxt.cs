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
using RT2020.DAL;

#endregion

namespace RT2020.Inventory.Transfer.Import
{
    public partial class ImportTxt : Form
    {
        string mstrDirectory = string.Empty;
        MasterDetails[] md = null;

        public ImportTxt()
        {
            InitializeComponent();
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "Invt_Txfer");
        }

        #region Events
        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtFileName.Text = Utility.UploadFile(openFileDialog, mstrDirectory);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Import Record(s)?", "Import Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(ImportMessageHandler));
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
            info.Append("File Structure").Append(" - Transfer").Append("\n\r").Append("\n\r");
            info.Append("The record content is listed as follows : ").Append("\n\r");
            info.Append("** Each field in a line is separated by a <TAB>. **").Append("\n\r").Append("\n\r");
            info.Append("Start (Row)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Transaction Type        - (TRF) ").Append("\n\r").Append("\n\r");
            info.Append("Header (Column)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Record Type        - (HH)").Append("\n\r");
            info.Append("2 -     From Location Code").Append("\n\r");
            info.Append("3 -     To Location Code").Append("\n\r");
            info.Append("4 -     Operator Code").Append("\n\r");
            info.Append("5 -     Transaction Date        - (DDMMYYYY)").Append("\n\r");
            info.Append("6 -     Transfer Date        - (DDMMYYYY)").Append("\n\r");
            info.Append("7 -     Completion Date        - (DDMMYYYY)").Append("\n\r");
            info.Append("8 -     Reference").Append("\n\r");
            info.Append("9 -     Remark(s)").Append("\n\r").Append("\n\r");
            info.Append("Detail (Column)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Record Type    - (DD)").Append("\n\r");
            info.Append("2 -     Stock Code").Append("\n\r");
            info.Append("3 -     Appendix1").Append("\n\r");
            info.Append("4 -     Appendix2").Append("\n\r");
            info.Append("5 -     Appendix3").Append("\n\r");
            info.Append("6 -     Required Qty").Append("\n\r");
            info.Append("7 -     Transfer Qty").Append("\n\r");
            info.Append("8 -     Remark(s)").Append("\n\r").Append("\n\r");
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
            MasterDetailEngine engine = new MasterDetailEngine(typeof(TxferTxtIEMaster), typeof(TxferTxtIEDetails),new MasterDetailSelector(RecSelector));

            md = engine.ReadFile(Path.Combine(mstrDirectory, txtFileName.Text));

            for (int i = 0; i <md.Length; i++)
            {
                TxferTxtIEMaster txferItem = md[0].Master as TxferTxtIEMaster;

                ListViewItem oItem = lvImportedList.Items.Add(txferItem.RecType);
                oItem.SubItems.Add(txferItem.FromLocation);
                oItem.SubItems.Add(txferItem.ToLocation);
                oItem.SubItems.Add(txferItem.Operator);
                oItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(txferItem.TxDate, false));
                oItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(txferItem.TxferDate, false));
                oItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(txferItem.CompletionDate, false));
                oItem.SubItems.Add(txferItem.RefNumber);
                oItem.SubItems.Add(txferItem.Remarks);
            }

            lblTxCount.Text = md.Length.ToString();
        }
        #endregion

        #region Import

        #region IDs

        private Guid GetProductId(TxferTxtIEDetails detail)
        {
            string sql = "STKCODE = '" + detail.StockCode +"' AND APPENDIX1 = '" + detail.Appendix1 + "' AND APPENDIX2 = '" + detail.Appendix2 + "' AND APPENDIX3 = '" + detail.Appendix3 + "'";
            var oItem = ModelEx.ProductEx.Get(sql);
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
                            string txNumber = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.TxType.TXF);

                            #region Guid headerId = ImportTxferHeader(md[i].Master as TxferTxtIEMaster, txNumber);
                            var master = md[i].Master as TxferTxtIEMaster;

                            var oHeader = new EF6.InvtBatchTXF_Header();
                            oHeader.HeaderId = Guid.NewGuid();
                            oHeader.TxType = Common.Enums.TxType.TXF.ToString();
                            oHeader.TxNumber = txNumber;
                            oHeader.TxDate = master.TxDate;
                            oHeader.TransferredOn = master.TxferDate;
                            oHeader.CompletedOn = master.CompletionDate;
                            oHeader.FromLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(master.FromLocation);
                            oHeader.ToLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(master.ToLocation);
                            oHeader.StaffId = ModelEx.StaffEx.GetStaffIdByStaffNumber(master.Operator);
                            oHeader.Status = Convert.ToInt32(Common.Enums.Status.Draft.ToString("d"));
                            oHeader.Reference = master.RefNumber;
                            oHeader.Remarks = master.Remarks;

                            oHeader.CreatedBy = Common.Config.CurrentUserId;
                            oHeader.CreatedOn = DateTime.Now;
                            oHeader.ModifiedBy = Common.Config.CurrentUserId;
                            oHeader.ModifiedOn = DateTime.Now;

                            ctx.InvtBatchTXF_Header.Add(oHeader);
                            ctx.SaveChanges();

                            Guid headerId = oHeader.HeaderId;
                            #endregion

                            if (headerId != Guid.Empty)
                            {
                                lvImportedList.Items[i].Text = txNumber;

                                #region ImportTxferDetails(md[i].Details, headerId, txNumber);
                                object[] details = md[i].Details;

                                if (details != null)
                                {
                                    for (int j = 0; j < details.Length; j++)
                                    {
                                        TxferTxtIEDetails detail = details[j] as TxferTxtIEDetails;
                                        Guid prodId = GetProductId(detail);
                                        if (prodId != Guid.Empty)
                                        {

                                            var oDetail = new EF6.InvtBatchTXF_Details();
                                            oDetail.DetailsId = Guid.NewGuid();
                                            oDetail.ProductId = prodId;
                                            oDetail.HeaderId = headerId;
                                            oDetail.LineNumber = j + 1;
                                            oDetail.TxNumber = txNumber;
                                            oDetail.TxType = Common.Enums.TxType.TXF.ToString();
                                            oDetail.QtyConfirmed = 0;
                                            oDetail.QtyHHT = 0;
                                            oDetail.QtyManualInput = 0;
                                            oDetail.QtyReceived = detail.TxferQty;
                                            oDetail.QtyRequested = detail.RequiredQty;
                                            oDetail.Remarks = detail.Remarks;

                                            ctx.InvtBatchTXF_Details.Add(oDetail);
                                            ctx.SaveChanges();
                                            result++;
                                        }
                                    }
                                }
                                #endregion

                                result++;
                            }
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
        private Guid ImportTxferHeader(TxferTxtIEMaster master, string txNumber)
        {
            Guid headerId = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oHeader = new EF6.InvtBatchTXF_Header();
                oHeader.HeaderId = Guid.NewGuid();
                oHeader.TxType = Common.Enums.TxType.TXF.ToString();
                oHeader.TxNumber = txNumber;
                oHeader.TxDate = master.TxDate;
                oHeader.TransferredOn = master.TxferDate;
                oHeader.CompletedOn = master.CompletionDate;
                oHeader.FromLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(master.FromLocation);
                oHeader.ToLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(master.ToLocation);
                oHeader.StaffId = ModelEx.StaffEx.GetStaffIdByStaffNumber(master.Operator);
                oHeader.Status = Convert.ToInt32(Common.Enums.Status.Draft.ToString("d"));
                oHeader.Reference = master.RefNumber;
                oHeader.Remarks = master.Remarks;

                oHeader.CreatedBy = Common.Config.CurrentUserId;
                oHeader.CreatedOn = DateTime.Now;
                oHeader.ModifiedBy = Common.Config.CurrentUserId;
                oHeader.ModifiedOn = DateTime.Now;

                ctx.InvtBatchTXF_Header.Add(oHeader);
                ctx.SaveChanges();

                headerId = oHeader.HeaderId;
            }

            return headerId;
        }

        private int ImportTxferDetails(object[] details, Guid headerId, string txNumber)
        {
            int result = 0;
            if (details != null)
            {
                for (int i = 0; i < details.Length; i++)
                {
                    TxferTxtIEDetails detail = details[i] as TxferTxtIEDetails;
                    System.Guid prodId = GetProductId(detail);

                    InvtBatchTXF_Details oDetail = new InvtBatchTXF_Details();

                    oDetail.ProductId = prodId;
                    oDetail.HeaderId = headerId;
                    oDetail.LineNumber = i + 1;
                    oDetail.TxNumber = txNumber;
                    oDetail.TxType = Common.Enums.TxType.TXF.ToString();
                    oDetail.QtyConfirmed = 0;
                    oDetail.QtyHHT = 0;
                    oDetail.QtyManualInput = 0;
                    oDetail.QtyReceived = detail.TxferQty;
                    oDetail.QtyRequested = detail.RequiredQty;
                    oDetail.Remarks = detail.Remarks;

                    if (prodId != System.Guid.Empty)
                    {
                        oDetail.Save();
                        result++;
                    }
                }
            }
            return result;
        }
        */
        #endregion
    }
}