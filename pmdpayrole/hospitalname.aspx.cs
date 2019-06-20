using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.pmdpayrole
{
    public partial class hospitalname : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            c.gv(GridView1, "SELECT  isnull(hospitalname_1.hname,0) as[AdministrativeUnit], hospitalname.hname AS [HospitalName]  FROM         hospitalname LEFT OUTER JOIN hospitalname AS hospitalname_1 ON hospitalname.adminunit = hospitalname_1.sno WHERE     (hospitalname.ddoid = '" + Session["iduser"] + "') order by AdministrativeUnit,HospitalName ");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/adminunit.aspx");
        }
    }
}