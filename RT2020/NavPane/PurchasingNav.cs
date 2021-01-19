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
using RT2020.Helper;

#endregion

namespace RT2020.NavPane
{
    public partial class PurchasingNav : UserControl
    {
        public PurchasingNav()
        {
            InitializeComponent();

            NavPane.NavMenu.FillNavTree("purchasing", this.navPurchase.Nodes);
        }

        private void navPurchase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Control[] controls = this.Form.Controls.Find("wspPane", true);
            if (controls.Length > 0)
            {
                Panel wspPane = (Panel)controls[0];
                wspPane.Text = navPurchase.SelectedNode.Text;

                wspPane.Controls.Clear();

                ShowAppToolStrip((string)navPurchase.SelectedNode.Tag);
                ShowWorkspace(ref wspPane, (string)navPurchase.SelectedNode.Tag);
                //ShowAppToolStrip((string)navPurchase.SelectedNode.Tag);

                // 2020.08.28 paulus: RT2020 如果 wspPane 有 ActionStripBar，降低 list pane
                if (wspPane.Controls.Count > 1)
                {
                    wspPane.Controls[1].Margin = new Padding(0, 22, 0, 0);
                }
            }
        }

        #region Show private AppToolStrip
        private void ShowAppToolStrip(string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                Control[] controls = this.Form.Controls.Find("wspPane", true);
                if (controls.Length > 0)
                {
                    Panel wspPane = (Panel)controls[0];

                    switch (Tag.ToLower())
                    {
                        case "pur_purchaseorders":
                        case "pur_goodsreturn":
                        case "pur_poreceiving":
                        case "pur_settleorders":
                            RT2020.AtsPane.PurchasingAts oAtsPurchasing = new RT2020.AtsPane.PurchasingAts();
                            oAtsPurchasing.Dock = DockStyle.Top;
                            wspPane.Controls.Add(oAtsPurchasing);
                            break;
                        case "pur_blankworksheet":
                            break;
                        case "pur_worksheet":
                            break;
                        case "pur_history":
                            break;
                        case "pur_printableorders":
                            break;
                        case "pur_excelmatrix":
                            break;
                        case "pur_ordersummary":
                            break;
                        case "pur_olapordersummary":
                            //RT2020.Inventory.GoodsReceive.DefaultAts oRecv = new RT2020.Inventory.GoodsReceive.DefaultAts();
                            //oRecv.Dock = DockStyle.Fill;
                            //atsPane.Controls.Clear();
                            //atsPane.Controls.Add(oRecv);
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
                //Control[] controls = this.Form.Controls.Find("atsPane", true);
                // 2020.08.28 paulus: RT2020 搬咗個 ActionStripBar 落嚟 wspPane 度
                Control[] controls = this.Form.Controls.Find("wspPane", true);

                switch (Tag.ToLower())
                {
                    case "pur_purchaseorders":
                        RT2020.Purchasing.DefaultPOList oPOList = new RT2020.Purchasing.DefaultPOList();
                        oPOList.DockPadding.All = 6;
                        oPOList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oPOList);
                        break;
                    case "pur_poreceiving":
                        RT2020.Purchasing.DefaultRECList oPORecvList = new RT2020.Purchasing.DefaultRECList();
                        oPORecvList.DockPadding.All = 6;
                        oPORecvList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oPORecvList);
                        break;
                    case "pur_settleorders":
                        RT2020.Purchasing.DefaultOSTList oOSTList = new RT2020.Purchasing.DefaultOSTList();
                        oOSTList.DockPadding.All = 6;
                        oOSTList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oOSTList);
                        break;
                    case "pur_blankworksheet":
                        RT2020.Purchasing.Reports.ReceivingSchedule.BlankSheet wizBlankSheet = new RT2020.Purchasing.Reports.ReceivingSchedule.BlankSheet();
                        wizBlankSheet.ShowDialog();
                        break;
                    case "pur_worksheet":
                        RT2020.Purchasing.Reports.ReceivingSchedule.Worksheet wizWorksheet = new RT2020.Purchasing.Reports.ReceivingSchedule.Worksheet();
                        wizWorksheet.ShowDialog();
                        break;
                    case "pur_history":
                        RT2020.Purchasing.Reports.ReceivingSchedule.History wizHistory = new RT2020.Purchasing.Reports.ReceivingSchedule.History();
                        wizHistory.ShowDialog();
                        break;
                    case "pur_printableorders":
                        RT2020.Purchasing.Reports.OfficialDocument.PrintableOrders wizPOrders = new RT2020.Purchasing.Reports.OfficialDocument.PrintableOrders();
                        wizPOrders.ShowDialog();
                        break;
                    case "pur_excelmatrix":
                        RT2020.Purchasing.Reports.OfficialDocument.ExcelMatrix wizXlsMatrix = new RT2020.Purchasing.Reports.OfficialDocument.ExcelMatrix();
                        wizXlsMatrix.ShowDialog();
                        break;
                    case "pur_ordersummary":
                        RT2020.Purchasing.Reports.OfficialDocument.OrderSummary wizOrderSummary = new RT2020.Purchasing.Reports.OfficialDocument.OrderSummary();
                        wizOrderSummary.ShowDialog();
                        break;
                    case "pur_olapordersummary":
                        break;
                    case "settings_supplier":
                        RT2020.Supplier.SupplierList oSupplierList = new RT2020.Supplier.SupplierList();
                        oSupplierList.DockPadding.All = 6;
                        oSupplierList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oSupplierList);
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
                }
            }
        }
        #endregion
    }
}