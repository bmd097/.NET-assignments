using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using WebApplication.Controllers;
using WebApplication.Utils;

namespace WebApplication.Factories {
    public class CustomControllerFactory : IControllerFactory {
        public IController CreateController(RequestContext requestContext, string controllerName) {

            if (controllerName.Equals("Home")) {
                return new HomeController();
            } else if (controllerName.Equals("Magic")) {
                return new MagicController();
            } else if (controllerName.Equals("Unity")) {
                return new UnityController(
                    (Countries)DependencyContainer.GetInstance().GetService(typeof(Countries)),
                    (Cities)DependencyContainer.GetInstance().GetService(typeof(Cities))
                );
            }

            throw new HttpException(404, "Controller not found");
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName) {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller) {
            IDisposable disposableController = controller as IDisposable;
            disposableController?.Dispose();
        }
    }
}