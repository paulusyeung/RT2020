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
using RT2020.Helper;
using RT2020.Components;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Product
{
    public partial class AnalysisCodeList : DefaultListBase
    {
        private Guid PageId = new Guid("15DB1A31-FC88-40FC-B6BC-D99A25A42771");     // 2007.12.22 paulus: PageId used in Preference
        private FAB fab = new FAB();    // floating action button: Add New Supplier

        public AnalysisCodeList(Control toolBar)
        {
            InitializeComponent();

            ProductToolbar tb = new ProductToolbar(toolBar, ref tbControl);

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
        }

        private void fab_OnClick(object sender, EventArgs e)
        {
            var wizard = new AnalysisCodeWizard();
            wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.ShowDialog();
        }

        public override void BindList()
        {
            BindAnalysisCodeList();
        }

        #region Bind AnalysisCode List

        #region Set Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colCodeId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colType = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCode = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colInitial = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colName = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colNameAlt1 = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colNameAlt2 = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();

            // 
            // colAnalysisCodeId
            // 
            colCodeId.ClientAction = null;
            colCodeId.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCodeId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colCodeId.Image = null;
            colCodeId.Name = "colCodeId";
            colCodeId.Text = "CodeId";
            colCodeId.TextAlign = HorizontalAlignment.Left;
            colCodeId.Visible = false;
            colCodeId.Width = 150;
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
            // colType
            // 
            colType.ClientAction = null;
            colType.ContentAlign = ExtendedHorizontalAlignment.Center;
            colType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colType.Image = null;
            colType.Name = "colType";
            colType.Text = WestwindHelper.GetWord("posAnalysisCode.type", "Model");
            colType.TextAlign = HorizontalAlignment.Left;
            colType.Width = 80;
            // 
            // colAnalysisCodeCode
            // 
            colCode.ClientAction = null;
            colCode.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colCode.Image = null;
            colCode.Name = "colCode";
            colCode.Text = WestwindHelper.GetWord("posAnalysisCode.code", "Model");
            colCode.TextAlign = HorizontalAlignment.Left;
            colCode.Width = 80;
            // 
            // colAnalysisCodeInitial
            // 
            colInitial.ClientAction = null;
            colInitial.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colInitial.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colInitial.Image = null;
            colInitial.Name = "colInitial";
            colInitial.Text = WestwindHelper.GetWord("posAnalysisCode.initial", "Model");
            colInitial.TextAlign = HorizontalAlignment.Left;
            colInitial.Width = 80;
            // 
            // colAnalysisCodeName
            // 
            colName.ClientAction = null;
            colName.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colName.Image = null;
            colName.Name = "colName";
            colName.Text = WestwindHelper.GetWord("posAnalysisCode.name", "Model");
            colName.TextAlign = HorizontalAlignment.Left;
            colName.Width = 120;
            // 
            // colAnalysisCodeNameChs
            // 
            colNameAlt2.ClientAction = null;
            colNameAlt2.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colNameAlt2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colNameAlt2.Image = null;
            colNameAlt2.Name = "colNameAlt2";
            colNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colNameAlt2.TextAlign = HorizontalAlignment.Left;
            colNameAlt2.Width = 120;
            // 
            // colAnalysisCodeNameCht
            // 
            colNameAlt1.ClientAction = null;
            colNameAlt1.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colNameAlt1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colNameAlt1.Image = null;
            colNameAlt1.Name = "colNameAlt1";
            colNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            colNameAlt1.TextAlign = HorizontalAlignment.Left;
            colNameAlt1.Width = 120;
            // 
            // colCreatedOn
            // 
            colCreatedOn.ClientAction = null;
            colCreatedOn.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colCreatedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colCreatedOn.Image = null;
            colCreatedOn.Name = "colCreatedOn";
            colCreatedOn.Text = WestwindHelper.GetWord("glossary.createdOn", "General");
            colCreatedOn.TextAlign = HorizontalAlignment.Left;
            colCreatedOn.Width = 100;
            // 
            // colModifiedOn
            // 
            colModifiedOn.ClientAction = null;
            colModifiedOn.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colModifiedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colModifiedOn.Image = null;
            colModifiedOn.Name = "colModifiedOn";
            colModifiedOn.Text = WestwindHelper.GetWord("glossary.modifiedOn", "General");
            colModifiedOn.TextAlign = HorizontalAlignment.Left;
            colModifiedOn.Width = 100;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colCode,
            colLN,
            colCodeId,
            colType,
            colInitial,
            colName,
            colNameAlt2,
            colNameAlt1,
            colCreatedOn,
            colModifiedOn});

            #region show/ hide alt1 alt2
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    colNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    colNameAlt1.Visible = colNameAlt2.Visible = false;
                    break;
            }
            #endregion
        }
        #endregion

        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{952898E5-BC7E-4b3f-B8D2-464DE67FC417}");

            ListViewHelper.LoadPreference(ref lvList);
        }

        private void BindAnalysisCodeList()
        {
            this.lvList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PosAnalysisCode
                    .SqlQuery(string.Format("Select * {0}", sql.Substring(sql.LastIndexOf("FROM"))))
                    .AsNoTracking()
                    .ToList();

                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvList.Items.Add(item.AnalysisCode); // AnalysisCode Type
                    objItem.SmallImage = new IconResourceHandle("16x16.Product16.gif");
                    objItem.LargeImage = new IconResourceHandle("16x16.Product16.gif");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.AnalysisCodeId.ToString());
                    objItem.SubItems.Add(item.AnalysisType);
                    objItem.SubItems.Add(item.CodeInitial); // AnalysisCode Initial
                    objItem.SubItems.Add(item.CodeName); // AnalysisCode Name
                    objItem.SubItems.Add(item.CodeName_Chs); // AnalysisCode Name Chs
                    objItem.SubItems.Add(item.CodeName_Cht); // AnalysisCode name Cht
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.CreatedOn, true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.ModifiedOn, true)); // ModifiedOn


                    iCount++;
                }
            }
            /**
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(3)); // AnalysisCode Type
                    objItem.SmallImage = new IconResourceHandle("16x16.Product16.gif");
                    objItem.LargeImage = new IconResourceHandle("16x16.Product16.gif");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); // AnalysisCodeId
                    objItem.SubItems.Add(reader.GetString(2)); // AnalysisCode Code
                    objItem.SubItems.Add(reader.GetString(4)); // AnalysisCode Initial
                    objItem.SubItems.Add(reader.GetString(5)); // AnalysisCode Name
                    objItem.SubItems.Add(reader.GetString(6)); // AnalysisCode Name Chs
                    objItem.SubItems.Add(reader.GetString(7)); // AnalysisCode name Cht
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(9), true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(10), true)); // ModifiedOn

                    iCount++;
                }
            }
            */

            this.lvList.Sort(); // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效
        }

        #region Build Sql Query String
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT AnalysisCodeId,  ROW_NUMBER() OVER (ORDER BY AnalysisCode) AS rownum, ");
            sql.Append(" AnalysisType, AnalysisCode, CodeInitial, CodeName, CodeName_Chs, CodeName_Cht, Mandatory, ");
            sql.Append(" CreatedOn, ModifiedOn, CreatedBy, ModifiedBy ");
            sql.Append(" FROM PosAnalysisCode ");
            sql.Append(" WHERE 1 = 1 ");

            switch (SelectedViewIndex)
            {
                case 0: // Last 7 days
                    sql.Append(" AND (CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME))");
                    break;
                case 1: // Last 14 days
                    sql.Append(" AND (CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-14).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME))");
                    break;
                case 2: // Last 30 days
                    sql.Append(" AND (CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME))");
                    break;
                case 3: // Last 60 days
                    sql.Append(" AND (CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-60).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME))");
                    break;
                case 4: // Last 90 days
                    sql.Append(" AND (CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-90).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME))");
                    break;
                case 5: // All
                default:
                    sql.Append("");
                    break;
            }

            if (!string.IsNullOrEmpty(SearchForText))
            {
                sql.Append(" AND (AnalysisCode LIKE '%").Append(SearchForText).Append("%'");
                sql.Append(" OR CodeName LIKE '%").Append(SearchForText).Append("%')");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            if (!(String.IsNullOrEmpty(AlphaSeacher)) && AlphaSeacher != "All")
            {
                sql.Append(String.Format(" AND ( SUBSTRING([AnalysisCode], 1, 1) = N'{0}' )", AlphaSeacher));
            }

            sql.Append(" ORDER BY AnalysisCode ");

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
                    AnalysisCodeWizard wizAC = new AnalysisCodeWizard();
                    wizAC.EditMode = EnumHelper.EditMode.Edit;
                    wizAC.AnalysisCodeId = id;
                    wizAC.Closed += new EventHandler(wizAC_Closed);
                    wizAC.ShowDialog();
                }
            }
        }

        void wizAC_Closed(object sender, EventArgs e)
        {
            AnalysisCodeWizard wizAC = sender as AnalysisCodeWizard;
            if (wizAC.AnalysisCodeId != System.Guid.Empty)
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