using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentityV2.Utilities
{
    /// <summary>
    /// Class to create custom html extensions
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// Custom HTML extension
        /// </summary>
        /// <param name="html"></param>
        /// <param name="control"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string IsActive(this HtmlHelper html,
                                  string control,
                                  string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = control == routeControl &&
                               action == routeAction;

            return returnActive ? "active-tab" : "";
        }
    }
}