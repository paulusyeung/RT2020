using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

using RT2020.Common.Helper;
using System.Web;

namespace RT2020.Api.Controllers
{
    [RoutePrefix("FileProxy")]
    public class FileProxyController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public HttpResponseMessage Post()
        {
            string fileUrl = "";
            var req = Request;
            var hdr = req.Headers;

            if (hdr.Contains("x-file-url"))
            {
                fileUrl = hdr.GetValues("x-file-url").First();
                if (fileUrl != String.Empty)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    var filepath = Path.Combine(ConfigHelper.OutBox, fileUrl);
                    if (File.Exists(filepath))
                    {
                        var raw = File.ReadAllBytes(filepath);
                        if (raw != null)
                        {
                            var contentLength = raw.Length;

                            //200 successful
                            var statuscode = HttpStatusCode.OK;
                            response = Request.CreateResponse(statuscode);
                            response.Content = new StreamContent(new MemoryStream(raw));
                            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                            response.Content.Headers.ContentLength = contentLength;

                            ContentDispositionHeaderValue contentDisposition = null;
                            if (ContentDispositionHeaderValue.TryParse("inline; filename=" + fileUrl, out contentDisposition))
                            {
                                response.Content.Headers.ContentDisposition = contentDisposition;
                            }
                        }
                        else
                        {
                            var message = String.Format("Null file. Resource \"{0}\" may not exist.", fileUrl);
                            HttpError err = new HttpError(message);
                            response = Request.CreateErrorResponse(HttpStatusCode.NoContent, err);
                        }
                    }
                    else
                    {
                        var message = String.Format("Unable to find resource. Resource \"{0}\" may not exist.", fileUrl);
                        HttpError err = new HttpError(message);
                        response = Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
                    }
                    return response;
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}
