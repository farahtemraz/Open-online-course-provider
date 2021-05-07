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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["type"] = -1;
        }

        protected void registerstudent(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String first = firstname.Text;
            String last = lastname.Text;
            String mail = email.Text;
            String add = address.Text;
            String pass = password.Text;
            Boolean value = Boolean.Parse(gender.SelectedItem.Value.ToString());


            SqlCommand registerproc = new SqlCommand("studentRegister", conn);
            registerproc.CommandType = CommandType.StoredProcedure;
            registerproc.Parameters.Add(new SqlParameter("@first_name", first));
            registerproc.Parameters.Add(new SqlParameter("@last_name", last));
            registerproc.Parameters.Add(new SqlParameter("@email", mail));
            registerproc.Parameters.Add(new SqlParameter("@password", pass));
            if (string.IsNullOrEmpty(address.Text))
            {
                registerproc.Parameters.Add(new SqlParameter("@address", DBNull.Value));
            }
            else
            {
                registerproc.Parameters.Add(new SqlParameter("@address", add));
            }

            registerproc.Parameters.Add(new SqlParameter("@gender", value));

            Session["type"] = 2;

            conn.Open();
            try
            {
                registerproc.ExecuteNonQuery();
                MessageBox.Show("Registered successfully");
                Response.Redirect("mobile.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid info");
            }


            SqlCommand getid = new SqlCommand("select id from Users where email =@email", conn);
            getid.Parameters.AddWithValue("@email", mail);
            int id = Convert.ToInt32(getid.ExecuteScalar());
            conn.Close();

            Session["user"] = id;
            
        }
 

        protected void registerinstructor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String first = firstname.Text;
            String last = lastname.Text;
            String mail = email.Text;
            String add = address.Text;
            String pass = password.Text;
            Boolean value = Boolean.Parse(gender.SelectedItem.Value.ToString());



            SqlCommand registerproc = new SqlCommand("InstructorRegister", conn);
            registerproc.CommandType = CommandType.StoredProcedure;
            registerproc.Parameters.Add(new SqlParameter("@first_name", first));
            registerproc.Parameters.Add(new SqlParameter("@last_name", last));
            registerproc.Parameters.Add(new SqlParameter("@email", mail));
            registerproc.Parameters.Add(new SqlParameter("@password", pass));
            registerproc.Parameters.Add(new SqlParameter("@address", add));
            registerproc.Parameters.Add(new SqlParameter("@gender", value));

            Session["type"] = 0;

            conn.Open();
            try
            {
                registerproc.ExecuteNonQuery();
                MessageBox.Show("Registered Successfully");
                Response.Redirect("mobile.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch
            {
                MessageBox.Show("Invalid info!");

            }
            SqlCommand getid = new SqlCommand("select id from Users where email =@email" , conn);
            getid.Parameters.AddWithValue("@email", mail);
            int id = Convert.ToInt32(getid.ExecuteScalar());
            conn.Close();

           
            Session["user"] = id;
         
        }
    }
}