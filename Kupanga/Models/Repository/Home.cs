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
    
    public partial class Home
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Home()
        {
            this.HomeImages = new HashSet<HomeImage>();
            this.SubmittedQuotes = new HashSet<SubmittedQuote>();
        }
    
        public int HomeId { get; set; }
        public string HomeName { get; set; }
        public string HomeDescription { get; set; }
        public decimal BasePrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HomeImage> HomeImages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmittedQuote> SubmittedQuotes { get; set; }
    }
}