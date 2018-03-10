using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Ninject.Modules;
using Cinema.WEB.Utils;
using Ninject;
using Cinema.Domain.Utils;

namespace Cinema.WEB
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // inject dependencies         
            NinjectModule registrations = new NinjectRegistrations();
            NinjectModule serviceModule = new ServiceModule("CotsContext");
            var kernel = new StandardKernel(registrations, serviceModule);
            var ninjectResolver = new Utils.NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(ninjectResolver);
        }
    }
}