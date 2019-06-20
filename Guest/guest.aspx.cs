using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.Guest
{
    public partial class guest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Red1(object sender,EventArgs e)
        {
            Response.Redirect("doctor'sPosting.aspx");

        }
        public void Red2(object sender, EventArgs e)
        {
            Response.Redirect("Proformachoice.aspx");

        }
        public void Red3(object sender, EventArgs e)
        {
            Response.Redirect("genpaySlip.aspx");

        }
        public void Red4(object sender, EventArgs e)
        {
            Response.Redirect("P2.aspx");

        }
        public void Red5(object sender, EventArgs e)
        {
            Response.Redirect("progressreport.aspx");

        }
        public void Red6(object sender, EventArgs e)
        {
            Response.Redirect("yearrepo.aspx");

        }
    }
}