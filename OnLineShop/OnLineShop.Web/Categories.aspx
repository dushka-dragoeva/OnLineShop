<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="OnLineShop.Web.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class=" row">
        <div class="col-md-3">
            <asp:ListView ID="CategoryListView"
                runat="server"
                ItemType="OnLineShop.Data.Models.Category"
                SelectMethod="CategoryListView_GetData"
                DataKeyNames="Id"
                SelectedIndex="1">
                <LayoutTemplate>
                    <ul class="nav nav-pills nav-stacked">
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </ul>

                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%# string.Format("~/CategoryDetailsView.aspx?id={0}", Item.Id) %>' Text=" <%#:Item.Name %>" />
                    </li>
                </ItemTemplate>

                <EditItemTemplate>
                    Няма Намерен Продукт с ID <%#:Item.Id %>
                </EditItemTemplate>

            </asp:ListView>
        </div>
        <div class="col-md-8"></div>

    </div>
</asp:Content>
