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
using RT2020.Helper;
using RT2020.Components;

#endregion

namespace RT2020.Inventory.Transfer
{
    public partial class DefaultTXFList : DefaultListBase
    {
        private FAB fab = new FAB();    // floating action button: Add New TXF

        public DefaultTXFList(Control toolBar)
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

            //2013.07.05 paulus: 預設 view 7 days
            this.cboView.SelectedIndex = 0;
        }

        private void fab_OnClick(object sender, EventArgs e)
        {
            var wizard = new Wizard(EnumHelper.TxType.TXF);
            //wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.ShowDialog();
        }

        public override void BindList()
        {
            BindTxferList();
        }

        #region Bind Txfer List

        #region Set View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colInvtTxferId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colTxNumber = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colTxDate = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colOperator = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colFromLocation = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colToLocation = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colRemarks = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colTransferredOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCompletedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colTxType = new ColumnHeader();

            // 
            // colInvtTxferId
            // 
            colInvtTxferId.Image = null;
            colInvtTxferId.Name = "colInvtTxferId";
            colInvtTxferId.Text = "InvtTxferId";
            colInvtTxferId.Visible = false;
            colInvtTxferId.Width = 150;
            // 
            // colLN
            // 
            colLN.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colLN.Image = null;
            colLN.Name = "colLN";
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
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
            // colOperator
            // 
            colOperator.ContentAlign = ExtendedHorizontalAlignment.Center;
            colOperator.Image = null;
            colOperator.Name = "colOperator";
            colOperator.Text = WestwindHelper.GetWord("staff.number", "Model");
            colOperator.TextAlign = HorizontalAlignment.Left;
            colOperator.Width = 70;
            // 
            // colFromLocation
            // 
            colFromLocation.ContentAlign = ExtendedHorizontalAlignment.Center;
            colFromLocation.Image = null;
            colFromLocation.Name = "colFromLocation";
            colFromLocation.Text = Utility.Dictionary.GetWord("From_location");
            colFromLocation.TextAlign = HorizontalAlignment.Center;
            colFromLocation.Width = 80;
            // 
            // colToLocation
            // 
            colToLocation.ContentAlign = ExtendedHorizontalAlignment.Center;
            colToLocation.Image = null;
            colToLocation.Name = "colToLocation";
            colToLocation.Text = Utility.Dictionary.GetWord("To_location");
            colToLocation.TextAlign = HorizontalAlignment.Center;
            colToLocation.Width = 80;
            // 
            // colTransferredOn
            // 
            colTransferredOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTransferredOn.Image = null;
            colTransferredOn.Name = "colTransferredOn";
            colTransferredOn.Text = Utility.Dictionary.GetWord("Transfer Date");
            colTransferredOn.TextAlign = HorizontalAlignment.Left;
            colTransferredOn.Width = 80;
            // 
            // colCompletedOn
            // 
            colCompletedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCompletedOn.Image = null;
            colCompletedOn.Name = "colCompletedOn";
            colCompletedOn.Text = Utility.Dictionary.GetWord("Completion Date");
            colCompletedOn.TextAlign = HorizontalAlignment.Left;
            colCompletedOn.Width = 80;
            // 
            // colRemarks
            // 
            colRemarks.ContentAlign = ExtendedHorizontalAlignment.Center;
            colRemarks.Image = null;
            colRemarks.Name = "colRemarks";
            colRemarks.Text = Utility.Dictionary.GetWord("Remarks");
            colRemarks.TextAlign = HorizontalAlignment.Left;
            colRemarks.Width = 150;
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
            // 
            // colTxType
            // 
            colTxType.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTxType.Image = null;
            colTxType.Name = "colTxType";
            colTxType.Text = Utility.Dictionary.GetWord("TxType");
            colTxType.TextAlign = HorizontalAlignment.Left;
            colTxType.Width = 50;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colTxNumber,
            colLN,
            colInvtTxferId,
            colTxType,
            colTxDate,
            colOperator,
            colFromLocation,
            colToLocation,
            colTransferredOn,
            colCompletedOn,
            colRemarks,
            colCreatedOn,
            colModifiedOn});
        }
        #endregion

        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{DBB38641-0F9A-4dbc-94EB-9B032DE97DA7}");

            ListViewHelper.LoadPreference(ref lvList);
        }

        private void BindTxferList()
        {
            this.lvList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(2)); // TxNumber
                    objItem.SmallImage = reader.GetString(1) == "HOLD" ? new IconResourceHandle("16x16.flag_grey.png") : new IconResourceHandle("16x16.flag_green.png");
                    objItem.LargeImage = reader.GetString(1) == "HOLD" ? new IconResourceHandle("16x16.flag_grey.png") : new IconResourceHandle("16x16.flag_green.png");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); // TxferHeaderId
                    objItem.SubItems.Add(reader.GetString(14)); // TxType
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                    objItem.SubItems.Add(reader.GetString(4)); // StaffNumber
                    objItem.SubItems.Add(reader.GetString(5)); // FromLocation
                    objItem.SubItems.Add(reader.GetString(6)); // ToLocation
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(7), false)); // TransferredOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(8), false)); // CompletedOn
                    objItem.SubItems.Add(reader.GetString(9)); // Remarks
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(10), true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(12), true)); // ModifiedOn

                    iCount++;
                }
            }
            this.lvList.Sort();        // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效
        }

        #region Build Sql Query String
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
SELECT HeaderId,
    (
    CASE
        WHEN Status = 0 THEN 'HOLD'
        WHEN Status = 1 THEN 'POST'
    END
    ) AS Status,
TxNumber, TxDate, StaffNumber, ");
            sql.Append(" FromLocation, ToLocation, TransferredOn, CompletedOn, Remarks, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, TxType ");
            sql.Append(" FROM vwDraftTxferList ");
            sql.Append(" WHERE POSTNEG = 0 AND");

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

            sql.Append("ORDER BY TxNumber DESC");

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
                    RT2020.Inventory.Transfer.Wizard wizTxfer = new RT2020.Inventory.Transfer.Wizard(id);
                    wizTxfer.Closed += new EventHandler(wizREJ_Closed);
                    wizTxfer.ShowDialog();
                }
            }
        }

        void wizREJ_Closed(object sender, EventArgs e)
        {
            RT2020.Inventory.Transfer.Wizard wizTxfer = sender as RT2020.Inventory.Transfer.Wizard;
            if (wizTxfer.TxferId != System.Guid.Empty)
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