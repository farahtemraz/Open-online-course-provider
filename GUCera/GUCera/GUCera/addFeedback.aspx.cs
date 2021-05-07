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
    public partial class addFeedback : System.Web.UI.Page
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

        protected void feedbackSubmit_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int cid = -1;
            Boolean check = Int32.TryParse(courseID.Text, out cid);
            if (!check || cid <= 0)
            {
                MessageBox.Show("Please enter a valid ID");
            }
            else
            {
                String commentText = comment.Text;
                int sid = Int32.Parse(Session["user"].ToString());
                conn.InfoMessage += Conn_InfoMessage;
                conn.Open();

                SqlCommand addFeedback = new SqlCommand("addFeedback", conn);
                addFeedback.CommandType = CommandType.StoredProcedure;
                addFeedback.Parameters.Add(new SqlParameter("@comment", commentText));
                addFeedback.Parameters.Add(new SqlParameter("@sid", sid));
                addFeedback.Parameters.Add(new SqlParameter("@cid", cid));

                try
                {
                    addFeedback.ExecuteNonQuery();
                    Response.Redirect("addFeedback.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no can");

                }
            }
        }

        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message);
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