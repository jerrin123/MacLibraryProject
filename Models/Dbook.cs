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

    public partial class Dbook
    {
        public int Ebooks_Id { get; set; }
        public string Ebook_Name { get; set; }
        public string Ebook_Decription { get; set; }
        public string Ebook_Pdf { get; set; }

        public HttpPostedFileBase Ebk_file { get; set; }
        public string Ebook_Author { get; set; }
    }
}
