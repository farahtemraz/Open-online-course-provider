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
    public partial class registerproc : System.Web.UI.Page
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

        protected void define_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int assignNumber = -1;
            Boolean check = Int32.TryParse(assignmentNumber.Text, out assignNumber);
            int grade = -1;
            Boolean check2 = Int32.TryParse(fullGrade.Text, out grade);
            decimal assignWeight = 0;
            Boolean check3 = Decimal.TryParse(weight.Text,out assignWeight);
            String assignContent = content.Text;
            
            if (!check || assignNumber < 0 || !check2 || !check3 )
            {
                MessageBox.Show("Please enter valid information");
            }
            else
            {
                String type = assignmentType.SelectedItem.Value;
                DateTime assignDeadline = calendar.SelectedDate;
                int cid = Int32.Parse(Session["defineAssignment"].ToString());
                int insID = Int32.Parse(Session["user"].ToString());
                conn.InfoMessage += Conn_InfoMessage;
                conn.Open();


                SqlCommand defineAssignment = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
                defineAssignment.CommandType = CommandType.StoredProcedure;
                defineAssignment.Parameters.Add(new SqlParameter("@instId", insID));
                defineAssignment.Parameters.Add(new SqlParameter("@cid", cid));
                defineAssignment.Parameters.Add(new SqlParameter("@number", assignNumber));
                defineAssignment.Parameters.Add(new SqlParameter("@type", type));
                defineAssignment.Parameters.Add(new SqlParameter("@fullGrade", grade));
                defineAssignment.Parameters.Add(new SqlParameter("@deadline", assignDeadline));
                defineAssignment.Parameters.Add(new SqlParameter("@weight", assignWeight));

                if (string.IsNullOrEmpty(content.Text))
                {
                    defineAssignment.Parameters.Add(new SqlParameter("@content", DBNull.Value));
                }
                else
                {
                    defineAssignment.Parameters.Add(new SqlParameter("@content", assignContent));
                }
               


                try
                {
                    defineAssignment.ExecuteNonQuery();
                    
                    Response.Redirect("defineAssignment.aspx", false);
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

        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
        
                MessageBox.Show(e.Message);
            
        }

    }
}