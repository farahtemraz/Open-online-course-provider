
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["type"] = -1;
        }

        protected void Signin_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int id = -1;
            Boolean check = Int32.TryParse(username.Text, out id);
            if (!check || id <= 0)
            {
                MessageBox.Show("Please enter a valid ID");
            }
            else
            {

                String pass = password.Text;

                SqlCommand loginproc = new SqlCommand("userLogin", conn);
                loginproc.CommandType = CommandType.StoredProcedure;
                loginproc.Parameters.Add(new SqlParameter("@id", id));
                loginproc.Parameters.Add(new SqlParameter("@password", pass));

                SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
                SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.Int);

                success.Direction = ParameterDirection.Output;
                type.Direction = ParameterDirection.Output;



                conn.Open();
                try
                {
                    loginproc.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid info!");
                }
                Session["type"] = type.Value;
                Session["user"] = id;
                conn.Close();

                if (success.Value.ToString() == "0")
                {
                    MessageBox.Show("Invalid info!");
                }

                else
                {
                    if (success.Value.ToString() == "1")
                    {
                        MessageBox.Show("login successful");
                        if (type.Value.ToString() == "2")
                        {
                            try
                            {
                                Response.Redirect("home.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();
                            }
                            catch (Exception ex)
                            {
                                System.Windows.MessageBox.Show("Invalid info");
                            }
                        }
                        else if (type.Value.ToString() == "0")
                        {
                            try
                            {
                                Response.Redirect("homeOfInstructors.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();
                            }
                            catch (Exception ex)
                            {
                                System.Windows.MessageBox.Show("Invalid info");
                            }
                        }
                        else if (type.Value.ToString() == "1")
                        {
                            try
                            {
                                Response.Redirect("adminHome.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();
                            }
                            catch (Exception ex)
                            {
                                System.Windows.MessageBox.Show("Invalid info");
                            }
                        }
                    }
                }
            }
        }
    }
}