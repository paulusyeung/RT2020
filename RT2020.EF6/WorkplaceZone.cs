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
    
    public partial class WorkplaceZone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkplaceZone()
        {
            this.SystemInfo = new HashSet<SystemInfo>();
            this.Workplace = new HashSet<Workplace>();
            this.WorkplaceZone1 = new HashSet<WorkplaceZone>();
        }
    
        public System.Guid ZoneId { get; set; }
        public Nullable<System.Guid> ParentZone { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneInitial { get; set; }
        public string ZoneName { get; set; }
        public string ZoneName_Chs { get; set; }
        public string ZoneName_Cht { get; set; }
        public string Notes { get; set; }
        public string CurrencyCode { get; set; }
        public bool PromaryZone { get; set; }
        public string MetadataXml { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemInfo> SystemInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workplace> Workplace { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkplaceZone> WorkplaceZone1 { get; set; }
        public virtual WorkplaceZone WorkplaceZone2 { get; set; }
    }
}
