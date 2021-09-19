using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.Common.ModelEx
{
    public class ProductDim_DetailsEx
    {
        public static List<EF6.ProductDim_Details> GetListByDimensionId(Guid id)
        {
            List<EF6.ProductDim_Details> result = new List<EF6.ProductDim_Details>();

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.ProductDim_Details.Where(x => x.DimensionId == id).AsNoTracking().ToList();
            }

            return result;
        }

        public static bool DeleteByDimensionId(Guid id)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.ProductDim_Details.Where(x => x.DimensionId == id).AsNoTracking().ToList();

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        ctx.ProductDim_Details.Remove(item);
                    }
                    ctx.SaveChanges();
                }
            }

            return result;
        }
    }
}