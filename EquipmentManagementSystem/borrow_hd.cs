//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquipmentManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class borrow_hd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public borrow_hd()
        {
            this.borrow_dt = new HashSet<borrow_dt>();
        }
    
        public string bor_id { get; set; }
        public string mem_id { get; set; }
        public string admin_id { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
    
        public virtual admin admin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<borrow_dt> borrow_dt { get; set; }
        public virtual mMember mMember { get; set; }
    }
}
