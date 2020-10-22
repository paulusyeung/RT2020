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
    // NOTE: If you change the class name "TransactionList" here, you must also update the reference to "TransactionList" in Web.config and in the associated .svc file.
    public class TransactionList : ITransactionList
    {
        string sql = @"SELECT TxNumber, TxType, TxDate, WorkplaceCode FROM vwTransactionListForBarcode ";

        #region ITransactionList Members

        public RT2020.Services.Model.TransactionList[] GetTransactionList()
        {
            return GetTransactionList(sql);
        }

        public RT2020.Services.Model.TransactionList GetFirstTransaction(string txType, bool posted)
        {
            sql += " WHERE TxType = '" + txType + "' AND Posted = " + (posted ? "1" : "0");
            sql += " ORDER BY TxDate, TxNumber";

            return GetTransaction(sql);
        }

        public RT2020.Services.Model.TransactionList GetLastTransaction(string txType, bool posted)
        {
            sql += " WHERE TxType = '" + txType + "' AND Posted = " + (posted ? "1" : "0");
            sql += " ORDER BY TxDate DESC, TxNumber DESC";

            return GetTransaction(sql);
        }

        public RT2020.Services.Model.TransactionList[] GetTransactionListByWhereClause(string whereClause)
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

            return GetTransactionList(sql);
        }

        #endregion

        /// <summary>
        /// Builds the transaction list.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        private static Model.TransactionList[] BuildTransactionList(DbCommand cmd)
        {
            using (DbDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                List<Model.TransactionList> txList = new List<Model.TransactionList>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.TransactionList tx = new Model.TransactionList();
                        tx.TxNumber = reader.GetString(0);
                        tx.TxType = reader.GetString(1);
                        tx.TxDate = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                        tx.WorkplaceCode = reader.GetString(3);
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
        private static Model.TransactionList[] GetTransactionList(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeoutValue"]);
            cmd.CommandType = System.Data.CommandType.Text;

            Model.TransactionList[] txList = BuildTransactionList(cmd);
            if (txList != null && txList.Length > 0)
            {
                return txList;
            }
            else
            {
                return new Model.TransactionList[] { };
            }
        }

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.TransactionList GetTransaction(string sqlQuery)
        {
            Model.TransactionList[] txList = GetTransactionList(sqlQuery);
            if (txList.Length > 0)
            {
                return txList[0];
            }

            return null;
        }
    }
}
