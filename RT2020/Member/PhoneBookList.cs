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
using RT2020.Controls;
using RT2020.Common.Helper;
using System.Linq;

#endregion

namespace RT2020.Member
{
    public partial class PhoneBookList : Controls.DefaultListBase
    {
        public PhoneBookList()
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
        }

        public override void BindList()
        {
            BindMemberList();
        }

        #region Bind Phone Book List

        #region List View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colPhoneBookId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colVIPNumber = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colPhoneWork = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colPhoneHome = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colPhonePager = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colFax = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colPhoneBook = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colPhoneOther = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colAddressType = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeId = new ColumnHeader();

            // 
            // colPhoneBookId
            // 
            colPhoneBookId.ClientAction = null;
            colPhoneBookId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colPhoneBookId.Image = null;
            colPhoneBookId.Name = "colPhoneBookId";
            colPhoneBookId.Text = "PhoneBookId";
            colPhoneBookId.Visible = false;
            colPhoneBookId.Width = 150;
            // 
            // colLN
            // 
            colLN.ClientAction = null;
            colLN.ContentAlign = ExtendedHorizontalAlignment.Center;
            colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colLN.Image = null;
            colLN.Name = "colLN";
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colLN.TextAlign = HorizontalAlignment.Center;
            colLN.Width = 35;
            // 
            // colVIPNumber
            // 
            colVIPNumber.ClientAction = null;
            colVIPNumber.ContentAlign = ExtendedHorizontalAlignment.Center;
            colVIPNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colVIPNumber.Image = null;
            colVIPNumber.Name = "colVIPNumber";
            colVIPNumber.Text = Utility.Dictionary.GetWord("VIP Number");
            colVIPNumber.TextAlign = HorizontalAlignment.Left;
            colVIPNumber.Width = 100;
            // 
            // colPhoneBook
            // 
            colPhoneBook.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPhoneBook.ClientAction = null;
            colPhoneBook.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colPhoneBook.Image = null;
            colPhoneBook.Name = "colPhoneBook";
            colPhoneBook.Text = Utility.Dictionary.GetWord("Phone Book");
            colPhoneBook.TextAlign = HorizontalAlignment.Left;
            colPhoneBook.Width = 80;
            // 
            // colAddressType
            // 
            colAddressType.ContentAlign = ExtendedHorizontalAlignment.Center;
            colAddressType.ClientAction = null;
            colAddressType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colAddressType.Image = null;
            colAddressType.Name = "colAddressType";
            colAddressType.Text = Utility.Dictionary.GetWord("Type");
            colAddressType.TextAlign = HorizontalAlignment.Left;
            colAddressType.Width = 80;
            // 
            // colPhoneWork
            // 
            colPhoneWork.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPhoneWork.ClientAction = null;
            colPhoneWork.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colPhoneWork.Image = null;
            colPhoneWork.Name = "colPhoneWork";
            colPhoneWork.Text = Utility.Dictionary.GetWord("Phone") + "(" + Utility.Dictionary.GetWord("Work") + ")";
            colPhoneWork.TextAlign = HorizontalAlignment.Left;
            colPhoneWork.Width = 100;
            // 
            // colPhoneHome
            // 
            colPhoneHome.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPhoneHome.ClientAction = null;
            colPhoneHome.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colPhoneHome.Image = null;
            colPhoneHome.Name = "colPhoneHome";
            colPhoneHome.Text = Utility.Dictionary.GetWord("Phone") + "(" + Utility.Dictionary.GetWord("Home") + ")";
            colPhoneHome.TextAlign = HorizontalAlignment.Left;
            colPhoneHome.Width = 100;
            // 
            // colPhonePager
            // 
            colPhonePager.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPhonePager.ClientAction = null;
            colPhonePager.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colPhonePager.Image = null;
            colPhonePager.Name = "colPhonePager";
            colPhonePager.Text = Utility.Dictionary.GetWord("Phone") + "(" + Utility.Dictionary.GetWord("Pager") + ")";
            colPhonePager.TextAlign = HorizontalAlignment.Left;
            colPhonePager.Width = 100;
            // 
            // colFax
            // 
            colFax.ContentAlign = ExtendedHorizontalAlignment.Center;
            colFax.ClientAction = null;
            colFax.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colFax.Image = null;
            colFax.Name = "colFax";
            colFax.Text = Utility.Dictionary.GetWord("Fax");
            colFax.TextAlign = HorizontalAlignment.Left;
            colFax.Width = 100;
            // 
            // colPhoneOther
            // 
            colPhoneOther.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPhoneOther.ClientAction = null;
            colPhoneOther.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colPhoneOther.Image = null;
            colPhoneOther.Name = "colPhoneOther";
            colPhoneOther.Text = Utility.Dictionary.GetWord("Phone") + "(" + Utility.Dictionary.GetWord("Other") + ")";
            colPhoneOther.TextAlign = HorizontalAlignment.Left;
            colPhoneOther.Width = 100;
            // 
            // colCreatedOn
            // 
            colCreatedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCreatedOn.ClientAction = null;
            colCreatedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colCreatedOn.Image = null;
            colCreatedOn.Name = "colCreatedOn";
            colCreatedOn.Text = WestwindHelper.GetWord("glossary.createdOn", "General");
            colCreatedOn.TextAlign = HorizontalAlignment.Left;
            colCreatedOn.Visible = false;
            colCreatedOn.Width = 120;
            // 
            // colModifiedOn
            // 
            colModifiedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colModifiedOn.ClientAction = null;
            colModifiedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colModifiedOn.Image = null;
            colModifiedOn.Name = "colModifiedOn";
            colModifiedOn.Text = WestwindHelper.GetWord("glossary.modifiedOn", "General");
            colModifiedOn.TextAlign = HorizontalAlignment.Left;
            colModifiedOn.Visible = false;
            colModifiedOn.Width = 120;
            // 
            // colAddressTypeId
            // 
            colAddressTypeId.ClientAction = null;
            colAddressTypeId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            colAddressTypeId.Image = null;
            colAddressTypeId.Name = "colAddressTypeId";
            colAddressTypeId.Text = "AddressTypeId";
            colAddressTypeId.Visible = false;
            colAddressTypeId.Width = 150;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colVIPNumber,
            colLN,
            colPhoneBookId,
            colPhoneBook,
            colAddressType,
            colPhoneWork,
            colPhoneHome,
            colPhonePager,
            colFax,
            colPhoneOther,
            colCreatedOn,
            colModifiedOn,
            colAddressTypeId});
        }
        #endregion

        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("3AA0B3E8-B27A-415F-802F-6BCF5A0A79D0");

            ListViewHelper.LoadPreference(ref lvList);
        }

        private void BindMemberList()
        {
            this.lvList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();

            using (var ctx = new EF6.RT2020Entities())
            {
                //ctx.Configuration.LazyLoadingEnabled = false;

                var where = string.Format("Select * from vwPhonebookList {0}", sql.Substring(sql.LastIndexOf("WHERE")));
                var list = ctx.vwPhonebookList.SqlQuery(where).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvList.Items.Add(item.VipNumber);
                    objItem.SmallImage = new IconResourceHandle("16x16.CustomerSingle_16.png");
                    objItem.LargeImage = new IconResourceHandle("16x16.CustomerSingle_16.png");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.MemberId.ToString());
                    objItem.SubItems.Add(item.PhoneBook);
                    objItem.SubItems.Add(item.AddressTypeCode);
                    objItem.SubItems.Add(item.Phone_W);
                    objItem.SubItems.Add(item.Phone_H);
                    objItem.SubItems.Add(item.Phone_P);
                    objItem.SubItems.Add(item.Fax);
                    objItem.SubItems.Add(item.Phone_Other);
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.CreatedOn, true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.ModifiedOn, true)); // ModifiedOn
                    objItem.SubItems.Add(item.AddressTypeId.ToString());

                    iCount++;
                }
            }
            /**
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvList.Items.Add(reader.GetString(1)); // Vip Number
                    objItem.SmallImage = new IconResourceHandle("16x16.ico_16_137.gif");
                    objItem.LargeImage = new IconResourceHandle("16x16.ico_16_137.gif");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetGuid(0).ToString()); // MemberId
                    objItem.SubItems.Add(reader.GetString(2)); // PhoneBook
                    objItem.SubItems.Add(reader.GetString(3)); // Address Type Code
                    objItem.SubItems.Add(reader.GetString(4)); // Phone_Work
                    objItem.SubItems.Add(reader.GetString(5)); // Phone_Home
                    objItem.SubItems.Add(reader.GetString(6)); // Phone_Pager
                    objItem.SubItems.Add(reader.GetString(7)); // Fax
                    objItem.SubItems.Add(reader.GetString(8)); // Phone_Other
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(9), true)); // CreatedOn
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(11), true)); // ModifiedOn
                    objItem.SubItems.Add(reader.GetGuid(13).ToString());

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
            sql.Append(" SELECT MemberId, VipNumber, ISNULL(PhoneBook, '') AS PhoneBook, ISNULL(AddressTypeCode, '') AS AddressTypeCode, ");
            sql.Append(" ISNULL(Phone_W, '') AS Phone_W, ISNULL(Phone_H, '') AS Phone_H, ISNULL(Phone_P, '') AS Phone_P, ISNULL(Fax, '') AS Fax, ISNULL(Phone_Other, '') AS Phone_Other, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, AddressTypeId ");
            sql.Append(" FROM vwPhonebookList ");
            sql.Append(" WHERE ");

            switch (base.SelectedViewIndex)
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

            if (!string.IsNullOrEmpty(base.SearchForText))
            {
                sql.Append(" AND (VipNumber LIKE '%").Append(base.SearchForText).Append("%' ");
                sql.Append(" OR Phone_W LIKE '%").Append(base.SearchForText).Append("%' ");
                sql.Append(" OR Phone_P LIKE '%").Append(base.SearchForText).Append("%' ");
                sql.Append(" OR Phone_Other LIKE '%").Append(base.SearchForText).Append("%' ");
                sql.Append(" OR Phone_H LIKE '%").Append(base.SearchForText).Append("%')");
            }

            if (SelectedStaff != System.Guid.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(SelectedStaff.ToString()).Append("'");
            }

            if (!(String.IsNullOrEmpty(AlphaSeacher)) && AlphaSeacher != "All")
            {
                sql.Append(String.Format(" AND ( SUBSTRING([VipNumber], 1, 1) = N'{0}' )", AlphaSeacher));
            }

            sql.Append(" ORDER BY VipNumber, AddressTypeCode ");

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
                Guid memberId = Guid.Empty, addressTypeId = Guid.Empty;
                if (Guid.TryParse(lvList.SelectedItem.SubItems[2].Text, out memberId) && Guid.TryParse(lvList.SelectedItem.SubItems[12].Text, out addressTypeId))
                {
                    PhoneBookWizard wizPhone = new PhoneBookWizard(memberId, addressTypeId);
                    wizPhone.Closed += new EventHandler(wizSupplier_Closed);
                    wizPhone.ShowDialog();
                }
            }
        }

        void wizSupplier_Closed(object sender, EventArgs e)
        {
            PhoneBookWizard wizPhoneBook = sender as PhoneBookWizard;
            if (wizPhoneBook.MemberId != System.Guid.Empty && wizPhoneBook.AddressTypeId != System.Guid.Empty)
            {
                //2013.06.25 paulus: 每次 close 個 wizard 都 rebind 會浪費時間，既然有 Refresh button，我就取消這
                //BindList();
                //this.Update();
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