<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminNavigation.ascx.cs" Inherits="OnLineShop.Web.UserControl.AdminNavigation" %>

<ul class="nav nav-pills">
    <li><a runat="server" role="presentation" href="~/Admin/AdminHome">Админ</a></li>
    <li><a runat="server" role="presentation" href="~/Admin/Product">Продукти</a></li>
    <li><a runat="server" role="presentation" href="~/Admin/CategoriesView">Катeгории</a></li>
    <li><a runat="server" role="presentation" href="~/Admin/BrandsAdminView">Марки</a></li>
    <li><a runat="server" role="presentation" href="~/Admin/SizesAdminView">Размери</a></li>
    <li><a runat="server" role="presentation" href="~/Admin/BrandsView">Клиенти</a></li>
    <li><a runat="server" role="presentation" href="~/Admin/SizesView">Поръчки</a></li>
</ul>
