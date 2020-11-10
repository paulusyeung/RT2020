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
    
    public partial class StaffGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffGroup()
        {
            this.Staffs = new HashSet<Staff>();
            this.StaffGroup1 = new HashSet<StaffGroup>();
        }
    
        public System.Guid GroupId { get; set; }
        public Nullable<System.Guid> ParentGrade { get; set; }
        public string GradeCode { get; set; }
        public string GradeName { get; set; }
        public string GradeName_Chs { get; set; }
        public string GradeName_Cht { get; set; }
        public Nullable<bool> CanRead { get; set; }
        public Nullable<bool> CanWrite { get; set; }
        public Nullable<bool> CanDelete { get; set; }
        public Nullable<bool> CanPost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffGroup> StaffGroup1 { get; set; }
        public virtual StaffGroup StaffGroup2 { get; set; }
    }
}
