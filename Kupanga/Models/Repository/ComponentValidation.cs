using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kupanga.Models.Repository
{
    public class ComponentValidation
    {
        
        public int CategoryId { get; set; }
        [Required]
        public string ComponentName { get; set; }
        public decimal ComponentPrice { get; set; }
    }
}