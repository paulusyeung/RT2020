using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class ProductCurrentSummaryEx
    {
        public static decimal GetAverageCode(Guid productId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).AsNoTracking().FirstOrDefault();
                if (item != null) result = item.AverageCost;
            }

            return result;
        }

        public static EF6.ProductCurrentSummary GetByProductCode(Guid productId)
        {
            EF6.ProductCurrentSummary result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }
    }
}