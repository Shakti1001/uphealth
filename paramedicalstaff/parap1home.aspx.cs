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
    public partial class parap1home : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
            }
        }

        protected void PRES_Click(object sender, EventArgs e)
        {

        }


        protected void EDITHR_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkA(Uidt.Text);
            if (i == true)
            {
                Session.Add("val", "E");
                Response.Redirect("~/paramedicalstaff/parap1recadd.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void HREP_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/paramedicalstaff/paraSearchVaccant.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }

        }
       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parahome.aspx");
        }
    }
}