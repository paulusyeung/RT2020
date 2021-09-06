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
using ClosedXML.Excel;
using ClosedXML.Report;
using RT2020.Inventory.Reports.TestModels;
using LinqToDB;
using System.Data.SqlClient;

namespace RT2020.Reports.Inventory.Journal
{
    public class Summary
    {
        #region private properties: _Sql, _ReportName
        private const string _SpNameForCurrentPeriod = "apStockInOutSummary_CurrentMonth";
        private const string _SpNameForOtherPeriods = "apStockInOutSummary_HistoryMonth";
        private const string _Sql = @"";

        private static string _ReportName = "Inventory\\Journal\\Summary.frx";
        private static string _ExcelTemplate = "Inventory\\Journal\\Summary.xlsx";
        private static string _PivotTemplate = "Inventory\\Journal\\SummaryPivot.xlsx";

        private static string ReportFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _ReportName); ; }
        }

        private static string ReportFileName
        {
            get { return Path.GetFileNameWithoutExtension(ReportFilePath); }
        }

        private static string ExcelFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _ExcelTemplate); ; }
        }

        private static string PivotFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _PivotTemplate); ; }
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

                        #region populate data source
                        //! 首先，取消 designer 用緊嘅 Connection
                        report.Dictionary.Connections.Clear();

                        //! 準備 custom 嘅 data source
                        DataSet ds = new DataSet();
                        ds = Helper.SqlHelper.Default.ExecuteDataSet(CommandType.Text, sql);

                        //! 替代 design time 嘅設定
                        string desingTimeDataSourceAlias = "Table", desingTimeDataBandName = "Data1";
                        report.Dictionary.Report.RegisterData(ds, desingTimeDataSourceAlias, true);
                        ((DataBand)report.Report.FindObject(desingTimeDataBandName)).DataSource = report.GetDataSource(desingTimeDataSourceAlias);
                        report.GetDataSource(desingTimeDataSourceAlias).Enabled = true;
                        //! DataSource 已經 sorted，不過 DataBand 會亂來，除非你喺 designer 設定咗 DataBand 個 Sort
                        //! 我選擇喺 code 度搞
                        ((DataBand)report.Report.FindObject(desingTimeDataBandName)).Sort.AddRange(new Sort[] {
                            new Sort(string.Format("[{0}.TxDate]", desingTimeDataSourceAlias), false),
                            new Sort(string.Format("[{0}.TxType]", desingTimeDataSourceAlias), false),
                            new Sort(string.Format("[{0}.TxNumber]", desingTimeDataSourceAlias), false)
                            });
                        #endregion

                        #region render 個 report 前作最後處理
                        //report.SetParameterValue("pReportTitle", WestwindHelper.GetWord("report.SA1330", "Setting"));                                        // 塞個 report title 入去
                        //! 唔用 parameter, design time 嘅時候容易知道係邊隻 report
                        ((TextObject)report.Report.FindObject("lblReportTitle")).Text = WestwindHelper.GetWord("report.SA1330", "Setting");

                        //! 如果用 PrintOn.FirstPage，咁就祇能用 [Page]
                        //((PageHeaderBand)report.Report.FindObject("PageHeader1")).PrintOn = PrintOn.FirstPage;              // PageHeader1 淨係喺第一頁出現，出 HTML 有用
                        ((TextObject)report.Report.FindObject("txtPageNofM")).Text = string.Format(WestwindHelper.GetWord("reports.pageNofM", "General"), "[Page]","[TotalPages]");

                        report.SetParameterValue("pCompanyName", WestwindHelper.GetWord("companyInfo.name", "Setting"));    // SystemInfoEx.CurrentInfo.Default.CompanyName);
                        ((TextObject)report.Report.FindObject("lblSelectedRange")).Text = WestwindHelper.GetWordWithColon("reports.selectedRange", "General");
                        ((TextObject)report.Report.FindObject("lblSelectedStockCode")).Text = WestwindHelper.GetWordWithColon("article.code", "Product");
                        ((TextObject)report.Report.FindObject("lblSelectedDate")).Text = WestwindHelper.GetWordWithColon("transaction.date", "Transaction");
                        report.SetParameterValue("pSelectedStockCode", string.Format("{0} ⇔ {1}", fromCode, toCode));
                        report.SetParameterValue("pSelectedDate", string.Format("{0} ⇔ {1}", fromDate, toDate));
                        ((TextObject)report.Report.FindObject("lblPrintedOn")).Text = WestwindHelper.GetWordWithColon("reports.printedOn", "General");
                        ((TextObject)report.Report.FindObject("lblPage")).Text = WestwindHelper.GetWordWithColon("reports.page", "General");

                        ((TextObject)report.Report.FindObject("lblStockCode")).Text = WestwindHelper.GetWordWithColon("article.code", "Product");
                        ((TextObject)report.Report.FindObject("lblAppendix1")).Text = WestwindHelper.GetWordWithColon("appendix.appendix1", "Product");
                        ((TextObject)report.Report.FindObject("lblAppendix2")).Text = WestwindHelper.GetWordWithColon("appendix.appendix2", "Product");
                        ((TextObject)report.Report.FindObject("lblAppendix3")).Text = WestwindHelper.GetWordWithColon("appendix.appendix3", "Product");
                        ((TextObject)report.Report.FindObject("lblClass1")).Text = WestwindHelper.GetWordWithColon("class.class1", "Product");
                        ((TextObject)report.Report.FindObject("lblClass2")).Text = WestwindHelper.GetWordWithColon("class.class2", "Product");
                        ((TextObject)report.Report.FindObject("lblClass3")).Text = WestwindHelper.GetWordWithColon("class.class3", "Product");
                        ((TextObject)report.Report.FindObject("lblClass4")).Text = WestwindHelper.GetWordWithColon("class.class4", "Product");
                        ((TextObject)report.Report.FindObject("lblClass5")).Text = WestwindHelper.GetWordWithColon("class.class5", "Product");
                        ((TextObject)report.Report.FindObject("lblClass6")).Text = WestwindHelper.GetWordWithColon("class.class6", "Product");
                        ((TextObject)report.Report.FindObject("lblBFQty")).Text = WestwindHelper.GetWordWithColon("inventory.bfQty", "Product");
                        ((TextObject)report.Report.FindObject("lblBFAmount")).Text = WestwindHelper.GetWordWithColon("inventory.bfAmount", "Product");
                        ((TextObject)report.Report.FindObject("lblCDQty")).Text = WestwindHelper.GetWordWithColon("inventory.cdQty", "Product");
                        ((TextObject)report.Report.FindObject("lblCDAmount")).Text = WestwindHelper.GetWordWithColon("inventory.cdAmount", "Product");

                        ((TextObject)report.Report.FindObject("lblTxDate")).Text = WestwindHelper.GetWord("transaction.date", "Transaction");
                        ((TextObject)report.Report.FindObject("lblTxType")).Text = WestwindHelper.GetWord("transaction.type", "Transaction");
                        ((TextObject)report.Report.FindObject("lblQtyIn")).Text = WestwindHelper.GetWord("transaction.qtyIn", "Transaction");
                        ((TextObject)report.Report.FindObject("lblQtyOut")).Text = WestwindHelper.GetWord("transaction.qtyOut", "Transaction");
                        ((TextObject)report.Report.FindObject("lblPrice")).Text = WestwindHelper.GetWord("transaction.price", "Transaction");
                        ((TextObject)report.Report.FindObject("lblCost")).Text = WestwindHelper.GetWord("transaction.cost", "Transaction");
                        ((TextObject)report.Report.FindObject("lblTxNumber")).Text = WestwindHelper.GetWord("transaction.number", "Transaction");
                        ((TextObject)report.Report.FindObject("lblReference")).Text = WestwindHelper.GetWord("transaction.reference", "Transaction");
                        ((TextObject)report.Report.FindObject("lblLocation")).Text = WestwindHelper.GetWord("workplace", "Model");
                        ((TextObject)report.Report.FindObject("lblSupplierCode")).Text = WestwindHelper.GetWord("supplier", "Model");
                        ((TextObject)report.Report.FindObject("lblRemarks")).Text = WestwindHelper.GetWord("transaction.remarks", "Transaction");
                        ((TextObject)report.Report.FindObject("lblSubTotal")).Text = WestwindHelper.GetWordWithColon("transaction.subtotal", "Transaction");
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

                        #region populate data source
                        //! 首先，取消 designer 用緊嘅 Connection
                        report.Dictionary.Connections.Clear();

                        //! 再準備 custom 嘅 data source
                        DataSet ds = new DataSet();
                        ds = Helper.SqlHelper.Default.ExecuteDataSet(CommandType.Text, sql);

                        //! 替代 design time 嘅設定
                        string desingTimeDataSourceAlias = "Table", desingTimeDataBandName = "Data1";
                        report.Dictionary.Report.RegisterData(ds, desingTimeDataSourceAlias, true);
                        ((DataBand)report.Report.FindObject(desingTimeDataBandName)).DataSource = report.GetDataSource(desingTimeDataSourceAlias);
                        report.GetDataSource(desingTimeDataSourceAlias).Enabled = true;
                        //! DataSource 已經 sorted，不過 DataBand 會亂來，除非你喺 designer 設定咗 DataBand 個 Sort
                        //! 我選擇喺 code 度搞
                        ((DataBand)report.Report.FindObject(desingTimeDataBandName)).Sort.AddRange(new Sort[] {
                            new Sort(string.Format("[{0}.TxDate]", desingTimeDataSourceAlias), false),
                            new Sort(string.Format("[{0}.TxType]", desingTimeDataSourceAlias), false),
                            new Sort(string.Format("[{0}.TxNumber]", desingTimeDataSourceAlias), false)
                            });
                        #endregion

                        #region render 個 report 前作最後處理
                        ((TextObject)report.Report.FindObject("lblReportTitle")).Text = WestwindHelper.GetWord("report.SA1330", "Setting");

                        ((TextObject)report.Report.FindObject("txtPageNofM")).Text = string.Format(WestwindHelper.GetWord("reports.pageNofM", "General"), "[Page]", "[TotalPages]");

                        report.SetParameterValue("pCompanyName", WestwindHelper.GetWord("companyInfo.name", "Setting"));    // SystemInfoEx.CurrentInfo.Default.CompanyName);
                        ((TextObject)report.Report.FindObject("lblSelectedRange")).Text = WestwindHelper.GetWordWithColon("reports.selectedRange", "General");
                        ((TextObject)report.Report.FindObject("lblSelectedStockCode")).Text = WestwindHelper.GetWordWithColon("article.code", "Product");
                        ((TextObject)report.Report.FindObject("lblSelectedDate")).Text = WestwindHelper.GetWordWithColon("transaction.date", "Transaction");
                        report.SetParameterValue("pSelectedStockCode", string.Format("{0} ⇔ {1}", fromCode, toCode));
                        report.SetParameterValue("pSelectedDate", string.Format("{0} ⇔ {1}", fromDate, toDate));
                        ((TextObject)report.Report.FindObject("lblPrintedOn")).Text = WestwindHelper.GetWordWithColon("reports.printedOn", "General");
                        ((TextObject)report.Report.FindObject("lblPage")).Text = WestwindHelper.GetWordWithColon("reports.page", "General");

                        ((TextObject)report.Report.FindObject("lblStockCode")).Text = WestwindHelper.GetWordWithColon("article.code", "Product");
                        ((TextObject)report.Report.FindObject("lblAppendix1")).Text = WestwindHelper.GetWordWithColon("appendix.appendix1", "Product");
                        ((TextObject)report.Report.FindObject("lblAppendix2")).Text = WestwindHelper.GetWordWithColon("appendix.appendix2", "Product");
                        ((TextObject)report.Report.FindObject("lblAppendix3")).Text = WestwindHelper.GetWordWithColon("appendix.appendix3", "Product");
                        ((TextObject)report.Report.FindObject("lblClass1")).Text = WestwindHelper.GetWordWithColon("class.class1", "Product");
                        ((TextObject)report.Report.FindObject("lblClass2")).Text = WestwindHelper.GetWordWithColon("class.class2", "Product");
                        ((TextObject)report.Report.FindObject("lblClass3")).Text = WestwindHelper.GetWordWithColon("class.class3", "Product");
                        ((TextObject)report.Report.FindObject("lblClass4")).Text = WestwindHelper.GetWordWithColon("class.class4", "Product");
                        ((TextObject)report.Report.FindObject("lblClass5")).Text = WestwindHelper.GetWordWithColon("class.class5", "Product");
                        ((TextObject)report.Report.FindObject("lblClass6")).Text = WestwindHelper.GetWordWithColon("class.class6", "Product");
                        ((TextObject)report.Report.FindObject("lblBFQty")).Text = WestwindHelper.GetWordWithColon("inventory.bfQty", "Product");
                        ((TextObject)report.Report.FindObject("lblBFAmount")).Text = WestwindHelper.GetWordWithColon("inventory.bfAmount", "Product");
                        ((TextObject)report.Report.FindObject("lblCDQty")).Text = WestwindHelper.GetWordWithColon("inventory.cdQty", "Product");
                        ((TextObject)report.Report.FindObject("lblCDAmount")).Text = WestwindHelper.GetWordWithColon("inventory.cdAmount", "Product");

                        ((TextObject)report.Report.FindObject("lblTxDate")).Text = WestwindHelper.GetWord("transaction.date", "Transaction");
                        ((TextObject)report.Report.FindObject("lblTxType")).Text = WestwindHelper.GetWord("transaction.type", "Transaction");
                        ((TextObject)report.Report.FindObject("lblQtyIn")).Text = WestwindHelper.GetWord("transaction.qtyIn", "Transaction");
                        ((TextObject)report.Report.FindObject("lblQtyOut")).Text = WestwindHelper.GetWord("transaction.qtyOut", "Transaction");
                        ((TextObject)report.Report.FindObject("lblPrice")).Text = WestwindHelper.GetWord("transaction.price", "Transaction");
                        ((TextObject)report.Report.FindObject("lblCost")).Text = WestwindHelper.GetWord("transaction.cost", "Transaction");
                        ((TextObject)report.Report.FindObject("lblTxNumber")).Text = WestwindHelper.GetWord("transaction.number", "Transaction");
                        ((TextObject)report.Report.FindObject("lblReference")).Text = WestwindHelper.GetWord("transaction.reference", "Transaction");
                        ((TextObject)report.Report.FindObject("lblLocation")).Text = WestwindHelper.GetWord("workplace", "Model");
                        ((TextObject)report.Report.FindObject("lblSupplierCode")).Text = WestwindHelper.GetWord("supplier", "Model");
                        ((TextObject)report.Report.FindObject("lblRemarks")).Text = WestwindHelper.GetWord("transaction.remarks", "Transaction");
                        ((TextObject)report.Report.FindObject("lblSubTotal")).Text = WestwindHelper.GetWordWithColon("transaction.subtotal", "Transaction");
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

        public static byte[] Excel(string fromCode, string toCode, string fromDate, string toDate)
        {
            byte[] result = null;

            var sql = string.Format(_Sql, fromDate, toDate, fromCode, toCode);

            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    var tpl = new XLTemplate(ExcelFilePath);

                    var ds = Helper.SqlHelper.Default.ExecuteDataSet(CommandType.Text, sql);
                    var dt = ds.Tables[0];
                    var dr = from row in dt.AsEnumerable() select row;
                    //var dr = dt.Rows.Cast<DataRow>();      // 可以咁玩

                    /** for fun & learning
                    var dic = dt.AsEnumerable()
                        .Select(x => dt.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => x[c].ToString()))
                        .ToList();

                    #region obj = List<object>, gp = grouping obj
                    var obj = dt.AsEnumerable()
                        .Select(x => new ModelEx.InOutHistoryEx.Product()
                        {
                            STKCODE = x.Field<string>("STKCODE"),
                            APPENDIX1 = x.Field<string>("APPENDIX1"),
                            APPENDIX2 = x.Field<string>("APPENDIX2"),
                            APPENDIX3 = x.Field<string>("APPENDIX3"),
                            CLASS1 = x.Field<string>("CLASS1"),
                            CLASS2 = x.Field<string>("CLASS2"),
                            CLASS3 = x.Field<string>("CLASS3"),
                            CLASS4 = x.Field<string>("CLASS4"),
                            CLASS5 = x.Field<string>("CLASS5"),
                            CLASS6 = x.Field<string>("CLASS6")
                        })
                        .ToList();

                    var gp = obj.GroupBy(g => new { g.STKCODE, g.APPENDIX1, g.APPENDIX2, g.APPENDIX3 })
                        .Select(x => x.ToList())
                        .ToList();
                    #endregion
                    */

                    #region 用 linq 做 grouping: gh = linq grouping from dr
                    var gh = dr.AsEnumerable()
                        .GroupBy(x => new
                        {
                            STKCODE = x.Field<string>("STKCODE"),
                            APPENDIX1 = x.Field<string>("APPENDIX1"),
                            APPENDIX2 = x.Field<string>("APPENDIX2"),
                            APPENDIX3 = x.Field<string>("APPENDIX3"),
                        })
                        .Select(g => g.CopyToDataTable())
                        .ToList();
                    #endregion

                    #region 由 gh 建成 products = parent child object
                    var products = new List<ModelEx.InOutHistoryEx.Product>();

                    if (gh.Count > 0)
                    {
                        for (int i = 0; i < gh.Count; i++ )
                        {
                            #region create 一隻 product
                            var hdr = gh[i];
                            var x = hdr.Rows[0];
                            var product = new ModelEx.InOutHistoryEx.Product()
                            {
                                Id = Guid.NewGuid(),
                                STKCODE = x.Field<string>("STKCODE"),
                                APPENDIX1 = x.Field<string>("APPENDIX1"),
                                APPENDIX2 = x.Field<string>("APPENDIX2"),
                                APPENDIX3 = x.Field<string>("APPENDIX3"),
                                CLASS1 = x.Field<string>("CLASS1"),
                                CLASS2 = x.Field<string>("CLASS2"),
                                CLASS3 = x.Field<string>("CLASS3"),
                                CLASS4 = x.Field<string>("CLASS4"),
                                CLASS5 = x.Field<string>("CLASS5"),
                                CLASS6 = x.Field<string>("CLASS6"),
                                BFQTY = x.Field<decimal>("BFQTY"),
                                BFAMT = x.Field<decimal>("BFAMT"),
                                CDQTY = x.Field<decimal>("CDQTY"),
                                CDAMT = x.Field<decimal>("CDAMT")
                            };
                            #endregion

                            #region create 多隻 transactions
                            for (int j = 0; j < hdr.Rows.Count; j++)
                            {
                                var y = hdr.Rows[j];
                                var tx = new InOutHistoryEx.Tx()
                                {
                                    Id = Guid.NewGuid(),
                                    STKCODE = y.Field<string>("STKCODE"),
                                    APPENDIX1 = y.Field<string>("APPENDIX1"),
                                    APPENDIX2 = y.Field<string>("APPENDIX2"),
                                    APPENDIX3 = y.Field<string>("APPENDIX3"),
                                    CLASS1 = y.Field<string>("CLASS1"),
                                    CLASS2 = y.Field<string>("CLASS2"),
                                    CLASS3 = y.Field<string>("CLASS3"),
                                    CLASS4 = y.Field<string>("CLASS4"),
                                    CLASS5 = y.Field<string>("CLASS5"),
                                    CLASS6 = y.Field<string>("CLASS6"),
                                    TxDate = y.Field<DateTime>("TxDate"),
                                    TxNumber = y.Field<string>("TxNumber"),
                                    TxType = y.Field<string>("TxType"),
                                    QTYIN = y.Field<decimal>("QTYIN"),
                                    QTYOUT = y.Field<decimal>("QTYOUT"),
                                    Price = y.Field<decimal>("Price"),
                                    AverageCost = y.Field<decimal>("AverageCost"),
                                    Reference = y.Field<string>("Reference"),
                                    FromLocation = y.Field<string>("FromLocation"),
                                    ToLocation = y.Field<string>("ToLocation"),
                                    SupplierCode = y.Field<string>("SupplierCode"),
                                    Remarks = y.Field<string>("Remarks")
                                };

                                product.Tx.Add(tx);
                            }
                            #endregion

                            products.Add(product);                                  // used for debug
                        }
                    }
                    #endregion

                    tpl.AddVariable("item", products);

                    #region labels 中英互換
                    tpl.AddVariable("CompanyName", WestwindHelper.GetWord("companyInfo.name", "Setting"));
                    tpl.AddVariable("ReportTitle", WestwindHelper.GetWord("report.SA1330", "Setting"));
                    tpl.AddVariable("lblSelectedRange", WestwindHelper.GetWordWithColon("reports.selectedRange", "General"));
                    tpl.AddVariable("lblSelectedStockCode", WestwindHelper.GetWordWithColon("article.code", "Product"));
                    tpl.AddVariable("lblSelectedDate", WestwindHelper.GetWordWithColon("transaction.date", "Transaction"));
                    tpl.AddVariable("pSelectedStockCode", string.Format("{0} ⇔ {1}", fromCode, toCode));
                    tpl.AddVariable("pSelectedDate", string.Format("{0} ⇔ {1}", fromDate, toDate));
                    tpl.AddVariable("lblPrintedOn", WestwindHelper.GetWordWithColon("reports.printedOn", "General"));
                    tpl.AddVariable("PrintedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    tpl.AddVariable("lblStockCode", WestwindHelper.GetWord("article.code", "Product"));
                    tpl.AddVariable("lblAppendix1", WestwindHelper.GetWord("appendix.appendix1", "Product"));
                    tpl.AddVariable("lblAppendix2", WestwindHelper.GetWord("appendix.appendix2", "Product"));
                    tpl.AddVariable("lblAppendix3", WestwindHelper.GetWord("appendix.appendix3", "Product"));
                    tpl.AddVariable("lblClass1", WestwindHelper.GetWord("class.class1", "Product"));
                    tpl.AddVariable("lblClass2", WestwindHelper.GetWord("class.class2", "Product"));
                    tpl.AddVariable("lblClass3", WestwindHelper.GetWord("class.class3", "Product"));
                    tpl.AddVariable("lblClass4", WestwindHelper.GetWord("class.class4", "Product"));
                    tpl.AddVariable("lblClass5", WestwindHelper.GetWord("class.class5", "Product"));
                    tpl.AddVariable("lblClass6", WestwindHelper.GetWord("class.class6", "Product"));
                    tpl.AddVariable("lblBFQty", WestwindHelper.GetWord("inventory.bfQty", "Product"));
                    tpl.AddVariable("lblBFAmount", WestwindHelper.GetWord("inventory.bfAmount", "Product"));
                    tpl.AddVariable("lblCDQty", WestwindHelper.GetWord("inventory.cdQty", "Product"));
                    tpl.AddVariable("lblCDAmount", WestwindHelper.GetWord("inventory.cdAmount", "Product"));

                    tpl.AddVariable("lblTxDate", WestwindHelper.GetWord("transaction.date", "Transaction"));
                    tpl.AddVariable("lblTxType", WestwindHelper.GetWord("transaction.type", "Transaction"));
                    tpl.AddVariable("lblQtyIn", WestwindHelper.GetWord("transaction.qtyIn", "Transaction"));
                    tpl.AddVariable("lblQtyOut", WestwindHelper.GetWord("transaction.qtyOut", "Transaction"));
                    tpl.AddVariable("lblPrice", WestwindHelper.GetWord("transaction.price", "Transaction"));
                    tpl.AddVariable("lblCost", WestwindHelper.GetWord("transaction.cost", "Transaction"));
                    tpl.AddVariable("lblTxNumber", WestwindHelper.GetWord("transaction.number", "Transaction"));
                    tpl.AddVariable("lblReference", WestwindHelper.GetWord("transaction.reference", "Transaction"));
                    tpl.AddVariable("lblLocation", WestwindHelper.GetWord("workplace", "Model"));
                    tpl.AddVariable("lblSupplierCode", WestwindHelper.GetWord("supplier", "Model"));
                    tpl.AddVariable("lblRemarks", WestwindHelper.GetWord("transaction.remarks", "Transaction"));
                    tpl.AddVariable("lblSubTotal", WestwindHelper.GetWordWithColon("transaction.subtotal", "Transaction"));
                    tpl.AddVariable("lblGrandTotal", WestwindHelper.GetWordWithColon("transaction.grandtotal", "Transaction"));
                    #endregion

                    tpl.Generate();
                    tpl.SaveAs(stream);

                    stream.Position = 0;
                    result = stream.ToArray();

                    stream.Flush();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    stream.Dispose();
                }
            }

            return result;
        }

        public static byte[] Pivot(SqlParameter[] param)
        {
            byte[] result = null;

            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    #region 喺 param 搵出 selected stockcode & date ranges
                    var fromCode = (string)param.Where(x => x.ParameterName == "@fromSTKCODE").FirstOrDefault().Value;
                    var toCode = (string)param.Where(x => x.ParameterName == "@toSTKCODE").FirstOrDefault().Value;
                    var fromDate = (DateTime)param.Where(x => x.ParameterName == "@fromDate").FirstOrDefault().Value;
                    var toDate = (DateTime)param.Where(x => x.ParameterName == "@toDate").FirstOrDefault().Value;
                    #endregion

                    var tpl = new XLTemplate(PivotFilePath);

                    var ds = Helper.SqlHelper.Default.ExecuteDataSet(IsCurrentPeriod(fromDate, toDate) ? _SpNameForCurrentPeriod : _SpNameForOtherPeriods, param);
                    var dt = ds.Tables[0];
                    var dr = from row in dt.AsEnumerable() select row;

                    #region create tx = List<InOutHistoryEx.Tx> from dt
                    var tx = dt.AsEnumerable()
                        .Select(x => new ModelEx.InOutSummaryEx.Product()
                        {
                            Id = Guid.NewGuid(),
                            TxType = x.Field<string>("TxType"),
                            TRRNO = x.Field<string>("TRRNO"),
                            LOCNO = x.Field<string>("LOCNO"),
                            STKCODE = x.Field<string>("STKCODE"),
                            APPENDIX1 = x.Field<string>("APPENDIX1"),
                            APPENDIX2 = x.Field<string>("APPENDIX2"),
                            APPENDIX3 = x.Field<string>("APPENDIX3"),
                            SEQNO = x.Field<int>("SEQNO"),
                            DESCRIPTION = x.Field<string>("DESCRIPTION"),

                            PW_CDQTY = x.Field<decimal>("PW_CDQTY"),
                            BF_AVRCOST = x.Field<decimal>("BF_AVRCOST"),
                            AVRCOST = x.Field<decimal>("AVRCOST"),
                            QTY = x.Field<decimal>("QTY"),
                            PCS_BFQTY = x.Field<decimal>("PCS_BFQTY"),
                            PW_BFQTY = x.Field<decimal>("PW_BFQTY"),
                            BFQTY = x.Field<decimal>("BFQTY"),
                            BFAMT = x.Field<decimal>("BFAMT"),

                            RECQTY = x.Field<decimal>("RECQTY"),
                            RECAMT = x.Field<decimal>("RECAMT"),
                            CAPQTY = x.Field<decimal>("CAPQTY"),
                            CAPAMT = x.Field<decimal>("CAPAMT"),
                            REJQTY = x.Field<decimal>("REJQTY"),
                            REJAMT = x.Field<decimal>("REJAMT"),
                            ADJQTY = x.Field<decimal>("ADJQTY"),
                            ADJAMT = x.Field<decimal>("ADJAMT"),
                            TXIQTY = x.Field<decimal>("TXIQTY"),
                            TXIAMT = x.Field<decimal>("TXIAMT"),
                            TXOQTY = x.Field<decimal>("TXOQTY"),
                            TXOAMT = x.Field<decimal>("TXOAMT"),
                            CASQTY = x.Field<decimal>("CASQTY"),
                            CASAMT = x.Field<decimal>("CASAMT"),
                            CRTQTY = x.Field<decimal>("CRTQTY"),
                            CRTAMT = x.Field<decimal>("CRTAMT"),
                            VODQTY = x.Field<decimal>("VODQTY"),
                            VODAMT = x.Field<decimal>("VODAMT"),
                            SALQTY = x.Field<decimal>("SALQTY"),
                            SALAMT = x.Field<decimal>("SALAMT"),
                            SRTQTY = x.Field<decimal>("SRTQTY"),
                            SRTAMT = x.Field<decimal>("SRTAMT"),

                            CDQTY = x.Field<decimal>("CDQTY"),
                            CDAMT = x.Field<decimal>("CDAMT"),
                            CAL_CDQTY = x.Field<decimal>("CAL_CDQTY"),
                            CAL_CDAMT = x.Field<decimal>("CAL_CDAMT"),
                            DIFF_CDQTY = x.Field<decimal>("DIFF_CDQTY"),
                            DIFF_CDAMT = x.Field<decimal>("DIFF_CDAMT")
                        })
                        .ToList();
                    #endregion

                    tpl.AddVariable("item", tx);

                    #region labels 中英互換
                    tpl.AddVariable("CompanyName", WestwindHelper.GetWord("companyInfo.name", "Setting"));
                    tpl.AddVariable("ReportTitle", WestwindHelper.GetWord("report.SA1340", "Setting"));
                    tpl.AddVariable("lblSelectedRange", WestwindHelper.GetWordWithColon("reports.selectedRange", "General"));
                    tpl.AddVariable("lblSelectedStockCode", WestwindHelper.GetWordWithColon("article.code", "Product"));
                    tpl.AddVariable("lblSelectedDate", WestwindHelper.GetWordWithColon("transaction.date", "Transaction"));
                    tpl.AddVariable("pSelectedStockCode", string.Format("{0} ⇔ {1}", fromCode, toCode));
                    tpl.AddVariable("pSelectedDate", string.Format("{0} ⇔ {1}", fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd")));
                    tpl.AddVariable("lblPrintedOn", WestwindHelper.GetWordWithColon("reports.printedOn", "General"));
                    tpl.AddVariable("PrintedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    tpl.AddVariable("lblStockCode", WestwindHelper.GetWord("article.code", "Product"));
                    tpl.AddVariable("lblAppendix1", WestwindHelper.GetWord("appendix.appendix1", "Product"));
                    tpl.AddVariable("lblAppendix2", WestwindHelper.GetWord("appendix.appendix2", "Product"));
                    tpl.AddVariable("lblAppendix3", WestwindHelper.GetWord("appendix.appendix3", "Product"));

                    tpl.AddVariable("lblBFQty", WestwindHelper.GetWord("inventory.bfQty", "Product"));
                    tpl.AddVariable("lblBFAmount", WestwindHelper.GetWord("inventory.bfAmount", "Product"));
                    tpl.AddVariable("lblCDQty", WestwindHelper.GetWord("inventory.cdQty", "Product"));
                    tpl.AddVariable("lblCDAmount", WestwindHelper.GetWord("inventory.cdAmount", "Product"));

                    tpl.AddVariable("lblTxDate", WestwindHelper.GetWord("transaction.date", "Transaction"));
                    tpl.AddVariable("lblYear", WestwindHelper.GetWord("glossary.year", "General"));
                    tpl.AddVariable("lblMonth", WestwindHelper.GetWord("glossary.month", "General"));
                    tpl.AddVariable("lblDay", WestwindHelper.GetWord("glossary.day", "General"));
                    tpl.AddVariable("lblTxType", WestwindHelper.GetWord("transaction.type", "Transaction"));

                    tpl.AddVariable("lblAverageCost", WestwindHelper.GetWord("transaction.cost", "Transaction"));
                    tpl.AddVariable("lblTxNumber", WestwindHelper.GetWord("transaction.number", "Transaction"));
                    tpl.AddVariable("lblLocation", WestwindHelper.GetWord("workplace", "Model"));

                    tpl.AddVariable("lblSubTotal", WestwindHelper.GetWordWithColon("transaction.subtotal", "Transaction"));
                    tpl.AddVariable("lblGrandTotal", WestwindHelper.GetWordWithColon("transaction.grandtotal", "Transaction"));

                    tpl.AddVariable("lblSeqNo", "SeqNo");
                    tpl.AddVariable("lblDescription", "Description");
                    tpl.AddVariable("lblPW_CDQTY", "PW_CDQTY");
                    tpl.AddVariable("lblBF_AVRCOST", "BF_AVRCOST");
                    tpl.AddVariable("lblQTY", "QTY");
                    tpl.AddVariable("lblPCS_BFQTY", "PCS_BFQTY");
                    tpl.AddVariable("lblPW_BFQTY", "PW_BFQTY");

                    tpl.AddVariable("lblRECQTY", "REC (+)");
                    tpl.AddVariable("lblRECAMT", "REC ($)");
                    tpl.AddVariable("lblCAPQTY", "CAP (+)");
                    tpl.AddVariable("lblCAPAMT", "CAP ($)");
                    tpl.AddVariable("lblREJQTY", "REJ (-)");
                    tpl.AddVariable("lblREJAMT", "REJ ($)");
                    tpl.AddVariable("lblADJQTY", "ADJ (+/-)");
                    tpl.AddVariable("lblADJAMT", "ADJ ($)");
                    tpl.AddVariable("lblTXIQTY", "TXI (+)");
                    tpl.AddVariable("lblTXIAMT", "TXI ($)");
                    tpl.AddVariable("lblTXOQTY", "TXO (-)");
                    tpl.AddVariable("lblTXOAMT", "TXO ($)");
                    tpl.AddVariable("lblCASQTY", "CAS (-)");
                    tpl.AddVariable("lblCASAMT", "CAS ($)");
                    tpl.AddVariable("lblCRTQTY", "CRT (+)");
                    tpl.AddVariable("lblCRTAMT", "CRT ($)");
                    tpl.AddVariable("lblVODQTY", "VOD (+)");
                    tpl.AddVariable("lblVODAMT", "VOD ($)");
                    tpl.AddVariable("lblSALQTY", "SAL (-)");
                    tpl.AddVariable("lblSALAMT", "SAL ($)");
                    tpl.AddVariable("lblSRTQTY", "SRT (+)");
                    tpl.AddVariable("lblSRTAMT", "SRT ($)");
                    tpl.AddVariable("lblCAL_CDQTY", "CAL CDQTY");
                    tpl.AddVariable("lblCAL_CDAMT", "CAL CDAMT");
                    tpl.AddVariable("lblDIFF_CDQTY", "DIFF CDQTY");
                    tpl.AddVariable("lblDIFF_CDAMT", "DIFF CDAMT");
                    #endregion

                    tpl.Generate();
                    tpl.SaveAs(stream);

                    stream.Position = 0;
                    result = stream.ToArray();

                    stream.Flush();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    stream.Dispose();
                }
            }

            return result;
        }

        /// <summary>
        /// 睇下 selected date range 係咪屬於 current period
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        private static bool IsCurrentPeriod(DateTime fromDate, DateTime toDate)
        {
            var result = false;

            var currentPeriod = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear + SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth;
            result = string.Compare(fromDate.ToString("yyyyMM"), currentPeriod) == 0 &&
                string.Compare(toDate.ToString("yyyyMM"), currentPeriod) == 0 ?
                true :
                false;

            return result;
        }
    }
}
