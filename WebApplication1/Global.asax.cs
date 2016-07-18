using Elmah;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

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