#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

using ClosedXML.Excel;

using FileHelpers.DataLink;
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.GoodsReceive.Import
{
    public partial class ImportXls : Form
    {
        XlsImportTemplate[] _ImportList = null;
        String _MstrDirectory = string.Empty;

        public ImportXls()
        {
            InitializeComponent();
            _MstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "Invt_CAP");
            FillCboList();
            SetSystemLabel();
            updateCurrency(cboCurrency.Text);
        }

        private void SetSystemLabel()
        {
            colStockCode.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE");
            colAppendix1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3");
            colClass1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS1");
            colClass2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS2");
            colClass3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS3");
            colClass4.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS4");
            colClass5.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS5");
            colClass6.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS6");
            colRemark1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK1");
            colRemark2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK2");
            colRemark3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK3");
            colRemark4.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK4");
            colRemark5.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK5");
            colRemark6.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK6");
            colCostBase.Text = string.Format(RT2020.Controls.Utility.Dictionary.GetWord("unit_amount_with_currency"), SystemInfoEx.CurrentInfo.Default.SysInfo.BasicCurrency);
        }

        private void updateCurrency(string currencyCode)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oCny = ctx.Currency.Where(x => x.CurrencyCode == currencyCode).FirstOrDefault();
                if (oCny != null)
                {
                    updateCurrency(oCny.CurrencyId);
                }
                else
                {
                    Guid id = Guid.Empty;
                    Guid.TryParse(cboCurrency.SelectedValue.ToString(), out id);
                    updateCurrency(id);
                }
            }
        }

        private void updateCurrency(Guid selectedCurrency)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oCny = ctx.Currency.Find(selectedCurrency);
                if (oCny != null)
                {
                    colCost.Text = string.Format(RT2020.Controls.Utility.Dictionary.GetWord("unit_amount_with_currency"), oCny.CurrencyCode);
                    txtExchangeRate.Text = oCny.ExchangeRate.Value.ToString("n4");
                    if (lvDetailsList.Items.Count > 0)
                    {
                        foreach (ListViewItem lvDetail in lvDetailsList.Items)
                        {
                            lvDetail.SubItems[7].Text = (Convert.ToDecimal(lvDetail.SubItems[6].Text) * Convert.ToDecimal(txtExchangeRate.Text.Length == 0 ? "1" : txtExchangeRate.Text)).ToString("n2");
                        }
                    }
                }
            }
        }

        #region Fill Combo List
        private void FillCboList()
        {
            FillLocationList();
            FillStaffList();
            FillSupplierList();
            FillCurrencyList();
        }

        private void FillLocationList()
        {
            WorkplaceEx.LoadCombo(ref cboWorkplace, "WorkplaceCode", false);
        }

        private void FillStaffList()
        {
            StaffEx.LoadCombo(ref cboOperator, "StaffNumber", false);
        }

        private void FillSupplierList()
        {
            SupplierEx.LoadCombo(ref cboSupplier, "SupplierCode", false);
        }

        private void FillCurrencyList()
        {
            cboCurrency.Items.Clear();

            CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false);

            if (cboCurrency.Items.Count > 0)
            {
                cboCurrency.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.BasicCurrency;

                updateCurrency(cboCurrency.Text);
            }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowserPhotoFile_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
        }

        private void folderBrowserDialog_Closed(object sender, EventArgs e)
        {
            //FolderBrowserDialog objFolderDialog = sender as FolderBrowserDialog;
            //txtPhotoPath.Text = objFolderDialog.SelectedPath;
        }

        private void btnBrowseExcelFile_Click(object sender, EventArgs e)
        {
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.Title = "Choose the file to import";
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "Excel files(xlsx)|*.xlsx|All files|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.DefaultExt = "*.xlsx";
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            String fileName = RT2020.Controls.Utility.UploadFile(openFileDialog, _MstrDirectory);
            txtFileSource.Text = fileName;
            newExcelFileSelected(fileName);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            #region Excel File Structure Info
            // --------------------------------------------------
            // Task:
            // 1. [Optional] Import CAP Worksheet
            // 2. [Optional] Import Stock Code
            // => Overwrite, Insert New or Both
            // 3. [Optional] Auto-Create Record for not existed Class/Appendix
            // --------------------------------------------------
            StringBuilder msg = new StringBuilder();
            msg.Append("Process Detail : ").Append("\n\r").Append("\n\r");
            msg.Append("1. [Optional] Import CAP Worksheet").Append("\n\r");
            msg.Append("2. [Optional] Import Stock Code").Append("\n\r");
            msg.Append("=> Overwrite, Insert New or Both").Append("\n\r");
            msg.Append("3. [Optional] Auto-Create Record for not existed Class/Appendix").Append("\n\r").Append("\n\r");

            // --------------------------------------------------
            // Column Definition (Excel)
            // --------------------------------------------------
            msg.Append("\n\r").Append("\n\r");
            msg.Append("Column Definition (Excel) : ").Append("\n\r");
            msg.Append("** Row#1 is the Header **").Append("\n\r");
            msg.Append("** Worksheet Name [CAP] **").Append("\n\r").Append("\n\r");

            msg.Append("      A    : STOCKCODE          - 10 digits").Append("\n\r");
            msg.Append("      B    : APPENDIX1          -  4 digits").Append("\n\r");
            msg.Append("      C    : APPENDIX2          -  4 digits").Append("\n\r");
            msg.Append("      D    : APPENDIX3          -  4 digits").Append("\n\r");
            msg.Append("      E    : CURRENCY           -  3 digits").Append("\n\r");
            msg.Append("      F    : COST               - 12 digits").Append("\n\r");
            msg.Append("      G    : QTY                - 12 digits").Append("\n\r");
            msg.Append("      H    : CLASS1             -  6 digits").Append("\n\r");
            msg.Append("      I    : CLASS2             -  6 digits").Append("\n\r");
            msg.Append("      J    : CLASS3             -  6 digits").Append("\n\r");
            msg.Append("      K    : CLASS4             -  6 digits").Append("\n\r");
            msg.Append("      L    : CLASS5             -  6 digits").Append("\n\r");
            msg.Append("      M    : CLASS6             -  6 digits").Append("\n\r");
            msg.Append("      N    : PRODUCT_NAME       - 50 digits").Append("\n\r");
            msg.Append("      O    : REMARKS            - 30 digits").Append("\n\r");
            msg.Append("      P    : REMARK1            - 10 digits").Append("\n\r");
            msg.Append("      Q    : REMARK2            - 10 digits").Append("\n\r");
            msg.Append("      R    : REMARK3            - 10 digits").Append("\n\r");
            msg.Append("      S    : REMARK4            - 10 digits").Append("\n\r");
            msg.Append("      T    : REMARK5            - 10 digits").Append("\n\r");
            msg.Append("      U    : REMARK6            - 10 digits").Append("\n\r");
            msg.Append("      V    : RETAIL_PRICE       - 12 digits").Append("\n\r");
            msg.Append("      W    : RETAIL_DISCOUNT    -  8 digits").Append("\n\r");
            msg.Append("      X    : DISC FOR DISC ITEM -  8 digits").Append("\n\r");
            #endregion

            MessageBox.Show(msg.ToString(), "File Structure Info");
        }

        private void btnGenerateTemplate_Click(object sender, EventArgs e)
        {
            String filePath = System.Web.HttpContext.Current.Server.MapPath("~/Resources/Templates/CAP Import Template.xlsx");
            var dl = new FileDownloadGateway();
            dl.FileName = "CAP Import Template.XLS";
            dl.SetContentType(DownloadContentType.MicrosoftExcel);
            dl.StartFileDownload(this, filePath);
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid id = Guid.Empty;
            if (Guid.TryParse(cboCurrency.SelectedValue.ToString(), out id))
            {
                txtExchangeRate.Text = CurrencyEx.GetExchangeRateById(id).ToString("n4");
                updateCurrency(new System.Guid(cboCurrency.SelectedValue.ToString()));
            }
        }

        private void newExcelFileSelected (string excelFile)
        {
            //ExcelStorage provider = new ExcelStorage(typeof(XlsImportTemplate));

            //provider.StartRow = 2;
            //provider.StartColumn = 1;

            //provider.FileName = Path.Combine(_MstrDirectory, excelFile);

            //_ImportList = (XlsImportTemplate[])provider.ExtractRecords();
            ReadXlsx(Path.Combine(_MstrDirectory, excelFile));
            DialogResult dialogResult = MessageBox.Show(
                string.Format("Total line{0} read: {1}\n\nCorrect and continue?", _ImportList.Length > 1 ? "s" : "", _ImportList.Length.ToString()),
                "Excel file read",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                new EventHandler(ExcelFileReadMessageHandler)
            );
        }

        private void ReadXlsx(String ExcelFilePath)
        {
            List<XlsImportTemplate> items = new List<XlsImportTemplate>();

            var wb = new XLWorkbook(ExcelFilePath);
            var ws = wb.Worksheets.First();                         //這裡的 First 如果出現 error，是因為欠 using System.Link;

            var firstRowUsed = ws.FirstRowUsed();                   //找出第一行有料的行數
            var row = firstRowUsed.RowBelow();                      //起用第二行（假設第一行係 column header）
            while (!row.Cell("A").IsEmpty())                        //如果 column A 不是空白的就做嘢
            {
                #region 讀入資料，可用 column index 或 column title
                String STOCKCODE = row.Cell(1).GetString();
                String APPENDIX1 = row.Cell("B").GetString();
                String APPENDIX2 = row.Cell("C").GetString();
                String APPENDIX3 = row.Cell("D").GetString();
                String CLASS1 = row.Cell("N").GetString();
                String CLASS2 = row.Cell("O").GetString();
                String CLASS3 = row.Cell("P").GetString();
                String CLASS4 = row.Cell("Q").GetString();
                String CLASS5 = row.Cell("R").GetString();
                String CLASS6 = row.Cell("S").GetString();
                String REMARK1 = row.Cell(5).GetString();
                String REMARK2 = row.Cell(6).GetString();
                String REMARK3 = row.Cell(7).GetString();
                String REMARK4 = row.Cell(8).GetString();
                String REMARK5 = row.Cell(9).GetString();
                String REMARK6 = row.Cell(10).GetString();
                String PCS = row.Cell(11).GetString();
                String DESCRIPTION = row.Cell("L").GetString();
                String REMARKS = row.Cell("M").GetString();
                Double RETAIL_PRICE = row.Cell("V").IsEmpty() ? 0 : row.Cell("V").GetDouble();
                Double RETAIL_DISCOUNT = row.Cell("W").IsEmpty() ? 0 : row.Cell("W").GetDouble();
                Double DISCOUNT_FOR_DISCOUNT_ITEM = row.Cell("X").IsEmpty() ? 0 : row.Cell("X").GetDouble();
                #endregion

                if (!String.IsNullOrEmpty(STOCKCODE))
                {
                    XlsImportTemplate item = new XlsImportTemplate();
                    #region 轉為 List item
                    item.STOCKCODE = STOCKCODE;
                    item.APPENDIX1 = APPENDIX1;
                    item.APPENDIX2 = APPENDIX2;
                    item.APPENDIX3 = APPENDIX3;
                    item.REMARK1 = REMARK1;
                    item.REMARK2 = REMARK2;
                    item.REMARK3 = REMARK3;
                    item.REMARK4 = REMARK4;
                    item.REMARK5 = REMARK5;
                    item.REMARK6 = REMARK6;
                    item.QTY = String.IsNullOrEmpty(PCS) ? 0 : Convert.ToInt16(PCS);
                    item.PRODUCT_NAME = DESCRIPTION;
                    item.REMARKS = REMARKS;
                    item.CLASS1 = CLASS1;
                    item.CLASS2 = CLASS2;
                    item.CLASS3 = CLASS3;
                    item.CLASS4 = CLASS4;
                    item.CLASS5 = CLASS5;
                    item.CLASS6 = CLASS6;
                    item.RETAIL_PRICE = RETAIL_PRICE;
                    item.RETAIL_DISCOUNT = RETAIL_DISCOUNT;
                    item.DISCOUNT_FOR_DISCOUNT_ITEM = DISCOUNT_FOR_DISCOUNT_ITEM;
                    #endregion
                    items.Add(item);
                }

                row = row.RowBelow();                               //下一行
            }

            // 先排序，再放入 ListView 的 cache
            var sorted = items.OrderBy(item => item.STOCKCODE).OrderBy(item => item.APPENDIX1).OrderBy(item => item.APPENDIX2).OrderBy(item => item.APPENDIX3);
            this._ImportList = sorted.ToArray();
        }

        private void ExcelFileReadMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                LoadIntoDetailList(_ImportList);
            }
        }

        private void LoadIntoDetailList(XlsImportTemplate[] res)
        {
            int iCount = 0;
            Guid productId = System.Guid.Empty;

            lvDetailsList.Items.Clear();
            btnImport.Enabled = false;

            if (res.Length > 0)
            {
                foreach (XlsImportTemplate row in res)
                {
                    iCount++;
                    if (row.STOCKCODE == null) row.STOCKCODE = System.String.Empty;
                    if (row.APPENDIX1 == null) row.APPENDIX1 = System.String.Empty;
                    if (row.APPENDIX2 == null) row.APPENDIX2 = System.String.Empty;
                    if (row.APPENDIX3 == null) row.APPENDIX3 = System.String.Empty;
                    if (row.CLASS1 == null) row.CLASS1 = System.String.Empty;
                    if (row.CLASS2 == null) row.CLASS2 = System.String.Empty;
                    if (row.CLASS3 == null) row.CLASS3 = System.String.Empty;
                    if (row.CLASS4 == null) row.CLASS4 = System.String.Empty;
                    if (row.CLASS5 == null) row.CLASS5 = System.String.Empty;
                    if (row.CLASS6 == null) row.CLASS6 = System.String.Empty;
                    if (row.PRODUCT_NAME == null) row.PRODUCT_NAME = System.String.Empty;
                    if (row.REMARKS == null) row.REMARKS = System.String.Empty;
                    if (row.REMARK1 == null) row.REMARK1 = System.String.Empty;
                    if (row.REMARK2 == null) row.REMARK2 = System.String.Empty;
                    if (row.REMARK3 == null) row.REMARK3 = System.String.Empty;
                    if (row.REMARK4 == null) row.REMARK4 = System.String.Empty;
                    if (row.REMARK5 == null) row.REMARK5 = System.String.Empty;
                    if (row.REMARK6 == null) row.REMARK6 = System.String.Empty;
                    if (row.REMARK1 == null) row.REMARK1 = System.String.Empty;

                    ListViewItem listItem = lvDetailsList.Items.Add(iCount.ToString()); // LN
                    listItem.SubItems.Add(string.Empty); // Status
                    listItem.SubItems.Add(row.STOCKCODE); // STKCode
                    listItem.SubItems.Add(row.APPENDIX1); // Appendix1
                    listItem.SubItems.Add(row.APPENDIX2); // Appendix2
                    listItem.SubItems.Add(row.APPENDIX3); // Appendix3

                    // Check STKCode already exsist
                    String sql = String.Format("STKCODE = '{0}'", row.STOCKCODE);
                    var oProduct = ProductEx.Get(sql);
                    if (oProduct == null)
                    {
                        lvDetailsList.Items[iCount - 1].Tag = "P"; // New Product
                    }
                    else
                    {
                        sql = String.Format("STKCODE = '{0}' AND APPENDIX1 = '{1}' AND APPENDIX2 = '{2}' AND APPENDIX3 = '{3}'",
                            row.STOCKCODE,
                            row.APPENDIX1,
                            row.APPENDIX2,
                            row.APPENDIX3);
                        oProduct = ProductEx.Get(sql);
                        if (oProduct == null)
                        {
                            lvDetailsList.Items[iCount - 1].Tag = "A"; // New Appendix/Class
                        }
                        else
                        {
                            productId = oProduct.ProductId;
                        }
                    }

                    listItem.SubItems.Add(row.COST.ToString("n2")); // Cost
                    if (row.COST == 0)
                    {
                        lvDetailsList.Items[iCount - 1].Tag += "C"; // No Cost
                        listItem.SubItems.Add("0.00"); // CostLocal
                    }
                    else
                    {
                        listItem.SubItems.Add((Convert.ToDecimal(row.COST) * Convert.ToDecimal(txtExchangeRate.Text.Length == 0 ? "1" : txtExchangeRate.Text)).ToString("n2")); // CostLocal
                    }

                    listItem.SubItems.Add(row.QTY.ToString("n0")); // Qty
                    if (row.QTY == 0)
                    {
                        lvDetailsList.Items[iCount - 1].Tag += "Q"; // No Qty
                    }
                    listItem.SubItems.Add(row.CLASS1); // Class1
                    listItem.SubItems.Add(row.CLASS2); // Class2
                    listItem.SubItems.Add(row.CLASS3); // Class3
                    listItem.SubItems.Add(row.CLASS4); // Class4
                    listItem.SubItems.Add(row.CLASS5); // Class5
                    listItem.SubItems.Add(row.CLASS6); // Class6
                    listItem.SubItems.Add(row.PRODUCT_NAME); // ProductName
                    listItem.SubItems.Add(row.REMARKS); // Remarks
                    listItem.SubItems.Add(row.REMARK1); // Remark1
                    listItem.SubItems.Add(row.REMARK2); // Remark2
                    listItem.SubItems.Add(row.REMARK3); // Remark3
                    listItem.SubItems.Add(row.REMARK4); // Remark4
                    listItem.SubItems.Add(row.REMARK5); // Remark5
                    listItem.SubItems.Add(row.REMARK6); // Remark6
                    listItem.SubItems.Add(row.RETAIL_PRICE.ToString()); // Retail Price
                    if (row.RETAIL_PRICE == 0 && chkImportStockCode.Checked)
                    {
                        lvDetailsList.Items[iCount - 1].Tag += "R"; // No Retail Price
                    }
                    listItem.SubItems.Add(row.RETAIL_DISCOUNT.ToString()); // Retail Discount
                    listItem.SubItems.Add(row.DISCOUNT_FOR_DISCOUNT_ITEM.ToString()); // Discount for Discount Item
                    listItem.SubItems.Add(productId.ToString()); // ProductId
                }

                if (updatelvDetailStatus() <= 1)// 0 = no error, 1 = has alert, 2 = has error
                {
                    btnImport.Enabled = true;
                }
            }
        }

        // Update lvDetailsList status column [1]
        // Return 0 = no error nor alert
        // Return 1 = has alert
        // Reutrn 2 = has error
        private int updatelvDetailStatus()
        {
            int result = 0;
            string tag = string.Empty;
            if (lvDetailsList.Items.Count > 0)
            {
                foreach (ListViewItem lvDetail in lvDetailsList.Items)
                {
                    tag = lvDetail.Tag.ToString();
                    if (tag.Contains("P"))
                    {
                        if (chkInsertNewRecord.Checked)
                        {
                            lvDetail.SubItems[1].Text = new IconResourceHandle("16x16.16_alert.gif").ToString(); // Status
                            if (result <= 1) result = 1;
                        }
                        else
                        {
                            lvDetail.SubItems[1].Text = new IconResourceHandle("16x16.16_error.gif").ToString(); // Status
                            result = 2;
                        }
                    }
                    else if (tag.Contains("A"))
                    {
                        if (chkAutoCreateRecord.Checked)
                        {
                            lvDetail.SubItems[1].Text = new IconResourceHandle("16x16.16_alert.gif").ToString(); // Status
                            if (result <= 1) result = 1;
                        }
                        else
                        {
                            lvDetail.SubItems[1].Text = new IconResourceHandle("16x16.16_error.gif").ToString(); // Status
                            result = 2;
                        }
                    }
                    else if (tag.Contains("C"))
                    {
                        lvDetail.SubItems[1].Text = new IconResourceHandle("16x16.16_alert.gif").ToString(); // Status
                        if (result <= 1) result = 1;
                    }
                    else if (tag.Contains("Q"))
                    {
                        lvDetail.SubItems[1].Text = new IconResourceHandle("16x16.16_alert.gif").ToString(); // Status
                        if (result <= 1) result = 1;
                    }
                    else if (tag.Contains("R"))
                    {
                        if (chkOverWriteExistingCode.Checked || chkInsertNewRecord.Checked || chkAutoCreateRecord.Checked)
                        {
                            lvDetail.SubItems[1].Text = new IconResourceHandle("16x16.16_alert.gif").ToString(); // Status
                            if (result <= 1) result = 1;
                        }
                    }
                }
            }
            return result;
        }

        private void chkImportStockCode_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            chkOverWriteExistingCode.Enabled = chkOverWriteExistingCode.Checked = chkImportStockCode.Checked;
            chkInsertNewRecord.Enabled = chkInsertNewRecord.Checked = chkImportStockCode.Checked;
            chkAutoCreateRecord.Enabled = chkAutoCreateRecord.Checked = chkImportStockCode.Checked;

            if (updatelvDetailStatus() <= 1)// 0 = no error, 1 = has alert, 2 = has error
            {
                btnImport.Enabled = true;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void lvDetailsList_DoubleClick(object sender, EventArgs e)
        {
            string tag = lvDetailsList.SelectedItem.Tag.ToString();
            string status = lvDetailsList.SelectedItem.SubItems[1].ToString();
            if (tag != string.Empty)
            {
                string message = String.Empty;
                if (tag.Contains("P"))
                {
                    message += "New Product.\n";
                }
                if (tag.Contains("A"))
                {
                    message += "New Appendix / Class.\n";
                }
                if (tag.Contains("C"))
                {
                    message += "No Cost.\n";
                }
                if (tag.Contains("Q"))
                {
                    message += "No Qty.\n";
                }
                if (tag.Contains("R") && (chkOverWriteExistingCode.Checked || chkInsertNewRecord.Checked || chkAutoCreateRecord.Checked))
                {
                    message += "No Retail Price.\n";
                }

                MessageBox.Show(message, "Info", MessageBoxButtons.OK, status.Contains("alert")? MessageBoxIcon.Exclamation : MessageBoxIcon.Error);
            }
        }
    }
}