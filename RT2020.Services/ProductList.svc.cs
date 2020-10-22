using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Common;
using System.Configuration;
using RT2020.DAL;
using System.Data.SqlClient;
using RT2020.Services.Contracts;

namespace RT2020.Services
{
    // NOTE: If you change the class name "ProductList" here, you must also update the reference to "ProductList" in Web.config and in the associated .svc file.
    public class ProductList : IProductList
    {
        string sql = @"SELECT [ProductId],[STKCODE],[APPENDIX1],[APPENDIX2],[APPENDIX3],[ProductName],[RetailPrice] FROM [dbo].[vwProductList]";

        #region IProductList Members

        /// <summary>
        /// Gets all product.
        /// </summary>
        /// <returns></returns>
        public RT2020.Services.Model.ProductList[] GetProductList()
        {
            return GetProductList(sql);
        }

        /// <summary>
        /// Gets the product list by where clause.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductList[] GetProductListByWhereClause(string whereClause)
        {
            if (whereClause.Length > 0)
            {
                if (whereClause.Contains("WHERE"))
                {
                    sql += whereClause;
                }
                else
                {
                    sql += " WHERE " + whereClause;
                }
            }

            return GetProductList(sql);
        }

        /// <summary>
        /// Gets the product list by stock code.
        /// </summary>
        /// <param name="stkCode">The STK code.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductList[] GetProductListByStockCode(string stkCode)
        {
            sql += @" WHERE [STKCODE] = '" + stkCode + @"'";

            return GetProductList(sql);
        }

        /// <summary>
        /// Gets the product with product id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductList GetProductWithProductId(string productId)
        {
            sql += @" WHERE [ProductId] = '" + productId + "'";

            return GetProduct(sql);
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="stkCode">The STK code.</param>
        /// <param name="appendix1">The appendix1.</param>
        /// <param name="appendix2">The appendix2.</param>
        /// <param name="appendix3">The appendix3.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductList GetProduct(string stkCode, string appendix1, string appendix2, string appendix3)
        {
            sql += @" WHERE [STKCODE] = '" + stkCode + @"' AND 
                                  [APPENDIX1] = '" + appendix1 + @"' AND 
                                  [APPENDIX2] = '" + appendix2 + @"' AND 
                                  [APPENDIX3] = '" + appendix3 + @"'";

            return GetProduct(sql);
        }

        /// <summary>
        /// Gets the frist product.
        /// </summary>
        /// <returns></returns>
        public RT2020.Services.Model.ProductList GetFirstProduct()
        {
            sql = "SELECT TOP 1 * FROM (" + sql + ") lst ";
            sql += @" ORDER BY [STKCODE], [APPENDIX1], [APPENDIX2], [APPENDIX3]";

            return GetProduct(sql);
        }

        /// <summary>
        /// Gets the last product.
        /// </summary>
        /// <returns></returns>
        public RT2020.Services.Model.ProductList GetLastProduct()
        {
            sql = "SELECT TOP 1 * FROM (" + sql + ") lst ";
            sql += @" ORDER BY [STKCODE] DESC, [APPENDIX1], [APPENDIX2], [APPENDIX3]";

            return GetProduct(sql);
        }

        #endregion

        /// <summary>
        /// Builds the product.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        private static Model.ProductList[] BuildProductList(DbCommand cmd)
        {
            using (DbDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                List<Model.ProductList> productList = new List<Model.ProductList>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.ProductList product = new Model.ProductList();
                        product.ProductId = reader["ProductId"].ToString();
                        product.STKCODE = reader["STKCODE"].ToString();
                        product.APPENDIX1 = reader["APPENDIX1"].ToString();
                        product.APPENDIX2 = reader["APPENDIX2"].ToString();
                        product.APPENDIX3 = reader["APPENDIX3"].ToString();
                        product.ProductName = reader["ProductName"].ToString();
                        product.RetailPrice = Convert.ToDouble(reader["RetailPrice"].ToString());
                        productList.Add(product);
                    }
                    if (productList.Count > 0)
                    {
                        return productList.ToArray();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the product list.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.ProductList[] GetProductList(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeoutValue"]);
            cmd.CommandType = System.Data.CommandType.Text;

            Model.ProductList[] productList = BuildProductList(cmd);
            if (productList != null && productList.Length > 0)
            {
                return productList;
            }
            else
            {
                return new Model.ProductList[] { };
            }
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.ProductList GetProduct(string sqlQuery)
        {
            Model.ProductList[] productList = GetProductList(sqlQuery);
            if (productList.Length > 0)
            {
                return productList[0];
            }

            return null;
        }
    }
}
