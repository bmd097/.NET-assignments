using ArticlesViewer.Filters;
using ArticlesViewer.Models;
using ArticlesViewer.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticlesViewer.Controllers
{
    [LogActionFilterAttribute]
    [ExceptionFilterAttribute]
    public class AuthController : Controller
    {

        public AuthController() {
            JwtUtils.secretKey = ConfigurationManager.AppSettings["SecretKey"];
        }

        public static Dictionary<String, String> map = new Dictionary<string, string>();

        // GET: Auth
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }

        // POST: Auth/LogIn
        [HttpPost]
        public ActionResult LogIn(string email = null, string password = null, bool register = false)
        {
            try {
                if (register) {
                    map[email] = password;
                    TempData["Message"] = "Registration successful. Please log in.";
                    String token = JwtUtils.GetToken(new Dictionary<string, string> {
                        { "email",email},
                        { "password",password}
                    });
                    var cookie = new HttpCookie("jwtToken", token) {
                        HttpOnly = true
                    };
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "WordVoyager");
                } else {
                    if (map.ContainsKey(email)) {
                        if (map[email] == password) {
                            TempData["Message"] = "Registration successful. Please log in.";
                            String token = JwtUtils.GetToken(new Dictionary<string, string> {
                                { "email",email},
                                { "password",password}
                            });
                            var cookie = new HttpCookie("jwtToken", token) {
                                HttpOnly = true
                            };
                            Response.Cookies.Add(cookie);
                            return RedirectToAction("Index", "WordVoyager");
                        } else {
                            TempData["ErrorMessage"] = "Incorrect email!";
                        }
                    }
                    else {
                        TempData["ErrorMessage"] = "Incorrect password.";
                    }
                }
            } catch {
                TempData["ErrorMessage"] = "Server Error!";
            }
            return RedirectToAction("Index");
        }


        public String TestException() {
            var a = (1 + 1);
            var b = (2);
            if (a == b) throw new Exception();
            return "Nope! Try Again!";
        }
    }
}
