using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace ArticlesViewer.Filters {

    public class LogActionFilterAttribute : ActionFilterAttribute {
        private static readonly ILog log = LogManager.GetLogger(typeof(LogActionFilterAttribute));

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            log.Info($"Executing action: {filterContext.ActionDescriptor.ActionName}");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            log.Info($"Executed action: {filterContext.ActionDescriptor.ActionName}");
            base.OnActionExecuted(filterContext);
        }
    }
}