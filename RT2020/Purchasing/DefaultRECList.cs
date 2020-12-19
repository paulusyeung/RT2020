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

#endregion

namespace RT2020.Purchasing
{
    public partial class DefaultRECList : Controls.DefaultListBase
    {
        public DefaultRECList()
        {
            InitializeComponent();

            base.ExportClick += new MenuEventHandler(DefaultList_ExportClick);
            base.RefreshClick += new EventHandler(DefaultList_RefreshClick);
            base.PreferenceClick += new EventHandler(DefaultList_PreferenceClick);
            base.BindingListDoubleClick += new EventHandler(DefaultList_BindingListDoubleClick);
            base.ComboBoxSelectedIndexChanged += new EventHandler(DefaultList_ComboBoxSelectedIndexChanged);
            base.ButtonClick += new EventHandler(DefaultList_ButtonClick);
            base.ShowClick += new EventHandler(DefaultList_ShowClick);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetColumns();
            SetLvwList();

            tbControl.Visible = false;
            alphaBinding.Visible = false;
        }

        public override void BindList()
        {
            BindPurchaseList();
        }

        #region Bind Purchase List

        #region List View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colTxNumber = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colOrderHeaderId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colOperator = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colTxDate = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLocation = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colSupplier = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();

            // 
            // colTxNumber
            // 
            colTxNumber.ClientAction = null;
            colTxNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colTxNumber.Image = null;
            colTxNumber.Text = Utility.Dictionary.GetWord("TxNumber");
            colTxNumber.Width = 110;
            // 
            // colLN
            // 
            colLN.ClientAction = null;
            colLN.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colLN.Image = null;
            colLN.Text = Utility.Dictionary.GetWord("LN");
            colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            colLN.Width = 30;
            // 
            // colOrderHeaderId
            // 
            colOrderHeaderId.ClientAction = null;
            colOrderHeaderId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colOrderHeaderId.Image = null;
            colOrderHeaderId.Text = "OrderHeaderId";
            colOrderHeaderId.Visible = false;
            colOrderHeaderId.Width = 150;
            // 
            // colTxDate
            // 
            colTxDate.ClientAction = null;
            colTxDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colTxDate.Image = null;
            colTxDate.Text = Utility.Dictionary.GetWord("TxDate");
            colTxDate.Width = 80;
            // 
            // colOperator
            // 
            colOperator.ClientAction = null;
            colOperator.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colOperator.Image = null;
            colOperator.Text = Utility.Dictionary.GetWord("Staff");
            colOperator.Width = 70;
            // 
            // colLocation
            // 
            colLocation.ClientAction = null;
            colLocation.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colLocation.Image = null;
            colLocation.Text = Utility.Dictionary.GetWord("Workplace");
            colLocation.Width = 70;
            // 
            // colSupplier
            // 
            colSupplier.ClientAction = null;
            colSupplier.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colSupplier.Image = null;
            colSupplier.Text = Utility.Dictionary.GetWord("Supplier");
            colSupplier.Width = 70;
            // 
            // colCreatedOn
            // 
            colCreatedOn.ClientAction = null;
            colCreatedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colCreatedOn.Image = null;
            colCreatedOn.Text = Utility.Dictionary.GetWord("CreatedOn");
            colCreatedOn.Width = 110;
            // 
            // colModifiedOn
            // 
            colModifiedOn.ClientAction = null;
            colModifiedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colModifiedOn.Image = null;
            colModifiedOn.Text = Utility.Dictionary.GetWord("ModifiedOn");
            colModifiedOn.Width = 110;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colTxNumber,
            colLN,
            colOrderHeaderId,
            colTxDate,
            colOperator,
            colLocation,
            colSupplier,
            colCreatedOn,
            colModifiedOn});
        }
        #endregion

        /// <summary>
        /// Binds the purchase list.
        /// </summary>
        
        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{96A324F5-3E7C-4834-9A0D-75527BBB3877}");

            RT2020.Controls.Preference.Load(ref lvList);
        }
        
        private void BindPurchaseList()
        {
            this.lvList.Items.Clear();   ////Çå³ýlisPurchaseOrderList¿Ø¼þÖÐµÄÊý¾Ý

            int iCount = 1;
            string sql = this.BuildSqlQueryString();
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvList.Items.Add(reader.IsDBNull(2) ? string.Empty : reader.GetString(2)); //// TxNumber 
                    objItem.SmallImage = reader.GetString(1) == "HOLD" ? new IconResourceHandle("16x16.flag_grey.png") : new IconResourceHandle("16x16.flag_green.png");
                    objItem.LargeImage = reader.GetString(1) == "HOLD" ? new IconResourceHandle("16x16.flag_grey.png") : new IconResourceHandle("16x16.flag_green.png");

                    objItem.SubItems.Add(iCount.ToString()); //// Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); ///// CAPHeaderId
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); //// TxDate
                    objItem.SubItems.Add(reader.IsDBNull(4) ? string.Empty : reader.GetString(4)); //// Operator
                    objItem.SubItems.Add(reader.IsDBNull(5) ? string.Empty : reader.GetString(5)); //// Location
                    objItem.SubItems.Add(reader.IsDBNull(6) ? string.Empty : reader.GetString(6)); //// SupplierInvoiceNumber
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(7), true)); //// CreatedOn
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(9), true)); //// ModifiedOn

                    iCount++;
                }
            }
            this.lvList.Sort(); // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效

        }

        #region Build Sql Query String
        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <returns>The joined Sql</returns>
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
SELECT ReceiveHeaderId,
    (
    CASE
        WHEN Status = 0 THEN 'HOLD'
        WHEN Status = 1 THEN 'POST'
    END
    ) AS Status, TxNumber, TxDate, StaffNumber, ");
            sql.Append(" Location, SupplierCode, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy ");
            sql.Append(" FROM vwReceivingList ");
            sql.Append(" WHERE 1 = 1 AND ");

            switch (SelectedViewIndex)
            {
                case 0: //// Last 7 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 1: //// Last 14 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-14).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 2: //// Last 30 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 3: //// Last 60 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-60).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 4: //// Last 90 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-90).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 5: //// All
                default:
                    sql.Append(" 1 = 1 ");
                    break;
            }

            if (!string.IsNullOrEmpty(SearchForText))
            {
                string objTxNumber = PurchasingUtils.GenSafeChars(SearchForText);
                sql.Append(" AND TxNumber LIKE '%").Append(objTxNumber).Append("%'");
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
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvList.SelectedItem.SubItems[2].Text, out id))
                {
                    RT2020.Purchasing.Wizard.Receiving phoList = new RT2020.Purchasing.Wizard.Receiving(id);
                    phoList.Closed += new EventHandler(wizSupplier_Closed);
                    phoList.ShowDialog();
                }
            }
        }

        void wizSupplier_Closed(object sender, EventArgs e)
        {
            RT2020.Purchasing.Wizard.Receiving pohList = sender as RT2020.Purchasing.Wizard.Receiving;
            if (pohList.ReceivingHeaderId != System.Guid.Empty)
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