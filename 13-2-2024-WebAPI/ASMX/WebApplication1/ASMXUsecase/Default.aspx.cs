using ASMXUsecase.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASMXUsecase {
    public partial class _Default : Page {
            
        public FlightCalculatorSoapClient flightCalculatorSoapClient = new FlightCalculatorSoapClient();
        protected void Page_Load(object sender, EventArgs e) {
            string res = "";
            foreach (var item in flightCalculatorSoapClient.GetFligts()) {
                res += "<p>" + item.ToString() + "</p>";
            }
            divflow.InnerHtml = res;
        }
    }
}