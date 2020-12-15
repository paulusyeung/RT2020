using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class MemberSmartTagEx
    {
        public static EF6.MemberSmartTag Get(Guid memberId, Guid tagId)
        {
            EF6.MemberSmartTag result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).AsNoTracking().FirstOrDefault();
                if (item != null) result = item;
            }

            return result;
        }
    }
}