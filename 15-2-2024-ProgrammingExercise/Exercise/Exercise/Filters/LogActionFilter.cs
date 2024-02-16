using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise.Filters {
    public class LogActionFilter : IActionFilter {

        public void OnActionExecuting(ActionExecutingContext filterContext) {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string logMessage = $"Executing action {actionName} in controller {controllerName}";
            Console.WriteLine($"{DateTime.Now} :: " + logMessage);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            // Code to be executed after the action method
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string logMessage = $"Finished executing action {actionName} in controller {controllerName}";
            Console.WriteLine($"{DateTime.Now} :: " + logMessage);
        }

    }
}