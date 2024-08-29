using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class EmployeeDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployeeGrid();
        }
    }

    private void BindEmployeeGrid()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Employee";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvEmployees.DataSource = dt;
            gvEmployees.DataBind();
        }
    }

    protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployees.EditIndex = e.NewEditIndex;
        BindEmployeeGrid();
    }

    protected void gvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvEmployees.Rows[e.RowIndex];
        int empID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
        string empName = (row.FindControl("txtEmpName") as TextBox).Text;
        string empDesignation = (row.FindControl("txtEmpDesignation") as TextBox).Text;
        string empPlace = (row.FindControl("txtEmpPlace") as TextBox).Text;
        string empState = (row.FindControl("txtEmpState") as TextBox).Text;
        string empCountry = (row.FindControl("txtEmpCountry") as TextBox).Text;

        string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string query = "UPDATE Employee SET EmpName=@EmpName, EmpDesignation=@EmpDesignation, EmpPlace=@EmpPlace, EmpState=@EmpState, EmpCountry=@EmpCountry WHERE EmpID=@EmpID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EmpID", empID);
            cmd.Parameters.AddWithValue("@EmpName", empName);
            cmd.Parameters.AddWithValue("@EmpDesignation", empDesignation);
            cmd.Parameters.AddWithValue("@EmpPlace", empPlace);
            cmd.Parameters.AddWithValue("@EmpState", empState);
            cmd.Parameters.AddWithValue("@EmpCountry", empCountry);
            cmd.ExecuteNonQuery();
            gvEmployees.EditIndex = -1;
            BindEmployeeGrid();
        }
    }

    protected void gvEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmployees.EditIndex = -1;
        BindEmployeeGrid();
    }

    protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int empID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
        string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            // Backup data
            string backupQuery = "INSERT INTO BackupEmployees (EmpID, EmpName, EmpDesignation, EmpPlace, EmpState, EmpCountry) SELECT EmpID, EmpName, EmpDesignation, EmpPlace, EmpState, EmpCountry FROM Employee WHERE EmpID=@EmpID";
            SqlCommand backupCmd = new SqlCommand(backupQuery, con);
            backupCmd.Parameters.AddWithValue("@EmpID", empID);
            backupCmd.ExecuteNonQuery();

            // Delete data
            string deleteQuery = "DELETE FROM Employee WHERE EmpID=@EmpID";
            SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
            deleteCmd.Parameters.AddWithValue("@EmpID", empID);
            deleteCmd.ExecuteNonQuery();

            BindEmployeeGrid();
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddEmployee.aspx");
    }
}
