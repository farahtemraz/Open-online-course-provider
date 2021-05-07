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
    public partial class mobile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["type"].ToString().Equals("1") && !Session["type"].ToString().Equals("2") && !Session["type"].ToString().Equals("0"))
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

        protected void addmobile_Click(object sender, EventArgs e)
        {
            
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int myId = (int)Session["user"];
            String mob = number.Text;

            SqlCommand mobileproc = new SqlCommand("addMobile", conn);
            mobileproc.CommandType = CommandType.StoredProcedure;
            mobileproc.Parameters.Add(new SqlParameter("@ID", myId));
            mobileproc.Parameters.Add(new SqlParameter("@mobile_number", mob));

            conn.Open();
            if (string.IsNullOrEmpty(number.Text))
            {
                MessageBox.Show("please enter mobile number");
            }
            else
            {
                try
                {
                    mobileproc.ExecuteNonQuery();
                    MessageBox.Show("mobile added successfully");
                    Response.Redirect("mobile.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch
                {
                    MessageBox.Show("Invalid info!");
                }
            }
            conn.Close();
        }

        protected void go_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int myId = (int)Session["user"];
            String mob = number.Text;

            SqlCommand mobileproc = new SqlCommand("addMobile", conn);
            mobileproc.CommandType = CommandType.StoredProcedure;
            mobileproc.Parameters.Add(new SqlParameter("@ID", myId));
            mobileproc.Parameters.Add(new SqlParameter("@mobile_number", mob));

            int type = Int32.Parse(Session["type"].ToString());

            conn.Open();
            if (string.IsNullOrEmpty(number.Text))
            {
                MessageBox.Show("please enter mobile number");
            }
            else
            {
                try
                {
                    mobileproc.ExecuteNonQuery();
                    MessageBox.Show("mobile added successfully");
                    if (type == 2)
                    {
                        Response.Redirect("home.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else if (type == 0)
                    {
                        Response.Redirect("homeOfInstructors.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }

                }
                catch
                {
                    MessageBox.Show("Invalid info!");
                }
            }
            conn.Close();
        }


        protected void homepage_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int type = Int32.Parse(Session["type"].ToString());
            conn.Open();
            try
            {
                if (type == 2)
                {
                    Response.Redirect("home.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else if (type == 0)
                {
                    Response.Redirect("homeOfInstructors.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }
            catch
            {
                MessageBox.Show("Invalid info!");
            }
            conn.Close();
        }
    }
}

   