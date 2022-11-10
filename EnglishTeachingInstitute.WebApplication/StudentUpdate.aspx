<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentUpdate.aspx.cs" Inherits="EnglishTeachingInstitute.WebApplication.StudentUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2> Student Form</h2>
    <formview>
        <div class="form-group">
            <asp:Label ID="FormFirstName" Text="First Name" runat="server" />
            <asp:TextBox ID="TextFirstName" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <asp:Label ID="FormLastName" Text="Last Name" runat="server" />
            <asp:TextBox ID="TextLastName" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <asp:Label ID="FormAddress" Text="Address" runat="server" />
            <asp:TextBox ID="TextAddress" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <asp:Label ID="FormContactNumber" Text="ContactNumber" runat="server" />
            <asp:TextBox ID="TextContactNumber" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <asp:Label ID="FormBirthday" Text="Birthday" runat="server" />
            <asp:TextBox ID="TextBirthday" class="form-control" runat="server" />
        </div>
        
        <asp:Button ID="SaveButton" Class="btn btn-primary" runat="server"  Text="REGISTER" OnClick="SaveStudent"/>
        
    </formview>

</asp:Content>
