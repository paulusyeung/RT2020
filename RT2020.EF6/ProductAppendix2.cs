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
    
    public partial class ProductAppendix2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductAppendix2()
        {
            this.ProductAppendix21 = new HashSet<ProductAppendix2>();
            this.ProductCodes = new HashSet<ProductCode>();
        }
    
        public System.Guid Appendix2Id { get; set; }
        public Nullable<System.Guid> ParentAppendix { get; set; }
        public string Appendix2Code { get; set; }
        public string Appendix2Initial { get; set; }
        public string Appendix2Name { get; set; }
        public string Appendix2Name_Chs { get; set; }
        public string Appendix2Name_Cht { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public System.Guid ModifiedBy { get; set; }
        public bool Retired { get; set; }
        public Nullable<System.DateTime> RetiredOn { get; set; }
        public Nullable<System.Guid> RetiredBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAppendix2> ProductAppendix21 { get; set; }
        public virtual ProductAppendix2 ProductAppendix22 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCode> ProductCodes { get; set; }
    }
}
