<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentListPage.aspx.cs" Inherits="EnglishTeachingInstitute.WebApplication.StudentListPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>STUDENT LIST</h2> 
     <asp:Button 
         ID="Button1" 
         runat="server" 
         Text="Add New Student" 
         OnClick="btn_register_click"
         class ="btn btn-success"
         CommandName="insert"
         CommandArgument='<%# Eval("Id") %>'/>  
    <hr />
    <asp:GridView 
        ID ="GridStudentList"
        ItemType ="EnglishTeachingInstitute.Model.Student"
        AllowPaging="true" 
        DataKeyNames ="Id"
        PageSize="5"
        OnPageIndexChanging="GridPageIndexChange"
        OnRowUpdating ="btn_update_click"
        OnRowDeleting ="btn_delete_click"
        AutoGenerateColumns="false"
        runat="server"
        class ="table table-striped">
         
        <Columns>
            <asp:DynamicField DataField ="Id" />
            <asp:DynamicField DataField ="FirstName" />
            <asp:DynamicField DataField ="LastName" />
            <asp:DynamicField DataField ="Address" />
            <asp:DynamicField DataField ="BirthDay" />
            <asp:DynamicField DataField ="ContactNumber" />
            <%--<asp:DynamicField DataField ="CreatedDate" />--%>

            
      

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button 
                        ID="btn_update"
                        runat="server"
                        Text="Update"
                        class ="btn btn-success"
                        CommandName="update"
                        OnClick ="btn_update_click"
                        CommandArgument='<%# Eval("Id") %>'/>

                    <asp:Button 
                        ID="btn_delete"
                        runat="server"
                        Text="Delete"
                        class ="btn btn-danger"
                        CommandName="delete"
                        OnClick ="btn_delete_click"
                        CommandArgument='<%# Eval("Id") %>' />

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
