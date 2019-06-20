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
    public partial class parap2ReportOption : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
            }
        }

       
        protected void FactSheetCh_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/paramedicalstaff/paraproformachoice.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }


        }
        protected void CurrentL_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/paramedicalstaff/paraCurrentlistchoice.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }

        }
        protected void DyQ_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //Proforma2/totaltimeinhospital.aspx
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/paramedicalstaff/paratotaltimeinhospital.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void Linkalpha_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/paramedicalstaff/PMDP2alpha.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/P2Search.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2option.aspx");
        }
    }
}