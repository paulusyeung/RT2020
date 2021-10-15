using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

using RT2020.EF6;
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;
using Newtonsoft.Json;
using System.Text;
using Gizmox.WebGUI.Forms;
using System.Configuration;

namespace RT2020.Api.Controllers
{
    /// <summary>
    /// WPT Web Pivot Table Controller
    /// </summary>
    [RoutePrefix("api/Wpt")]
    public class WptController : ApiController
    {
        #region private properties
        //! HACK: 有啲唔算美滿，因為個 api server name 要根據實況要自行更改，不過，橫掂都要改 CORS Origins declarations
        private const string _ExcelUrl  = @"/api/Wpt/getExcelFile/{0}/{1}/{2}/";
        private const string _CsvUrl    = @"/api/Wpt/getCsvFile/{0}/{1}/{2}/";

        private string ExcelUrl
        {
            get
            {
                return ConfigHelper.ApiServerName + _ExcelUrl;
            }
        }

        private string CsvUrl
        {
            get
            {
                return ConfigHelper.ApiServerName + _CsvUrl;
            }
        }
        #endregion

        /// <summary>
        /// 喺 ReportsBox 之內搵隻同名嘅 wpt template
        /// 將 wpt template 嘅 ExcelUrl 更正，要使用 dbo.Pipeline 嘅選項
        /// </summary>
        /// <param name="filename">隻 wpt template 檔案名（冇 suffix 嘅）</param>
        /// <param name="id">個 dbo.Pipeline 嘅 PipelineId（隻 excel report 嘅 選項）</param>
        /// <param name="lang">語言（例如：en, zh-CN, zh-HK, zh-TW）</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getWptFile/{filename}/{id}/{lang}")]
        [AllowAnonymous]
        //[JwtAuthentication]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]    // allow ALL origins
        [EnableCors(origins: "http://rt2020.nxstudio.com,https://rt2020.nxstudio.com", headers: "*", methods: "*")]
        public HttpResponseMessage GetWptFile(string filename, string id, string lang)
        {
            using (var ctx = new RT2020Entities())
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);

                // 2021.10.14 paulus：WebPivotTable 係用 SheetJs 嚟 parse Excel contents，用 CSV 會安全啲
                //var dsUrl = string.Format(_ExcelUrl, filename, id, lang);
                var dsUrl = string.Format(this.CsvUrl, filename, id, lang);

                var wptText = PivotHelper.GetLocalizedWptFile(filename, lang);

                if (wptText != "")
                {
                    //if (File.Exists(wptFile))
                    //{
                    #region 讀入隻 wpt template 化做 response 送返俾 caller
                    //var text = (File.ReadAllText(wptFile)).Replace("#dsUrl#", dsUrl);   //! 替換 wpt 內的 data source Url
                    var text = wptText.Replace("#dsUrl#", dsUrl);   //! 替換 wpt 內的 data source Url
                    var raw = Encoding.UTF8.GetBytes(text);

                        if (raw != null)
                        {
                            var contentLength = raw.Length;
                            var mimeJson = "application/json";

                            var statuscode = HttpStatusCode.OK;     // 200 successful
                            response = Request.CreateResponse(statuscode);
                            response.Content = new StreamContent(new MemoryStream(raw));
                            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeJson);
                            response.Content.Headers.ContentLength = contentLength;

                            ContentDispositionHeaderValue contentDisposition = null;
                            if (ContentDispositionHeaderValue.TryParse("inline; filename=" + filename + ".wpt", out contentDisposition))
                            {
                                response.Content.Headers.ContentDisposition = contentDisposition;
                            }
                        }
                        else
                        {
                            var message = String.Format("Unable to find resource. Resource \"{0}\" may not exist.", filename);
                            HttpError err = new HttpError(message);
                            response = Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
                        }
                        #endregion
                    //}
                }
                return response;
            }
        }

        /// <summary>
        /// 喺 ReportsBox 之內搵隻同名嘅 Excel template
        /// 利用 ClosedXML.Report 生成 Excel 檔案做 wpt data source
        /// 注意：WebPivotTable 係用 SheetJs 嚟 parse Excel contents，所以天生會有 SheetJs 嘅 bugs，為咗保險我轉用 CSV
        /// </summary>
        /// <param name="filename">隻 Excel template 檔案名（冇 suffix 嘅）</param>
        /// <param name="id">個 dbo.Pipeline 嘅 PipelineId（隻 excel report 嘅 選項）</param>
        /// <param name="lang">語言（例如：en, zh-CN, zh-HK, zh-TW）</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getExcelFile/{filename}/{id}/{lang}/")]
        [AllowAnonymous]
        //[JwtAuthentication]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]    // allow ALL origins
        [EnableCors(origins: "http://rt2020.nxstudio.com,https://rt2020.nxstudio.com", headers: "*", methods: "*")]
        public HttpResponseMessage GetExcelFile(string filename, string id, string lang)
        {
            using (var ctx = new RT2020Entities())
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);

                // 如果 RT2020 call 會有 VWGContext，RT2020.Api call 就冇 VWGContext，咁就要用 AppSettings
                var directory = VWGContext.Current != null ?
                    VWGContext.Current.Config.GetDirectory("Reports") :
                    ConfigHelper.ReportsBox;

                using (new Impersonate(directory, ConfigHelper.Impersonate_UserName, ConfigHelper.Impersonate_UserPassword))
                {
                    // 喺 ReportsBox directory path 內搵出隻 excel template file
                    var excelFile = Directory.GetFiles(ConfigHelper.ReportsBox, "*.xlsx", SearchOption.AllDirectories)
                        .Where(x => Path.GetFileNameWithoutExtension(x) == filename)
                        .FirstOrDefault();
                    if (excelFile != null)
                    {
                        if (File.Exists(excelFile))
                        {
                            // 讀入 dbo.Pipeline 記低嘅 user 要嘅 options
                            var item = PipelineEx.Get(string.Format("PipelineId = '{0}'", id));
                            if (item != null)
                            {
                                #region 問 RT2020.Reports.dll 攞隻 Excel data source 送返俾 caller
                                var raw = Helper.SA1340Helper.GenExcelDataSource(filename, item.Content, lang);
                                if (raw != null)
                                {
                                    var contentLength = raw.Length;
                                    //var mimeXls = "application/vnd.ms-excel";
                                    var mimeXlsx = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                                    var statuscode = HttpStatusCode.OK; // 200 successful
                                    response = Request.CreateResponse(statuscode);
                                    response.Content = new StreamContent(new MemoryStream(raw));
                                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeXlsx);
                                    response.Content.Headers.ContentLength = contentLength;

                                    ContentDispositionHeaderValue contentDisposition = null;
                                    if (ContentDispositionHeaderValue.TryParse("inline; filename=" + filename + ".xlsx", out contentDisposition))
                                    {
                                        response.Content.Headers.ContentDisposition = contentDisposition;
                                    }
                                }
                                else
                                {
                                    var message = String.Format("Unable to find resource. Resource \"{0}\" may not exist.", filename);
                                    HttpError err = new HttpError(message);
                                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
                                }
                                #endregion
                            }
                        }
                    }
                }
                return response;
            }
        }

        /// <summary>
        /// 喺 ReportsBox 之內搵隻同名嘅 Excel template
        /// 利用 ClosedXML.Report 生成 Excel 再轉 Csv 檔案做 wpt data source
        /// </summary>
        /// <param name="filename">隻 Excel template 檔案名（冇 suffix 嘅）</param>
        /// <param name="id">個 dbo.Pipeline 嘅 PipelineId（隻 excel report 嘅 選項）</param>
        /// <param name="lang">語言（例如：en, zh-CN, zh-HK, zh-TW）</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCsvFile/{filename}/{id}/{lang}/")]
        [AllowAnonymous]
        //[JwtAuthentication]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]    // allow ALL origins
        [EnableCors(origins: "http://rt2020.nxstudio.com,https://rt2020.nxstudio.com", headers: "*", methods: "*")]
        public HttpResponseMessage GetCsvFile(string filename, string id, string lang)
        {
            using (var ctx = new RT2020Entities())
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);

                // 讀入 dbo.Pipeline 記低嘅 user 要嘅 options
                var item = PipelineEx.Get(string.Format("PipelineId = '{0}'", id));
                if (item != null)
                {
                    #region 問 RT2020.Reports.dll 攞隻 Csv data source 送返俾 caller
                    var raw = Helper.SA1340Helper.GenCsvDataSource(filename, item.Content, lang);
                    if (raw != "")
                    {
                        var content = Encoding.UTF8.GetBytes(raw);  //! 將原本嘅 string 轉為 UTF8 byte[]
                        var contentLength = content.Length;
                        var mimeCsv = "text/csv";
                        var statuscode = HttpStatusCode.OK; // 200 successful

                        response = Request.CreateResponse(statuscode);
                        response.Content = new ByteArrayContent(Encoding.UTF8.GetPreamble().Concat(content).ToArray()); //! 加上 UTF8 Preamble
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeCsv);
                        response.Content.Headers.ContentLength = contentLength;

                        ContentDispositionHeaderValue contentDisposition = null;
                        if (ContentDispositionHeaderValue.TryParse("inline; filename=" + filename + ".csv", out contentDisposition))
                        {
                            response.Content.Headers.ContentDisposition = contentDisposition;
                        }
                    }
                    else
                    {
                        var message = String.Format("Unable to find resource. Resource \"{0}\" may not exist.", filename);
                        HttpError err = new HttpError(message);
                        response = Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
                    }
                    #endregion
                }
                return response;
            }
        }
    }
}
