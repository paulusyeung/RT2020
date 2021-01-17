#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;
using Gizmox.WebGUI.Common.Resources;
using RT2020.Controls;
using System.Configuration;
using RT2020.Helper;
using System.Linq;
using RT2020.Components;

#endregion

namespace RT2020.Workplace
{
    public partial class WorkplaceList : Controls.DefaultListBase
    {
        private FAB fab = new FAB();    // floating action button: Add New Supplier

        public WorkplaceList()
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
            var wizard = new WorkplaceWizard();
            wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.ShowDialog();
        }

        public override void BindList()
        {
            BindWorkplaceList();
        }

        #region Bind Workplace List

        #region List View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceId = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceInitial = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceName = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colEmail = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new Gizmox.WebGUI.Forms.ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new Gizmox.WebGUI.Forms.ColumnHeader();

            // 
            // colWorkplaceId
            // 
            colWorkplaceId.Name = "colWorkplaceId";
            colWorkplaceId.ClientAction = null;
            colWorkplaceId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colWorkplaceId.Image = null;
            colWorkplaceId.Name = "colWorkplaceId";
            colWorkplaceId.Text = "WorkplaceId";
            colWorkplaceId.Visible = false;
            colWorkplaceId.Width = 150;
            // 
            // colLN
            // 
            colLN.Name = "colLN";
            colLN.ClientAction = null;
            colLN.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colLN.Image = null;
            colLN.Name = "colLN";
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            colLN.Width = 30;
            // 
            // colWorkplaceCode
            // 
            colWorkplaceCode.Name = "colWorkplaceCode";
            colWorkplaceCode.ClientAction = null;
            colWorkplaceCode.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colWorkplaceCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colWorkplaceCode.Image = null;
            colWorkplaceCode.Name = "colWorkplaceCode";
            colWorkplaceCode.Text = WestwindHelper.GetWord("workplace.code", "Model");
            colWorkplaceCode.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colWorkplaceCode.Width = 80;
            // 
            // colWorkplaceInitial
            // 
            colWorkplaceInitial.Name = "colWorkplaceInitial";
            colWorkplaceInitial.ClientAction = null;
            colWorkplaceInitial.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colWorkplaceInitial.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colWorkplaceInitial.Image = null;
            colWorkplaceInitial.Name = "colWorkplaceInitial";
            colWorkplaceInitial.Text = WestwindHelper.GetWord("workplace.initial", "Model");
            colWorkplaceInitial.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colWorkplaceInitial.Width = 80;
            // 
            // colWorkplaceName
            // 
            colWorkplaceName.Name = "colWorkplaceName";
            colWorkplaceName.ClientAction = null;
            colWorkplaceName.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colWorkplaceName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colWorkplaceName.Image = null;
            colWorkplaceName.Name = "colWorkplaceName";
            colWorkplaceName.Text = WestwindHelper.GetWord("workplace.name", "Model");
            colWorkplaceName.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colWorkplaceName.Width = 120;
            // 
            // colWorkplaceNameChs
            // 
            colWorkplaceNameChs.Name = "colWorkplaceNameChs";
            colWorkplaceNameChs.ClientAction = null;
            colWorkplaceNameChs.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colWorkplaceNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colWorkplaceNameChs.Image = null;
            colWorkplaceNameChs.Name = "colWorkplaceNameChs";
            colWorkplaceNameChs.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colWorkplaceNameChs.TextAlign = HorizontalAlignment.Left;
            colWorkplaceNameChs.Width = 120;
            // 
            // colWorkplaceNameCht
            // 
            colWorkplaceNameCht.Name = "colWorkplaceNameCht";
            colWorkplaceNameCht.ClientAction = null;
            colWorkplaceNameCht.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colWorkplaceNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colWorkplaceNameCht.Image = null;
            colWorkplaceNameCht.Name = "colWorkplaceNameCht";
            colWorkplaceNameCht.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            colWorkplaceNameCht.TextAlign = HorizontalAlignment.Left;
            colWorkplaceNameCht.Width = 120;
            // 
            // colEmail
            // 
            colEmail.Name = "colEmail";
            colEmail.ClientAction = null;
            colEmail.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colEmail.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colEmail.Image = null;
            colEmail.Name = "colEmail";
            colEmail.Text = WestwindHelper.GetWord("workplace.email", "Model");
            colEmail.TextAlign = HorizontalAlignment.Left;
            colEmail.Width = 120;
            // 
            // colCreatedOn
            // 
            colCreatedOn.Name = "colCreatedOn";
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
            colModifiedOn.Name = "colModifiedOn";
            colModifiedOn.ClientAction = null;
            colModifiedOn.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colModifiedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colModifiedOn.Image = null;
            colModifiedOn.Name = "colModifiedOn";
            colModifiedOn.Text = WestwindHelper.GetWord("glossary.modifiedOn", "General");
            colModifiedOn.TextAlign = HorizontalAlignment.Left;
            colModifiedOn.Width = 100;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colWorkplaceCode,
            colLN,
            colWorkplaceId,
            colWorkplaceInitial,
            colWorkplaceName,
            colWorkplaceNameChs,
            colWorkplaceNameCht,
            colEmail,
            colCreatedOn,
            colModifiedOn});

            #region show/ hide alt1 alt2
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    colWorkplaceNameCht.Visible = false;
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    colWorkplaceNameChs.Visible = colWorkplaceNameCht.Visible = false;
                    break;
            }
            #endregion
        }
        #endregion

        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{CD2A7928-69A9-4c79-8D69-5A5BA8842076}");

            ListViewHelper.LoadPreference(ref lvList);
        }


        public void BindWorkplaceList()
        {
            this.lvList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString() + " Order By [WorkplaceCode]";

            using (var ctx = new EF6.RT2020Entities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;

                var where = string.Format("Select * {0}", sql.Substring(sql.LastIndexOf("FROM")));
                var list = ctx.vwWorkplaceList.SqlQuery(where).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvList.Items.Add(item.WorkplaceCode);
                    objItem.SmallImage = new IconResourceHandle("16x16.ico_16_4000.gif");
                    objItem.LargeImage = new IconResourceHandle("16x16.ico_16_4000.gif");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.WorkplaceId.ToString());
                    objItem.SubItems.Add(item.WorkplaceInitial);
                    objItem.SubItems.Add(item.WorkplaceName);
                    objItem.SubItems.Add(item.WorkplaceName_Chs);
                    objItem.SubItems.Add(item.WorkplaceName_Cht);
                    objItem.SubItems.Add(item.Email);
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
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(2)); // WorkplaceId
                    objItem.SmallImage = new IconResourceHandle("16x16.ico_16_4000.gif");
                    objItem.LargeImage = new IconResourceHandle("16x16.ico_16_4000.gif");
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); // WorkplaceCode
                    objItem.SubItems.Add(reader.GetString(3)); // Workplace Initial
                    objItem.SubItems.Add(reader.GetString(4)); // Workplace Name
                    objItem.SubItems.Add(reader.GetString(5)); // Workplace Name Chs
                    objItem.SubItems.Add(reader.GetString(6)); // Workplace name Cht
                    objItem.SubItems.Add(reader.GetString(7)); // Email
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(8), true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(9), true)); // ModifiedOn

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
            sql.Append("SELECT WorkplaceId,  ROW_NUMBER() OVER (ORDER BY WorkplaceCode) AS rownum, ");
            sql.Append(" WorkplaceCode, WorkplaceInitial, WorkplaceName, WorkplaceName_Chs, ");
            sql.Append(" WorkplaceName_Cht, ISNULL(Email, ''), ");
            sql.Append(" CreatedOn, ModifiedOn, CreatedBy, ModifiedBy ");
            sql.Append(" FROM vwWorkplaceList ");

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
                sql.Append(" AND (WorkplaceCode LIKE '%").Append(SearchForText).Append("%' ");
                sql.Append(" OR WorkplaceInitial LIKE '%").Append(SearchForText).Append("%' ");
                sql.Append(" OR WorkplaceName LIKE '%").Append(SearchForText).Append("%')");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            if (!(String.IsNullOrEmpty(AlphaSeacher)) && AlphaSeacher != "All")
            {
                sql.Append(String.Format(" AND ( SUBSTRING([WorkplaceCode], 1, 1) = N'{0}' )", AlphaSeacher));
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
                    WorkplaceWizard wizWorkplace = new WorkplaceWizard();
                    wizWorkplace.EditMode = EnumHelper.EditMode.Edit;
                    wizWorkplace.WorkplaceId = id;
                    wizWorkplace.Closed += (sender, e) =>
                    {
                        BindList();
                    };
                    wizWorkplace.ShowDialog();
                }
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