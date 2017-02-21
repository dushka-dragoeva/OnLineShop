<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="OnLineShop.Web.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server"
        ID="ListViewProducts"
        ItemType="OnLineShop.Data.Models.Product"
        SelectMethod="Products_GetData"
        DataKeyNames="Id">
        <LayoutTemplate>
            <div class="row">

                <ul class="nav nav-tabs nav-justified">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </ul>
            </div>
            </div>

            <asp:DataPager runat="server" ID="DataPagerCategories" PageSize="5">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-3" style="border: 1px solid black; margin: 10px;">
                <li>
                    <h4> <asp:HyperLink NavigateUrl='<%# string.Format("~/ProductDetailsView.aspx?id={0}", Item.Id) %>' runat="server" Text="  <%#:Item.Name %>" /></h4>
                    <div><%#:Item.Brand.Name %></div>
                    <div class ="row" style="height:300px; align-content:center">
                        <asp:ImageButton
                            ID="ImageButton1"
                            runat="server"
                            ImageUrl="<%#:Item.PictureUrl %>"
                            AlternateText="Picture"
                            Width="180"
                            
                            />
                    </div>
                    <div class="pull-ridht">Цена <%#:Item.Price %></div>
                    Категория: <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl ='<%# string.Format("~/CategoryDetailsView.aspx?id={0}", Item.Category.Id) %>' Text=" <%#:Item.Category.Name %>"/>
                </li>
            </div>

        </ItemTemplate>
    </asp:ListView>

</asp:Content>
