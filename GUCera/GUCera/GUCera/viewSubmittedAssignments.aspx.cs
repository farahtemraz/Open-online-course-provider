using Microsoft.VisualBasic;
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
    public partial class viewSubmittedAssignments : System.Web.UI.Page
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
                int cid = Int32.Parse(Session["viewSubmittedAssignment"].ToString());
                int insID = Int32.Parse(Session["user"].ToString());
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand viewAssignments = new SqlCommand("InstructorViewAssignmentsStudents", conn);
                viewAssignments.CommandType = CommandType.StoredProcedure;
                viewAssignments.Parameters.Add(new SqlParameter("@cid", cid));
                viewAssignments.Parameters.Add(new SqlParameter("@instrId", insID));

                try
                {
                    viewAssignments.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid info");
                }


                SqlDataReader rdr = viewAssignments.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    int sid = rdr.GetInt32(rdr.GetOrdinal("sid"));
                    String type = rdr.GetString(rdr.GetOrdinal("assignmenttype"));
                    int assignNumber = rdr.GetInt32(rdr.GetOrdinal("assignmentNumber"));
                    String grade = "";
                    TableRow row = new TableRow();
                    TableCell studentID = new TableCell();
                    studentID.Text = sid.ToString();
                    TableCell assignmentNumber = new TableCell();
                    assignmentNumber.Text = assignNumber.ToString();
                    TableCell assignType = new TableCell();
                    assignType.Text = type;

                    TableCell actionType = new TableCell();
                    Button action = new Button();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("grade")))
                    {
                        grade = rdr.GetDecimal(rdr.GetOrdinal("grade")).ToString();
                        action.Text = "Edit Grade";
                    }
                    else
                    {
                        grade = "yet to be graded";
                        action.Text = "Grade";
                    }
                    TableCell assignGrade = new TableCell();
                    assignGrade.Text = grade;

                    action.ID = studentID.Text + "," + assignmentNumber.Text + "," + assignType.Text;
                    action.CssClass = "btn btn-md btn-outline-light";
                    action.Click += action_Click;
                    actionType.Controls.Add(action);
                    row.Cells.Add(studentID);
                    row.Cells.Add(assignmentNumber);
                    row.Cells.Add(assignType);
                    row.Cells.Add(assignGrade);
                    row.Cells.Add(actionType);
                    assignmentsTable.Rows.Add(row);

                }


            }
        }

        protected void button_Click(object sender, EventArgs e)
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


        protected void action_Click(object sender, EventArgs e)
        {
            string[] keys = (((Button)sender).ID).Split(',');
            int sid = Int32.Parse(keys[0]);
            int assignNumber = Int32.Parse(keys[1]);
            string type = keys[2];
            int insID = Int32.Parse(Session["user"].ToString());
            int cid = Int32.Parse(Session["viewSubmittedAssignment"].ToString());

            string input = Interaction.InputBox("Prompt", "Grade Student", "", 500, 150);
            Decimal grade = -1;
            Boolean check = Decimal.TryParse(input, out grade);
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            if (!check)
            {
                System.Windows.MessageBox.Show("Invalid Grade");
            }
            else
            {

                SqlCommand gradeAssignment = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
                gradeAssignment.CommandType = CommandType.StoredProcedure;
                gradeAssignment.Parameters.Add(new SqlParameter("@cid", cid));
                gradeAssignment.Parameters.Add(new SqlParameter("@instrId", insID));
                gradeAssignment.Parameters.Add(new SqlParameter("@assignmentNumber", assignNumber));
                gradeAssignment.Parameters.Add(new SqlParameter("@type", type));
                gradeAssignment.Parameters.Add(new SqlParameter("@sid", sid));
                gradeAssignment.Parameters.Add(new SqlParameter("@grade", grade));
                try
                {
                    gradeAssignment.ExecuteNonQuery();
                    Response.Redirect("viewSubmittedAssignments.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("no can");
                }
            }

            conn.Close();
        }
    }
}
