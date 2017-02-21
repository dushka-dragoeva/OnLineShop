<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetailsAdminView.aspx.cs" Inherits="OnLineShop.Web.Admin.ProductDetailsAdminView" %>

<%@ Register Src="~/UserControl/AdminNavigation.ascx" TagPrefix="uc" TagName="AdminNav" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <uc:AdminNav runat="server" ID="AdminNav" />

    <asp:FormView runat="server"
        ID="FormViewAdminProductDetails"
        ItemType="OnLineShop.Data.Models.Product"
        SelectMethod="FormViewAdminProductDetails_GetItem"
        DeleteMethod="FormViewAdminProductDetails_DeleteItem"
        UpdateMethod="FormViewAdminProductDetails_UpdateItem"
        InsertMethod="FormViewAdminProductDetails_InsertItem"
        EnableModelValidation="true"
        DataKeyNames="Id" OnPageIndexChanging="FormViewAdminProductDetails_PageIndexChanging">

        <EditItemTemplate>
            <h2>Редактирена на aртикул<%#:Item.ModelNumber %></h2>
            <div class="form-group">
                <asp:Label ID="Label1" AssociatedControlID="TextBoxName" runat="server" Text="Заглавие"></asp:Label>

                <asp:TextBox runat="server" ID="TextBoxName" class="form-control" Text="<%#: BindItem.Name %>" />
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator2"
                    ControlToValidate="TextBoxName"
                    EnableClientScript="true"
                    runat="server"
                    ErrorMessage="Невалидни символи"
                    Display="Dynamic"
                    ForeColor="Red"
                    ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-]+$">
                </asp:RegularExpressionValidator>
                <asp:CustomValidator
                    ErrorMessage="Заглавието трябва да бъде между 2 и 20 символа"
                    ControlToValidate="TextBoxName"
                    OnServerValidate="Length_ServerValidate" runat="server" />

                <asp:Label ID="Label2" AssociatedControlID="TextBoxDescription" runat="server" Text="Описание"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxDescription" class="form-control" Text="<%#: BindItem.Description %>" TextMode="MultiLine" />
                 <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator3"
                    ControlToValidate="TextBoxDescription"
                    EnableClientScript="true"
                    runat="server"
                    ErrorMessage="Невалидни символи"
                    Display="Dynamic"
                    ForeColor="Red"
                    ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-\.,:!?_@*();']+$">
                </asp:RegularExpressionValidator>
                <asp:CustomValidator
                    ErrorMessage="Заглавието трябва да бъде между 2 и 20 символа"
                    ControlToValidate="TextBoxDescription"
                    OnServerValidate="DescriptionLength_ServerValidate"
                    runat="server"
                    Display="Dynamic" />

                <div class="row">
                    <div class=" col-md-4">
                        <asp:Label ID="Label3" AssociatedControlID="TextBoxModel" runat="server" Text="Модел"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxModel" class="form-control" Text="<%#: BindItem.ModelNumber %>" />
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator4"
                            ControlToValidate="TextBoxModel"
                            EnableClientScript="true"
                            runat="server"
                            ErrorMessage="Невалидни символи"
                            Display="Dynamic"
                            ForeColor="Red"
                            ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-]{2,20}$">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class=" col-md-4">
                        <asp:Label ID="Label5" AssociatedControlID="DropDownCategories" runat="server" Text=" Категория"></asp:Label>
                        <asp:DropDownList runat="server" ID="DropDownCategories"
                            ItemType="OnLineShop.Data.Models.Category"
                            DataValueField="Id"
                            DataTextField="Name"
                            SelectedValue="<%# BindItem.CategoryId %>"
                            SelectMethod="DropDownCategories_GetData"
                            class="form-control"
                            Display="Dynamic" />
                    </div>
                    <div class=" col-md-4">
                        <asp:Label ID="Label6" AssociatedControlID="DropDownBrands" runat="server" Text="Марка"></asp:Label>
                        <asp:DropDownList runat="server" ID="DropDownBrands"
                            ItemType="OnLineShop.Data.Models.Brand"
                            DataValueField="Id"
                            DataTextField="Name"
                            SelectedValue="<%# BindItem.BrandId%>"
                            SelectMethod="DropDownBrands_GetData"
                            class="form-control"
                            Display="Dynamic" />
                    </div>
                </div>
                <asp:Label ID="Label4" AssociatedControlID="CheckBoxListSizes" runat="server" Text="Размери"></asp:Label>
                <asp:CheckBoxList
                    ID="CheckBoxListSizes"
                    ItemType="OnLineShop.Data.Models.Size"
                    runat="server"
                    DataValueField="Id"
                    DataTextField="Value"
                    SelectedValues="<%#:Item.Sizes.Select(x=>x.Id) %>"
                    SelectMethod="DropDownSizes_GetData"
                    AutoPostBack="true"
                    RepeatColumns="30"
                    CssClass="form-control"
                    AppendDataBoundItems="True" />
                <br />

                <div class="row">
                    <div class=" col-md-5">
                        <div class="row">
                            <asp:Label ID="LabelPrice" AssociatedControlID="TextBoxQuantity" runat="server" Text="Количество"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBoxQuantity" TextMode="Number" class="form-control" Text="<%#: BindItem.Quantity %>" Width="50%" />
                                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1"
                                runat="server" ErrorMessage="Количеството е задължителна"
                                ControlToValidate="TextBoxQuantity">
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1"
                                ControlToValidate="TextBoxQuantity"
                                runat="server" MinimumValue="1"
                                MaximumValue="10000"
                                ErrorMessage="Въведете положително число"
                                Display="Dynamic"
                                Type="Double"
                                CssClass="form-control">

                            </asp:RangeValidator>
                        </div>
                        <div class="row">
                            <asp:Label ID="Label7" AssociatedControlID="TextBoxPrice" runat="server" Text="Цена"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBoxPrice"  class="form-control" Text="<%#: BindItem.Price %>" Width="50%" />
                             <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2"
                                runat="server" ErrorMessage="Цената е задължителна"
                                ControlToValidate="TextBoxPrice"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2"
                                ControlToValidate="TextBoxPrice"
                                runat="server"
                                MinimumValue="0"
                                MaximumValue="100000"
                                ErrorMessage="Въведете положително число"
                                Display="Dynamic"
                                Type="Double"
                                >
                            </asp:RangeValidator>
                        </div>
                        <div class="row">
                        </div>
                        <div class="row">
                        </div>
                    </div>

                    <div class=" col-md-6">

                        <br />

                        <asp:Image
                            ID="Image1"
                            runat="server"
                            ImageUrl="<%#:Item.PictureUrl %>"
                            Width="40"
                            AlternateText="NoImage"></asp:Image>
                    </div>
                    <%--                    <div class=" col-md-2">

                        <asp:Image
                            ID="Image2"
                            runat="server"
                            AlternateText="NoImage"></asp:Image>
                    </div>
                    <div class=" col-md-2">

                        <asp:Image
                            ID="Image3"
                            runat="server"
                            AlternateText="NoImage"></asp:Image>
                    </div>
                </div>--%>
                    <div class="row">
                        <div class=" col-md-3">

                            <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Update" CssClass="btn" />
                        </div>
                        <div class=" col-md-3">
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" CssClass="btn" />
                        </div>
                    </div>
                </div>
        </EditItemTemplate>

        <InsertItemTemplate>
            <h3>Добавяне на нов продукт</h3>
            <div class="form-group">
                <asp:Label ID="Label1" AssociatedControlID="TextBoxName" runat="server" Text="Заглавие"></asp:Label>

                <asp:TextBox runat="server" ID="TextBoxName" class="form-control" Text="<%#: BindItem.Name %>" />
                 <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator2"
                    ControlToValidate="TextBoxName"
                    EnableClientScript="true"
                    runat="server"
                    ErrorMessage="Невалидни символи"
                    Display="Dynamic"
                    ForeColor="Red"
                    ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-]+$">
                </asp:RegularExpressionValidator>
                <asp:CustomValidator
                    ErrorMessage="Заглавието трябва да бъде между 2 и 20 символа"
                    ControlToValidate="TextBoxName"
                    OnServerValidate="Length_ServerValidate" runat="server" />

                <asp:Label ID="Label2" AssociatedControlID="TextBoxDescription" runat="server" Text="Описание"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxDescription" class="form-control" Text="<%#: BindItem.Description %>" TextMode="MultiLine" />
                 <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator3"
                    ControlToValidate="TextBoxDescription"
                    EnableClientScript="true"
                    runat="server"
                    ErrorMessage="Невалидни символи"
                    Display="Dynamic"
                    ForeColor="Red"
                    ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-\.,:!?_@*();']+$">
                </asp:RegularExpressionValidator>
                <asp:CustomValidator
                    ErrorMessage="Заглавието трябва да бъде между 2 и 20 символа"
                    ControlToValidate="TextBoxDescription"
                    OnServerValidate="DescriptionLength_ServerValidate"
                    runat="server"
                    Display="Dynamic" />

                <div class="row">
                    <div class=" col-md-4">
                        <asp:Label ID="Label3" AssociatedControlID="TextBoxModel" runat="server" Text="Модел"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxModel" class="form-control" Text="<%#: BindItem.ModelNumber %>" />
                         <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator4"
                            ControlToValidate="TextBoxModel"
                            EnableClientScript="true"
                            runat="server"
                            ErrorMessage="Невалидни символи"
                            Display="Dynamic"
                            ForeColor="Red"
                            ValidationExpression="^[a-zA-Zа-яА-Я0-9\s\-]{2,20}$">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class=" col-md-4">
                        <asp:Label ID="Label5" AssociatedControlID="DropDownCategories" runat="server" Text=" Категория"></asp:Label>
                        <asp:DropDownList runat="server" ID="DropDownCategories"
                            ItemType="OnLineShop.Data.Models.Category"
                            DataValueField="Id"
                            DataTextField="Name"
                            SelectedValue="<%# BindItem.CategoryId %>"
                            SelectMethod="DropDownCategories_GetData"
                            class="form-control"
                            Display="Dynamic" />
                    </div>
                    <div class=" col-md-4">
                        <asp:Label ID="Label6" AssociatedControlID="DropDownBrands" runat="server" Text="Марка"></asp:Label>
                        <asp:DropDownList runat="server" ID="DropDownBrands"
                            ItemType="OnLineShop.Data.Models.Brand"
                            DataValueField="Id"
                            DataTextField="Name"
                            SelectedValue="<%# BindItem.BrandId%>"
                            SelectMethod="DropDownBrands_GetData"
                            class="form-control"
                            Display="Dynamic" />
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanelBeersWines" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label4" AssociatedControlID="CheckBoxListSizes" runat="server" Text="Размери"></asp:Label>
                        
                        <asp:CheckBoxList
                            ID="CheckBoxListSizes"
                            ItemType="OnLineShop.Data.Models.Size"
                            runat="server"
                            SelectMethod="DropDownSizes_GetData"
                            DataValueField="Id"
                            DataTextField="Value"
                            AutoPostBack="True"
                            RepeatColumns="30"
                            CssClass="form-control"
                             >
                           
                          
                        </asp:CheckBoxList>
                        <br />

                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class=" col-md-5">
                        <div class="row">
                            <asp:Label ID="LabelPrice" AssociatedControlID="TextBoxQuantity" runat="server" Text="Количество"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBoxQuantity" TextMode="Number" class="form-control" Text="<%#: BindItem.Quantity %>" Width="50%" />
                             <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1"
                                runat="server" ErrorMessage="Количеството е задължителна"
                                ControlToValidate="TextBoxQuantity">
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1"
                                ControlToValidate="TextBoxQuantity"
                                runat="server" MinimumValue="1"
                                MaximumValue="10000"
                                ErrorMessage="Въведете положително число"
                                Display="Dynamic"
                                Type="Double"
                                CssClass="form-control">

                            </asp:RangeValidator>
                        </div>
                        <div class="row">
                            <asp:Label ID="Label7" AssociatedControlID="TextBoxPrice"  runat="server" Text="Цена"></asp:Label>
                            <input  type="number" typeof="decimal"  runat="server" ID="TextBoxPrice" class="form-control" value="<%#: BindItem.Price %>" Width="50%" />
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2"
                                runat="server" ErrorMessage="Цената е задължителна"
                                ControlToValidate="TextBoxPrice"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxPrice" 
                                ValidationExpression="[0-9\.]{1,9}" 
                                ErrorMessage="Цената е с 2 символа след десетичната запетая." 
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        
                        </div>
                        <div class="row">
                        </div>
                        <div class="row">
                        </div>
                    </div>
                </div>
                <br />
                <br />
        <%--        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <asp:FileUpload ID="FileUpload1" runat="server" ValidateRequestMode="Disabled" />
                        <br />
                        <asp:Button runat="server" ID="UploadButton1" Text="Upload" OnClick="UploadButton1_Click" ValidateRequestMode="Disabled" />
                        <br />
                        <br />
                        <asp:Label runat="server" ID="LabelUploadStatus" ValidateRequestMode="Disabled" Text="Upload status: " />
                        <asp:TextBox ID="TextBoxFilePath" runat="server" Text="<%#:BindItem.PictureUrl %>" Visible="false"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Image ID="DisplayImage" runat="server" Width="50" AlternateText="Picture" />
       <%--             </ContentTemplate>
                </asp:UpdatePanel>--%>
                <br />
                <br />
                <br />
                <div class="row">
                    <div class=" col-md-3">
                        <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Insert" CssClass="btn" />
                    </div>
                    <div class=" col-md-3">
                        <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" CssClass="btn" ValidateRequestMode="Disabled" />
                    </div>
                </div>
            </div>
            <validationsummary runat="server" ForeColor="Red"  EnableModelValidation="true"></validationsummary>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
