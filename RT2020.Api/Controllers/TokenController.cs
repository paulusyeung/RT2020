using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RT2020.Common.Helper;

namespace RT2020.Api.Controllers
{
    /// <summary>
    /// JWT Json Web Token
    /// </summary>
    [RoutePrefix("api/Token")]
    public class TokenController : ApiController
    {
        /// <summary>
        /// 將 username + password 放在 header 內
        /// </summary>
        /// <returns>token</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public string Get()
        {
            string user = "", pwd = "";
            var req = Request;
            var hdr = req.Headers;
            if ((hdr.Contains("username")) && (hdr.Contains("password")))
            {
                user = hdr.GetValues("username").First();
                pwd = hdr.GetValues("password").First();

                var oUser = CheckUser(user, pwd);
                if (oUser != null)
                {
                    return JwtHelper.GenerateToken(oUser.UserSid.ToString());
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// 將 username + password 放在 querystring 內
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>token</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("{username}/{password}")]
        public string Get(string username, string password)
        {
            var oUser = CheckUser(username, password);
            if (oUser != null)
            {
                return JwtHelper.GenerateToken(oUser.UserSid.ToString());
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// 將 username + password 放在 querystring 內
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>token</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("{username}/{password}/{expiry}")]
        public string Get(string username, string password, string expiry)
        {
            var oUser = CheckUser(username, password);
            if (oUser != null)
            {
                var expiryDate = DateTime.Now;

                if (DateTime.TryParseExact(expiry, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out expiryDate))
                {
                    TimeSpan t = (expiryDate - DateTime.Now);
                    var expiryInMinutes = t.TotalMinutes;
                    return JwtHelper.GenerateToken(oUser.UserSid.ToString(), (int)t.TotalMinutes);
                }
                else
                {
                    return JwtHelper.GenerateToken(oUser.UserSid.ToString());
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// 將 username + password 放在 header 內
        /// </summary>
        /// <returns>token</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("Staff")]
        public string GetStaff()
        {
            string user = "", pwd = "";
            var req = Request;
            var hdr = req.Headers;
            if ((hdr.Contains("username")) && (hdr.Contains("password")))
            {
                user = hdr.GetValues("username").First();
                pwd = hdr.GetValues("password").First();

                var oUser = CheckUser(user, pwd);
                if (oUser != null)
                {
                    if (oUser.UserType == (int)EnumHelper.UserType.Staff)
                    {
                        return JwtHelper.GenerateToken(oUser.UserSid.ToString());
                    }
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// 將 username + password 放在 querystring 內
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>token</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("Staff/{username}/{password}")]
        public string GetStaff(string username, string password)
        {
            var oUser = CheckUser(username, password);
            if (oUser != null)
            {
                if (oUser.UserType == (int)EnumHelper.UserType.Staff)
                {
                    return JwtHelper.GenerateToken(oUser.UserSid.ToString());
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// 將 username + password 放在 header 內
        /// </summary>
        /// <returns>token</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("Client")]
        public string GetClient()
        {
            string user = "", pwd = "";
            var req = Request;
            var hdr = req.Headers;
            if ((hdr.Contains("username")) && (hdr.Contains("password")))
            {
                user = hdr.GetValues("username").First();
                pwd = hdr.GetValues("password").First();

                var oUser = CheckUser(user, pwd);
                if (oUser != null)
                {
                    if (oUser.UserType == (int)EnumHelper.UserType.Customer)
                    {
                        return JwtHelper.GenerateToken(oUser.UserSid.ToString());
                    }
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// 將 username + password 放在 querystring 內
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>token</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("Client/{username}/{password}")]
        public string GetClient(string username, string password)
        {
            var oUser = CheckUser(username, password);
            if (oUser != null)
            {
                if (oUser.UserType == (int)EnumHelper.UserType.Customer)
                {
                    return JwtHelper.GenerateToken(oUser.UserSid.ToString());
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private EF6.UserProfile CheckUser(string username, string password)
        {
            EF6.UserProfile result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var user = ctx.UserProfile.FirstOrDefault(x => (x.LoginName == username) && (x.LoginPassword == password) && (x.Status >= 1));
                if (user != null)
                {
                    result = user;
                }
            }

            return result;
        }
    }
}
