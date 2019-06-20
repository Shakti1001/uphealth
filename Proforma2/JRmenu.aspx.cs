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

namespace NewWebApp.Proforma2
{
    public partial class JRmenu : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
            }

        }
       
        protected void joinlink_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Session.Add("pass", "Join");
                Response.Redirect("~/Proforma2/namesearch.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void rellink_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Session.Add("pass", "RELRET");
                Response.Redirect("~/Proforma2/namesearch.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void RetLink_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Session.Add("pass", "RELRET");
                Response.Redirect("~/Proforma2/namesearch.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void EJLink_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Session.Add("pass", "Join");
                Response.Redirect("~/Proforma2/Editsearch.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void ERLink_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Session.Add("pass", "RELRET");
                Response.Redirect("~/Proforma2/Editsearch.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/Option.aspx");
        }
    }
}