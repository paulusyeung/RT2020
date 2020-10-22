using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FileHelpers;

namespace RT2020.Inventory.GoodsReceive.Import
{

    [DelimitedRecord("|")]
    public class XlsImportTemplate
    {
        public string STOCKCODE;

      public string APPENDIX1;

      public string APPENDIX2;

      public string APPENDIX3;

      [FieldNullValue(0.0)]
      [FieldConverter(ConverterKind.Double)]
      public double COST;

      [FieldNullValue(0)]
      [FieldConverter(ConverterKind.Int32)]
      public int QTY;

      [FieldOptional()]
      public string CLASS1;

      [FieldOptional()]
      public string CLASS2;

      [FieldOptional()]
      public string CLASS3;

      [FieldOptional()]
      public string CLASS4;

      [FieldOptional()]
      public string CLASS5;

      [FieldOptional()]
      public string CLASS6;

      [FieldOptional()]
      public string PRODUCT_NAME;

      [FieldOptional()]
      public string REMARKS;

      [FieldOptional()]
      public string REMARK1;

      [FieldOptional()]
      public string REMARK2;

      [FieldOptional()]
      public string REMARK3;

      [FieldOptional()]
      public string REMARK4;

      [FieldOptional()]
      public string REMARK5;

      [FieldOptional()]
      public string REMARK6;

      [FieldOptional()]
      [FieldNullValue(0.0)]
      [FieldConverter(ConverterKind.Double)]
      public double? RETAIL_PRICE;

      [FieldOptional()]
      [FieldNullValue(0.0)]
      [FieldConverter(ConverterKind.Double)]
      public double? RETAIL_DISCOUNT;

      [FieldOptional()]
      [FieldNullValue(0.0)]
      [FieldConverter(ConverterKind.Double)]
      public double? DISCOUNT_FOR_DISCOUNT_ITEM;
    }
}
