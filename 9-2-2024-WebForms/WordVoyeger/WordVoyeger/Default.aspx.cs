using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WordVoyegerBackend;
using static WordVoyegerBackend.Article;

namespace WordVoyeger {
    public partial class Csharp : System.Web.UI.Page {

        public AppState appState = AppState.GetInstance();

        public bool IsValidEmail(string email) {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public bool IsValidPassword(string password) {
            return password.Length >= 6;
        }

        protected void Page_Load(object sender, EventArgs e) {

            btnLoginRender.ServerClick += (i, j) => {
                AuthDetails.GetInstance().viewLogInView = true;
                txtAuthError.InnerText = "";
            };

            btnSignupRender.ServerClick += (i, j) => {
                AuthDetails.GetInstance().viewLogInView = false;
                txtAuthError.InnerText = "";
            };

            btnAuth.ServerClick += (i, j) => {
                
                string email = txtEmail.Value;
                string password = txtPassword.Value;
                
                if (AuthDetails.GetInstance().viewLogInView) {
                    if (IsValidEmail(email) && IsValidPassword(password)) {
                        if (AuthDetails.GetInstance().LogIn(email,password)) {
                        } else {
                            txtAuthError.InnerText = "LogIn Failed! :)";
                        }
                    } else {
                        txtAuthError.InnerText = "Bad Credentials!";
                    }
                } else {
                    string name = txtName.Value;
                    if(name != null && name.Length > 2) {
                        if(IsValidEmail(email) && IsValidPassword(password)) {
                            if(AuthDetails.GetInstance().SignUp(name, email, password)) {
                                AuthDetails.GetInstance().viewLogInView = true;
                            } else {
                                txtAuthError.InnerText = "SignUp Failed! :)";
                            }
                        } else {
                            txtAuthError.InnerText = "Bad Credentials!";
                        }
                    } else txtAuthError.InnerText = "Bad Credentials!";

                }
                
            };

            AuthDetails.GetInstance().OnLoggedIn += () => {
                divHeadlines.InnerHtml = "";
                var html = "";
                AppState.GetInstance().dictionary[3] = AppState.ConvertTo(WordVoyegerAPI.GetInstance().FetchArticlesByCategoryId(3));
                foreach (var headline in AppState.GetInstance().dictionary[3]) {
                    html += "<div class='headline' >";
                    html += "<h2>" + headline.Title + "</h2>";
                    html += "<div class='tags'>";
                    foreach (var tag in headline.tags) {
                        html += "<p>" + tag + "</p>";
                    }
                    html += "</div>";
                    html += "<p>" + headline.content + "</p>";
                    html += "<button class='btn btn-primary' data-headlineid='" + headline.Id + "'>";
                    html += "<a href='/Article?id=" + headline.Id + "&key=3'>View</a>";
                    html += "</button>";
                    html += "</div>";
                }
                divHeadlines.InnerHtml = html;
            };

            if (AuthDetails.GetInstance().isLoggedIn) {
                divHeadlines.InnerHtml = "";
                var html = "";
                foreach (var headline in AppState.GetInstance().dictionary[3]) {
                    html += "<div class='headline'>";
                    html += "<h2>" + headline.Title + "</h2>";
                    html += "<div class='tags'>";
                    foreach (var tag in headline.tags) {
                        html += "<p>" + tag + "</p>";
                    }
                    html += "</div>";
                    html += "<p>" + headline.content + "</p>";
                    html += "<button class='btn btn-primary' data-headlineid='" + headline.Id + "'>";
                    html += "<a href='/Article?id=" + headline.Id + "&key=3'>View</a>";
                    html += "</button>";
                    html += "</div>";
                }
                divHeadlines.InnerHtml = html;
            }


 


        }
    }
}