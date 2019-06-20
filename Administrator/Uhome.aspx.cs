using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace NewWebApp.Administrator
{
    public partial class Uhome : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                Response.Expires = -1500;
                Response.CacheControl = "no-cache";
                this.Fnamet.Text = (string)Session["fullname"];
                this.Uidt.Text = (string)Session["iduser"];
            }

        }

        protected void medicalsection_Click(object sender, EventArgs e)
        {
            if ((string)Session["UsDisId"] != null)
            {
                Response.Redirect("~/Administrator/LoginHome.aspx");
            }
        }
        protected void Paramedical_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parahome.aspx");
        }
        protected void ucp_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("ChangeUpass.aspx");

        }
    }
}