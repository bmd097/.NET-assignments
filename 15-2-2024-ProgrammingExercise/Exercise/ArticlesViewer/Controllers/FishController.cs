using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticlesViewer.Controllers
{
    public class FishController : Controller
    {
        // GET: Fish
        public ActionResult Index()
        {
            return View();
        }

        // GET: Fish
        public ActionResult PartialIndex() {
            return View();
        }


    }
}
