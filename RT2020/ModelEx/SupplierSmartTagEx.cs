using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class SupplierSmartTagEx
    {
        public static EF6.SupplierSmartTag Get(Guid supplierid, Guid tagId)
        {
            EF6.SupplierSmartTag result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierid && x.TagId == tagId).AsNoTracking().FirstOrDefault();
                if (item != null) result = item;
            }

            return result;
        }

        public static bool Delete(Guid id)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierSmartTag.Find(id);
                if (item != null)
                {
                    ctx.SupplierSmartTag.Remove(item);
                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
    }
}