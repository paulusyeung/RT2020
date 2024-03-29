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

#endregion

namespace RT2020.Product
{
    public partial class ClassList : DefaultListBase
    {
        private Guid PageId = new Guid("96D49FA2-039A-4E77-9F83-DA932B14DCA7");     // 2007.12.22 paulus: PageId used in Preference
        private FAB fab = new FAB();    // floating action button: Add New Supplier

        public string TypeName { get; set; }

        public ClassList(string typeName, Control toolBar)
        {
            InitializeComponent();

            ProductToolbar tb = new ProductToolbar(toolBar, ref tbControl);

            this.TypeName = typeName;

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
            var wizard = new ProductClassWizard();
            wizard.ClassMode = TypeName == "Class1" ?
                ProductHelper.Classes.Class1 : TypeName == "Class2" ?
                ProductHelper.Classes.Class2 : TypeName == "Class3" ?
                ProductHelper.Classes.Class3 : TypeName == "Class4" ?
                ProductHelper.Classes.Class4 : TypeName == "Class5" ?
                ProductHelper.Classes.Class5 :
                ProductHelper.Classes.Class6;
            wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.ShowDialog();
        }

        public override void BindList()
        {
            if (!string.IsNullOrEmpty(this.TypeName))
            {
                BindClassList();
            }
        }

        #region Bind Class List

        #region List View Columns
        void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colClassNameCht = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colClassId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colClassCode = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colClassName = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colClassNameChs = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colClassInitial = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();

            // 
            // colLN
            // 
            colLN.ClientAction = null;
            colLN.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colLN.Image = null;
            colLN.Name = "colLN";
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            colLN.Width = 30;
            // 
            // colClassId
            // 
            colClassId.ClientAction = null;
            colClassId.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colClassId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colClassId.Image = null;
            colClassId.Name = "colClassId";
            colClassId.Text = "ClassId";
            colClassId.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colClassId.Visible = false;
            colClassId.Width = 150;
            // 
            // colClassCode
            // 
            colClassCode.ClientAction = null;
            colClassCode.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colClassCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colClassCode.Image = null;
            colClassCode.Name = "colClassCode";
            colClassCode.Text = WestwindHelper.GetWord("class.code", "Product");
            colClassCode.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colClassCode.Width = 80;
            // 
            // colClassInitial
            // 
            colClassInitial.ClientAction = null;
            colClassInitial.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colClassInitial.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colClassInitial.Image = null;
            colClassInitial.Name = "colClassInitial";
            colClassInitial.Text = WestwindHelper.GetWord("class.initial", "Product");
            colClassInitial.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colClassInitial.Width = 120;
            // 
            // colClassName
            // 
            colClassName.ClientAction = null;
            colClassName.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colClassName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colClassName.Image = null;
            colClassName.Name = "colClassName";
            colClassName.Text = WestwindHelper.GetWord("class.name", "Product");
            colClassName.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colClassName.Width = 120;
            // 
            // colClassNameChs
            // 
            colClassNameChs.ClientAction = null;
            colClassNameChs.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colClassNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colClassNameChs.Image = null;
            colClassNameChs.Name = "colClassNameChs";
            colClassNameChs.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colClassNameChs.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colClassNameChs.Width = 120;
            // 
            // colClassNameCht
            // 
            colClassNameCht.ClientAction = null;
            colClassNameCht.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colClassNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colClassNameCht.Image = null;
            colClassNameCht.Name = "colClassNameCht";
            colClassNameCht.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            colClassNameCht.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colClassNameCht.Width = 120;
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

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colClassCode,
            colLN,
            colClassId,
            colClassInitial,
            colClassName,
            colClassNameChs,
            colClassNameCht,
            colCreatedOn,
            colModifiedOn});

            #region show/ hide alt1 alt2
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    colClassNameCht.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    colClassNameChs.Visible = colClassNameCht.Visible = false;
                    break;
            }
            #endregion
        }
        #endregion

        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{E2322A52-36E3-4eb4-8A5D-391C44D17C98}");

            ListViewHelper.LoadPreference(ref lvList);
        }

        private void BindClassList()
        {
            this.lvList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(2)); // Class Code
                    objItem.SmallImage = new IconResourceHandle("16x16.Product16.gif");
                    objItem.LargeImage = new IconResourceHandle("16x16.Product16.gif");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); // ClassId
                    objItem.SubItems.Add(reader.GetString(3)); // Class Initial
                    objItem.SubItems.Add(reader.GetString(4)); // Class Name
                    objItem.SubItems.Add(reader.GetString(5)); // Class Name Chs
                    objItem.SubItems.Add(reader.GetString(6)); // Class name Cht
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(7), true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(8), true)); // ModifiedOn

                    iCount++;
                }
            }

            this.lvList.Sort(); // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效
        }

        #region Build Sql Query String
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append(this.TypeName);
            sql.Append("Id,  ROW_NUMBER() OVER (ORDER BY ");
            sql.Append(this.TypeName);
            sql.Append("Code) AS rownum, ISNULL(");
            sql.Append(this.TypeName);
            sql.Append("Code, ''), ISNULL(");
            sql.Append(this.TypeName);
            sql.Append("Initial, ''), ISNULL(");
            sql.Append(this.TypeName);
            sql.Append("Name, ''), ISNULL(");
            sql.Append(this.TypeName);
            sql.Append("Name_Chs, ''), ISNULL(");
            sql.Append(this.TypeName);
            sql.Append("Name_Cht, ''), ");
            sql.Append(" CreatedOn, ModifiedOn, CreatedBy, ModifiedBy ");
            sql.Append(" FROM Product");
            sql.Append(this.TypeName);
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
                sql.Append(this.TypeName);
                sql.Append("Code LIKE '%").Append(SearchForText).Append("%'");
                sql.Append(" OR ");
                sql.Append(this.TypeName);
                sql.Append("Name LIKE '%").Append(SearchForText).Append("%')");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            if (!(String.IsNullOrEmpty(AlphaSeacher)) && AlphaSeacher != "All")
            {
                sql.Append(String.Format(" AND ( SUBSTRING([" + this.TypeName + "Code], 1, 1) = N'{0}' )", AlphaSeacher));
            }

            sql.Append(" AND Retired = 0 ");
            sql.Append(" ORDER BY " + this.TypeName + "Code ");

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
                    //ProductClassWizard wizProd = new ProductClassWizard(new System.Guid(lvList.SelectedItem.SubItems[2].Text));
                    //var id = new System.Guid(lvList.SelectedItem.SubItems[2].Text);
                    var wizProd = new ProductClassWizard()
                    {
                        ClassId = id,
                        ClassMode = ProductHelper.Classes.Class1,
                        EditMode = EnumHelper.EditMode.Edit
                    };

                    wizProd.Closed += new EventHandler(wizProd_Closed);
                    wizProd.ShowDialog();
                }
            }
        }

        void wizProd_Closed(object sender, EventArgs e)
        {
            ProductClassWizard wizProd = sender as ProductClassWizard;
            if (wizProd.ClassId != System.Guid.Empty)
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