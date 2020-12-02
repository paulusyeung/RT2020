using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class StaffSmartTagEx
    {
        public static EF6.StaffSmartTag Get(Guid staffid, Guid tagId)
        {
            EF6.StaffSmartTag result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.StaffSmartTag.Where(x => x.StaffId == staffid && x.TagId == tagId).AsNoTracking().FirstOrDefault();
                if (item != null) result = item;
            }

            return result;
        }
    }
}