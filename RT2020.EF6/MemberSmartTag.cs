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
    
    public partial class MemberSmartTag
    {
        public System.Guid SmartTagId { get; set; }
        public string SmartTagValue { get; set; }
        public System.Guid MemberId { get; set; }
        public System.Guid TagId { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual SmartTag4Member SmartTag4Member { get; set; }
    }
}