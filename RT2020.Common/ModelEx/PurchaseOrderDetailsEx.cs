using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.Common.ModelEx
{
    public class PurchaseOrderDetailsEx
    {
        public static decimal GetTotalOrderQty(Guid headerId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PurchaseOrderDetails.Where(x => x.OrderHeaderId == headerId).AsNoTracking().ToList();
                foreach( var item in list)
                {
                    result += item.OrderedQty;
                }
            }

            return result;
        }

        public static decimal GetTotalAmount(Guid headerId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PurchaseOrderDetails.Where(x => x.OrderHeaderId == headerId).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    decimal disc = (100 - item.DiscountPcn) / 100;
                    result += item.OrderedQty * item.UnitCost * disc;
                }
            }

            return result;
        }
    }
}