using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WeatherApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            string lang = null;

            // Check if a language is specified in the query string
            if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
            {
                lang = Request.QueryString["lang"];
            }
            // Otherwise, check if a language preference is stored in a cookie
            else if (Request.Cookies["language"] != null)
            {
                lang = Request.Cookies["language"].Value;
            }

            // If a language was found, set the culture
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
        }



    }
}
