<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ado.aspx.cs" Inherits="WordVoyeger.Ado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="PNF.css" rel="stylesheet" type="text/css" />    
    <link href="Page.css" rel="stylesheet" type="text/css" />



    <% if (WordVoyeger.AuthDetails.GetInstance().isLoggedIn) {  %>
        
        <div class="Page container" runat="server" id="divContentHolder">
            <div style="margin-top:10px" class="headlines" runat="server" id="divHeadlines">
       
            </div>
        </div>     

    <% } else {  %>
        
            <div class="PNF" style="background:url(back.jpg);background-size:cover">

                <h1>401</h1>
                <p>Not Authenticated!</p>

            </div>   

     <% } %>

</asp:Content>
