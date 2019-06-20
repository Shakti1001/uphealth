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


namespace NewWebApp.proforma
{
    public partial class HRephome : System.Web.UI.Page
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
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
            }

        }

        protected void ListHOS_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkA(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/proforma/onlyhreport.aspx");//TotHospital
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void DetPOST_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkA(Uidt.Text);
            if (i == true)
            {
                Session.Add("REP", "P1vsP2");
                Response.Redirect("~/proforma/ListOfHospital.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void VacPOST_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkA(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/proforma/SearchVaccant.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
       
        protected void P1det_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkA(Uidt.Text);
            if (i == true)
            {
                Session.Add("REP", "P1Detail");
                Response.Redirect("~/proforma/ListOfHospital.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/proforma/p1.aspx");
        }
    }
}