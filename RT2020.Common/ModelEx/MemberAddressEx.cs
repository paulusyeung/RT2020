using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Common.ModelEx
{
    public class MemberAddressEx
    {
        public static bool Delete(Guid memberId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var list = ctx.MemberAddress.Where(x => x.MemberId == memberId).ToList();
                        if (list.Count > 0)
                        {
                            foreach (var item in list)
                            {
                                ctx.MemberAddress.Remove(item);
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