﻿using System;
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
    public partial class viewGrades : System.Web.UI.Page
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

        protected void viewAssignmentGrade_Click(object sender, EventArgs e)
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

            if (!check0 || !check1 || cid <= 0 || number < 0)
            {
                MessageBox.Show("Please enter valid information");
            }
            else
            {
                SqlCommand viewGrade = new SqlCommand("viewAssignGrades", conn);
                viewGrade.CommandType = CommandType.StoredProcedure;
                viewGrade.Parameters.Add(new SqlParameter("@assignType", type));
                viewGrade.Parameters.Add(new SqlParameter("@assignnumber", number));
                viewGrade.Parameters.Add(new SqlParameter("@sid", sid));
                viewGrade.Parameters.Add(new SqlParameter("@cid", cid));
                SqlParameter assignGrade = viewGrade.Parameters.Add("@assignGrade", SqlDbType.Int);

                assignGrade.Direction = ParameterDirection.Output;
                try
                {
                    viewGrade.ExecuteNonQuery();
                    grade.Text = "Grade:   ";
                    if (assignGrade.Value.ToString().Equals(""))
                    {
                        gradeOutput.Text = "No Grade";
                    }
                    else
                    {
                        gradeOutput.Text = assignGrade.Value.ToString();
                    }
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