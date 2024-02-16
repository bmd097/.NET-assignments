using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise.Filters {

    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class AddHeaderResultFilter : ActionFilterAttribute,IResultFilter {
        public override void OnResultExecuted(ResultExecutedContext filterContext) {
            filterContext.HttpContext.Response.Headers.Add("X-Custom-Header", "This is a custom header");
        }
    }
}