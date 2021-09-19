using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.Common.Helper
{
    public static class ProductHelper
    {
        public static bool IsDuplicated(string STKCODE, string APPENDIX1, string APPENDIX2, string APPENDIX3)
        {
            bool result = true;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Product.Where(x => x.STKCODE == STKCODE && x.APPENDIX1 == APPENDIX1 && x.APPENDIX2 == APPENDIX2 && x.APPENDIX3 == APPENDIX3).AsNoTracking().FirstOrDefault();
                if (item != null) result = true;
            }

            return result;
        }

        public static bool IsServiceItem(Guid productId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oProd = ctx.Product.Find(productId);
                if (oProd != null)
                {
                    var oNature = ctx.ProductNature.Find(oProd.NatureId);
                    if (oNature != null)
                    {
                        result = (oNature.NatureCode == "S");
                    }
                }
            }

            return result; ;
        }

        /// <summary>
        /// Product Onhand Qty 全部 Workplace
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static decimal GetOnHandQtyByWorkplaceId(Guid productId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.ProductWorkplace
                    .Where(x => x.ProductId == productId)
                    .AsNoTracking()
                    .ToList();
                foreach (var item in list)
                {
                    result += item.CDQTY;
                }
            }
            return result;
        }

        /// <summary>
        /// Product Onhand Qty 指定 Workplace
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="workplaceId"></param>
        /// <returns></returns>
        public static decimal GetOnHandQtyByWorkplaceId(Guid productId, Guid workplaceId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.ProductWorkplace
                    .Where(x => x.ProductId == productId && x.WorkplaceId == workplaceId)
                    .AsNoTracking()
                    .ToList();
                foreach (var item in list)
                {
                    result += item.CDQTY;
                }
            }
            return result;
        }

        /// <summary>
        /// Product Onhand Qty 指定 Workplace List
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="workplaceId"></param>
        /// <returns></returns>
        public static decimal GetOnHandQtyByWorkplaceId(Guid productId, Guid[] workplaceId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var idList = String.Join(",", workplaceId.Select(x => "'" + x + "'"));
                var list = ctx.ProductWorkplace
                    .Where(x => x.ProductId == productId && idList.Contains(x.WorkplaceId.ToString()))
                    .AsNoTracking()
                    .ToList();
                foreach (var item in list)
                {
                    result += item.CDQTY;
                }
            }
            return result;
        }

        public static decimal GetVipDiscount(Guid productId, string discType)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                
                string query = " ProductId = '" + productId.ToString() + "'";
                var oSupplement = ctx.ProductSupplement.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oSupplement != null)
                {
                    switch (discType.ToLower().Trim())
                    {
                        case "fixeditem":
                            result = oSupplement.VipDiscount_FixedItem;
                            break;
                        case "discitem":
                            result = oSupplement.VipDiscount_DiscountItem;
                            break;
                        case "nodiscitem":
                            result = oSupplement.VipDiscount_NoDiscountItem;
                            break;
                        case "staffdisc":
                            result = oSupplement.StaffDiscount;
                            break;
                    }
                }
            }

            return result;
        }

        public enum Appendix
        {
            None,
            Appendix1,
            Appendix2,
            Appendix3
        }

        public enum Classes
        {
            None,
            Class1,
            Class2,
            Class3,
            Class4,
            Class5,
            Class6
        }

        public enum Prices
        {
            /// <summary>
            /// Original Retail Price
            /// </summary>
            ORIPRC,
            /// <summary>
            /// Retail Price /Basic Price
            /// </summary>
            BASPRC,
            /// <summary>
            /// WholeSale Price
            /// </summary>
            WHLPRC,
            /// <summary>
            /// Vendor Price
            /// </summary>
            VPRC
        }
    }
}