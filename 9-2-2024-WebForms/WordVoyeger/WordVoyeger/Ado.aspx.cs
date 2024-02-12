using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WordVoyegerBackend;

namespace WordVoyeger {
    public partial class Ado : System.Web.UI.Page {

        public List<WordVoyegerBackend.Article> listArticles;

        public Ado() {
            listArticles = WordVoyegerAPI.GetInstance().FetchArticlesByCategoryId(2);
        }

        protected void Page_Load(object sender, EventArgs e) {
            divHeadlines.InnerHtml = "";
            var html = "";
            AppState.GetInstance().dictionary[4] = AppState.ConvertTo(WordVoyegerAPI.GetInstance().FetchArticlesByCategoryId(4));
            foreach (var headline in AppState.GetInstance().dictionary[4]) {
                html += "<div class='headline'>";
                html += "<h2>" + headline.Title + "</h2>";
                html += "<div class='tags'>";
                foreach (var tag in headline.tags) {
                    html += "<p>" + tag + "</p>";
                }
                html += "</div>";
                html += "<p>" + headline.content + "</p>";
                html += "<button class='btn btn-primary' data-headlineid='" + headline.Id + "'>";
                html += "<a href='/Article?id=" + headline.Id + "&key=4'>View</a>";
                html += "</button>";
                
                html += "</div>";
            }
            divHeadlines.InnerHtml = html;
        }
    }
}