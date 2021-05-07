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
    public partial class courseCertificates : System.Web.UI.Page
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
                int sid = Int32.Parse(Session["user"].ToString());
                int cid = Int32.Parse(Session["courseCertificates"].ToString());
                conn.Open();
                SqlCommand getEnrolled = new SqlCommand("viewCertificate", conn);
                getEnrolled.CommandType = CommandType.StoredProcedure;
                getEnrolled.Parameters.AddWithValue("@sid", sid);
                getEnrolled.Parameters.AddWithValue("@cid", cid);

                SqlDataReader rdr = getEnrolled.ExecuteReader(CommandBehavior.CloseConnection);
                conn.InfoMessage += conn_InfoMessage;
                while (rdr.Read())
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                    String grade = rdr.GetDecimal(rdr.GetOrdinal("grade")).ToString();
                    String issueDate = rdr.GetDateTime(rdr.GetOrdinal("issueDate")).ToString();
                    Label courseNameLabel = new Label();
                    courseNameLabel.Text = "Course Name: ";
                    courseCertificate.Controls.Add(courseNameLabel);
                    Label nameCourse = new Label();
                    nameCourse.Text = courseName.ToString() + " <br/>";
                    courseCertificate.Controls.Add(nameCourse);

                    Label courseGradeLabel = new Label();
                    courseGradeLabel.Text = "Grade: ";
                    courseCertificate.Controls.Add(courseGradeLabel);
                    Label gradeCourse = new Label();
                    gradeCourse.Text = grade + " <br/>";
                    courseCertificate.Controls.Add(gradeCourse);

                    Label courseIssueLabel = new Label();
                    courseIssueLabel.Text = "Issue Date: ";
                    courseCertificate.Controls.Add(courseIssueLabel);
                    Label issueCourse = new Label();
                    issueCourse.Text = issueDate + " <br/>";
                    courseCertificate.Controls.Add(issueCourse);
                    Label lineBreak2 = new Label();
                    lineBreak2.Text = " <br/>";
                    courseCertificate.Controls.Add(lineBreak2);
                    Label lineBreak = new Label();
                    lineBreak.Text = "--------------------------------" + "<br/>";
                    courseCertificate.Controls.Add(lineBreak);

                }
                conn.Close();
            }
            
            }

        private void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message);
            Response.Redirect("viewCertificates.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }


    }
}