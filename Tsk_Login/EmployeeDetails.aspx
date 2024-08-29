<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Tsk_Login.EmployeeDetails" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Employee Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" OnRowEditing="gvEmployees_RowEditing" OnRowUpdating="gvEmployees_RowUpdating" OnRowCancelingEdit="gvEmployees_RowCancelingEdit" OnRowDeleting="gvEmployees_RowDeleting">
            <Columns>
                <asp:BoundField DataField="EmpID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="EmpName" HeaderText="Name" />
                <asp:BoundField DataField="EmpDesignation" HeaderText="Designation" />
                <asp:BoundField DataField="EmpPlace" HeaderText="Place" />
                <asp:BoundField DataField="EmpState" HeaderText="State" />
                <asp:BoundField DataField="EmpCountry" HeaderText="Country" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
