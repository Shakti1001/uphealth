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

namespace NewWebApp.payrole
{
    public partial class PayRopt : System.Web.UI.Page
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

            Response.Redirect("~/payrole/PayRoption.aspx");
        }
        protected void GPFSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = GPFSch_link.Text;

            Response.Redirect("~/payrole/PayRoption.aspx");
        }
        protected void GISSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = GISSch_link.Text;

            Response.Redirect("~/payrole/PayRoption.aspx");
        }
        protected void Incometax_link_Click(object sender, EventArgs e)
        {
            Session["report"] = Incometax_link.Text;

            Response.Redirect("~/payrole/PayRoption.aspx");

        }
        protected void GVRSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = GVRSch_link.Text;

            Response.Redirect("~/payrole/PayRoption.aspx");
        }
        protected void ElecBillSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = ElecBillSch_link.Text;

            Response.Redirect("~/payrole/PayRoption.aspx");
        }
        protected void HRRSch_link_Click(object sender, EventArgs e)
        {
            Session["report"] = HRRSch_link.Text;

            Response.Redirect("~/payrole/PayRoption.aspx");
        }
        protected void BankStatment_link_Click(object sender, EventArgs e)
        {
            Session["report"] = BankStatment_link.Text;

            Response.Redirect("~/payrole/PayRoption.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payrole/SaldetH.aspx");
        }
    }
}