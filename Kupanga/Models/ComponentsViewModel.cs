using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kupanga.Models.Repository;

namespace Kupanga.Models
{
    public class ComponentsViewModel
    {
        public List<Component> components { get; set; }

        public ComponentsViewModel()
        {
            components = new List<Component>();
        }
    }
}