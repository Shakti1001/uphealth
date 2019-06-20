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

namespace NewWebApp.pmdpayrole
{
    public partial class pmdPayRopt : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string opt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                if ((string)Session["ddoname"] != null && (string)Session["ddopid"] != null)
                {

                    DDOText.Text = (string)Session["ddoname"];
                    DDOIDLab.Text = (string)Session["ddopid"];



                }
                else
                {
                    this.MSGLabel.Text = "Please select Proper One...";
                }


            }

        }

       

        protected void paybill_link_Click(object sender, EventArgs e)
        {
            Session["report"] = paybill_link.Text;
            //opt = 1;
            //opt = "1";
            //Response.Redirect("~/pmdpayrole/pmdpayreport/pmdPayRoption.aspx?option="+opt);

            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");

        }
        protected void GPFSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = GPFSch_link.Text;
            opt = "2";
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx?option=" + opt);
        }
        protected void GISSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = GISSch_link.Text;
            //opt = "3";
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");
        }
        protected void Incometax_link_Click(object sender, EventArgs e)
        {
            Session["report"] = Incometax_link.Text;
            ////opt = 4;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");

        }
        protected void GVRSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = GVRSch_link.Text;
            //opt = 5;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");
        }
        protected void ElecBillSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = ElecBillSch_link.Text;
            //opt = 6;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");
        }
        protected void HRRSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = HRRSch_link.Text;
            //opt = 7;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");
        }
        protected void BankStatment_link_Click(object sender, EventArgs e)
        {
            Session["report"] = BankStatment_link.Text;
            //opt = 8;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");
        }
        protected void gpf4schedul_Click(object sender, EventArgs e)
        {
            Session["report"] = gpf4schedul.Text;
            opt = "8";
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx?option=" + opt);
        }
        protected void hbashdl_Click(object sender, EventArgs e)
        {
            Session["report"] = hbashdl.Text;
            //opt = 8;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");
        }
        protected void vehsdl_Click(object sender, EventArgs e)
        {
            Session["report"] = vehsdl.Text;
            //opt = 8;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");
        }
        protected void vehsdl1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pmdPayRoption.aspx");
        }
        protected void licsdl_Click(object sender, EventArgs e)
        {

            Session["report"] = licsdl.Text;
            //opt = 8;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");
        }
        //protected void licsdl0_Click(object sender, EventArgs e)
        //{
        //    Session["report"] = licsdl.Text;
        //    //opt = 8;
        //    Response.Redirect("~/pmdpayrole/pmdpayreport/pmdPayRoption.aspx");
        //}
        protected void vinst_Click(object sender, EventArgs e)
        {
            Session["report"] = vinst.Text;
            //opt = 8;
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");

        }
        protected void HBAinst_Click(object sender, EventArgs e)
        {
            Session["report"] = HBAinst.Text;

            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx");

        }
        protected void prs_Click(object sender, EventArgs e)
        {
            Session["report"] = prs.Text;
            opt = "9";
            Response.Redirect("~/pmdpayrole/pmdPayRoption.aspx?option=" + opt);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/pmdSaldetH.aspx");
        }
    }
}