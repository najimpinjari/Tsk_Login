using System;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(1) FROM Login WHERE UserName=@UserName AND PasswordHaash=@Password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserName", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
                Response.Redirect("EmployeeDetails.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Username or Password!";
            }
        }
    }
}
