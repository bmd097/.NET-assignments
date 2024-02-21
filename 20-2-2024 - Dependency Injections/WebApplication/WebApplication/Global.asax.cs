using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using WebApplication.Factories;
using WebApplication.Utils;

namespace WebApplication {
    public class MvcApplication : System.Web.HttpApplication {

        private void LoadDependencies() {
            DependencyContainer.GetInstance().AddService(new SingletonDependency<Countries>());
            DependencyContainer.GetInstance().AddService(new TransientDependency<Cities>());
        }

        protected void Application_Start() {
            LoadDependencies();
            // UnComment Down line if wanna use custom Factory also comment in UnityMvcActivator
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
