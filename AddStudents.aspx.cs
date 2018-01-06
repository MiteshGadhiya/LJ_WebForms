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
    public partial class AddStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    GetExistingData(Request.QueryString["ID"]);
                }
            }
        }

        public void GetExistingData(string ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["WebFormDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [StudentId],[StudentName],[Gender],[CountryId],[StateId],[Address],[InstituteName]FROM [dbo].[Student](Nolock) WHERE StudentId=" + ID.ToString()))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                hfId.Value = dt.Rows[0]["StudentId"].ToString();
                                txtName.Text = dt.Rows[0]["StudentName"].ToString();
                                rblGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                                ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString();
                                if (dt.Rows[0]["CountryId"].ToString() == "1")
                                {
                                    ddlState.Items.Insert(0, new ListItem("Gujarat", "1"));
                                    ddlState.Items.Insert(0, new ListItem("Mumbai", "2"));
                                }
                                else
                                {
                                    ddlState.Items.Insert(0, new ListItem("New york", "1"));
                                    ddlState.Items.Insert(0, new ListItem("New Jersy", "2"));
                                }
                                ddlState.SelectedValue = dt.Rows[0]["StateId"].ToString();
                                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                                txtInstituteName.Text = dt.Rows[0]["InstituteName"].ToString();
                            }
                        }
                    }
                }
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCountry.SelectedValue == "1")
                {
                    ddlState.Items.Insert(0, new ListItem("Gujarat", "1"));
                    ddlState.Items.Insert(0, new ListItem("Mumbai", "2"));
                }
                else
                {
                    ddlState.Items.Insert(0, new ListItem("New york", "1"));
                    ddlState.Items.Insert(0, new ListItem("New Jersy", "2"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["WebFormDemo"].ConnectionString;
                InsertData(connectionString,
                           txtName.Text.Trim(),
                           rblGender.SelectedValue.Trim(),
                           Convert.ToInt32(ddlCountry.SelectedValue.Trim()),
                           Convert.ToInt32(ddlState.SelectedValue.Trim()),
                           txtAddress.Text.Trim(),
                           txtInstituteName.Text.Trim());
                Response.Redirect("ListStudents.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData(string connectionString, string Name, string Gender, Int32 Country, Int32 State, string Address, string InstituteName)
        {
            string query = string.Empty;
            if (Convert.ToInt32(hfId.Value) > 0)
            {
                query = "UPDATE [Student] SET StudentName = @Name,Gender = @Gender,CountryId = @Country,StateId = @State,Address = @Address,InstituteName = @InstituteName WHERE StudentId =" + Convert.ToInt32(hfId.Value);
            }
            else
            {
                query = "INSERT INTO [Student] ([StudentName],[Gender],[CountryId],[StateId],[Address],[InstituteName]) " +
                                           "VALUES (@Name, @Gender, @Country, @State, @Address, @InstituteName) ";
            }

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 500).Value = Name;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 10).Value = Gender;
                cmd.Parameters.Add("@Country", SqlDbType.Int).Value = Country;
                cmd.Parameters.Add("@State", SqlDbType.Int).Value = State;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 500).Value = Address;
                cmd.Parameters.Add("@InstituteName", SqlDbType.VarChar, 50).Value = InstituteName;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

    }
}