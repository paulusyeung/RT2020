using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class SystemInfoEx
    {
        public static EF6.SystemInfo Get(Guid id)
        {
            EF6.SystemInfo result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SystemInfo.Find(id);
            }

            return result;
        }

        public static bool ClearLogoInfo(Guid id)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sys = ctx.SystemInfo.Find(id);
                if (sys != null)
                {
                    sys.LOGO = string.Empty;
                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
    }
}