using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace NewWebApp.healthPIS
{
    public partial class login : System.Web.UI.Page
    {
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
            string st="shaktikripamishra@gmail.com";
            String str = "select iduser from loginuser where username='"+st+"'";
            try
            {
                
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(str,con);
                int a= Convert.ToInt32(cmd.ExecuteNonQuery());
                Label2.Text = a.ToString();
               
            }
            catch (SqlException se)
            {
                Console.Write(se.ToString());
            }
            

            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

    }
}
