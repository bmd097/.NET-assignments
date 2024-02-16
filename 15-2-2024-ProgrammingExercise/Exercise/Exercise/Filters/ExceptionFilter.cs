using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise.Filters {
    public class ExceptionArticleFilter : ActionFilterAttribute, IExceptionFilter {
        public void OnException(ExceptionContext filterContext) {
            Console.WriteLine(filterContext.Exception);
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.ContentType = "application/json";
            filterContext.HttpContext.Response.Write("{ \"error\" : \"filter\" }");
            filterContext.HttpContext.Response.Flush();
        }
    }
}