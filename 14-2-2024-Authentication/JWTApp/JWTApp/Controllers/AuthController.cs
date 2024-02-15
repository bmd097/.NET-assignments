using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWTApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index(){
            ViewBag.Title = "Auth App";
            return View();
        }
    }
}
