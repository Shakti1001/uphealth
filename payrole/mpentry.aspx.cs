using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.payrole
{
    public partial class mpentry : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["lavel"] == "3")
                {
                    ddlddo.Visible = false;
                    lblddo.Text = Session["fullname"].ToString();
                    c.ddlhospital(ddlhname, "select * from hospitalname where ddoid=" + Session["iduser"] + "", "hname", "sno");
                }
                else if ((string)Session["lavel"] == "2")
                {
                    lblddo.Visible = false;
                    c.ddl1(ddlddo, "select * from Ucreate", "username", "iduser");
                }
            }
        }

        protected void ddlddo_indexchanged(object sender, EventArgs e)
        {
            if (ddlddo.SelectedIndex != 0)
            {
                c.ddlhospital(ddlhname, "select * from hospitalname where ddoid=" + ddlddo.SelectedValue + "", "hname", "sno");
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (ddlhname.SelectedIndex == 0)
            {
                lblmess.Text = "Please select the Hospital Name...";
            }
            else
            {

                if (ddlddo.SelectedIndex != 0)
                {
                    c.gv(GridView1, "select idno,senno,name,post from salaryselect where sno=" + ddlhname.SelectedValue + "");
                }
                else
                {
                    lblmess.Text = "Please select the DDO Name...";
                }
                //if(Session["lavel"] == "3")
                //{
                //   c.gv(GridView1,"select idno,senno,name,hname,post from salaryselect where sno="+ddlhname.SelectedValue+"");

                //}
                //else if (Session["lavel"] == "2")
                //{
                //     c.gv(GridView1,"select idno,senno,name,hname,post from salaryselect where sno ");
                //}
                lblmess.Enabled = false;
                lblmess.Visible = false;
            }
        }
       
        protected void ddlhname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("mpr.aspx");
        }
    }
}