using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gizmox.WebGUI.Forms;

using FastReport;
using FastReport.Utils;
using FastReport.Export.Image;
using FastReport.Export.Html;
using FastReport.Export.PdfSimple;
using RT2020.Reports.ModelEx;
using RT2020.Reports.Helper;

namespace RT2020.Reports.Inventory.Journal
{
    public class Monthly
    {
        #region private properties: _Sql, _ReportName
        private const string _Sql = @"
select * from
(
SELECT TOP 100 PERCENT
    V.STKCODE, V.APPENDIX1, V.APPENDIX2, V.APPENDIX3, V.CLASS1, V.CLASS2, V.CLASS3, V.CLASS4, V.CLASS5, V.CLASS6, V.TxDate, V.TxType, V.TxNumber, V.SupplierCode, V.Price, V.FromLocation, V.ToLocation, V.QTYIN, V.QTYOUT, V.Qty, V.AverageCost, V.BFQTY, V.BFAMT, V.CDQTY, V.CDAMT, V.Reference, V.Remarks
FROM vwInOutHistory AS V
WHERE V.TxDate >= '{0}' AND V.TxDate <= '{1}' AND V.STKCODE >= '{2}' AND V.STKCODE <= '{3}'
) as vw
order by STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, TxDate, TxType, TxNumber
";
        private static string _ReportName = "Inventory\\Journal\\Monthly.frx";

        private static string ReportFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _ReportName); ; }
        }

        private static string ReportFileName
        {
            get { return Path.GetFileNameWithoutExtension(ReportFilePath); }
        }
        #endregion

        /// <summary>
        /// Return the report in HTML string
        /// Usage Example:
        ///   htmlbox.html = HTML("2012-01-01", "2012-01-15", "03", "03Z");
        /// </summary>
        /// <param name="fromCode"></param>
        /// <param name="toCode"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static string HTML(string fromCode, string toCode, string fromDate, string toDate)
        {
            var result = "";

            var sql = string.Format(_Sql, fromDate, toDate, fromCode, toCode);

            //! 提供一個 data connection object (依家用 MsSql)
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(FastReport.Data.MsSqlDataConnection));

            using (MemoryStream stream = new MemoryStream()) //Create the stream for the report
            {
                try
                {
                    Config.WebMode = true;

                    using (Report report = new Report())
                    {
                        report.Load(ReportFilePath);

                        #region populate dataset
                        //! 首先，取消 designer 用緊嘅 Connection
                        report.Dictionary.Connections.Clear();

                        //! 再準備 custom 嘅 data source
                        DataSet ds = new DataSet();
                        ds = Helper.SqlHelper.Default.ExecuteDataSet(CommandType.Text, sql);

                        report.Dictionary.Report.RegisterData(ds, "Table", true);
                        ((DataBand)report.Report.FindObject("Data1")).DataSource = report.GetDataSource("Table");
                        report.GetDataSource("Table").Enabled = true;
                        #endregion

                        #region render 個 report 前作最後處理
                        //report.SetParameterValue("pReportTitle", WestwindHelper.GetWord("report.SA1330", "Setting"));                                        // 塞個 report title 入去
                        // Do not use parameter, instead keep the report title for easy reconize
                        ((TextObject)report.Report.FindObject("lblReportTitle")).Text = WestwindHelper.GetWord("report.SA1330", "Setting");

                        // 如果用 PrintOn.FirstPage，咁就祇能用 [Page]
                        //((PageHeaderBand)report.Report.FindObject("PageHeader1")).PrintOn = PrintOn.FirstPage;              // PageHeader1 淨係喺第一頁出現，出 HTML 有用
                        ((TextObject)report.Report.FindObject("txtPageNofM")).Text = "[Page] of [TotalPages]";

                        report.SetParameterValue("pCompanyName", WestwindHelper.GetWord("companyInfo.name", "Setting"));    // SystemInfoEx.CurrentInfo.Default.CompanyName);
                        report.SetParameterValue("pSelectedStockCode", string.Format("{0} ~ {1}", fromCode, toCode));
                        report.SetParameterValue("pSelectedDate", string.Format("{0} ~ {1}", fromDate, toDate));

                        ((TextObject)report.Report.FindObject("lblStockCode")).Text = "貨品編號：";                  // 示範英轉中
                        #endregion

                        report.Prepare();   //Prepare the report

                        #region report export to HTML
                        HTMLExport html = new HTMLExport();
                        html.SinglePage = true;         //report on the one page
                        html.Navigator = false;         //navigation panel on top
                        html.EmbedPictures = true;      //build in images to the document
                        html.Zoom = 1.20F;              //design 嘅 font size 係以 A4 為主，喺 HTML 會太細，所以要放大 1.25 倍
                        report.Export(html, stream);    //export as HTML to stream

                        // debug: write to a file
                        //report.Export(html, string.Format("C:\\Temp\\{0}.html", ReportFileName));

                        stream.Position = 0;
                        var reader = new StreamReader(stream);
                        result = reader.ReadToEnd();
                        #endregion

                        stream.Flush();
                    }
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    stream.Dispose();
                }
            }

            return result;
        }

        public static byte[] PDF(string fromCode, string toCode, string fromDate, string toDate)
        {
            byte[] result = null;

            var sql = string.Format(_Sql, fromDate, toDate, fromCode, toCode);

            //! 提供一個 data connection object (依家用 MsSql)
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(FastReport.Data.MsSqlDataConnection));

            using (MemoryStream stream = new MemoryStream()) //Create the stream for the report
            {
                try
                {
                    Config.WebMode = true;

                    using (Report report = new Report())
                    {
                        report.Load(ReportFilePath);

                        #region populate dataset
                        //! 首先，取消 designer 用緊嘅 Connection
                        report.Dictionary.Connections.Clear();

                        //! 再準備 custom 嘅 data source
                        DataSet ds = new DataSet();
                        ds = Helper.SqlHelper.Default.ExecuteDataSet(CommandType.Text, sql);

                        report.Dictionary.Report.RegisterData(ds, "Table", true);
                        ((DataBand)report.Report.FindObject("Data1")).DataSource = report.GetDataSource("Table");
                        report.GetDataSource("Table").Enabled = true;
                        #endregion

                        #region render 個 report 前作最後處理
                        ((TextObject)report.Report.FindObject("lblReportTitle")).Text = WestwindHelper.GetWord("report.SA1330", "Setting");

                        report.SetParameterValue("pCompanyName", WestwindHelper.GetWord("companyInfo.name", "Setting"));    // SystemInfoEx.CurrentInfo.Default.CompanyName);
                        report.SetParameterValue("pSelectedStockCode", string.Format("{0} ~ {1}", fromCode, toCode));
                        report.SetParameterValue("pSelectedDate", string.Format("{0} ~ {1}", fromDate, toDate));
                        ((TextObject)report.Report.FindObject("txtPageNofM")).Text = "[Page] of [TotalPages]";
                        ((TextObject)report.Report.FindObject("lblStockCode")).Text = "貨品編號：";                  // 示範英轉中
                        #endregion

                        report.Prepare();   //Prepare the report

                        #region export as PDF
                        var pdf = new PDFSimpleExport();
                        pdf.Export(report, stream);

                        // debug: write to a file
                        //pdf.Export(report, string.Format("C:\\Temp\\{0}.pdf", ReportFileName));

                        stream.Position = 0;
                        result = stream.ToArray();

                        #endregion

                        stream.Flush();
                    }
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    stream.Dispose();
                }
            }
            return result;
        }

        public static void Excel()
        {

        }
    }
}
