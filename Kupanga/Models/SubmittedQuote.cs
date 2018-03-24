using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kupanga.Models.Repository
{
    [MetadataType(typeof(SubmittedQuoteMetaData))]
    public partial class SubmittedQuote
    {
    }

    public class SubmittedQuoteMetaData
    {
        [DisplayFormat(NullDisplayText = "*Not Handled*")]
        public string HandledBy { get; set; }
    }
}