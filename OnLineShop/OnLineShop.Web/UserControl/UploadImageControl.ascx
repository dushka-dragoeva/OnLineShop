﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadImageControl.ascx.cs" Inherits="OnLineShop.Web.UserControl.UploadImageControl" %>
<asp:UpdatePanel runat="server">
    <%--<ContentTemplate>
        <div class="row">
            <img src="data:image/<%#: Model.CurrentProfilePictureMimeType %>;base64,<%#: Model.CurrentProfilePictureBase64 %>" alt="The profile picture of <%#: Model.LoggedUserUsername %>" />

            <asp:TextBox ID="ProfilePictureUrlTextBox" runat="server"></asp:TextBox>
            <asp:FileUpload ID="ProfilePictureFileUpload" runat="server" />
            <asp:Button ID="UpdateProfilePictureButton" runat="server" OnClick="OnUploadProfilePictureButtonClick" Text="Update Profile Picture" />

            <asp:Label ID="ResultLable" runat="server" CssClass=""></asp:Label>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="UpdateProfilePictureButton" />
    </Triggers>--%>
</asp:UpdatePanel>