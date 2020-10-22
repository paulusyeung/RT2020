using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RT2020.Services.Contracts
{
    // NOTE: If you change the interface name "IProductBarcode" here, you must also update the reference to "IProductBarcode" in Web.config.
    [ServiceContract]
    public interface IProductBarcode
    {
        [OperationContract]
        Model.ProductBarcode[] GetAllBarcode();

        [OperationContract]
        Model.ProductBarcode GetBarcodeWithProductId(string productId);

        [OperationContract]
        Model.ProductBarcode[] GetBarcodeListByStockCode(string stkCode);

        [OperationContract]
        Model.ProductBarcode[] GetBarcodeListByBarcode(string barcode);

        [OperationContract]
        Model.ProductBarcode[] GetBarcodeListByWhereClause(string whereClause);

        [OperationContract]
        Model.ProductBarcode GetBarcode(string stkCode, string appendix1, string appendix2, string appendix3);
    }
}
