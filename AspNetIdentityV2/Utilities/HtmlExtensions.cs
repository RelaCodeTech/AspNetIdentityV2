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

        public static string MakeActiveMainMenu(this HtmlHelper html,
                  string menuName,
                  string suppliedMenuName)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = menuName == suppliedMenuName;

            //return returnActive ? "active" : "";
            return returnActive ? "active-nav" : ""; //for customized active tab
        }


        /// <summary>
        /// not in usage
        /// </summary>
        /// <param name="html"></param>
        /// <param name="menuName"></param>
        /// <param name="suppliedMenuName"></param>
        /// <returns></returns>
        public static string MakeActiveSubMenu(this HtmlHelper html,
                  string menuName,
                  string suppliedMenuName)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = menuName == suppliedMenuName;

            return returnActive ? "active-pill" : "";
        }

        /// <summary>
        /// not in usage
        /// </summary>
        /// <param name="html"></param>
        /// <param name="menuName"></param>
        /// <param name="suppliedMenuName"></param>
        /// <returns></returns>
        public static string MakeActiveMenu(this HtmlHelper html,
                  string menuName,
                  string suppliedMenuName)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = menuName == suppliedMenuName;

            return returnActive ? "active-tab" : "";
        }


    }
}