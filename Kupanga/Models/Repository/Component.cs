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
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(ComponentValidation))]
    public partial class Component
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Component()
        {
            this.QuoteComponents = new HashSet<QuoteComponent>();
            this.SubmittedQuotes = new HashSet<SubmittedQuote>();
            this.SubmittedQuotes1 = new HashSet<SubmittedQuote>();
            this.SubmittedQuotes2 = new HashSet<SubmittedQuote>();
            this.SubmittedQuotes3 = new HashSet<SubmittedQuote>();
        }
    
        public int ComponentId { get; set; }
        public int CategoryId { get; set; }
        public string ComponentName { get; set; }
        public decimal ComponentPrice { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuoteComponent> QuoteComponents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmittedQuote> SubmittedQuotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmittedQuote> SubmittedQuotes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmittedQuote> SubmittedQuotes2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmittedQuote> SubmittedQuotes3 { get; set; }
    }
}
