//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace workFlowApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_empoyee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_empoyee()
        {
            this.tbl_entity = new HashSet<tbl_entity>();
        }
    
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public int emp_role { get; set; }
        public int status { get; set; }
        public string nic { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public System.DateTime created_date { get; set; }
    
        public virtual tbl_role tbl_role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_entity> tbl_entity { get; set; }
    }
}
