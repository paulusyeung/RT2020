using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.Common.ModelEx
{
    public class StaffSecurityEx
    {
        public static EF6.StaffSecurity GetById(Guid id)
        {
            EF6.StaffSecurity result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var ss = ctx.StaffSecurity.Where(x => x.SecurityId == id).AsNoTracking().FirstOrDefault();
                if (ss != null) result = ss;
            }

            return result;
        }

        public static EF6.StaffSecurity GetByStaffId(Guid id)
        {
            EF6.StaffSecurity result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var ss = ctx.StaffSecurity.Where(x => x.StaffId == id).AsNoTracking().FirstOrDefault();
                if (ss != null) result = ss;
            }

            return result;
        }

        public static EF6.StaffSecurity GetByStaffId(Guid id, string grade)
        {
            EF6.StaffSecurity result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var ss = ctx.StaffSecurity.Where(x => x.StaffId == id && x.GradeCode == grade).AsNoTracking().FirstOrDefault();
                if (ss != null) result = ss;
            }

            return result;
        }
    }
}