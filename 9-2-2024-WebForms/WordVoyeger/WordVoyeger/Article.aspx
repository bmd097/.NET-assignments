<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="WordVoyeger.Article" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Article.css" rel="stylesheet" type="text/css" />    
    <link href="PNF.css" rel="stylesheet" type="text/css" />    

     <% if (WordVoyeger.AuthDetails.GetInstance().isLoggedIn) {
%>
            <%

                var id = int.Parse(Request.QueryString["id"].ToString());
                var key = int.Parse(Request.QueryString["key"].ToString());

                var list = WordVoyeger.AppState.GetInstance().dictionary[key];
                WordVoyeger.RenderArticle article = null;

                foreach(WordVoyeger.RenderArticle atr in list) {
                    if(atr.Id == id) {
                        article = atr;
                    }
                }

                %>
     
    <% if (article != null) { %>
            <section class="Article container">
                <main class="content">
                    <h1><% = article.Title %></h1>
                    <p><%= article.authorName %> | <%=article.authorEmail %></p>
                    <div class="tags">

                        <% foreach (string tag in article.tags) { %>

                          <p>#<%=tag %> </p>
                        

                        <% } %>
                    </div>
                    <p><% =article.content %></p>
                </main>
                <div class="comments">
                    <div class="comment-adder">
                        <textarea rows="3"  placeholder="Comment here..." id="txtComment" runat="server"></textarea>
                        <button class="btn btn-success" id="btnCommentAdder" runat="server">Add</button>
                        <div>
                        <p style="color:green;" runat="server" id="txtSuccessLog"></p>
                        <p style="color:red" id="txtErrorLog" runat="server"></p>
                        </div>
                    </div>
                    <div class="comments-display" runat="server" id="commentsDisplay">
                        
                    </div>
                    
                </div>
            </section>      
    <% } %>

     <% } else {  %>
        
            <div class="PNF" style="background:url(back.jpg);background-size:cover">

                <h1>401</h1>
                <p>Not Authenticated!</p>

            </div>   

     <% } %>

</asp:Content>
