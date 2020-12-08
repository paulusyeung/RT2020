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
using System.IO;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web;
using Gizmox.WebGUI.Common.Gateways;
using RT2020.Controls;
using System.Collections;
using System.Linq;

#endregion

namespace RT2020.Product.Import
{
    public partial class ProductCodeImport : Form
    {
        #region Constants

        private const int iMaxRecord = 20000; //Maximum Load 20,000 records

        // Columns' Header Text
        private const string colClass1 = "CLASS1"; //Class1
        private const string colClass2 = "CLASS2"; //Class2
        private const string colClass3 = "CLASS3"; //Class3
        private const string colClass4 = "CLASS4"; //Class4
        private const string colClass5 = "CLASS5"; //Class5
        private const string colClass6 = "CLASS6"; //Class6
        private const string colDESC = "DESC"; //Description
        private const string colSTKCode = "STKCODE"; //Stock Code
        private const string colAppendix1 = "APPENDIX1"; //Appendix1
        private const string colAppendix2 = "APPENDIX2"; //Appendix2
        private const string colAppendix3 = "APPENDIX3"; //Appendix3
        private const string colBasicPrice = "BASPRC"; //Basic Price
        private const string colVendorCurrency = "VCURR"; //Vendor Currency
        private const string colVendorPrice = "VPRC"; //Vendor Price
        private const string colMEMO = "STK_MEMO"; //Stock MEMO
        private const string colPHOTO = "PHOTO"; //Photo

        // Field Size
        private const int iLenC1 = 6; //Class1
        private const int iLenC2 = 6; //Class2
        private const int iLenC3 = 6; //Class3
        private const int iLenC4 = 6; //Class4
        private const int iLenC5 = 6; //Class5
        private const int iLenC6 = 6; //Class6
        private const int iLenDESC = 50; //Description
        private const int iLenSTK = 10; //Stock Code
        private const int iLenA1 = 4; //Appendix1
        private const int iLenA2 = 4; //Appendix2
        private const int iLenA3 = 4; //Appendix3
        private const int iLenBP = 12; //Basic Price
        private const int iLenVCURR = 3; //Vendor Currency
        private const int iLenVPRC = 12; //Vendor Price
        private const int iLenPHOTO = 100; //Photo Path

        #endregion

        #region Variables

        string mstrDirectory = string.Empty;
        ArrayList emptyRecordList = new ArrayList(); // Store Empty row number
        ArrayList incorrectField = new ArrayList(); // Store the column in incorrect format 
        ArrayList duplicatedRec = new ArrayList(); // Store the column has duplicated record

        #endregion

        public ProductCodeImport()
        {
            InitializeComponent();
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "Prodcut");
        }

        private void ProductCodeImport_Load(object sender, EventArgs e)
        {
            BindStockCodeList();
        }

        #region Button Events
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtUploadedFileName.Text = Utility.UploadFile(openFileDialog, mstrDirectory);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUploadedFileName.Text))
            {
                //DateTime now = DateTime.Now;

                BindStockCodeList();

                //DateTime after = DateTime.Now;

                //TimeSpan elapse = after - now;
                //MessageBox.Show(elapse.ToString());

                // Incorrect field format
                if (incorrectField.Count > 0)
                {
                    btnExcelTemplate.Enabled = false;
                }
                else
                {
                    btnExcelTemplate.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please select an excel file to preview!");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dgvTempStockCodeList.RowCount > 0)
            {
                ImportData();
            }
            else
            {
                MessageBox.Show("You must preview the data before import!");
            }
        }

        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {
            Import.ProductCodeImportTemplate templateForm = new RT2020.Product.Import.ProductCodeImportTemplate();
            templateForm.ShowDialog();
        }
        #endregion

        #region Bind Template Stock Code List
        private void BindStockCodeList()
        {
            dgvTempStockCodeList.DataSource = GetStockList();
        }

        private DataTable GetData()
        {
            DataTable oTable = new DataTable();
            if (!string.IsNullOrEmpty(txtUploadedFileName.Text))
            {
                string filePath = Path.Combine(mstrDirectory, txtUploadedFileName.Text);
                string[] sheetNames = XlsImport.GetExcelSheetNames(filePath);

                if (sheetNames != null && sheetNames.Length > 0)
                {
                    // Get data in the first sheet
                    oTable = XlsImport.BindData(filePath, sheetNames[0]);
                }
            }
            return oTable;
        }

        private StockCodeList GetStockList()
        {
            StockCodeList oList = new StockCodeList();

            DataTable oTable = GetData();
            if (oTable.Rows.Count > 0)
            {                
                for (int iCount = 0; iCount < oTable.Rows.Count; iCount ++)
                {
                    DataRow row = oTable.Rows[iCount];
                    int rowNum = iCount + 1;
                    if (!VerifyEmptyData(rowNum, row))
                    {
                        string status = VerifyDataFieldSize(rowNum, row);
                        //status += VerifyDuplicatedData(rowNum, row);
                        AddStockCodeToList(rowNum, status, row, ref oList);
                    }
                }
            }

            return oList;
        }

        private void AddStockCodeToList(int iCount, string status, DataRow row, ref StockCodeList oList)
        {
            oList.Add(new StockCodeRec(
                iCount,
                status,
                Utility.VerifyQuotes(row[colClass1].ToString()),
                Utility.VerifyQuotes(row[colClass2].ToString()),
                Utility.VerifyQuotes(row[colClass3].ToString()),
                Utility.VerifyQuotes(row[colClass4].ToString()),
                Utility.VerifyQuotes(row[colClass5].ToString()),
                Utility.VerifyQuotes(row[colClass6].ToString()),
                row[colDESC].ToString(),
                Utility.VerifyQuotes(row[colSTKCode].ToString()),
                Utility.VerifyQuotes(row[colAppendix1].ToString()),
                Utility.VerifyQuotes(row[colAppendix2].ToString()),
                Utility.VerifyQuotes(row[colAppendix3].ToString()),
                row[colBasicPrice].ToString(),
                row[colVendorCurrency].ToString(),
                row[colVendorPrice].ToString(),
                row[colMEMO].ToString(),
                row[colPHOTO].ToString()));
        }

        // Check the data in row (CLASS1..6, STK_CODE, APPENDIX1..3) is empty or not
        private bool VerifyEmptyData(int iCount, DataRow row)
        {
            bool emptyRow = true;

            emptyRow = emptyRow && string.IsNullOrEmpty(row[colClass1].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colClass2].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colClass3].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colClass4].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colClass5].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colClass6].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colSTKCode].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colAppendix1].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colAppendix2].ToString());
            emptyRow = emptyRow && string.IsNullOrEmpty(row[colAppendix3].ToString());

            if (emptyRow)
            {
                // Store the empty row number of excel data 
                emptyRecordList.Add(iCount + 1);
            }

            return emptyRow;
        }

        // Verify the data size is correct or not
        private string VerifyDataFieldSize(int iCount, DataRow row)
        {
            iCount = iCount + 1; // get the original row number of excel data
            StringBuilder result = new StringBuilder();
            result.Append("Row#").Append(iCount.ToString()).Append(":");

            int iLen = result.ToString().Length;

            if (row[colClass1].ToString().Length.CompareTo(iLenC1) == 1)
            {
                result.Append(colClass1).Append(";");
            }

            if (row[colClass2].ToString().Length.CompareTo(iLenC2) == 1)
            {
                result.Append(colClass2).Append(";");
            }

            if (row[colClass3].ToString().Length.CompareTo(iLenC3) == 1)
            {
                result.Append(colClass3).Append(";");
            }

            if (row[colClass4].ToString().Length.CompareTo(iLenC4) == 1)
            {
                result.Append(colClass4).Append(";");
            }

            if (row[colClass5].ToString().Length.CompareTo(iLenC5) == 1)
            {
                result.Append(colClass5).Append(";");
            }

            if (row[colClass6].ToString().Length.CompareTo(iLenC6) == 1)
            {
                result.Append(colClass6).Append(";");
            }

            if (row[colDESC].ToString().Length.CompareTo(iLenDESC) == 1)
            {
                result.Append(colDESC).Append(";");
            }

            if (row[colSTKCode].ToString().Length.CompareTo(iLenSTK) == 1)
            {
                result.Append(colSTKCode).Append(";");
            }

            if (row[colAppendix1].ToString().Length.CompareTo(iLenA1) == 1)
            {
                result.Append(colAppendix1).Append(";");
            }

            if (row[colAppendix2].ToString().Length.CompareTo(iLenA2) == 1)
            {
                result.Append(colAppendix2).Append(";");
            }

            if (row[colAppendix3].ToString().Length.CompareTo(iLenA3) == 1)
            {
                result.Append(colAppendix3).Append(";");
            }

            if (row[colBasicPrice].ToString().Length.CompareTo(iLenBP) == 1)
            {
                result.Append(colBasicPrice).Append(";");
            }

            if (row[colVendorCurrency].ToString().Length.CompareTo(iLenVCURR) == 1)
            {
                result.Append(colVendorCurrency).Append(";");
            }

            if (row[colVendorPrice].ToString().Length.CompareTo(iLenVPRC) == 1)
            {
                result.Append(colVendorPrice).Append(";");
            }

            if (row[colPHOTO].ToString().Length.CompareTo(iLenPHOTO) == 1)
            {
                result.Append(colPHOTO).Append(";");
            }

            if (iLen == result.ToString().Length)
            {
                return string.Empty;
            }
            else
            {
                incorrectField.Add(result.ToString());
                return "ERROR";
            }
        }

        // Verify Vendor Currency and Price exist or not.
        // If verify failed, can not post the import.
        private void VerifyVendorCurrencyPrice(int iCount, DataRow row)
        {
            if (!string.IsNullOrEmpty(row[colVendorCurrency].ToString()))
            {
                //string sql = "CurrencyCode = '" + row[colVendorCurrency].ToString() + "'";
                //Currency oCurr = Currency.LoadWhere(sql);
                //if (oCurr != null)
                if (ModelEx.CurrencyEx.IsCurrencyCodeInUse(row[colVendorCurrency].ToString()))
                {
                    // TODO:Set the cell style of DataGridView
                }
            }
            else // Without Vendor Currency, Vendor Price should be ZERO
            {
                // TODO:Set the cell style of DataGridView
            }
        }

        // Verify the data from excel file exists or not
        private string VerifyDuplicatedData(int iCount, DataRow row)
        {
            iCount = iCount + 1;
            StringBuilder returnResult = new StringBuilder();
            StringBuilder verifiedResult = new StringBuilder();
            verifiedResult.Append("Row#").Append(iCount.ToString()).Append(":");

            int iLen = verifiedResult.ToString().Length;

            // Check whether the StockCode is duplicate or not
            string sql = @"STKCODE = '" + Utility.VerifyQuotes(row[colSTKCode].ToString().Trim()) + "' AND APPENDIX1 = '" + Utility.VerifyQuotes(row[colAppendix1].ToString().Trim())
                + "' AND APPENDIX2 = '" + Utility.VerifyQuotes(row[colAppendix2].ToString().Trim()) + "' AND APPENDIX3 = '" + Utility.VerifyQuotes(row[colAppendix3].ToString().Trim()) + "'";

            RT2020.DAL.Product oStockItem = RT2020.DAL.Product.LoadWhere(sql);
            if (oStockItem != null)
            {
                returnResult.Append("Duplicated Stock Code;");
            }

            // Appendix1
            sql = "Appendix1Code = '" + Utility.VerifyQuotes(row[colAppendix1].ToString().Trim()) + "'";
            ProductAppendix1 oApp1 = ProductAppendix1.LoadWhere(sql);
            if (oApp1 != null)
            {
                verifiedResult.Append(colAppendix1).Append(";");
            }

            // Appendix2
            sql = "Appednix2Code = '" + Utility.VerifyQuotes(row[colAppendix2].ToString().Trim()) + "'";
            ProductAppendix2 oApp2 = ProductAppendix2.LoadWhere(sql);
            if (oApp2 != null)
            {
                verifiedResult.Append(colAppendix2).Append(";");
            }

            // Appendix3
            sql = "Appendix3Code = '" + Utility.VerifyQuotes(row[colAppendix3].ToString().Trim()) + "'";
            ProductAppendix3 oApp3 = ProductAppendix3.LoadWhere(sql);
            if (oApp3 != null)
            {
                verifiedResult.Append(colAppendix3).Append(";");
            }

            // Class1
            //sql = "Class1Code = '" + Utility.VerifyQuotes(row[colClass1].ToString().Trim()) + "'";
            //ProductClass1 oCls1 = ProductClass1.LoadWhere(sql);
            //if (oCls1 != null)
            if (ModelEx.ProductClass1Ex.IsClassCodeInUse(Utility.VerifyQuotes(row[colClass1].ToString().Trim())))
            {
                verifiedResult.Append(colClass1).Append(";");
            }

            // Class2
            //sql = "Class2Code = '" + Utility.VerifyQuotes(row[colClass2].ToString().Trim()) + "'";
            //ProductClass2 oCls2 = ProductClass2.LoadWhere(sql);
            //if (oCls2 != null)
            if (ModelEx.ProductClass2Ex.IsClassCodeInUse(Utility.VerifyQuotes(row[colClass2].ToString().Trim())))
            {
                verifiedResult.Append(colClass2).Append(";");
            }

            // Class3
            //sql = "Class3Code = '" + Utility.VerifyQuotes(row[colClass3].ToString().Trim()) + "'";
            //ProductClass3 oCls3 = ProductClass3.LoadWhere(sql);
            //if (oCls3 != null)
            if (ModelEx.ProductClass3Ex.IsClassCodeInUse(Utility.VerifyQuotes(row[colClass3].ToString().Trim())))
            {
                verifiedResult.Append(colClass3).Append(";");
            }

            // Class4
            //sql = "Class4Code = '" + Utility.VerifyQuotes(row[colClass4].ToString().Trim()) + "'";
            //ProductClass4 oCls4 = ProductClass4.LoadWhere(sql);
            //if (oCls4 != null)
            if (ModelEx.ProductClass4Ex.IsClassCodeInUse(Utility.VerifyQuotes(row[colClass4].ToString().Trim())))
            {
                verifiedResult.Append(colClass4).Append(";");
            }

            // Class5
            //sql = "Class5Code = '" + Utility.VerifyQuotes(row[colClass5].ToString().Trim()) + "'";
            //ProductClass5 oCls5 = ProductClass5.LoadWhere(sql);
            //if (oCls5 != null)
            if (ModelEx.ProductClass5Ex.IsClassCodeInUse(Utility.VerifyQuotes(row[colClass5].ToString().Trim())))
            {
                verifiedResult.Append(colClass5).Append(";");
            }

            // Class6
            //sql = "Class6Code = '" + Utility.VerifyQuotes(row[colClass6].ToString().Trim()) + "'";
            //ProductClass6 oCls6 = ProductClass6.LoadWhere(sql);
            //if (oCls6 != null)
            if (ModelEx.ProductClass6Ex.IsClassCodeInUse(Utility.VerifyQuotes(row[colClass6].ToString().Trim())))
            {
                verifiedResult.Append(colClass6).Append(";");
            }

            // Barcode 
            sql = "BARCODE = '" + Utility.VerifyQuotes(row[colSTKCode].ToString().Trim()) + Utility.VerifyQuotes(row[colAppendix1].ToString().Trim()) + Utility.VerifyQuotes(row[colAppendix2].ToString().Trim()) + Utility.VerifyQuotes(row[colAppendix3].ToString().Trim()) + "'";
            ProductBarcode oBarcode = ProductBarcode.LoadWhere(sql);
            if (oBarcode != null)
            {
                returnResult.Append("Duplicated Barcode;");
            }

            if (verifiedResult.ToString().Length > iLen)
            {
                duplicatedRec.Add(verifiedResult.ToString());
            }

            return returnResult.ToString();
        }
        #endregion

        #region Import Stock Code to database
        private void ImportData()
        {
            //MessageBox.Show(chkAutoGenerateBarcode.Checked.ToString());
            //MessageBox.Show(chkSetRetailItem.Checked.ToString());
            //MessageBox.Show(chkAutoCreate.Checked.ToString());
            int iErrCount = 0;

            StockCodeList oList = dgvTempStockCodeList.DataSource as StockCodeList;
            for (int i = 0; i < oList.Count; i++)
            {
                if (string.IsNullOrEmpty(oList[i].Status))
                {
                    // Class/Appendix
                    System.Guid a1Id = ImportAppendix1(oList[i].Season);
                    System.Guid a2Id = ImportAppendix2(oList[i].Color);
                    System.Guid a3Id = ImportAppendix3(oList[i].Size);
                    System.Guid c1Id = ImportClass1(oList[i].Vendor);
                    System.Guid c2Id = ImportClass2(oList[i].Gender);
                    System.Guid c3Id = ImportClass3(oList[i].Collection);
                    System.Guid c4Id = ImportClass4(oList[i].Group);
                    System.Guid c5Id = ImportClass5(oList[i].Category);
                    System.Guid c6Id = ImportClass6(oList[i].SubCat);

                    // Product
                    System.Guid productId = ImportProduct(oList[i]);
                    ImportProductSupplement(productId, oList[i]);
                    ImportProductCode(productId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);
                    ImportProductRemarks(productId, oList[i]);
                    ImportProductPrice(productId, oList[i]);

                    // Generate Barcode
                    if (chkAutoGenerateBarcode.Checked)
                    {
                        ImportProductBarcode(productId, oList[i]);
                    }
                }
                else
                {
                    iErrCount++;
                }

                if (i == (oList.Count - 1))
                {
                    if (iErrCount == 0)
                    {
                        MessageBox.Show("Success!", "Import Result");
                    }
                    else
                    {
                        int succeedCount = oList.Count - iErrCount;
                        MessageBox.Show(succeedCount.ToString() + " Succeed! " + iErrCount.ToString() + " Failed!", "Import Result");
                    }
                }
            }
        }

        #region Class/Appendix
        private Guid ImportAppendix1(string appendix1Value)
        {
            string sql = "Appendix1Code = '" + appendix1Value + "'";
            ProductAppendix1 oA1 = ProductAppendix1.LoadWhere(sql);
            if (oA1 == null)
            {
                oA1 = new ProductAppendix1();

                oA1.Appendix1Code = appendix1Value;
                oA1.Appendix1Initial = appendix1Value;

                oA1.CreatedBy = Common.Config.CurrentUserId;
                oA1.CreatedOn = DateTime.Now;
            }

            oA1.ModifiedBy = Common.Config.CurrentUserId;
            oA1.ModifiedOn = DateTime.Now;

            oA1.Save();

            return oA1.Appendix1Id;
        }

        private Guid ImportAppendix2(string appendix2Value)
        {
            string sql = "Appendix2Code = '" + appendix2Value + "'";
            ProductAppendix2 oA2 = ProductAppendix2.LoadWhere(sql);
            if (oA2 == null)
            {
                oA2 = new ProductAppendix2();

                oA2.Appendix2Code = appendix2Value;
                oA2.Appendix2Initial = appendix2Value;

                oA2.CreatedBy = Common.Config.CurrentUserId;
                oA2.CreatedOn = DateTime.Now;
            }

            oA2.ModifiedBy = Common.Config.CurrentUserId;
            oA2.ModifiedOn = DateTime.Now;

            oA2.Save();

            return oA2.Appendix2Id;
        }

        private Guid ImportAppendix3(string appendix3Value)
        {
            string sql = "Appendix3Code = '" + appendix3Value + "'";
            ProductAppendix3 oA3 = ProductAppendix3.LoadWhere(sql);
            if (oA3 == null)
            {
                oA3 = new ProductAppendix3();

                oA3.Appendix3Code = appendix3Value;
                oA3.Appendix3Initial = appendix3Value;

                oA3.CreatedBy = Common.Config.CurrentUserId;
                oA3.CreatedOn = DateTime.Now;
            }

            oA3.ModifiedBy = Common.Config.CurrentUserId;
            oA3.ModifiedOn = DateTime.Now;

            oA3.Save();

            return oA3.Appendix3Id;
        }

        private Guid ImportClass1(string class1Value)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "Class1Code = '" + class1Value + "'";
                var oC1 = ctx.ProductClass1.Where(x => x.Class1Code == class1Value).FirstOrDefault();
                if (oC1 == null)
                {
                    oC1 = new EF6.ProductClass1();
                    oC1.Class1Id = Guid.NewGuid();
                    oC1.Class1Code = class1Value;
                    oC1.Class1Initial = class1Value;

                    oC1.CreatedBy = Common.Config.CurrentUserId;
                    oC1.CreatedOn = DateTime.Now;

                    ctx.ProductClass1.Add(oC1);
                }

                oC1.ModifiedBy = Common.Config.CurrentUserId;
                oC1.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = oC1.Class1Id;
            }

            return result;
        }

        private Guid ImportClass2(string class2Value)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "Class2Code = '" + class2Value +"'";
                var oC2 = ctx.ProductClass2.Where(x => x.Class2Code == class2Value).FirstOrDefault();
                if (oC2 == null)
                {
                    oC2 = new EF6.ProductClass2();
                    oC2.Class2Id = Guid.NewGuid();
                    oC2.Class2Code = class2Value;
                    oC2.Class2Initial = class2Value;

                    oC2.CreatedBy = Common.Config.CurrentUserId;
                    oC2.CreatedOn = DateTime.Now;

                    ctx.ProductClass2.Add(oC2);
                }

                oC2.ModifiedBy = Common.Config.CurrentUserId;
                oC2.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = oC2.Class2Id;
            }

            return result;
        }

        private Guid ImportClass3(string class3Value)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "Class3Code = '" + class3Value +"'";
                var oC3 = ctx.ProductClass3.Where(x => x.Class3Code == class3Value).FirstOrDefault();
                if (oC3 == null)
                {
                    oC3 = new EF6.ProductClass3();
                    oC3.Class3Id = Guid.NewGuid();
                    oC3.Class3Code = class3Value;
                    oC3.Class3Initial = class3Value;

                    oC3.CreatedBy = Common.Config.CurrentUserId;
                    oC3.CreatedOn = DateTime.Now;

                    ctx.ProductClass3.Add(oC3);
                }

                oC3.ModifiedBy = Common.Config.CurrentUserId;
                oC3.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = oC3.Class3Id;
            }

            return result;
        }

        private Guid ImportClass4(string class4Value)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "Class4Code = '" + class4Value + "'";
                var oC4 = ctx.ProductClass4.Where(x => x.Class4Code == class4Value).FirstOrDefault();
                if (oC4 == null)
                {
                    oC4 = new EF6.ProductClass4();
                    oC4.Class4Id = Guid.NewGuid();
                    oC4.Class4Code = class4Value;
                    oC4.Class4Initial = class4Value;

                    oC4.CreatedBy = Common.Config.CurrentUserId;
                    oC4.CreatedOn = DateTime.Now;

                    ctx.ProductClass4.Add(oC4);
                }

                oC4.ModifiedBy = Common.Config.CurrentUserId;
                oC4.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = oC4.Class4Id;
            }

            return result;
        }

        private Guid ImportClass5(string class5Value)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "Class5Code = '" + class5Value + "'";
                var oC5 = ctx.ProductClass5.Where(x => x.Class5Code == class5Value).FirstOrDefault();
                if (oC5 == null)
                {
                    oC5 = new EF6.ProductClass5();
                    oC5.Class5Id = Guid.NewGuid();
                    oC5.Class5Code = class5Value;
                    oC5.Class5Initial = class5Value;

                    oC5.CreatedBy = Common.Config.CurrentUserId;
                    oC5.CreatedOn = DateTime.Now;

                    ctx.ProductClass5.Add(oC5);
                }

                oC5.ModifiedBy = Common.Config.CurrentUserId;
                oC5.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = oC5.Class5Id;
            }

            return result;
        }

        private Guid ImportClass6(string class6Value)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "Class6Code = '" + class6Value + "'";
                var oC6 = ctx.ProductClass6.Where(x => x.Class6Code == class6Value).FirstOrDefault();
                if (oC6 == null)
                {
                    oC6 = new EF6.ProductClass6();
                    oC6.Class6Id = Guid.NewGuid();
                    oC6.Class6Code = class6Value;
                    oC6.Class6Initial = class6Value;

                    oC6.CreatedBy = Common.Config.CurrentUserId;
                    oC6.CreatedOn = DateTime.Now;

                    ctx.ProductClass6.Add(oC6);
                }

                oC6.ModifiedBy = Common.Config.CurrentUserId;
                oC6.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = oC6.Class6Id;
            }

            return result;
        }
        #endregion

        private Guid ImportProduct(StockCodeRec oRec)
        {
            StringBuilder productWhereClause = new StringBuilder();
            productWhereClause.Append(" STKCODE = '").Append(oRec.PLU).Append("' ");
            productWhereClause.Append(" AND APPENDIX1 = '").Append(oRec.Season).Append("' ");
            productWhereClause.Append(" AND APPENDIX2 = '").Append(oRec.Color).Append("' ");
            productWhereClause.Append(" AND APPENDIX3 = '").Append(oRec.Size).Append("' ");
            productWhereClause.Append(" AND CLASS1 = '").Append(oRec.Vendor).Append("' ");
            productWhereClause.Append(" AND CLASS2 = '").Append(oRec.Gender).Append("' ");
            productWhereClause.Append(" AND CLASS3 = '").Append(oRec.Collection).Append("' ");
            productWhereClause.Append(" AND CLASS4 = '").Append(oRec.Group).Append("' ");
            productWhereClause.Append(" AND CLASS5 = '").Append(oRec.Category).Append("' ");
            productWhereClause.Append(" AND CLASS6 = '").Append(oRec.SubCat).Append("' ");

            RT2020.DAL.Product oItem = RT2020.DAL.Product.LoadWhere(productWhereClause.ToString());
            if (oItem == null)
            {
                oItem = new RT2020.DAL.Product();

                oItem.STKCODE = oRec.PLU;
                oItem.APPENDIX1 = oRec.Season;
                oItem.APPENDIX2 = oRec.Color;
                oItem.APPENDIX3 = oRec.Size;
                oItem.CLASS1 = oRec.Vendor;
                oItem.CLASS2 = oRec.Gender;
                oItem.CLASS3 = oRec.Collection;
                oItem.CLASS4 = oRec.Group;
                oItem.CLASS5 = oRec.Category;
                oItem.CLASS6 = oRec.SubCat;

                oItem.ProductName = oRec.Description;
                oItem.RetailPrice = Convert.ToDecimal(oRec.BASPRC);
                oItem.DownloadToPOS = chkSetRetailItem.Checked;
                //oItem.NatureId = System.Guid.Empty;

                oItem.CreatedBy = Common.Config.CurrentUserId;
                oItem.CreatedOn = DateTime.Now;
            }

            oItem.ModifiedBy = Common.Config.CurrentUserId;
            oItem.ModifiedOn = DateTime.Now;

            oItem.Save();

            return oItem.ProductId;
        }

        private void ImportProductSupplement(Guid productId, StockCodeRec oRec)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "ProductId = '" + productId.ToString() + "' AND VendorCurrencyCode = '" + oRec.VCURR + "'";
                var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == productId && x.VendorCurrencyCode == oRec.VCURR).FirstOrDefault();
                if (oProdSupp == null)
                {
                    oProdSupp = new EF6.ProductSupplement();
                    oProdSupp.SupplementId = Guid.NewGuid();
                    oProdSupp.ProductId = productId;
                    oProdSupp.VendorCurrencyCode = oRec.VCURR;
                    oProdSupp.VendorPrice = Convert.ToDecimal(oRec.VPRC);

                    ctx.ProductSupplement.Add(oProdSupp);
                    ctx.SaveChanges();
                }
            }
        }

        private void ImportProductBarcode(Guid productId, StockCodeRec oRec)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                StringBuilder barcode = new StringBuilder();
                barcode.Append(oRec.PLU); // STK_CODE
                barcode.Append(oRec.Season); // Appendix1
                barcode.Append(oRec.Color); // Appendix2
                barcode.Append(oRec.Size); // Appendix3

                //string sql = "ProductId = '" + productId.ToString() + "' AND Barcode = '" + barcode.ToString() + "'";
                var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == productId && x.Barcode == barcode.ToString()).FirstOrDefault();
                if (oBarcode == null)
                {
                    oBarcode = new EF6.ProductBarcode();
                    oBarcode.ProductBarcodeId = Guid.NewGuid();
                    oBarcode.Barcode = barcode.ToString();
                    oBarcode.BarcodeType = "INTER";
                    oBarcode.PrimaryBarcode = true;
                    oBarcode.DownloadToPOS = chkSetRetailItem.Checked;
                    ctx.ProductBarcode.Add(oBarcode);
                    ctx.SaveChanges();
                }
            }
        }

        private void ImportProductCode(Guid productId, Guid a1Id, Guid a2Id, Guid a3Id, Guid c1Id, Guid c2Id, Guid c3Id, Guid c4Id, Guid c5Id, Guid c6Id)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + productId.ToString() + "'";
                var oCode = ctx.ProductCode.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oCode == null)
                {
                    oCode = new EF6.ProductCode();
                    oCode.CodeId = Guid.NewGuid();
                    oCode.ProductId = productId;
                    oCode.Appendix1Id = a1Id;
                    oCode.Appendix2Id = a2Id;
                    oCode.Appendix3Id = a3Id;
                    oCode.Class1Id = c1Id;
                    oCode.Class2Id = c2Id;
                    oCode.Class3Id = c3Id;
                    oCode.Class4Id = c4Id;
                    oCode.Class5Id = c5Id;
                    oCode.Class6Id = c6Id;

                    ctx.ProductCode.Add(oCode);
                    ctx.SaveChanges();
                }
            }
        }

        private void ImportProductRemarks(Guid productId, StockCodeRec oRec)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + productId.ToString() + "'";
                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oRemarks == null)
                {
                    oRemarks = new EF6.ProductRemarks();
                    oRemarks.ProductRemarksId = Guid.NewGuid();
                    oRemarks.ProductId = productId;
                    oRemarks.Photo = oRec.PhotoPath;
                    oRemarks.Notes = oRec.STK_MEMO;
                    oRemarks.DownloadToShop = chkSetRetailItem.Checked;

                    ctx.ProductRemarks.Add(oRemarks);
                    ctx.SaveChanges();
                }
            }
        }

        private void ImportProductPrice(Guid productId, StockCodeRec oRec)
        {
            ImportProductPrice(productId, Common.Enums.ProductPriceType.BASPRC.ToString(), "HKD", oRec.BASPRC);
            ImportProductPrice(productId, Common.Enums.ProductPriceType.ORIPRC.ToString(), "HKD", "0");
            ImportProductPrice(productId, Common.Enums.ProductPriceType.VPRC.ToString(), oRec.VCURR, oRec.VPRC);
            ImportProductPrice(productId, Common.Enums.ProductPriceType.WHLPRC.ToString(), "HKD", "0");
        }

        private void ImportProductPrice(Guid productId, string priceType, string currencyCode, string price)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + productId.ToString() + "'";
                var oPrice = ctx.ProductPrice.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oPrice == null)
                {
                    oPrice = new EF6.ProductPrice();
                    oPrice.ProductPriceId = Guid.NewGuid();
                    oPrice.ProductId = productId;
                    oPrice.PriceTypeId = GetPriceType(priceType);
                    oPrice.CurrencyCode = currencyCode;
                    oPrice.Price = Convert.ToDecimal(price);

                    ctx.ProductPrice.Add(oPrice);
                    ctx.SaveChanges();
                }
            }
        }

        private Guid GetPriceType(string priceType)
        {
            Guid result = Guid.Empty;
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "PriceType = '" + priceType + "'";
                var oType = ctx.ProductPriceType.Where(x => x.PriceType == priceType).FirstOrDefault();
                if (oType == null)
                {
                    oType = new EF6.ProductPriceType();
                    oType.PriceTypeId = Guid.NewGuid();
                    oType.PriceType = priceType;
                    oType.CurrencyCode = "HKD";
                    oType.CoreSystemPrice = false;

                    ctx.ProductPriceType.Add(oType);
                    ctx.SaveChanges();

                    result = oType.PriceTypeId;
                }
            }
            return result;
        }
        #endregion

        #region Stock Code Records Class
        public class StockCodeRec
        {
            public StockCodeRec(int intRowNum, string strStatus, string strVendor, string strGender, string strCollection, string strGroup, string strCategory,
                string strSubCat, string strDescription, string strPLU, string strSeason, string strColor, string strSize, string strBasprc, string strVcurr,
                string strVprc, string strStkMemo, string strPhotoPath)
            {
                rownum = intRowNum;
                status = strStatus;
                vendor = strVendor;
                gender = strGender;
                collection = strCollection;
                group = strGroup;
                category = strCategory;
                subCat = strSubCat;
                description = strDescription;
                pLU = strPLU;
                season = strSeason;
                color = strColor;
                size = strSize;
                basprc = strBasprc;
                vcurr = strVcurr;
                vprc = strVprc;
                stkMemo = strStkMemo;
                photoPath = strPhotoPath;
            }

            #region Properties
            private int rownum = 0;
            /// <summary>
            ///  Line number
            /// </summary>
            public int LN
            {
                get { return rownum; }
                set { rownum = value; }
            }

            private string status = string.Empty;
            /// <summary>
            /// Record Status
            /// </summary>
            public string Status
            {
                get { return status; }
                set { status = value; }
            }

            private string vendor = string.Empty;
            /// <summary>
            /// VENDOR [CLASS1]
            /// </summary>
            public string Vendor
            {
                get { return vendor; }
                set { vendor = value; }
            }

            private string gender = string.Empty;
            /// <summary>
            ///  GENDOR [CLASS2]
            /// </summary>
            public string Gender
            {
                get { return gender; }
                set { gender = value; }
            }

            private string collection = string.Empty;
            /// <summary>
            /// COLLECTION [CLASS3]
            /// </summary>
            public string Collection
            {
                get { return collection; }
                set { collection = value; }
            }

            private string group = string.Empty;
            /// <summary>
            /// GROUP [CLASS4]
            /// </summary>
            public string Group
            {
                get { return group; }
                set { group = value; }
            }

            private string category = string.Empty;
            /// <summary>
            /// CATEGORY [CLASS5]
            /// </summary>
            public string Category
            {
                get { return category; }
                set { category = value; }
            }

            private string subCat = string.Empty;
            /// <summary>
            ///  SUB-CAT [CLASS6]
            /// </summary>
            public string SubCat
            {
                get { return subCat; }
                set { subCat = value; }
            }

            private string description = string.Empty;
            /// <summary>
            ///  Description [DESC]
            /// </summary>
            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            private string pLU = string.Empty;
            /// <summary>
            ///  PLU [STKCODE]
            /// </summary>
            public string PLU
            {
                get { return pLU; }
                set { pLU = value; }
            }

            private string season = string.Empty;
            /// <summary>
            ///  SEASON [APPENDIX1]
            /// </summary>
            public string Season
            {
                get { return season; }
                set { season = value; }
            }

            private string color = string.Empty;
            /// <summary>
            ///  COLOR [APPENDIX2]
            /// </summary>
            public string Color
            {
                get { return color; }
                set { color = value; }
            }

            private string size = string.Empty;
            /// <summary>
            ///  SIZE [APPENDIX3]
            /// </summary>
            public string Size
            {
                get { return size; }
                set { size = value; }
            }

            private string basprc = string.Empty;
            /// <summary>
            ///  Basic Price [BASPRC]
            /// </summary>
            public string BASPRC
            {
                get { return basprc; }
                set { basprc = value; }
            }

            private string vcurr = string.Empty;
            /// <summary>
            ///  Vendor Currency [VCURR]
            /// </summary>
            public string VCURR
            {
                get { return vcurr; }
                set { vcurr = value; }
            }

            private string vprc = string.Empty;
            /// <summary>
            ///  Vendor Price [VPRC]
            /// </summary>
            public string VPRC
            {
                get { return vprc; }
                set { vprc = value; }
            }

            private string stkMemo = string.Empty;
            /// <summary>
            ///  Stock MEMO [STK_MEMO]
            /// </summary>
            public string STK_MEMO
            {
                get { return stkMemo; }
                set { stkMemo = value; }
            }

            private string photoPath = string.Empty;
            /// <summary>
            ///  Photo Path [PHOTO]
            /// </summary>
            public string PhotoPath
            {
                get { return photoPath; }
                set { photoPath = value; }
            }
            #endregion
        }

        public class StockCodeList : BindingList<StockCodeRec>
        {
        }
        #endregion
    }
}