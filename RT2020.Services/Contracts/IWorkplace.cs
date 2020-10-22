using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RT2020.DAL;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "IWorkplace" here, you must also update the reference to "IWorkplace" in Web.config.
    [ServiceContract]
    public interface IWorkplace
    {
        [OperationContract]
        RT2020.DAL.Workplace[] GetAllWorkplace();

        [OperationContract]
        RT2020.DAL.Workplace GetWorkplaceById(string staffId);

        [OperationContract]
        RT2020.DAL.Workplace GetWorkplaceByCode(string staffNumber);

        [OperationContract]
        RT2020.DAL.Workplace[] GetWorkplaceByWhereClause(string whereClause);
    }
}
