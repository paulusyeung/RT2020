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
    // NOTE: If you change the class name "Staff" here, you must also update the reference to "Staff" in Web.config and in the associated .svc file.
    public class Staff : IStaff
    {
        #region IStaff Members

        public RT2020.DAL.Staff[] GetAllStaff()
        {
            return RT2020.DAL.Staff.LoadCollection().ToArray<RT2020.DAL.Staff>();
        }

        public RT2020.DAL.Staff GetStaffById(string staffId)
        {
            string query = "StaffId = '" + staffId + "'";
            return RT2020.DAL.Staff.LoadWhere(query);
        }

        public RT2020.DAL.Staff GetStaffByCode(string staffNumber)
        {
            string query = "StaffNumber = '" + staffNumber + "'";
            return RT2020.DAL.Staff.LoadWhere(query);
        }

        public Guid IsAuth(string staffNumber, string password)
        {
            string query = "StaffNumber = '" + staffNumber.Trim().Replace("'", "") + "' AND Password = '" + password.Trim().Replace("'", "") + "'";

            RT2020.DAL.Staff objStaff = RT2020.DAL.Staff.LoadWhere(query);
            if (objStaff != null)
            {
                return objStaff.StaffId;
            }
            else
            {
                return Guid.Empty;
            }
        }

        public RT2020.DAL.Staff[] GetStaffByWhereClause(string whereClause)
        {
            return RT2020.DAL.Staff.LoadCollection(whereClause).ToArray<RT2020.DAL.Staff>();
        }

        #endregion
    }
}
