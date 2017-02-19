<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProducsAdminView.aspx.cs" Inherits="OnLineShop.Web.Admin.ProducsAdminView" %>

<%@ Register Src="~/UserControl/AdminNavigation.ascx" TagPrefix="uc" TagName="AdminNav" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <uc:AdminNav runat="server" ID="AdminNav" />

    <asp:ListView runat="server"
        ID="ListViewProducts"
        ItemType="OnLineShop.Data.Models.Product"
        SelectMethod="ListViewProducts_GetData"
        DeleteMethod="ListViewProducts_DeleteItem"
        DataKeyNames="Id">
        <LayoutTemplate>
            <div class="row">
                <div class=" col-md-8">
                    <h4>Продукти</h4>
                    <table class="gridview table table-striped table-responsive table-hover" border="1" id="MainContent_GridViewCategories" style="border-collapse: collapse;">
                        <tbody>
                            <tr>
                                <th scope="col">Снимка</th>
                                <th scope="col">Продукт</th>
                                <th scope="col">Артикул №</th>
                                <th scope="col">
                                    <asp:LinkButton Text="Категория" runat="server" ID="LinkButton1" CommandName="Sort" CommandArgument="Name" />
                                </th>
                                <th scope="col">
                                    <asp:LinkButton Text="Марка" runat="server" ID="LinkButton2" CommandName="Sort" CommandArgument="Name" />
                                </th>
                                <th scope="col">Количество</th>
                                <th scope="col">Цена</th>
                                <th scope="col">Изтрий</th>
                            </tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>

                            <tr class="active">
                                <td colspan="10">
                                    <asp:DataPager runat="server" ID="DataPagerCategories" PageSize="5">
                                        <Fields>
                                            <asp:NumericPagerField />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>No Picture
                </td>
                <td>
                    <asp:HyperLink NavigateUrl='<%# string.Format("~/Admin/ProductDetailsAdminView.aspx?id={0}", Item.Id) %>' runat="server" CssClass="glyphicon glyphicon-pencil" Text="  <%#:Item.Name %>" />

                </td>
                <td><%#:Item.ModelNumber %></td>
                <td>
                    <%#:Item.Category.Name %>
                </td>
                <td>
                    <%#:Item.Brand.Name %>
                </td>
                <td>
                    <%#:Item.Quantity %>
                </td>
                <td>
                    <%#:Item.Price %>
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" ControlStyle-CssClass="glyphicon glyphicon-remove" ForeColor="Red" EditText="" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
        </InsertItemTemplate>


        <EmptyDataTemplate>
            Няма продукти в тази категория.
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:HyperLink NavigateUrl="~/Admin/ProductDetailsAdminView.aspx" runat="server" Text="Добави нов продукт" CssClass="btn btn-info" />
</asp:Content>
