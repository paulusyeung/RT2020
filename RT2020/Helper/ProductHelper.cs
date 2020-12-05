using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.Helper
{
    public class ProductHelper
    {
        /// <summary>
        /// Product Onhand Qty 全部 Workplace
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static decimal GetOnHandQtyByWorkplaceId(Guid productId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.ProductWorkplace
                    .Where(x => x.ProductId == productId)
                    .AsNoTracking()
                    .ToList();
                foreach (var item in list)
                {
                    result += item.CDQTY;
                }
            }
            return result;
        }

        /// <summary>
        /// Product Onhand Qty 指定 Workplace
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="workplaceId"></param>
        /// <returns></returns>
        public static decimal GetOnHandQtyByWorkplaceId(Guid productId, Guid workplaceId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.ProductWorkplace
                    .Where(x => x.ProductId == productId && x.WorkplaceId == workplaceId)
                    .AsNoTracking()
                    .ToList();
                foreach (var item in list)
                {
                    result += item.CDQTY;
                }
            }
            return result;
        }

        /// <summary>
        /// Product Onhand Qty 指定 Workplace List
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="workplaceId"></param>
        /// <returns></returns>
        public static decimal GetOnHandQtyByWorkplaceId(Guid productId, Guid[] workplaceId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var idList = String.Join(",", workplaceId.Select(x => "'" + x + "'"));
                var list = ctx.ProductWorkplace
                    .Where(x => x.ProductId == productId && idList.Contains(x.WorkplaceId.ToString()))
                    .AsNoTracking()
                    .ToList();
                foreach (var item in list)
                {
                    result += item.CDQTY;
                }
            }
            return result;
        }
    }
}