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
    
    public partial class SmartTag4Supplier_Options
    {
        public System.Guid OptionId { get; set; }
        public Nullable<System.Guid> TagId { get; set; }
        public string OptionCode { get; set; }
        public string OptionName { get; set; }
        public string OptionName_Alt1 { get; set; }
        public string OptionName_Alt2 { get; set; }
    
        public virtual SmartTag4Supplier SmartTag4Supplier { get; set; }
    }
}
