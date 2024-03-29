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

namespace RT2020.PriceMgmt
{
    public partial class PriceMgmtList : DefaultListBase
    {
        private Guid PageId = new Guid("626FDC72-57D2-4DC2-9C8C-3DF1BC1B2763");     // 2007.12.22 paulus: PageId used in Preference
        private FAB fab = new FAB();    // floating action button: Add New Supplier

        #region public properties
        private EnumHelper.PriceMgmtPMType _ListType = EnumHelper.PriceMgmtPMType.None;
        public EnumHelper.PriceMgmtPMType ListType
        {
            get { return _ListType; }
            set { _ListType = value; }
        }
        #endregion

        public PriceMgmtList(Control toolBar, EnumHelper.PriceMgmtPMType listType)
        {
            InitializeComponent();

            PriceToolbar tb = new PriceToolbar(toolBar, ref tbControl);

            this.ListType = listType;

            base.ExportClick += new MenuEventHandler(DefaultList_ExportClick);
            base.RefreshClick += new EventHandler(DefaultList_RefreshClick);
            base.PreferenceClick += new EventHandler(DefaultList_PreferenceClick);
            base.BindingListDoubleClick += new EventHandler(DefaultList_BindingListDoubleClick);
            base.ComboBoxSelectedIndexChanged += new EventHandler(DefaultList_ComboBoxSelectedIndexChanged);
            base.ButtonClick += new EventHandler(DefaultList_ButtonClick);
            base.ShowClick += new EventHandler(DefaultList_ShowClick);

            fab.Location = new Point(this.Size.Width - 80, this.Height - 72);
            fab.Click += fab_OnClick;
            this.Controls.Add(fab);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetColumns();
            BindList();
            SetLvwList();

            alphaBinding.Visible = false;
        }

        private void fab_OnClick(object sender, EventArgs e)
        {
            var wizard = new PriceMgmtWizard();
            wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.TxType = EnumHelper.PriceMgmtTxType.PMC;
            wizard.PMType = _ListType;
            wizard.ShowDialog();
        }

        public override void BindList()
        {
            BindPriceList();
        }

        #region Bind Price List

        #region Set View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colTxNumber = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colHeaderId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colEffectDate = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colReasonCode = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colRemarks = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();

            // 
            // colHeaderId
            // 
            colHeaderId.Image = null;
            colHeaderId.Name = "colHeaderId";
            colHeaderId.Text = "HeaderId";
            colHeaderId.Visible = false;
            colHeaderId.Width = 150;
            // 
            // colLN
            // 
            colLN.ContentAlign = ExtendedHorizontalAlignment.Center;
            colLN.Image = null;
            colLN.Name = "colLN";
            colLN.Text = Utility.Dictionary.GetWord("LN");
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
            colTxNumber.Width = 100;
            // 
            // colEffectDate
            // 
            colEffectDate.ContentAlign = ExtendedHorizontalAlignment.Center;
            colEffectDate.Image = null;
            colEffectDate.Name = "colEffectDate";
            colEffectDate.Text = Utility.Dictionary.GetWord("Effective Date");
            colEffectDate.TextAlign = HorizontalAlignment.Left;
            colEffectDate.Width = 80;
            // 
            // colReasonCode
            // 
            colReasonCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colReasonCode.Image = null;
            colReasonCode.Name = "colReasonCode";
            colReasonCode.Text = Utility.Dictionary.GetWord("Reason");
            colReasonCode.TextAlign = HorizontalAlignment.Left;
            colReasonCode.Width = 80;
            // 
            // colRemarks
            // 
            colRemarks.ContentAlign = ExtendedHorizontalAlignment.Center;
            colRemarks.Image = null;
            colRemarks.Name = "colRemarks";
            colRemarks.Text = Utility.Dictionary.GetWord("Remarks");
            colRemarks.TextAlign = HorizontalAlignment.Left;
            colRemarks.Width = 120;
            // 
            // colCreatedOn
            // 
            colCreatedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCreatedOn.Image = null;
            colCreatedOn.Name = "colCreatedOn";
            colCreatedOn.Text = Utility.Dictionary.GetWord("CreatedOn");
            colCreatedOn.TextAlign = HorizontalAlignment.Left;
            colCreatedOn.Width = 100;
            // 
            // colModifiedOn
            // 
            colModifiedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colModifiedOn.Image = null;
            colModifiedOn.Name = "colModifiedOn";
            colModifiedOn.Text = Utility.Dictionary.GetWord("ModifiedOn");
            colModifiedOn.TextAlign = HorizontalAlignment.Left;
            colModifiedOn.Width = 100;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colTxNumber,
            colLN,
            colHeaderId,
            colEffectDate,
            colReasonCode,
            colRemarks,
            colCreatedOn,
            colModifiedOn});
        }
        #endregion

        /// <summary>
        /// Binds the Price list.
        /// </summary>
        /// 
        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("7D760FA5-A2B9-4FE3-BAE2-563BDB4D1232");

            ListViewHelper.LoadPreference(ref lvList);
        }

        private void BindPriceList()
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
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(1)); // Tx Number
                    objItem.SmallImage = new IconResourceHandle("16x16.flag_green.png");
                    objItem.LargeImage = new IconResourceHandle("16x16.flag_green.png");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); // HeaderId
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(3), false)); // Effective Date
                    objItem.SubItems.Add(reader.GetString(5)); // Reason Code
                    objItem.SubItems.Add(reader.GetString(6)); // Remarks
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(7), true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(8), true)); // ModifiedOn

                    iCount++;
                }
            }
            this.lvList.Sort(); // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效
        }

        #region Build Sql Query String

        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <returns></returns>
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT HeaderId, TxNumber, TxType, EffectDate, PM_TYPE, 
                (CASE WHEN PriceManagementBatchHeader.ReasonId IS NOT NULL THEN (SELECT ReasonCode FROM PriceManagementReason WHERE ReasonId = PriceManagementBatchHeader.ReasonId)
                ELSE '' END) AS ReasonCode, Remarks, ");
            sql.Append(" CreatedOn, ModifiedOn, CreatedBy, ModifiedBy ");
            sql.Append(" FROM PriceManagementBatchHeader ");
            sql.Append(" WHERE 1 = 1 ");
            sql.Append(" AND PM_TYPE = '").Append(this.ListType.ToString().Substring(0, 1)).Append("'");

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
                sql.Append(" AND TxNumber LIKE '%").Append(SearchForText).Append("%'");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            sql.Append(" ORDER BY TxNumber ");

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
                    PriceMgmtWizard wizList = new PriceMgmtWizard();
                    wizList.EditMode = EnumHelper.EditMode.Edit;
                    wizList.HeaderId = id;
                    wizList.TxType = EnumHelper.PriceMgmtTxType.PMC;
                    wizList.PMType = _ListType;
                    wizList.Closed += new EventHandler(wizList_Closed);
                    wizList.ShowDialog();
                }
            }
        }

        void wizList_Closed(object sender, EventArgs e)
        {
            PriceMgmtWizard wizList = sender as PriceMgmtWizard;
            if (wizList.HeaderId != System.Guid.Empty)
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