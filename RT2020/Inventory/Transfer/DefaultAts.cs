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
using RT2020.DAL;
using RT2020.Inventory;

#endregion

namespace RT2020.Inventory.Transfer
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
            this.atsTransfer.MenuHandle = false;
            this.atsTransfer.DragHandle = false;
            this.atsTransfer.TextAlign = ToolBarTextAlign.Right;

            // cmdNew
            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Transfer"), string.Empty, "Transfer"));
            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Transfer - Picking Note"), string.Empty, "Transfer_Picking_Note"));
            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Transfer - Picking Note (Fast)"), string.Empty, "Transfer_Picking_Note_Fast"));
            ddlNew.MenuItems.Add(new MenuItem("-"));

            MenuItem auth = new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Transfer - Authorization"), string.Empty, "Transfer_Authorization");
            auth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Posting);
            ddlNew.MenuItems.Add(auth);

            MenuItem confirm = new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Transfer - Confirmation"), string.Empty, "Transfer_Confirmation");
            confirm.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Posting);
            ddlNew.MenuItems.Add(confirm);

            ToolBarButton cmdNew = new ToolBarButton("New", RT2020.Controls.Utility.Dictionary.GetWord("New"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            this.atsTransfer.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdImport
            ContextMenu ddlImport = new ContextMenu();
            ddlImport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Transfer"), string.Empty, "Transfer_Import"));
            ddlImport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Transfer (Advance)"), string.Empty, "Transfer_Import_Advance"));

            ToolBarButton cmdImport = new ToolBarButton("Import", RT2020.Controls.Utility.Dictionary.GetWord("Import"));
            cmdImport.Style = ToolBarButtonStyle.DropDownButton;
            cmdImport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdImport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            cmdImport.DropDownMenu = ddlImport;

            this.atsTransfer.Buttons.Add(cmdImport);
            cmdImport.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdExport
            ContextMenu ddlExport = new ContextMenu();
            ddlExport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Transfer"), string.Empty, "Transfer_Export"));

            ToolBarButton cmdExport = new ToolBarButton("Export", RT2020.Controls.Utility.Dictionary.GetWord("Export"));
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdExport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            cmdExport.DropDownMenu = ddlExport;

            atsTransfer.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(cmdMenuClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            this.atsTransfer.Buttons.Add(sep);

            #region cmdReports
            switch (RT2020.Controls.UserUtility.SecurityLevel())
            {
                case "1":
                    ContextMenu ddlReports1 = new ContextMenu();
                    //ddlReports1.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Worksheet"), string.Empty, "Worksheet"));
                    ddlReports1.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("History"), string.Empty, "History"));
                    //ddlReports1.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Journal"), string.Empty, "Journal"));

                    ToolBarButton cmdReports1 = new ToolBarButton("Reports", RT2020.Controls.Utility.Dictionary.GetWord("Reports"));
                    cmdReports1.Style = ToolBarButtonStyle.DropDownButton;
                    cmdReports1.Image = new IconResourceHandle("16x16.16_reports.gif");
                    cmdReports1.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
                    cmdReports1.DropDownMenu = ddlReports1;

                    this.atsTransfer.Buttons.Add(cmdReports1);
                    cmdReports1.MenuClick += new MenuEventHandler(cmdMenuClick);

                    this.atsTransfer.Buttons.Add(sep);
                    break;
                default:
                    ContextMenu ddlReports = new ContextMenu();
                    ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Worksheet"), string.Empty, "Worksheet"));
                    ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("History"), string.Empty, "History"));
                    ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Journal"), string.Empty, "Journal"));

                    ToolBarButton cmdReports = new ToolBarButton("Reports", RT2020.Controls.Utility.Dictionary.GetWord("Reports"));
                    cmdReports.Style = ToolBarButtonStyle.DropDownButton;
                    cmdReports.Image = new IconResourceHandle("16x16.16_reports.gif");
                    cmdReports.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
                    cmdReports.DropDownMenu = ddlReports;

                    this.atsTransfer.Buttons.Add(cmdReports);
                    cmdReports.MenuClick += new MenuEventHandler(cmdMenuClick);

                    this.atsTransfer.Buttons.Add(sep);
                    break;
            }
            #endregion
        }

        void cmdMenuClick(object sender, MenuItemEventArgs e)
        {
            if (!(e.MenuItem.Tag == null))
            {
                switch (e.MenuItem.Tag.ToString().ToLower())
                {
                    case "transfer":
                        RT2020.Inventory.Transfer.Wizard wizTxfer = new RT2020.Inventory.Transfer.Wizard(Common.Enums.TxType.TXF);
                        wizTxfer.ShowDialog();
                        break;
                    case "transfer_picking_note":
                        RT2020.Inventory.Transfer.Wizard wizTxfer_PNQ = new RT2020.Inventory.Transfer.Wizard(Common.Enums.TxType.PNQ);
                        wizTxfer_PNQ.ShowDialog();
                        break;
                    case "transfer_picking_note_fast":
                        RT2020.Inventory.Transfer.PickingNoteFast wizPNQFast = new RT2020.Inventory.Transfer.PickingNoteFast();
                        wizPNQFast.ShowDialog();
                        break;
                    case "transfer_authorization":
                        RT2020.Inventory.Transfer.Authorization wizAuth = new Authorization();
                        wizAuth.ShowDialog();
                        break;
                    case "transfer_confirmation":
                        Confirmation wizConfirm = new Confirmation();
                        wizConfirm.ShowDialog();
                        break;
                    case "transfer_import":
                        RT2020.Inventory.Transfer.Import.ImportTxt wizTxferImport = new RT2020.Inventory.Transfer.Import.ImportTxt();
                        wizTxferImport.ShowDialog();
                        break;
                    case "transfer_import_advance":
                        RT2020.Inventory.Transfer.Import.AdvanceImport wizTxferImportAdv = new RT2020.Inventory.Transfer.Import.AdvanceImport();
                        wizTxferImportAdv.ShowDialog();
                        break;
                    case "transfer_export":
                        RT2020.Inventory.Transfer.Export.Export2Txt wizTxferExport = new RT2020.Inventory.Transfer.Export.Export2Txt();
                        wizTxferExport.ShowDialog();
                        break;
                    case "worksheet":
                        RT2020.Inventory.Transfer.Reports.WorksheetWizard wizWorksheet = new RT2020.Inventory.Transfer.Reports.WorksheetWizard();
                        wizWorksheet.ShowDialog();
                        break;
                    case "history":
                        RT2020.Inventory.Transfer.Reports.HistoryWizard wizHistory = new RT2020.Inventory.Transfer.Reports.HistoryWizard();
                        wizHistory.ShowDialog();
                        break;
                    case "journal":
                        RT2020.Inventory.Transfer.Reports.JournalWizard wizJournal = new RT2020.Inventory.Transfer.Reports.JournalWizard();
                        wizJournal.ShowDialog();
                        break;
                }
            }
        }

        private void atsTransfer_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
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