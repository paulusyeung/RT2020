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
    
    public partial class StaffDept
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffDept()
        {
            this.Staff = new HashSet<Staff>();
            this.StaffDept1 = new HashSet<StaffDept>();
        }
    
        public System.Guid DeptId { get; set; }
        public Nullable<System.Guid> ParentDept { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string DeptName_Chs { get; set; }
        public string DeptName_Cht { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffDept> StaffDept1 { get; set; }
        public virtual StaffDept StaffDept2 { get; set; }
    }
}
