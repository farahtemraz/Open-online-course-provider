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
    public partial class studentCreditCards : System.Web.UI.Page
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

        protected void addAnotherCreditCard_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int studentID = Int32.Parse(Session["user"].ToString());
            String cardHolderName = cardName.Text;
            String number = cardNumber.Text;
            String Cvv = cvv.Text;
            DateTime expiration = expirationDate.SelectedDate;
            conn.Open();

            SqlCommand addCreditCard = new SqlCommand("addCreditCard", conn);
            addCreditCard.CommandType = CommandType.StoredProcedure;
            addCreditCard.Parameters.Add(new SqlParameter("@sid", studentID));
            addCreditCard.Parameters.Add(new SqlParameter("@number", number));
            addCreditCard.Parameters.Add(new SqlParameter("@cardHolderName", cardHolderName));
            addCreditCard.Parameters.Add(new SqlParameter("@expiryDate", expiration));
            addCreditCard.Parameters.Add(new SqlParameter("@cvv", Cvv));

            try
            {
                addCreditCard.ExecuteNonQuery();
                MessageBox.Show("credit card added successfully");
                Response.Redirect("studentCreditCards.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid info!");
            }

            conn.Close();
        }

        protected void homepage_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int studentID = Int32.Parse(Session["user"].ToString());
            String cardHolderName = cardName.Text;
            String number = cardNumber.Text;
            String Cvv = cvv.Text;
            DateTime expiration = expirationDate.SelectedDate;
            conn.Open();

            SqlCommand addCreditCard = new SqlCommand("addCreditCard", conn);
            addCreditCard.CommandType = CommandType.StoredProcedure;
            addCreditCard.Parameters.Add(new SqlParameter("@sid", studentID));
            addCreditCard.Parameters.Add(new SqlParameter("@number", number));
            addCreditCard.Parameters.Add(new SqlParameter("@cardHolderName", cardHolderName));
            addCreditCard.Parameters.Add(new SqlParameter("@expiryDate", expiration));
            addCreditCard.Parameters.Add(new SqlParameter("@cvv", Cvv));

            try
            {
                addCreditCard.ExecuteNonQuery();
                MessageBox.Show("credit card added successfully");
                Response.Redirect("home.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid info!");
            }

            conn.Close();
        }
    }
}