using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using RT2020.Common.Helper;

namespace RT2020.PriceMgmt
{
    public class PriceToolbar
    {
        private Control atsPaneCtrl;

        public PriceToolbar(Control toolBar, ref ToolBar tbPriceControl)
        {
            atsPaneCtrl = toolBar;
            ClearToolBar();
            AddItemToToolBar(tbPriceControl);
        }

        private void ClearToolBar()
        {
            atsPaneCtrl.Controls.Clear();
        }

        private void AddItemToToolBar(ToolBar atsPriceMgmt)
        {
            atsPriceMgmt.MenuHandle = false;
            atsPriceMgmt.DragHandle = false;
            atsPriceMgmt.TextAlign = ToolBarTextAlign.Right;

            // Price Change
            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem("Price Change - Worksheet", string.Empty, "PriceChange_Worksheet"));

            MenuItem priceAuth = new MenuItem("Price Change - Authorization", string.Empty, "PriceChange_Authorization");
            priceAuth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(priceAuth);

            ddlNew.MenuItems.Add(new MenuItem("-"));

            ddlNew.MenuItems.Add(new MenuItem("Discount Change - Worksheet", string.Empty, "DiscChange_Worksheet"));

            MenuItem discAuth = new MenuItem("Discount Change - Authorization", string.Empty, "DiscChange_Authorization");
            discAuth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(discAuth);

            ddlNew.MenuItems.Add(new MenuItem("-"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("product.priceManagement.reason", "Menu"), string.Empty, "Reason_Code"));

            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            cmdNew.MenuClick += new MenuEventHandler(cmdMenuClick);
            atsPriceMgmt.Buttons.Add(cmdNew);

            // Separator
            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            atsPriceMgmt.Buttons.Add(sep);

            //  cmdReport
            ContextMenu ddlReport = new ContextMenu();
            ddlReport.MenuItems.Add(new MenuItem("Price Change - Worksheet", string.Empty, "Rpt_PriceChangeWorksheet"));
            ddlReport.MenuItems.Add(new MenuItem("Price Change - History", string.Empty, "Rpt_PriceChangeHistory"));
            ddlReport.MenuItems.Add(new MenuItem("-"));
            ddlReport.MenuItems.Add(new MenuItem("Discount Change - Worksheet", string.Empty, "Rpt_DiscountChangeWorksheet"));
            ddlReport.MenuItems.Add(new MenuItem("Discount Change - History", string.Empty, "Rpt_DiscountChangeHistory"));

            ToolBarButton cmdReport = new ToolBarButton("Report", WestwindHelper.GetWord("edit.print", "General"));
            cmdReport.Style = ToolBarButtonStyle.DropDownButton;
            cmdReport.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReport.DropDownMenu = ddlReport;
            cmdReport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            cmdReport.MenuClick += new MenuEventHandler(cmdMenuClick);
            atsPriceMgmt.Buttons.Add(cmdReport);

            if (atsPaneCtrl != null)
            {
                atsPaneCtrl.Controls.Add(atsPriceMgmt);
            }
        }

        void cmdMenuClick(object sender, MenuItemEventArgs e)
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
                    case "pricechange_worksheet":
                        PriceMgmtWizard wizPriceChange = new PriceMgmtWizard();
                        wizPriceChange.EditMode = EnumHelper.EditMode.Add;
                        wizPriceChange.TxType = EnumHelper.PriceMgmtTxType.PMC;
                        wizPriceChange.PMType = EnumHelper.PriceMgmtPMType.Price;
                        wizPriceChange.ShowDialog();
                        break;
                    case "pricechange_authorization":
                        Authorization wizAuthPrice = new Authorization();
                        wizAuthPrice.ListType = EnumHelper.PriceMgmtPMType.Price;
                        wizAuthPrice.ShowDialog();
                        break;
                    case "discchange_worksheet":
                        PriceMgmtWizard wizDiscChange = new PriceMgmtWizard();
                        wizDiscChange.EditMode = EnumHelper.EditMode.Add;
                        wizDiscChange.TxType = EnumHelper.PriceMgmtTxType.PMC;
                        wizDiscChange.PMType = EnumHelper.PriceMgmtPMType.Discount;
                        wizDiscChange.ShowDialog();
                        break;
                    case "discchange_authorization":
                        Authorization wizAuthDisc = new Authorization();
                        wizAuthDisc.ListType = EnumHelper.PriceMgmtPMType.Discount;
                        wizAuthDisc.ShowDialog();
                        break;
                    case "reason_code":
                        ReasonCodeWizard wizReasonCode = new ReasonCodeWizard();
                        wizReasonCode.EditMode = EnumHelper.EditMode.Add;
                        wizReasonCode.ShowDialog();
                        break;
                    case "rpt_pricechangeworksheet":
                        Reports.Worksheet wizPriceWorksheet = new RT2020.PriceMgmt.Reports.Worksheet();
                        wizPriceWorksheet.ReportType = EnumHelper.PriceMgmtPMType.Price;
                        wizPriceWorksheet.ShowDialog();
                        break;
                    case "rpt_pricechangehistory":
                        Reports.History wizPriceHistory = new RT2020.PriceMgmt.Reports.History();
                        wizPriceHistory.ReportType = EnumHelper.PriceMgmtPMType.Price;
                        wizPriceHistory.ShowDialog();
                        break;
                    case "rpt_discountchangeworksheet":
                        Reports.Worksheet wizDiscWorksheet = new RT2020.PriceMgmt.Reports.Worksheet();
                        wizDiscWorksheet.ReportType = EnumHelper.PriceMgmtPMType.Discount;
                        wizDiscWorksheet.ShowDialog();
                        break;
                    case "rpt_discountchangehistory":
                        Reports.History wizDiscHistory = new RT2020.PriceMgmt.Reports.History();
                        wizDiscHistory.ReportType = EnumHelper.PriceMgmtPMType.Discount;
                        wizDiscHistory.ShowDialog();
                        break;
                }
            }
        }
    }
}
