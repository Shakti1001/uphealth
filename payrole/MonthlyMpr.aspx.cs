using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.payrole
{
    public partial class MonthlyMpr : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                //c.gv1(GridView2,"SELECT  monthlympr.dutyid, dutytype.dutyname, COUNT(monthlympr.name)as name, SUM(monthlympr.cases)as cases, AVG(monthlympr.cases)as avgcase, monthlympr.username, monthlympr.districtid, monthlympr.districtname, monthlympr.ddoid FROM monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE (monthlympr.month = '11') AND (monthlympr.dutyid = '15')GROUP BY monthlympr.dutyid, dutytype.dutyname, monthlympr.ddoid, monthlympr.username, monthlympr.districtid, monthlympr.districtname");
                c.ddl3(ddlmonth, "select * from pay_month", "monthname", "monthid");
                c.ddl(ddldutytype, "select * from dutytype order by dutyname", "dutyname", "dutyid");
                c.ddl2(ddlddo, "select * from ucreate order by username", "username", "iduser");
                c.ddl5(district, "select * from hospitaldistrict order by districtname", "districtname", "districtid");
                //c.ddl5(ddlpost, "select * from Post order by newpostname","newpostname","newpostid");
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlyear.SelectedIndex == 0 || ddlmonth.SelectedIndex == 0)
            {
                lblmess.Text = "Please Select Month and Year both";

            }
            else
            {


                if (ddlddo.SelectedIndex != 0 && ddldutytype.SelectedIndex != 0 && ddlmonth.SelectedIndex != 0 && district.SelectedIndex != 0 && ddlyear.SelectedIndex != 0)
                {
                    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + "  GROUP BY monthlympr.dutyid, dutytype.dutyname");
                    if (GridView2.Rows.Count < 1)
                    {
                        lblmess.Visible = true;
                        lblmess.Text = "No Record Found...";
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmess.Visible = false;



                        //c.gv(GridView1, "SELECT  monthlympr.compid,  monthlympr.name, monthlympr.spqual, monthlympr.hname, monthlympr.newpostname,dutytype.dutyname, SUM(monthlympr.cases) AS cases,  monthlympr.districtname, SUM(monthlympr.cases) AS cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM  dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid WHERE     (monthlympr.month = " + ddlmonth.SelectedValue + ") AND (monthlympr.year = " + ddlyear.SelectedValue + ") and monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " GROUP BY dutytype.dutyname, monthlympr.name, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username, monthlympr.compid ");







                        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + " order by monthlympr.cases DESC");

                    }
                }

                if (ddlddo.SelectedIndex != 0 && ddldutytype.SelectedIndex != 0 && ddlmonth.SelectedIndex != 0 && district.SelectedIndex == 0 && ddlyear.SelectedIndex != 0)
                {
                    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where  monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + "  GROUP BY monthlympr.dutyid, dutytype.dutyname");
                    if (GridView2.Rows.Count < 1)
                    {
                        lblmess.Visible = true;
                        lblmess.Text = "No Record Found...";
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmess.Visible = false;
                        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where  monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + " order by monthlympr.cases DESC");

                    }
                }

                if (ddlddo.SelectedIndex == 0 && ddldutytype.SelectedIndex != 0 && ddlmonth.SelectedIndex != 0 && district.SelectedIndex == 0 && ddlyear.SelectedIndex != 0)
                {
                    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where   monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + "  GROUP BY monthlympr.dutyid, dutytype.dutyname");
                    if (GridView2.Rows.Count < 1)
                    {
                        lblmess.Visible = true;
                        lblmess.Text = "No Record Found...";
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmess.Visible = false;
                        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where  monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + " order by monthlympr.cases DESC");

                    }
                }

                if (ddlddo.SelectedIndex == 0 && ddldutytype.SelectedIndex == 0 && ddlmonth.SelectedIndex != 0 && district.SelectedIndex == 0 && ddlyear.SelectedIndex != 0)
                {
                    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where    monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + "  GROUP BY monthlympr.dutyid, dutytype.dutyname");
                    if (GridView2.Rows.Count < 1)
                    {
                        lblmess.Visible = true;
                        lblmess.Text = "No Record Found...";
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmess.Visible = false;
                        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where   monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + " order by monthlympr.cases DESC");

                    }
                }

                if (district.SelectedIndex != 0 && ddlddo.SelectedIndex == 0 && ddldutytype.SelectedIndex == 0 && ddlmonth.SelectedIndex != 0 && ddlyear.SelectedIndex != 0)//5
                {
                    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where monthlympr.districtid=" + district.SelectedValue + "  and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + "  GROUP BY monthlympr.dutyid, dutytype.dutyname");
                    if (GridView2.Rows.Count < 1)
                    {
                        lblmess.Visible = true;
                        lblmess.Text = "No Record Found...";
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmess.Visible = false;
                        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.districtid=" + district.SelectedValue + "  and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + " order by monthlympr.cases DESC");

                    }
                }

                if (district.SelectedIndex != 0 && ddlddo.SelectedIndex != 0 && ddldutytype.SelectedIndex == 0 && ddlmonth.SelectedIndex != 0 && ddlyear.SelectedIndex != 0)//6
                {
                    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + "  and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + "  GROUP BY monthlympr.dutyid, dutytype.dutyname");
                    if (GridView2.Rows.Count < 1)
                    {
                        lblmess.Visible = true;
                        lblmess.Text = "No Record Found...";
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmess.Visible = false;
                        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.year=" + ddlyear.SelectedValue + " order by monthlympr.cases DESC");

                    }
                }




















                //if (ddldutytype.SelectedIndex == 0 && district.SelectedIndex == 0 && ddlddo.SelectedIndex == 0)//5
                // {
                //     //c.gv1(GridView1,"SELECT     monthlympr.dutyid AS [Duty Type], COUNT(monthlympr.name) AS [No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases], dutytype.dutyname FROM monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE(monthlympr.month = "+ddlmonth.SelectedValue+")GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //     //c.gv1(GridView2, "SELECT dutyid as [Duty Type], COUNT(name) AS [No. of Doctor],sum(cases) as [Total No. of cases], avg(cases) AS [Average No. of Cases] FROM dbo.monthlympr where month=" + ddlmonth.SelectedValue + "GROUP BY dutyid");
                //     c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE (monthlympr.month = 1) and monthlympr.year=2014 GROUP BY monthlympr.dutyid, dutytype.dutyname ");

                //     if (GridView2.Rows.Count < 1)
                //     {
                //         lblmess.Visible = true;
                //         lblmess.Text = "No Record Found...";
                //         GridView1.Visible = false;
                //     }
                //     else
                //     {

                //         lblmess.Visible = false;
                //         c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where month=" + ddlmonth.SelectedValue + " and monthlympr.year=2014 order by monthlympr.cases DESC");

                //     }

                // }

                //     if (district.SelectedIndex == 0 && ddlddo.SelectedIndex == 0)//1

                //     {
                //    //c.gv1(GridView2, "SELECT  monthlympr.dutyid, dutytype.dutyname, COUNT(monthlympr.name)as name, SUM(monthlympr.cases)as cases, AVG(monthlympr.cases)as avgcase, monthlympr.username, monthlympr.districtid, monthlympr.districtname, monthlympr.ddoid FROM monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE (monthlympr.month = " + ddlmonth.SelectedValue + ") AND (monthlympr.dutyid = " + ddldutytype.SelectedValue + ")GROUP BY monthlympr.dutyid, dutytype.dutyname, monthlympr.ddoid, monthlympr.username, monthlympr.districtid, monthlympr.districtname");

                //    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE (monthlympr.dutyid = " + ddldutytype.SelectedValue + ") AND (monthlympr.month = " + ddlmonth.SelectedValue + ")  GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //    if (GridView2.Rows.Count < 1)
                //    {

                //        lblmess.Visible = true;
                //        lblmess.Text = "No Record Found...";
                //        GridView1.Visible = false;
                //    }
                //    else
                //    {
                //        lblmess.Visible = false;

                //        //Response.Write(ddldutytype.SelectedValue);

                //        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid  where monthlympr.dutyid=" + ddldutytype.SelectedValue + " and month=" + ddlmonth.SelectedValue + "order by monthlympr.cases DESC ");

                //    }

                //}
                //else if (district.SelectedIndex == 0)//2
                //{

                //    //c.gv1(GridView2, "SELECT dutyid as [Duty Type], COUNT(name) AS [No. of Doctor],sum(cases) as [Total No. of cases], avg(cases) AS [Average No. of Cases] FROM dbo.monthlympr where month=" + ddlmonth.SelectedValue + " and dutyid=" + ddldutytype.SelectedValue + "GROUP BY dutyid");
                //    //c.gv1(GridView1, "SELECT monthlympr.dutyid AS [Duty Type], COUNT(monthlympr.name) AS [No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases], dutytype.dutyname FROM monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE(monthlympr.month = " + ddlmonth.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + ")GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //    c.gv1(GridView2, "SELECT  monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE monthlympr.ddoid=" + ddlddo.SelectedValue + " and  (monthlympr.dutyid = " + ddldutytype.SelectedValue + ") and (monthlympr.month = " + ddlmonth.SelectedValue + ")  GROUP BY monthlympr.dutyid, dutytype.dutyname");

                //    if (GridView2.Rows.Count < 1)
                //    {
                //        lblmess.Visible = true;
                //        lblmess.Text = "No Record Found...";
                //        GridView1.Visible = false;
                //    }
                //    else
                //    {
                //        lblmess.Visible = false;
                //        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.ddoid=" + ddlddo.SelectedValue + " and  monthlympr.dutyid=" + ddldutytype.SelectedValue + "  and monthlympr.month=" + ddlmonth.SelectedValue + "order by monthlympr.cases DESC");

                //    }
                //}

                //else if (ddlddo.SelectedIndex == 0 && ddldutytype.SelectedIndex == 0)//3
                //{
                //    //c.gv1(GridView2, "SELECT dutyid as [Duty Type], COUNT(name) AS [No. of Doctor],sum(cases) as [Total No. of cases], avg(cases) AS [Average No. of Cases] FROM dbo.monthlympr where month=" + ddlmonth.SelectedValue + " and dutyid=" + ddldutytype.SelectedValue + "GROUP BY dutyid");
                //    //c.gv1(GridView1, "SELECT     monthlympr.dutyid AS [Duty Type], COUNT(monthlympr.name) AS [No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases], dutytype.dutyname FROM monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE(monthlympr.month = " + ddlmonth.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + ")GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //    //c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE (monthlympr.month = " + ddlmonth.SelectedValue + ") AND (monthlympr.dutyid = " + ddldutytype.SelectedValue + ")GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE monthlympr.districtid=" + district.SelectedValue + " and (monthlympr.month = " + ddlmonth.SelectedValue + ") GROUP BY monthlympr.dutyid, dutytype.dutyname");

                //    if (GridView2.Rows.Count < 1)
                //    {
                //        lblmess.Visible = true;
                //        lblmess.Text = "No Record Found...";
                //        GridView1.Visible = false;
                //    }
                //    else
                //    {
                //        lblmess.Visible = false;
                //        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.districtid=" + district.SelectedValue + " and month=" + ddlmonth.SelectedValue + "order by monthlympr.cases DESC ");

                //    }


                //}



                //else if (ddlddo.SelectedIndex == 0)//4
                //{
                //    //c.gv1(GridView2, "SELECT dutyid as [Duty Type], COUNT(name) AS [No. of Doctor],sum(cases) as [Total No. of cases], avg(cases) AS [Average No. of Cases] FROM dbo.monthlympr where month=" + ddlmonth.SelectedValue + " and dutyid=" + ddldutytype.SelectedValue + "GROUP BY dutyid");
                //    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE monthlympr.districtid=" + district.SelectedValue + " and (monthlympr.dutyid = " + ddldutytype.SelectedValue + ") and (monthlympr.month = " + ddlmonth.SelectedValue + ") GROUP BY monthlympr.dutyid, dutytype.dutyname");

                //    if (GridView2.Rows.Count < 1)
                //    {
                //        lblmess.Visible = true;
                //        lblmess.Text = "No Record Found...";
                //        GridView1.Visible = false;
                //    }
                //    else
                //    {
                //        lblmess.Visible = false;
                //        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.month=" + ddlmonth.SelectedValue + " and monthlympr.districtid=" + district.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + "order by monthlympr.cases DESC");

                //    }


                //}

                //else if (district.SelectedIndex == 0 && ddldutytype.SelectedIndex == 0)//6
                //{
                //    //c.gv1(GridView2, "SELECT dutyid as [Duty Type], COUNT(name) AS [No. of Doctor],sum(cases) as [Total No. of cases], avg(cases) AS [Average No. of Cases] FROM dbo.monthlympr where month=" + ddlmonth.SelectedValue + " and dutyid=" + ddldutytype.SelectedValue + "GROUP BY dutyid");
                //    //c.gv1(GridView1, "SELECT     monthlympr.dutyid AS [Duty Type], COUNT(monthlympr.name) AS [No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases], dutytype.dutyname FROM monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE(monthlympr.month = " + ddlmonth.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + ")GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //    //c.gv1(GridView1, " SELECT     monthlympr.dutyid AS [Duty Type], COUNT(monthlympr.name) AS [No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases], dutytype.dutyname FROM monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE(monthlympr.month = '11' and monthlympr.dutyid='15')GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE monthlympr.ddoid=" + ddlddo.SelectedValue + " and (monthlympr.month = " + ddlmonth.SelectedValue + ") GROUP BY monthlympr.dutyid, dutytype.dutyname");

                //    if (GridView2.Rows.Count < 1)
                //    {
                //        lblmess.Visible = true;
                //        lblmess.Text = "No Record Found...";
                //        GridView1.Visible = false;
                //    }
                //    else
                //    {
                //        lblmess.Visible = false;
                //        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + "order by monthlympr.cases DESC");

                //    }

                //}



                //else if(ddlmonth.SelectedIndex!=0 && ddlyear.SelectedIndex!=0)

                //{


                //    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE monthlympr.year=2014 and (monthlympr.month = " + ddlmonth.SelectedValue + ") GROUP BY monthlympr.dutyid, dutytype.dutyname");

                //    if (GridView2.Rows.Count < 1)
                //    {
                //        lblmess.Visible = true;
                //        lblmess.Text = "No Record Found...";
                //        GridView1.Visible = false;
                //    }
                //    else
                //    {
                //        lblmess.Visible = false;
                //        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.year=2014 and monthlympr.month=" + ddlmonth.SelectedValue + " order by monthlympr.cases DESC");

                //    }


                //    }
                //else if (ddldutytype.SelectedIndex == 0)//7
                //{
                //    //c.gv1(GridView2, "SELECT dutyid as [Duty Type], COUNT(name) AS [No. of Doctor],sum(cases) as [Total No. of cases], avg(cases) AS [Average No. of Cases] FROM dbo.monthlympr where month=" + ddlmonth.SelectedValue + " and dutyid=" + ddldutytype.SelectedValue + "GROUP BY dutyid");
                //    //c.gv1(GridView1, " SELECT     monthlympr.dutyid AS [Duty Type], COUNT(monthlympr.name) AS [No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases], dutytype.dutyname FROM monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid WHERE(monthlympr.month = '11' and monthlympr.dutyid='15')GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " GROUP BY monthlympr.dutyid, dutytype.dutyname");

                //    if (GridView2.Rows.Count < 1)
                //    {
                //        lblmess.Visible = true;
                //        lblmess.Text = "No Record Found...";
                //        GridView1.Visible = false;
                //    }
                //    else
                //    {
                //        lblmess.Visible = false;
                //        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " order by monthlympr.cases DESC");

                //    }
                //}



                //else if (ddlddo.SelectedIndex != 0 && ddldutytype.SelectedIndex != 0 && ddlmonth.SelectedIndex != 0 && district.SelectedIndex != 0)
                //{
                //    c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " GROUP BY monthlympr.dutyid, dutytype.dutyname");
                //    if (GridView2.Rows.Count < 1)
                //    {
                //        lblmess.Visible = true;
                //        lblmess.Text = "No Record Found...";
                //        GridView1.Visible = false;
                //    }
                //    else
                //    {
                //        lblmess.Visible = false;
                //        c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.dutyid=" + ddldutytype.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " order by monthlympr.cases DESC");

                //    }
                //}
                //else if(ddldutytype.SelectedIndex==0)
                //     {


                //         c.gv1(GridView2, "SELECT   monthlympr.dutyid AS [Duty Type],dutytype.dutyname as [DUTY], COUNT(monthlympr.name) AS [Total No. of Doctor], SUM(monthlympr.cases) AS [Total No. of cases], AVG(monthlympr.cases)  AS [Average No. of Cases] FROM  monthlympr INNER JOIN dutytype ON monthlympr.dutyid = dutytype.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + "and monthlympr.month=" + ddlmonth.SelectedValue + " GROUP BY monthlympr.dutyid, dutytype.dutyname");

                //         if (GridView2.Rows.Count < 1)
                //         {
                //             lblmess.Visible = true;
                //             lblmess.Text = "No Record Found...";
                //             GridView1.Visible = false;
                //         }
                //         else
                //         {
                //             lblmess.Visible = false;
                //             c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where monthlympr.districtid=" + district.SelectedValue + " and monthlympr.ddoid=" + ddlddo.SelectedValue + " and monthlympr.month=" + ddlmonth.SelectedValue + " order by monthlympr.cases DESC");

                //         }



            }
        }

        protected void district_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (district.SelectedIndex != 0)
            {
                c.ddl2(ddlddo, "select * from ucreate  where Disid=" + district.SelectedValue + " and lavel=3 order by username ", "username", "iduser");
            }
            else
            {
                c.ddl2(ddlddo, "select * from ucreate order by username", "username", "iduser");
            }
        }



        //protected void Paging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    //c.gv(GridView1, "SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid where month=" + ddlmonth.SelectedValue + "order by monthlympr.cases");

        //}
    }
}