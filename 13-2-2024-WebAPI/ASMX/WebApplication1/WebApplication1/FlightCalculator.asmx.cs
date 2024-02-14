using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1 {
    /// <summary>
    /// Summary description for FlightCalculator
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FlightCalculator : System.Web.Services.WebService {

        public static List<string> flights = new List<string> {
           "Boing 899 - ARG - MEX",
           "IND 89 - DUB - UK",
           "SAHARA EXPRESS - NIG - TAS",
           "PAKI 788 - PAK - DUB"
    };

        [WebMethod]
        public List<string> GetFligts() {
            return flights;
        }

        [WebMethod]
        public bool CreateNewFlight(string name, string from, string to) {
            Random random = new Random();
            if (random.Next(0, 100) > 60) {
                flights.Add(name + " - " + from + " - " + to);
                return true;
            } else return false;
        }
    }
}
