//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kupanga.Models.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class HomeImage
    {
        public int ImageId { get; set; }
        public int HomeId { get; set; }
        public string ImageURL { get; set; }
        public int ImageTypeId { get; set; }
    
        public virtual Home Home { get; set; }
        public virtual ImageType ImageType { get; set; }
    }
}
