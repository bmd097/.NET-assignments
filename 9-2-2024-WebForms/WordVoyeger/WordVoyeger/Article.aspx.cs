using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WordVoyegerBackend;

namespace WordVoyeger {
    public partial class Article : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            btnCommentAdder.ServerClick += (i, j) => {
                try {
                    var id = int.Parse(Request.QueryString["id"].ToString());

                    String comment = txtComment.Value;
                    if (comment == null || comment.Length == 0) {
                        txtErrorLog.InnerText = "Bad Comment!";
                        txtSuccessLog.InnerText = string.Empty;
                        return;
                    }
                    Comment co = new Comment();
                    co.content = comment;
                    co.createdAt = DateTime.Now;
                    co.userId = AuthDetails.GetInstance().user.id;
                    
                    if (WordVoyegerAPI.GetInstance().AddComment(id, co)) {
                        txtErrorLog.InnerText = "";
                        txtSuccessLog.InnerText = "Success!";
                    } else {
                        txtErrorLog.InnerText = "Nah! Failed!";
                        txtSuccessLog.InnerText = string.Empty;
                    }

                }catch (Exception ex) {

                }
            };

            try {
                var id = Request.QueryString["id"];
                if (id != null) {
                    var articleId = int.Parse(Request.QueryString["id"].ToString());

                    List<Comment> comments = WordVoyegerAPI.GetInstance().FetchCommentsByArticleId(articleId);
                    comments.Sort((c1, c2) => c2.createdAt.CompareTo(c1.createdAt));

                    StringBuilder commentHtml = new StringBuilder();

                    foreach (var comment in comments) {
                        commentHtml.Append("<div class=\"comment\">");
                        commentHtml.Append("<h3>" + comment.userName + "</h3>");
                        commentHtml.Append("<p>" + comment.content + "</p>");
                        commentHtml.Append("<h4>" + comment.createdAt.ToString("M/d/yyyy") + "</h4>");
                        commentHtml.Append("</div>");
                    }

                    commentsDisplay.InnerHtml = commentHtml.ToString();
                }
            }catch (Exception ex) { }

        }
    }
}