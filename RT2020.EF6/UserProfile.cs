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
    
    public partial class UserProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserProfile()
        {
            this.UserPreference = new HashSet<UserPreference>();
        }
    
        public System.Guid UserId { get; set; }
        public System.Guid UserSid { get; set; }
        public Nullable<int> UserType { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string Alias { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPreference> UserPreference { get; set; }
    }
}