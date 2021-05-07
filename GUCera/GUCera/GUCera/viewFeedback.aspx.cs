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
    public partial class viewFeedback : System.Web.UI.Page
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
                int cid = Int32.Parse(Session["viewFeedback"].ToString());
                int insID = Int32.Parse(Session["user"].ToString());
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand viewFeedbacks = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
                viewFeedbacks.CommandType = CommandType.StoredProcedure;
                viewFeedbacks.Parameters.Add(new SqlParameter("@cid", cid));
                viewFeedbacks.Parameters.Add(new SqlParameter("@instrId", insID));

                try
                {
                    viewFeedbacks.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("invalid");
                }


                SqlDataReader rdr = viewFeedbacks.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    int number = rdr.GetInt32(rdr.GetOrdinal("number"));
                    int noOfLikes = rdr.GetInt32(rdr.GetOrdinal("numberOfLikes"));
                    String comment = rdr.GetString(rdr.GetOrdinal("comment"));
                    TableRow row = new TableRow();
                    TableCell feedbackNo = new TableCell();
                    feedbackNo.Text = number.ToString();
                    TableCell numberOfLikes = new TableCell();
                    numberOfLikes.Text = noOfLikes.ToString();
                    TableCell comments = new TableCell();
                    comments.Text = comment;
                    row.Cells.Add(feedbackNo);
                    row.Cells.Add(numberOfLikes);
                    row.Cells.Add(comments);
                    feedbackTable.Rows.Add(row);

                }
            }
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