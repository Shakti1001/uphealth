using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.paramedicalstaff
{
    public partial class MonitoringReport : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                c.gv(GridView1, " SELECT  hospitaldistrict.districtname as[District], COUNT(PMDCposted.idno) AS [No Of P2 Entered] FROM PMDCposted INNER JOIN hospitaldistrict ON PMDCposted.districtid = hospitaldistrict.districtid GROUP BY PMDCposted.districtid, hospitaldistrict.districtname ORDER BY COUNT(PMDCposted.idno)");

                c.grdv2(GridView2, "select COUNT(PMDCposted.idno) as[Total] from pmdcposted");


                //c.grdv2(GridView2,"select COUNT(PMDCposted.idno) as[Total] from pmdcposted");

            }


        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/home.aspx");
        }
    }
}