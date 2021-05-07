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
    public partial class viewCertificates : System.Web.UI.Page
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
        }

        protected void viewCourseCertificates_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int cid = -1;
            Boolean check0 = Int32.TryParse(courseID.Text, out cid);
            int sid = Int32.Parse(Session["user"].ToString());
            Session["courseCertificates"] = cid;
            conn.InfoMessage += Conn_InfoMessage;
            conn.Open();
            if (!check0 || cid <= 0)
            {
                MessageBox.Show("Please enter a valid course id");
            }
            else
            {

                SqlCommand viewCertificate = new SqlCommand("viewCertificate", conn);
                viewCertificate.CommandType = CommandType.StoredProcedure;
                viewCertificate.Parameters.Add(new SqlParameter("@sid", sid));
                viewCertificate.Parameters.Add(new SqlParameter("@cid", cid));

                try
                {
                    viewCertificate.ExecuteNonQuery();
                    Response.Redirect("courseCertificates.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");

                }
            }
            conn.Close();
        }

        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message);
            Response.Redirect("viewCertificates.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
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