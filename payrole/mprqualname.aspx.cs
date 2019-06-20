using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.payrole
{
    public partial class mprqualname : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                c.ddl2(ddlddo, "select * from ucreate order by username", "username", "iduser");
                c.ddl3(ddlmonth, "select * from pay_month", "monthname", "monthid");
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlddo.SelectedIndex == 0)
            {
                c.gv(GridView1, "SELECT  mprfinal1.name + ' , ' + spqual.spqual AS NAME, mprfinal1.month, mprfinal1.year, mprfinal1.post, mprfinal1.hname, mprfinal1.poposting, mprfinal1.opd, mprfinal1.ot, mprfinal1.Postmortem, mprfinal1.vip, mprfinal1.jail, mprfinal1.emergency, mprfinal1.mela, mprfinal1.cl, mprfinal1.court, mprfinal1.el, mprfinal1.Medical, mprfinal1.tour, mprfinal1.gh, mprfinal1.adminwork, mprfinal1.compleave, mprfinal1.compid, mprfinal1.ddoid FROM mprfinal1 INNER JOIN spqual ON mprfinal1.compid = spqual.idno  ORDER BY mprfinal1.name");

            }

            else
            {
                c.gv(GridView1, "SELECT  mprfinal1.name + ' , ' + spqual.spqual AS NAME, mprfinal1.month, mprfinal1.year, mprfinal1.post, mprfinal1.hname, mprfinal1.poposting, mprfinal1.opd, mprfinal1.ot, mprfinal1.Postmortem, mprfinal1.vip, mprfinal1.jail, mprfinal1.emergency, mprfinal1.mela, mprfinal1.cl, mprfinal1.court, mprfinal1.el, mprfinal1.Medical, mprfinal1.tour, mprfinal1.gh, mprfinal1.adminwork, mprfinal1.compleave, mprfinal1.compid, mprfinal1.ddoid FROM mprfinal1 INNER JOIN spqual ON mprfinal1.compid = spqual.idno where ddoid=" + ddlddo.SelectedValue + " and month=" + ddlmonth.SelectedValue + " and year='2013' ORDER BY mprfinal1.name");
                if (GridView1.Rows.Count < 1)
                {
                    lblmess.Visible = true;
                    lblmess.Text = "No Record Found...";

                }
                else
                {
                    lblmess.Visible = false;

                }
            }
        }
    }
}