using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kupanga.Models.Repository;

namespace Kupanga.Models
{
    public class HomesViewModel
    {
        public List<Home> Homes { get; set; }

        public HomesViewModel()
        {
            Homes = new List<Home>();
        }
    }
}