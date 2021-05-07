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
    public partial class courseInformation : System.Web.UI.Page
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
            } else {
                if (IsPostBack)
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    enroll.Visible = false;
                    int idCourse = Int32.Parse(Session["viewedCourseID"].ToString());
                    chooseYourInstructor.Text = "Choose your Instructor: ";

                    Label lineBreak = new Label();
                    lineBreak.Text = " <br/>";
                    courseInfo.Controls.Add(lineBreak);
                    courseInfo.Controls.Add(lineBreak);

                    SqlCommand getInstructors = new SqlCommand("SELECT insid,firstName, lastName FROM InstructorTeachCourse ITC INNER JOIN Users U ON ITC.insid = U.id WHERE cid = @cid ", conn);
                    getInstructors.Parameters.AddWithValue("@cid", idCourse);
                    SqlDataReader rdr = getInstructors.ExecuteReader(CommandBehavior.CloseConnection);



                    while (rdr.Read())
                    {
                        String instructorFirst = rdr.GetString(rdr.GetOrdinal("firstName"));
                        String instructorLast = rdr.GetString(rdr.GetOrdinal("lastName"));
                        String fullName = instructorFirst + " " + instructorLast;
                        ListItem instructorValue = new ListItem(fullName);
                        instructorValue.Value = rdr.GetInt32(rdr.GetOrdinal("insid")).ToString();
                        instructorsList.Items.Add(instructorValue);
                    }
                    Session["selectedInstructor"] = instructorsList.SelectedValue;
                    submitButton.Visible = true;
                    instructorsList.Visible = true;
                }
                else
                {
                    submitButton.Visible = false;
                    instructorsList.Visible = false;
                    int id = Int32.Parse(Session["viewedCourseID"].ToString());
                    string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand getCourseInformation = new SqlCommand("courseInformation", conn);
                    getCourseInformation.CommandType = CommandType.StoredProcedure;
                    getCourseInformation.Parameters.Add(new SqlParameter("@id", id));
                    try
                    {
                        getCourseInformation.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("No info");
                    }
                    SqlDataReader rdr = getCourseInformation.ExecuteReader(CommandBehavior.CloseConnection);

                    while (rdr.Read())
                    {
                        String name = rdr.GetString(rdr.GetOrdinal("name"));
                        int noOfCreditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                        Decimal coursePrice = rdr.GetDecimal(rdr.GetOrdinal("price"));
                        String firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                        String lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                        String courseDescription = "";

                        if (rdr.IsDBNull(rdr.GetOrdinal("courseDescription")))
                        {
                            courseDescription = "No Description";
                        }
                        else
                        {
                            courseDescription = rdr.GetString(rdr.GetOrdinal("courseDescription"));
                        }
                        courseID.Text = id.ToString();
                        courseName.Text = name;
                        creditHours.Text = noOfCreditHours.ToString();
                        instructorFirstName.Text = firstName;
                        instructorLastName.Text = lastName;
                        price.Text = coursePrice.ToString();
                        description.Text = courseDescription;
                    }

                    conn.Close();
                }
            }
        }

        protected void enroll_Click(object sender, EventArgs e)
        {
            
        }


        protected void submit_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int studentID = Int32.Parse(Session["user"].ToString());
            int courseID = Int32.Parse(Session["viewedCourseID"].ToString());
            int instID = Int32.Parse(instructorsList.SelectedValue.ToString());
            SqlCommand enrollInCourse = new SqlCommand("enrollInCourse", conn);
            enrollInCourse.CommandType = CommandType.StoredProcedure;
            enrollInCourse.Parameters.Add(new SqlParameter("@sid", studentID));
            enrollInCourse.Parameters.Add(new SqlParameter("@cid", courseID));
            enrollInCourse.Parameters.Add(new SqlParameter("@instr", instID));
            conn.InfoMessage += Conn_InfoMessage;

            conn.Open();
            try
            {
                enrollInCourse.ExecuteNonQuery();
                MessageBox.Show("enrolled successfully");
                Response.Redirect("home.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid info!");
            }

            conn.Close();
        }

        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        protected void instructorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedInstructor"] = instructorsList.SelectedValue;
        }
    }
}