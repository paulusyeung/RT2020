//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RT2020.EF6
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductBatch
    {
        public System.Guid BatchId { get; set; }
        public string STKCODE { get; set; }
        public string APP1_COMBIN { get; set; }
        public string APP2_COMBIN { get; set; }
        public string APP3_COMBIN { get; set; }
        public string CLASS1 { get; set; }
        public string CLASS2 { get; set; }
        public string CLASS3 { get; set; }
        public string CLASS4 { get; set; }
        public string CLASS5 { get; set; }
        public string CLASS6 { get; set; }
        public string Description { get; set; }
        public string MAINUNIT { get; set; }
        public string ALTITEM { get; set; }
        public string REMARKS { get; set; }
        public Nullable<decimal> MARKUP { get; set; }
        public Nullable<decimal> BASPRC { get; set; }
        public Nullable<decimal> WHLPRC { get; set; }
        public string VCURR { get; set; }
        public Nullable<decimal> VPRC { get; set; }
        public Nullable<decimal> NRDISC { get; set; }
        public Nullable<decimal> REORDLVL { get; set; }
        public Nullable<decimal> REORDQTY { get; set; }
        public bool SERIALFLAG { get; set; }
        public string NATURE { get; set; }
        public string REMARK1 { get; set; }
        public string REMARK2 { get; set; }
        public string REMARK3 { get; set; }
        public string REMARK4 { get; set; }
        public string REMARK5 { get; set; }
        public string REMARK6 { get; set; }
        public string PHOTO { get; set; }
        public string STK_MEMO { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> DATEPOST { get; set; }
        public Nullable<System.DateTime> DATECREATE { get; set; }
        public Nullable<System.DateTime> DATELCHG { get; set; }
        public string USERLCHG { get; set; }
        public string RETAILITEM { get; set; }
        public string BINX { get; set; }
        public string BINY { get; set; }
        public string BINZ { get; set; }
        public string DESC_MEMO { get; set; }
        public string DESC_POLE { get; set; }
        public string OFF_DISPLAY_ITEM { get; set; }
        public string COUNTER_ITEM { get; set; }
        public Nullable<decimal> ORIPRC { get; set; }
    }
}