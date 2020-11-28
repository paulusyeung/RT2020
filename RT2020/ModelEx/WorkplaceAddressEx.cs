using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class WorkplaceAddressEx
    {
        public static bool DeleteTagByWorkplaceId(Guid id)
        {
            var result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var list = ctx.WorkplaceAddress.Where(x => x.WorkplaceId == id);
                        foreach (var item in list)
                        {
                            ctx.WorkplaceAddress.Remove(item);
                            ctx.SaveChanges();
                        }
                        ctx.SaveChanges();
                        scope.Commit();
                        result = true;
                    }
                    catch
                    {
                        scope.Rollback();
                    }
                }
            }

            return result;
        }
    }
}