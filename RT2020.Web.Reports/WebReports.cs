#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using System.Xml;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using System.Configuration;
using System.Collections;
using RT2020.Web.Reports.Controls.CustomPanel;

#endregion

namespace RT2020.Web.Reports
{
    public partial class WebReports : Form
    {
        string xmlSource = System.Web.HttpContext.Current.Server.MapPath("~/Resources/List/ReportList.xml");

        /// <summary>
        /// Initializes a new instance of the <see cref="Default"/> class.
        /// </summary>
        public WebReports()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Default control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Default_Load(object sender, EventArgs e)
        {
            Binding();
        }

        /// <summary>
        /// Bindings this instance.
        /// </summary>
        private void Binding()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(xmlSource);

            customPanel.DataSource = ds.Tables["Report"];
        }

        /// <summary>
        /// Views the reports.
        /// </summary>
        /// <param name="tag">The tag.</param>
        private void ViewReports(string tag)
        {
            switch (tag.ToLower())
            {
                case "stock_list":
                    //Forms.StockList frmStockList = new RT2020.Web.Reports.Forms.StockList();
                    //frmStockList.Show();
                    RT2020.Web.Reports.Forms.StockList_Inline frmStockList = new RT2020.Web.Reports.Forms.StockList_Inline();
                    frmStockList.Dock = DockStyle.Fill;
                    frmStockList.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(frmStockList);
                    break;
                case "stock_qty_status":
                    // 2013.11.07 paulus: 由彈出新頁改為在同一頁顯示
                    //Forms.StockQtyStatus frmStockQtyStatus = new RT2020.Web.Reports.Forms.StockQtyStatus();
                    //frmStockQtyStatus.Show();
                    Forms.StockQtyStatus_Inline stockQtyStatus = new RT2020.Web.Reports.Forms.StockQtyStatus_Inline();
                    stockQtyStatus.Dock = DockStyle.Fill;
                    stockQtyStatus.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(stockQtyStatus);
                    break;
                case "stock_qty_status_photo":
                    //Forms.StockQtyStatusWithPhoto frmStockQtyStatusWithPhoto = new RT2020.Web.Reports.Forms.StockQtyStatusWithPhoto();
                    //frmStockQtyStatusWithPhoto.Show();
                    Forms.StockQtyStatusWithPhoto_Inline frmStockQtyStatusWithPhoto = new RT2020.Web.Reports.Forms.StockQtyStatusWithPhoto_Inline();
                    frmStockQtyStatusWithPhoto.Dock = DockStyle.Fill;
                    frmStockQtyStatusWithPhoto.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(frmStockQtyStatusWithPhoto);
                    break;
                case "stock_discount_status":
                    //Forms.StockDiscountStatus frmStockDiscountStatus = new RT2020.Web.Reports.Forms.StockDiscountStatus();
                    //frmStockDiscountStatus.Show();
                    Forms.StockDiscountStatus_Inline frmStockDiscountStatus = new RT2020.Web.Reports.Forms.StockDiscountStatus_Inline();
                    frmStockDiscountStatus.Dock = DockStyle.Fill;
                    frmStockDiscountStatus.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(frmStockDiscountStatus);
                    break;
                case "daily_shop_transaction":
                    //Forms.DailyShopTransaction frmDailyShopTransaction = new RT2020.Web.Reports.Forms.DailyShopTransaction();
                    //frmDailyShopTransaction.Show();
                    Forms.DailyShopTransaction_Inline frmDailyShopTransaction = new RT2020.Web.Reports.Forms.DailyShopTransaction_Inline();
                    frmDailyShopTransaction.Dock = DockStyle.Fill;
                    frmDailyShopTransaction.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(frmDailyShopTransaction);
                    break;
                case "stock_inout_history":
                    //Forms.StockInOutHistory frmStockInOutHistory = new RT2020.Web.Reports.Forms.StockInOutHistory();
                    //frmStockInOutHistory.Show();
                    Forms.StockInOutHistory_Inline frmStockInOutHistory = new RT2020.Web.Reports.Forms.StockInOutHistory_Inline();
                    frmStockInOutHistory.Dock = DockStyle.Fill;
                    frmStockInOutHistory.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(frmStockInOutHistory);
                    break;
                case "olap_monthly_sales_transaction":
                    //Forms.OlapMonthlySalesTransaction olapForm = new RT2020.Web.Reports.Forms.OlapMonthlySalesTransaction();
                    //olapForm.Show();
                    RT2020.Web.Reports.Controls.OlapViewer olapViewer = new RT2020.Web.Reports.Controls.OlapViewer();
                    olapViewer.DockPadding.All = 6;
                    olapViewer.Dock = DockStyle.Fill;
                    olapViewer.AutoSize = true;
                    olapViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    olapViewer.AspxPagePath = @"Olap\OlapMonthlySalesTransactionPage.aspx";
                    olapViewer.Dock = DockStyle.Fill;
                    olapViewer.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(olapViewer);
                    break;
                case "vip_profile":
                    //Forms.VIPProfile frmVIPProfile = new RT2020.Web.Reports.Forms.VIPProfile();
                    //frmVIPProfile.Show();
                    RT2020.Web.Reports.Forms.VIPProfile_Inline frmVIPProfile = new RT2020.Web.Reports.Forms.VIPProfile_Inline();
                    frmVIPProfile.Dock = DockStyle.Fill;
                    frmVIPProfile.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(frmVIPProfile);
                    break;
                case "vip_sales_analysis":
                    //Forms.VIPSalesAnalysis frmVIPSalesAnalysis = new RT2020.Web.Reports.Forms.VIPSalesAnalysis();
                    //frmVIPSalesAnalysis.Show();
                    RT2020.Web.Reports.Forms.VIPSalesAnalysis_Inline frmVIPSalesAnalysis = new RT2020.Web.Reports.Forms.VIPSalesAnalysis_Inline();
                    frmVIPSalesAnalysis.Dock = DockStyle.Fill;
                    frmVIPSalesAnalysis.Padding = new Padding(4, 0, 4, 4);
                    this.customPanel.Controls.Clear();
                    this.customPanel.Controls.Add(frmVIPSalesAnalysis);
                    break;
                case "apply_vip":
                    Forms.VipApplyForm frmApplyVip = new RT2020.Web.Reports.Forms.VipApplyForm();
                    frmApplyVip.Show();
                    break;
            }

            UpdateLastAccessedOn(tag);
        }

        /// <summary>
        /// Handles the DoubleClick event of the customPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void customPanel_Click(object sender, EventArgs e)
        {
            if (sender is CustomPanel)
            {
                string tag = ((CustomPanel)sender).Tag.ToString();
                this.ViewReports(tag);
            }
        }

        /// <summary>
        /// Updates the last printed on.
        /// </summary>
        private void UpdateLastAccessedOn(string tagCode)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlSource);  // suppose that str string contains "<Reports>...</Reports>"

            XmlNodeList xnList = xml.SelectNodes("/root/Reports/Report[@Tag='" + tagCode + "']");
            foreach (XmlNode xn in xnList)
            {
                xn.Attributes["LastAccessedOn"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }

            xml.Save(xmlSource);
        }
    }
}
