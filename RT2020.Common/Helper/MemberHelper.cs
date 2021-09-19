using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Common.Helper
{
    public class MemberHelper
    {
        /// <summary>
        /// Gets the class id.
        /// </summary>
        /// <param name="classCode">The class code.</param>
        /// <returns></returns>
        public static Guid GetClassId(string classCode)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                string query = "ClassCode = '" + classCode + "'";
                var item = ctx.MemberClass.Where(x => x.ClassCode == classCode).FirstOrDefault();
                if (item == null)
                {
                    item = new EF6.MemberClass();
                    item.ClassId = System.Guid.NewGuid();
                    item.ClassCode = classCode;
                    item.ClassName = classCode;
                    item.ClassName_Chs = classCode;
                    item.ClassName_Cht = classCode;

                    ctx.MemberClass.Add(item);
                    ctx.SaveChanges();
                }
                return item.ClassId;
            }

            return result;
        }

        /// <summary>
        /// Gets the group id.
        /// </summary>
        /// <param name="groupCode">The group code.</param>
        /// <returns></returns>
        public static Guid GetGroupId(string groupCode)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                string query = "GroupCode = '" + groupCode + "'";
                var item = ctx.MemberGroup.Where(x => x.GroupCode == groupCode).FirstOrDefault();
                if (item == null)
                {
                    item = new EF6.MemberGroup();
                    item.GroupId = Guid.NewGuid();
                    item.GroupCode = groupCode;
                    item.GroupName = groupCode;
                    item.GroupName_Chs = groupCode;
                    item.GroupName_Cht = groupCode;

                    ctx.MemberGroup.Add(item);
                    ctx.SaveChanges();
                }
                result = item.GroupId;
            }

            return result;
        }

        /// <summary>
        /// Gets the salute id.
        /// </summary>
        /// <param name="saluteCode">The salute code.</param>
        /// <returns></returns>
        public static Guid GetSaluteId(string saluteCode)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var objSalutationList = ctx.Salutation.Where(x => x.SalutationCode == saluteCode).FirstOrDefault();
                if (objSalutationList == null)
                {
                    var item = new EF6.Salutation();

                    item.SalutationId = Guid.NewGuid();
                    item.SalutationCode = saluteCode;
                    item.SalutationName = saluteCode;
                    item.SalutationName_Chs = saluteCode;
                    item.SalutationName_Cht = saluteCode;

                    ctx.Salutation.Add(item);
                    ctx.SaveChanges();

                    result = item.SalutationId;
                }
                else
                {
                    result = objSalutationList.SalutationId;
                }
            }

            return result;
        }
    }
}