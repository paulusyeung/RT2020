using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "ITransactionDetailList" here, you must also update the reference to "ITransactionDetailList" in Web.config.
    [ServiceContract]
    public interface ITransactionDetailList
    {
        [OperationContract]
        Model.TransactionDetailList[] GetTransactionDetailList();

        [OperationContract]
        Model.TransactionDetailList[] GetTransactionDetailListByWhereClause(string whereClause);
    }
}
