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
    public partial class yourCourses : System.Web.UI.Page
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
                int id = Int32.Parse(Session["user"].ToString());
                conn.Open();
                SqlCommand getEnrolled = new SqlCommand("SELECT Distinct C.name,STC.cid FROM StudentTakeCourse STC INNER JOIN Course C ON STC.cid = C.id WHERE STC.sid = @sid ", conn);
                getEnrolled.Parameters.AddWithValue("@sid", id);
                SqlDataReader rdr = getEnrolled.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                    int courseID = rdr.GetInt32(rdr.GetOrdinal("cid"));


                    TableRow row = new TableRow();
                    TableCell courseIdCell = new TableCell();
                    courseIdCell.Text = courseID.ToString();
                    TableCell courseNameCell = new TableCell();
                    courseNameCell.Text = courseName.ToString();
                    TableCell actionType = new TableCell();
                    Button viewAssignments = new Button();
                    viewAssignments.ID = courseID.ToString();
                    viewAssignments.Text = "View Assignments";
                    viewAssignments.Click += button_Click;
                    viewAssignments.CssClass = "btn btn-md btn-outline-light";
                    actionType.Controls.Add(viewAssignments);
                    row.Cells.Add(courseIdCell);
                    row.Cells.Add(courseNameCell);
                    row.Cells.Add(actionType);
                    yourCoursesTable.Rows.Add(row);

                }
            }
        }

        protected void button2_Click(object sender, EventArgs e)
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

        protected void button_Click(object sender, EventArgs e)
        {
            Session["courseAssignments"] = ((Button)sender).ID;
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("courseAssignments.aspx", false);
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