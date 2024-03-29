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
using RT2020.Controls;
using Gizmox.WebGUI.Common.Resources;
using System.Configuration;
using RT2020.Common.Helper;

#endregion

namespace RT2020.Purchasing
{
    public partial class DefaultPOList : Controls.DefaultListBase
    {
        public DefaultPOList()
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
            Gizmox.WebGUI.Forms.ColumnHeader colOrderHeaderId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colOrderNumber = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colStatus = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colOrderOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLocation = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colSupplier = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colRemarks = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colStaffNumber = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();

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
            // colOrderNumber
            // 
            colOrderNumber.ClientAction = null;
            colOrderNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colOrderNumber.Image = null;
            colOrderNumber.Text = Utility.Dictionary.GetWord("OrderNumber");
            colOrderNumber.Width = 110;
            // 
            // colStaffNumber
            // 
            colStaffNumber.ClientAction = null;
            colStaffNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colStaffNumber.Image = null;
            colStaffNumber.Text = Utility.Dictionary.GetWord("Staff Number");
            colStaffNumber.Width = 70;
            // 
            // colOrderOn
            // 
            colOrderOn.ClientAction = null;
            colOrderOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colOrderOn.Image = null;
            colOrderOn.Text = Utility.Dictionary.GetWord("OrderOn");
            colOrderOn.Width = 80;
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
            // colRemarks
            // 
            colRemarks.ClientAction = null;
            colRemarks.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colRemarks.Image = null;
            colRemarks.Text = Utility.Dictionary.GetWord("Remarks");
            colRemarks.Width = 150;
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
            colOrderNumber,
            colLN,
            colOrderHeaderId,
            colStaffNumber,
            colOrderOn,
            colLocation,
            colSupplier,
            colRemarks,
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
            lvList.Tag = new Guid("{95E1E053-5237-412d-B58C-6E4A3B6296FF}");

            ListViewHelper.LoadPreference(ref lvList);
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
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(2)); //// OrderNumber
                    objItem.SmallImage = reader.GetString(1) == "HOLD" ? new IconResourceHandle("16x16.flag_grey.png") : new IconResourceHandle("16x16.flag_green.png");
                    objItem.LargeImage = reader.GetString(1) == "HOLD" ? new IconResourceHandle("16x16.flag_grey.png") : new IconResourceHandle("16x16.flag_green.png");

                    objItem.SubItems.Add(iCount.ToString()); //// Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); //// CAPHeaderId
                    objItem.SubItems.Add(reader.GetString(4)); //// StaffNumber
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(3), false)); //// OrderOn
                    objItem.SubItems.Add(reader.GetString(5)); //// Location
                    objItem.SubItems.Add(reader.IsDBNull(6) ? string.Empty : reader.GetString(6)); //// Supplier
                    objItem.SubItems.Add(reader.GetString(7) + reader.GetString(8) + reader.GetString(9)); //// Remarks
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(10), true)); //// CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(12), true)); //// ModifiedOn

                    iCount++;
                }
            }
           this.lvList.Sort() ; // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效
        }

        #region Build Sql Query String
        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <returns>The joined Sql</returns>
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            //// 2008.03.24 paulus: TxType is not that useful, changed to show the Header.Status
            //// sql.Append("SELECT HeaderId, TxType, TxNumber, TxDate, StaffNumber, ");
            sql.Append(@"
SELECT OrderHeaderId,
    (
    CASE
        WHEN Status = 0 THEN 'HOLD'
        WHEN Status = 1 THEN 'POST'
    END
    ) AS Status, OrderNumber, OrderOn, StaffNumber, ");
            sql.Append(" Location, SupplierCode, Remarks1, Remarks2, Remarks3, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy ");
            sql.Append(" FROM vwPurchaseOrderList ");
            sql.Append(" WHERE PostedBy = '00000000-0000-0000-0000-000000000000' AND ");

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
                string objOrderNumber = PurchasingUtils.GenSafeChars(SearchForText);
                sql.Append(" AND OrderNumber LIKE '%").Append(objOrderNumber).Append("%'");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            sql.Append("ORDER BY OrderNumber");

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
                    RT2020.Purchasing.Wizard.PurchaseOrder phoList = new RT2020.Purchasing.Wizard.PurchaseOrder(id);
                    phoList.Closed += new EventHandler(wizSupplier_Closed);
                    phoList.ShowDialog();
                }
            }
        }

        void wizSupplier_Closed(object sender, EventArgs e)
        {
            RT2020.Purchasing.Wizard.PurchaseOrder pohList = sender as RT2020.Purchasing.Wizard.PurchaseOrder;
            if (pohList.OrderHeaderId != System.Guid.Empty)
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