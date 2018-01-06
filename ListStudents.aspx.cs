using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormDemo
{
    public partial class ListStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ListStudentBindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ListStudentBindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["WebFormDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [StudentId],[StudentName],[Gender],CASE WHEN [CountryId] = 1 THEN 'India' ELSE 'USA' END [CountryId],CASE WHEN [CountryId] = 1 AND [StateId] = 1 THEN 'GUJARAT' WHEN [CountryId] = 1 AND [StateId] = 2 THEN 'Mumbai'WHEN [CountryId] = 2 AND [StateId] = 1 THEN 'New york' WHEN [CountryId] = 2 AND [StateId] = 2 THEN 'New Jersy' End as [StateId],[Address],[InstituteName]FROM [dbo].[Student](Nolock)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvListStudent.DataSource = dt;
                            gvListStudent.DataBind();
                        }
                    }
                }
            }
        }

        protected void gvListStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int l = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Delete")
                {
                    string constr = ConfigurationManager.ConnectionStrings["WebFormDemo"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("delete from Student where StudentId=" + l, con))
                        {
                            cmd.Connection = con;
                            int i = cmd.ExecuteNonQuery();
                            if (i == 1)
                            {
                                Response.Write("Record deleted");
                                ListStudentBindGrid();
                            }
                            else
                            {
                                Response.Write("Recodrd not deleted...");
                            }
                        }
                        con.Close();
                    }
                }
                else
                {
                    Response.Redirect("AddStudents.aspx?ID=" + l.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvListStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvListStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}