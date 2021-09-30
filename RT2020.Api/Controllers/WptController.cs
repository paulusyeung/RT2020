using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

using RT2020.Api.Filters;
using RT2020.EF6;
using RT2020.Common.Helper;

namespace RT2020.Api.Controllers
{
    /// <summary>
    /// WPT Web Pivot Table Controller
    /// </summary>
    [RoutePrefix("api/Wpt")]
    public class WptController : ApiController
    {
        [HttpGet]
        [Route("getWptFile/{filename}")]
        [AllowAnonymous]
        //[JwtAuthentication]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]    // allow ALL origins
        [EnableCors(origins: "http://rt2020.nxstudio.com,https://rt2020.nxstudio.com", headers: "*", methods: "*")]
        public HttpResponseMessage GetWptFile(string filename)
        {
            using (var ctx = new RT2020Entities())
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);

                var filepath = Path.Combine(ConfigHelper.OutBox, filename);
                var raw = File.ReadAllBytes(filepath);

                if (raw != null)
                {
                    var contentLength = raw.Length;

                    //200
                    //successful
                    var statuscode = HttpStatusCode.OK;
                    response = Request.CreateResponse(statuscode);
                    response.Content = new StreamContent(new MemoryStream(raw));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response.Content.Headers.ContentLength = contentLength;

                    ContentDispositionHeaderValue contentDisposition = null;
                    if (ContentDispositionHeaderValue.TryParse("inline; filename=" + filename, out contentDisposition))
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
                return response;
            }
        }
    }
}
