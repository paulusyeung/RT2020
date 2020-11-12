using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Hangfire;
using log4net;
using RT2020.EF6;
using RT2020.Bot.Helper;

namespace RT2020.Bot.Controllers
{
    public class BotController : ApiController
    {
        #region Instead of naming my invoking class, I started using the following:
        //private static log4net.ILog Log { get; set; }
        //ILog log = log4net.LogManager.GetLogger(typeof(BotController));

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // In this way, I can use the same line of code in every class that uses log4net without having to remember to change code when I copy and paste.
        // Alternatively, i could create a logging class, and have every other class inherit from my logging class.
        // Refer: https://stackoverflow.com/questions/7089286/correct-way-of-using-log4net-logger-naming
        #endregion

        [HttpPost]
        [Route("GenMemberPhoneNumbers/{userId}/")]
        public IHttpActionResult GenMemberPhoneNumbers(String userId)
        {
            var id = Guid.Empty;
            if (Guid.TryParse(userId, out id))
            {
                using (var ctx = new RT2020Entities())
                {
                    var staff = ctx.Staff.Where(x => x.StaffId == id && x.Status > 0).SingleOrDefault();
                    if (staff != null)
                    {
                        BackgroundJob.Enqueue(() => SuperUserHelper.GenMemberPhoneNumbers(id));
                        //SuperUserHelper.GenMemberPhoneNumbers(id);

                        log.Info(String.Format("[bot, SuperUser, GenMemberPhoneNumbers] \r\nHangfire findished the Job\r\nUser = {0}", String.IsNullOrEmpty(staff.FullName) ? staff.StaffCode : staff.FullName));

                        return StatusCode(HttpStatusCode.Accepted);     // 202 or use: return new StatusCodeResult(202);
                    }
                }
            }

            log.Info(String.Format("[bot, SuperUser, GenMemberPhoneNumbers] \r\nError found before submitting to Hangfire\r\nUser Id = {0}", userId));

            return BadRequest();
        }
    }
}
