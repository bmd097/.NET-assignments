using ArticlesViewer.Controllers;
using ArticlesViewer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace ArticlesViewer.Filters {
    public class JwtAuthorizationFilter : FilterAttribute,IAuthorizationFilter {
        public void OnAuthorization(AuthorizationContext filterContext) {
            var request = filterContext.HttpContext.Request;
            var token = request.Cookies["jwtToken"]?.Value;
            if (string.IsNullOrEmpty(token)) {
                filterContext.Result = new RedirectResult("/Auth");
                return;
            }
            Dictionary<string, string> dictionary;
            if (JwtUtils.VerifyToken(token,out dictionary)) {
                if (dictionary.ContainsKey("email") && dictionary.ContainsKey("password")) {
                    if (AuthController.map.ContainsKey(dictionary["email"]) && AuthController.map[dictionary["email"]] == dictionary["password"]) {
                        return;
                    } else {
                        filterContext.Result = new RedirectResult("/Auth");
                        return;
                    }
                } else {
                    filterContext.Result = new RedirectResult("/Auth");
                    return;
                }
            } else {
                filterContext.Result = new RedirectResult("/Auth");
                return;
            }
        }
    }
}