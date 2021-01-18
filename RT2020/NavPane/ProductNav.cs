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
using RT2020.Helper;

#endregion

namespace RT2020.NavPane
{
    public partial class ProductNav : UserControl
    {
        public ProductNav()
        {
            InitializeComponent();

            NavPane.NavMenu.FillNavTree("product", this.navProduct.Nodes);
        }

        private void navSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Control[] controls = this.Form.Controls.Find("wspPane", true);
            if (controls.Length > 0)
            {
                Panel wspPane = (Panel)controls[0];
                wspPane.Text = navProduct.SelectedNode.Text;

                wspPane.Controls.Clear();

                ShowWorkspace(ref wspPane, (string)navProduct.SelectedNode.Tag);
                ShowAppToolStrip((string)navProduct.SelectedNode.Tag);

                // 2020.08.28 paulus: RT2020 如果 wspPane 有 ActionStripBar，降低 list pane
                if (wspPane.Controls.Count > 1)
                {
                    wspPane.Controls[1].Margin = new Padding(0, 22, 0, 0);
                }
            }
        }

        private void ShowAppToolStrip(string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                //Control[] controls = this.Form.Controls.Find("atsPane", true);
                Control[] controls = this.Form.Controls.Find("wspPane", true);
                if (controls.Length > 0)
                {
                    Panel atsPane = (Panel)controls[0];

                }
            }
        }

        private void ShowWorkspace(ref Panel wspPane, string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                Control[] controls = this.Form.Controls.Find("wspPane", true);

                switch (Tag.ToLower())
                {
                    case "product.product":
                        RT2020.Product.ProductList oProd = new RT2020.Product.ProductList(controls[0]);
                        oProd.DockPadding.All = 6;
                        oProd.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oProd);
                        break;
                    case "product.appendix1":
                        RT2020.Product.DefaultAppendixList oAppendix1List = new RT2020.Product.DefaultAppendixList(ProductHelper.Appendix.Appendix1, controls[0]);
                        oAppendix1List.DockPadding.All = 6;
                        oAppendix1List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAppendix1List);
                        break;
                    case "product.appendix2":
                        RT2020.Product.DefaultAppendixList oAppendix2List = new RT2020.Product.DefaultAppendixList(ProductHelper.Appendix.Appendix2, controls[0]);
                        oAppendix2List.DockPadding.All = 6;
                        oAppendix2List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAppendix2List);
                        break;
                    case "product.appendix3":
                        RT2020.Product.DefaultAppendixList oAppendix3List = new RT2020.Product.DefaultAppendixList(ProductHelper.Appendix.Appendix3, controls[0]);
                        oAppendix3List.DockPadding.All = 6;
                        oAppendix3List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAppendix3List);
                        break;
                    case "product.class1":
                        RT2020.Product.DefaultClassList oClass1List = new RT2020.Product.DefaultClassList("Class1", controls[0]);
                        oClass1List.DockPadding.All = 6;
                        oClass1List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass1List);
                        break;
                    case "product.class2":
                        RT2020.Product.DefaultClassList oClass2List = new RT2020.Product.DefaultClassList("Class2", controls[0]);
                        oClass2List.DockPadding.All = 6;
                        oClass2List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass2List);
                        break;
                    case "product.class3":
                        RT2020.Product.DefaultClassList oClass3List = new RT2020.Product.DefaultClassList("Class3", controls[0]);
                        oClass3List.DockPadding.All = 6;
                        oClass3List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass3List);
                        break;
                    case "product.class4":
                        RT2020.Product.DefaultClassList oClass4List = new RT2020.Product.DefaultClassList("Class4", controls[0]);
                        oClass4List.DockPadding.All = 6;
                        oClass4List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass4List);
                        break;
                    case "product.class5":
                        RT2020.Product.DefaultClassList oClass5List = new RT2020.Product.DefaultClassList("Class5", controls[0]);
                        oClass5List.DockPadding.All = 6;
                        oClass5List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass5List);
                        break;
                    case "product.class6":
                        RT2020.Product.DefaultClassList oClass6List = new RT2020.Product.DefaultClassList("Class6", controls[0]);
                        oClass6List.DockPadding.All = 6;
                        oClass6List.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oClass6List);
                        break;
                    case "product.combination":
                        RT2020.Product.DefaultCombinList oCombinList = new RT2020.Product.DefaultCombinList(controls[0]);
                        oCombinList.DockPadding.All = 6;
                        oCombinList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oCombinList);
                        break;
                    case "product.analysiscode":
                        RT2020.Product.AnalysisCodeList oAnalysisList = new RT2020.Product.AnalysisCodeList(controls[0]);
                        oAnalysisList.DockPadding.All = 6;
                        oAnalysisList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oAnalysisList);
                        break;
                    case "product.pricemanagement.pricechange":
                        RT2020.PriceMgmt.DefaultList wizPriceChangeList = new RT2020.PriceMgmt.DefaultList(controls[0], RT2020.PriceMgmt.PriceUtility.PriceMgmtType.Price);
                        wizPriceChangeList.DockPadding.All = 6;
                        wizPriceChangeList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(wizPriceChangeList);
                        break;
                    case "product.pricemanagement.discountchange":
                        RT2020.PriceMgmt.DefaultList wizDiscChangeList = new RT2020.PriceMgmt.DefaultList(controls[0], RT2020.PriceMgmt.PriceUtility.PriceMgmtType.Discount);
                        wizDiscChangeList.DockPadding.All = 6;
                        wizDiscChangeList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(wizDiscChangeList);
                        break;
                    case "product.pricemanagement.reason":
                        RT2020.PriceMgmt.DefaultReasonList oReasonList = new RT2020.PriceMgmt.DefaultReasonList(controls[0]);
                        oReasonList.DockPadding.All = 6;
                        oReasonList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oReasonList);
                        break;
                }
            }
        }
    }
}