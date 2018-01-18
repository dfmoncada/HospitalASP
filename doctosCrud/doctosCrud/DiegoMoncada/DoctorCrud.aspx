<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorCrud.aspx.cs" Inherits="doctosCrud.DoctorCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="create" runat="server">
        <asp:Label ID="lbl_message" runat="server"></asp:Label>
        <h2>Create</h2>
        <div>
            <asp:Label ID="lbl_id_c" runat="server">ID:</asp:Label>
            <asp:TextBox ID="txt_id_c" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_name_c" runat="server">Name:</asp:Label>
            <asp:TextBox ID="txt_name_c" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_special_c" runat="server">Specialization:</asp:Label>
            <asp:TextBox ID="txt_special_c" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_resume_c" runat="server">Resume:</asp:Label>
            <asp:TextBox ID="txt_resume_c" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btn_create" Text="Create" runat="server" OnClick="btn_create_click"/>
        <br /> <hr />
        <h2>Update</h2>
        <div>
            <asp:Label ID="lbl_id_u" runat="server">ID</asp:Label>
            <asp:DropDownList ID="slc_doctors_u" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="lbl_name_u" runat="server">Name:</asp:Label>
            <asp:TextBox ID="txt_name_u" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_special_u" runat="server">Specialization:</asp:Label>
            <asp:TextBox ID="txt_special_u" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_resume_u" runat="server">Resume:</asp:Label>
            <asp:TextBox ID="txt_resume_u" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btn_update" Text="Update" runat="server" OnClick="btn_update_terms_Click" />
        <br /><hr />
        <h2>Delete</h2>
        <div>
            <asp:Label ID="lbl_doctor" runat="server">Dosctors:</asp:Label>
            <asp:DropDownList ID="slc_doctors" runat="server"></asp:DropDownList>
        </div>
        <asp:Button ID ="btn_delete" Text="Delete" runat="server" OnClick="btn_delete_term_Click"/>
        <br /><hr />
    </form>
    
    <asp:Table ID ="tbl_doctors" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Specialization</asp:TableHeaderCell>
            <asp:TableHeaderCell>Resume</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</body>
</html>
