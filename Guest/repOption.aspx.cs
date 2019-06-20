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


namespace NewWebApp.Guest
{
    public partial class repOption : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //if ((string)Session["iduser"] == null)
                //{
                //    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                //}
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
            }
        }

        protected void Back_Click(object sender, ImageClickEventArgs e)
        {//javascript:history.go(-1)
            Response.Redirect("~/Proforma2/Option.aspx");
        }
        protected void FactSheetCh_Click(object sender, EventArgs e)
        {
            //bool j;
            //j = cl.checkR(Uidt.Text);
            //if (j == true)
            //{
            Response.Redirect("~/newguest/Proformachoice.aspx");
            //}
            //else
            //{
            //    mess.Text = "Access Denied Please Contact to Administrator";
            //}
            //bool i;
            //i = cl.checklavel(Uidt.Text);
            //if (i == true)
            //{//for factsheet
            //    //Response.Redirect("~/Proforma2/ShowProforma.aspx");
            //    Response.Redirect("~/Proforma2/Proformachoice.aspx");
            //}
            //else
            //{//for factsheet
            //    Response.Redirect("~/Proforma2/ShowProformachoiceU.aspx");
            //}

        }
        protected void CurrentL_Click(object sender, EventArgs e)
        {
            //bool j;
            //j = cl.checkR(Uidt.Text);
            //if (j == true)
            //{
            //    //bool i;
            //i = cl.checklavel(Uidt.Text);
            //if (i == true)
            //{//for current posting
            //    Response.Redirect("~/Proforma2/Curlistchoice.aspx");
            //}
            //else
            //{//for current posting
            //    Response.Redirect("~/Proforma2/CShowProformachoiceU.aspx");
            //}
            //Response.Redirect("~/Proforma2/Curlistchoice.aspx");
            Response.Redirect("~/newguest/Currentlistchoice.aspx");
            //}
            //else
            //{
            //    mess.Text = "Access Denied Please Contact to Administrator";
            //}

        }
        protected void DyQ_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Underpr.aspx");
            bool j;
            j = cl.checklavel(Uidt.Text);
            if (j == true)
            {
                //Response.Redirect("~/Proforma2/DynamicSelection.aspx");
                Response.Redirect("~/Proforma2/Dyn.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //Proforma2/totaltimeinhospital.aspx
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/Proforma2/totaltimeinhospital.aspx");
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
                Response.Redirect("~/Proforma2/Proformaalpha.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void CurrALL_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                //Response.Redirect("~/Proforma2/Currlistallprint.aspx");

            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void searchform_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                //Response.Redirect("~/Proforma2/Retiredocprint.aspx");
                //Response.Write("<script language=javascript>window.open('Search.aspx' ,'new_Win');</script>");
                //Response.Write("<script language=javascript>window.open('Search.aspx' ,'new_Win');</script>");//amit
                Response.Redirect("~/Proforma2/Search.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }

        }
        protected void Retlink_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                //Response.Redirect("~/Proforma2/Retiredocprint.aspx");
                Response.Write("<script language=javascript>window.open('Retiredocprint.aspx' ,'new_Win');</script>");
                //Response.Write("<script language=javascript>window.open('Search.aspx' ,'new_Win');</script>");//amit
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void Timebased_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                //Response.Redirect("~/Proforma2/timebased.aspx");
                Response.Write("<script language=javascript>window.open('timebased.aspx' ,'new_Win');</script>");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void Rtdue_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                //Response.Write("<script language=javascript>window.open('timebased.aspx' ,'new_Win');</script>");
                Response.Redirect("Retiredue.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

        protected void click1(object sender, EventArgs e)
        {
            Response.Redirect("transfer.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MIS_report.aspx");
        }
        protected void seniority_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                //bool i;
                //i = cl.checklavel(Uidt.Text);
                //if (i == true)
                //{//for current posting
                //    Response.Redirect("~/Proforma2/Curlistchoice.aspx");
                //}
                //else
                //{//for current posting
                //    Response.Redirect("~/Proforma2/CShowProformachoiceU.aspx");
                //}
                //Response.Redirect("~/Proforma2/Curlistchoice.aspx");
                Response.Redirect("~/proforma/senioritylistchoice.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/dash.aspx");
        }
        protected void CurrentL0_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/OldDoctor/Currentlistchoice.aspx");
        }
    }
}