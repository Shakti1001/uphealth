using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.Guest
{
    public partial class progressreport : System.Web.UI.Page
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
                    c.ddl2(ddlddo, "select * from ucreate order by username", "username", "iduser");
                    lblhname.Visible = true;
                    lblhname.Text = "Hospital Name ::";
                    ddlhname.Visible = true;
                }
                else
                {
                    lblddo.Visible = true;
                    lblddo.Text = "DDo Name ::";
                    ddlddo.Visible = true;
                    c.ddl5(ddlhname, "select * from hospitalname order by hname", "hname", "sno");
                    //  c.ddl5(ddlhname, "select * from hospitalname where ddoid=" + ((string)Session["iduser"]) + " order by hname", "hname", "sno");
                    c.ddl2(ddlddo, "select * from ucreate ", "username", "iduser");

                    // c.ddl2(ddlddo, "select * from ucreate where iduser="+((string)Session["iduser"])+"", "username", "iduser");

                    lblhname.Visible = true;
                    lblhname.Text = "Hospital Name ::";
                    ddlhname.Visible = true;
                    //Label2.Visible = ((string)Session["lavel"] == "3");

                }

                c.ddl3(ddlmonth, "select * from pay_month", "monthname", "monthid");
                //lblmess.Visible = false;

            }

        }
        protected void Back_Click(object sender, ImageClickEventArgs e)
        {
            //if ((string)Session["lavel"] == "2")
            //{
            //    Response.Redirect("~/LoginHome.aspx");
            //}
            //if (((string)Session["lavel"] == "3"))
            //{
            //    Response.Redirect("mpr.aspx");
            //}
            Response.Redirect("~/newguest/ghome.aspx");
        }

        protected void ddlddo_indexchanged(object sender, EventArgs e)
        {
            c.ddl5(ddlhname, "select * from hospitalname where ddoid=" + ddlddo.SelectedValue + " order by hname", "hname", "sno");
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (ddlddo.SelectedIndex == 0 && ddlhname.SelectedIndex == 0 && ddlyear.SelectedIndex == 0 && ddlmonth.SelectedIndex == 0)
            {
                lblmess.Text = "Please Select DDO,Hospitalname,Month and Year first..";
            }
            else
            {
                if (ddlmonth.SelectedIndex == 0 || ddlyear.SelectedIndex == 0)
                {
                    lblmess.Text = "Please Select Month and Year Both.";
                }
                else
                {

                    int yy = 0;

                    if (ddlyear.SelectedIndex == 1)
                    {
                        yy = 2014;


                    }
                    else
                    {
                        yy = 2015;

                    }



                    if (ddlddo.SelectedIndex != 0 && ddlhname.SelectedIndex == 0)
                    {
                        c.gv(GridView1, "select hname,compid, ddoid, month, year, name, post,opd, ot, Postmortem, vip, jail, emergency, mela, court,leaveOff,tourstudy,medicolegal,ndelivery,cdelivery from mprfinal1 where ddoid=" + ddlddo.SelectedValue + " and month=" + ddlmonth.SelectedValue + " and year=" + yy + " order by hname");


                        lblmess.Visible = false;
                    }
                    else
                    {
                        c.gv(GridView1, "select hname,compid, ddoid, month, year, name, post,opd, ot, Postmortem, vip, jail, emergency, mela, court,leaveOff,tourstudy,medicolegal,ndelivery,cdelivery from mprfinal1 where ddoid='" + ddlddo.SelectedValue + "' and sno='" + ddlhname.SelectedValue + "' and month=" + ddlmonth.SelectedValue + " and year=" + yy + " order by hname");
                        lblmess.Visible = false;
                    }
                }
            }


        }

        protected void ddlhname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Authenticate/login.aspx");
        }
    }
}