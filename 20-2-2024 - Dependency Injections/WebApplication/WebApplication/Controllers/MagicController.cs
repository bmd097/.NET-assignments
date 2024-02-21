using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Utils;

namespace WebApplication.Controllers {
    public class MagicController : Controller {


        public ActionResult Index() {
            ResultModel resultModel = new ResultModel();
            resultModel.Countries = (Countries)DependencyContainer.GetInstance().GetService(typeof(Countries));
            return View(resultModel);
        }

        [HttpPost]
        public ActionResult FetchAll(String city,String country,String district) {
            ResultModel resultModel = new ResultModel();
            resultModel.Countries = (Countries)DependencyContainer.GetInstance().GetService(typeof(Countries));
            if (country != null) {
                resultModel.CountryCodeSelected = country;
                var cities = (Cities) DependencyContainer.GetInstance().GetService(typeof(Cities));
                foreach(var c in cities.GetCities()) {
                    if(country == c.CountryCode) {
                        resultModel.Cities = c.CountryNames;
                        break;
                    }
                }
            } 
            if(city != null) {
                resultModel.CitySelected = city;
                resultModel.Districts = new List<string> { 
                    "ABC",
                    "DEF",
                    "GHI",
                    "XYZ",
                    "ALP",
                };
            }
            return View("Index",resultModel); 
        }
    }
}