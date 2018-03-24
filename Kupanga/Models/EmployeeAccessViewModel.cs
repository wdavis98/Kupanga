using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kupanga.Models.Repository;

namespace Kupanga.Models
{
    public class EmployeeAccessViewModel
    {
        public List<SubmittedQuote> SubmittedQuotes { get; set; }
        public List<Component> Components { get; set; }
        public List<Home> Homes { get; set; }

    }
}