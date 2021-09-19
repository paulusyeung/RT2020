using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.Common.ModelEx
{
    public class SystemLabelEx
    {
        public static EF6.SystemLabel GetByLanguageCode(string code)
        {
            EF6.SystemLabel result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SystemLabel.Where(x => x.LanguageCode == code).AsNoTracking().FirstOrDefault();
                if (item != null) result = item;
            }

            return result;
        }
    }
}