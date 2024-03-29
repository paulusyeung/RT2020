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
using RT2020.Controls;
using RT2020.Common.Helper;

#endregion

namespace RT2020.Inventory.StockTake
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
            this.atsStockTake.MenuHandle = false;
            this.atsStockTake.DragHandle = false;
            this.atsStockTake.TextAlign = ToolBarTextAlign.Right;

            // cmdNew
            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Stock Take - All Items"), string.Empty, "StockTake_AllItems"));
            ddlNew.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Stock Take - Partial"), string.Empty, "StockTake_Partial"));
            //ddlNew.MenuItems.Add(new MenuItem("Stock Take", string.Empty, "StockTake"));
            ddlNew.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Re-Capture On-Hand Quantity"), string.Empty, "Recapture_OnHand_Quantity"));

            MenuItem approval = new MenuItem(Utility.Dictionary.GetWord("Stock Take - Approval"), string.Empty, "StockTake_Approval");
            approval.Enabled = UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(approval);

            MenuItem auth = new MenuItem(Utility.Dictionary.GetWord("Stock Take (Authorization)"), string.Empty, "StockTake_Authorization");
            auth.Enabled = UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(auth);

            ToolBarButton cmdNew = new ToolBarButton("New", Utility.Dictionary.GetWord("New"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            this.atsStockTake.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdImport
            ContextMenu ddlImport = new ContextMenu();
            ddlImport.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("From PPC"), string.Empty, "ImportFromPPC"));
            ddlImport.MenuItems[0].Icon = new IconResourceHandle("16x16.16_ppc.png");
            ddlImport.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("From POS"), string.Empty, "ImportFromPOS"));
            ddlImport.MenuItems.Add(new MenuItem("-", string.Empty, "-"));
            ddlImport.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("HHT Data Review and Summation"), string.Empty, "HHTReview_Summation"));

            ToolBarButton cmdImport = new ToolBarButton("Import", Utility.Dictionary.GetWord("Import"));
            cmdImport.Style = ToolBarButtonStyle.DropDownButton;
            cmdImport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdImport.Enabled = UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdImport.DropDownMenu = ddlImport;

            this.atsStockTake.Buttons.Add(cmdImport);
            cmdImport.MenuClick += new MenuEventHandler(cmdMenuClick);

            // cmdExport
            ContextMenu ddlExport = new ContextMenu();
            ddlExport.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Stock Take"), string.Empty, "StockTake"));
            ddlExport.MenuItems[0].Visible = false;     // HACK: 未有這項功能

            ToolBarButton cmdExport = new ToolBarButton("Export", Utility.Dictionary.GetWord("Export"));
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdExport.Enabled = UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdExport.DropDownMenu = ddlExport;

            atsStockTake.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(cmdMenuClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            this.atsStockTake.Buttons.Add(sep);

            // cmdReports
            ContextMenu ddlReports = new ContextMenu();
            ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("HHT Worksheet"), string.Empty, "Rpt_HHTWorksheet"));
            ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("HHT History"), string.Empty, "Rpt_HHTHistory"));
            ddlReports.MenuItems.Add(new MenuItem("-", string.Empty, "-"));
            ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Worksheet"), string.Empty, "Rpt_Worksheet"));
            ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("History"), string.Empty, "Rpt_History"));
            //ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Journal"), string.Empty, "Rpt_Journal"));
            ddlReports.MenuItems.Add(new MenuItem("-", string.Empty, "-"));
            ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Variance List") + " " + Utility.Dictionary.GetWord("Worksheet"), string.Empty, "Rpt_VarianceWorksheet"));
            ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Variance List") + " " + Utility.Dictionary.GetWord("History"), string.Empty, "Rpt_VarianceHistory"));
            ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Variance List") + " " + Utility.Dictionary.GetWord("Worksheet") + " (" + Utility.Dictionary.GetWord("Without Cost") + ")", string.Empty, "Rpt_VarianceWorksheet_withoutCost"));
            ddlReports.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Variance List") + " " + Utility.Dictionary.GetWord("History") + " (" + Utility.Dictionary.GetWord("Without Cost") + ")", string.Empty, "Rpt_VarianceHistory_withoutCost"));

            ToolBarButton cmdReports = new ToolBarButton("Reports", Utility.Dictionary.GetWord("Reports"));
            cmdReports.Style = ToolBarButtonStyle.DropDownButton;
            cmdReports.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReports.Enabled = UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdReports.DropDownMenu = ddlReports;

            this.atsStockTake.Buttons.Add(cmdReports);
            cmdReports.MenuClick += new MenuEventHandler(cmdMenuClick);

            //this.atsStockTake.Buttons.Add(sep);

            //this.atsInvt.Buttons.Add(new ToolBarButton("StockStatus", "Stock Status"));
            //this.atsInvt.Buttons[3].Image = new IconResourceHandle("16x16.16_find.gif");
            //this.atsInvt.ButtonClick += new ToolBarButtonClickEventHandler(atsStockTake_ButtonClick);

        }

        void cmdMenuClick(object sender, MenuItemEventArgs e)
        {
            if (!(e.MenuItem.Tag == null))
            {
                switch (e.MenuItem.Tag.ToString().ToLower())
                {
                    case "stocktake_allitems":
                        RT2020.Inventory.StockTake.AllItems wizStkAll = new RT2020.Inventory.StockTake.AllItems();
                        wizStkAll.ShowDialog();
                        break;
                    case "stocktake_partial":
                        RT2020.Inventory.StockTake.PartialItems wizStkPartial = new RT2020.Inventory.StockTake.PartialItems();
                        wizStkPartial.ShowDialog();
                        break;
                    case "stocktake":
                        RT2020.Inventory.StockTake.Wizard wizStockTake = new RT2020.Inventory.StockTake.Wizard();
                        wizStockTake.ShowDialog();
                        break;
                    case "importfromppc":
                        RT2020.Inventory.StockTake.Import.ImportFromPPC wizPPC = new RT2020.Inventory.StockTake.Import.ImportFromPPC();
                        wizPPC.ShowDialog();
                        break;
                    case "importfrompos":
                        RT2020.Inventory.StockTake.Import.ImportFromPoS wizPoS = new RT2020.Inventory.StockTake.Import.ImportFromPoS();
                        wizPoS.ShowDialog();
                        break;
                    case "importfrompalm":
                        break;
                    case "hhtreview_summation":
                        RT2020.Inventory.StockTake.HHTDataReviewAndSummation wizReview_Summation = new HHTDataReviewAndSummation();
                        wizReview_Summation.ShowDialog();
                        break;
                    case "recapture_onhand_quantity":
                        RT2020.Inventory.StockTake.RecaptureOnhand wizRecaptureOnhand = new RT2020.Inventory.StockTake.RecaptureOnhand();
                        wizRecaptureOnhand.ShowDialog();
                        break;
                    case "stocktake_approval":
                        RT2020.Inventory.StockTake.Approval wizApproval = new RT2020.Inventory.StockTake.Approval();
                        wizApproval.ShowDialog();
                        break;
                    case "stocktake_authorization":
                        RT2020.Inventory.StockTake.Authorization wizAuthStk = new RT2020.Inventory.StockTake.Authorization();
                        wizAuthStk.ShowDialog();
                        break;
                    case "rpt_worksheet":
                        RT2020.Inventory.StockTake.Reports.Worksheet wizRptWorksheet = new RT2020.Inventory.StockTake.Reports.Worksheet();
                        wizRptWorksheet.ShowDialog();
                        break;
                    case "rpt_history":
                        RT2020.Inventory.StockTake.Reports.History wizRptHistory = new RT2020.Inventory.StockTake.Reports.History();
                        wizRptHistory.ShowDialog();
                        break;
                    case "rpt_journal":
                        RT2020.Inventory.StockTake.Reports.JournalWizard wizRptJournal = new RT2020.Inventory.StockTake.Reports.JournalWizard();
                        wizRptJournal.ShowDialog();
                        break;
                    case "rpt_hhtworksheet":
                        RT2020.Inventory.StockTake.Reports.HHTWorksheet wizHHTWorksheet = new RT2020.Inventory.StockTake.Reports.HHTWorksheet();
                        wizHHTWorksheet.ShowDialog();
                        break;
                    case "rpt_hhthistory":
                        RT2020.Inventory.StockTake.Reports.HHTHistory wizHHTHistory = new RT2020.Inventory.StockTake.Reports.HHTHistory();
                        wizHHTHistory.ShowDialog();
                        break;
                    case "rpt_varianceworksheet":
                        RT2020.Inventory.StockTake.Reports.VarianceList wizVarianceWorksheet = new RT2020.Inventory.StockTake.Reports.VarianceList();
                        wizVarianceWorksheet.ReportType = RT2020.Inventory.StockTake.Reports.VarianceList.VarianceReportType.Worksheet;
                        wizVarianceWorksheet.ShowDialog();
                        break;
                    case "rpt_variancehistory":
                        RT2020.Inventory.StockTake.Reports.VarianceList wizVarianceHistory = new RT2020.Inventory.StockTake.Reports.VarianceList();
                        wizVarianceHistory.ReportType = RT2020.Inventory.StockTake.Reports.VarianceList.VarianceReportType.History;
                        wizVarianceHistory.ShowDialog();
                        break;
                    case "rpt_varianceworksheet_withoutcost":
                        RT2020.Inventory.StockTake.Reports.VarianceList wizVarianceWorksheetWithoutCost = new RT2020.Inventory.StockTake.Reports.VarianceList();
                        wizVarianceWorksheetWithoutCost.ReportType = RT2020.Inventory.StockTake.Reports.VarianceList.VarianceReportType.WorksheetWithoutCost;
                        wizVarianceWorksheetWithoutCost.ShowDialog();
                        break;
                    case "rpt_variancehistory_withoutcost":
                        RT2020.Inventory.StockTake.Reports.VarianceList wizVarianceHistoryWithoutCost = new RT2020.Inventory.StockTake.Reports.VarianceList();
                        wizVarianceHistoryWithoutCost.ReportType = RT2020.Inventory.StockTake.Reports.VarianceList.VarianceReportType.HistoryWithoutCost;
                        wizVarianceHistoryWithoutCost.ShowDialog();
                        break;
                }
            }
        }

        private void atsStockTake_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
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