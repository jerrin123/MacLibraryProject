//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MacLibraryProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Availables = new HashSet<Available>();
        }
    
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string item_disc { get; set; }
        public string item_pic { get; set; }

        public HttpPostedFileBase ite_pic { get; set; }
        //public HttpPostedFileBase ite_pic { get; set; }

        public string item_author { get; set; }
        public int cat_fid { get; set; }
        public string item_branch { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Available> Availables { get; set; }
    }
}
