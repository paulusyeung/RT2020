using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class InvtBatchTXF_HeaderEx
    {
        public static bool Delete(Guid headerId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var header = ctx.InvtBatchTXF_Header.Find(headerId);
                if (header != null)
                {
                    var list = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == headerId);
                    foreach (var item in list)
                    {
                        ctx.InvtBatchTXF_Details.Remove(item);
                    }

                    ctx.InvtBatchTXF_Header.Remove(header);
                    ctx.SaveChanges();

                    result = true;
                }

            }

            return result;
        }
    }
}