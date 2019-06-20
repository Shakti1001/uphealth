using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NewWebApp.payrole
{
    public partial class mprreports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {



            Response.Redirect("~/payrole/progressreport.aspx");





        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payrole/mprqualname.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payrole/MonthlyMpr.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payrole/dscombind.aspx");
        }
    }
}