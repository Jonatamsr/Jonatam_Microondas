using JonatamMicroondas.UI.Web.App_Start;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JonatamMicroondas.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ProgramaAquecimentoSetup.Init();
        }
    }
}
