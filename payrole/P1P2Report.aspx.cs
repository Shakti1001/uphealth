using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.payrole
{
    public partial class P1P2Report : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                c.ddl5(ddldistrict, "select * from hospitaldistrict order by districtname", "districtname", "districtid");
            }
            // c.ddl5(DropDownList1, "select * from hospitaldistrict order by districtname", "districtname", "districtid"); 

            //c.ddl5(ddlhospital, "select * from hospitaldistrict order by districtname", "hname", "sno"); 
            //c.gv(GridView1, "SELECT dbo.hospitaldistrict.districtname as[District Name], dbo.hospitalname.hname as[Hospital Name], dbo.Sanctioned_post.Sanctioned_post as[Sanctioned Post], dbo.filledpost.Filled_post as[Filled Post] FROM dbo.hospitaldistrict INNER JOIN dbo.Sanctioned_post ON dbo.hospitaldistrict.districtid = dbo.Sanctioned_post.districtid INNER JOIN dbo.hospitalname ON dbo.hospitaldistrict.districtid = dbo.hospitalname.districtid AND dbo.Sanctioned_post.hnameid = dbo.hospitalname.sno INNER JOIN dbo.filledpost ON dbo.hospitaldistrict.districtid = dbo.filledpost.districtid AND dbo.Sanctioned_post.hnameid = dbo.filledpost.poposting GROUP BY dbo.hospitaldistrict.districtname, dbo.hospitalname.hname, dbo.Sanctioned_post.Sanctioned_post, dbo.filledpost.Filled_post");


        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write(DropDownList1.SelectedIndex);

            if (ddldistrict.SelectedIndex == 0)
            {
                c.gv(GridView1, "SELECT  TOP (100) PERCENT dbo.hospitaldistrict.districtname, dbo.hospitalname.hname, dbo.Sanctioned_post.Sanctioned_post, dbo.filledpost.Filled_post, dbo.hospitaldistrict.districtid FROM dbo.hospitaldistrict INNER JOIN dbo.Sanctioned_post ON dbo.hospitaldistrict.districtid = dbo.Sanctioned_post.districtid INNER JOIN dbo.hospitalname ON dbo.hospitaldistrict.districtid = dbo.hospitalname.districtid AND dbo.Sanctioned_post.hnameid = dbo.hospitalname.sno INNER JOIN dbo.filledpost ON dbo.hospitaldistrict.districtid = dbo.filledpost.districtid AND dbo.Sanctioned_post.hnameid = dbo.filledpost.poposting GROUP BY dbo.hospitaldistrict.districtname, dbo.hospitalname.hname, dbo.Sanctioned_post.Sanctioned_post, dbo.filledpost.Filled_post, dbo.hospitaldistrict.districtid ORDER BY dbo.hospitaldistrict.districtname");
            }

            else
            {
                c.gv(GridView1, "SELECT  TOP (100) PERCENT dbo.hospitaldistrict.districtname, dbo.hospitalname.hname, dbo.Sanctioned_post.Sanctioned_post, dbo.filledpost.Filled_post, dbo.hospitaldistrict.districtid FROM dbo.hospitaldistrict INNER JOIN dbo.Sanctioned_post ON dbo.hospitaldistrict.districtid = dbo.Sanctioned_post.districtid INNER JOIN dbo.hospitalname ON dbo.hospitaldistrict.districtid = dbo.hospitalname.districtid AND dbo.Sanctioned_post.hnameid = dbo.hospitalname.sno INNER JOIN dbo.filledpost ON dbo.hospitaldistrict.districtid = dbo.filledpost.districtid AND dbo.Sanctioned_post.hnameid = dbo.filledpost.poposting where dbo.hospitaldistrict.districtid='" + ddldistrict.SelectedValue + "' GROUP BY dbo.hospitaldistrict.districtname, dbo.hospitalname.hname, dbo.Sanctioned_post.Sanctioned_post, dbo.filledpost.Filled_post, dbo.hospitaldistrict.districtid ORDER BY dbo.hospitaldistrict.districtname");

            }
        }
    }
}