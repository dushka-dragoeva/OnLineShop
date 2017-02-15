<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="OnLineShop.Web.Admin.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Категории</h2>

    <asp:GridView
        ID="GridViewCategories"
        runat="server"
        ItemType="OnLineShop.Data.Models.Category"
        DataKeyNames="Id"
        SelectMethod="GridViewCategories_GetData"
        AutoGenerateColumns="False"
        AllowPaging="True"
        AllowSorting="True"
        UpdateMethod="GridViewCategories_UpdateItem"
        DeleteMethod="GridViewCategories_DeleteItem"
        ValidateRequestMode="Enabled"
        BackColor="White"
        BorderColor="#999999"
        BorderStyle="None"
        BorderWidth="1px"
        CellPadding="10"
        GridLines="Vertical">

        <AlternatingRowStyle BackColor="#DCDCDC" />

        <Columns>
            <asp:CommandField ShowSelectButton="true" />
            <asp:BoundField DataField="Id" Visible="false" />

            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <ItemTemplate><%#:Item.Name %></ItemTemplate>
                <EditItemTemplate>

                    <asp:TextBox ID="EditName" runat="server" Text="<%# Item.Name %>"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1"
                        runat="server"
                        ControlToValidate="EditName"
                        ErrorMessage="Полето е задължително!"
                        Display="Dynamic"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1"
                        ControlToValidate="EditName"
                        runat="server"
                        ErrorMessage="Невалидни символи"
                        Display="Dynamic"
                        ForeColor="Red"
                        ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-]+$"></asp:RegularExpressionValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="true">
                <ControlStyle></ControlStyle>
            </asp:CommandField>
            <asp:CommandField ShowDeleteButton="true">
                <ControlStyle></ControlStyle>
            </asp:CommandField>

        </Columns>

        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />

    </asp:GridView>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Button ID="ButtonAdd" runat="server" Text="Добави" OnClick="ButtonAdd_Click" />

            <asp:Panel ID="CreareItem" runat="server" Visible="false">
                <br />
                <asp:TextBox ID="CategoryCreate" runat="server" ToolTip="category name"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator
                    ID="RequiredfieldValidator"
                    runat="server"
                    Display="dynamic"
                    ErrorMessage="category name is mandatory"
                    ControlToValidate="categorycreate"
                    EnableClientScript="true"
                    ForeColor="red">
                </asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="ButtonCreate" runat="server" Text="Потвърди" CssClass="btn btn-info" OnClick="ButtonCreate_Click" />

                <asp:Button ID="ButtonCancel"
                    runat="server"
                    CommandName="Cancel"
                    EnableClientScript="false"
                    Text="Откажи"
                    CssClass="btn btn-danger"
                    CausesValidation="false" ValidateRequestMode="Disabled"
                    OnClick="ButtonCancel_Click" />

            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
