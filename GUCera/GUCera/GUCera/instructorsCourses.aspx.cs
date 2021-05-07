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
    public partial class instructorsCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["type"].ToString().Equals("0"))
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
                int insID = Int32.Parse(Session["user"].ToString());
                conn.Open();
                SqlCommand getEnrolled = new SqlCommand("SELECT ITC.cid,C.name FROM InstructorTeachCourse ITC INNER JOIN Course C on ITC.cid = c.id WHERE insid = @insID", conn);
                getEnrolled.Parameters.AddWithValue("@insID", insID);
                SqlDataReader rdr = getEnrolled.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                    int courseID = rdr.GetInt32(rdr.GetOrdinal("cid"));

                    TableRow row = new TableRow();
                    TableCell courseNameCell = new TableCell();
                    courseNameCell.Text = courseName.ToString();
                    TableCell courseIDCell = new TableCell();
                    courseIDCell.Text = courseID.ToString();
                    TableCell defineAssignmentsCell = new TableCell();
                    Button defineAssignments = new Button();
                    defineAssignments.ID = courseID.ToString();
                    defineAssignments.Text = "Define Assignment";
                    defineAssignments.Click += button_Click;
                    defineAssignments.CssClass = "btn btn-md btn-outline-light";
                    defineAssignmentsCell.Controls.Add(defineAssignments);

                    TableCell submittedAssignmentsCell = new TableCell();
                    Button viewAssignments = new Button();
                    viewAssignments.ID = courseID.ToString() + " ";
                    viewAssignments.Text = "View Submitted Assignment";
                    viewAssignments.CssClass = "btn btn-md btn-outline-light";
                    viewAssignments.Click += viewAssignment_Click;
                    submittedAssignmentsCell.Controls.Add(viewAssignments);

                    TableCell feedbackCell = new TableCell();
                    Button viewFeedback = new Button();
                    viewFeedback.ID = courseID.ToString() + "  ";
                    viewFeedback.Text = "View Feedback";
                    viewFeedback.CssClass = "btn btn-md btn-outline-light";
                    viewFeedback.Click += viewFeedback_Click;
                    feedbackCell.Controls.Add(viewFeedback);


                    TableCell certificatesCell = new TableCell();
                    Button issueCertificate = new Button();
                    issueCertificate.ID = courseID.ToString() + "   ";
                    issueCertificate.Text = "Issue Certificate";
                    issueCertificate.CssClass = "btn btn-md btn-outline-light";
                    issueCertificate.Click += issueCertificate_Click;
                    certificatesCell.Controls.Add(issueCertificate);

                    row.Cells.Add(courseIDCell);
                    row.Cells.Add(courseNameCell);
                    row.Cells.Add(defineAssignmentsCell);
                    row.Cells.Add(submittedAssignmentsCell);
                    row.Cells.Add(feedbackCell);
                    row.Cells.Add(certificatesCell);
                    instructorsCoursesTable.Rows.Add(row);

                }

            }
        }


        protected void button_Click(object sender, EventArgs e)
        {
            Session["defineAssignment"] = ((Button)sender).ID;
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("defineAssignment.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Invalid info");
            }

            conn.Close();
        }

        protected void viewAssignment_Click(object sender, EventArgs e)
        {
            Session["viewSubmittedAssignment"] = ((Button)sender).ID.Trim();
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("viewSubmittedAssignments.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Invalid info");
            }

            conn.Close();
        }

        protected void viewFeedback_Click(object sender, EventArgs e)
        {
            Session["viewFeedback"] = ((Button)sender).ID.Trim();
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("viewFeedback.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Invalid info");
            }

            conn.Close();
        }

        protected void issueCertificate_Click(object sender, EventArgs e)
        {
            Session["issueCertificate"] = ((Button)sender).ID.Trim();
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("issueCertificate.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Invalid info");
            }

            conn.Close();
        }


        protected void button2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            try
            {
                Response.Redirect("homeOfInstructors.aspx", false);
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