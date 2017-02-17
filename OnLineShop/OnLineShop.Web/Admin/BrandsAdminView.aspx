<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrandsAdminView.aspx.cs" Inherits="OnLineShop.Web.Admin.BrandsAdminView" %>

<%@ Register Src="~/UserControl/AdminNavigation.ascx" TagPrefix="uc" TagName="AdminNav" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AdminNav runat="server" ID="AdminNav" />
    <h4>Редактиране Марки</h4>
    <asp:ListView ID="BrandListView"
        runat="server"
        ItemType="OnLineShop.Data.Models.Brand"
        SelectMethod="BrandListView_GetData"
        InsertMethod="BrandListView_InsertItem"
        DeleteMethod="BrandListView_DeleteItem"
        UpdateMethod="BrandListView_UpdateItem"
        InsertItemPosition="LastItem"
        DataKeyNames="Id" ConvertEmptyStringToNull="False">
        <LayoutTemplate>
            <div class="row">
                <div class=" col-md-4">
                    <table class="gridview table table-striped table-responsive table-hover" cellspacing="0" rules="all" border="1" id="MainContent_GridViewCategories" style="border-collapse: collapse;">
                        <tbody>
                            <tr>
                                <th scope="col">
                                    <asp:LinkButton Text="Марки" runat="server" ID="LinkButtonSortByBrand" CommandName="Sort" CommandArgument="Name" />
                                </th>
                                <th scope="col">Описание</th>
                                <th scope="col">Снимка</th>
                                <th scope="col">Редактирай</th>
                                <th scope="col">Изтрий</th>
                            </tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                            <tr class="active">
                                <td colspan="5">
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
                <td>
                    <asp:LinkButton ID="LinkBrandName" runat="server"><%#:Item.Name %></asp:LinkButton>
                </td>
                <td><%#(String.IsNullOrEmpty(Item.Description)) ? "Няма Описание" : Item.Description.Length<=20? Item.Description: Item.Description.Substring(0,20)%>...</td>

                <td><%#(String.IsNullOrEmpty(Item.ImageUrl)) ? "Няма Снимка" : Item.ImageUrl.Length<=20 ? Item.ImageUrl: Item.ImageUrl.Substring(0,20)%>...</td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="" ControlStyle-CssClass="glyphicon glyphicon-pencil" CommandName="Edit" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" ControlStyle-CssClass="glyphicon glyphicon-remove" ForeColor="Red" EditText="" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxName" placeholder="Добави" Text="<%#: BindItem.Name %>" />
                </td>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1"
                    ControlToValidate="TextBoxName"
                    EnableClientScript="true"
                    runat="server"
                    ErrorMessage="Невалидни символи"
                    Display="Dynamic"
                    ForeColor="Red"
                    ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-]{2,20}$">
                </asp:RegularExpressionValidator>
                <td>
                    <asp:TextBox runat="server" ID="TextBox1" Text="<%#: BindItem.Description %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox2" Text="<%#: BindItem.ImageUrl %>" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="InsertBoxName" Text="<%#: BindItem.Name %>" />
                </td>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1"
                    ControlToValidate="InsertBoxName"
                    runat="server"
                    ErrorMessage="Невалидни символи"
                    Display="Dynamic"
                    ForeColor="Red"
                    ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-]{2,20}$">
                </asp:RegularExpressionValidator>
                <td>
                    <asp:TextBox runat="server" ID="TextBox1" Text="<%#: BindItem.Description %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox2" Text="<%#: BindItem.ImageUrl %>" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Insert" CommandName="Insert" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
