using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "ITransactionList" here, you must also update the reference to "ITransactionList" in Web.config.
    [ServiceContract]
    public interface ITransactionList
    {
        [OperationContract]
        Model.TransactionList[] GetTransactionList();

        [OperationContract]
        Model.TransactionList GetFirstTransaction(string txType, bool posted);

        [OperationContract]
        Model.TransactionList GetLastTransaction(string txType, bool posted);

        [OperationContract]
        Model.TransactionList[] GetTransactionListByWhereClause(string whereClause);
    }
}
