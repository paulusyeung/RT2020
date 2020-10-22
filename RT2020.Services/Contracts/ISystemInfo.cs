using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "ISystemInfo" here, you must also update the reference to "ISystemInfo" in Web.config.
    [ServiceContract]
    public interface ISystemInfo
    {
        [OperationContract]
        Model.SystemInfo GetSystemInfo();

        [OperationContract]
        Model.SystemInfo GetSystemInfoById(string infoId);

        [OperationContract]
        Model.SystemInfo GetSystemInfoByCode(string shopNumber);

        [OperationContract]
        Model.SystemInfo GetSystemInfoByWhereClause(string whereClause);
    }
}
