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
    
    public partial class ProductClass2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductClass2()
        {
            this.ProductClass21 = new HashSet<ProductClass2>();
            this.ProductCode = new HashSet<ProductCode>();
        }
    
        public System.Guid Class2Id { get; set; }
        public Nullable<System.Guid> ParentClass { get; set; }
        public string Class2Code { get; set; }
        public string Class2Initial { get; set; }
        public string Class2Name { get; set; }
        public string Class2Name_Chs { get; set; }
        public string Class2Name_Cht { get; set; }
        public Nullable<System.Guid> AlternateClass { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public System.Guid ModifiedBy { get; set; }
        public bool Retired { get; set; }
        public Nullable<System.DateTime> RetiredOn { get; set; }
        public Nullable<System.Guid> RetiredBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductClass2> ProductClass21 { get; set; }
        public virtual ProductClass2 ProductClass22 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCode> ProductCode { get; set; }
    }
}
