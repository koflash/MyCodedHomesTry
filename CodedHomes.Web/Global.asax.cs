using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Elmah;

namespace CodedHomes.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            CustomGlobalConfig.Customize(GlobalConfiguration.Configuration);
        }

        private void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            if (e.Exception is System.Threading.ThreadAbortException)
            {
                e.Dismiss();
            }
        }
    }
}