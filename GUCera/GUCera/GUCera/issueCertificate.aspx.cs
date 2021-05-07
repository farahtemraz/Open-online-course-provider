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
    public partial class issueCertificate : System.Web.UI.Page
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
        }

        protected void issue_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int sid = -1;
            Boolean check = Int32.TryParse(studentID.Text, out sid);
            DateTime issueDate = DateTime.Now;
            int cid = Int32.Parse(Session["issueCertificate"].ToString());
            int insID = Int32.Parse(Session["user"].ToString());
            conn.InfoMessage += Conn_InfoMessage;
            conn.Open();

            if (!check || sid <= 0)
            {
                MessageBox.Show("invalid id");
            }
            else
            {

                SqlCommand issueCourseCertificate = new SqlCommand("InstructorIssueCertificateToStudent", conn);
                issueCourseCertificate.CommandType = CommandType.StoredProcedure;
                issueCourseCertificate.Parameters.Add(new SqlParameter("@insId", insID));
                issueCourseCertificate.Parameters.Add(new SqlParameter("@cid", cid));
                issueCourseCertificate.Parameters.Add(new SqlParameter("@sid", sid));
                issueCourseCertificate.Parameters.Add(new SqlParameter("@issueDate", issueDate));
                try
                {
                    issueCourseCertificate.ExecuteNonQuery();
                 
                    Response.Redirect("issueCertificate.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid info");
                }
            }
            conn.Close();
        }

        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        protected void goToHome_Click(object sender, EventArgs e)
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