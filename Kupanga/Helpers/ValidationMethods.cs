using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kupanga.Models;

namespace Kupanga.Helpers
{
    public class ValidationMethods
    {
        public bool HomeModelIsValid(Models.Repository.Home home)
        {
            decimal dummy;
            if (string.IsNullOrEmpty(home.HomeName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(home.HomeDescription))
            {
                return false;
            }
            if (string.IsNullOrEmpty(home.BasePrice.ToString()))
            {
                return false;
            }
            if (home.Image.Count() == 0)
            {
                return false;
            }
            if (home.Blueprint.Count() == 0)
            {
                return false;
            }
            return true;
        }
    }
}