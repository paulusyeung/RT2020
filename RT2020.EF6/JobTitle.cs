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
    
    public partial class JobTitle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobTitle()
        {
            this.JobTitle1 = new HashSet<JobTitle>();
            this.Member = new HashSet<Member>();
            this.SupplierContact = new HashSet<SupplierContact>();
        }
    
        public System.Guid JobTitleId { get; set; }
        public Nullable<System.Guid> ParentJobTitle { get; set; }
        public string JobTitleCode { get; set; }
        public string JobTitleName { get; set; }
        public string JobTitleName_Chs { get; set; }
        public string JobTitleName_Cht { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobTitle> JobTitle1 { get; set; }
        public virtual JobTitle JobTitle2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierContact> SupplierContact { get; set; }
    }
}
