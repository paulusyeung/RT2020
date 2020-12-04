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
using System.IO;
using RT2020.Controls;
using System.Web.Configuration;
using FileHelpers.DataLink;
using RT2020.DAL;
using System.Data.Entity;

#endregion

namespace RT2020.Inventory.StockTake.Import
{
    public partial class ImportFromPoS_SelectionWizard : Form
    {
        string mstrDirectory;
        string tempDirectory;
        string backupDirectory;
        string logFile;

        private List<string> Result { get; set; }
        public List<string[]> ResultList { get; set; }
        private ImportPOSData[] PacketDataList { get; set; }
        public string Remarks { get; set; }

        public ImportFromPoS_SelectionWizard()
        {
            InitializeComponent();

            InitializeDir();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            openFileDialog.MaxFileSize = 10240;
            openFileDialog.ShowDialog();

            LoadPacketList();
        }

        #region Initialize & Load

        private void InitializeDir()
        {
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "StockTake_From_POS");
            if (!Directory.Exists(mstrDirectory))
            {
                Directory.CreateDirectory(mstrDirectory);
            }

            tempDirectory = Path.Combine(mstrDirectory, "Temp");
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            backupDirectory = Path.Combine(mstrDirectory, "Backup");
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }

            string logDir = Path.Combine(mstrDirectory, "Log");
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            logFile = Path.Combine(logDir, "STK1300E_POS_" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        }

        private void LoadPacketList()
        {
            lvSelection.Items.Clear();

            if (!string.IsNullOrEmpty(tempDirectory))
            {
                string[] packetFiles = Directory.GetFiles(tempDirectory, "*.DBF", SearchOption.TopDirectoryOnly);

                for (int i = 0; i < packetFiles.Length; i++)
                {
                    ListViewItem lvItem = lvSelection.Items.Add(Path.GetFileName(packetFiles[i]));
                    lvItem.SubItems.Add(packetFiles[i]);
                }
            }
        }

        #endregion

        #region Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItem in lvSelection.Items)
            {
                if (btnMarkAll.Text.Contains("Mark All"))
                    lvItem.Checked = true;
                else if (btnMarkAll.Text.Contains("Unmark"))
                    lvItem.Checked = false;
            }

            btnMarkAll.Text = btnMarkAll.Text.Contains("Mark All") ? "Unmark All" : "Mark All";
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            Utility.UploadFile(openFileDialog, tempDirectory);

            LoadPacketList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ResultList = new List<string[]>();

            foreach (ListViewItem lvItem in lvSelection.Items)
            {
                if (lvItem.Checked)
                {
                    LoadPacket(lvItem.SubItems[1].Text);

                    if (Result != null)
                    {
                        ResultList.Add(Result.ToArray());

                        if (!Result.Exists(FindString))
                        {
                            File.Move(lvItem.SubItems[1].Text, Path.Combine(backupDirectory, lvItem.Text));
                        }
                    }
                }
            }

            this.Close();
        }

        private static bool FindString(string value)
        {
            if (value.LastIndexOf("Failed") >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Load Packet

        private void LoadPacket(string packet)
        {
            Result = new List<string>();

            string dbfConnStr = WebConfigurationManager.ConnectionStrings["dbfConn"].ConnectionString.Replace("{0}", tempDirectory);

            OleDbStorage oledbStorage = new OleDbStorage(typeof(ImportPOSData), dbfConnStr);

            string packetName = Path.GetFileNameWithoutExtension(packet);
            if (packetName.Length > 8)
            {
                packetName = packetName.Substring(0, 6) + "~1";
            }

            oledbStorage.SelectSql = "SELECT * FROM [" + packetName + ".DBF]";
            oledbStorage.FillRecordCallback = new FillRecordHandler(FillRecord);

            PacketDataList = oledbStorage.ExtractRecords() as ImportPOSData[];

            Result.Add(Path.GetFileName(packet));
            Result.Add(Path.GetFileNameWithoutExtension(packet));

            Import();
        }

        protected void FillRecord(object rec, object[] fields)
        {
            ImportPOSData record = (ImportPOSData)rec;

            record.STKCODE = (fields[0] is DBNull) ? string.Empty : fields[0].ToString();
            record.APPENDIX1 = (fields[1] is DBNull) ? string.Empty : fields[1].ToString();
            record.APPENDIX2 = (fields[2] is DBNull) ? string.Empty : fields[2].ToString();
            record.APPENDIX3 = (fields[3] is DBNull) ? string.Empty : fields[3].ToString();

            record.SeqNum = (fields[4] is DBNull) ? 0 : Convert.ToInt32(fields[4].ToString());
            record.Shop = (fields[5] is DBNull) ? string.Empty : fields[5].ToString();
            record.Terminal = (fields[6] is DBNull) ? string.Empty : fields[6].ToString();
            record.Operator = (fields[7] is DBNull) ? string.Empty : fields[7].ToString();
            record.Qty = (fields[8] is DBNull) ? 0 : Convert.ToDecimal(fields[8].ToString());
            record.Shelf = (fields[9] is DBNull) ? string.Empty : fields[9].ToString();
            record.Barcode = (fields[10] is DBNull) ? string.Empty : fields[10].ToString();
            record.HHT = (fields[11] is DBNull) ? string.Empty : fields[11].ToString();
            record.Keyboard = (fields[12] is DBNull) ? string.Empty : fields[12].ToString();
            record.TxDate = (fields[13] is DBNull) ? string.Empty : fields[13].ToString();
            record.Exported = (fields[14] is DBNull) ? string.Empty : fields[14].ToString();
            record.ExportedOn = (fields[15] is DBNull) ? string.Empty : fields[15].ToString();
            record.ExportNum = (fields[16] is DBNull) ? string.Empty : fields[16].ToString();
        }

        #endregion

        #region Import

        private bool CheckExistedTransaction(string txNumber, string hhtId)
        {
            var result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                if (hhtId.Trim().Length == 0)
                {
                    hhtId = "POS_ADV1";
                }

                var hhtHeader = ctx.StocktakeHeader_HHT.Where(x => x.TxNumber == txNumber && x.HHTId == hhtId).AsNoTracking().FirstOrDefault();
                if (hhtHeader != null) result = true;
            }

            return result;
        }

        private void Import()
        {
            if (PacketDataList != null && PacketDataList.Length > 0)
            {
                if (CheckExistedTransaction(PacketDataList[0].ExportNum, PacketDataList[0].HHT))
                {
                    MessageBox.Show("The transaction [" + PacketDataList[0].ExportNum + "] exists, try to import again and overwrite the existed data?", "Attention", MessageBoxButtons.YesNo, new EventHandler(ImportDataHandler));
                }
                else
                {
                    ImportData(false);
                }
            }
        }

        private void ImportDataHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                ImportData(true);
            }
            else
            {
                Result.Add("");
                Result.Add("Ignored/Failed");
                Result.Add(this.Remarks);
                Result.Add("");
            }
        }

        private void ImportData(bool overwrite)
        {
            if (PacketDataList != null && PacketDataList.Length > 0)
            {
                DateTime uploadOn = DateTime.Now;
                string shop = PacketDataList[0].Shop;
                string hht = PacketDataList[0].HHT.Length == 0 ? "POS_ADV1" : PacketDataList[0].HHT;
                System.Guid workplaceId = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(shop);

                if (workplaceId != System.Guid.Empty)
                {
                    System.Guid headerId = CreateStockTakeHHTHeader(PacketDataList[0].ExportNum, hht, workplaceId, uploadOn, overwrite);

                    if (headerId != System.Guid.Empty)
                    {
                        CreateStockTakeHHTDetails(headerId, uploadOn, overwrite);

                        Result.Add(shop);
                        Result.Add("Success");
                        Result.Add(this.Remarks);
                        Result.Add(hht);
                    }
                }
                else
                {
                    Result.Add(shop);
                    Result.Add("Failed");
                    Result.Add("Shop does not exist!");
                    Result.Add(hht);
                }
            }
        }

        private Guid CreateStockTakeHHTHeader(string txNumber, string hhtId, Guid workplaceId, DateTime uploadOn, bool overwrite)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                EF6.StocktakeHeader_HHT hhtHeader;

                if (overwrite)
                {
                    string sql = "TxNumber = '" + txNumber + "' AND HHTId ='" + hhtId + "'";
                    hhtHeader = ctx.StocktakeHeader_HHT.Where(x => x.TxNumber == txNumber && x.HHTId == hhtId).FirstOrDefault();
                }
                else
                {
                    hhtHeader = new EF6.StocktakeHeader_HHT();
                    hhtHeader.HeaderId = Guid.NewGuid();
                    hhtHeader.CreatedBy = Common.Config.CurrentUserId;
                    hhtHeader.CreatedOn = DateTime.Now;

                    ctx.StocktakeHeader_HHT.Add(hhtHeader);
                }

                hhtHeader.TxNumber = txNumber;
                hhtHeader.HHTId = hhtId;
                hhtHeader.UploadedOn = uploadOn;
                hhtHeader.WorkplaceId = workplaceId;
                hhtHeader.TotalRows = 0;
                hhtHeader.TOTALQTY = 0;
                hhtHeader.MissingQty = 0;
                hhtHeader.MissingRows = 0;
                hhtHeader.Remarks = this.Remarks;
                hhtHeader.Status = (int)Common.Enums.Status.Draft;
                hhtHeader.ModifiedBy = Common.Config.CurrentUserId;
                hhtHeader.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = hhtHeader.HeaderId;
            }
            return result;
        }

        private void CreateStockTakeHHTDetails(Guid headerId, DateTime uploadOn, bool overwrite)
        {
            int totalLine = PacketDataList.Length, missingLine = 0;
            decimal totalQty = 0, missingQty = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < PacketDataList.Length; i++)
                        {
                            EF6.StockTakeDetails_HHT hhtDetail;
                            ImportPOSData posData = PacketDataList[i];
                            totalQty += posData.Qty;

                            // Calc missing line & qty
                            Guid productId = GetProductId(posData.STKCODE, posData.APPENDIX1, posData.APPENDIX2, posData.APPENDIX3);
                            if (productId == System.Guid.Empty)
                            {
                                missingLine++;
                                missingQty += posData.Qty;
                            }
                            else
                            {
                                ProductBarcode pb = ProductBarcode.LoadWhere("ProductId = '" + productId.ToString() + "'");
                                if (pb == null)
                                {
                                    missingLine++;
                                    missingQty += posData.Qty;
                                }

                                string hhtId = posData.HHT.Trim().Length == 0 ? "POS_ADV1" : posData.HHT.Trim();

                                if (overwrite)
                                {
                                    //string sql = "TxNumber = '" + posData.ExportNum + "' AND HHTId ='" + hhtId + "'";
                                    hhtDetail = ctx.StockTakeDetails_HHT
                                        .Where(x => x.TxNumber == posData.ExportNum && x.HHTId == hhtId)
                                        .FirstOrDefault();
                                }
                                else
                                {
                                    hhtDetail = new EF6.StockTakeDetails_HHT();
                                    hhtDetail.DetailsId = Guid.NewGuid();

                                    ctx.StockTakeDetails_HHT.Add(hhtDetail);
                                }

                                hhtDetail.TxNumber = posData.ExportNum;
                                hhtDetail.HHTId = hhtId;
                                hhtDetail.UploadedOn = uploadOn;
                                hhtDetail.Barcode = posData.Barcode;
                                hhtDetail.Qty = posData.Qty;
                                hhtDetail.LineNumber = posData.SeqNum;
                                hhtDetail.ProductId = productId;
                                hhtDetail.Remarks = posData.Shelf;

                                ctx.SaveChanges();
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

            UpdateHHtHeader(headerId, totalLine, missingLine, totalQty, missingQty);
        }

        private void UpdateHHtHeader(Guid headerId, int totalLine, int missingLine, decimal totalQty, decimal missingQty)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hhtHeader = ctx.StocktakeHeader_HHT.Find(headerId);
                if (hhtHeader != null)
                {
                    hhtHeader.TOTALQTY = totalQty;
                    hhtHeader.TotalRows = totalLine;
                    hhtHeader.MissingRows = missingLine;
                    hhtHeader.MissingQty = missingQty;

                    ctx.SaveChanges(); 
                }
            }
        }

        private Guid GetProductId(string stkCode, string appendix1, string appendix2, string appendix3)
        {
            string sql = "STKCODE = '" + stkCode + "' AND APPENDIX1 = '" + appendix1 + "' AND APPENDIX2 = '" + appendix2 + "' AND APPENDIX3 = '" + appendix3 + "'";
            RT2020.DAL.Product oProduct = RT2020.DAL.Product.LoadWhere(sql);
            if (oProduct != null)
            {
                return oProduct.ProductId;
            }
            else
            {
                return System.Guid.Empty;
            }
        }

        #endregion
    }
}