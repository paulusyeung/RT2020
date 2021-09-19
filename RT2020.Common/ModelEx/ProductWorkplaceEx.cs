using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.Common.ModelEx
{
    public class ProductWorkplaceEx
    {
        public static EF6.ProductWorkplace Get(Guid productId, Guid workplaceId)
        {
            EF6.ProductWorkplace result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.ProductWorkplace.Where(x => x.ProductId == productId && x.WorkplaceId == workplaceId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }
    }
}