using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "ISystemLabels" here, you must also update the reference to "ISystemLabels" in Web.config.
    [ServiceContract]
    public interface ISystemLabels
    {
        [OperationContract]
        Model.SystemLabels GetSystemLabels();

        [OperationContract]
        Model.SystemLabels GetSystemLabelsByLanguage(string languageCode);

        [OperationContract]
        Model.SystemLabels GetSystemLabelsByWhereClause(string whereClause);
    }
}
