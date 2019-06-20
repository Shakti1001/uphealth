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
    public partial class LoginHome : System.Web.UI.Page
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
                //Response.buffer = True;
                //Response.expireAbsolute = DateTime.now().AddDay(-1);
                //Response.Expire = -1500;
                //Response.CacheControl = "no-cache";
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                //if (Label2.Text == "")
                //    {
                //        Response.Redirect("~/login.aspx");
                //    }

            }
        }

        protected void Llogout_Click(object sender, EventArgs e)
        {
            //cl.lout();
            Session.Remove("fullname");
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        protected void Hsec_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/proforma/p1.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void Msec_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/Proforma2/Option.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }

        }
        protected void Psec_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://uphealth.up.nic.in/ems/login.asp");//  ~/Underpr.aspx            ~/payrole/payroleselect.aspx
            //http://uphealth.up.nic.in/ems/login.asp

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //javascript:history.go(-1)

            bool i;
            i = cl.checklavel(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/home.aspx");
            }
            else
            {
                Response.Redirect("~/Uhome.aspx");
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payroll/login.asp?a=" + Uidt.Text + "");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://uphealth.up.nic.in/ems/login.asp");
        }
        protected void Newpay_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checklavel(Uidt.Text);
            if (i == true)
            {
                if ((string)Session["lavel"] != "2")
                {
                    Response.Redirect("~/payrole/payrolehome.aspx");
                }

            }
            else
            {
                Response.Redirect("~/payrole/SaldetH.aspx");

            }
        }
    /*    protected void mpr_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checklavel(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/payrole/mprreports.aspx");
            }
            else
            {
                Response.Redirect("~/payrole/mpr.aspx");
            }

        }*/
        protected void Link_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkR(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/payrole/payrolehome.aspx");

            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            bool i;
            i = cl.checklavel(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/Administrator/home.aspx");
            }
            else
            {
                Response.Redirect("~/Administrator/Uhome.aspx");
            }
        }
    }
}