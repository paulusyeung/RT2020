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
    // NOTE: If you change the class name "SystemLabels" here, you must also update the reference to "SystemLabels" in Web.config and in the associated .svc file.
    public class SystemLabels : ISystemLabels
    {
        #region ISystemLabels Members

        public RT2020.Services.Model.SystemLabels GetSystemLabels()
        {
            string sql = @"SELECT [LabelId],[LanguageCode],[STKCODE],[CLASS1],[CLASS2],[CLASS3],[CLASS4],[CLASS5],[CLASS6]
                                  ,[APPENDIX1],[APPENDIX2],[APPENDIX3],[REMARK1],[REMARK2],[REMARK3],[REMARK4],[REMARK5],[REMARK6]
                              FROM [dbo].[SystemLabel]";

            return GetSystemLabels(sql);
        }

        public RT2020.Services.Model.SystemLabels GetSystemLabelsByLanguage(string languageCode)
        {
            string sql = @"SELECT [LabelId],[LanguageCode],[STKCODE],[CLASS1],[CLASS2],[CLASS3],[CLASS4],[CLASS5],[CLASS6]
                                  ,[APPENDIX1],[APPENDIX2],[APPENDIX3],[REMARK1],[REMARK2],[REMARK3],[REMARK4],[REMARK5],[REMARK6]
                              FROM [dbo].[SystemLabel]
                            WHERE LanguageCode = '" + languageCode + "'";

            return GetSystemLabels(sql);
        }

        public RT2020.Services.Model.SystemLabels GetSystemLabelsByWhereClause(string whereClause)
        {
            string sql = @"SELECT [LabelId],[LanguageCode],[STKCODE],[CLASS1],[CLASS2],[CLASS3],[CLASS4],[CLASS5],[CLASS6]
                                  ,[APPENDIX1],[APPENDIX2],[APPENDIX3],[REMARK1],[REMARK2],[REMARK3],[REMARK4],[REMARK5],[REMARK6]
                              FROM [dbo].[SystemLabel]";

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

            return GetSystemLabels(sql);
        }

        #endregion

        /// <summary>
        /// Builds the system info.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        private static Model.SystemLabels[] BuildSystemLabels(DbCommand cmd)
        {
            using (DbDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                List<Model.SystemLabels> labels = new List<Model.SystemLabels>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.SystemLabels label = new Model.SystemLabels();
                        label.LabelId = reader["LabelId"].ToString();
                        label.LanguageCode = reader["LanguageCode"].ToString();
                        label.STKCODE = reader["STKCODE"].ToString();
                        label.APPENDIX1 = reader["APPENDIX1"].ToString();
                        label.APPENDIX2 = reader["APPENDIX2"].ToString();
                        label.APPENDIX3 = reader["APPENDIX3"].ToString();
                        label.CLASS1 = reader["CLASS1"].ToString();
                        label.CLASS2 = reader["CLASS2"].ToString();
                        label.CLASS3 = reader["CLASS3"].ToString();
                        label.CLASS4 = reader["CLASS4"].ToString();
                        label.CLASS5 = reader["CLASS5"].ToString();
                        label.CLASS6 = reader["CLASS6"].ToString();
                        label.REMARK1 = reader["REMARK1"].ToString();
                        label.REMARK2 = reader["REMARK2"].ToString();
                        label.REMARK3 = reader["REMARK3"].ToString();
                        label.REMARK4 = reader["REMARK4"].ToString();
                        label.REMARK5 = reader["REMARK5"].ToString();
                        label.REMARK6 = reader["REMARK6"].ToString();
                        labels.Add(label);
                    }
                    if (labels.Count > 0)
                    {
                        return labels.ToArray();
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
        private static Model.SystemLabels[] GetSystemLabelsList(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeoutValue"]);
            cmd.CommandType = System.Data.CommandType.Text;

            Model.SystemLabels[] labels = BuildSystemLabels(cmd);
            if (labels != null && labels.Length > 0)
            {
                return labels;
            }
            else
            {
                return new Model.SystemLabels[] { };
            }
        }

        /// <summary>
        /// Gets the system info.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        private static Model.SystemLabels GetSystemLabels(string sqlQuery)
        {
            Model.SystemLabels[] labelList = GetSystemLabelsList(sqlQuery);
            if (labelList.Length > 0)
            {
                return labelList[0];
            }

            return null;
        }
    }
}
