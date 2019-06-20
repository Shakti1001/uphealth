using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.Administrator
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                /*if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); //jump to first page for login
                }*/
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                Response.Expires = -1500;
                Response.CacheControl = "no-cache";
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];

            }
        }
        protected void ADMIN_Click(object sender, EventArgs e)
        {
            if ((string)Session["iduser"] == "76" || (string)Session["iduser"] == "80")
            {
                Lmsg.Visible = false;
                Response.Redirect("~/Administrator/Ad1.aspx");
            }
            else
            {
                Lmsg.Visible = true;
                Lmsg.Text = "You Have No Permission For This Module";
            }
        }
        protected void medicalsection_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginHome.aspx");
            //Response.Redirect("~/Proforma2/specialization.aspx");
        }
        protected void Paramedical_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parahome.aspx");//Paramedical.aspx//Proforma2/Option.aspx
        }


        protected void ucp_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeUpass.aspx?iduser=" + Uidt.Text + "");

        }

        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{

        //}
        protected void Attendance_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonitoringReport.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/MonitoringReport.aspx");
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/GovernmentOrders.aspx");
        }
    }
}