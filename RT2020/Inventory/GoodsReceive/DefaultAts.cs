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

namespace RT2020.Inventory.GoodsReceive
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
            this.atsGoodsReceive.MenuHandle = false;
            this.atsGoodsReceive.DragHandle = false;
            this.atsGoodsReceive.TextAlign = ToolBarTextAlign.Right;

            // cmdNew
            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Goods Receive"), string.Empty, "Goods_Receive"));

            MenuItem rec = new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Goods Receive (Authorization)"), string.Empty, "Goods_Receive_Authorization");
            rec.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Posting);
            ddlNew.MenuItems.Add(rec);

            ToolBarButton cmdNew = new ToolBarButton("New", RT2020.Controls.Utility.Dictionary.GetWord("New"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            this.atsGoodsReceive.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdImport
            ContextMenu ddlImport = new ContextMenu();
            ddlImport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Goods Receive") + " (Excel)", string.Empty, "Goods_Receive_Import_Xls"));
            ddlImport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Goods Receive") + " (Text)", string.Empty, "Goods_Receive_Import_Txt"));
            ddlImport.MenuItems[0].Enabled = true;

            ToolBarButton cmdImport = new ToolBarButton("Import", RT2020.Controls.Utility.Dictionary.GetWord("Import"));
            cmdImport.Style = ToolBarButtonStyle.DropDownButton;
            cmdImport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdImport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            cmdImport.DropDownMenu = ddlImport;

            this.atsGoodsReceive.Buttons.Add(cmdImport);
            cmdImport.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdExport
            ContextMenu ddlExport = new ContextMenu();
            ddlExport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Goods Receive"), string.Empty, "Goods_Receive_Export"));

            ToolBarButton cmdExport = new ToolBarButton("Export", RT2020.Controls.Utility.Dictionary.GetWord("Export"));
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdExport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            cmdExport.DropDownMenu = ddlExport;

            atsGoodsReceive.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(cmdMenuClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            this.atsGoodsReceive.Buttons.Add(sep);

            // cmdReports
            ContextMenu ddlReports = new ContextMenu();
            ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Worksheet"), string.Empty, "Worksheet"));
            ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("History"), string.Empty, "History"));
            ddlReports.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Journal"), string.Empty, "Journal"));

            ToolBarButton cmdReports = new ToolBarButton("Reports", RT2020.Controls.Utility.Dictionary.GetWord("Reports"));
            cmdReports.Style = ToolBarButtonStyle.DropDownButton;
            cmdReports.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReports.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            cmdReports.DropDownMenu = ddlReports;

            this.atsGoodsReceive.Buttons.Add(cmdReports);
            cmdReports.MenuClick += new MenuEventHandler(cmdMenuClick);

            this.atsGoodsReceive.Buttons.Add(sep);

            //this.atsInvt.Buttons.Add(new ToolBarButton("StockStatus", "Stock Status"));
            //this.atsInvt.Buttons[3].Image = new IconResourceHandle("16x16.16_find.gif");
            //this.atsInvt.ButtonClick += new ToolBarButtonClickEventHandler(atsGoodsReceive_ButtonClick);

        }

        void cmdMenuClick(object sender, MenuItemEventArgs e)
        {
            if (!(e.MenuItem.Tag == null))
            {
                switch (e.MenuItem.Tag.ToString().ToLower())
                {
                    case "goods_receive":
                        RT2020.Inventory.GoodsReceive.Wizard wizCAP = new RT2020.Inventory.GoodsReceive.Wizard();
                        wizCAP.ShowDialog();
                        break;
                    case "goods_receive_authorization":
                        RT2020.Inventory.GoodsReceive.Authorization wizAuthRecv = new RT2020.Inventory.GoodsReceive.Authorization();
                        wizAuthRecv.ShowDialog();
                        break;
                    case "goods_receive_import_xls":
                        RT2020.Inventory.GoodsReceive.Import.ImportXls wizXlsImport = new RT2020.Inventory.GoodsReceive.Import.ImportXls();
                        wizXlsImport.ShowDialog();
                        break;
                    case "goods_receive_import_txt":
                        RT2020.Inventory.GoodsReceive.Import.ImportTxt wizCAPTxtImport = new RT2020.Inventory.GoodsReceive.Import.ImportTxt();
                        wizCAPTxtImport.ShowDialog();
                        break;
                    case "goods_receive_export":
                        RT2020.Inventory.GoodsReceive.Export.Export2Txt wizCAPExport = new RT2020.Inventory.GoodsReceive.Export.Export2Txt();
                        wizCAPExport.ShowDialog();
                        break;
                    case "worksheet":
                        RT2020.Inventory.GoodsReceive.Reports.WorksheetWizard wizWorksheet = new RT2020.Inventory.GoodsReceive.Reports.WorksheetWizard();
                        wizWorksheet.ShowDialog();
                        break;
                    case "history":
                        RT2020.Inventory.GoodsReceive.Reports.HistoryWizard wizHistory = new RT2020.Inventory.GoodsReceive.Reports.HistoryWizard();
                        wizHistory.ShowDialog();
                        break;
                    case "journal":
                        RT2020.Inventory.GoodsReceive.Reports.JournalWizard wizJournal = new RT2020.Inventory.GoodsReceive.Reports.JournalWizard();
                        wizJournal.ShowDialog();
                        break;
                }
            }
        }

        private void atsGoodsReceive_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
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