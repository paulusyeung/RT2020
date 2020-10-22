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
    // NOTE: If you change the class name "Appendices" here, you must also update the reference to "Appendices" in Web.config and in the associated .svc file.
    public class Appendices : IAppendices
    {
        #region IAppendices Members

        public ProductAppendix1[] GetAllAppendix1()
        {
            return ProductAppendix1.LoadCollection().ToArray<ProductAppendix1>();
        }

        public ProductAppendix1 GetAppendix1ById(string appendix1Id)
        {
            string query = "Appendix1Id = '" + appendix1Id + "'";
            return ProductAppendix1.LoadWhere(query);
        }

        public ProductAppendix1 GetAppendix1ByCode(string appendix1Code)
        {
            string query = "Appendix1Code = '" + appendix1Code + "'";
            return ProductAppendix1.LoadWhere(query);
        }

        public ProductAppendix2[] GetAllAppendix2()
        {
            return ProductAppendix2.LoadCollection().ToArray<ProductAppendix2>();
        }

        public ProductAppendix2 GetAppendix2ById(string appendix2Id)
        {
            string query = "Appendix2Id = '" + appendix2Id + "'";
            return ProductAppendix2.LoadWhere(query);
        }

        public ProductAppendix2 GetAppendix2ByCode(string appendix2Code)
        {
            string query = "Appendix2Code = '" + appendix2Code + "'";
            return ProductAppendix2.LoadWhere(query);
        }

        public ProductAppendix3[] GetAllAppendix3()
        {
            return ProductAppendix3.LoadCollection().ToArray<ProductAppendix3>();
        }

        public ProductAppendix3 GetAppendix3ById(string appendix3Id)
        {
            string query = "Appendix3Id = '" + appendix3Id + "'";
            return ProductAppendix3.LoadWhere(query);
        }

        public ProductAppendix3 GetAppendix3ByCode(string appendix3Code)
        {
            string query = "Appendix3Code = '" + appendix3Code + "'";
            return ProductAppendix3.LoadWhere(query);
        }

        public ProductAppendix1[] GetAppendix1ListByWhereClause(string whereClause)
        {
            return ProductAppendix1.LoadCollection(whereClause).ToArray<ProductAppendix1>();
        }

        public ProductAppendix2[] GetAppendix2ListByWhereClause(string whereClause)
        {
            return ProductAppendix2.LoadCollection(whereClause).ToArray<ProductAppendix2>();
        }

        public ProductAppendix3[] GetAppendix3ListByWhereClause(string whereClause)
        {
            return ProductAppendix3.LoadCollection(whereClause).ToArray<ProductAppendix3>();
        }

        #endregion
    }
}
