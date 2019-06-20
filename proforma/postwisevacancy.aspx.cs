using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace NewWebApp.proforma
{
    public partial class postwisevacancy : System.Web.UI.Page
    {
        public String QS, sr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.TextBox3.Text = (string)Session["post"];
                //sr = "SELECT divname, districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM hospitallist " + Request.QueryString["qr"] + "";
                //sr = "SELECT post.newpostname, hospitalrecord.posts, hospitalrecord.withcadre, hospitalrecord.withoutcadre, hospitalrecord.Extrapost, hospitalrecord.posts - hospitalrecord.withcadre - hospitalrecord.Extrapost AS vacantpost, post.newpostid,hospitalname.sno FROM hospitalrecord INNER JOIN post ON hospitalrecord.postid = post.newpostid INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno WHERE (post.newpostname ='SURGEON') order by districtid,tehsilid,blockid,htype ";//";//
                sr = "SELECT     post.newpostname, hospitalrecord.posts, hospitalrecord.withcadre, hospitalrecord.withoutcadre, hospitalrecord.Extrapost,hospitalrecord.posts - hospitalrecord.withcadre - hospitalrecord.Extrapost AS vacantpost, post.newpostid, hospitalname.sno FROM         hospitalrecord INNER JOIN  post ON hospitalrecord.postid = post.newpostid INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno INNER JOIN hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid INNER JOIN division ON hospitaldistrict.divid = division.divid INNER JOIN Block ON hospitalname.blockid = Block.blockid INNER JOIN Tehsil ON hospitaldistrict.districtid = Tehsil.districtid WHERE (post.newpostname ='" + this.TextBox3.Text + "') ORDER BY division.divname, hospitaldistrict.districtname, Tehsil.tehsilname, Block.blockname ";// " + (string)Session["zr"] + "
                this.SqlDataSource1.SelectCommand = sr;

            }
        }
    }
}