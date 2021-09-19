using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RT2020.Common.ModelEx
{
    public class ProductBarcodeEx
    {
        public static string GetBarcodeByProductId(Guid productId)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sqlWhere = "ProductId = '" + productId.ToString() + "' AND PrimaryBarcode = 1";
                var item = ctx.ProductBarcode.Where(x => x.ProductId == productId && x.PrimaryBarcode).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    result = item.Barcode;
                }
            }

            return result;
        }

        public static Guid GetProductIdByBarcode(string barcode)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sqlWhere = "ProductId = '" + productId.ToString() + "' AND PrimaryBarcode = 1";
                var item = ctx.ProductBarcode.Where(x => x.Barcode == barcode).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    result = item.ProductId;
                }
            }

            return result;
        }

        public static bool IsBarcodeInUse(string barcode)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductBarcode.Where(x => x.Barcode == barcode).AsNoTracking().FirstOrDefault();
                if (item != null) result = true;
            }

            return result;
        }

        public static bool IsBarcodeInUse(Guid productId, string barcode)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductBarcode.Where(x => x.ProductId == productId && x.Barcode == barcode).AsNoTracking().FirstOrDefault();
                if (item != null) result = true;
            }

            return result;
        }
    }
}