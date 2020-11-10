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
    
    public partial class PriceManagementReason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PriceManagementReason()
        {
            this.PriceManagementActiveHeaders = new HashSet<PriceManagementActiveHeader>();
            this.PriceManagementBatchHeaders = new HashSet<PriceManagementBatchHeader>();
        }
    
        public System.Guid ReasonId { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonName { get; set; }
        public string ReasonName_Chs { get; set; }
        public string ReasonName_Cht { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceManagementActiveHeader> PriceManagementActiveHeaders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceManagementBatchHeader> PriceManagementBatchHeaders { get; set; }
    }
}
