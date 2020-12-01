using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class UserProfileEx
    {
        public static EF6.UserProfile GetByUserSid(Guid sid)
        {
            EF6.UserProfile result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.UserProfile.Where(x => x.UserSid == sid).AsNoTracking().FirstOrDefault();
                result = item;
            }

            return result;
        }

        public static Guid GetUserIdBySid(Guid sid)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.UserProfile.Where(x => x.UserSid == sid).AsNoTracking().FirstOrDefault();
                if (item != null) result = item.UserId;
            }

            return result;
        }

        public static EF6.UserProfile GetLoginUser(string name, string password)
        {
            EF6.UserProfile result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.UserProfile.Where(x => x.LoginName == name && x.LoginPassword == password).AsNoTracking().FirstOrDefault();
                result = item;
            }

            return result;
        }
    }
}