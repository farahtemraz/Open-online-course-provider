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
    public partial class adminAllCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["type"].ToString().Equals("1"))
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
                conn.Open();
                SqlCommand adminViewAllCourses = new SqlCommand("AdminViewAllCourses", conn);
                adminViewAllCourses.CommandType = CommandType.StoredProcedure;

                try
                {
                    adminViewAllCourses.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid info");
                }


                SqlDataReader rdr = adminViewAllCourses.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    int creditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                    String name = rdr.GetString(rdr.GetOrdinal("name"));
                    Decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                    Boolean accepted = false;
                    String content = "";
                    String acceptedOrNot = "";

                    if (!rdr.IsDBNull(rdr.GetOrdinal("accepted")))
                    {
                        accepted = (bool)rdr.GetSqlBoolean(rdr.GetOrdinal("accepted"));
                        if (accepted)
                        {
                            acceptedOrNot = "Accepted";
                        }
                        else
                        {
                            acceptedOrNot = "Rejected";
                        }
                    }
                    else
                    {
                        acceptedOrNot = "Not Yet Accepted";
                    }
                    if (!rdr.IsDBNull(rdr.GetOrdinal("content")))
                    {
                        content = rdr.GetString(rdr.GetOrdinal("content"));
                    }
                    else
                    {
                        content = "No content available";
                    }
                    TableRow row = new TableRow();
                    TableCell courseName = new TableCell();
                    courseName.Text = name.ToString();
                    TableCell credits = new TableCell();
                    credits.Text = creditHours.ToString();
                    TableCell coursePrice = new TableCell();
                    coursePrice.Text = price.ToString();

                    TableCell courseContent = new TableCell();
                    courseContent.Text = content;

                    TableCell courseAcceptance = new TableCell();
                    courseAcceptance.Text = acceptedOrNot;



                    row.Cells.Add(courseName);
                    row.Cells.Add(credits);
                    row.Cells.Add(coursePrice);
                    row.Cells.Add(courseContent);
                    row.Cells.Add(courseAcceptance);
                    allCoursesTable.Rows.Add(row);

                }
            }
        }

        protected void goHome_Click(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("adminHome.aspx", false);
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