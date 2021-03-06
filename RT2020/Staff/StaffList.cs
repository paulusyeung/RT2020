#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using Gizmox.WebGUI.Common.Resources;
using System.Data.SqlClient;
using System.Configuration;
using RT2020.Helper;
using RT2020.Components;

#endregion

namespace RT2020.Staff
{
    public partial class StaffList : RT2020.Controls.DefaultListBase
    {
        private Guid PageId = new Guid("3553565B-9484-4310-9763-1E0F130101CB");     // 2007.12.22 paulus: PageId used in StaffPreference
        private FAB fab = new FAB();    // floating action button: Add New Supplier

        public StaffList()
        {
            InitializeComponent();

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

            tbControl.Visible = false;
        }

        private void fab_OnClick(object sender, EventArgs e)
        {
            var wizard = new StaffWizard();
            wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.ShowDialog();
        }

        public override void BindList()
        {
            BindStaffList();
        }

        #region Bind Staff List

        #region List View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colStaffId = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colStaffNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colStaffCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colFullName = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colFullName_Chs = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colFullName_Cht = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new Gizmox.WebGUI.Forms.ColumnHeader();
            // 
            // columnStaffId
            // 
            colStaffId.ClientAction = null;
            colStaffId.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colStaffId.Image = null;
            colStaffId.Name = "colStaffId";
            colStaffId.Tag = "StaffId";
            colStaffId.Text = "StaffId";
            colStaffId.TextAlign = HorizontalAlignment.Left;
            colStaffId.Visible = false;
            colStaffId.Width = 150;
            // 
            // columnLN
            // 
            colLN.ClientAction = null;
            colLN.ContentAlign = ExtendedHorizontalAlignment.Center;
            colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colLN.Image = null;
            colLN.Name = "colLN";
            colLN.Tag = "LN";
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colLN.TextAlign = HorizontalAlignment.Center;
            colLN.Width = 35;
            // 
            // columnStaffNumber
            // 
            colStaffNumber.ClientAction = null;
            colStaffNumber.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colStaffNumber.Image = null;
            colStaffNumber.Name = "colStaffNumber";
            colStaffNumber.Tag = "StaffNumber";
            colStaffNumber.Text = WestwindHelper.GetWord("staff.number", "Model");
            colStaffNumber.TextAlign = HorizontalAlignment.Left;
            colStaffNumber.Width = 80;
            // 
            // columnStaffCode
            // 
            colStaffCode.ClientAction = null;
            colStaffCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colStaffCode.Image = null;
            colStaffCode.Name = "colStaffCode";
            colStaffCode.Tag = "StaffInitial";
            colStaffCode.Text = WestwindHelper.GetWord("staff.initial", "Model");
            colStaffCode.TextAlign = HorizontalAlignment.Left;
            colStaffCode.Width = 80;
            // 
            // columnFullName
            // 
            colFullName.ClientAction = null;
            colFullName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colFullName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colFullName.Image = null;
            colFullName.Name = "colFullName";
            colFullName.Tag = "FullName";
            colFullName.Text = WestwindHelper.GetWord("staff.fullName", "Model");
            colFullName.TextAlign = HorizontalAlignment.Left;
            colFullName.Width = 120;
            // 
            // columnFullName_Chs
            // 
            colFullName_Chs.ClientAction = null;
            colFullName_Chs.ContentAlign = ExtendedHorizontalAlignment.Center;
            colFullName_Chs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colFullName_Chs.Image = null;
            colFullName_Chs.Name = "colFullName_Chs";
            colFullName_Chs.Tag = "FullName_Chs";
            colFullName_Chs.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colFullName_Chs.TextAlign = HorizontalAlignment.Left;
            colFullName_Chs.Width = 120;
            // 
            // columnFullName_Cht
            // 
            colFullName_Cht.ClientAction = null;
            colFullName_Cht.ContentAlign = ExtendedHorizontalAlignment.Center;
            colFullName_Cht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colFullName_Cht.Image = null;
            colFullName_Cht.Name = "colFullName_Cht";
            colFullName_Cht.Tag = "FullName_Cht";
            colFullName_Cht.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            colFullName_Cht.TextAlign = HorizontalAlignment.Left;
            colFullName_Cht.Width = 120;
            // 
            // columnCreatedOn
            // 
            colCreatedOn.ClientAction = null;
            colCreatedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCreatedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colCreatedOn.Image = null;
            colCreatedOn.Name = "colCreatedOn";
            colCreatedOn.Tag = "CreatedOn";
            colCreatedOn.Text = WestwindHelper.GetWord("glossary.createdOn", "General");
            colCreatedOn.TextAlign = HorizontalAlignment.Left;
            colCreatedOn.Width = 100;
            // 
            // columnModifiedOn
            // 
            colModifiedOn.ClientAction = null;
            colModifiedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colModifiedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colModifiedOn.Image = null;
            colModifiedOn.Name = "colModifiedOn";
            colModifiedOn.Tag = "ModifiedOn";
            colModifiedOn.Text = WestwindHelper.GetWord("glossary.modifiedOn", "General");
            colModifiedOn.TextAlign = HorizontalAlignment.Left;
            colModifiedOn.Width = 100;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colStaffNumber,
            colLN,
            colStaffId,
            colStaffCode,
            colFullName,
            colFullName_Chs,
            colFullName_Cht,
            colCreatedOn,
            colModifiedOn});

            #region show/ hide alt1 alt2
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    colFullName_Cht.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    colFullName_Chs.Visible = colFullName_Cht.Visible = false;
                    break;
            }
            #endregion
        }
        #endregion

        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{6F24B254-ACFF-485f-9EE2-58C5F75DB672}");

            ListViewHelper.LoadPreference(ref lvList);
        }


        private void BindStaffList()
        {
            this.lvList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();
            sql += " ORDER BY StaffNumber ";
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(1));
                    objItem.SmallImage = new IconResourceHandle("16x16.staffSingle_16.png");
                    objItem.LargeImage = new IconResourceHandle("16x16.staffSingle_16.png");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString());
                    objItem.SubItems.Add(reader.GetString(2)); // Initial
                    objItem.SubItems.Add(reader.GetString(3));
                    objItem.SubItems.Add(reader.GetString(4));
                    objItem.SubItems.Add(reader.GetString(5));
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(6), true));
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(8), true));

                    iCount++;
                }
            }
            this.lvList.Sort(); // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效

        }

        #region Build Sql Query String
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT [StaffId],[StaffNumber],[StaffCode],[FullName],[FullName_Chs],[FullName_Cht]");
            sql.Append(" ,[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy] ");
            sql.Append(" FROM [dbo].[vwStaffList] ");

            sql.Append(" WHERE Status >= 0 AND ");

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
                sql.Append(" AND (StaffNumber LIKE '%").Append(SearchForText).Append("%' ");
                sql.Append(" OR StaffCode LIKE '%").Append(SearchForText).Append("%' ");
                sql.Append(" OR FullName LIKE '%").Append(SearchForText).Append("%')");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            if (!(String.IsNullOrEmpty(AlphaSeacher)) && AlphaSeacher != "All")
            {
                sql.Append(String.Format(" AND ( SUBSTRING([StaffNumber], 1, 1) = N'{0}' )", AlphaSeacher));
            }

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
                    StaffWizard wizStaff = new StaffWizard();
                    wizStaff.EditMode = EnumHelper.EditMode.Edit;
                    wizStaff.StaffId = id;
                    wizStaff.Closed += new EventHandler(wizSupplier_Closed);
                    wizStaff.ShowDialog();
                }
            }
        }

        void wizSupplier_Closed(object sender, EventArgs e)
        {
            StaffWizard wizStaff = sender as StaffWizard;
            if (wizStaff.StaffId != System.Guid.Empty)
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