using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticlesViewer.Filters {
    public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter {
        private static readonly ILog log = LogManager.GetLogger(typeof(ExceptionFilterAttribute));

        public void OnException(ExceptionContext filterContext) {
            filterContext.ExceptionHandled = true;
            log.Error(filterContext.Exception);
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}