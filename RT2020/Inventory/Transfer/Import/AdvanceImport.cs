#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;
using FileHelpers;
using RT2020.Controls;
using System.Data.SqlClient;
using System.Configuration;

using RT2020.Helper;
using RT2020.ModelEx;

#endregion

namespace RT2020.Inventory.Transfer.Import
{
    public partial class AdvanceImport : Form
    {
        string mstrDirectory;
        public AdvanceImport()
        {
            InitializeComponent();
        }

        private void Invt_TxferImportWizard_Advance_Load(object sender, EventArgs e)
        {
            lblYear.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear;
            lblMonth.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth;
            lblDay.Text = DateTime.Today.Day.ToString().PadLeft(2, '0');
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "Invt_Txfer_Advance");

            InitTabPages();
            InitTempTable();
        }

        #region Init Tab Page
        private void InitTabPages()
        {
            tpBarcode_MatchedItems.Controls.Add(new AdvanceImport_ListView());
            tpBarcode_UnMatchedItems.Controls.Add(new AdvanceImport_ListView());
            tpRequired_MatchedItems.Controls.Add(new AdvanceImport_ListView());
            tpRequired_UnMatchedItems.Controls.Add(new AdvanceImport_ListView());
        }
        #endregion

        #region Init Data
        private void InitTempTable()
        {
            // Drop the temp table if exists.
            string query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TxferAdvanceImportSummary]') AND type in (N'U'))
DROP TABLE [dbo].[TxferAdvanceImportSummary] ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // Drop the temp table if exists.
            query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TxferAdvanceImport]') AND type in (N'U'))
DROP TABLE [dbo].[TxferAdvanceImport] ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // create new temp table
            query = @"
CREATE TABLE [dbo].[TxferAdvanceImportSummary](
	[TxNumber] [varchar](12) NOT NULL,
	[STKCODE] [varchar](10) NOT NULL,
	[APPENDIX1] [varchar](4) NOT NULL,
	[APPENDIX2] [varchar](4) NOT NULL,
	[APPENDIX3] [varchar](4) NOT NULL,
	[Barcode] [varchar](22) NULL,
    [Qty] [decimal](18, 4) NULL,
	[MatchedBarcode] [varchar](1) NULL,
	[UnMatchedBarcode] [varchar](1) NULL,
	[MatchedRequired] [varchar](1) NULL,
	[UnMatchedRequired] [varchar](1) NULL,
	[NotInMatch] [varchar](1) NULL
) ON [PRIMARY]";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // create new temp table
            query = @"
CREATE TABLE [dbo].[TxferAdvanceImport](
	[LocNo] [varchar](4) NOT NULL,
	[HHTID] [varchar](19) NOT NULL,
	[TxNumber] [varchar](12) NOT NULL,
	[Barcode] [varchar](22) NULL,
    [Qty] [decimal](18, 4) NULL,
	[Keyboard] [varchar](1) NULL,
	[EntryDate] [varchar](14) NULL
) ON [PRIMARY]";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        private void DropTempTable()
        {
            // Drop the temp table if exists.
            string query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TxferAdvanceImportSummary]') AND type in (N'U'))
DROP TABLE [dbo].[TxferAdvanceImportSummary] ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // Drop the temp table if exists.
            query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TxferAdvanceImport]') AND type in (N'U'))
DROP TABLE [dbo].[TxferAdvanceImport] ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
        #endregion

        #region Operations

        private void SummarizeData()
        {
            string query = @"
INSERT INTO [TxferAdvanceImportSummary]([TxNumber], [STKCODE], [APPENDIX1], [APPENDIX2], [APPENDIX3], [Barcode], [Qty], [MatchedBarcode],
        [UnMatchedBarcode], [MatchedRequired], [UnMatchedRequired], [NotInMatch])
SELECT TRF.TxNumber, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, 
	   TRF.BARCODE, SUM(TRF.QTY) AS Qty, 'N' AS BAR_MATCH, 'N' AS BAR_UNMATCH, 'N' AS REQ_MATCH, 
	   'N' AS REQ_UNMATCH, 'N' AS NOTINBATCH 
FROM [TxferAdvanceImport] TRF LEFT JOIN ProductBarcode BAR ON TRF.BARCODE = BAR.BARCODE 
	   LEFT JOIN Product p ON p.ProductId = BAR.ProductId
GROUP BY TRF.TxNumber, TRF.BARCODE, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // Update matched barcode
            query = @"
UPDATE TxferAdvanceImportSummary
SET TxferAdvanceImportSummary.MatchedBarcode = 'Y'
FROM TxferAdvanceImportSummary S LEFT JOIN ProductBarcode BAR ON S.BARCODE = BAR.BARCODE
	   LEFT JOIN Product p ON p.ProductId = BAR.ProductId
WHERE (p.ProductId IS NOT NULL) ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // Update unmatched barcode
            query = @"
UPDATE TxferAdvanceImportSummary
SET TxferAdvanceImportSummary.UnMatchedBarcode = 'Y'
FROM TxferAdvanceImportSummary S LEFT JOIN ProductBarcode BAR ON S.BARCODE = BAR.BARCODE
	   LEFT JOIN Product p ON p.ProductId = BAR.ProductId
WHERE (p.ProductId IS NULL) ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // Update matched required
            query = @"
UPDATE TxferAdvanceImportSummary
SET TxferAdvanceImportSummary.MatchedRequired = 'Y'
FROM TxferAdvanceImportSummary S LEFT JOIN (InvtBatchTXF_Details TRF 
	   LEFT JOIN Product p ON p.ProductId = TRF.ProductId) 
	   ON S.TxNumber = TRF.TxNumber AND S.STKCODE = p.STKCODE
	   AND S.APPENDIX1 = p.APPENDIX1
	   AND S.APPENDIX2 = p.APPENDIX2
	   AND S.APPENDIX3 = p.APPENDIX3
WHERE (p.ProductId IS NOT NULL) ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // Update unmatched required
            query = @"
UPDATE TxferAdvanceImportSummary
SET TxferAdvanceImportSummary.UnMatchedRequired = 'Y'
FROM TxferAdvanceImportSummary S LEFT JOIN (InvtBatchTXF_Details TRF 
	   LEFT JOIN Product p ON p.ProductId = TRF.ProductId) 
	   ON S.TxNumber = TRF.TxNumber AND S.STKCODE = p.STKCODE
	   AND S.APPENDIX1 = p.APPENDIX1
	   AND S.APPENDIX2 = p.APPENDIX2
	   AND S.APPENDIX3 = p.APPENDIX3
WHERE (p.ProductId IS NULL)  ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            // Update notinmatch
            query = @"
UPDATE [TxferAdvanceImportSummary]
SET [TxferAdvanceImportSummary].NotInMatch = 'Y'
FROM [TxferAdvanceImportSummary] S LEFT JOIN InvtBatchTXF_Header TRF ON S.TxNumber = TRF.TxNumber
WHERE TRF.TxNumber = '' OR TRF.TxNumber IS NULL";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        private void LoadData()
        {
            string query = @"
SELECT TxNumber, NotInMatch FROM [TxferAdvanceImportSummary]
GROUP BY TxNumber, NotInMatch
ORDER BY TxNumber, NotInMatch";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    bool notInMatch = string.IsNullOrEmpty(reader.GetString(1)) || reader.GetString(1) == "N" ? false : true;
                    // Check Detail HACK: check 嚟做咩? 都冇用到
                    var txNumber = reader.GetString(0);
                    bool noDetail = ModelEx.InvtBatchTXF_DetailsEx.CountByTxNumber(txNumber) > 0;

                    string sql = @"
SELECT S.TxNumber, S.STKCODE, S.APPENDIX1, S.APPENDIX2, S.APPENDIX3, S.BARCODE, STK.ProductName, SUM(S.Qty) AS Qty
FROM [TxferAdvanceImportSummary] S LEFT JOIN Product STK ON S.STKCODE = STK.STKCODE 
									AND S.APPENDIX1 = STK.APPENDIX1 
									AND S.APPENDIX2 = STK.APPENDIX2 
									AND S.APPENDIX3 = STK.APPENDIX3 
WHERE S.TxNumber = '" + reader.GetString(0) + @"' AND S.{0} = 'Y'
GROUP BY S.TxNumber, S.STKCODE, S.APPENDIX1, S.APPENDIX2, S.APPENDIX3, S.BARCODE, STK.ProductName 
ORDER BY S.TxNumber, S.STKCODE, S.APPENDIX1, S.APPENDIX2, S.APPENDIX3, S.BARCODE, STK.ProductName";

                    tpBarcode_MatchedItems.Controls.Clear();
                    tpBarcode_MatchedItems.Controls.Add(new AdvanceImport_ListView(string.Format(sql, "[MatchedBarcode]"), notInMatch));

                    tpBarcode_UnMatchedItems.Controls.Clear();
                    tpBarcode_UnMatchedItems.Controls.Add(new AdvanceImport_ListView(string.Format(sql, "[UnMatchedBarcode]"), notInMatch));

                    tpRequired_MatchedItems.Controls.Clear();
                    tpRequired_MatchedItems.Controls.Add(new AdvanceImport_ListView(string.Format(sql, "[MatchedRequired]"), notInMatch));

                    tpRequired_UnMatchedItems.Controls.Clear();
                    tpRequired_UnMatchedItems.Controls.Add(new AdvanceImport_ListView(string.Format(sql, "[UnMatchedRequired]"), notInMatch));
                }
            }
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFileStructure_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            message.Append("ASCII File").AppendLine();
            message.Append("==========================").AppendLine();
            message.Append("LOC#    (Text, 4)").AppendLine();
            message.Append("HHT#    (Text, 19)").AppendLine();
            message.Append("TRN#    (Text, 12)").AppendLine();
            message.Append("Barcode (Text, 22)").AppendLine();
            message.Append("Quantity (Text, 10)").AppendLine();
            message.Append("Keyboard (Y/N)").AppendLine();
            message.Append("Entry at (ddMMyyyyHHmmss)").AppendLine();

            MessageBox.Show(message.ToString(), "Attention");
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text.Trim();
            string errMsg = string.Empty;

            if (fileName.Length > 0)
            {
                if (Path.GetExtension(fileName).ToLower() == ".txt")
                {
                    if (File.Exists(fileName))
                    {
                        FileHelperEngine<AdvanceTxferImport> engine = new FileHelperEngine<AdvanceTxferImport>();

                        engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

                        AdvanceTxferImport[] res = engine.ReadFile(fileName, 25000); // Ignore the lines after 25000

                        if (engine.ErrorManager.ErrorCount > 0)
                        {
                            string errFile = Path.Combine(Application.ExecutablePath, "Errors(Txfer).txt");

                            if (File.Exists(errFile))
                            {
                                File.Delete(errFile);
                            }

                            engine.ErrorManager.SaveErrors(errFile);

                            using (StreamReader sr = File.OpenText(errFile))
                            {
                                errMsg = sr.ReadToEnd();
                            }
                        }
                        else
                        {
                            if (res.Length > 0)
                            {
                                string sql = "DELETE FROM TxferAdvanceImportSummary;";
                                if (!chkAccumulate.Checked)
                                {
                                    sql += "DELETE FROM TxferAdvanceImport";
                                }

                                SqlCommand initCmd = new SqlCommand();
                                initCmd.CommandText = sql;
                                initCmd.CommandTimeout = ConfigHelper.CommandTimeout;
                                initCmd.CommandType = CommandType.Text;

                                SqlHelper.Default.ExecuteNonQuery(initCmd);

                                for (int i = 0; i < res.Length; i++)
                                {
                                    string stk = string.Empty, a1 = string.Empty, a2 = string.Empty, a3 = string.Empty;
                                    AdvanceTxferImport importedData = res[i];

                                    string query = @"INSERT INTO TxferAdvanceImport([LocNo], [HHTID], [TxNumber], [Barcode], [Qty], [Keyboard], [EntryDate]) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";

                                    query = string.Format(query,
                                        importedData.LocNo,
                                        importedData.HHTNo,
                                        importedData.TxNumber,
                                        importedData.Barcode,
                                        importedData.Quantity,
                                        importedData.Keyboard,
                                        importedData.EntryDate);

                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandText = query;
                                    cmd.CommandTimeout = ConfigHelper.CommandTimeout;
                                    cmd.CommandType = CommandType.Text;

                                    SqlHelper.Default.ExecuteNonQuery(cmd);
                                }

                                this.SummarizeData();
                                this.LoadData();
                            }
                            else
                            {
                                errMsg = "File (" + fileName + ") is empty.";
                            }
                        }
                    }
                    else
                    {
                        errMsg = "File (" + fileName + ") Not Found";
                    }
                }
                else
                {
                    errMsg = "Invalid file name, please try a text file (.txt).";
                }
            }
            else
            {
                errMsg = "Please select a file to import";
            }

            if (errMsg.Length > 0)
            {
                MessageBox.Show(errMsg, "Attention");
            }
        }

        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Browser transfer file(.txt)";
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            string fileName = Utility.UploadFile(openFileDialog, mstrDirectory);

            txtFileName.Text = Path.Combine(mstrDirectory, fileName);
        }
    }
}