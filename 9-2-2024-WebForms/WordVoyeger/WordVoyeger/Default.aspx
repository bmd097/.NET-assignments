<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WordVoyeger.Csharp" %>
<asp:Content ID="CSharpContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Page.css" rel="stylesheet" type="text/css" />
    <link href="Auth.css" rel="stylesheet" type="text/css" />

    <% if (WordVoyeger.AuthDetails.GetInstance().isLoggedIn) { %>
        <div class="Page container" runat="server" id="divContentHolder" >
            <div style="margin-top:10px;" class="headlines" runat="server" id="divHeadlines">
               
            </div>
        </div>
    <% } else { %>
        <div class="Auth" runat="server">
            <img src="back.jpg" alt="pic" decoding="async" />
            <div class="box">
                <h1>Word Voyeger</h1>
                <div class="authMenu">
                    <button runat="server" id="btnLoginRender">Login</button>
                    <button runat="server" id="btnSignupRender">Signup</button>
                </div>
                <% if (!WordVoyeger.AuthDetails.GetInstance().viewLogInView) { %>
                    <input required type="text" id="txtName" runat="server" placeholder="Name"/>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Name required" ControlToValidate="txtName"></asp:RequiredFieldValidator>                
                <% } %>
                <input required type="email" id="txtEmail" runat="server" placeholder="Email"/>
                <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Email required" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                <input required type="password" id="txtPassword" runat="server" placeholder="Password"/>
                <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Password required" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>                
                <button type="submit"  class="btn btn-primary" id="btnAuth" runat="server">Submit</button>
                <p runat="server" style="color:red;" id="txtAuthError"></p>
            </div>
        </div>
        
    <% }%>

</asp:Content>
