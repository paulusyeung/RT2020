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

namespace RT2020.Inventory.Adjustment
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
            this.atsAdjustment.MenuHandle = false;
            this.atsAdjustment.DragHandle = false;
            this.atsAdjustment.TextAlign = ToolBarTextAlign.Right;

            // cmdNew
            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Adjustment"), string.Empty, "Adjustment"));

            MenuItem adj = new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Adjustment (Authorization)"), string.Empty, "Adjustment_Authorization");
            adj.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(adj);

            ToolBarButton cmdNew = new ToolBarButton("New", RT2020.Controls.Utility.Dictionary.GetWord("New"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            this.atsAdjustment.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdImport
            ContextMenu ddlImport = new ContextMenu();
            ddlImport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Adjustment"), string.Empty, "Adjustment_Import"));
            ddlImport.MenuItems[0].Enabled = false;     // HACK: 未有這項功能

            ToolBarButton cmdImport = new ToolBarButton("Import", RT2020.Controls.Utility.Dictionary.GetWord("Import"));
            cmdImport.Style = ToolBarButtonStyle.DropDownButton;
            cmdImport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdImport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdImport.DropDownMenu = ddlImport;

            this.atsAdjustment.Buttons.Add(cmdImport);
            cmdImport.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdExport
            ContextMenu ddlExport = new ContextMenu();
            ddlExport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Adjustment"), string.Empty, "Adjustment_Export"));
            ddlExport.MenuItems[0].Enabled = false;     // HACK: 未有這項功能

            ToolBarButton cmdExport = new ToolBarButton("Export", RT2020.Controls.Utility.Dictionary.GetWord("Export"));
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdExport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdExport.DropDownMenu = ddlExport;

            atsAdjustment.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(cmdMenuClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            this.atsAdjustment.Buttons.Add(sep);

            // cmdReports
            ContextMenu ddlReports = new ContextMenu();
            ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Worksheet"), string.Empty, "Worksheet"));
            ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("History"), string.Empty, "History"));
            ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Journal"), string.Empty, "Journal"));

            ToolBarButton cmdReports = new ToolBarButton("Reports", RT2020.Controls.Utility.Dictionary.GetWord("Reports"));
            cmdReports.Style = ToolBarButtonStyle.DropDownButton;
            cmdReports.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReports.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdReports.DropDownMenu = ddlReports;

            this.atsAdjustment.Buttons.Add(cmdReports);
            cmdReports.MenuClick += new MenuEventHandler(cmdMenuClick);

            this.atsAdjustment.Buttons.Add(sep);

            //this.atsInvt.Buttons.Add(new ToolBarButton("StockStatus", "Stock Status"));
            //this.atsInvt.Buttons[3].Image = new IconResourceHandle("16x16.16_find.gif");
            //this.atsInvt.ButtonClick += new ToolBarButtonClickEventHandler(atsAdjustment_ButtonClick);

        }

        void cmdMenuClick(object sender, MenuItemEventArgs e)
        {
            if (!(e.MenuItem.Tag == null))
            {
                switch (e.MenuItem.Tag.ToString().ToLower())
                {
                    case "adjustment":
                        RT2020.Inventory.Adjustment.Wizard wizAdj = new RT2020.Inventory.Adjustment.Wizard();
                        wizAdj.ShowDialog();
                        break;
                    case "adjustment_authorization":
                        RT2020.Inventory.Adjustment.Authorization wizAuthAdj = new RT2020.Inventory.Adjustment.Authorization();
                        wizAuthAdj.ShowDialog();
                        break;
                    case "adjustment_import":
                        break;
                    case "adjustment_export":
                        break;
                    case "worksheet":
                        RT2020.Inventory.Adjustment.Reports.WorksheetWizard wizWorksheet = new RT2020.Inventory.Adjustment.Reports.WorksheetWizard();
                        wizWorksheet.ShowDialog();
                        break;
                    case "history":
                        RT2020.Inventory.Adjustment.Reports.HistoryWizard wizHistory = new RT2020.Inventory.Adjustment.Reports.HistoryWizard();
                        wizHistory.ShowDialog();
                        break;
                    case "journal":
                        RT2020.Inventory.Adjustment.Reports.JournalWizard wizJournal = new RT2020.Inventory.Adjustment.Reports.JournalWizard();
                        wizJournal.ShowDialog();
                        break;
                }
            }
        }

        private void atsAdjustment_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
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