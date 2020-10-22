using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RT2020.DAL;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "IStaff" here, you must also update the reference to "IStaff" in Web.config.
    [ServiceContract]
    public interface IStaff
    {
        [OperationContract]
        RT2020.DAL.Staff[] GetAllStaff();

        [OperationContract]
        RT2020.DAL.Staff GetStaffById(string staffId);

        [OperationContract]
        RT2020.DAL.Staff GetStaffByCode(string staffNumber);

        [OperationContract]
        RT2020.DAL.Staff[] GetStaffByWhereClause(string whereClause);

        [OperationContract]
        Guid IsAuth(string staffNumber, string password);
    }
}
