#region Using

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using RT2020.Controls;
using RT2020.Helper;

#endregion Using

namespace RT2020.AtsPane
{
    public partial class PurchasingAts : UserControl
    {
        public PurchasingAts()
        {
            InitializeComponent();

            SetAtsPurchase();
        }

        private void SetAtsPurchase()
        {
            nxStudio.BaseClass.WordDict oDict = new nxStudio.BaseClass.WordDict(ConfigHelper.CurrentWordDict, ConfigHelper.CurrentLanguageId);

            this.atsPurchase.MenuHandle = false;
            this.atsPurchase.DragHandle = false;
            this.atsPurchase.TextAlign = ToolBarTextAlign.Right;

            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem(oDict.GetWord("Purchase Orders (Multiple Loc#)"), string.Empty, "PurPurchaseOrders_MultipleLoc"));
            ddlNew.MenuItems.Add(new MenuItem(oDict.GetWord("Purchase Orders"), string.Empty, "PurPurchaseOrders"));

            MenuItem poAuth = new MenuItem(oDict.GetWord("P.O. Authentication"), string.Empty, "PurPurchaseOrders_Auth");
            poAuth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(poAuth);

            ddlNew.MenuItems.Add(new MenuItem("-"));
            ddlNew.MenuItems.Add(new MenuItem(oDict.GetWord("P.O. Receiving"), string.Empty, "PurGoodsReceive"));

            MenuItem recAuth = new MenuItem(oDict.GetWord("Receiving Authentication"), string.Empty, "PurGoodsReceive_Auth");
            recAuth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(recAuth);
            //ddlNew.MenuItems.Add(new MenuItem("Settle Orders", string.Empty, "PurSettleOrders"));

            ToolBarButton cmdNew = new ToolBarButton("New", oDict.GetWord("New"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            this.atsPurchase.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(AtsMenuClick);

            // cmdImport
            ContextMenu ddlImport = new ContextMenu();
            ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Receiving from PPC"), string.Empty, "PurImportReceivingPPC"));
            ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("PO Worksheet"), string.Empty, "PurImportWorksheet"));
            ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("PO Receive Worksheet"), string.Empty, "PurImportReceiveWorksheet"));
            ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Advanced Shipment Notice"), string.Empty, "PurImportAdvancedShipmentNotice"));

            ToolBarButton cmdImport = new ToolBarButton("Import", oDict.GetWord("Import"));
            cmdImport.Style = ToolBarButtonStyle.DropDownButton;
            cmdImport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdImport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdImport.DropDownMenu = ddlImport;

            this.atsPurchase.Buttons.Add(cmdImport);
            cmdImport.MenuClick += new MenuEventHandler(AtsMenuClick);

            // cmdExport
            ContextMenu ddlExport = new ContextMenu();
            ddlExport.MenuItems.Add(new MenuItem(oDict.GetWord("PO History Data"), string.Empty, "PurExportHistoryData"));

            ToolBarButton cmdExport = new ToolBarButton("Export", oDict.GetWord("Export"));
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.ico_16_exportCustomizations.gif");
            cmdExport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdExport.DropDownMenu = ddlExport;

            this.atsPurchase.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(AtsMenuClick);

            // Separator
            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            this.atsPurchase.Buttons.Add(sep);

            //  cmdReport
            ContextMenu ddlReport = new ContextMenu();
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("Worksheet"), string.Empty, "PurWorksheet"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("History"), string.Empty, "PurHistory"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("Voided Worksheet"), string.Empty, "PurVoidedWorksheet"));
            ddlReport.MenuItems.Add(new MenuItem("-"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("Order Status"), string.Empty, "PurOrderStatus"));
            ddlReport.MenuItems.Add(new MenuItem("-"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("Receiving Worksheet"), string.Empty, "PurRecvWorksheet"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("Receiving History"), string.Empty, "PurRecvHistory"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("Receiving Discrepency"), string.Empty, "PurRecvDiscrepency"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("Receiving Expected Weekly Summary"), string.Empty, "PurExpectedRecvSummay_Weekly"));

            ToolBarButton cmdReport = new ToolBarButton("Report", oDict.GetWord("Reports"));
            cmdReport.Style = ToolBarButtonStyle.DropDownButton;
            cmdReport.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdReport.DropDownMenu = ddlReport;

            this.atsPurchase.Buttons.Add(cmdReport);
            cmdReport.MenuClick += new MenuEventHandler(AtsMenuClick);
        }

        private void AtsMenuClick(object sender, MenuItemEventArgs e)
        {
            //Control[] controls = this.Form.Controls.Find("wspPane", true);
            //if (controls.Length > 0)
            //{
            //    Panel wspPane = (Panel)controls[0];
            //    wspPane.Text = (string)e.MenuItem.Text;
            //}

            if (!(e.MenuItem.Tag == null))
            {
                switch (e.MenuItem.Tag.ToString().ToLower())
                {
                    case "purpurchaseorders_multipleloc":
                        RT2020.Purchasing.Wizard.ByMultipleLocation wizMultipleLoc = new RT2020.Purchasing.Wizard.ByMultipleLocation();
                        wizMultipleLoc.ShowDialog();
                        break;
                    case "purpurchaseorders":
                        RT2020.Purchasing.Wizard.PurchaseOrder wizPO = new RT2020.Purchasing.Wizard.PurchaseOrder();
                        wizPO.ShowDialog();
                        break;
                    case "purpurchaseorders_auth":
                        RT2020.Purchasing.Wizard.AuthPurchaseOrder wizAuthPO = new RT2020.Purchasing.Wizard.AuthPurchaseOrder();
                        wizAuthPO.ShowDialog();
                        break;
                    case "purgoodsreceive":
                        RT2020.Purchasing.Wizard.ReceivingFind wizReceivingFind = new RT2020.Purchasing.Wizard.ReceivingFind();
                        wizReceivingFind.ShowDialog();
                        break;
                    case "purgoodsreceive_auth":
                        RT2020.Purchasing.Wizard.AuthPOReceiving wizAuthReceiving = new RT2020.Purchasing.Wizard.AuthPOReceiving();
                        wizAuthReceiving.ShowDialog();
                        break;
                    case "purreceivingppc":
                        RT2020.Purchasing.Import.FromPPC wizFromPPC = new RT2020.Purchasing.Import.FromPPC();
                        wizFromPPC.ShowDialog();
                        break;
                    case "purworksheet":
                        RT2020.Purchasing.Reports.PurchaseOrder.Worksheet wizWorksheet = new RT2020.Purchasing.Reports.PurchaseOrder.Worksheet();
                        wizWorksheet.ShowDialog();
                        break;
                    case "purhistory":
                        RT2020.Purchasing.Reports.PurchaseOrder.History wizHistory = new RT2020.Purchasing.Reports.PurchaseOrder.History();
                        wizHistory.ShowDialog();
                        break;
                    case "purvoidedworksheet":
                        RT2020.Purchasing.Reports.PurchaseOrder.VoidedWorksheet wizVoidedWorksheet = new RT2020.Purchasing.Reports.PurchaseOrder.VoidedWorksheet();
                        wizVoidedWorksheet.ShowDialog();
                        break;
                    case "purorderstatus":
                        RT2020.Purchasing.Reports.PurchaseOrder.OrderStatus wizOrderStatus = new RT2020.Purchasing.Reports.PurchaseOrder.OrderStatus();
                        wizOrderStatus.ShowDialog();
                        break;
                    case "purrecvworksheet":
                        RT2020.Purchasing.Reports.Receiving.Worksheet wizRecvWorksheet = new RT2020.Purchasing.Reports.Receiving.Worksheet();
                        wizRecvWorksheet.ShowDialog();
                        break;
                    case "purrecvhistory":
                        RT2020.Purchasing.Reports.Receiving.History wizRecvHistory = new RT2020.Purchasing.Reports.Receiving.History();
                        wizRecvHistory.ShowDialog();
                        break;
                    case "purrecvdiscrepency":
                        RT2020.Purchasing.Reports.Receiving.Discrepancy wizRecvDiscrepancy = new RT2020.Purchasing.Reports.Receiving.Discrepancy();
                        wizRecvDiscrepancy.ShowDialog();
                        break;
                    case "purexpectedrecvsummay_weekly":
                        RT2020.Purchasing.Reports.Receiving.WeeklyExpectedSummary wizRecvSummary = new RT2020.Purchasing.Reports.Receiving.WeeklyExpectedSummary();
                        wizRecvSummary.ShowDialog();
                        break;
                }
            }
        }

        private void atsPurchase_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            MessageBox.Show(e.Button.Text);
        }
    }
}