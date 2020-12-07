using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class ProductPriceEx
    {
        public static EF6.ProductPrice Get(Guid productId, Guid priceTypeId)
        {
            EF6.ProductPrice result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }
    }
}