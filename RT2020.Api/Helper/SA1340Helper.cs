using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Report;
using log4net;
using Newtonsoft.Json;
using RT2020.Common.Helper;
using Gizmox.WebGUI.Forms;
using System.Data;
using ClosedXML.Excel;
using System.Threading;
using System.Globalization;

namespace RT2020.Api.Helper
{
    public class SA1340Helper
    {
        #region private properties: _Sql, _ReportName
        private const string _SpNameForCurrentPeriod = "apStockInOutSummary_CurrentMonth";
        private const string _SpNameForOtherPeriods = "apStockInOutSummary_HistoryMonth";
        private const string _Sql = @"";

        private static string _FastReportName = "Inventory\\Journal\\SA1340-Summary.frx";
        private static string _ExcelTemplate = "Inventory\\Journal\\SA1340-Summary.xlsx";
        private static string _HtmlTemplate = "Inventory\\Journal\\SA1340-Summary.html";
        private static string _PivotTemplate = "Inventory\\Journal\\SA1340-SummaryPivot.xlsx";
        private static string _WptTemplate = "Inventory\\Journal\\SA1340-Summary.wpt";

        private static string FastReportFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _FastReportName); }
        }

        private static string ReportFileName
        {
            get { return Path.GetFileNameWithoutExtension(FastReportFilePath); }
        }

        private static string ExcelFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _ExcelTemplate); }
        }

        private static string HtmlFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _HtmlTemplate); }
        }

        private static string PivotFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _PivotTemplate); }
        }

        private static string WptFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Reports"), _WptTemplate); }
        }
        #endregion

        #region Instead of naming my invoking class, I started using the following:
        //private static log4net.ILog Log { get; set; }
        //ILog log = log4net.LogManager.GetLogger(typeof(BotController));

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // In this way, I can use the same line of code in every class that uses log4net without having to remember to change code when I copy and paste.
        // Alternatively, i could create a logging class, and have every other class inherit from my logging class.
        // Refer: https://stackoverflow.com/questions/7089286/correct-way-of-using-log4net-logger-naming
        #endregion

        /// <summary>
        /// 根據 json data 轉成 SqlParamters 再 call GenExcelDataSource 攞 Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="jsonData"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static byte[] GenExcelDataSource(string filename, string jsonData, string lang)
        {
            byte[] result = null;

            try
            {
                dynamic options = JsonConvert.DeserializeObject(jsonData);
                if (options != null)
                {
                    #region 用 DynamicObject 將 json data 轉為 SqlParameters: param
                    var fromSTKCODE = (string)options.fromSTKCODE;
                    var toSTKCODE = (string)options.toSTKCODE;
                    var fromDate = (DateTime)options.fromDate;
                    var toDate = (DateTime)options.toDate;
                    var selectedWorkplaceCode = (string)options.selectedWorkplaceCode;
                    var selectedTYPE = (string)options.selectedTYPE;
                    var showSkipZeroQty = (string)options.showSkipZeroQty;
                    var showReCalculatedCD = (string)options.showReCalculatedCD;

                    SqlParameter[] param = {
                        new SqlParameter("@fromSTKCODE", fromSTKCODE),
                        new SqlParameter("@toSTKCODE", toSTKCODE),
                        new SqlParameter("@fromDate", fromDate),
                        new SqlParameter("@toDate", toDate),
                        new SqlParameter("@SelectedWorkplaceCode", selectedWorkplaceCode.Replace("'","")),
                        new SqlParameter("@SelectedTYPE", selectedTYPE),
                        new SqlParameter("@ShowSkipZeroQty", showSkipZeroQty),
                        new SqlParameter("@ShowReCalculatedCD", showReCalculatedCD)
                    };
                    #endregion

                    log.Info(String.Format("[GenExcelDataSource, Start] \r\nfileName:\r\n{0}\r\njsonData:\r\n{1}", filename, jsonData));
                    result = GenExcelDataSource(filename, param, lang);
                    log.Info(String.Format("[GenExcelDataSource, Stop] \r\nfileName:\r\n{0}\r\njsonData:\r\n{1}", filename, jsonData));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 1. 根據 param 去 SQL 攞 data
        /// 2. 根據 Excel file 用 ClosedXML.Report 生成 Excel (MemoryStream)
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="param"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        private static byte[] GenExcelDataSource(string filename, SqlParameter[] param, string lang)
        {
            byte[] result = null;

            try
            {
                #region 喺 param 搵出 selected stockcode & date ranges
                var fromCode = (string)param.Where(x => x.ParameterName == "@fromSTKCODE").FirstOrDefault().Value;
                var toCode = (string)param.Where(x => x.ParameterName == "@toSTKCODE").FirstOrDefault().Value;
                var fromDate = (DateTime)param.Where(x => x.ParameterName == "@fromDate").FirstOrDefault().Value;
                var toDate = (DateTime)param.Where(x => x.ParameterName == "@toDate").FirstOrDefault().Value;
                #endregion

                var excelFile = Directory.GetFiles(ConfigHelper.ReportsBox, "*.xlsx", SearchOption.AllDirectories)
                    .Where(x => Path.GetFileNameWithoutExtension(x) == filename)
                    .FirstOrDefault();

                if (excelFile != null)
                {
                    using (var fileStream = new FileStream(excelFile, FileMode.Open, FileAccess.Read))
                    {
                        if (fileStream != null)
                        {
                            fileStream.Seek(0, SeekOrigin.Begin);

                            //! 本來係可以直接讀入隻 excel template，不過，用 FileStream 多咗 FileMode 同 FileAccess 可控
                            //var tpl = new XLTemplate(excelFile);
                            var tpl = new XLTemplate(fileStream);

                            log.Info(String.Format("[GenExcelDataSource, Dataset] \r\nStart:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            #region populate data source
                            var ds = SqlHelper.Default.ExecuteDataSet(SystemInfoHelper.IsCurrentPeriod(fromDate, toDate) ? _SpNameForCurrentPeriod : _SpNameForOtherPeriods, param);
                            var dt = ds.Tables[0];
                            //var dr = from row in dt.AsEnumerable() select row;
                            #endregion
                            log.Info(String.Format("[GenExcelDataSource, Dataset] \r\nStop:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                            #region create tx = List<InOutHistoryEx.Tx> from dt
                            var tx = dt.AsEnumerable()
                                .Select(x => new RT2020.Reports.ModelEx.InOutSummaryEx.Product()
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
                            tpl.AddVariable("CompanyName", WestwindHelper.GetWord("companyInfo.name", "Setting", lang));
                            tpl.AddVariable("ReportTitle", WestwindHelper.GetWord("report.SA1340", "Setting", lang));
                            tpl.AddVariable("lblSelectedRange", WestwindHelper.GetWordWithColon("reports.selectedRange", "General", lang));
                            tpl.AddVariable("lblSelectedStockCode", WestwindHelper.GetWordWithColon("article.code", "Product", lang));
                            tpl.AddVariable("lblSelectedDate", WestwindHelper.GetWordWithColon("transaction.date", "Transaction", lang));
                            tpl.AddVariable("pSelectedStockCode", string.Format("{0} ⇔ {1}", fromCode, toCode));
                            tpl.AddVariable("pSelectedDate", string.Format("{0} ⇔ {1}", fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd")));
                            tpl.AddVariable("lblPrintedOn", WestwindHelper.GetWordWithColon("reports.printedOn", "General", lang));
                            tpl.AddVariable("PrintedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            tpl.AddVariable("lblStockCode", WestwindHelper.GetWord("article.code", "Product", lang));
                            tpl.AddVariable("lblAppendix1", WestwindHelper.GetWord("appendix.appendix1", "Product", lang));
                            tpl.AddVariable("lblAppendix2", WestwindHelper.GetWord("appendix.appendix2", "Product", lang));
                            tpl.AddVariable("lblAppendix3", WestwindHelper.GetWord("appendix.appendix3", "Product", lang));

                            tpl.AddVariable("lblBFQty", WestwindHelper.GetWord("inventory.bfQty", "Product", lang));
                            tpl.AddVariable("lblBFAmount", WestwindHelper.GetWord("inventory.bfAmount", "Product", lang));
                            tpl.AddVariable("lblCDQty", WestwindHelper.GetWord("inventory.cdQty", "Product", lang));
                            tpl.AddVariable("lblCDAmount", WestwindHelper.GetWord("inventory.cdAmount", "Product", lang));

                            tpl.AddVariable("lblTxDate", WestwindHelper.GetWord("transaction.date", "Transaction", lang));
                            tpl.AddVariable("lblYear", WestwindHelper.GetWord("glossary.year", "General", lang));
                            tpl.AddVariable("lblMonth", WestwindHelper.GetWord("glossary.month", "General", lang));
                            tpl.AddVariable("lblDay", WestwindHelper.GetWord("glossary.day", "General", lang));
                            tpl.AddVariable("lblTxType", WestwindHelper.GetWord("transaction.type", "Transaction", lang));

                            tpl.AddVariable("lblAverageCost", WestwindHelper.GetWord("transaction.cost", "Transaction", lang));
                            tpl.AddVariable("lblTxNumber", WestwindHelper.GetWord("transaction.number", "Transaction", lang));
                            tpl.AddVariable("lblLocation", WestwindHelper.GetWord("workplace", "Model", lang));

                            tpl.AddVariable("lblSubTotal", WestwindHelper.GetWordWithColon("transaction.subtotal", "Transaction", lang));
                            tpl.AddVariable("lblGrandTotal", WestwindHelper.GetWordWithColon("transaction.grandtotal", "Transaction", lang));

                            tpl.AddVariable("lblSeqNo", WestwindHelper.GetWord("glossary.sequencyNumber", "General", lang));
                            tpl.AddVariable("lblDescription", WestwindHelper.GetWord("article.description", "Product", lang));
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

                            log.Info(String.Format("[GenExcelDataSource, Generate] \r\nStart:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            tpl.Generate();
                            log.Info(String.Format("[GenExcelDataSource, Generate] \r\nStop:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            
                            using (var mstream = new MemoryStream())
                            {
                                /** save as file, used in debugging
                                var guid = Guid.NewGuid();
                                var filepath = Path.Combine(ConfigHelper.OutBox, string.Format("{0}_{1}.xlsx", filename, guid.ToString()));
                                tpl.SaveAs(filepath, new SaveOptions { EvaluateFormulasBeforeSaving = false, GenerateCalculationChain = false, ValidatePackage = false });
                                log.Info(String.Format("[GenExcelDataSource, File] \r\nSave:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                */

                                //lock (lockObject)     // 防止 simutaneously access
                                //{
                                log.Info(String.Format("[GenExcelDataSource, MemoryStream] \r\nStart:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                tpl.SaveAs(mstream, new SaveOptions { EvaluateFormulasBeforeSaving = false, GenerateCalculationChain = false, ValidatePackage = false });
                                log.Info(String.Format("[GenExcelDataSource, MemoryStream] \r\nStop:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                //}

                                mstream.Position = 0;
                                result = mstream.ToArray();
                            }
                            tpl.Dispose();
                            //log.Info(String.Format("[GenExcelDataSource, MemoryStream] \r\nFlush:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// 根據 json data 轉成 SqlParamters 再 call GenCsvDataSource 攞 CSV text (Comma delimited)
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="jsonData"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static string GenCsvDataSource(string filename, string jsonData, string lang)
        {
            string result = "";

            try
            {
                dynamic options = JsonConvert.DeserializeObject(jsonData);
                if (options != null)
                {
                    #region 用 DynamicObject 將 json data 轉為 SqlParameters: param
                    var fromSTKCODE = (string)options.fromSTKCODE;
                    var toSTKCODE = (string)options.toSTKCODE;
                    var fromDate = (DateTime)options.fromDate;
                    var toDate = (DateTime)options.toDate;
                    var selectedWorkplaceCode = (string)options.selectedWorkplaceCode;
                    var selectedTYPE = (string)options.selectedTYPE;
                    var showSkipZeroQty = (string)options.showSkipZeroQty;
                    var showReCalculatedCD = (string)options.showReCalculatedCD;

                    SqlParameter[] param = {
                        new SqlParameter("@fromSTKCODE", fromSTKCODE),
                        new SqlParameter("@toSTKCODE", toSTKCODE),
                        new SqlParameter("@fromDate", fromDate),
                        new SqlParameter("@toDate", toDate),
                        new SqlParameter("@SelectedWorkplaceCode", selectedWorkplaceCode.Replace("'","")),
                        new SqlParameter("@SelectedTYPE", selectedTYPE),
                        new SqlParameter("@ShowSkipZeroQty", showSkipZeroQty),
                        new SqlParameter("@ShowReCalculatedCD", showReCalculatedCD)
                    };
                    #endregion

                    log.Info(String.Format("[GenCsvDataSource, Start] \r\nfileName:\r\n{0}\r\njsonData:\r\n{1}", filename, jsonData));
                    result = GenCsvDataSource(filename, param, lang);
                    log.Info(String.Format("[GenCsvDataSource, Stop] \r\nfileName:\r\n{0}\r\njsonData:\r\n{1}", filename, jsonData));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 1. 根據 param 去 SQL 攞 data
        /// 2. 根據 Excel file 用 ClosedXML.Report 生成 Excel (MemoryStream)
        /// 3. 利用 Linq 將 Excel (MemoryStream) 轉為 CSV Text
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="param"></param>
        /// <param name="lang"></param>
        /// <returns>CSV Text</returns>
        private static string GenCsvDataSource(string filename, SqlParameter[] param, string lang)
        {
            string result = "";

            try
            {
                #region 喺 param 搵出 selected stockcode & date ranges
                var fromCode = (string)param.Where(x => x.ParameterName == "@fromSTKCODE").FirstOrDefault().Value;
                var toCode = (string)param.Where(x => x.ParameterName == "@toSTKCODE").FirstOrDefault().Value;
                var fromDate = (DateTime)param.Where(x => x.ParameterName == "@fromDate").FirstOrDefault().Value;
                var toDate = (DateTime)param.Where(x => x.ParameterName == "@toDate").FirstOrDefault().Value;
                #endregion

                // 如果 RT2020 call 會有 VWGContext，RT2020.Api call 就冇 VWGContext，咁就要用 AppSettings
                var directory = VWGContext.Current != null ?
                    VWGContext.Current.Config.GetDirectory("Reports") :
                    ConfigHelper.ReportsBox;

                using (new Impersonate(directory, ConfigHelper.Impersonate_UserName, ConfigHelper.Impersonate_UserPassword))
                {
                    var excelFile = Directory.GetFiles(ConfigHelper.ReportsBox, "*.xlsx", SearchOption.AllDirectories)
                        .Where(x => Path.GetFileNameWithoutExtension(x) == filename)
                        .FirstOrDefault();

                    if (excelFile != null)
                    {
                        using (var fileStream = new FileStream(excelFile, FileMode.Open, FileAccess.Read))
                        {
                            if (fileStream != null)
                            {
                                fileStream.Seek(0, SeekOrigin.Begin);

                                //! 本來係可以直接讀入隻 excel template，不過，用 FileStream 多咗 FileMode 同 FileAccess 可控
                                //var tpl = new XLTemplate(excelFile);
                                var tpl = new XLTemplate(fileStream);

                                log.Info(String.Format("[GenCsvDataSource, Dataset] \r\nStart:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                #region populate data source
                                var ds = SqlHelper.Default.ExecuteDataSet(SystemInfoHelper.IsCurrentPeriod(fromDate, toDate) ? _SpNameForCurrentPeriod : _SpNameForOtherPeriods, param);
                                var dt = ds.Tables[0];
                                //var dr = from row in dt.AsEnumerable() select row;
                                #endregion
                                log.Info(String.Format("[GenCsvDataSource, Dataset] \r\nStop:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                                #region create tx = List<InOutHistoryEx.Tx> from dt
                                var tx = dt.AsEnumerable()
                                    .Select(x => new RT2020.Reports.ModelEx.InOutSummaryEx.Product()
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
                                tpl.AddVariable("CompanyName", WestwindHelper.GetWord("companyInfo.name", "Setting", lang));
                                tpl.AddVariable("ReportTitle", WestwindHelper.GetWord("report.SA1340", "Setting", lang));
                                tpl.AddVariable("lblSelectedRange", WestwindHelper.GetWordWithColon("reports.selectedRange", "General", lang));
                                tpl.AddVariable("lblSelectedStockCode", WestwindHelper.GetWordWithColon("article.code", "Product", lang));
                                tpl.AddVariable("lblSelectedDate", WestwindHelper.GetWordWithColon("transaction.date", "Transaction", lang));
                                tpl.AddVariable("pSelectedStockCode", string.Format("{0} ⇔ {1}", fromCode, toCode));
                                tpl.AddVariable("pSelectedDate", string.Format("{0} ⇔ {1}", fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd")));
                                tpl.AddVariable("lblPrintedOn", WestwindHelper.GetWordWithColon("reports.printedOn", "General", lang));
                                tpl.AddVariable("PrintedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                tpl.AddVariable("lblStockCode", WestwindHelper.GetWord("article.code", "Product", lang));
                                tpl.AddVariable("lblAppendix1", WestwindHelper.GetWord("appendix.appendix1", "Product", lang));
                                tpl.AddVariable("lblAppendix2", WestwindHelper.GetWord("appendix.appendix2", "Product", lang));
                                tpl.AddVariable("lblAppendix3", WestwindHelper.GetWord("appendix.appendix3", "Product", lang));

                                tpl.AddVariable("lblBFQty", WestwindHelper.GetWord("inventory.bfQty", "Product", lang));
                                tpl.AddVariable("lblBFAmount", WestwindHelper.GetWord("inventory.bfAmount", "Product", lang));
                                tpl.AddVariable("lblCDQty", WestwindHelper.GetWord("inventory.cdQty", "Product", lang));
                                tpl.AddVariable("lblCDAmount", WestwindHelper.GetWord("inventory.cdAmount", "Product", lang));

                                tpl.AddVariable("lblTxDate", WestwindHelper.GetWord("transaction.date", "Transaction", lang));
                                tpl.AddVariable("lblYear", WestwindHelper.GetWord("glossary.year", "General", lang));
                                tpl.AddVariable("lblMonth", WestwindHelper.GetWord("glossary.month", "General", lang));
                                tpl.AddVariable("lblDay", WestwindHelper.GetWord("glossary.day", "General", lang));
                                tpl.AddVariable("lblTxType", WestwindHelper.GetWord("transaction.type", "Transaction", lang));

                                tpl.AddVariable("lblAverageCost", WestwindHelper.GetWord("transaction.cost", "Transaction", lang));
                                tpl.AddVariable("lblTxNumber", WestwindHelper.GetWord("transaction.number", "Transaction", lang));
                                tpl.AddVariable("lblLocation", WestwindHelper.GetWord("workplace", "Model", lang));

                                tpl.AddVariable("lblSubTotal", WestwindHelper.GetWordWithColon("transaction.subtotal", "Transaction", lang));
                                tpl.AddVariable("lblGrandTotal", WestwindHelper.GetWordWithColon("transaction.grandtotal", "Transaction", lang));

                                tpl.AddVariable("lblSeqNo", WestwindHelper.GetWord("glossary.sequencyNumber", "General", lang));
                                tpl.AddVariable("lblDescription", WestwindHelper.GetWord("article.description", "Product", lang));
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

                                log.Info(String.Format("[GenCsvDataSource, Generate] \r\nStart:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                tpl.Generate();
                                log.Info(String.Format("[GenCsvDataSource, Generate] \r\nStop:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                                result = ConvertToCsv(tpl);

                                /** deprecated
                                using (var mstream = new MemoryStream())
                                {
                                    //var guid = Guid.NewGuid();
                                    //var filepath = Path.Combine(ConfigHelper.OutBox, string.Format("{0}_{1}.xlsx", filename, guid.ToString()));
                                    //tpl.SaveAs(filepath, new SaveOptions { EvaluateFormulasBeforeSaving = false, GenerateCalculationChain = false, ValidatePackage = false });
                                    //log.Info(String.Format("[GenCsvDataSource, File] \r\nSave:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                                    //lock (lockObject)
                                    //{
                                    log.Info(String.Format("[GenCsvDataSource, MemoryStream] \r\nStart:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                    tpl.SaveAs(mstream, new SaveOptions { EvaluateFormulasBeforeSaving = false, GenerateCalculationChain = false, ValidatePackage = false });
                                    log.Info(String.Format("[GenCsvDataSource, MemoryStream] \r\nStop:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                    //}

                                    mstream.Position = 0;
                                    result = mstream.ToArray();
                                }
                                */

                                tpl.Dispose();
                                //log.Info(String.Format("[GenCsvDataSource, MemoryStream] \r\nFlush:\r\n{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        private static string ConvertToCsv(XLTemplate tpl)
        {
            // 參考：https://stackoverflow.com/questions/27102904/can-i-save-an-excel-worksheet-as-csv-via-closedxml
            //var csvFileName = "";
            var worksheet = tpl.Workbook.Worksheet(1);  // Sheet1

            var firstColumn = 2;    // 唔要第一列，因為 ClosedXML.Report 要求係吉嘅
            IXLAddress lastCellAddress = worksheet.RangeUsed().LastCell().Address;

            //byte[] bytes = null;
            string text = "";

            text = string.Join("\r\n", worksheet
                    //.RowsUsed()
                    //.Select(row => string.Join(";", row.Cells(2, row.LastCellUsed(false).Address.ColumnNumber)
                    //.Select(cell => cell.GetValue<string>()))
                    //)
                    .Rows(1, lastCellAddress.RowNumber)
                    .Select(r => string.Join(",", r.Cells(firstColumn, lastCellAddress.ColumnNumber)
                        .Select(cell =>
                        {
                            var cellValue = cell.GetValue<string>();
                            return cellValue.Contains(",") ? $"\"{cellValue}\"" : cellValue;
                        })
                    ))
                );
            //bytes = Encoding.UTF8.GetBytes(text);

            return text;

            /** deprecated
            using (var ms = new MemoryStream())
            {
                using (TextWriter tw = new StreamWriter(ms))
                {
                    lastCellAddress = worksheet.RangeUsed().LastCell().Address;
                    tw.Write(
                        worksheet
                            .Rows(1, lastCellAddress.RowNumber)
                            .Select(r => string.Join(",", r.Cells(1, lastCellAddress.ColumnNumber)
                            .Select(cell =>
                                {
                                    var cellValue = cell.GetValue<string>();
                                    return cellValue.Contains(",") ? $"\"{cellValue}\"" : cellValue;
                                })
                            ))

                        //worksheet
                        //    .RowsUsed()
                        //    .Select(row => string.Join(";", row.Cells(1, row.LastCellUsed(false).Address.ColumnNumber)
                        //    .Select(cell => cell.GetValue<string>()))
                        //    )
                        );
                    tw.Flush();
                    ms.Position = 0;
                    bytes = ms.ToArray();
                    text = bytes.ToString();
                }
            }

            lastCellAddress = worksheet.RangeUsed().LastCell().Address;
            File.WriteAllLines(csvFileName, worksheet.Rows(1, lastCellAddress.RowNumber)
                .Select(r => string.Join(",", r.Cells(1, lastCellAddress.ColumnNumber)
                        .Select(cell =>
                        {
                            var cellValue = cell.GetValue<string>();
                            return cellValue.Contains(",") ? $"\"{cellValue}\"" : cellValue;
                        }))));

            File.WriteAllLines(
                csvFileName,
                worksheet
                    .RowsUsed()
                    .Select(row => string.Join(";", row.Cells(1, row.LastCellUsed(false).Address.ColumnNumber)
                    .Select(cell => cell.GetValue<string>()))
                    )
                );
        */
        }
    }
}
