using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class StaffAddressEx
    {
        public static bool Delete(Guid staffId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var list = ctx.StaffAddress.Where(x => x.StaffId == staffId).ToList();
                        if (list.Count > 0)
                        {
                            foreach (var item in list)
                            {
                                ctx.StaffAddress.Remove(item);
                            }
                            ctx.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }

                return result;
        }
    }
}