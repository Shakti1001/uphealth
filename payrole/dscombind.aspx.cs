using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.payrole
{
    public partial class dscombind : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((string)Session["lavel"] == "2") || ((string)Session["lavel"] == "1"))
                {
                    lblddo.Visible = true;
                    lblddo.Text = "DDo Name ::";
                    ddlddo.Visible = true;
                    c.ddl5(ddlddo, "select * from ucreate order by username", "username", "iduser");
                    //lblhname.Visible = true;
                    //lblhname.Text = "Hospital Name ::";
                    //ddlhname.Visible = true;
                }
                else
                {

                }

                c.ddl3(ddlmonth, "select * from pay_month", "monthname", "monthid");
                //lblmess.Visible = false;

            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlddo.SelectedIndex == 0)
            {
                c.gv(GridView1, "SELECT hospitaldistrict.districtname as[District Name],calulatedsalary.ddoid as[DDO Id],Ucreate.username as [DDO Name],COUNT(DISTINCT calulatedsalary.idno) AS [No of SALARY Records], COUNT(DISTINCT mpr.compid) AS [No of Dairy Records] FROM calulatedsalary INNER JOIN Ucreate ON calulatedsalary.ddoid = Ucreate.iduser INNER JOIN mpr ON Ucreate.iduser = mpr.ddoid INNER JOIN hospitaldistrict ON Ucreate.DisId = hospitaldistrict.districtid WHERE (calulatedsalary.Smonth = " + ddlmonth.SelectedValue + ") AND (calulatedsalary.Syear = 2013) AND (MONTH(mpr.date) = 8) AND (YEAR(mpr.date) = 2013) GROUP BY calulatedsalary.ddoid, Ucreate.username, hospitaldistrict.districtname ORDER BY hospitaldistrict.districtname");
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
            else
            {
                c.gv(GridView1, "SELECT hospitaldistrict.districtname as[District Name],calulatedsalary.ddoid as[DDO Id],Ucreate.username as [DDO Name],COUNT(DISTINCT calulatedsalary.idno) AS [No of SALARY Records], COUNT(DISTINCT mpr.compid) AS [No of Dairy Records] FROM calulatedsalary INNER JOIN Ucreate ON calulatedsalary.ddoid = Ucreate.iduser INNER JOIN mpr ON Ucreate.iduser = mpr.ddoid INNER JOIN hospitaldistrict ON Ucreate.DisId = hospitaldistrict.districtid WHERE (calulatedsalary.Smonth = " + ddlmonth.SelectedValue + ") AND (calulatedsalary.Syear = 2013) AND (MONTH(mpr.date) = 8) AND (YEAR(mpr.date) = 2013) and  calulatedsalary.ddoid=" + ddlddo.SelectedValue + " GROUP BY calulatedsalary.ddoid, Ucreate.username, hospitaldistrict.districtname ORDER BY hospitaldistrict.districtname");
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