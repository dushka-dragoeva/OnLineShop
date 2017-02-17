<%@ Page Title=""
     Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="AdminHome.aspx.cs" 
    Inherits="OnLineShop.Web.Admin.AdminHome" %>

<%@ Register Src="~/UserControl/AdminNavigation.ascx" TagPrefix="uc" TagName="AdminNav" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
    <uc:AdminNav runat="server" ID="AdminNav"/>
    <h2>Welcome Admin!</h2>
  
 </asp:Content>
