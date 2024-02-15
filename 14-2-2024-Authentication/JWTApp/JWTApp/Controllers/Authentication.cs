using JWTApp.context;
using JWTApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;

namespace JWTApp.Controllers {
    public class AuthenticationController : ApiController {

        public AuthenticationController() {
            JWTUtils.secretKey = ConfigurationManager.AppSettings["SecretKey"];
        }
        AuthDbContext authDbContext = new AuthDbContext();
       

        // POST api/<controller>
        public Dictionary<string,object> Post([FromBody] AuthModel model) {
            var enumerator = this.Request.Headers.GetCookies().GetEnumerator();
            List<CookieHeaderValue> list = new List<CookieHeaderValue>();
            var authModel = authDbContext.authModel.Find(1);
            while (enumerator.MoveNext()) {
                var cookie = enumerator.Current;
                var state = cookie.Cookies.FirstOrDefault(e => e.Name == "authJwtCookie");
                if (state != null) {
                    Dictionary<string,string> keyValuePairs = new Dictionary<string, string>();
                    if (JWTUtils.VerifyToken(state.Value,out keyValuePairs)) {
                        if(authModel != null) {
                            if(authModel.email == keyValuePairs["email"]) {
                                if(authModel.password == keyValuePairs["password"]) {
                                    return new Dictionary<string, object>
                                    {
                                        { "success", true},
                                        { "fromJwt",true },
                                        { "data",authModel }
                                    };
                                }
                            }
                        }
                    }
                }
            }
            if(model.email == authModel.email) {
                if(model.password == authModel.password) {
                    HttpCookie myCookie = new HttpCookie("authJwtCookie");
                    myCookie.Value = JWTUtils.GetToken(new Dictionary<string, string> {
                        { "email",model.email },
                        { "password",model.password }
                    });
                    myCookie.Expires = DateTime.Now.AddDays(2d);
                    myCookie.HttpOnly = true;
                    HttpContext.Current.Response.Cookies.Add(myCookie);
                    return new Dictionary<string, object>
                    {
                        { "success", true}
                    };
                } else {
                    return new Dictionary<string, object>
                    {
                        { "success", false}
                    };
                }
            } else {
                return new Dictionary<string, object>
                {
                    { "success", false}
                };
            }
        }
    }
}