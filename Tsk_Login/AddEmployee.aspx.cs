using System;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddEmployee : System.Web.UI.Page
{
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string empName = txtEmpName.Text;
        string empDesignation = txtEmpDesignation.Text;
        string empPlace = txtEmpPlace.Text;
        string empState = txtEmpState.Text;
        string empCountry = txtEmpCountry.Text;

        string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string query = "INSERT INTO Employee (EmpName, EmpDesignation, EmpPlace, EmpState, EmpCountry) VALUES (@EmpName, @EmpDesignation, @EmpPlace, @EmpState, @EmpCountry)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EmpName", empName);
            cmd.Parameters.AddWithValue("@EmpDesignation", empDesignation);
            cmd.Parameters.AddWithValue("@EmpPlace", empPlace);
            cmd.Parameters.AddWithValue("@EmpState", empState);
            cmd.Parameters.AddWithValue("@EmpCountry", empCountry);
            cmd.ExecuteNonQuery();
        }
        Response.Redirect("EmployeeDetails.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeDetails.aspx");
    }
}
