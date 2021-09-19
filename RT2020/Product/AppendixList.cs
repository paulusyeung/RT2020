#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Controls;
using System.Data.SqlClient;
using Gizmox.WebGUI.Common.Resources;
using System.Configuration;
using RT2020.Common.Helper;
using RT2020.Components;
using System.Linq;

#endregion

namespace RT2020.Product
{
    public partial class AppendixList : DefaultListBase
    {
        private Guid PageId = new Guid("849DB3DE-D2D2-4879-A4F8-B943EC25799D");     // 2007.12.22 paulus: PageId used in Preference
        private FAB fab = new FAB();    // floating action button: Add New Supplier

        #region Properties
        private Guid _AppendixId = Guid.Empty;
        public Guid ProductAppendixId
        {
            get { return _AppendixId; }
            set { _AppendixId = value; }
        }

        private ProductHelper.Appendix _AppendixType = ProductHelper.Appendix.None;
        public ProductHelper.Appendix ProductAppendixType
        {
            get { return _AppendixType; }
            set { _AppendixType = value; }
        }
        #endregion

        public ProductHelper.Appendix AppendixType { get; set; }

        public AppendixList(ProductHelper.Appendix typeName, Control toolBar)
        {
            InitializeComponent();

            ProductToolbar tb = new ProductToolbar(toolBar, ref tbControl);

            _AppendixType = typeName;

            base.ExportClick += new MenuEventHandler(DefaultList_ExportClick);
            base.RefreshClick += new EventHandler(DefaultList_RefreshClick);
            base.PreferenceClick += new EventHandler(DefaultList_PreferenceClick);
            base.BindingListDoubleClick += new EventHandler(DefaultList_BindingListDoubleClick);
            base.ComboBoxSelectedIndexChanged += new EventHandler(DefaultList_ComboBoxSelectedIndexChanged);
            base.ButtonClick += new EventHandler(DefaultList_ButtonClick);
            base.ShowClick += new EventHandler(DefaultList_ShowClick);

            fab.Location = new Point(this.Size.Width - 80, this.Height - 100);
            fab.Click += fab_OnClick;
            this.Controls.Add(fab);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetColumns();
            SetLvwList();
            BindList();

        }

        private void fab_OnClick(object sender, EventArgs e)
        {
            var wizard = new ProductAppendixWizard();
            wizard.AppendixMode = _AppendixType == ProductHelper.Appendix.Appendix1 ?
                ProductHelper.Appendix.Appendix1 : _AppendixType == ProductHelper.Appendix.Appendix2 ?
                ProductHelper.Appendix.Appendix2 :
                ProductHelper.Appendix.Appendix3;
            wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.ShowDialog();
        }

        public override void BindList()
        {
            if (_AppendixType != ProductHelper.Appendix.None)
            {
                BindAppendixList();
            }
        }

        #region Bind Appendix List

        #region List View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colAppendixNameCht = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colAppendixId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colAppendixCode = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colAppendixName = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colAppendixNameChs = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colAppendixInitial = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();

            // 
            // colLN
            // 
            colLN.ClientAction = null;
            colLN.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colLN.Image = null;
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            colLN.Width = 30;
            // 
            // colAppendixId
            // 
            colAppendixId.ClientAction = null;
            colAppendixId.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendixId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colAppendixId.Image = null;
            colAppendixId.Name = "colAppendixId";
            colAppendixId.Text = "AppendixId";
            colAppendixId.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendixId.Visible = false;
            colAppendixId.Width = 150;
            // 
            // colAppendixCode
            // 
            colAppendixCode.ClientAction = null;
            colAppendixCode.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendixCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colAppendixCode.Image = null;
            colAppendixCode.Name = "colAppendixCode";
            colAppendixCode.Text = WestwindHelper.GetWord("appendix.code", "Product");
            colAppendixCode.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendixCode.Width = 80;
            // 
            // colAppendixInitial
            // 
            colAppendixInitial.ClientAction = null;
            colAppendixInitial.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendixInitial.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colAppendixInitial.Image = null;
            colAppendixInitial.Name = "colAppendixInitial";
            colAppendixInitial.Text = WestwindHelper.GetWord("appendix.initial", "Product");
            colAppendixInitial.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendixInitial.Width = 80;
            // 
            // colAppendixName
            // 
            colAppendixName.ClientAction = null;
            colAppendixName.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendixName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colAppendixName.Image = null;
            colAppendixName.Name = "colAppendixName";
            colAppendixName.Text = WestwindHelper.GetWord("appendix.name", "Product");
            colAppendixName.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendixName.Width = 120;
            // 
            // colAppendixNameChs
            // 
            colAppendixNameChs.ClientAction = null;
            colAppendixNameChs.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendixNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colAppendixNameChs.Image = null;
            colAppendixNameChs.Name = "colAppendixNameChs";
            colAppendixNameChs.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colAppendixNameChs.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendixNameChs.Width = 120;
            // 
            // colAppendixNameCht
            // 
            colAppendixNameCht.ClientAction = null;
            colAppendixNameCht.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendixNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colAppendixNameCht.Image = null;
            colAppendixNameCht.Name = "colAppendixNameCht";
            colAppendixNameCht.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            colAppendixNameCht.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendixNameCht.Width = 120;
            // 
            // colModifiedOn
            // 
            colModifiedOn.ClientAction = null;
            colModifiedOn.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colModifiedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colModifiedOn.Image = null;
            colModifiedOn.Name = "colModifiedOn";
            colModifiedOn.Text = WestwindHelper.GetWord("glossary.modifiedOn", "General");
            colModifiedOn.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colModifiedOn.Width = 120;
            // 
            // colCreatedOn
            // 
            colCreatedOn.ClientAction = null;
            colCreatedOn.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colCreatedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colCreatedOn.Image = null;
            colCreatedOn.Name = "colCreatedOn";
            colCreatedOn.Text = WestwindHelper.GetWord("glossary.createdOn", "General");
            colCreatedOn.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colCreatedOn.Width = 120;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colAppendixCode,
            colLN,
            colAppendixId,
            colAppendixInitial,
            colAppendixName,
            colAppendixNameChs,
            colAppendixNameCht,
            colCreatedOn,
            colModifiedOn});

            #region show/ hide alt1 alt2
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    colAppendixNameCht.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    colAppendixNameChs.Visible = colAppendixNameCht.Visible = false;
                    break;
            }
            #endregion
        }
        #endregion


        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{91F0A08C-4726-4829-94F2-5FBAE2ECA392}");

            ListViewHelper.LoadPreference(ref lvList);
        }

        private void BindAppendixList()
        {
            this.lvList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();
            /**
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(2)); // Appendix Code
                    objItem.SmallImage = new IconResourceHandle("16x16.Product16.gif");
                    objItem.LargeImage = new IconResourceHandle("16x16.Product16.gif");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); // AppendixId
                    objItem.SubItems.Add(reader.GetString(3)); // Appendix Initial
                    objItem.SubItems.Add(reader.GetString(4)); // Appendix Name
                    objItem.SubItems.Add(reader.GetString(5)); // Appendix Name Chs
                    objItem.SubItems.Add(reader.GetString(6)); // Appendix name Cht
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(7), true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(8), true)); // ModifiedOn

                    iCount++;
                }
            }
            */
            using (var ctx = new EF6.RT2020Entities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;

                switch (_AppendixType)
                {
                    case ProductHelper.Appendix.Appendix1:
                        #region bind Appendix1 list
                        var sql1 = string.Format("Select * from ProductAppendix1 {0}", sql.Substring(sql.LastIndexOf("WHERE")));
                        var list1 = ctx.ProductAppendix1.SqlQuery(sql1).AsNoTracking().ToList();
                        foreach (var item in list1)
                        {
                            ListViewItem objItem = this.lvList.Items.Add(item.Appendix1Code);
                            objItem.SmallImage = new IconResourceHandle("16x16.CustomerSingle_16.png");
                            objItem.LargeImage = new IconResourceHandle("16x16.CustomerSingle_16.png");

                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Appendix1Id.ToString()); // MemberCode
                            objItem.SubItems.Add(item.Appendix1Initial); // Member Initial
                            objItem.SubItems.Add(item.Appendix1Name); // Member Name
                            objItem.SubItems.Add(item.Appendix1Name_Chs); // Member Name Chs
                            objItem.SubItems.Add(item.Appendix1Name_Cht); // Member name Cht
                            objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.CreatedOn, true)); // CreatedOn
                            objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.ModifiedOn, true)); // ModifiedOn

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Appendix.Appendix2:
                        #region bind Appendix1 list
                        var sql2 = string.Format("Select * from ProductAppendix2 {0}", sql.Substring(sql.LastIndexOf("WHERE")));
                        var list2 = ctx.ProductAppendix2.SqlQuery(sql2).AsNoTracking().ToList();
                        foreach (var item in list2)
                        {
                            ListViewItem objItem = this.lvList.Items.Add(item.Appendix2Code);
                            objItem.SmallImage = new IconResourceHandle("16x16.CustomerSingle_16.png");
                            objItem.LargeImage = new IconResourceHandle("16x16.CustomerSingle_16.png");

                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Appendix2Id.ToString()); // MemberCode
                            objItem.SubItems.Add(item.Appendix2Initial); // Member Initial
                            objItem.SubItems.Add(item.Appendix2Name); // Member Name
                            objItem.SubItems.Add(item.Appendix2Name_Chs); // Member Name Chs
                            objItem.SubItems.Add(item.Appendix2Name_Cht); // Member name Cht
                            objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.CreatedOn, true)); // CreatedOn
                            objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.ModifiedOn, true)); // ModifiedOn

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Appendix.Appendix3:
                        #region bind Appendix1 list
                        var sql3 = string.Format("Select * from ProductAppendix3 {0}", sql.Substring(sql.LastIndexOf("WHERE")));
                        var list3 = ctx.ProductAppendix3.SqlQuery(sql3).AsNoTracking().ToList();
                        foreach (var item in list3)
                        {
                            ListViewItem objItem = this.lvList.Items.Add(item.Appendix3Code);
                            objItem.SmallImage = new IconResourceHandle("16x16.CustomerSingle_16.png");
                            objItem.LargeImage = new IconResourceHandle("16x16.CustomerSingle_16.png");

                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Appendix3Id.ToString()); // MemberCode
                            objItem.SubItems.Add(item.Appendix3Initial); // Member Initial
                            objItem.SubItems.Add(item.Appendix3Name); // Member Name
                            objItem.SubItems.Add(item.Appendix3Name_Chs); // Member Name Chs
                            objItem.SubItems.Add(item.Appendix3Name_Cht); // Member name Cht
                            objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.CreatedOn, true)); // CreatedOn
                            objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.ModifiedOn, true)); // ModifiedOn

                            iCount++;
                        }
                        break;
                        #endregion
                }
            }

            this.lvList.Sort(); // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效
        }

        #region Build Sql Query String
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append(_AppendixType);
            sql.Append("Id,  ROW_NUMBER() OVER (ORDER BY ");
            sql.Append(_AppendixType);
            sql.Append("Code) AS rownum, ISNULL(");
            sql.Append(_AppendixType);
            sql.Append("Code, ''), ISNULL(");
            sql.Append(_AppendixType);
            sql.Append("Initial, ''), ISNULL(");
            sql.Append(_AppendixType);
            sql.Append("Name, ''), ISNULL(");
            sql.Append(_AppendixType);
            sql.Append("Name_Chs, ''), ISNULL(");
            sql.Append(_AppendixType);
            sql.Append("Name_Cht, ''), ");
            sql.Append(" CreatedOn, ModifiedOn, CreatedBy, ModifiedBy ");
            sql.Append(" FROM Product");
            sql.Append(_AppendixType);
            sql.Append(" WHERE ");

            switch (SelectedViewIndex)
            {
                case 0: // Last 7 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 1: // Last 14 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-14).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 2: // Last 30 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 3: // Last 60 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-60).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 4: // Last 90 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-90).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 5: // All
                default:
                    sql.Append(" 1 = 1 ");
                    break;
            }

            if (!string.IsNullOrEmpty(SearchForText))
            {
                sql.Append(" AND (");
                sql.Append(_AppendixType);
                sql.Append("Code LIKE '%").Append(SearchForText).Append("%'");
                sql.Append(" OR ");
                sql.Append(_AppendixType);
                sql.Append("Name LIKE '%").Append(SearchForText).Append("%')");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            if (!(String.IsNullOrEmpty(AlphaSeacher)) && AlphaSeacher != "All")
            {
                sql.Append(String.Format(" AND ( SUBSTRING([" + _AppendixType + "Code], 1, 1) = N'{0}' )", AlphaSeacher));
            }

            sql.Append(" AND Retired = 0 ");
            sql.Append(" ORDER BY " + _AppendixType + "Code ");

            return sql.ToString();
        }
        #endregion

        #endregion

        void DefaultList_ButtonClick(object sender, EventArgs e)
        {
            BindList();
        }

        void DefaultList_ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            BindList();
        }

        void DefaultList_BindingListDoubleClick(object sender, EventArgs e)
        {
            ShowItem();
        }

        private void ShowItem()
        {
            if (lvList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvList.SelectedItem.SubItems[2].Text, out id))
                {
                    ProductAppendixWizard wizProd = new ProductAppendixWizard();
                    wizProd.EditMode = EnumHelper.EditMode.Edit;
                    wizProd.AppendixId = id;
                    wizProd.AppendixMode = _AppendixType == ProductHelper.Appendix.Appendix1?
                        ProductHelper.Appendix.Appendix1 : _AppendixType == ProductHelper.Appendix.Appendix2 ?
                        ProductHelper.Appendix.Appendix2 :
                        ProductHelper.Appendix.Appendix3;
                    wizProd.Closed += new EventHandler(wizProd_Closed);
                    wizProd.ShowDialog();
                }
            }
        }

        void wizProd_Closed(object sender, EventArgs e)
        {
            ProductAppendixWizard wizProd = sender as ProductAppendixWizard;
            if (wizProd.AppendixId != System.Guid.Empty)
            {
                BindList();
                this.Update();
            }
        }

        void DefaultList_PreferenceClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void DefaultList_RefreshClick(object sender, EventArgs e)
        {
            BindList();
            base.lvList.Update();
        }

        void DefaultList_ExportClick(object objSource, MenuItemEventArgs objArgs)
        {
            throw new NotImplementedException();
        }

        void DefaultList_ShowClick(object sender, EventArgs e)
        {
            ShowItem();
        }
    }
}