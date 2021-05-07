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
    public partial class adminPendingCourses : System.Web.UI.Page
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
                SqlCommand adminViewNonAcceptedCourses = new SqlCommand("AdminViewNonAcceptedCourses", conn);
                adminViewNonAcceptedCourses.CommandType = CommandType.StoredProcedure;

                try
                {
                    adminViewNonAcceptedCourses.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }


                SqlDataReader rdr = adminViewNonAcceptedCourses.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    int cid = rdr.GetInt32(rdr.GetOrdinal("id"));
                    int creditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                    String name = rdr.GetString(rdr.GetOrdinal("name"));
                    Decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                    String content = "";

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

                    TableCell actionType = new TableCell();
                    Button action = new Button();
                    action.Text = "Accept Course";
                    action.ID = cid.ToString();
                    action.CssClass = "btn btn-md btn-outline-light";
                    action.Click += action_Click;
                    actionType.Controls.Add(action);

                    row.Cells.Add(courseName);
                    row.Cells.Add(credits);
                    row.Cells.Add(coursePrice);
                    row.Cells.Add(courseContent);
                    row.Cells.Add(actionType);
                    pendingCoursesTable.Rows.Add(row);

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

        protected void action_Click(object sender, EventArgs e)
        {
            int cid = Int32.Parse(((Button)sender).ID);
            int adminID = Int32.Parse(Session["user"].ToString());

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand acceptCourse = new SqlCommand("AdminAcceptRejectCourse", conn);
            acceptCourse.CommandType = CommandType.StoredProcedure;
            acceptCourse.Parameters.Add(new SqlParameter("@courseId", cid));
            acceptCourse.Parameters.Add(new SqlParameter("@adminid", adminID));
            try
            {
                acceptCourse.ExecuteNonQuery();
                MessageBox.Show("Course accepted");
                Response.Redirect("adminPendingCourses.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid info");
            }
        conn.Close();
        }
    }
}