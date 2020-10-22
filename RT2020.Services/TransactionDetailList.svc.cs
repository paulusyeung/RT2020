using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using RT2020.Services.Contracts;
using RT2020.DAL;

namespace RT2020.Services
{
    // NOTE: If you change the class name "TransactionDetailList" here, you must also update the reference to "TransactionDetailList" in Web.config and in the associated .svc file.
    public class TransactionDetailList : ITransactionDetailList
    {
        string sql = @"SELECT TxNumber, TxType, TxDate, ProductId, Qty, WorkplaceCode FROM vwTransactionDetailListForBarcode ";

        #region 2014.01.24 paulus: 由於要 sort by STKCODE + APPENDIX1 + APPENDIX2 + APPENDIX3，我增加這個 SQL Query
        String _BaseSQL = @"
SELECT TOP (100) PERCENT v.TxNumber, v.TxType, v.TxDate, v.ProductId, v.Qty,
      v.WorkplaceCode --, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3
FROM dbo.vwTransactionDetailListForBarcode AS v INNER JOIN
      dbo.Product AS p ON v.ProductId = p.ProductId
{0}
ORDER BY TxNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3
";
        #endregion

        #region ITransactionDetailList Members

        public RT2020.Services.Model.TransactionDetailList[] GetTransactionDetailList()
        {
            //2014.01.24 paulus: 由於要 sort by STKCODE + APPENDIX1 + APPENDIX2 + APPENDIX3，我在這裡改用 _BaseSQL
            //return GetTransactionDetailList(sql);
            return GetTransactionDetailList(String.Format(_BaseSQL, "WHERE (1 = 1)"));
        }

        public RT2020.Services.Model.TransactionDetailList[] GetTransactionDetailListByWhereClause(string whereClause)
        {
            //2014.01.24 paulus: 由於要 sort by STKCODE + APPENDIX1 + APPENDIX2 + APPENDIX3，我在這裡改用 result
            String result = String.Empty;

            if (whereClause.Length > 0)
            {
                if (whereClause.Contains("WHERE"))
                {
                    sql += whereClause;
                    result = String.Format(_BaseSQL, whereClause);
                }
                else
                {
                    sql += " WHERE " + whereClause;
                    result = String.Format(_BaseSQL, "WHERE " + whereClause);
                }
            }
            else
            {   //2014.01.24 paulus: 原本是沒有 else 這段的
                result = String.Format(_BaseSQL, "WHERE (1 = 1)");
            }

            //return GetTransactionDetailList(sql);
            return GetTransactionDetailList(result);
        }

        #endregion

        /// <summary>
        /// Builds the transaction list.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        private static Model.TransactionDetailList[] BuildTransactionDetailList(DbCommand cmd)
        {
            using (DbDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                List<Model.TransactionDetailList> txList = new List<Model.TransactionDetailList>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.TransactionDetailList tx = new Model.TransactionDetailList();

                        tx.TxNumber = reader.GetString(0);
                        tx.TxType = reader.GetString(1);
                        tx.TxDate = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                        tx.ProductId = reader.GetGuid(3).ToString();
                        tx.Qty = (double)reader.GetDecimal(4);
                        tx.Workplace = reader.GetString(5);

                        txList.Add(tx);
                    }
                    if (txList.Count > 0)
                    {
                        return txList.ToArray();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the transaction list.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.TransactionDetailList[] GetTransactionDetailList(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeoutValue"]);
            cmd.CommandType = System.Data.CommandType.Text;

            Model.TransactionDetailList[] txList = BuildTransactionDetailList(cmd);
            if (txList != null && txList.Length > 0)
            {
                return txList;
            }
            else
            {
                return new Model.TransactionDetailList[] { };
            }
        }

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.TransactionDetailList GetTransaction(string sqlQuery)
        {
            Model.TransactionDetailList[] txList = GetTransactionDetailList(sqlQuery);
            if (txList.Length > 0)
            {
                return txList[0];
            }

            return null;
        }
    }
}
