using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tsk_Login
{
    public partial class Register : System.Web.UI.Page
    {

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                // Passwords do not match
                errorMessage.Text = "Passwords do not match!";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Register (Name, Gender, Place, UserName, UserPassword, ConfirmPassword) VALUES (@Name, @Gender, @Place, @UserName, @UserPassword, @ConfirmPassword)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Place", txtPlace.Text.Trim());
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@ConfirmPassword", ConfirmPassword.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
                errorMessage.Text = "Registration Successful!";
            }
        }

    }
}

 
//errorMessage,,



