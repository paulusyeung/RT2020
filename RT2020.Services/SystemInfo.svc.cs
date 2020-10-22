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
    // NOTE: If you change the class name "SystemInfo" here, you must also update the reference to "SystemInfo" in Web.config and in the associated .svc file.
    public class SystemInfo : ISystemInfo
    {
        #region ISystemInfo Members

        public RT2020.Services.Model.SystemInfo GetSystemInfo()
        {
            string sql = @"SELECT TOP 1 [InfoId],[ShopNumber],[CompanyName],[LastMonthEnd],[BasicCurrency],[BarcodeLabelFormat]
                            FROM [dbo].[SystemInfo]";

            return GetSystemInfo(sql);
        }

        public RT2020.Services.Model.SystemInfo GetSystemInfoById(string infoId)
        {
            string sql = @"SELECT TOP 1 [InfoId],[ShopNumber],[CompanyName],[LastMonthEnd],[BasicCurrency],[BarcodeLabelFormat]
                            FROM [dbo].[SystemInfo]
                            WHERE [InfoId] = '" + infoId + "'";

            return GetSystemInfo(sql);
        }

        public RT2020.Services.Model.SystemInfo GetSystemInfoByCode(string shopNumber)
        {
            string sql = @"SELECT TOP 1 [InfoId],[ShopNumber],[CompanyName],[LastMonthEnd],[BasicCurrency],[BarcodeLabelFormat]
                            FROM [dbo].[SystemInfo]
                            WHERE [ShopNumber] = '" + shopNumber + "'";

            return GetSystemInfo(sql);
        }

        public RT2020.Services.Model.SystemInfo GetSystemInfoByWhereClause(string whereClause)
        {
            string sql = @"SELECT TOP 1 [InfoId],[ShopNumber],[CompanyName],[LastMonthEnd],[BasicCurrency],[BarcodeLabelFormat]
                            FROM [dbo].[SystemInfo]";

            if (whereClause.Length > 0)
            {
                if (whereClause.Contains("WHERE"))
                {
                    sql += whereClause;
                }
                else
                {
                    sql += "WHERE " + whereClause;
                }
            }

            return GetSystemInfo(sql);
        }

        #endregion

        /// <summary>
        /// Builds the system info.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        private static Model.SystemInfo[] BuildSystemInfo(DbCommand cmd)
        {
            using (DbDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                List<Model.SystemInfo> infos = new List<Model.SystemInfo>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.SystemInfo info = new Model.SystemInfo();
                        info.SystemInfoId = reader["InfoId"].ToString();
                        info.ShopNumber = reader["ShopNumber"].ToString();
                        info.CompanyName = reader["CompanyName"].ToString();
                        info.BasicCurrency = reader["BasicCurrency"].ToString();
                        info.LastMonthEnd = Convert.ToInt32(reader["LastMonthEnd"].ToString());
                        infos.Add(info);
                    }
                    if (infos.Count > 0)
                    {
                        return infos.ToArray();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the system list.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.SystemInfo[] GetSystemInfoList(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeoutValue"]);
            cmd.CommandType = System.Data.CommandType.Text;

            Model.SystemInfo[] infos = BuildSystemInfo(cmd);
            if (infos != null && infos.Length > 0)
            {
                return infos;
            }
            else
            {
                return new Model.SystemInfo[] { };
            }
        }

        /// <summary>
        /// Gets the system info.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.SystemInfo GetSystemInfo(string sqlQuery)
        {
            Model.SystemInfo[] infoList = GetSystemInfoList(sqlQuery);
            if (infoList.Length > 0)
            {
                return infoList[0];
            }

            return null;
        }
    }
}
