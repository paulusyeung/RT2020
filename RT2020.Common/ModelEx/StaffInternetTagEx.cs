using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;
using System.Data.Entity;

namespace RT2020.Common.ModelEx
{
    /// <summary>
    /// 都名不對題
    /// RT2020 攞咗嚟做 Internet Address/ Exchange Address/ URL Address
    /// 呢 3 個 Address 都唔知係咩呢嘅？
    /// </summary>
    public class StaffInternetTagEx
    {
        public static string GetTagValue(Guid staffId, Guid internetTagId)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var sp = ctx.StaffInternetTag.Where(x => x.StaffId == staffId).AsNoTracking().FirstOrDefault();
                if (sp != null)
                {
                    result = sp.InternetTag1 == internetTagId ?
                        sp.InternetTag1Value : sp.InternetTag2 == internetTagId ?
                        sp.InternetTag2Value : sp.InternetTag3 == internetTagId ?
                        sp.InternetTag3Value : sp.InternetTag4 == internetTagId ?
                        sp.InternetTag4Value : "";
                }
            }

            return result;
        }

        public static string GetTagValue(Guid staffId, TagName tagName)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var sp = ctx.StaffInternetTag.Where(x => x.StaffId == staffId).AsNoTracking().FirstOrDefault();
                if (sp != null)
                {
                    result = tagName == TagName.Internet ?
                        sp.InternetTag1Value : tagName == TagName.Exchange ?
                        sp.InternetTag2Value : tagName == TagName.URL ?
                        sp.InternetTag3Value : "";
                }
            }

            return result;
        }

        public enum TagName
        {
            Internet = 1,
            Exchange,
            URL
        }
    }
}