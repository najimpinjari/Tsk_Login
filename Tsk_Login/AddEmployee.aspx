<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Tsk_Login.AddEmployee" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Add Employee</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtEmpName" runat="server" />
            <asp:TextBox ID="txtEmpDesignation" runat="server" />
            <asp:TextBox ID="txtEmpPlace" runat="server" />
            <asp:TextBox ID="txtEmpState" runat="server" />
            <asp:TextBox ID="txtEmpCountry" runat="server" />
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </form>
</body>
</html>
