using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using MovieSite.Database;

namespace MovieSite
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            EndRequest += Application_EndRequest;
        }

        private void Application_EndRequest(
            object sender, 
            EventArgs e)
        {
            if (HttpContext.Current.Items.Contains("repo"))
            {
                var repo = HttpContext.Current.Items["repo"] as IRepository;
                repo?.Dispose();
            }
        }
    }
}
