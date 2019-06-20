using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.paramedicalstaff
{
    public partial class P2Search : System.Web.UI.Page
    {
        Class1 c = new Class1();
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                c.ddl(district, "select * from hospitaldistrict order by districtname", "districtname", "districtid");
                //c.ddl5(hname,"select * from hospitalname order by hname","hname","sno");
                //c.ddl5(post,"select * from pmdhospitaldesignation order by designame","designame","desigid");
                c.ddl(cadre, "select * from pmdcadre order by cadrename", "cadrename", "cadreid");

                //c.gv(GridView1, "select * from pmdfactsheet");


            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {




        }

        public void runqualC()
        {

            string q1, q2, q3, q4, q5, q6, q7, q8, qr1, qr2;
            //***************compid****************
            if (this.compid.Text != "")
            {
                q1 = "idno =" + compid.Text + "";
            }
            else { q1 = "idno like '%'"; }
            //**************name*****************
            if (this.name.Text != "")
            { q2 = "name like '%" + name.Text + "%'"; }
            else { q2 = "name like '%'"; }
            //*****************dob**************
            if (this.dob.Text != "")
            { q3 = "dob=" + dob.Text + ""; }
            else { q3 = "dob like '%'"; }
            //****************POST***************
            if (this.cadre.SelectedIndex != 0)
            { q4 = "cadreid=" + cadre.SelectedItem.Value + ""; }
            else { q4 = "cadreid like '%'"; }
            //***************CADRE****************
            if (this.district.SelectedIndex != 0)
            { q5 = "homedistrictid=" + district.SelectedItem.Value + ""; }
            else { q5 = "homedistrictid like '%'"; }



            qr1 = " And " + q1 + " And " + q2 + " And " + q3 + " AND " + q4 + " And " + q5 + " ";//And " + q9 + "

            qr2 = q2 + " And " + q3 + " AND " + q4 + " And " + q5 + " and " + q1 + " ";//


            bool i;
            i = cl.checklavel((string)Session["iduser"]);


            if (i == true)
            {

                c.gv(GridView1, "select idno,name,fathername,districtname,Convert(varchar(11),dob,106) as dob,senno from pmdfactsheet where (divid LIKE '" + Divs.Text + "')" + qr1 + "");

            }
            else
            {
                c.gv(GridView1, "select idno,name,fathername,districtname,Convert(varchar(11),dob,106) as dob,senno from pmdfactsheet WHERE  ( " + qr2 + " )");

            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            GridView1.Enabled = true;
            GridView1.Visible = true;
            runqualC();

            //if (compid.Text != "" && name.Text=="" && dob.Text=="" && cadre.SelectedIndex==0 && district.SelectedIndex==0 )
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where idno="+compid.Text+"");
            //}
            //if (compid.Text == "" && name.Text != "" && dob.Text == "" && cadre.SelectedIndex == 0 && district.SelectedIndex == 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where name like '%" + name.Text + "%'");
            //}
            //if (compid.Text == "" && name.Text == "" && dob.Text != "" && cadre.SelectedIndex == 0 && district.SelectedIndex == 0)
            //{
            //    c.gv(GridView1, "select idno,name,fathername,districtname,Convert(varchar(11),dob,106) as dob,senno from pmdfactsheet where Convert(varchar(10),dob,103)='" + dob.Text + "'");
            //    //c.gv(GridView1, "select * from pmdfactsheet where dob='" + Convert.ToDateTime(dob.Text).ToShortDateString() + "'");
            //}
            //if (compid.Text == "" && name.Text == "" && dob.Text == "" && cadre.SelectedIndex != 0 && district.SelectedIndex == 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where cadreid='" + cadre.SelectedValue + "'");
            //}


            //if (compid.Text == "" && name.Text == "" && dob.Text == "" && cadre.SelectedIndex == 0 && district.SelectedIndex != 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where disid=" + district.SelectedValue + "");
            //}
            //if (compid.Text != "" && name.Text != "" && dob.Text == "" && cadre.SelectedIndex == 0 && district.SelectedIndex == 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where name=" + name.Text + " and idno="+compid.Text+"");
            //}
            ////if (compid.Text == "" && name.Text != "" && dob.Text != "" && cadre.SelectedIndex == 0 && district.SelectedIndex == 0)
            ////{
            ////    c.gv(GridView1, "select * from pmdfactsheet where name=" + name.Text + " and idno=" + compid.Text + "");
            ////}


            //if (compid.Text != "" && name.Text != "" && dob.Text == "" && cadre.SelectedIndex != 0 && district.SelectedIndex != 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where name=" + name.Text + " and idno=" + compid.Text + " postid="+cadre.SelectedValue+" and disid="+district.SelectedValue+"");
            //}

            ////if (compid.Text == "" && name.Text == "" && dob.Text == "" && cadre.SelectedIndex != 0 && district.SelectedIndex == 0)
            ////{
            ////    c.gv(GridView1, "select * from pmdfactsheet where postid=" +cadre.SelectedValue + " and disid=" +district.SelectedValue + "");
            ////}

            //if (compid.Text != "" && name.Text == "" && dob.Text == "" && cadre.SelectedIndex == 0 && district.SelectedIndex != 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where idno=" + compid.Text + " and disid=" + district.SelectedValue + " ");
            //}
            //if (compid.Text == "" && name.Text == "" && dob.Text == "" && cadre.SelectedIndex == 0 && district.SelectedIndex == 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet" );
            //}
            //if (compid.Text == "" && name.Text != "" && dob.Text == "" && cadre.SelectedIndex == 0 && district.SelectedIndex != 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where name="+name.Text+" and disid="+district.SelectedValue+"");
            //}


            //if (compid.Text == "" && name.Text != "" && dob.Text == "" && cadre.SelectedIndex != 0 && district.SelectedIndex != 0)
            //{
            //    c.gv(GridView1, "select * from pmdfactsheet where  name=" + name.Text + " and disid=" + district.SelectedValue + " and postid="+cadre.SelectedValue+"");
            //}

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            cadre.SelectedIndex = 0;
            district.SelectedIndex = 0;
            name.Text = "";
            dob.Text = "";
            compid.Text = "";
            GridView1.Enabled = false;
            GridView1.Visible = false;
        }
    }
}