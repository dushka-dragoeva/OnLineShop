<%@ Page Title=""
     Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="AdminHome.aspx.cs" 
    Inherits="OnLineShop.Web.Admin.AdminHome" %>
<%@ Register Src="~/Admin/CategoriesControl.ascx" TagPrefix="uc" TagName="AdminCategories" %>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
 <%--   
    
    <ul>
        <li><a runat="server" href="~/Admin/Product">ПродуктиView</a></li>
        <li><a runat="server" href="~/Admin/CategoriesView">Катргории</a></li>
        <li><a runat="server" href="~/Admin/Brands">Марки</a></li>
    </ul>--%>

</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2>Welcome Admin!</h2>
    
    <ul>
        <li><a runat="server" href="~/Admin/Product">Продукти</a></li>
        <li><a runat="server" href="~/Admin/CategoriesView">Катeгории</a></li>
        <li><a runat="server" href="~/Admin/BrandsView">Марки</a></li>
        <li><a runat="server" href="~/Admin/SizesView">Размери</a></li>
    </ul>

 <%-- <uc:AdminCategories runat="server" ID="EditCategories" />--%>

</asp:Content>
