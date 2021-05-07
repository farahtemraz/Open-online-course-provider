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
    public partial class adminPromocodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["type"].ToString().Equals("1"))
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
                conn.Open();
                SqlCommand viewPromocodes = new SqlCommand("select * from Promocode", conn);
                SqlDataReader rdr = viewPromocodes.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    string code = rdr.GetString(rdr.GetOrdinal("code"));
                    DateTime issueDate = rdr.GetDateTime(rdr.GetOrdinal("isuueDate"));
                    DateTime expiryDate = rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                    Decimal discount = rdr.GetDecimal(rdr.GetOrdinal("discount"));
                    TableRow row = new TableRow();

                    TableCell promoCode = new TableCell();
                    promoCode.Text = code.ToString();

                    TableCell issueTime = new TableCell();
                    issueTime.Text = issueDate.ToString();

                    TableCell expiryTime = new TableCell();
                    expiryTime.Text = expiryDate.ToString();

                    TableCell discountAmount = new TableCell();
                    discountAmount.Text = discount.ToString();

                    TableCell actionType = new TableCell();
                    Button issueButton = new Button();
                    issueButton.Text = "Issue to Student";
                    issueButton.CssClass = "btn btn-md btn-outline-light";
                    issueButton.Click += issueButton_Click;
                    issueButton.ID = code;
                    actionType.Controls.Add(issueButton);

                    row.Cells.Add(promoCode);
                    row.Cells.Add(issueTime);
                    row.Cells.Add(expiryTime);
                    row.Cells.Add(discountAmount);
                    row.Cells.Add(actionType);

                    promocodesTable.Rows.Add(row);
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
                Response.Redirect("adminHome.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Invalid info");
            }

            conn.Close();
        }

        protected void addPromo_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int adminID = Int32.Parse(Session["user"].ToString());
            String code = promo.Text;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = expiryDate.SelectedDate;
            decimal discountPercentage = -1;
            Boolean check = Decimal.TryParse(discount.Text, out discountPercentage);
            conn.Open();
            SqlCommand addPromocode = new SqlCommand("AdminCreatePromocode", conn);
            addPromocode.CommandType = CommandType.StoredProcedure;
            conn.InfoMessage += Conn_InfoMessage;

            if (check && discountPercentage >= 0 && !string.IsNullOrEmpty(promo.Text))
            {

                addPromocode.Parameters.Add(new SqlParameter("@code", code));
                addPromocode.Parameters.Add(new SqlParameter("@isuueDate", issueDate));
                addPromocode.Parameters.Add(new SqlParameter("@expiryDate", expirationDate));
                addPromocode.Parameters.Add(new SqlParameter("@discount", discountPercentage));
                addPromocode.Parameters.Add(new SqlParameter("@adminId", adminID));
                try
                {
                    addPromocode.ExecuteNonQuery();
                    MessageBox.Show("Promocode added");
                    Response.Redirect("adminPromocodes.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot create promocode");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid information");
            }



            conn.Close();
        }

        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        protected void issueButton_Click(object sender, EventArgs e)
        {
            string code = ((Button)sender).ID;
            string input = Interaction.InputBox("Prompt", "Student ID", "", 500, 150);
            int sid = -1;
            Boolean check = Int32.TryParse(input, out sid);
            if (!check)
            {
                MessageBox.Show("Invalid Student ID");
            }
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand issuePromocode = new SqlCommand("AdminIssuePromocodeToStudent", conn);
                issuePromocode.CommandType = CommandType.StoredProcedure;
                issuePromocode.Parameters.Add(new SqlParameter("@pid", code));
                issuePromocode.Parameters.Add(new SqlParameter("@sid", sid));
                conn.InfoMessage += Conn_InfoMessage;
                try
                {
                    issuePromocode.ExecuteNonQuery();
                    MessageBox.Show("Promocode Issued");
                    Response.Redirect("adminPromocodes.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not issue promocode to student");
                }
            }
        }
    }
}