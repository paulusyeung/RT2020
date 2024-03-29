#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using RT2020.Product;

using RT2020.Inventory;
using RT2020.Common.Helper;

#endregion

namespace RT2020.Inventory.Replenishment
{
    public partial class DefaultAts : UserControl
    {
        public DefaultAts()
        {
            InitializeComponent();

            SetAtsInvt();
        }

        private void SetAtsInvt()
        {
            this.atsReplenishment.MenuHandle = false;
            this.atsReplenishment.DragHandle = false;
            this.atsReplenishment.TextAlign = ToolBarTextAlign.Right;

            // cmdNew
            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Prepare Replenishment"), string.Empty, "Prepare_Replenishment"));
            //ddlNew.MenuItems.Add(new MenuItem("Replenishment", string.Empty, "Replenishment"));
            //ddlNew.MenuItems.Add(new MenuItem("Replenishment (Advance)", string.Empty, "Replenishment_Advance"));

            MenuItem confirm = new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Replenishment (Confirmation)"), string.Empty, "Replenishment_Confirmation");
            confirm.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(confirm);

            MenuItem auth = new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Replenishment (Authorization)"), string.Empty, "Replenishment_Authorization");
            auth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(auth);

            ToolBarButton cmdNew = new ToolBarButton("New", RT2020.Controls.Utility.Dictionary.GetWord("New"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            this.atsReplenishment.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdImport
            ContextMenu ddlImport = new ContextMenu();
            ddlImport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Replenishment"), string.Empty, "Replenishment"));
            ddlImport.MenuItems[0].Enabled = false;     // HACK: 未有這項功能

            ToolBarButton cmdImport = new ToolBarButton("Import", RT2020.Controls.Utility.Dictionary.GetWord("Import"));
            cmdImport.Style = ToolBarButtonStyle.DropDownButton;
            cmdImport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdImport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdImport.DropDownMenu = ddlImport;

            this.atsReplenishment.Buttons.Add(cmdImport);
            cmdImport.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdExport
            ContextMenu ddlExport = new ContextMenu();
            ddlExport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Replenishment"), string.Empty, "Replenishment"));
            ddlExport.MenuItems[0].Enabled = false;     // HACK: 未有這項功能

            ToolBarButton cmdExport = new ToolBarButton("Export", RT2020.Controls.Utility.Dictionary.GetWord("Export"));
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdExport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdExport.DropDownMenu = ddlExport;

            atsReplenishment.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(cmdMenuClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            this.atsReplenishment.Buttons.Add(sep);

            // cmdReports
            ContextMenu ddlReports = new ContextMenu();
            ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Worksheet"), string.Empty, "Worksheet"));
            ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("History"), string.Empty, "History"));
            //ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Journal"), string.Empty, "Journal"));

            ToolBarButton cmdReports = new ToolBarButton("Reports", RT2020.Controls.Utility.Dictionary.GetWord("Reports"));
            cmdReports.Style = ToolBarButtonStyle.DropDownButton;
            cmdReports.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReports.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdReports.DropDownMenu = ddlReports;

            this.atsReplenishment.Buttons.Add(cmdReports);
            cmdReports.MenuClick += new MenuEventHandler(cmdMenuClick);

            this.atsReplenishment.Buttons.Add(sep);

            //this.atsInvt.Buttons.Add(new ToolBarButton("StockStatus", "Stock Status"));
            //this.atsInvt.Buttons[3].Image = new IconResourceHandle("16x16.16_find.gif");
            //this.atsInvt.ButtonClick += new ToolBarButtonClickEventHandler(atsReplenishment_ButtonClick);

        }

        void cmdMenuClick(object sender, MenuItemEventArgs e)
        {
            if (!(e.MenuItem.Tag == null))
            {
                switch (e.MenuItem.Tag.ToString().ToLower())
                {
                    case "prepare_replenishment":
                        RT2020.Inventory.Replenishment.Preparation wizRepPreparation = new RT2020.Inventory.Replenishment.Preparation();
                        wizRepPreparation.ShowDialog();
                        break;
                    case "replenishment":
                        RT2020.Inventory.Replenishment.Wizard wizRPL = new RT2020.Inventory.Replenishment.Wizard();
                        wizRPL.ShowDialog();
                        break;
                    case "replenishment_advance":
                        RT2020.Inventory.Replenishment.Wizard_Advance wizRPLAdv = new RT2020.Inventory.Replenishment.Wizard_Advance();
                        wizRPLAdv.ShowDialog();
                        break;
                    case "replenishment_confirmation":
                        RT2020.Inventory.Replenishment.Confirmation wizConfirm = new RT2020.Inventory.Replenishment.Confirmation();
                        wizConfirm.ShowDialog();
                        break;
                    case "replenishment_authorization":
                        RT2020.Inventory.Replenishment.Authorization wizAuth = new RT2020.Inventory.Replenishment.Authorization();
                        wizAuth.ShowDialog();
                        break;
                    case "worksheet":
                        RT2020.Inventory.Replenishment.Reports.WorksheetWizard wizWorksheet = new RT2020.Inventory.Replenishment.Reports.WorksheetWizard();
                        wizWorksheet.ShowDialog();
                        break;
                    case "history":
                        RT2020.Inventory.Replenishment.Reports.HistoryWizard wizHistory = new RT2020.Inventory.Replenishment.Reports.HistoryWizard();
                        wizHistory.ShowDialog();
                        break;
                    case "journal":
                        RT2020.Inventory.Replenishment.Reports.JournalWizard wizJournal = new RT2020.Inventory.Replenishment.Reports.JournalWizard();
                        wizJournal.ShowDialog();
                        break;
                }
            }
        }

        private void atsReplenishment_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Control[] controls = this.Form.Controls.Find("wspPane", true);
            if (controls.Length > 0)
            {
                Panel wspPane = (Panel)controls[0];
                wspPane.Text = (string)e.Button.Text;
            }
        }
    }
}