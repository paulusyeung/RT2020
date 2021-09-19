#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Dialogs;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.PriceMgmt
{
    public partial class PriceMgmtWizard : Form
    {
        PriceMgmtWizard_Details details;

        #region public Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        // 2021.02.05 paulus: 加嚟分開 promption 定係 priceMgmt
        private EnumHelper.PriceMgmtTxType _TxType = EnumHelper.PriceMgmtTxType.None;
        public EnumHelper.PriceMgmtTxType TxType
        {
            get { return _TxType; }
            set { _TxType = value; }
        }

        private EnumHelper.PriceMgmtPMType _PMType = EnumHelper.PriceMgmtPMType.Price;
        public EnumHelper.PriceMgmtPMType PMType
        {
            get { return _PMType; }
            set { _PMType = value; }
        }

        private Guid _HeaderId = Guid.Empty;
        public Guid HeaderId
        {
            get
            {
                return _HeaderId;
            }
            set
            {
                _HeaderId = value;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceMgmtWizard"/> class.
        /// </summary>
        public PriceMgmtWizard()
        {
            InitializeComponent();
        }

        private void PriceMgmtWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetToolBar();
            SetToolBar4Details();
            SetItemList();
            FillReasonCombo();

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadHeader();
                    break;
            }
        }
        /**
        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        */

        #region Set attributes
        private void SetCaptions()
        {
            this.Text = _PMType == EnumHelper.PriceMgmtPMType.Discount ?
                WestwindHelper.GetWord("product.priceManagement.discountChange", "Menu") : _PMType == EnumHelper.PriceMgmtPMType.Price ?
                WestwindHelper.GetWord("product.priceManagement.priceChange", "Menu") : "";
        }

        private void SetAttributes()
        {
            #region color boxes
            this.dtpEffectiveDate.BackColor = SystemInfoHelper.ControlBackColor.RequiredBox;

            this.txtTxType.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            this.txtCreatedOn.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            this.txtModifiedBy.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            this.txtModifiedOn.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            this.txtTxNumber.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            #endregion

            // Loading Details Page
            /**
            details = new PriceMgmtWizard_Details();
            details.HeaderId = this.HeaderId;
            details.ListType = _PMType;
            details.Dock = DockStyle.Bottom;
            pnlDetails.Controls.Add(details);
            */
            lvItemList.Dock = DockStyle.Fill;
            lvItemList.GridLines = true;
            switch (_PMType)
            {
                case EnumHelper.PriceMgmtPMType.Price:
                    colAverageCost.Visible = colOldPrice.Visible = colNewPrice.Visible = colOldMarkUp.Visible = colNewMarkUp.Visible = colDiff.Visible = colOldDiscount.Visible = colNewDiscount.Visible = true;
                    colUpdateVipDiscount.Visible = colFixedPriceItem.Visible = colDiscountForDiscountItem.Visible = colDiscountForFixedPriceItem.Visible = colDiscountForNoDiscountItem.Visible = colStaffDiscount.Visible = false;
                    break;
                case EnumHelper.PriceMgmtPMType.Discount:
                    colAverageCost.Visible = colOldPrice.Visible = colNewPrice.Visible = colOldMarkUp.Visible = colNewMarkUp.Visible = colDiff.Visible = colOldDiscount.Visible = colNewDiscount.Visible = false;
                    colUpdateVipDiscount.Visible = colFixedPriceItem.Visible = colDiscountForDiscountItem.Visible = colDiscountForFixedPriceItem.Visible = colDiscountForNoDiscountItem.Visible = colStaffDiscount.Visible = true;
                    break;
            }

            #region 設定 clickable Reason Code label
            //lblReasonCode.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblReasonCode.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblReasonCode.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ReasonCodeWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillReasonCombo();
                };
                dialog.ShowDialog();
            };
            #endregion

        }

        private void SetItemList()
        {
            // 提供一個固定的 Guid tag， 在 UserPreference 中用作這個 ListView 的 unique key
            lvItemList.Tag = new Guid("DC9935C8-0A61-4703-8661-541C7585DA32");

            ListViewHelper.LoadPreference(ref lvItemList);
        }
        #endregion

        private void FillReasonCombo()
        {
            var textField = new string[] { "ReasonCode", "ReasonName" };
            var pattern = "{0} - {1}";
            var orderBy = new string[] { "ReasonCode" };
            PriceManagementReasonEx.LoadCombo(ref cboReasonCode, textField, pattern, true, true, string.Empty, "", orderBy);
        }

        #region ToolBar

        /// <summary>
        /// Sets the tool bar.
        /// </summary>
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", WestwindHelper.GetWord("edit.save.new", "General"));
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", WestwindHelper.GetWord("edit.save.close", "General"));
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            // cmdPrint
            ToolBarButton cmdPrint = new ToolBarButton("Print", WestwindHelper.GetWord("edit.print", "General"));
            cmdPrint.Tag = "Print";
            cmdPrint.Image = new IconResourceHandle("16x16.16_print.gif");

            if (this.HeaderId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
                cmdPrint.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Delete);
                cmdPrint.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);
            this.tbWizardAction.Buttons.Add(sep);
            this.tbWizardAction.Buttons.Add(cmdPrint);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        private void SetToolBar4Details()
        {
            tbrDetails.MenuHandle = false;
            tbrDetails.DragHandle = false;
            tbrDetails.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            #region cmdButtons   - Buttons [0~3]
            /**
            tbrDetails.Buttons.Add(new ToolBarButton("Columns", String.Empty));
            tbrDetails.Buttons[0].Image = new IconResourceHandle("16x16.listview_columns.gif");
            tbrDetails.Buttons[0].ToolTipText = WestwindHelper.GetWord("toolbar.hideUnhideColumns", "Tools");

            tbrDetails.Buttons.Add(new ToolBarButton("Sorting", String.Empty));
            tbrDetails.Buttons[1].Image = new IconResourceHandle("16x16.listview_sorting.gif");
            tbrDetails.Buttons[1].ToolTipText = WestwindHelper.GetWord("toolbar.sorting", "Tools");

            tbrDetails.Buttons.Add(new ToolBarButton("Checkbox", String.Empty));
            tbrDetails.Buttons[2].Image = new IconResourceHandle("16x16.listview_checkbox.gif");
            tbrDetails.Buttons[2].ToolTipText = WestwindHelper.GetWord("toolbar.toggleCheckbox", "Tools");
            tbrDetails.Buttons[2].Visible = true;

            tbrDetails.Buttons.Add(new ToolBarButton("MultiSelect", String.Empty));
            tbrDetails.Buttons[3].Image = new IconResourceHandle("16x16.listview_multiselect.gif");
            tbrDetails.Buttons[3].ToolTipText = WestwindHelper.GetWord("toolbar.toggleMultiSelect", "Tools");
            tbrDetails.Buttons[3].Visible = false;
            */
            ToolBarButton cmdColumns = new ToolBarButton("Columns", String.Empty)
            {
                Image = new IconResourceHandle("16x16.listview_columns.gif"),
                Tag = "Columns",
                ToolTipText = WestwindHelper.GetWord("toolbar.sorting", "Tools")
            };
            ToolBarButton cmdSorting = new ToolBarButton("Sorting", String.Empty)
            {
                Image = new IconResourceHandle("16x16.listview_sorting.gif"),
                Tag = "Sorting",
                ToolTipText = WestwindHelper.GetWord("toolbar.sorting", "Tools")
            };
            ToolBarButton cmdCheckbox = new ToolBarButton("Checkbox", String.Empty)
            {
                Image = new IconResourceHandle("16x16.listview_checkbox.gif"),
                Tag = "Checkbox",
                ToolTipText = WestwindHelper.GetWord("toolbar.toggleCheckbox", "Tools")
            };
            ToolBarButton cmdMultiSelect = new ToolBarButton("MultiSelect", String.Empty)
            {
                Image = new IconResourceHandle("16x16.listview_multiselect.gif"),
                Tag = "MultiSelect",
                ToolTipText = WestwindHelper.GetWord("toolbar.toggleMultiSelect", "Tools"),
                Visible = false
            };

            #endregion

            tbrDetails.Buttons.Add(cmdColumns);
            tbrDetails.Buttons.Add(cmdSorting);
            tbrDetails.Buttons.Add(cmdCheckbox);
            tbrDetails.Buttons.Add(cmdMultiSelect);
            tbrDetails.Buttons.Add(sep);

            #region cmdViews    - Buttons[5]

            ContextMenu ddlViews = new ContextMenu();
            ddlViews.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("toolbar.views.icon", "Tools"), string.Empty, "Icon"));
            ddlViews.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("toolbar.views.tile", "Tools"), string.Empty, "Tile"));
            ddlViews.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("toolbar.views.list", "Tools"), string.Empty, "List"));
            ddlViews.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("toolbar.views.details", "Tools"), string.Empty, "Details"));

            ddlViews.MenuItems[0].Icon = new IconResourceHandle("16x16.appView_icons.png");
            ddlViews.MenuItems[1].Icon = new IconResourceHandle("16x16.appView_tile.png");
            ddlViews.MenuItems[2].Icon = new IconResourceHandle("16x16.appView_columns.png");
            ddlViews.MenuItems[3].Icon = new IconResourceHandle("16x16.appView_list.png");

            ToolBarButton cmdViews = new ToolBarButton("Views", WestwindHelper.GetWord("toolbar.views", "Tools"));
            cmdViews.Style = ToolBarButtonStyle.DropDownButton;
            cmdViews.Image = new IconResourceHandle("16x16.appView_xp.png");
            cmdViews.DropDownMenu = ddlViews;
            tbrDetails.Buttons.Add(cmdViews);
            cmdViews.MenuClick += new MenuEventHandler(ansViews_MenuClick);

            #endregion

            #region cmdPreference    - Buttons[6]
            ContextMenu ddlPreference = new ContextMenu();
            RT2020.Controls.Data.AppendMenuItem_AppPref(ref ddlPreference);
            ToolBarButton cmdPreference = new ToolBarButton("Preference", WestwindHelper.GetWord("toolbar.preference", "Tools"));
            cmdPreference.Style = ToolBarButtonStyle.DropDownButton;
            cmdPreference.Image = new IconResourceHandle("16x16.ico_16_1039_default.gif");
            cmdPreference.DropDownMenu = ddlPreference;
            tbrDetails.Buttons.Add(cmdPreference);
            cmdPreference.MenuClick += new MenuEventHandler(ansPreference_MenuClick);
            #endregion

            tbrDetails.Buttons.Add(sep);

            // Refresh       - Buttons[8]
            tbrDetails.Buttons.Add(new ToolBarButton("Refresh", WestwindHelper.GetWord("toolbar.refresh", "Tools")));
            tbrDetails.Buttons[8].Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            #region cmdExport    - Buttons[9]
            /**
            ContextMenu ddlExport = new ContextMenu();
            ddlExport.MenuItems.Add(new MenuItem("PDF"));
            ddlExport.MenuItems.Add(new MenuItem("Excel"));
            ddlExport.MenuItems.Add(new MenuItem("CSV"));
            ddlExport.MenuItems.Add(new MenuItem("UIFD"));

            ToolBarButton cmdExport = new ToolBarButton("Export", string.Empty);
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.16_export.gif");
            cmdExport.DropDownMenu = ddlExport;
            cmdExport.Enabled = false;
            tbrDetails.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(ansExport_MenuClick);
            */
            #endregion

            //tbrDetails.Buttons.Add(new ToolBarButton("Show", WestwindHelper.GetWord("toolbar.show", "Tools")));
            //tbrDetails.Buttons[10].Image = new IconResourceHandle("16x16.ico_18_127.gif");
            //tbrDetails.ButtonClick += new ToolBarButtonClickEventHandler(ansCare_ButtonClick);

            tbrDetails.Buttons.Add(sep);


            //ToolBarButton sep = new ToolBarButton();
            //sep.Style = ToolBarButtonStyle.Separator;

            #region cmdSave
            ToolBarButton cmdNew = new ToolBarButton("cmdNew", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Tag = "cmdNew";
            cmdNew.Image = new IconResourceHandle(ThemeHelper.GetIconThemed(".24.mdi-playlist-plus.png"));
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            #endregion

            #region cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("cmdDelete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "cmdDelete";
            cmdDelete.Image = new IconResourceHandle(ThemeHelper.GetIconThemed(".24.mdi-delete.png"));
            #endregion

            #region cmdEdit
            ToolBarButton cmdEdit = new ToolBarButton("cmdEdit", WestwindHelper.GetWord("edit", "General"));
            cmdEdit.Tag = "cmdEdit";
            cmdEdit.Image = new IconResourceHandle(ThemeHelper.GetIconThemed(".24.mdi-pencil-outline.png"));
            #endregion

            #region show/hide buttons
            cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Delete);
            cmdEdit.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            #endregion

            tbrDetails.Buttons.Add(cmdNew);
            tbrDetails.Buttons.Add(sep);
            tbrDetails.Buttons.Add(cmdEdit);
            tbrDetails.Buttons.Add(sep);
            tbrDetails.Buttons.Add(cmdDelete);

            tbrDetails.ButtonClick += new ToolBarButtonClickEventHandler(tbrDetails_OnButtonClick);
        }

        /// <summary>
        /// Handles the ButtonClick event of the tbWizardAction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs"/> instance containing the event data.</param>
        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs arg)
        {
            if (arg.Button.Tag != null)
            {
                switch (arg.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
                        break;
                    case "save & new":
                        MessageBox.Show("Save Record And Add New?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
                        break;
                    case "save & close":
                        MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveCloseMessageHandler));
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                    case "print":
                        ClickPrint();
                        break;
                }
            }
        }

        void tbrDetails_OnButtonClick(object sender, ToolBarButtonClickEventArgs arg)
        {
            if (arg.Button.Tag != null)
            {
                switch (arg.Button.Tag.ToString())
                {
                    case "Columns":
                        ListViewColumnOptions objListViewColumnOptions = new ListViewColumnOptions(lvItemList);
                        objListViewColumnOptions.ShowDialog();
                        break;
                    case "Sorting":
                        ListViewSortingOptions objListViewSortingOptions = new ListViewSortingOptions(lvItemList);
                        objListViewSortingOptions.ShowDialog();
                        break;
                    case "Checkbox":
                        this.lvItemList.CheckBoxes = !lvItemList.CheckBoxes;
                        break;
                    case "MultiSelect":
                        lvItemList.MultiSelect = !lvItemList.MultiSelect;
                        arg.Button.Pushed = true;
                        break;
                    case "cmdNew":
                        #region add item
                        PriceMgmtWizard_AddItem addItem = new PriceMgmtWizard_AddItem();
                        addItem.TxType = _TxType;
                        addItem.PMType = _PMType;
                        addItem.Closed += (s, e) =>
                        {
                            // 如果要跟手尾，喺呢度加 code，例如 refresh 個 listview
                        };
                        addItem.ShowDialog();
                        break;
                        #endregion
                    case "cmdEdit":
                        break;
                    case "cmdDelete":
                        break;
                }
            }
        }

        private void ansViews_MenuClick(object sender, MenuItemEventArgs e)
        {
            if (e.MenuItem.Tag != null)
            {
                switch (e.MenuItem.Tag.ToString())
                {
                    case "Icon":
                        this.lvItemList.View = View.SmallIcon;
                        break;
                    case "Tile":
                        this.lvItemList.View = View.LargeIcon;
                        break;
                    case "List":
                        this.lvItemList.View = View.List;
                        break;
                    case "Details":
                        this.lvItemList.View = View.Details;
                        break;
                }
            }
        }

        private void ansPreference_MenuClick(object sender, MenuItemEventArgs e)
        {
            switch (e.MenuItem.Tag.ToString())
            {
                case "Save":
                    ListViewHelper.SavePreference(lvItemList);
                    break;
                case "Reset":
                    ListViewHelper.DeletePreference(lvItemList);
                    break;
            }
            MessageBox.Show(
                WestwindHelper.GetWord("result.done", "Prompt"),
                WestwindHelper.GetWord("dialog.information", "General"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private DataTable BindDataToReport()
        {
            string sql = @"
SELECT TOP 100 PERCENT * 
FROM vwRptBatchPriceMgmt
WHERE TxNumber BETWEEN '" + this.txtTxNumber.Text.Trim() + "' AND '" + this.txtTxNumber.Text.Trim() + @"'
AND CONVERT(NVARCHAR(10),EffectDate,126) BETWEEN '" + this.dtpEffectiveDate.Value.ToString("yyyy-MM-dd") + @"'
                                             AND '" + this.dtpEffectiveDate.Value.ToString("yyyy-MM-dd") + @"'
";
            if (this.PMType.ToString().Substring(0, 1) == "P")
            {
                sql += " AND PM_TYPE = 'P'";
            }
            else if (this.PMType.ToString().Substring(0, 1) == "D")
            {
                sql += " AND PM_TYPE = 'D'";
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        /// <summary>
        /// print every ListItem
        /// </summary>
        private void ClickPrint()
        {
            string[,] param = { 
                {"FromTxNumber",this.txtTxNumber.Text.Trim()},
                {"ToTxNumber",this.txtTxNumber.Text.Trim()},
                {"FromTxDate", this.dtpEffectiveDate.Value.ToString(DateTimeHelper.GetDateFormat())},
                {"ToTxDate", this.dtpEffectiveDate.Value.ToString(DateTimeHelper.GetDateFormat())},
                {"PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
                {"DateFormat", DateTimeHelper.GetDateFormat()},
                {"STKCODE",SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE")},
                {"APPENDIX1",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1")},
                {"APPENDIX2",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2")},
                {"APPENDIX3",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3")},
                {"CLASS1",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS1")},
                {"CLASS2",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS2")},
                {"CLASS3",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS3")},
                {"CLASS4",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS4")},
                {"CLASS5",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS5")},
                {"CLASS6",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS6")},
                {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
                };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindDataToReport();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource4PriceMgmt_vwRptBatchPriceMgmt";

            if (this.PMType.ToString().Substring(0, 1) == "P")
            {
                view.ReportName = "RT2020.PriceMgmt.Reports.PriceWorksheetRdl.rdlc";
            }
            else if (this.PMType.ToString().Substring(0, 1) == "D")
            {
                view.ReportName = "RT2020.PriceMgmt.Reports.DiscountWorksheetRdl.rdlc";
            }

            view.Parameters = param;

            view.Show();    
        }

        #endregion

        #region Load Data

        /// <summary>
        /// Loads this instance.
        /// </summary>
        private void LoadHeader()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oHeader = ctx.PriceManagementBatchHeader.Find(this.HeaderId);
                if (oHeader != null)
                {
                    txtTxNumber.Text = oHeader.TxNumber;

                    dtpEffectiveDate.Value = oHeader.EffectDate.Value;
                    cboReasonCode.SelectedValue = oHeader.ReasonId;
                    txtRemarks.Text = oHeader.Remarks;

                    txtModifiedOn.Text = DateTimeHelper.DateTimeToString(oHeader.ModifiedOn.Value, true);
                    txtModifiedBy.Text = StaffEx.GetStaffNumberById(oHeader.ModifiedBy);
                    txtCreatedOn.Text = DateTimeHelper.DateTimeToString(oHeader.CreatedOn.Value, true);

                }
            }
        }

        #endregion

        #region Save Data

        /// <summary>
        /// Verifies this instance.
        /// </summary>
        /// <returns></returns>
        private bool Verify()
        {
            bool isValid = false;

            if (details != null)
            {
                if (details.lvItemList.Items.Count <= 0)
                {
                    MessageBox.Show("The detail list cannot be empty. Try to add some!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, new EventHandler(CheckValidationHandler));
                }
                else
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            if (Verify())
            {
                UpdateHeader();

                return this.HeaderId != System.Guid.Empty;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the header.
        /// </summary>
        private void UpdateHeader()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oHeader = ctx.PriceManagementBatchHeader.Find(this.HeaderId);
                        if (oHeader == null)
                        {
                            #region add new PriceManagementBatchHeader
                            oHeader = new EF6.PriceManagementBatchHeader();
                            oHeader.HeaderId = Guid.NewGuid();
                            txtTxNumber.Text = SystemInfoHelper.Settings.QueuingTxNumber(EnumHelper.TxType.PMS);
                            oHeader.TxNumber = txtTxNumber.Text;
                            oHeader.TxType = EnumHelper.TxType.PMC.ToString();
                            oHeader.PM_TYPE = this.PMType.ToString().Substring(0, 1);

                            oHeader.CreatedBy = ConfigHelper.CurrentUserId;
                            oHeader.CreatedOn = DateTime.Now;

                            ctx.PriceManagementBatchHeader.Add(oHeader);
                            #endregion
                        }

                        oHeader.EffectDate = dtpEffectiveDate.Value;
                        oHeader.ReasonId = (Guid)cboReasonCode.SelectedValue;
                        oHeader.Remarks = txtRemarks.Text;

                        oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                        oHeader.ModifiedOn = DateTime.Now;

                        ctx.SaveChanges();

                        this.HeaderId = oHeader.HeaderId;

                        #region UpdateDetails();
                        for (int i = 0; i < details.lvItemList.Items.Count; i++)
                        {
                            ListViewItem lvItem = details.lvItemList.Items[i];
                            int lineNumber = i + 1;

                            Guid productId = Guid.Empty, detailId = Guid.Empty;
                            if (Guid.TryParse(lvItem.SubItems[27].Text, out productId) && Guid.TryParse(lvItem.Text, out detailId))
                            {
                                var oDetail = ctx.PriceManagementBatchDetails.Find(detailId);
                                if (oDetail == null)
                                {
                                    #region new PriceManagementBatchDetails
                                    oDetail = new EF6.PriceManagementBatchDetails();
                                    oDetail.DetailId = Guid.NewGuid();
                                    oDetail.HeaderId = this.HeaderId;
                                    oDetail.LineNumber = lineNumber;
                                    oDetail.ProductId = productId;
                                    oDetail.TxNumber = txtTxNumber.Text;
                                    oDetail.TxType = txtTxType.Text;

                                    ctx.PriceManagementBatchDetails.Add(oDetail);
                                    #endregion
                                }

                                if (lvItem.SubItems[1].Text != "D")
                                {
                                    decimal oldValue = 0, newValue = 0;

                                    if (_PMType == EnumHelper.PriceMgmtPMType.Price)
                                    {
                                        decimal.TryParse(lvItem.SubItems[7].Text, out oldValue);
                                        decimal.TryParse(lvItem.SubItems[9].Text, out newValue);
                                    }
                                    else
                                    {
                                        decimal.TryParse(lvItem.SubItems[12].Text, out oldValue);
                                        decimal.TryParse(lvItem.SubItems[13].Text, out newValue);
                                    }

                                    oDetail.OLD_FIGURE = oldValue;
                                    oDetail.NEW_FIGURE = newValue;

                                    #region Update Vip Discount
                                    if (lvItem.SubItems[21].Text == "Y") // Update Vip Discount
                                    {
                                        var objProduct = ctx.Product.Find(productId);
                                        if (objProduct != null)
                                        {
                                            objProduct.FixedPriceItem = (lvItem.SubItems[22].Text == "Y"); // Fixed price item

                                            string query = "ProductId = '" + objProduct.ProductId.ToString() + "'";
                                            var oSupplement = ctx.ProductSupplement.Where(x => x.ProductId == objProduct.ProductId).FirstOrDefault();
                                            if (oSupplement != null)
                                            {
                                                decimal vipDicount_FixedItem = 0, vipDiscount_DiscountItem = 0, vipDiscount_NoDiscountItem = 0, staffDiscount = 0;
                                                decimal.TryParse(lvItem.SubItems[23].Text, out vipDicount_FixedItem);
                                                decimal.TryParse(lvItem.SubItems[24].Text, out vipDiscount_DiscountItem);
                                                decimal.TryParse(lvItem.SubItems[25].Text, out vipDiscount_NoDiscountItem);
                                                decimal.TryParse(lvItem.SubItems[26].Text, out staffDiscount);
                                                //oSupplement.VipDiscount_FixedItem = Common.Utility.IsNumeric(lvItem.SubItems[23].Text) ? Convert.ToDecimal(lvItem.SubItems[23].Text.Trim()) : oSupplement.VipDiscount_FixedItem; // Discount For Fixed price Item
                                                //oSupplement.VipDiscount_DiscountItem = Common.Utility.IsNumeric(lvItem.SubItems[24].Text) ? Convert.ToDecimal(lvItem.SubItems[24].Text.Trim()) : oSupplement.VipDiscount_DiscountItem; // Discount for Discount Item
                                                //oSupplement.VipDiscount_NoDiscountItem = Common.Utility.IsNumeric(lvItem.SubItems[25].Text) ? Convert.ToDecimal(lvItem.SubItems[25].Text.Trim()) : oSupplement.VipDiscount_NoDiscountItem; // Disocunt for No Discount Item
                                                //oSupplement.StaffDiscount = Common.Utility.IsNumeric(lvItem.SubItems[26].Text) ? Convert.ToDecimal(lvItem.SubItems[26].Text.Trim()) : oSupplement.StaffDiscount; // Staff Discount
                                                oSupplement.VipDiscount_FixedItem = vipDicount_FixedItem;
                                                oSupplement.VipDiscount_DiscountItem = vipDiscount_DiscountItem;
                                                oSupplement.VipDiscount_NoDiscountItem = vipDiscount_NoDiscountItem;
                                                oSupplement.StaffDiscount = staffDiscount;
                                            }

                                            objProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                                            objProduct.ModifiedOn = DateTime.Now;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    ctx.PriceManagementBatchDetails.Remove(oDetail);
                                }
                                ctx.SaveChanges();
                            }
                        }
                        #endregion

                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }
        /**
        /// <summary>
        /// Updates the details.
        /// </summary>
        private void UpdateDetails()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < details.lvItemList.Items.Count; i++)
                        {
                            ListViewItem lvItem = details.lvItemList.Items[i];
                            int lineNumber = i + 1;

                            Guid productId = Guid.Empty, detailId = Guid.Empty;
                            if (Guid.TryParse(lvItem.SubItems[27].Text, out productId) && Guid.TryParse(lvItem.Text, out detailId))
                            {
                                var oDetail = ctx.PriceManagementBatchDetails.Find(detailId);
                                if (oDetail == null)
                                {
                                    #region new PriceManagementBatchDetails
                                    oDetail = new EF6.PriceManagementBatchDetails();
                                    oDetail.DetailId = Guid.NewGuid();
                                    oDetail.HeaderId = this.HeaderId;
                                    oDetail.LineNumber = lineNumber;
                                    oDetail.ProductId = productId;
                                    oDetail.TxNumber = txtTxNumber.Text;
                                    oDetail.TxType = txtTxType.Text;

                                    ctx.PriceManagementBatchDetails.Add(oDetail);
                                    #endregion
                                }

                                if (lvItem.SubItems[1].Text != "D")
                                {
                                    decimal oldValue = 0, newValue = 0;

                                    if (this.ListType == PriceUtility.PriceMgmtType.Price)
                                    {
                                        decimal.TryParse(lvItem.SubItems[7].Text, out oldValue);
                                        decimal.TryParse(lvItem.SubItems[9].Text, out newValue);
                                    }
                                    else
                                    {
                                        decimal.TryParse(lvItem.SubItems[12].Text, out oldValue);
                                        decimal.TryParse(lvItem.SubItems[13].Text, out newValue);
                                    }

                                    oDetail.OLD_FIGURE = oldValue;
                                    oDetail.NEW_FIGURE = newValue;

                                    #region Update Vip Discount
                                    if (lvItem.SubItems[21].Text == "Y") // Update Vip Discount
                                    {
                                        var objProduct = ctx.Product.Find(productId);
                                        if (objProduct != null)
                                        {
                                            objProduct.FixedPriceItem = (lvItem.SubItems[22].Text == "Y"); // Fixed price item

                                            string query = "ProductId = '" + objProduct.ProductId.ToString() + "'";
                                            var oSupplement = ctx.ProductSupplement.Where(x => x.ProductId == objProduct.ProductId).FirstOrDefault();
                                            if (oSupplement != null)
                                            {
                                                oSupplement.VipDiscount_FixedItem = Common.Utility.IsNumeric(lvItem.SubItems[23].Text) ? Convert.ToDecimal(lvItem.SubItems[23].Text.Trim()) : oSupplement.VipDiscount_FixedItem; // Discount For Fixed price Item
                                                oSupplement.VipDiscount_DiscountItem = Common.Utility.IsNumeric(lvItem.SubItems[24].Text) ? Convert.ToDecimal(lvItem.SubItems[24].Text.Trim()) : oSupplement.VipDiscount_DiscountItem; // Discount for Discount Item
                                                oSupplement.VipDiscount_NoDiscountItem = Common.Utility.IsNumeric(lvItem.SubItems[25].Text) ? Convert.ToDecimal(lvItem.SubItems[25].Text.Trim()) : oSupplement.VipDiscount_NoDiscountItem; // Disocunt for No Discount Item
                                                oSupplement.StaffDiscount = Common.Utility.IsNumeric(lvItem.SubItems[26].Text) ? Convert.ToDecimal(lvItem.SubItems[26].Text.Trim()) : oSupplement.StaffDiscount; // Staff Discount
                                            }

                                            objProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                                            objProduct.ModifiedOn = DateTime.Now;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    ctx.PriceManagementBatchDetails.Remove(oDetail);
                                }
                                ctx.SaveChanges();
                            }
                        }
                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }
        */
        #endregion

        /// <summary>
        /// the Validation handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckValidationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
            }
        }

        /// <summary>
        /// Saves the message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    Helper.DesktopHelper.RefreshMainList<DiscountReasonList>();
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    PriceMgmtWizard wizard = new PriceMgmtWizard();
                    wizard.HeaderId = _HeaderId;
                    wizard.PMType = this.PMType;
                    wizard.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Saves the new message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    Helper.DesktopHelper.RefreshMainList<DiscountReasonList>();
                    this.Close();
                    PriceMgmtWizard wizard = new PriceMgmtWizard();
                    wizard.PMType = this.PMType;
                    wizard.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Saves the close message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    Helper.DesktopHelper.RefreshMainList<DiscountReasonList>();
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Deletes the confirmation handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var objPriceMgmtBatchHeader = ctx.PriceManagementBatchHeader.Find(this.HeaderId);
                if (objPriceMgmtBatchHeader != null)
                {
                    try
                    {
                        //string query = "HeaderId = '" + objPriceMgmtBatchHeader.HeaderId.ToString() + "'";
                        var objDetailList = ctx.PriceManagementBatchDetails
                            .Where(x => x.HeaderId == objPriceMgmtBatchHeader.HeaderId)
                            .ToList();
                        foreach (var objDetail in objDetailList)
                        {
                            ctx.PriceManagementBatchDetails.Remove(objDetail);
                        }

                        ctx.PriceManagementBatchHeader.Remove(objPriceMgmtBatchHeader);

                        ctx.SaveChanges();

                        MessageBox.Show("Record deleted!", "Delete Successful!");

                        this.Close();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Failed to delete!");
                    }
                }
            }
        }
    }
}