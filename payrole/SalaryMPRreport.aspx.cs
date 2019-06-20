using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.payrole
{
    public partial class SalaryMPRreport : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                c.ddl3(ddlmonth, "select * from pay_month", "monthname", "monthid");
                //c.gv(GridView1, "SELECT  t1.salaryrecord, t2.mprrecord, t2.i1, dbo.Ucreate.username FROM (SELECT     ddoid, COUNT(idno) AS salaryrecord FROM dbo.calulatedsalary  where Smonth='" + ddlmonth.SelectedValue + "'  GROUP BY ddoid) AS t1 INNER JOIN  dbo.Ucreate ON t1.ddoid = dbo.Ucreate.iduser LEFT OUTER JOIN (SELECT     ddoid AS i1, COUNT(DISTINCT ISNULL(compid, '0')) AS mprrecord  FROM dbo.mpr GROUP BY ddoid) AS t2 ON t1.ddoid = t2.i1 ");

                c.ddl5(ddlddo, "select * from ucreate where usertype=1 order by username", "username", "iduser");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            if (ddlddo.SelectedIndex == 0)
            {

                //c.gv(GridView1, "SELECT t1.smonth, t1.ddoid, t1.salaryrecord, t2.mprrecord, t2.i1, Ucreate.username FROM(SELECT ddoid,smonth, COUNT(idno) AS salaryrecord FROM  calulatedsalary WHERE (Smonth ='" + ddlmonth.SelectedValue + "') AND (Syear = 2013)GROUP BY ddoid,smonth) AS t1 INNER JOIN Ucreate ON t1.ddoid = Ucreate.iduser LEFT OUTER JOIN(SELECT     ddoid AS i1, COUNT(DISTINCT ISNULL(compid, '0')) AS mprrecord FROM   mpr WHERE      (DATEPART(year, date) = 2013) AND (DATEPART(month, date) = '" + ddlmonth.SelectedValue + "') GROUP BY ddoid) AS t2 ON t1.ddoid = t2.i1");

                //c.gv(GridView1, "SELECT t1.smonth, t1.ddoid, t1.salaryrecord, t2.mprrecord, t2.i1, Ucreate.username FROM(SELECT ddoid,smonth, COUNT(idno) AS salaryrecord FROM  calulatedsalary WHERE (Smonth ='" + ddlmonth.SelectedValue + "') AND (Syear = "+ddlyear.SelectedValue+")GROUP BY ddoid,smonth) AS t1 INNER JOIN Ucreate ON t1.ddoid = Ucreate.iduser LEFT OUTER JOIN(SELECT     ddoid AS i1, COUNT(DISTINCT ISNULL(compid, '0')) AS mprrecord FROM   mpr WHERE      (DATEPART(year, date) = 2016) AND (DATEPART(month, date) = 1) GROUP BY ddoid) AS t2 ON t1.ddoid = t2.i1");
                c.gv(GridView1, "SELECT t1.smonth, t1.ddoid, t1.salaryrecord, t2.mprrecord, t2.i1, Ucreate.username FROM(SELECT ddoid,smonth, COUNT(idno) AS salaryrecord FROM  calulatedsalary WHERE (Smonth ='" + ddlmonth.SelectedValue + "') AND (Syear = " + ddlyear.SelectedValue + ")GROUP BY ddoid,smonth) AS t1 INNER JOIN Ucreate ON t1.ddoid = Ucreate.iduser LEFT OUTER JOIN(SELECT     ddoid AS i1, COUNT(DISTINCT ISNULL(compid, '0')) AS mprrecord FROM   mpr WHERE      (DATEPART(year, date) = " + ddlyear.SelectedValue + ") AND (DATEPART(month, date) = " + ddlmonth.SelectedValue + ") GROUP BY ddoid) AS t2 ON t1.ddoid = t2.i1");



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
                //c.gv(GridView1, "SELECT t1.smonth, t1.ddoid, t1.salaryrecord, t2.mprrecord, t2.i1, Ucreate.username FROM(SELECT ddoid,smonth, COUNT(idno) AS salaryrecord FROM  calulatedsalary WHERE ddoid='" + ddlddo.SelectedValue + "'and (Smonth ='" + ddlmonth.SelectedValue + "') AND (Syear = 2013)GROUP BY ddoid,smonth) AS t1 INNER JOIN Ucreate ON t1.ddoid = Ucreate.iduser LEFT OUTER JOIN(SELECT     ddoid AS i1, COUNT(DISTINCT ISNULL(compid, '0')) AS mprrecord FROM   mpr WHERE      (DATEPART(year, date) = 2013) AND (DATEPART(month, date) = '" + ddlmonth.SelectedValue + "') GROUP BY ddoid) AS t2 ON t1.ddoid = t2.i1");
                //c.gv(GridView1, "SELECT t1.smonth, t1.ddoid, t1.salaryrecord, t2.mprrecord, t2.i1, Ucreate.username FROM(SELECT ddoid,smonth, COUNT(idno) AS salaryrecord FROM  calulatedsalary WHERE ddoid='" + ddlddo.SelectedValue + "' and (Smonth ='" + ddlmonth.SelectedValue + "') AND (Syear = " + ddlyear.SelectedValue + ")GROUP BY ddoid,smonth) AS t1 INNER JOIN Ucreate ON t1.ddoid = Ucreate.iduser LEFT OUTER JOIN(SELECT     ddoid AS i1, COUNT(DISTINCT ISNULL(compid, '0')) AS mprrecord FROM   mpr WHERE      (DATEPART(year, date) = 2016) AND (DATEPART(month, date) = '" + ddlmonth.SelectedValue + "') GROUP BY ddoid) AS t2 ON t1.ddoid = t2.i1");

                c.gv(GridView1, "SELECT t1.smonth, t1.ddoid, t1.salaryrecord, t2.mprrecord, t2.i1, Ucreate.username FROM(SELECT ddoid,smonth, COUNT(idno) AS salaryrecord FROM  calulatedsalary WHERE ddoid='" + ddlddo.SelectedValue + "' and (Smonth ='" + ddlmonth.SelectedValue + "') AND (Syear = " + ddlyear.SelectedValue + ")GROUP BY ddoid,smonth) AS t1 INNER JOIN Ucreate ON t1.ddoid = Ucreate.iduser LEFT OUTER JOIN(SELECT     ddoid AS i1, COUNT(DISTINCT ISNULL(compid, '0')) AS mprrecord FROM   mpr WHERE      (DATEPART(year, date) = " + ddlyear.SelectedValue + ") AND (DATEPART(month, date) = '" + ddlmonth.SelectedValue + "') GROUP BY ddoid) AS t2 ON t1.ddoid = t2.i1");

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


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}