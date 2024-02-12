using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordVoyeger {



    public partial class SiteMaster : MasterPage {

        


        protected void Page_Load(object sender, EventArgs e) {
            btnLogout.ServerClick += (i, j) => {
                AuthDetails.GetInstance().Logout();
            };
        }
    }
}