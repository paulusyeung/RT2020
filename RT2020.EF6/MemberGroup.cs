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
    
    public partial class MemberGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberGroup()
        {
            this.Member = new HashSet<Member>();
            this.MemberGroup1 = new HashSet<MemberGroup>();
        }
    
        public System.Guid GroupId { get; set; }
        public Nullable<System.Guid> ParentGroup { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string GroupName_Chs { get; set; }
        public string GroupName_Cht { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberGroup> MemberGroup1 { get; set; }
        public virtual MemberGroup MemberGroup2 { get; set; }
    }
}