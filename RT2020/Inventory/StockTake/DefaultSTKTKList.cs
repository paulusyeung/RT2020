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

#endregion

namespace RT2020.Inventory.StockTake
{
    public partial class DefaultSTKTKList : DefaultListBase
    {
        private FAB fab = new FAB();    // floating action button: Add New STKTK

        public DefaultSTKTKList(Control toolBar)
        {
            InitializeComponent();

            //InvtToolbar tb = new InvtToolbar(toolBar, ref tbControl, InvtToolbar.FormType.Adjustment);

            base.ExportClick += new MenuEventHandler(DefaultList_ExportClick);
            base.RefreshClick += new EventHandler(DefaultList_RefreshClick);
            base.PreferenceClick += new EventHandler(DefaultList_PreferenceClick);
            base.BindingListDoubleClick += new EventHandler(DefaultList_BindingListDoubleClick);
            base.ComboBoxSelectedIndexChanged += new EventHandler(DefaultList_ComboBoxSelectedIndexChanged);
            base.ButtonClick += new EventHandler(DefaultList_ButtonClick);
            base.ShowClick += new EventHandler(DefaultList_ShowClick);

            fab.Location = new Point(this.Size.Width - 80, this.Height - 80);
            fab.Click += fab_OnClick;
            this.Controls.Add(fab);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetColumns();
            SetLvwList();

            tbControl.Visible = false;
            alphaBinding.Visible = false;

            //2013.07.05 paulus: 預設 view 7 days, Kennece added 2013.07.23
            this.cboView.SelectedIndex = 0;
        }

        private void fab_OnClick(object sender, EventArgs e)
        {
            var wizard = new Wizard();
            //wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.ShowDialog();
        }

        public override void BindList()
        {
            BindStkList();
        }

        #region Bind Stk List

        #region Set View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colInvtStkId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colTxNumber = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colTxDate = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colWorkplace = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colUploadedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCapturedOn = new ColumnHeader();

            // 
            // colInvtStkId
            // 
            colInvtStkId.Image = null;
            colInvtStkId.Name = "colInvtStkId";
            colInvtStkId.Text = "InvtStkId";
            colInvtStkId.Visible = false;
            colInvtStkId.Width = 150;
            // 
            // colLN
            // 
            colLN.ContentAlign = ExtendedHorizontalAlignment.Center;
            colLN.Image = null;
            colLN.Name = "colLN";
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colLN.TextAlign = HorizontalAlignment.Center;
            colLN.Width = 30;
            // 
            // colTxNumber
            // 
            colTxNumber.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTxNumber.Image = null;
            colTxNumber.Name = "colTxNumber";
            colTxNumber.Text = Utility.Dictionary.GetWord("TxNumber");
            colTxNumber.TextAlign = HorizontalAlignment.Left;
            colTxNumber.Width = 110;
            // 
            // colTxDate
            // 
            colTxDate.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTxDate.Image = null;
            colTxDate.Name = "colTxDate";
            colTxDate.Text = Utility.Dictionary.GetWord("TxDate");
            colTxDate.TextAlign = HorizontalAlignment.Left;
            colTxDate.Width = 80;
            // 
            // colWorkplace
            // 
            colWorkplace.ContentAlign = ExtendedHorizontalAlignment.Center;
            colWorkplace.Image = null;
            colWorkplace.Name = "colWorkplace";
            colWorkplace.Text = WestwindHelper.GetWord("workplace.code", "Model");
            colWorkplace.TextAlign = HorizontalAlignment.Center;
            colWorkplace.Width = 80;
            // 
            // colCapturedOn
            // 
            colCapturedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCapturedOn.Image = null;
            colCapturedOn.Name = "colCapturedOn";
            colCapturedOn.Text = Utility.Dictionary.GetWord("Captured On");
            colCapturedOn.TextAlign = HorizontalAlignment.Left;
            colCapturedOn.Width = 110;
            // 
            // colUploadedOn
            // 
            colUploadedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colUploadedOn.Image = null;
            colUploadedOn.Name = "colUploadedOn";
            colUploadedOn.Text = Utility.Dictionary.GetWord("Uploaded On");
            colUploadedOn.TextAlign = HorizontalAlignment.Left;
            colUploadedOn.Width = 100;
            // 
            // colCreatedOn
            // 
            colCreatedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCreatedOn.Image = null;
            colCreatedOn.Name = "colCreatedOn";
            colCreatedOn.Text = WestwindHelper.GetWord("glossary.createdOn", "General");
            colCreatedOn.TextAlign = HorizontalAlignment.Left;
            colCreatedOn.Width = 110;
            // 
            // colModifiedOn
            // 
            colModifiedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colModifiedOn.Image = null;
            colModifiedOn.Name = "colModifiedOn";
            colModifiedOn.Text = WestwindHelper.GetWord("glossary.modifiedOn", "General");
            colModifiedOn.TextAlign = HorizontalAlignment.Left;
            colModifiedOn.Width = 110;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colTxNumber,
            colLN,
            colInvtStkId,
            colTxDate,
            colWorkplace,
            colCapturedOn,
            colUploadedOn,
            colCreatedOn,
            colModifiedOn});
        }
        #endregion

        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{CA888AB8-E832-425d-B23C-6B7EDC4E84B2}");

            ListViewHelper.LoadPreference(ref lvList);
        }

        private void BindStkList()
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
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(1)); // TxNumber
                    objItem.SmallImage = reader.GetString(10) == "HOLD" ? new IconResourceHandle("16x16.flag_grey.png") : new IconResourceHandle("16x16.flag_green.png");
                    objItem.LargeImage = reader.GetString(10) == "HOLD" ? new IconResourceHandle("16x16.flag_grey.png") : new IconResourceHandle("16x16.flag_green.png");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); // StkHeaderId
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(2), false)); // TxDate
                    objItem.SubItems.Add(reader.GetString(3)); // WorkplaceCode
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(4), false)); // CapturedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(5), false)); // UploadedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(6), true)); // TransferredOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(8), true)); // CompletedOn

                    iCount++;
                }
            }

            this.lvList.Sort(); // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效
        }

        #region Build Sql Query String
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT HeaderId,TxNumber,TxDate,WorkplaceCode,CapturedOn,UploadedOn, ");
            sql.Append(@" CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,
    (
    CASE
        WHEN Status = 0 THEN 'HOLD'
        WHEN Status = 1 THEN 'POST'
    END
    ) AS Status ");
            sql.Append(" FROM vwDraftSTKList");
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
                sql.Append(" AND TxNumber LIKE '%").Append(SearchForText).Append("%'");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            sql.Append("ORDER BY TxNumber");

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
                Guid stkId = Guid.Empty;
                if (Guid.TryParse(lvList.SelectedItem.SubItems[2].Text, out stkId))
                {
                    RT2020.Inventory.StockTake.Wizard wizStk = new RT2020.Inventory.StockTake.Wizard(stkId);
                    wizStk.Closed += new EventHandler(wizStk_Closed);
                    wizStk.ShowDialog();
                }
            }
        }

        void wizStk_Closed(object sender, EventArgs e)
        {
            RT2020.Inventory.StockTake.Wizard wizStk = sender as RT2020.Inventory.StockTake.Wizard;
            if (wizStk.StkId != System.Guid.Empty)
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