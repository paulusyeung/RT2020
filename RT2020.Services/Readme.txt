Generate Schema Code:
"C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\svcutil.exe" /dconly /n:http://SynergyIS.biz/ProductBarcode.xsd,Model /Out:D:\ProductBarcode.cs D:\Projects\RT2020\RT2020.Services\Schemas\ProductBarcode.xsd

Generate Data Proxy:
"C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\svcutil.exe" /Out:D:\ProductBarcodeProxy.cs Http://localhost/Services/ProductBarcode.svc?wsdl