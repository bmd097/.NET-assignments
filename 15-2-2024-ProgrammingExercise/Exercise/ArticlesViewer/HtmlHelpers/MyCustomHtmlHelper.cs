using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticlesViewer.HtmlHelpers {
    public static class MyCustomHtmlHelper {
        // Extention Methods
        public static MvcHtmlString MyCustomButton(this HtmlHelper htmlHelper, string buttonText) {
            
            var button = new Button { Text = buttonText };
            button.OnClientClick = $"alert('Hi!')";
            button.CssClass = $"btn btn-primary";

            var writer = new StringWriter();
            button.RenderControl(new HtmlTextWriter(writer));

            return MvcHtmlString.Create(writer.ToString());
        }
    }
}