using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace GUCera
{
    public partial class studentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["type"].ToString().Equals("2"))
            {
                try
                {
                    Response.Redirect("Login.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch
                {
                    MessageBox.Show("Invalid info");
                }
            }
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                int id = (int)Session["user"];

                SqlCommand viewMyProfile = new SqlCommand("viewMyProfile", conn);
                viewMyProfile.CommandType = CommandType.StoredProcedure;
                viewMyProfile.Parameters.Add(new SqlParameter("@id", id));

                conn.Open();
                try
                {
                    viewMyProfile.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid info");
                }

                SqlDataReader rdr = viewMyProfile.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    int ID = rdr.GetInt32(rdr.GetOrdinal("id"));
                    String firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                    String lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                    String password = rdr.GetString(rdr.GetOrdinal("password"));
                    // int gender = rdr.GetInt32(rdr.GetOrdinal("gender"));
                    byte[] gender = (byte[])rdr.GetSqlBinary(rdr.GetOrdinal("gender"));
                    String email = rdr.GetString(rdr.GetOrdinal("email"));
                    String address = "";
                    if (rdr.IsDBNull(rdr.GetOrdinal("address")))
                    {
                        address = "No address provided";
                    }
                    else
                    {
                        address = rdr.GetString(rdr.GetOrdinal("address"));
                    }
                    Decimal gpa = rdr.GetDecimal(rdr.GetOrdinal("gpa"));
                    studentID.Text = ID.ToString();
                    studentFirstName.Text = firstName;
                    studentLastName.Text = lastName;
                    studentPassword.Text = password;
                    studentEmail.Text = email;
                    studentAddress.Text = address;
                    studentGPA.Text = gpa.ToString();

                    if (gender[0] == 1)
                    {
                        studentGender.Text = "Female";
                    }
                    else if (gender[0] == 0)
                    {
                        studentGender.Text = "Male";
                    }

                }

                conn.Close();
            }


        }

        protected void goHome_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("home.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Invalid info");
            }

            conn.Close();
        }
    }
}