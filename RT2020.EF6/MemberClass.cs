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
    
    public partial class MemberClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberClass()
        {
            this.Member = new HashSet<Member>();
            this.MemberClass1 = new HashSet<MemberClass>();
        }
    
        public System.Guid ClassId { get; set; }
        public Nullable<System.Guid> ParentClass { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public string ClassName_Chs { get; set; }
        public string ClassName_Cht { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberClass> MemberClass1 { get; set; }
        public virtual MemberClass MemberClass2 { get; set; }
    }
}