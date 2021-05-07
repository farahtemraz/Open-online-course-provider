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
    public partial class addCourse : System.Web.UI.Page
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

        protected void add_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Decimal price=-1;
            int credits = -1;
            Boolean check = Decimal.TryParse(coursePrice.Text,out price);
            Boolean check2 = Int32.TryParse(creditHours.Text,out credits);
            int insID = Int32.Parse(Session["user"].ToString());
            String name = courseName.Text;
            String description = courseDescription.Text;
            String content = courseContent.Text;

            conn.Open();
            if (!check || !check2)
            {
                MessageBox.Show("please enter valid info");
                
            }

            else
            {
                SqlCommand addCourse = new SqlCommand("InstAddCourse", conn);
                addCourse.CommandType = CommandType.StoredProcedure;
                addCourse.Parameters.Add(new SqlParameter("@creditHours", credits));
                addCourse.Parameters.Add(new SqlParameter("@name", name));
                addCourse.Parameters.Add(new SqlParameter("@price", price));
                addCourse.Parameters.Add(new SqlParameter("@instructorId", insID));
                addCourse.Parameters.Add(new SqlParameter("@content", content));
                addCourse.Parameters.Add(new SqlParameter("@description", description));


                try
                {
                    addCourse.ExecuteNonQuery();
                    MessageBox.Show("Course added");
                    Response.Redirect("addCourse.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Information");
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