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
    
    public partial class ProductCode
    {
        public System.Guid CodeId { get; set; }
        public System.Guid ProductId { get; set; }
        public Nullable<System.Guid> Appendix1Id { get; set; }
        public Nullable<System.Guid> Appendix2Id { get; set; }
        public Nullable<System.Guid> Appendix3Id { get; set; }
        public Nullable<System.Guid> Class1Id { get; set; }
        public Nullable<System.Guid> Class2Id { get; set; }
        public Nullable<System.Guid> Class3Id { get; set; }
        public Nullable<System.Guid> Class4Id { get; set; }
        public Nullable<System.Guid> Class5Id { get; set; }
        public Nullable<System.Guid> Class6Id { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ProductAppendix1 ProductAppendix1 { get; set; }
        public virtual ProductAppendix2 ProductAppendix2 { get; set; }
        public virtual ProductAppendix3 ProductAppendix3 { get; set; }
        public virtual ProductClass1 ProductClass1 { get; set; }
        public virtual ProductClass2 ProductClass2 { get; set; }
        public virtual ProductClass3 ProductClass3 { get; set; }
        public virtual ProductClass4 ProductClass4 { get; set; }
        public virtual ProductClass5 ProductClass5 { get; set; }
        public virtual ProductClass6 ProductClass6 { get; set; }
    }
}
