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
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Inventory.StockTake
{
    public partial class PartialItems : Form
    {
        public PartialItems()
        {
            InitializeComponent();
            FillListView();
            InitComboBoxes();

            lblClass1.Text = SystemInfo.Settings.GetSystemLabelByKey("CLASS1");
            lblClass2.Text = SystemInfo.Settings.GetSystemLabelByKey("CLASS2");
            lblClass3.Text = SystemInfo.Settings.GetSystemLabelByKey("CLASS3");
            lblClass4.Text = SystemInfo.Settings.GetSystemLabelByKey("CLASS4");
            lblClass5.Text = SystemInfo.Settings.GetSystemLabelByKey("CLASS5");
            lblClass6.Text = SystemInfo.Settings.GetSystemLabelByKey("CLASS6");
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
                string sql = "WorkplaceId = '" + workplaceId.ToString() + "' AND YEAR(PostedOn) = 1900 AND LEN(ADJNUM) = 0";
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

        #region Init Combo Box
        private void InitComboBoxes()
        {
            FillStockCodeList();
            FillFromClass1List();
            FillToClass1List();
            FillFromClass2List();
            FillToClass2List();
            FillFromClass3List();
            FillToClass3List();
            FillFromClass4List();
            FillToClass4List();
            FillFromClass5List();
            FillToClass5List();
            FillFromClass6List();
            FillToClass6List();
        }

        private void FillStockCodeList()
        {
            cboStockCode_From.DataSource = null;
            cboStockCode_To.DataSource = null;

            cboStockCode_From.Items.Clear();
            cboStockCode_To.Items.Clear();

            cboStockCode_From.Items.Add(" ");

            string query = "SELECT DISTINCT STKCODE FROM Product WHERE Retired = 0 ORDER BY STKCODE";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    cboStockCode_From.Items.Add(reader.GetString(0));
                    cboStockCode_To.Items.Add(reader.GetString(0));
                }
            }

            cboStockCode_To.Items.Add("zz");

            cboStockCode_To.SelectedIndex = cboStockCode_To.Items.Count - 1;
        }

        private void FillFromClass1List()
        {
            ModelEx.ProductClass1Ex.LoadCombo(ref cboClass1_From, "Class1Code", false, true, "", "");
            /**
            cboClass1_From.Items.Clear();

            string[] orderBy = new string[] { "Class1Code" };
            ProductClass1Collection prodCls1List = ProductClass1.LoadCollection(orderBy, true);
            prodCls1List.Add(new ProductClass1());
            cboClass1_From.DataSource = prodCls1List;
            cboClass1_From.DisplayMember = "Class1Code";
            cboClass1_From.ValueMember = "Class1Id";
            */
            cboClass1_From.SelectedIndex = cboClass1_From.Items.Count - 1;
        }

        private void FillToClass1List()
        {
            ModelEx.ProductClass1Ex.LoadCombo(ref cboClass1_To, "Class1Code", false, true, "zz", "");
            /**
            cboClass1_To.Items.Clear();
            ProductClass1 prodCls1 = new ProductClass1();
            prodCls1.Class1Code = "zz";

            string[] orderBy = new string[] { "Class1Code" };
            ProductClass1Collection prodCls1List = ProductClass1.LoadCollection(orderBy, true);
            prodCls1List.Add(prodCls1);
            cboClass1_To.DataSource = prodCls1List;
            cboClass1_To.DisplayMember = "Class1Code";
            cboClass1_To.ValueMember = "Class1Id";
            */
            cboClass1_To.SelectedIndex = cboClass1_To.Items.Count - 1;
        }

        private void FillFromClass2List()
        {
            ModelEx.ProductClass2Ex.LoadCombo(ref cboClass2_From, "Class2Code", false, true, "", "");
            /**
            cboClass2_From.Items.Clear();

            string[] orderBy = new string[] { "Class2Code" };
            ProductClass2Collection prodCls2List = ProductClass2.LoadCollection(orderBy, true);
            prodCls2List.Add(new ProductClass2());
            cboClass2_From.DataSource = prodCls2List;
            cboClass2_From.DisplayMember = "Class2Code";
            cboClass2_From.ValueMember = "Class2Id";
            */
            cboClass2_From.SelectedIndex = cboClass2_From.Items.Count - 1;
        }

        private void FillToClass2List()
        {
            ModelEx.ProductClass2Ex.LoadCombo(ref cboClass2_To, "Class2Code", false, true, "zz", "");
            /**
            cboClass2_To.Items.Clear();
            ProductClass2 prodCls2 = new ProductClass2();
            prodCls2.Class2Code = "zz";


            string[] orderBy = new string[] { "Class2Code" };
            ProductClass2Collection prodCls2List = ProductClass2.LoadCollection(orderBy, true);
            prodCls2List.Add(prodCls2);
            cboClass2_To.DataSource = prodCls2List;
            cboClass2_To.DisplayMember = "Class2Code";
            cboClass2_To.ValueMember = "Class2Id";
            */
            cboClass2_To.SelectedIndex = cboClass2_To.Items.Count - 1;
        }

        private void FillFromClass3List()
        {
            ModelEx.ProductClass3Ex.LoadCombo(ref cboClass3_From, "Class3Code", false, true, "", "");
            /**
            cboClass3_From.Items.Clear();

            string[] orderBy = new string[] { "Class3Code" };
            ProductClass3Collection prodCls3List = ProductClass3.LoadCollection(orderBy, true);
            prodCls3List.Add(new ProductClass3());
            cboClass3_From.DataSource = prodCls3List;
            cboClass3_From.DisplayMember = "Class3Code";
            cboClass3_From.ValueMember = "Class3Id";
            */
            cboClass3_From.SelectedIndex = cboClass3_From.Items.Count - 1;
        }

        private void FillToClass3List()
        {
            ModelEx.ProductClass3Ex.LoadCombo(ref cboClass3_To, "Class4Code", false, true, "zz", "");
            /**
            cboClass3_To.Items.Clear();
            ProductClass3 prodCls3 = new ProductClass3();
            prodCls3.Class3Code = "zz";


            string[] orderBy = new string[] { "Class3Code" };
            ProductClass3Collection prodCls3List = ProductClass3.LoadCollection(orderBy, true);
            prodCls3List.Add(prodCls3);
            cboClass3_To.DataSource = prodCls3List;
            cboClass3_To.DisplayMember = "Class3Code";
            cboClass3_To.ValueMember = "Class3Id";
            /*
            cboClass3_To.SelectedIndex = prodCls3List.Count - 1;
        }

        private void FillFromClass4List()
        {
            ModelEx.ProductClass4Ex.LoadCombo(ref cboClass4_From, "Class4Code", false, true, "", "");
            /**
            cboClass4_From.Items.Clear();

            string[] orderBy = new string[] { "Class4Code" };
            ProductClass4Collection prodCls4List = ProductClass4.LoadCollection(orderBy, true);
            prodCls4List.Add(new ProductClass4());
            cboClass4_From.DataSource = prodCls4List;
            cboClass4_From.DisplayMember = "Class4Code";
            cboClass4_From.ValueMember = "Class4Id";
            */
            cboClass3_From.SelectedIndex = cboClass3_From.Items.Count - 1;
        }

        private void FillFromClass4List()
        {
            ModelEx.ProductClass4Ex.LoadCombo(ref cboClass4_From, "Class4Code", false, true, "", "");
            /**
            cboClass5_From.Items.Clear();

            string[] orderBy = new string[] { "Class5Code" };
            ProductClass5Collection prodCls5List = ProductClass5.LoadCollection(orderBy, true);
            prodCls5List.Add(new ProductClass5());
            cboClass5_From.DataSource = prodCls5List;
            cboClass5_From.DisplayMember = "Class5Code";
            cboClass5_From.ValueMember = "Class5Id";
            */
            cboClass4_From.SelectedIndex = cboClass4_From.Items.Count - 1;
        }

        private void FillToClass4List()
        {
            ModelEx.ProductClass4Ex.LoadCombo(ref cboClass4_To, "Class4Code", false, true, "zz", "");
            /**
            cboClass4_To.Items.Clear();
            ProductClass4 prodCls4 = new ProductClass4();
            prodCls4.Class4Code = "zz";


            string[] orderBy = new string[] { "Class4Code" };
            ProductClass4Collection prodCls4List = ProductClass4.LoadCollection(orderBy, true);
            prodCls4List.Add(prodCls4);
            cboClass4_To.DataSource = prodCls4List;
            cboClass4_To.DisplayMember = "Class4Code";
            cboClass4_To.ValueMember = "Class4Id";
            */
            cboClass4_To.SelectedIndex = cboClass4_To.Items.Count - 1;
        }

        private void FillFromClass5List()
        {
            ModelEx.ProductClass5Ex.LoadCombo(ref cboClass5_From, "Class5Code", false, true, "", "");
            /**
            cboClass5_From.Items.Clear();

            string[] orderBy = new string[] { "Class5Code" };
            ProductClass5Collection prodCls5List = ProductClass5.LoadCollection(orderBy, true);
            prodCls5List.Add(new ProductClass5());
            cboClass5_From.DataSource = prodCls5List;
            cboClass5_From.DisplayMember = "Class5Code";
            cboClass5_From.ValueMember = "Class5Id";
            */
            cboClass5_From.SelectedIndex = cboClass5_From.Items.Count - 1;
        }

        private void FillToClass5List()
        {
            ModelEx.ProductClass5Ex.LoadCombo(ref cboClass5_To, "Class5Code", false, true, "zz", "");
            /**
            cboClass5_To.Items.Clear();
            ProductClass5 prodCls5 = new ProductClass5();
            prodCls5.Class5Code = "zz";


            string[] orderBy = new string[] { "Class5Code" };
            ProductClass5Collection prodCls5List = ProductClass5.LoadCollection(orderBy, true);
            prodCls5List.Add(prodCls5);
            cboClass5_To.DataSource = prodCls5List;
            cboClass5_To.DisplayMember = "Class5Code";
            cboClass5_To.ValueMember = "Class5Id";
            */
            cboClass5_To.SelectedIndex = cboClass5_To.Items.Count - 1;
        }

        private void FillFromClass6List()
        {
            ModelEx.ProductClass6Ex.LoadCombo(ref cboClass6_From, "Class6Code", false, true, "", "");
            /**
            cboClass6_From.Items.Clear();

            string[] orderBy = new string[] { "Class6Code" };
            ProductClass6Collection prodCls6List = ProductClass6.LoadCollection(orderBy, true);
            prodCls6List.Add(new ProductClass6());
            cboClass6_From.DataSource = prodCls6List;
            cboClass6_From.DisplayMember = "Class6Code";
            cboClass6_From.ValueMember = "Class6Id";
            */
            cboClass6_From.SelectedIndex = cboClass6_From.Items.Count - 1;
        }

        private void FillToClass6List()
        {
            ModelEx.ProductClass6Ex.LoadCombo(ref cboClass6_To, "Class6Code", false, true, "zz", "");
            /**
            cboClass6_To.Items.Clear();
            ProductClass6 prodCls6 = new ProductClass6();
            prodCls6.Class6Code = "zz";


            string[] orderBy = new string[] { "Class6Code" };
            ProductClass6Collection prodCls6List = ProductClass6.LoadCollection(orderBy, true);
            prodCls6List.Add(prodCls6);
            cboClass6_To.DataSource = prodCls6List;
            cboClass6_To.DisplayMember = "Class6Code";
            cboClass6_To.ValueMember = "Class6Id";
            */
            cboClass6_To.SelectedIndex = cboClass6_To.Items.Count - 1;
        }
        #endregion

        #region Stock Take Creation
        private string GetProductListQueryString()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("(STKCODE >= '")
                .Append(cboStockCode_From.Text.Trim())
                .Append("') AND ")
                .Append("(STKCODE <= '")
                .Append(cboStockCode_To.Text.Trim())
                .Append("') AND ");

            sql.Append("(CLASS1 >= '")
                .Append(cboClass1_From.Text)
                .Append("') AND ")
                .Append("(CLASS1 <= '")
                .Append(cboClass1_To.Text)
                .Append("') AND ");

            sql.Append("(CLASS2 >= '")
                .Append(cboClass2_From.Text)
                .Append("') AND ")
                .Append("(CLASS2 <= '")
                .Append(cboClass2_To.Text)
                .Append("') AND ");

            sql.Append("(CLASS3 >= '")
                .Append(cboClass3_From.Text)
                .Append("') AND ")
                .Append("(CLASS3 <= '")
                .Append(cboClass3_To.Text)
                .Append("') AND ");

            sql.Append("(CLASS4 >= '")
                .Append(cboClass4_From.Text)
                .Append("') AND ")
                .Append("(CLASS4 <= '")
                .Append(cboClass4_To.Text)
                .Append("') AND ");

            sql.Append("(CLASS5 >= '")
                .Append(cboClass5_From.Text)
                .Append("') AND ")
                .Append("(CLASS5 <= '")
                .Append(cboClass5_To.Text)
                .Append("') AND ");

            sql.Append("(CLASS6 >= '")
                .Append(cboClass6_From.Text)
                .Append("') AND ")
                .Append("(CLASS6 <= '")
                .Append(cboClass6_To.Text)
                .Append("') ");

            //ProductCollection prodList = RT2020.DAL.Product.LoadCollection(sql.ToString(), new string[] { "STKCODE" }, true);
            return sql.ToString();
        }

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

                    System.Guid headerId = CreateSTK(stkNum, wpId);
                    SetProgress(iCount, "Creating Transaction# " + stkNum);

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
                string sql = "WorkplaceId = '" + workplaceId.ToString() + "' ";
                var stkHeader = ctx.StockTakeHeader.Where(x => x.WorkplaceId == workplaceId).FirstOrDefault();
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
                stkHeader.CapturedAmount = 0;
                stkHeader.CapturedOn = DateTime.Now;
                stkHeader.CapturedQty = 0;

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

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var prodList = ctx.Product.SqlQuery(string.Format("Select * from Product Where {0}", GetProductListQueryString())).ToList();
                        foreach (var prod in prodList)
                        {
                            string sql = "WorkplaceId = '" + workplaceId.ToString() + "' AND ProductId = '" + prod.ProductId.ToString() + "'";
                            if (rbtnNonZeroQtyItems.Checked)
                            {
                                sql += " AND CDQTY > 0";
                            }

                            var wpItem = ctx.ProductWorkplace
                                .SqlQuery(string.Format("Select * from ProductWorkplace Where {0}", sql))
                                .FirstOrDefault();
                            if (wpItem != null)
                            {
                                decimal avgCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(prod.ProductId);

                                #region 一隻跟一隻 save detail
                                var stkDetail = new EF6.StockTakeDetails();
                                stkDetail.DetailsId = Guid.NewGuid();
                                stkDetail.TxNumber = txNumber;
                                stkDetail.HeaderId = headerId;
                                stkDetail.WorkplaceId = workplaceId;
                                stkDetail.ProductId = prod.ProductId;
                                stkDetail.CapturedQty = wpItem.CDQTY;
                                stkDetail.AverageCost = avgCost;

                                stkDetail.ModifiedBy = Common.Config.CurrentUserId;
                                stkDetail.ModifiedOn = DateTime.Now;

                                ctx.StockTakeDetails.Add(stkDetail);
                                ctx.SaveChanges();
                                #endregion

                                qty += wpItem.CDQTY;
                                amount += wpItem.CDQTY * avgCost;
                            }
                        }

                        #region save header
                        var oHeader = ctx.StockTakeHeader.Find(headerId);
                        if (oHeader != null)
                        {
                            oHeader.CapturedQty = qty;
                            oHeader.CapturedAmount = amount;
                            ctx.SaveChanges();
                        }
                        #endregion

                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
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
        #endregion

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int result = CreateSTK();
            if (result > 0)
            {
                RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                MessageBox.Show(result.ToString() + " Transaction(s) Creation Complete !", "Creation Succeed", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, new EventHandler(CreationMessageHandler));
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
                lvLocationList.Items[e.Index].Checked = false;

                MessageBox.Show("The location has its own stock take worksheet", "Message", MessageBoxButtons.OK, new EventHandler(ErrorMessageHandler));
            }
        }

        private void ErrorMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
            }
        }
    }
}