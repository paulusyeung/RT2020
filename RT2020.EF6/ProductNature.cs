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
    
    public partial class ProductNature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductNature()
        {
            this.Product = new HashSet<Product>();
            this.ProductNature1 = new HashSet<ProductNature>();
        }
    
        public System.Guid NatureId { get; set; }
        public Nullable<System.Guid> ParentNature { get; set; }
        public string NatureCode { get; set; }
        public string NatureName { get; set; }
        public string NatureName_Chs { get; set; }
        public string NatureName_Cht { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductNature> ProductNature1 { get; set; }
        public virtual ProductNature ProductNature2 { get; set; }
    }
}
