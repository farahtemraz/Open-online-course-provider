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
    public partial class courseAssignments : System.Web.UI.Page
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
            else
            {
                int cid = Int32.Parse(Session["courseAssignments"].ToString());
                int sid = Int32.Parse(Session["user"].ToString());
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand viewAssignments = new SqlCommand("viewAssign", conn);
                viewAssignments.CommandType = CommandType.StoredProcedure;
                viewAssignments.Parameters.Add(new SqlParameter("@courseId", cid));
                viewAssignments.Parameters.Add(new SqlParameter("@Sid", sid));

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
                    int assignNo = rdr.GetInt32(rdr.GetOrdinal("number"));
                    String type = rdr.GetString(rdr.GetOrdinal("type"));
                    int fullGrade = rdr.GetInt32(rdr.GetOrdinal("fullGrade"));
                    Decimal weight = rdr.GetDecimal(rdr.GetOrdinal("weight"));
                    DateTime deadline = rdr.GetDateTime(rdr.GetOrdinal("deadline"));
                    String content = "";

                    if (rdr.IsDBNull(rdr.GetOrdinal("content")))
                    {
                        content = "No Content";
                    }
                    else
                    {
                        content = rdr.GetString(rdr.GetOrdinal("content"));
                    }
                    TableRow row = new TableRow();
                    TableCell typeCell = new TableCell();
                    typeCell.Text = type.ToString();
                    TableCell assignNoCell = new TableCell();
                    assignNoCell.Text = assignNo.ToString();
                    TableCell fullGradeCell = new TableCell();
                    fullGradeCell.Text = fullGrade.ToString();
                    TableCell weightCell = new TableCell();
                    weightCell.Text = weight.ToString();
                    TableCell contentCell = new TableCell();
                    contentCell.Text = content.ToString();
                    TableCell deadlineCell = new TableCell();
                    deadlineCell.Text = deadline.ToString();

                    row.Cells.Add(typeCell);
                    row.Cells.Add(assignNoCell);
                    row.Cells.Add(fullGradeCell);
                    row.Cells.Add(weightCell);
                    row.Cells.Add(contentCell);
                    row.Cells.Add(deadlineCell);
                    courseAssignmentsTable.Rows.Add(row);
                }
                conn.Close();
            }
        }

       
    }
}