<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnLineShop.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div>
        <asp:Image ID="Image1" runat="server" CssClass=""
            ImageUrl="~/Content/Images/Alefa.jpg" />
    </div>

    <a runat="server" href="/Categories">Категории</a>

</asp:Content>