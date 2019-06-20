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

namespace NewWebApp.paramedicalstaff
{
    public partial class parahome : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];

            }

        }
        protected void Hsec_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap1home.aspx");//parap1home.aspx
        }
        protected void Msec_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2option.aspx");//~/paramedicalstaff/p2/parap2option.aspx
        }

        protected void Psec_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checklavel(Uidt.Text);
            if (i == true)
            {

                Response.Redirect("~/pmdpayrole/pmdSaldetH.aspx");
            }
            else
            {
                Response.Redirect("~/pmdpayrole/pmdSaldetH.aspx");
                //Response.Redirect("Underpr.aspx");
                //mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checklavel(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/Administrator/home.aspx");//
            }
            else
            {
                Response.Redirect("~/Administrator/Uhome.aspx");
            }
        }
    

    }
}