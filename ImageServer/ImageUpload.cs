//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImageUpload
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageTags { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<bool> ismoderated { get; set; }
        public Nullable<bool> isapproved { get; set; }
    }
}
