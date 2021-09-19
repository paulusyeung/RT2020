#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Product;
using RT2020.Common.Helper;

#endregion

namespace RT2020.NavPane
{
    public partial class InventoryNav : UserControl
    {
        public InventoryNav()
        {
            InitializeComponent();

            NavPane.NavMenu.FillNavTree("inventory", this.navInvt.Nodes);
            navInvt.DoubleClick += navInvt_DoubleClick;
        }

        private void navInvt_DoubleClick(object sender, EventArgs e)
        {
            LoadModule();
        }

        private void navInvt_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadModule();
        }

        private void LoadModule()
        {
            Control[] controls = this.Form.Controls.Find("wspPane", true);
            if (controls.Length > 0)
            {
                var menuTag = (MenuHelper.MenuTag)navInvt.SelectedNode.Tag;

                Panel wspPane = (Panel)controls[0];
                if (menuTag != null)
                {
                    if (!menuTag.IsPopup)
                    {
                        wspPane.Text = navInvt.SelectedNode.Text;

                        wspPane.Controls.Clear();
                    }
                }

                ShowAppToolStrip(menuTag.ResourceId);
                ShowWorkspace(ref wspPane, menuTag.ResourceId);
                //ShowAppToolStrip((string)navInvt.SelectedNode.Tag);

                // 2020.08.28 paulus: RT2020 如果 wspPane 有 ActionStripBar，降低 list pane
                if (wspPane.Controls.Count > 1)
                {
                    wspPane.Controls[1].Margin = new Padding(0, 22, 0, 0);
                }
            }
        }

        #region Show private AppToolStrip
        // 2008.03.25 paulus: 淢少使用 Invneotry.InvtToolbar, 方便 code maintenance.
        private void ShowAppToolStrip(string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                Control[] controls = this.Form.Controls.Find("wspPane", true);
                if (controls.Length > 0)
                {
                    Panel atsPane = (Panel)controls[0];

                    switch (Tag.ToLower())
                    {
                        case "invt_goodsreceive":
                            RT2020.Inventory.GoodsReceive.DefaultAts oRecv = new RT2020.Inventory.GoodsReceive.DefaultAts();
                            oRecv.Dock = DockStyle.Top;
                            atsPane.Controls.Add(oRecv);
                            break;
                        case "invt_goodsreturn":
                            RT2020.Inventory.GoodsReturn.DefaultAts oReturn = new RT2020.Inventory.GoodsReturn.DefaultAts();
                            oReturn.Dock = DockStyle.Fill;
                            atsPane.Controls.Add(oReturn);
                            break;
                        case "invt_txfer":
                            RT2020.Inventory.Transfer.DefaultAts oTxfer = new RT2020.Inventory.Transfer.DefaultAts();
                            oTxfer.Dock = DockStyle.Fill;
                            atsPane.Controls.Add(oTxfer);
                            break;
                        case "invt_adjustment":
                            RT2020.Inventory.Adjustment.DefaultAts oAdjust = new RT2020.Inventory.Adjustment.DefaultAts();
                            oAdjust.Dock = DockStyle.Fill;
                            atsPane.Controls.Add(oAdjust);
                            break;
                        case "invt_replenishment":
                            RT2020.Inventory.Replenishment.DefaultAts oRepl = new RT2020.Inventory.Replenishment.DefaultAts();
                            oRepl.Dock = DockStyle.Top;
                            atsPane.Controls.Add(oRepl);
                            break;
                        case "invt_stocktake":
                            RT2020.Inventory.StockTake.DefaultAts oStockTake = new RT2020.Inventory.StockTake.DefaultAts();
                            oStockTake.Dock = DockStyle.Fill;
                            atsPane.Controls.Add(oStockTake);
                            break;
                    }
                }
            }
        }
        #endregion

        #region Show private Workspace
        private void ShowWorkspace(ref Panel wspPane, string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                Control[] controls = this.Form.Controls.Find("wspPane", true);

                // OLAP Viewer
                RT2020.Inventory.Olap.OlapViewForm oOlapViewer = new RT2020.Inventory.Olap.OlapViewForm();
                oOlapViewer.DockPadding.All = 6;
                oOlapViewer.Dock = DockStyle.Fill;

                switch (Tag.ToLower())
                {
                    case "invt_goodsreceive":
                        RT2020.Inventory.GoodsReceive.DefaultCAPList oRecv = new RT2020.Inventory.GoodsReceive.DefaultCAPList(controls[0]);
                        oRecv.DockPadding.All = 6;
                        oRecv.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oRecv);
                        break;
                    case "invt_goodsreturn":
                        RT2020.Inventory.GoodsReturn.DefaultREJList oReturn = new RT2020.Inventory.GoodsReturn.DefaultREJList(controls[0]);
                        oReturn.DockPadding.All = 6;
                        oReturn.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oReturn);
                        break;
                    case "invt_txfer":
                        RT2020.Inventory.Transfer.DefaultTXFList oTxfer = new RT2020.Inventory.Transfer.DefaultTXFList(controls[0]);
                        oTxfer.DockPadding.All = 6;
                        oTxfer.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oTxfer);
                        break;
                    case "invt_adjustment":
                        RT2020.Inventory.Adjustment.DefaultADJList oAdjust = new RT2020.Inventory.Adjustment.DefaultADJList(controls[0]);
                        oAdjust.DockPadding.All = 6;
                        oAdjust.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAdjust);
                        break;
                    case "invt_replenishment":
                        RT2020.Inventory.Replenishment.DefaultRPLList oReplenishment = new RT2020.Inventory.Replenishment.DefaultRPLList(controls[0]);
                        oReplenishment.DockPadding.All = 6;
                        oReplenishment.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oReplenishment);
                        break;
                    case "invt_stocktake":
                        RT2020.Inventory.StockTake.DefaultSTKTKList oStockTake = new RT2020.Inventory.StockTake.DefaultSTKTKList(controls[0]);
                        oStockTake.DockPadding.All = 6;
                        oStockTake.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oStockTake);
                        break;
                    case "productcare_product":
                        RT2020.Product.ProductList oProd = new RT2020.Product.ProductList(controls[0]);
                        oProd.DockPadding.All = 6;
                        oProd.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oProd);
                        break;
                    case "productcare_appendix1":
                        RT2020.Product.AppendixList oAppendix1List = new RT2020.Product.AppendixList(ProductHelper.Appendix.Appendix1, controls[0]);
                        oAppendix1List.DockPadding.All = 6;
                        oAppendix1List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAppendix1List);
                        break;
                    case "productcare_appendix2":
                        RT2020.Product.AppendixList oAppendix2List = new RT2020.Product.AppendixList(ProductHelper.Appendix.Appendix2, controls[0]);
                        oAppendix2List.DockPadding.All = 6;
                        oAppendix2List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAppendix2List);
                        break;
                    case "productcare_appendix3":
                        RT2020.Product.AppendixList oAppendix3List = new RT2020.Product.AppendixList(ProductHelper.Appendix.Appendix3, controls[0]);
                        oAppendix3List.DockPadding.All = 6;
                        oAppendix3List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAppendix3List);
                        break;
                    case "productcare_class1":
                        RT2020.Product.ClassList oClass1List = new RT2020.Product.ClassList("Class1", controls[0]);
                        oClass1List.DockPadding.All = 6;
                        oClass1List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass1List);
                        break;
                    case "productcare_class2":
                        RT2020.Product.ClassList oClass2List = new RT2020.Product.ClassList("Class2", controls[0]);
                        oClass2List.DockPadding.All = 6;
                        oClass2List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass2List);
                        break;
                    case "productcare_class3":
                        RT2020.Product.ClassList oClass3List = new RT2020.Product.ClassList("Class3", controls[0]);
                        oClass3List.DockPadding.All = 6;
                        oClass3List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass3List);
                        break;
                    case "productcare_class4":
                        RT2020.Product.ClassList oClass4List = new RT2020.Product.ClassList("Class4", controls[0]);
                        oClass4List.DockPadding.All = 6;
                        oClass4List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass4List);
                        break;
                    case "productcare_class5":
                        RT2020.Product.ClassList oClass5List = new RT2020.Product.ClassList("Class5", controls[0]);
                        oClass5List.DockPadding.All = 6;
                        oClass5List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass5List);
                        break;
                    case "productcare_class6":
                        RT2020.Product.ClassList oClass6List = new RT2020.Product.ClassList("Class6", controls[0]);
                        oClass6List.DockPadding.All = 6;
                        oClass6List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass6List);
                        break;
                    case "productcare_combination":
                        RT2020.Product.CombinationList oCombinList = new RT2020.Product.CombinationList(controls[0]);
                        oCombinList.DockPadding.All = 6;
                        oCombinList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oCombinList);
                        break;
                    case "productcare_analysiscode":
                        RT2020.Product.AnalysisCodeList oAnalysisList = new RT2020.Product.AnalysisCodeList(controls[0]);
                        oAnalysisList.DockPadding.All = 6;
                        oAnalysisList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAnalysisList);
                        break;
                    case "journal_goodsreceive":
                        RT2020.Inventory.GoodsReceive.Reports.JournalWizard wizCAPJournal = new RT2020.Inventory.GoodsReceive.Reports.JournalWizard();
                        wizCAPJournal.ShowDialog();
                        break;
                    case "journal_goodsreturn":
                        RT2020.Inventory.GoodsReturn.Reports.JournalWizard wizRETJournal = new RT2020.Inventory.GoodsReturn.Reports.JournalWizard();
                        wizRETJournal.ShowDialog();
                        break;
                    case "journal_transfer":
                        RT2020.Inventory.Transfer.Reports.JournalWizard wizTransferJournal = new RT2020.Inventory.Transfer.Reports.JournalWizard();
                        wizTransferJournal.ShowDialog();
                        break;
                    case "journal_adjustment":
                        RT2020.Inventory.Adjustment.Reports.JournalWizard wizADJJournal = new RT2020.Inventory.Adjustment.Reports.JournalWizard();
                        wizADJJournal.ShowDialog();
                        break;
                    case "journal_replenishment":
                        RT2020.Inventory.Replenishment.Reports.JournalWizard wizRPLJournal = new RT2020.Inventory.Replenishment.Reports.JournalWizard();
                        wizRPLJournal.ShowDialog();
                        break;
                    case "journal_stocktake":
                        RT2020.Inventory.StockTake.Reports.JournalWizard wizSTKTKJournal = new RT2020.Inventory.StockTake.Reports.JournalWizard();
                        wizSTKTKJournal.ShowDialog();
                        break;
                    case "olap_qohatsnormal":
                        oOlapViewer.ViewerType = RT2020.Controls.InvtUtility.InvtOlapViewerType.QoH_ATS;

                        wspPane.Controls.Add(oOlapViewer);
                        break;
                    case "olap_qohatsnormal_withas":
                        RT2020.Controls.Reporting.OlapViewer oOlapViewerAS = new RT2020.Controls.Reporting.OlapViewer();
                        oOlapViewerAS.DockPadding.All = 6;
                        oOlapViewerAS.Dock = DockStyle.Fill;
                        oOlapViewerAS.AspxPagePath = @"Inventory\Olap\QohAtsNormalWithOlapConnection.aspx";
                        wspPane.Controls.Add(oOlapViewerAS);
                        break;
                    case "olap_qohatscutoff":
                        oOlapViewer.ViewerType = RT2020.Controls.InvtUtility.InvtOlapViewerType.QoH_ATS_WithCutOffDate;

                        wspPane.Controls.Add(oOlapViewer);
                        break;
                    case "olap_stockreorder":
                        oOlapViewer.ViewerType = RT2020.Controls.InvtUtility.InvtOlapViewerType.StockReorder;

                        wspPane.Controls.Add(oOlapViewer);
                        break;
                    case "olap_stockinout":
                        oOlapViewer.ViewerType = RT2020.Controls.InvtUtility.InvtOlapViewerType.StockIOHistory;

                        wspPane.Controls.Add(oOlapViewer);
                        break;
                    case "olap_invtopeningclosing":
                        oOlapViewer.ViewerType = RT2020.Controls.InvtUtility.InvtOlapViewerType.OCInventory;

                        wspPane.Controls.Add(oOlapViewer);
                        break;
                    case "olap_stockvaluediscrepancyaudit":
                        oOlapViewer.ViewerType = RT2020.Controls.InvtUtility.InvtOlapViewerType.DiscrepancyAudit;

                        wspPane.Controls.Add(oOlapViewer);
                        break;
                    case "olap_stocktransfer":
                        oOlapViewer.ViewerType = RT2020.Controls.InvtUtility.InvtOlapViewerType.StockTransfer;

                        wspPane.Controls.Add(oOlapViewer);
                        break;
                    case "olap_capsummary":
                        oOlapViewer.ViewerType = RT2020.Controls.InvtUtility.InvtOlapViewerType.CAP_Summary;

                        wspPane.Controls.Add(oOlapViewer);
                        break;
                    case "invthistory_monthlyinout":
                        //RT2020.Inventory.Reports.History.InOutHistory_Monthly wizMonthlyHist = new RT2020.Inventory.Reports.History.InOutHistory_Monthly();
                        //wizMonthlyHist.ShowDialog();
                        var monthly = new RT2020.Inventory.Reports.Journal.Monthly();
                        monthly.DockPadding.All = 6;
                        monthly.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(monthly);
                        break;
                    case "invthistory_inoutlist":
                        //RT2020.Inventory.Reports.History.InOutHistory_List wizInOutList = new RT2020.Inventory.Reports.History.InOutHistory_List();
                        //wizInOutList.ShowDialog();
                        var list = new RT2020.Inventory.Reports.Journal.List();
                        list.DockPadding.All = 6;
                        list.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(list);
                        break;
                    case "invthistory_inoutsummary":
                        //RT2020.Inventory.Reports.History.InOutHistory_Summary wizInOutSummary = new RT2020.Inventory.Reports.History.InOutHistory_Summary();
                        //wizInOutSummary.ShowDialog();
                        var summary = new RT2020.Inventory.Reports.Journal.Summary();
                        summary.DockPadding.All = 6;
                        summary.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(summary);
                        break;
                    case "price_change":
                        RT2020.PriceMgmt.PriceMgmtList wizPriceChangeList = new RT2020.PriceMgmt.PriceMgmtList(controls[0], EnumHelper.PriceMgmtPMType.Price);
                        wizPriceChangeList.DockPadding.All = 6;
                        wizPriceChangeList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(wizPriceChangeList);
                        break;
                    case "discount_change":
                        RT2020.PriceMgmt.PriceMgmtList wizDiscChangeList = new RT2020.PriceMgmt.PriceMgmtList(controls[0], EnumHelper.PriceMgmtPMType.Discount);
                        wizDiscChangeList.DockPadding.All = 6;
                        wizDiscChangeList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(wizDiscChangeList);
                        break;
                    case "reason_code":
                        RT2020.PriceMgmt.DiscountReasonList oReasonList = new RT2020.PriceMgmt.DiscountReasonList(controls[0]);
                        oReasonList.DockPadding.All = 6;
                        oReasonList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oReasonList);
                        break;
                    case "sales_input":
                        RT2020.EmulatedPoS.DefaultList oSalesInputList = new RT2020.EmulatedPoS.DefaultList(controls[0], EnumHelper.TxType.CAS);
                        oSalesInputList.DockPadding.All = 6;
                        oSalesInputList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oSalesInputList);
                        break;
                    case "sales_return":
                        RT2020.EmulatedPoS.DefaultList oSalesReturnList = new RT2020.EmulatedPoS.DefaultList(controls[0], EnumHelper.TxType.CRT);
                        oSalesReturnList.DockPadding.All = 6;
                        oSalesReturnList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oSalesReturnList);
                        break;
                }
            }
        }
        #endregion
    }
}