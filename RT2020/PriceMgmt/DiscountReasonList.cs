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

using Gizmox.WebGUI.Common.Resources;
using System.Linq;
using System.Data.Entity;
using RT2020.Common.Helper;
using RT2020.Components;

#endregion

namespace RT2020.PriceMgmt
{
    public partial class DiscountReasonList : DefaultListBase
    {
        private Guid PageId = new Guid("79CC7875-F4A5-445D-AFEA-63550990CA61");     // 2007.12.22 paulus: PageId used in Preference
        private FAB fab = new FAB();    // floating action button: Add New Supplier

        public DiscountReasonList(Control toolBar)
        {
            InitializeComponent();

            PriceToolbar tb = new PriceToolbar(toolBar, ref tbControl);

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
            SetLvwList();

            alphaBinding.Visible = false;
            lblCreatedBy.Visible = false;
            lblView.Visible = false;

            cboStaffList.Visible = false;
            cboView.Visible = false;
        }

        private void fab_OnClick(object sender, EventArgs e)
        {
            var wizard = new ReasonCodeWizard();
            wizard.EditMode = EnumHelper.EditMode.Add;
            wizard.ShowDialog();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {

        }

        private void SetAttributes()
        {

        }

        #endregion

        public override void BindList()
        {
            BindReasonList();
        }

        #region Bind Reason List

        #region Set View Columns
        private void SetColumns()
        {
            Gizmox.WebGUI.Forms.ColumnHeader colLN = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colReasonName = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colReasonCode = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colReasonId = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colReasonNameAlt1 = new ColumnHeader();
            Gizmox.WebGUI.Forms.ColumnHeader colReasonNameAlt2 = new ColumnHeader();

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
            // colReasonName
            // 
            colReasonName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colReasonName.Image = null;
            colReasonName.Name = "colReasonName";
            colReasonName.Text = WestwindHelper.GetWord("priceManagementReason.name", "Model");
            colReasonName.TextAlign = HorizontalAlignment.Center;
            colReasonName.Width = 120;
            // 
            // colReasonCode
            // 
            colReasonCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colReasonCode.Image = null;
            colReasonCode.Name = "colReasonCode";
            colReasonCode.Text = WestwindHelper.GetWord("priceManagementReason.code", "Model");
            colReasonCode.TextAlign = HorizontalAlignment.Center;
            colReasonCode.Width = 80;
            // 
            // colReasonId
            // 
            colReasonId.ContentAlign = ExtendedHorizontalAlignment.Center;
            colReasonId.Image = null;
            colReasonId.Name = "colReasonId";
            colReasonId.Text = "ReasonId";
            colReasonId.TextAlign = HorizontalAlignment.Center;
            colReasonId.Visible = false;
            colReasonId.Width = 150;
            // 
            // colReasonNameChs
            // 
            colReasonNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colReasonNameAlt1.Image = null;
            colReasonNameAlt1.Name = "colReasonNameAlt1";
            colReasonNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colReasonNameAlt1.TextAlign = HorizontalAlignment.Center;
            colReasonNameAlt1.Width = 120;
            // 
            // colReasonNameCht
            // 
            colReasonNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;
            colReasonNameAlt2.Image = null;
            colReasonNameAlt2.Name = "colReasonNameAlt2";
            colReasonNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            colReasonNameAlt2.TextAlign = HorizontalAlignment.Center;
            colReasonNameAlt2.Width = 120;

            lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            colReasonCode,
            colLN,
            colReasonId,
            colReasonName,
            colReasonNameAlt1,
            colReasonNameAlt2});

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    colReasonNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    colReasonNameAlt1.Visible = colReasonNameAlt2.Visible = false;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Binds the reason list.
        /// </summary>
        /// 
        private void SetLvwList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvList.Tag = new Guid("{35EA7DBA-0C67-42ef-8979-297DA0E34167}");

            ListViewHelper.LoadPreference(ref lvList);
        }
        
        private void BindReasonList()
        {
            this.lvList.Items.Clear();

            int iCount = 0;
            string query = "ReasonCode LIKE '%" + SearchForText + "%'";

            using (var ctx = new EF6.RT2020Entities())
            {
                var objReasonList = ctx.PriceManagementReason
                    .Where(x => SearchForText.Contains(x.ReasonCode))
                    .OrderBy(x => x.ReasonCode)
                    .AsNoTracking()
                    .ToList();
                foreach (var objReason in objReasonList)
                {
                    ++iCount;

                    ListViewItem objItem = this.lvList.Items.Add(objReason.ReasonCode);
                    objItem.SmallImage = new IconResourceHandle("16x16.flag_green.png");
                    objItem.LargeImage = new IconResourceHandle("16x16.flag_green.png");

                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(objReason.ReasonId.ToString());
                    objItem.SubItems.Add(objReason.ReasonName);
                    objItem.SubItems.Add(objReason.ReasonName_Chs);
                    objItem.SubItems.Add(objReason.ReasonName_Cht);
                }
            }

            this.lvList.Sort(); // 依照當前的 ListView.SortOrder 和 ListView.SortPosition 排序，使 UserPreference 有效

        }

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
                    ReasonCodeWizard wizReason = new ReasonCodeWizard();
                    wizReason.ReasonId = id;
                    wizReason.EditMode = EnumHelper.EditMode.Edit;
                    wizReason.Closed += new EventHandler(wizReason_Closed);
                    wizReason.ShowDialog();
                }
            }
        }

        void wizReason_Closed(object sender, EventArgs e)
        {
            ReasonCodeWizard wizReason = sender as ReasonCodeWizard;
            if (wizReason.ReasonId != Guid.Empty)
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