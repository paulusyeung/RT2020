﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using Gizmox.WebGUI.Forms;

using RT2020.Common.Helper;

namespace RT2020.Common.ModelEx
{
    /// <summary>
    /// This extension provides access to the EF6 entity dbo.InvtBatchADJ_Details.
    /// Date Created:   2020-12-18 03:17:22
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v2020.12.12.cst
    /// </summary>
    public class InvtBatchADJ_DetailsEx
    {
        public static decimal GetTotalQty(Guid headerId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.InvtBatchADJ_Details.Where(x => x.HeaderId == headerId).Sum(x => x.Qty.Value);
            }

            return result;
        }

        public static decimal GetTotalAmount(Guid headerId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.InvtBatchADJ_Details.Where(x => x.HeaderId == headerId);
                foreach (var item in list)
                {
                    result = item.Qty.Value * ProductEx.GetRetailPrice(item.ProductId);
                }
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.InvtBatchADJ_Details object from the database using the given DetailsId
        /// </summary>
        /// <param name="detailsId">The primary key value</param>
        /// <returns>A EF6.InvtBatchADJ_Details object</returns>
        public static EF6.InvtBatchADJ_Details Get(Guid detailsId)
        {
            EF6.InvtBatchADJ_Details result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.InvtBatchADJ_Details.Where(x => x.DetailsId == detailsId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.InvtBatchADJ_Details object from the database using the given QueryString
        /// </summary>
        /// <param name="detailsId">The primary key value</param>
        /// <returns>A EF6.InvtBatchADJ_Details object</returns>
        public static EF6.InvtBatchADJ_Details Get(string whereClause)
        {
            EF6.InvtBatchADJ_Details result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.InvtBatchADJ_Details
                    .SqlQuery(string.Format("Select * from InvtBatchADJ_Details Where {0}", whereClause))
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a list of InvtBatchADJ_Details objects from the database
        /// </summary>
        /// <returns>A list containing all of the InvtBatchADJ_Details objects in the database.</returns>
        public static List<EF6.InvtBatchADJ_Details> GetList()
        {
            var whereClause = "1 = 1";
            return GetList(whereClause);
        }

        /// <summary>
        /// Get a list of InvtBatchADJ_Details objects from the database
        /// ordered by primary key
        /// </summary>
        /// <returns>A list containing all of the InvtBatchADJ_Details objects in the database ordered by the columns specified.</returns>
        public static List<EF6.InvtBatchADJ_Details> GetList(string whereClause)
        {
            var orderBy = new string[] { "DetailsId" };
            return GetList(whereClause, orderBy);
        }

        /// <summary>
        /// Get a list of InvtBatchADJ_Details objects from the database.
        /// ordered accordingly, example { "FieldName1", "FieldName2 DESC" }
        /// </summary>
        /// <returns>A list containing all of the InvtBatchADJ_Details objects in the database.</returns>
        public static List<EF6.InvtBatchADJ_Details> GetList(string whereClause, string[] orderBy)
        {
            List<EF6.InvtBatchADJ_Details> result = new List<EF6.InvtBatchADJ_Details>();

            var orderby = String.Join(",", orderBy.Select(x => x));

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.InvtBatchADJ_Details
                    .SqlQuery(string.Format("Select * from InvtBatchADJ_Details Where {0} Order By {1}", whereClause, orderby))
                    .AsNoTracking()
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Deletes a EF6.InvtBatchADJ_Details object from the database.
        /// </summary>
        /// <param name="detailsId">The primary key value</param>
        public static bool Delete(Guid detailsId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.InvtBatchADJ_Details.Find(detailsId);
                if (item != null)
                {
                    ctx.InvtBatchADJ_Details.Remove(item);
                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
    }
}
