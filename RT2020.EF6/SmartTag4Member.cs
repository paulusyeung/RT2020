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
    
    public partial class SmartTag4Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SmartTag4Member()
        {
            this.MemberSmartTag = new HashSet<MemberSmartTag>();
            this.SmartTag4Member_Options = new HashSet<SmartTag4Member_Options>();
        }
    
        public System.Guid TagId { get; set; }
        public string TagCode { get; set; }
        public string TagName { get; set; }
        public string TagName_Chs { get; set; }
        public string TagName_Cht { get; set; }
        public int Priority { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberSmartTag> MemberSmartTag { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SmartTag4Member_Options> SmartTag4Member_Options { get; set; }
    }
}
