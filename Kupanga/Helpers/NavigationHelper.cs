using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kupanga.Models.Repository;

namespace Kupanga.Helpers
{
    public class NavigationHelper
    {
        /// <summary>
        /// This method validates the current quote and returns the appropriate action name;
        /// </summary>
        /// <param name="currentAction"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        static public string ValidateSessionQuote(string currentAction, object quote)
        {
            SubmittedQuote currentQuote;
            try
            {
                currentQuote = (SubmittedQuote)quote;
            }
            catch (Exception ex)
            {
                return "OneStory";
            }
            if (currentQuote == null)
            {
                return "OneStory";
            }
            if (currentQuote.HomeId == 0)
            {
                return "OneStory";
            }
            if (currentQuote.DoorId == null)
            {
                return "Doors";
            }
            if (currentQuote.WindowId == null)
            {
                return "Windows";
            }
            if (currentQuote.RoofId == null)
            {
                return "Roof";
            }
            if (currentQuote.FloorId == null)
            {
                return "Flooring";
            }
            return currentAction;
        }   
    }
}