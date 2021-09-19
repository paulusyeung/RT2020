using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Common.ModelEx
{
    public class InvtBatchTXF_DetailsEx
    {
        public static int CountByTxNumber(string txNumber)
        {
            int result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.InvtBatchTXF_Details.Where(x => x.TxNumber == txNumber).Count();
            }

            return result;
        }

        public static decimal GetTotalQtyRequested(Guid headerId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == headerId).Sum(x => x.QtyRequested.Value);
            }

            return result;
        }

        public static decimal GetTotalAmount(Guid headerId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == headerId).Sum(x => x.QtyRequested.Value);
            }

            return result;
        }
    }
}