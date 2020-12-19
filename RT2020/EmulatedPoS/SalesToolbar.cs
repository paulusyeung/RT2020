using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using RT2020.Helper;

namespace RT2020.EmulatedPoS
{
    public class SalesToolbar
    {
        private Control atsPaneCtrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesToolbar"/> class.
        /// </summary>
        /// <param name="toolBar">The tool bar.</param>
        /// <param name="tbPriceControl">The tb price control.</param>
        public SalesToolbar(Control toolBar, ref ToolBar tbPriceControl)
        {
            atsPaneCtrl = toolBar;
            ClearToolBar();
            AddItemToToolBar(tbPriceControl);
        }

        /// <summary>
        /// Clears the tool bar.
        /// </summary>
        private void ClearToolBar()
        {
            atsPaneCtrl.Controls.Clear();
        }

        /// <summary>
        /// Adds the item to tool bar.
        /// </summary>
        /// <param name="atsSales">The ats sales.</param>
        private void AddItemToToolBar(ToolBar atsSales)
        {
            atsSales.MenuHandle = false;
            atsSales.DragHandle = false;
            atsSales.TextAlign = ToolBarTextAlign.Right;

            // Price Change
            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales - Worksheet"), string.Empty, "Sales_Worksheet"));
            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales - Worksheet (Fast)"), string.Empty, "Sales_Worksheet_Fast"));

            MenuItem priceAuth = new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales - Authorization"), string.Empty, "Sales_Authorization");
            priceAuth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(priceAuth);

            ddlNew.MenuItems.Add(new MenuItem("-"));

            ddlNew.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales Return - Worksheet"), string.Empty, "SalesReturn_Worksheet"));

            MenuItem discAuth = new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales Return - Authorization"), string.Empty, "SalesReturn_Authorization");
            discAuth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            ddlNew.MenuItems.Add(discAuth);

            ToolBarButton cmdNew = new ToolBarButton("New", RT2020.Controls.Utility.Dictionary.GetWord("New"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            cmdNew.MenuClick += new MenuEventHandler(cmdMenuClick);
            atsSales.Buttons.Add(cmdNew);

            // Separator
            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            atsSales.Buttons.Add(sep);

            //  cmdReport
            ContextMenu ddlReport = new ContextMenu();
            ddlReport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales - Worksheet"), string.Empty, "Rpt_SalesWorksheet"));
            ddlReport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales - History"), string.Empty, "Rpt_SalesHistory"));
            ddlReport.MenuItems.Add(new MenuItem("-"));
            ddlReport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales Return - Worksheet"), string.Empty, "Rpt_SalesReturnWorksheet"));
            ddlReport.MenuItems.Add(new MenuItem(RT2020.Controls.Utility.Dictionary.GetWord("Sales Return - History"), string.Empty, "Rpt_SalesReturnHistory"));

            ToolBarButton cmdReport = new ToolBarButton("Report", RT2020.Controls.Utility.Dictionary.GetWord("Reports"));
            cmdReport.Style = ToolBarButtonStyle.DropDownButton;
            cmdReport.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReport.DropDownMenu = ddlReport;
            cmdReport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            cmdReport.MenuClick += new MenuEventHandler(cmdMenuClick);
            atsSales.Buttons.Add(cmdReport);

            if (atsPaneCtrl != null)
            {
                atsPaneCtrl.Controls.Add(atsSales);
            }
        }

        /// <summary>
        /// CMDs the menu click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.MenuItemEventArgs"/> instance containing the event data.</param>
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
                    case "sales_worksheet":
                        SalesWizard wizSalesInput = new SalesWizard(EnumHelper.TxType.CAS);
                        wizSalesInput.ShowDialog();
                        break;
                    case "sales_worksheet_fast":
                        FastModeLogin fastLogin = new FastModeLogin();
                        fastLogin.Closed += new EventHandler(fastLogin_Closed);
                        fastLogin.ShowDialog();
                        break;
                    case "sales_authorization":
                        Authorization wizAuthPrice = new Authorization(EnumHelper.TxType.CAS);
                        wizAuthPrice.SalesType = EnumHelper.TxType.CAS;
                        wizAuthPrice.ShowDialog();
                        break;
                    case "salesreturn_worksheet":
                        SalesWizard wizDiscChange = new SalesWizard(EnumHelper.TxType.CRT);
                        wizDiscChange.ShowDialog();
                        break;
                    case "salesreturn_authorization":
                        Authorization wizAuthDisc = new Authorization(EnumHelper.TxType.CRT);
                        wizAuthDisc.SalesType = EnumHelper.TxType.CRT;
                        wizAuthDisc.ShowDialog();
                        break;
                    case "rpt_salesworksheet":
                        Reports.Worksheet wizPriceWorksheet = new RT2020.EmulatedPoS.Reports.Worksheet(EnumHelper.TxType.CAS);
                        wizPriceWorksheet.SalesType = EnumHelper.TxType.CAS;
                        wizPriceWorksheet.ShowDialog();
                        break;
                    case "rpt_saleshistory":
                        Reports.History wizPriceHistory = new RT2020.EmulatedPoS.Reports.History(EnumHelper.TxType.CAS);
                        wizPriceHistory.SalesType = EnumHelper.TxType.CAS;
                        wizPriceHistory.ShowDialog();
                        break;
                    case "rpt_salesreturnworksheet":
                        Reports.Worksheet wizDiscWorksheet = new RT2020.EmulatedPoS.Reports.Worksheet(EnumHelper.TxType.CRT);
                        wizDiscWorksheet.SalesType = EnumHelper.TxType.CRT;
                        wizDiscWorksheet.ShowDialog();
                        break;
                    case "rpt_salesreturnhistory":
                        Reports.History wizDiscHistory = new RT2020.EmulatedPoS.Reports.History(EnumHelper.TxType.CRT);
                        wizDiscHistory.SalesType = EnumHelper.TxType.CRT;
                        wizDiscHistory.ShowDialog();
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the Closed event of the fastLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void fastLogin_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                FastModeLogin fast = sender as FastModeLogin;

                FastSalesWizard wizFastSalesInput = new FastSalesWizard(fast.TxDate, fast.WorkplaceId, EnumHelper.TxType.CAS);
                wizFastSalesInput.ShowDialog();
            }
        }
    }

    /// <summary>
    /// Price Management Utility
    /// </summary>
    public class PriceUtility
    {
        /// <summary>
        /// Price Management Type
        /// </summary>
        public enum SalesType
        {
            /// <summary>
            /// Price report (Worksheet / History)
            /// </summary>
            Price,
            /// <summary>
            /// Discount report (Worksheet / History)
            /// </summary>
            Discount
        }
    }
}
