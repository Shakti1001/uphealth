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

namespace NewWebApp.TransferSec
{
    public partial class TRmenu : System.Web.UI.Page
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
       



        protected void TransferLink_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Session.Add("pass", "Trans");
                Response.Redirect("~/TransferSec/namesearch.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void TransferOrLink_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Session.Add("pass", "Trans");
                Response.Redirect("~/TransferSec/TRmaster.aspx");
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

                Response.Redirect("~/TransferSec/TransferList.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void SOtr_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {

                Response.Redirect("~/TransferSec/StatusTrList.aspx");
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