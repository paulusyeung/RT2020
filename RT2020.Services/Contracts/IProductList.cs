using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "IProductList" here, you must also update the reference to "IProductList" in Web.config.
    [ServiceContract]
    public interface IProductList
    {
        [OperationContract]
        Model.ProductList[] GetProductList();

        [OperationContract]
        Model.ProductList GetProductWithProductId(string productId);

        [OperationContract]
        Model.ProductList[] GetProductListByStockCode(string stkCode);

        [OperationContract]
        Model.ProductList[] GetProductListByWhereClause(string whereClause);

        [OperationContract]
        Model.ProductList GetProduct(string stkCode, string appendix1, string appendix2, string appendix3);

        [OperationContract]
        Model.ProductList GetFirstProduct();

        [OperationContract]
        Model.ProductList GetLastProduct();
    }
}
