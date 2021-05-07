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
    public partial class studentViewPromocodes : System.Web.UI.Page
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
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand viewPromocodes = new SqlCommand("viewPromocode", conn);
                int sid = Int32.Parse(Session["user"].ToString());
                viewPromocodes.Parameters.Add(new SqlParameter("@sid", sid));
                viewPromocodes.CommandType = CommandType.StoredProcedure;

                conn.Open();
                try
                {
                    viewPromocodes.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid info!");
                }

                SqlDataReader rdr = viewPromocodes.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    String code = rdr.GetString(rdr.GetOrdinal("code"));
                    DateTime issueDate = rdr.GetDateTime(rdr.GetOrdinal("isuueDate"));
                    DateTime expiryDate = rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                    Decimal discount = rdr.GetDecimal(rdr.GetOrdinal("discount"));

                    TableRow row = new TableRow();
                    TableCell codeCell = new TableCell();
                    codeCell.Text = code.ToString();
                    TableCell discountCell = new TableCell();
                    discountCell.Text = discount.ToString();
                    TableCell issueDateCell = new TableCell();
                    issueDateCell.Text = issueDate.ToString();
                    TableCell expiryDateCell = new TableCell();
                    expiryDateCell.Text = expiryDate.ToString();

                    row.Cells.Add(codeCell);
                    row.Cells.Add(discountCell);
                    row.Cells.Add(issueDateCell);
                    row.Cells.Add(expiryDateCell);
                    studentPromocodesTable.Rows.Add(row);
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