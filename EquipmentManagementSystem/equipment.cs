//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace EquipmentManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class equipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public equipment()
        {
            this.borrow_dt = new HashSet<borrow_dt>();
        }
    
        public string equ_id { get; set; }
        [Display(Name ="�����ػ�ó�")]
        public string equ_name { get; set; }
        public string equ_cat_id { get; set; }
        public string equ_description { get; set; }
        public Nullable<int> equ_amount { get; set; }
        public string equ_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<borrow_dt> borrow_dt { get; set; }
        public virtual equ_category equ_category { get; set; }
    }
}