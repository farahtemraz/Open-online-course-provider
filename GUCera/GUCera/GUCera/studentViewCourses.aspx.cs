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
    public partial class studentViewCourses : System.Web.UI.Page
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
                SqlCommand coursesProc = new SqlCommand("availableCourses", conn);
                coursesProc.CommandType = CommandType.StoredProcedure;

                conn.Open();
                try
                {
                    coursesProc.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("invalid info");
                }

                SqlDataReader rdr = coursesProc.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                    int courseID = rdr.GetInt32(rdr.GetOrdinal("id"));
                    TableRow row = new TableRow();
                    TableCell courseNameCell = new TableCell();
                    courseNameCell.Text = courseName.ToString();
                    TableCell actionType = new TableCell();
                    Button viewCourses = new Button();
                    viewCourses.ID = courseID.ToString();
                    viewCourses.Text = "View Course";
                    viewCourses.Click += button_Click;
                    viewCourses.CssClass = "btn btn-md btn-outline-light";
                    actionType.Controls.Add(viewCourses);
                    row.Cells.Add(courseNameCell);
                    row.Cells.Add(actionType);
                    studentViewCoursesTable.Rows.Add(row);

                }
            }


        }

        protected void button_Click(object sender, EventArgs e)
        {

            Session["viewedCourseID"] = ((Button)sender).ID;
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("courseInformation.aspx", false);
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