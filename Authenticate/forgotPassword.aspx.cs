using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
namespace NewWebApp.Authenticate
{
    public partial class forgotPassword : System.Web.UI.Page
    {
        SqlCommand cmd;
        DataTable dt;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter adp;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            con.Open();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            Label1.Visible = false;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           


        }
    }
}