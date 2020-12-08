using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class ProductEx
    {
        public static EF6.Product Get(Guid id)
        {
            EF6.Product result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.Product.Where(x => x.ProductId == id).AsNoTracking().FirstOrDefault();
            }

            return result;
        }
    }
}