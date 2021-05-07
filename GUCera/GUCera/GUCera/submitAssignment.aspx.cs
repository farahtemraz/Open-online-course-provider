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
    public partial class submitAssignment : System.Web.UI.Page
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

        protected void submit_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            
            String type = typeOfAssignment.SelectedValue;
            int sid = Int32.Parse(Session["user"].ToString());
            int cid = -1;
            Boolean check0 = Int32.TryParse(courseID.Text, out cid);

            int number = -1;
            Boolean check1 = Int32.TryParse(assignmentNumber.Text, out number);
            conn.InfoMessage += Conn_InfoMessage;
            conn.Open();

            if (!check0 || !check1 || number < 0 || cid <= 0)
            {
                MessageBox.Show("Please enter valid information");
            }
            else
            {
                SqlCommand submitAssign = new SqlCommand("submitAssign", conn);
                submitAssign.CommandType = CommandType.StoredProcedure;
                submitAssign.Parameters.Add(new SqlParameter("@assignType", type));
                submitAssign.Parameters.Add(new SqlParameter("@assignnumber", number));
                submitAssign.Parameters.Add(new SqlParameter("@sid", sid));
                submitAssign.Parameters.Add(new SqlParameter("@cid", cid));

                try
                {
                    submitAssign.ExecuteNonQuery();
                    Response.Redirect("submitAssignment.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid info");
                }
            }
            conn.Close();
        }

        protected void goToHome_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String type = typeOfAssignment.SelectedValue;
            int sid = Int32.Parse(Session["user"].ToString());

            int cid = -1;
            Boolean check0 = Int32.TryParse(courseID.Text, out cid);

            int number = -1;
            Boolean check1 = Int32.TryParse(assignmentNumber.Text, out number);
            conn.InfoMessage += Conn_InfoMessage;

            conn.Open();

            if (!check0 || !check1 || number < 0 || cid <= 0)
            {
                MessageBox.Show("Please enter valid information");
            }
            else
            {
                SqlCommand submitAssign = new SqlCommand("submitAssign", conn);
                submitAssign.CommandType = CommandType.StoredProcedure;
                submitAssign.Parameters.Add(new SqlParameter("@assignType", type));
                submitAssign.Parameters.Add(new SqlParameter("@assignnumber", number));
                submitAssign.Parameters.Add(new SqlParameter("@sid", sid));
                submitAssign.Parameters.Add(new SqlParameter("@cid", cid));

                try
                {
                    submitAssign.ExecuteNonQuery();
                    Response.Redirect("home.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Information");
                }
            }
            conn.Close();
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