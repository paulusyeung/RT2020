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
    
    public partial class MemberVipData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberVipData()
        {
            this.MemberVipLineOfOperations = new HashSet<MemberVipLineOfOperation>();
            this.MemberVipSupplements = new HashSet<MemberVipSupplement>();
            this.MemberVipSupplements1 = new HashSet<MemberVipSupplement>();
        }
    
        public System.Guid MemberVipId { get; set; }
        public System.Guid MemberId { get; set; }
        public string VipNumber { get; set; }
        public Nullable<System.DateTime> CARD_ISSUE { get; set; }
        public Nullable<System.DateTime> CARD_EXPIRE { get; set; }
        public string CARD_NAME { get; set; }
        public bool CARD_RECEIVE { get; set; }
        public bool CARD_ACTIVE { get; set; }
        public string FORMER_PPNO { get; set; }
        public Nullable<System.DateTime> MigrationDate { get; set; }
        public Nullable<System.DateTime> CommencementDate { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public Nullable<decimal> CreditTerms { get; set; }
        public Nullable<decimal> PaymentDiscount { get; set; }
        public Nullable<bool> AddOnDiscount { get; set; }
        public Nullable<decimal> StaffQuota { get; set; }
        public string MetadataXml { get; set; }
    
        public virtual Member Member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberVipLineOfOperation> MemberVipLineOfOperations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberVipSupplement> MemberVipSupplements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberVipSupplement> MemberVipSupplements1 { get; set; }
    }
}
