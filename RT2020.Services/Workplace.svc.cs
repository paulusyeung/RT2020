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
    // NOTE: If you change the class name "Workplace" here, you must also update the reference to "Workplace" in Web.config and in the associated .svc file.
    public class Workplace : IWorkplace
    {
        #region IWorkplace Members

        public RT2020.DAL.Workplace[] GetAllWorkplace()
        {
            return RT2020.DAL.Workplace.LoadCollection().ToArray<RT2020.DAL.Workplace>();
        }

        public RT2020.DAL.Workplace GetWorkplaceById(string workplaceId)
        {
            string query = "WorkplaceId = '" + workplaceId + "'";
            return RT2020.DAL.Workplace.LoadWhere(query);
        }

        public RT2020.DAL.Workplace GetWorkplaceByCode(string workplaceCode)
        {
            string query = "WorkplaceCode = '" + workplaceCode + "'";
            return RT2020.DAL.Workplace.LoadWhere(query);
        }

        public RT2020.DAL.Workplace[] GetWorkplaceByWhereClause(string whereClause)
        {
            return RT2020.DAL.Workplace.LoadCollection(whereClause).ToArray<RT2020.DAL.Workplace>();
        }

        #endregion
    }
}
