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
using System.Text.RegularExpressions;
using RT2020.Controls;

using FileHelpers;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.StockTake.Import
{
    public partial class ImportFromPPC : Form
    {
        string mstrDirectory;
        string tempDirectory;
        string backupDirectory;
        string logFile;

        public ImportFromPPC()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetAttributes();
            LoadPacketList();
            WriteLog();
        }

        #region Set Attributes

        private void SetAttributes()
        {
            selectedDataCtrl.VisibleChanged += new EventHandler(selectedDataCtrl_VisibleChanged);

            mstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "StockTake_From_PPC");
            tempDirectory = Path.Combine(mstrDirectory, "Temp");
            backupDirectory = Path.Combine(mstrDirectory, "Backup");
            logFile = Path.Combine(Path.Combine(mstrDirectory, "Log"), "STK1300M_PPC_" + DateTime.Now.ToString("yyyyMMdd") + ".log");

            lblRecordNotFound.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            lblLedgendOfStockTakeNumber.BackColor = SystemInfoHelper.ControlBackColor.RequiredBox;

            txtUploadOn.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtHHTId.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtHHTTxNumber.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtStockTakeNumber.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
        }

        private string GetUploadOn(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            return DateTimeHelper.DateTimeToString(fileInfo.LastWriteTime, true);
        }

        #endregion

        #region Verify

        private bool IsHeaderFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                Regex guidRegEx = new Regex(@"^(HD_)+(?=.*\d)(?=.*[a-zA-Z0-9])(?!.*[\W_\x7B-\xFF]).{6,15}$");
                return guidRegEx.IsMatch(fileName);
            }
            else
                return false;
        }

        private bool IsDetailFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                Regex guidRegEx = new Regex(@"^(DT_)+(?=.*\d)(?=.*[a-zA-Z0-9])(?!.*[\W_\x7B-\xFF]).{6,15}$");
                return guidRegEx.IsMatch(fileName);
            }
            else
                return false;
        }

        private void WriteLog()
        {
            if (!Directory.Exists(Path.GetDirectoryName(logFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(logFile));
            }

            string message = "STK1300M_PPC - Import Data from Pocket PC	[RUN AT {0}]";

            Utility.WriteLog(string.Format(message, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")), logFile);
            Utility.WriteLog(string.Empty, logFile);
        }

        private void CheckHHTLog(string HHTID)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hhtLog = ctx.SystemHHTLog.Where(x => x.HHTID == HHTID).FirstOrDefault();
                if (hhtLog == null)
                {
                    hhtLog = new EF6.SystemHHTLog();
                    hhtLog.LogId = Guid.NewGuid();
                    hhtLog.HHTID = HHTID;
                    hhtLog.Module = "RWS_STK3 [Stock Take]";
                    hhtLog.Form = "STK1300M_PPC " + this.Text;
                    hhtLog.CreatedBy = ConfigHelper.CurrentUserId;
                    hhtLog.CreatedOn = DateTime.Now;

                    ctx.SystemHHTLog.Add(hhtLog);
                }

                hhtLog.ModifiedBy = ConfigHelper.CurrentUserId;
                hhtLog.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
            }
        }

        #endregion

        #region Help Message

        private void btnHelp_Click(object sender, EventArgs e)
        {
            #region Header Message

            StringBuilder message = new StringBuilder();
            message.Append(@"File Structure").AppendLine();
            message.Append(@"").AppendLine();
            message.Append(@"The record content is listed as follows:").AppendLine();
            message.Append(@"** Each field in a line is seperated by a <TAB> **").AppendLine();
            message.Append(@"").AppendLine();
            message.Append(@"File name: 'HD_' + HHT TRN# + '.TXT'").AppendLine();
            message.Append(@"").AppendLine();
            message.Append(@"Header (Column)").AppendLine();
            message.Append(@"--------------------------------------------------------------------").AppendLine();
            message.Append(@"1 -    Record Type     - ('HH')").AppendLine();
            message.Append(@"2 -    Location Code").AppendLine();
            message.Append(@"3 -    HHT ID").AppendLine();
            message.Append(@"4 -    HHT TRN#").AppendLine();
            message.Append(@"").AppendLine();
            message.Append(@"Detail (Column)").AppendLine();
            message.Append(@"--------------------------------------------------------------------").AppendLine();
            message.Append(@"1 -    Record Type     - ('DD')").AppendLine();
            message.Append(@"2 -    Shelf").AppendLine();
            message.Append(@"3 -    Shelf (Name)").AppendLine();
            message.Append(@"4 -    Qty").AppendLine();
            message.Append(@"5 -    # of Line(s)").AppendLine();
            message.Append(@"6 -    Last Updated    - (ddMMyyyyHHmmss)").AppendLine();
            message.Append(@"").AppendLine();
            message.Append(@"Footer (Column)").AppendLine();
            message.Append(@"--------------------------------------------------------------------").AppendLine();
            message.Append(@"1 -    Record Type     - ('EE')").AppendLine();
            message.Append(@"2 -    Total Line").AppendLine();
            message.Append(@"").AppendLine();

            #endregion

            MessageBox.Show(message.ToString(), "Attention", new EventHandler(HelpMessage));
        }

        private void HelpMessage(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                #region Detail Message

                StringBuilder message = new StringBuilder();
                message.Append(@"File Structure").AppendLine();
                message.Append(@"").AppendLine();
                message.Append(@"The record content is listed as follows:").AppendLine();
                message.Append(@"** Each field in a line is seperated by a <TAB> **").AppendLine();
                message.Append(@"").AppendLine();
                message.Append(@"File name: 'DT_' + HHT TRN# + '_' + Shelf + '.TXT'").AppendLine();
                message.Append(@"").AppendLine();
                message.Append(@"Header (Column)").AppendLine();
                message.Append(@"--------------------------------------------------------------------").AppendLine();
                message.Append(@"1 -    Record Type     - ('HH')").AppendLine();
                message.Append(@"").AppendLine();
                message.Append(@"Detail (Column)").AppendLine();
                message.Append(@"--------------------------------------------------------------------").AppendLine();
                message.Append(@"1 -    Record Type     - ('DD')").AppendLine();
                message.Append(@"2 -    Location Code").AppendLine();
                message.Append(@"3 -    HHT ID").AppendLine();
                message.Append(@"4 -    HHT TRN#").AppendLine();
                message.Append(@"5 -    Shelf").AppendLine();
                message.Append(@"6 -    Seq#").AppendLine();
                message.Append(@"7 -    Barcode").AppendLine();
                message.Append(@"8 -    Qty").AppendLine();
                message.Append(@"9 -    Key in          - ('Y' / 'N')").AppendLine();
                message.Append(@"10 -   Last Updated    - (ddMMyyyyHHmmss)").AppendLine();
                message.Append(@"").AppendLine();
                message.Append(@"Footer (Column)").AppendLine();
                message.Append(@"--------------------------------------------------------------------").AppendLine();
                message.Append(@"1 -    Record Type     - ('EE')").AppendLine();
                message.Append(@"2 -    Total Line").AppendLine();
                message.Append(@"").AppendLine();

                #endregion

                MessageBox.Show(message.ToString(), "Attention");
            }
        }

        #endregion

        #region Load Not finished Packet

        private void LoadPacketList()
        {
            lvPPCPacketList.Items.Clear();

            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            if (!string.IsNullOrEmpty(tempDirectory))
            {
                string[] packetFiles = Directory.GetFiles(tempDirectory, "*.txt", SearchOption.TopDirectoryOnly);

                for (int i = 0; i < packetFiles.Length; i++)
                {
                    string fileName = packetFiles[i];
                    if (IsHeaderFile(Path.GetFileNameWithoutExtension(fileName)) && Path.GetExtension(fileName).ToLower() == ".txt")
                    {
                        lbPacketList.Items.Add(Path.GetFileName(fileName));

                        LoadPacketList(fileName);
                    }
                }
            }
        }

        private void LoadPacketList(string packetName)
        {
            int iCount = 0;
            decimal qty = 0;
            using (StreamReader sr = File.OpenText(packetName))
            {
                if (sr.Peek() != -1)
                {
                    string stocktakeNumber = string.Empty;
                    string loc = string.Empty;

                    ListViewItem lvItem = null;

                    string[] srAllLine = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    for (int i = 0; i < srAllLine.Length; i++)
                    {
                        string srLine = srAllLine[i];

                        if (srLine.Substring(0, 2) == "HH")
                        {
                            lvItem = new ListViewItem();

                            string[] headerInfo = srLine.Split(new char[] { '\t' });

                            lvItem.SubItems.Add(headerInfo[1]); // LOC#
                            lvItem.SubItems.Add(headerInfo[3]); // Stock Take#
                            lvItem.SubItems.Add(headerInfo[3]); // HHT TRN#
                            lvItem.SubItems.Add(GetUploadOn(packetName)); // Upload On
                            lvItem.SubItems.Add(headerInfo[2]); // HHT ID

                            lvItem.UseItemStyleForSubItems = false;
                            lvItem.SubItems[1].BackColor = SystemInfoHelper.ControlBackColor.RequiredBox;

                            stocktakeNumber = headerInfo[3];
                            loc = headerInfo[1];
                        }

                        if (srLine.Substring(0, 2) == "DD")
                        {
                            string[] detailInfo = srLine.Split(new char[] { '\t' });

                            decimal srQty = 0;
                            if (decimal.TryParse(detailInfo[3], out srQty))
                            {
                                qty += srQty;
                            }

                            iCount++;
                        }

                        if (srLine.Substring(0, 2) == "EE" && lvItem != null)
                        {
                            lvItem.SubItems.Add(iCount.ToString()); // # of shelf
                            lvItem.SubItems.Add(qty.ToString()); // Qty
                            lvItem.SubItems.Add(string.Empty); // Remarks

                            lvItem.SubItems.Add(packetName); // File name
                            lvItem.SubItems.Add(loc); // Origin Location
                            lvItem.SubItems.Add(stocktakeNumber); // Origin StockTake Number

                            lvPPCPacketList.Items.Add(lvItem);
                        }
                    }
                }
            }
        }

        #endregion

        #region Save data to Stock Take

        private void Save()
        {
            int iCount = 1;
            bool isValid = true;

            foreach (ListViewItem lvItem in lvPPCPacketList.Items)
            {
                if (lvItem.Checked)
                {
                    string stktkNumber = string.Empty;
                    Guid workplaceId = Guid.Empty;
                    DateTime uploadedOn = DateTime.Now;
                    List<ImportDetailsInfo> detailAllList = new List<ImportDetailsInfo>();
                    decimal totalLine = 0, totalQty = 0, missingLine = 0, missingQty = 0;

                    this.CheckHHTLog(lvItem.SubItems[4].Text);

                    #region Load Header's detail info
                    FileHelperEngine<ImportHeaderInfo> headerInfoEngine = new FileHelperEngine<ImportHeaderInfo>();

                    headerInfoEngine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

                    ImportHeaderInfo[] headerInfoList = headerInfoEngine.ReadFile(lvItem.SubItems[8].Text);

                    if (headerInfoEngine.ErrorManager.ErrorCount > 0)
                        headerInfoEngine.ErrorManager.SaveErrors(logFile);
                    #endregion

                    Utility.WriteLog("Date Create	 : " + uploadedOn.ToString("dd/MM/yyyy HH:mm:ss"), logFile);
                    Utility.WriteLog("Session ID	 : " + uploadedOn.ToString("yyyyMMdd-HHmmss") + "-" + iCount.ToString().PadLeft(3, '0'), logFile);
                    Utility.WriteLog("Upload Time	 : " + uploadedOn.ToString("dd/MM/yyyy HH:mm:ss"), logFile);
                    Utility.WriteLog("HHT TRN#	 : " + lvItem.SubItems[2].Text, logFile);
                    Utility.WriteLog("Location#	 : " + lvItem.SubItems[9].Text + " [Original]; " + lvItem.Text + " [Current]", logFile);
                    Utility.WriteLog("Stock Take#	 : " + lvItem.SubItems[10].Text + " [Suggested]; " + lvItem.SubItems[1].Text + " [Current]", logFile);
                    Utility.WriteLog("Process Detail	 : Import Data", logFile);
                    Utility.WriteLog("Message :- ", logFile);
                    Utility.WriteLog("=> Checking Loc# ", logFile);

                    #region Check Workplace (Loc#)
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var wp = ctx.Workplace.Where(x => x.WorkplaceCode == lvItem.Text).AsNoTracking().FirstOrDefault();
                        if (wp != null)
                        {
                            if (wp.Retired)
                            {
                                Utility.WriteLog("	[ERROR] Loc# was retired ", logFile);
                                isValid = isValid & false;
                            }
                            else
                            {
                                Utility.WriteLog("	[OK] ", logFile);
                                workplaceId = wp.WorkplaceId;
                            }
                        }
                        else
                        {
                            Utility.WriteLog("	[ERROR] Loc# Not Found", logFile);
                            isValid = isValid & false;
                        }
                    }
                    #endregion

                    Utility.WriteLog("	RESULT : COMPLETED", logFile);
                    Utility.WriteLog("=> Import Packet File ", logFile);

                    #region Load details files
                    string[] packetFiles = Directory.GetFiles(tempDirectory, "DT_" + lvItem.SubItems[2].Text + "*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < packetFiles.Length; i++)
                    {
                        Utility.WriteLog(@"	" + (i + 1).ToString() + @") Packet => " + Path.GetFileNameWithoutExtension(packetFiles[i]) + " [" + packetFiles[i] + "] ", logFile);
                    }
                    #endregion

                    Utility.WriteLog("	RESULT : COMPLETED", logFile);
                    Utility.WriteLog("=> Checking (Header) ", logFile);

                    stktkNumber = lvItem.SubItems[1].Text.Trim();

                    #region checking Header info
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var stktkHeader = ctx.StockTakeHeader.Where(x => x.TxNumber == lvItem.SubItems[1].Text.Trim()).FirstOrDefault();
                        if (stktkHeader != null)
                        {
                            if (!string.IsNullOrEmpty(stktkHeader.ADJNUM))
                            {
                                Utility.WriteLog("	[ERROR] The Stock Take Number was posted, cannot be used anymore. ", logFile);
                                isValid = isValid & false;
                            }
                            else if (!WorkplaceEx.GetWorkplaceCodeById(stktkHeader.WorkplaceId.Value).Equals(lvItem.Text.Trim()))
                            {
                                Utility.WriteLog("	[ERROR] The loc# in Stock Take Header must be as same as the selected one. ", logFile);
                                isValid = isValid & false;
                            }
                            else
                            {
                                //? Why compare the UploadedOn down to "seconds"
                                //string sql = "TxNumber = '" + lvItem.SubItems[1].Text.Trim() + "' AND HHTId = '" + lvItem.SubItems[4].Text + "' AND CONVERT(NVARCHAR(20), UploadedOn, 120) = '" + uploadedOn.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                                var txNumber = lvItem.SubItems[1].Text.Trim();
                                var hhtId = lvItem.SubItems[4].Text;
                                var hhtHeader = ctx.StocktakeHeader_HHT.Where(x => x.TxNumber == txNumber && x.HHTId == hhtId && x.UploadedOn.Value.ToString("yyyy-MM-dd HH:mm:ss") == uploadedOn.ToString("yyyy-MM-dd HH:mm:ss")).FirstOrDefault();
                                if (hhtHeader != null)
                                {
                                    if (hhtHeader.PostedOn.Value.Year > 1900)
                                    {
                                        Utility.WriteLog("	[ERROR] The Stock Take (HHT) Number was posted, cannot be used anymore. ", logFile);
                                        isValid = isValid & false;
                                    }
                                    else
                                    {
                                        Utility.WriteLog("	[ERROR] The Stock Take (HHT) Number existed. ", logFile);
                                        isValid = isValid & false;
                                    }
                                }
                                else
                                {
                                    Utility.WriteLog("	[OK]  ", logFile);
                                }
                            }
                        }
                        else
                        {
                            Utility.WriteLog("	[OK]  ", logFile);
                        }
                    }
                    #endregion

                    Utility.WriteLog("=> Checking (Detail) ", logFile);
                    int iCountBarcode = 0;

                    #region checking details info
                    for (int iHeader = 0; iHeader < headerInfoList.Length; iHeader++)
                    {
                        ImportHeaderInfo headerInfo = headerInfoList[iHeader];

                        FileHelperEngine<ImportDetailsInfo> detailInfoEngine = new FileHelperEngine<ImportDetailsInfo>();

                        detailInfoEngine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

                        string detailPacket = Path.Combine(tempDirectory, "DT_" + lvItem.SubItems[2].Text + "_" + headerInfo.ShelfId + ".TXT");
                        ImportDetailsInfo[] detailInfoList = detailInfoEngine.ReadFile(detailPacket);

                        if (headerInfoEngine.ErrorManager.ErrorCount > 0)
                            headerInfoEngine.ErrorManager.SaveErrors(logFile);

                        Utility.WriteLog("	=> Checking Shelf (" + headerInfo.ShelfId + " - " + headerInfo.ShelfName + ")", logFile);

                        for (int iDetail = 0; iDetail < detailInfoList.Length; iDetail++)
                        {
                            ImportDetailsInfo detailInfo = detailInfoList[iDetail];
                            if (string.IsNullOrEmpty(detailInfo.Barcode))
                            {
                                iCountBarcode++;
                                missingQty += detailInfo.Qty;

                                Utility.WriteLog("	[ERROR] Barcode does not exist. ", logFile);
                            }
                            else
                            {
                                Guid productId = ProductBarcodeEx.GetProductIdByBarcode(detailInfo.Barcode);

                                if (productId == System.Guid.Empty)
                                {
                                    iCountBarcode++;
                                    missingQty += detailInfo.Qty;

                                    Utility.WriteLog("	[ERROR] Barcode (" + detailInfo.Barcode + ") does not exist. ", logFile);
                                }
                                else
                                {
                                    if (detailInfo.Qty <= 0)
                                    {
                                        Utility.WriteLog("	[ERROR] Barcode (" + detailInfo.Barcode + ") QTY <= 0 ", logFile);
                                        isValid = isValid & false;
                                    }
                                    else
                                    {
                                        Utility.WriteLog("	[OK] Barcode (" + detailInfo.Barcode + ") QTY > 0 ", logFile);
                                    }
                                }
                            }

                            totalLine++;
                            totalQty += detailInfo.Qty;

                            detailAllList.Add(detailInfo);
                        }

                        missingLine += iCountBarcode;

                        if (iCountBarcode > 0)
                        {
                            Utility.WriteLog("	[ERROR] Details of Shelf (" + headerInfo.ShelfId + " - " + headerInfo.ShelfName + ") has " + iCountBarcode.ToString() + " empty barcode.", logFile);
                        }
                        else
                        {
                            Utility.WriteLog("	[OK] Details of Shelf (" + headerInfo.ShelfId + " - " + headerInfo.ShelfName + ") has 0 empty barcode.", logFile);
                        }
                    }
                    #endregion

                    Utility.WriteLog("	RESULT : COMPLETED", logFile);
                    Utility.WriteLog("=> Save Packet", logFile);

                    #region isValid: wrapping up
                    if (isValid)
                    {
                        if (stktkNumber.Trim().Length == 0)
                        {
                            stktkNumber = SystemInfoHelper.Settings.QueuingTxNumber(EnumHelper.TxType.STK);
                        }

                        Utility.WriteLog("	[OK] System Queue ", logFile);

                        if (stktkNumber.Length > 0)
                        {
                            // Stock take header
                            System.Guid stktkheaderId = CreateStockTakeHeader(stktkNumber.Trim(), workplaceId);
                            Utility.WriteLog("	[OK] Create Worksheet (Stock Take - Header)", logFile);

                            // Stock take details
                            if (stktkheaderId != System.Guid.Empty)
                            {
                                CreatedStockTakeDetail(stktkheaderId, stktkNumber.Trim(), detailAllList, workplaceId, uploadedOn);
                            }
                            Utility.WriteLog("	[OK] Create Worksheet (Stock Take - Detail)", logFile);

                            // Stock take header (HHT)
                            System.Guid hhtHeaderId = CreateStockTakeHHTHeader(stktkNumber.Trim(), lvItem.SubItems[4].Text, uploadedOn, workplaceId, lvItem.SubItems[2].Text,
                                totalLine, totalQty, missingLine, missingQty);
                            Utility.WriteLog("	[OK] Create Worksheet (HHT Data Review - Header)", logFile);

                            // Stock take details (HHT)
                            if (hhtHeaderId != System.Guid.Empty)
                            {
                                CreateStockTakeHHTDetails(hhtHeaderId, stktkNumber.Trim(), lvItem.SubItems[4].Text, uploadedOn, detailAllList, lvItem.SubItems[2].Text);
                            }

                            Utility.WriteLog("	[OK] Create Worksheet (HHT Data Review - Detail)", logFile);
                            Utility.WriteLog("	[OK] Barcode Matching", logFile);
                            Utility.WriteLog("	[OK] Counting Missing Data", logFile);
                            Utility.WriteLog("	RESULT : COMPLETED", logFile);

                            // Backup text files
                            if (!Directory.Exists(backupDirectory))
                            {
                                Directory.CreateDirectory(backupDirectory);
                            }

                            // Header file
                            File.Move(lvItem.SubItems[8].Text, Path.Combine(backupDirectory, Path.GetFileName(lvItem.SubItems[8].Text)));

                            for (int i = 0; i < packetFiles.Length; i++)
                            {
                                File.Move(packetFiles[i], Path.Combine(backupDirectory, Path.GetFileName(packetFiles[i])));
                            }

                            Utility.WriteLog("=> Backup Data	RESULT : COMPLETED", logFile);
                        }
                    }
                    #endregion

                    iCount++;
                }
            }
        }

        #region Stock Take

        private Guid CreateStockTakeHeader(string txNumber, Guid workplaceId)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "TxNumber = '" + txNumber.Trim() + "'";

                var stktkHeader = ctx.StockTakeHeader.Where(x => x.TxNumber == txNumber).FirstOrDefault();
                if (stktkHeader == null)
                {
                    stktkHeader = new EF6.StockTakeHeader();

                    stktkHeader.HeaderId = Guid.NewGuid();
                    stktkHeader.TxNumber = txNumber;
                    stktkHeader.TxDate = DateTime.Now;

                    stktkHeader.CreatedBy = ConfigHelper.CurrentUserId;
                    stktkHeader.CreatedOn = DateTime.Now;

                    ctx.StockTakeHeader.Add(stktkHeader);
                }

                stktkHeader.WorkplaceId = workplaceId;

                stktkHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                stktkHeader.ModifiedOn = DateTime.Now;
                stktkHeader.Status = (int)EnumHelper.Status.Draft;

                ctx.SaveChanges();
                result = stktkHeader.HeaderId;
            }

            return result;
        }

        private void CreatedStockTakeDetail(Guid stktkHeaderId, string txNumber, List<ImportDetailsInfo> detailList, Guid workplaceId, DateTime uploadedOn)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (ImportDetailsInfo detail in detailList)
                        {
                            Guid productId = ProductBarcodeEx.GetProductIdByBarcode(detail.Barcode);

                            if (!string.IsNullOrEmpty(detail.Barcode.Trim()) && productId != Guid.Empty)
                            {
                                //string sql = "HeaderId = '" + stktkHeaderId.ToString() + "' AND TxNumber = '" + txNumber + "' AND ProductId = '" + productId.ToString() + "' AND WorkplaceId = '" + workplaceId.ToString() + "'";
                                var item = ctx.StockTakeDetails.Where(x => x.HeaderId == stktkHeaderId && x.TxNumber == txNumber && x.ProductId == productId && x.WorkplaceId == workplaceId).FirstOrDefault();
                                if (item == null)
                                {
                                    item = new EF6.StockTakeDetails();
                                    item.DetailsId = Guid.NewGuid();
                                    item.HeaderId = stktkHeaderId;
                                    item.TxNumber = txNumber;
                                    item.ProductId = productId;
                                    item.WorkplaceId = workplaceId;

                                    item.ModifiedOn = uploadedOn;
                                    item.ModifiedBy = ConfigHelper.CurrentUserId;

                                    ctx.StockTakeDetails.Add(item);
                                }

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
        }

        #endregion

        #region HHT Summation Data

        private Guid CreateStockTakeHHTHeader(string txNumber, string hhtId, DateTime uploadedOn, Guid workplaceId, string hhtTxNumber,
            decimal totalLine, decimal totalQty, decimal missingLine, decimal missingQty)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "TxNumber = '" + txNumber + "'";
                var hhtHeader = ctx.StocktakeHeader_HHT.Where(x => x.TxNumber == txNumber).FirstOrDefault();
                if (hhtHeader == null)
                {
                    hhtHeader = new EF6.StocktakeHeader_HHT();
                    hhtHeader.HeaderId = Guid.NewGuid();
                    hhtHeader.TxNumber = txNumber;

                    hhtHeader.Status = (int)EnumHelper.Status.Draft;
                    hhtHeader.CreatedBy = ConfigHelper.CurrentUserId;
                    hhtHeader.CreatedOn = DateTime.Now;

                    ctx.StocktakeHeader_HHT.Add(hhtHeader);
                }

                hhtHeader.HHTId = hhtId;
                hhtHeader.UploadedOn = uploadedOn;
                hhtHeader.WorkplaceId = workplaceId;
                hhtHeader.Remarks = hhtTxNumber;
                hhtHeader.TotalRows = (int)totalLine;
                hhtHeader.TOTALQTY = totalQty;
                hhtHeader.MissingRows = (int)missingLine;
                hhtHeader.MissingQty = missingQty;

                hhtHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                hhtHeader.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = hhtHeader.HeaderId;
            }

            return result;
        }

        private void CreateStockTakeHHTDetails(Guid hhtHeaderId, string txNumber, string hhtId, DateTime uploadedOn, List<ImportDetailsInfo> detailList, string hhtTxNumber)
        {
            int iCount = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (ImportDetailsInfo detail in detailList)
                        {
                            Guid productId = ProductBarcodeEx.GetProductIdByBarcode(detail.Barcode);

                            if (!string.IsNullOrEmpty(detail.Barcode.Trim()) && productId != System.Guid.Empty)
                            {
                                #region update dbo.StockTakeDetails_HHT
                                //string sql = "HeaderId = '" + hhtHeaderId.ToString() + "' AND TxNumber = '" + txNumber + "' AND ProductId = '" + productId.ToString() + "'";
                                var hhtDetail = ctx.StockTakeDetails_HHT
                                    .Where(x => x.HeaderId == hhtHeaderId && x.TxNumber == txNumber && x.ProductId == productId)
                                    .FirstOrDefault();
                                if (hhtDetail == null)
                                {
                                    hhtDetail = new EF6.StockTakeDetails_HHT();
                                    hhtDetail.DetailsId = Guid.NewGuid();
                                    hhtDetail.HeaderId = hhtHeaderId;
                                    hhtDetail.TxNumber = txNumber;
                                    hhtDetail.LineNumber = iCount++;
                                    hhtDetail.UploadedOn = uploadedOn;
                                    hhtDetail.ProductId = productId;
                                    hhtDetail.Barcode = detail.Barcode;

                                    ctx.StockTakeDetails_HHT.Add(hhtDetail);
                                }

                                hhtDetail.Qty = detail.Qty;
                                hhtDetail.Remarks = hhtTxNumber;

                                ctx.SaveChanges();
                                #endregion
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
        }

        #endregion

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadPacketList_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "PPC Packet files";
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            Utility.UploadFile(openFileDialog, tempDirectory);

            LoadPacketList();
        }

        private void lbPacketList_Click(object sender, EventArgs e)
        {
            string selectedPackt = Path.Combine(tempDirectory, lbPacketList.SelectedItem.ToString());

            using (StreamReader sr = File.OpenText(selectedPackt))
            {
                if (sr.Peek() != -1)
                {
                    string header = sr.ReadLine();
                    if (header.Substring(0, 2) == "HH")
                    {
                        string[] headerInfo = header.Split(new char[] { '\t' });

                        txtUploadOn.Text = GetUploadOn(selectedPackt);
                        txtHHTId.Text = headerInfo[2];
                        txtHHTTxNumber.Text = headerInfo[3];
                        txtStockTakeNumber.Text = headerInfo[3];
                    }
                }
            }
        }

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItem in lvPPCPacketList.Items)
            {
                lvItem.Checked = (btnMarkAll.Text.Contains("Mark"));
            }

            btnMarkAll.Text = (btnMarkAll.Text.Contains("Mark")) ? "Unmark All" : "Mark All";
        }

        private void lvPPCPacketList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvItem = lvPPCPacketList.SelectedItem;

            lvItem.Checked = lvItem.Checked;
            lvItem.SubItems[9].Text = lvItem.Text;
            lvItem.SubItems[10].Text = lvItem.SubItems[1].Text;

            if (!string.IsNullOrEmpty(lvItem.Text))
            {
                selectedDataCtrl.SelectedIndex = lvItem.Index;
                selectedDataCtrl.Workplace = lvItem.Text.Trim();
                selectedDataCtrl.HHTTxNumber = lvItem.SubItems[2].Text.Trim();
                selectedDataCtrl.StockTakeNumber = lvItem.SubItems[1].Text.Trim();
                selectedDataCtrl.Visible = true;
            }
        }

        void selectedDataCtrl_VisibleChanged(object sender, EventArgs e)
        {
            if (!selectedDataCtrl.Visible && selectedDataCtrl.HasChanged)
            {
                ListViewItem lvItem = lvPPCPacketList.Items[selectedDataCtrl.SelectedIndex];
                lvItem.Selected = true;
                lvItem.Text = selectedDataCtrl.Workplace;
                lvItem.SubItems[1].Text = selectedDataCtrl.StockTakeNumber;

                lvItem.Update();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void ImportFromPPC_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Log file: " + logFile, "Attention");
        }
    }
}