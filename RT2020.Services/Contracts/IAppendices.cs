using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RT2020.DAL;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "IAppendices" here, you must also update the reference to "IAppendices" in Web.config.
    [ServiceContract]
    public interface IAppendices
    {
        [OperationContract]
        ProductAppendix1[] GetAllAppendix1();

        [OperationContract]
        ProductAppendix1 GetAppendix1ById(string appendix1Id);

        [OperationContract]
        ProductAppendix1 GetAppendix1ByCode(string appendix1Code);

        [OperationContract]
        ProductAppendix1[] GetAppendix1ListByWhereClause(string whereClause);

        [OperationContract]
        ProductAppendix2[] GetAllAppendix2();

        [OperationContract]
        ProductAppendix2 GetAppendix2ById(string appendix2Id);

        [OperationContract]
        ProductAppendix2 GetAppendix2ByCode(string appendix2Code);

        [OperationContract]
        ProductAppendix2[] GetAppendix2ListByWhereClause(string whereClause);

        [OperationContract]
        ProductAppendix3[] GetAllAppendix3();

        [OperationContract]
        ProductAppendix3 GetAppendix3ById(string appendix3Id);

        [OperationContract]
        ProductAppendix3 GetAppendix3ByCode(string appendix3Code);

        [OperationContract]
        ProductAppendix3[] GetAppendix3ListByWhereClause(string whereClause);
    }
}
