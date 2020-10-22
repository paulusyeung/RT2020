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
    // NOTE: If you change the class name "ProductBarcode" here, you must also update the reference to "ProductBarcode" in Web.config and in the associated .svc file.
    public class ProductBarcode : IProductBarcode
    {
        string sql = @"SELECT  [ProductId],[STKCODE],[APPENDIX1],[App1Desc],[APPENDIX2],[App2Desc],[APPENDIX3],[App3Desc],[StockMemo],[StockRemark1],
                                   [CLASS1], [C1Desc],[CLASS2], [C2Desc],[CLASS3], [C3Desc],[CLASS4], [C4Desc],[CLASS5], [C5Desc],[CLASS6], [C6Desc],
                                   [Barcode],[BarcodeType],[ProductName],[ProductName_Chs],[ProductName_Cht],[PrimaryBarcode],[RetailPrice],[CurrencyCode],[Remarks]
                            FROM [dbo].[vwProductBarcodeList]";

        #region IProductBarcode Members

        /// <summary>
        /// Gets all barcode.
        /// </summary>
        /// <returns></returns>
        public RT2020.Services.Model.ProductBarcode[] GetAllBarcode()
        {
            return GetBarcodeList(sql);
        }

        /// <summary>
        /// Gets the barcode list by where clause.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductBarcode[] GetBarcodeListByWhereClause(string whereClause)
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

            return GetBarcodeList(sql);
        }

        /// <summary>
        /// Gets the barcode list by stock code.
        /// </summary>
        /// <param name="stkCode">The STK code.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductBarcode[] GetBarcodeListByStockCode(string stkCode)
        {
            sql += @" WHERE [STKCODE] = '" + stkCode + @"'";

            return GetBarcodeList(sql);
        }

        /// <summary>
        /// Gets the barcode list by barcode.
        /// </summary>
        /// <param name="barcode">The barcode.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductBarcode[] GetBarcodeListByBarcode(string barcode)
        {
            sql += @" WHERE [Barcode] = '" + barcode + @"'";

            return GetBarcodeList(sql);
        }

        /// <summary>
        /// Gets the barcode with product id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductBarcode GetBarcodeWithProductId(string productId)
        {
            sql += @" WHERE [ProductId] = '" + productId + "'";

            return GetBarcode(sql);
        }

        /// <summary>
        /// Gets the barcode.
        /// </summary>
        /// <param name="stkCode">The STK code.</param>
        /// <param name="appendix1">The appendix1.</param>
        /// <param name="appendix2">The appendix2.</param>
        /// <param name="appendix3">The appendix3.</param>
        /// <returns></returns>
        public RT2020.Services.Model.ProductBarcode GetBarcode(string stkCode, string appendix1, string appendix2, string appendix3)
        {
            sql += @" WHERE [STKCODE] = '" + stkCode + @"' AND 
                                  [APPENDIX1] = '" + appendix1 + @"' AND 
                                  [APPENDIX2] = '" + appendix2 + @"' AND 
                                  [APPENDIX3] = '" + appendix3 + @"'";

            return GetBarcode(sql);
        }
        #endregion

        /// <summary>
        /// Builds the barcode.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        private static Model.ProductBarcode[] BuildBarcode(DbCommand cmd)
        {
            using (DbDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                List<Model.ProductBarcode> barcodes = new List<Model.ProductBarcode>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.ProductBarcode barcode = new Model.ProductBarcode();
                        barcode.ProductId = reader["ProductId"].ToString();
                        barcode.STKCODE = reader["STKCODE"].ToString();
                        barcode.APPENDIX1 = reader["APPENDIX1"].ToString();
                        barcode.App1Desc = reader["App1Desc"].ToString();
                        barcode.APPENDIX2 = reader["APPENDIX2"].ToString();
                        barcode.App2Desc = reader["App2Desc"].ToString();
                        barcode.APPENDIX3 = reader["APPENDIX3"].ToString();
                        barcode.App3Desc = reader["App3Desc"].ToString();
                        barcode.CLASS1 = reader["CLASS1"].ToString();
                        barcode.C1Desc = reader["C1Desc"].ToString();
                        barcode.CLASS2 = reader["CLASS2"].ToString();
                        barcode.C2Desc = reader["C2Desc"].ToString();
                        barcode.CLASS3 = reader["CLASS3"].ToString();
                        barcode.C3Desc = reader["C3Desc"].ToString();
                        barcode.CLASS4 = reader["CLASS4"].ToString();
                        barcode.C4Desc = reader["C4Desc"].ToString();
                        barcode.CLASS5 = reader["CLASS5"].ToString();
                        barcode.C5Desc = reader["C5Desc"].ToString();
                        barcode.CLASS6 = reader["CLASS6"].ToString();
                        barcode.C6Desc = reader["C6Desc"].ToString();
                        barcode.Barcode = reader["Barcode"].ToString();
                        barcode.BarcodeType = reader["BarcodeType"].ToString();
                        barcode.ProductName = reader["ProductName"].ToString();
                        barcode.ProductName_Chs = reader["ProductName_Chs"].ToString();
                        barcode.ProductName_Cht = reader["ProductName_Cht"].ToString();
                        barcode.PrimaryBarcode = (reader["PrimaryBarcode"].ToString() == "1");
                        barcode.RetailPrice = Convert.ToDouble(reader["RetailPrice"].ToString());
                        barcode.CurrencyCode = reader["CurrencyCode"].ToString();
                        barcode.StockMemo = reader["StockMemo"].ToString();
                        barcode.StockRemark1 = reader["StockRemark1"].ToString();
                        barcode.Remarks = reader["Remarks"].ToString();
                        barcodes.Add(barcode);
                    }
                    if (barcodes.Count > 0)
                    {
                        return barcodes.ToArray();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the barcode list.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.ProductBarcode[] GetBarcodeList(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeoutValue"]);
            cmd.CommandType = System.Data.CommandType.Text;

            Model.ProductBarcode[] barcodes = BuildBarcode(cmd);
            if (barcodes != null && barcodes.Length > 0)
            {
                return barcodes;
            }
            else
            {
                return new Model.ProductBarcode[] { };
            }
        }

        /// <summary>
        /// Gets the barcode.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.ProductBarcode GetBarcode(string sqlQuery)
        {
            Model.ProductBarcode[] barcodeList = GetBarcodeList(sqlQuery);
            if (barcodeList.Length > 0)
            {
                return barcodeList[0];
            }

            return null;
        }
    }
}
