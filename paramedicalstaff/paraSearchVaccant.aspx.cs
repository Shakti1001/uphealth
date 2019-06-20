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

namespace NewWebApp.paramedicalstaff
{
    public partial class paraSearchVaccant : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        //SqlConnection upcon = new SqlConnection(ClDatabase.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddfill();
                count.Text = "0";
            }
        }
        public void ddfill()
        {
            cl.ds = cl.DataFill("SELECT DISTINCT divname, divid FROM  division ORDER BY divname");
            DDiv.DataSource = cl.ds;
            DDiv.DataTextField = "divname";
            DDiv.DataValueField = "divid";
            DDiv.DataBind();
            DDiv.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname ORDER BY hospitalname.hname");
            DHname.DataSource = cl.ds;
            DHname.DataTextField = "hname";
            DHname.DataValueField = "sno";
            DHname.DataBind();
            DHname.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT     htype, hid FROM         hospitaltype ORDER BY htype");
            DHtype.DataSource = cl.ds;
            DHtype.DataTextField = "htype";
            DHtype.DataValueField = "hid";
            DHtype.DataBind();
            DHtype.Items.Insert(0, new ListItem("--select--"));
            //***************************
            cl.ds = cl.DataFill("SELECT     newpostname, newpostid FROM         post ORDER BY newpostname");
            Dpost.DataSource = cl.ds;
            Dpost.DataTextField = "newpostname";
            Dpost.DataValueField = "newpostid";
            Dpost.DataBind();
            Dpost.Items.Insert(0, new ListItem("--select--"));
        }
        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where divid='" + DDiv.SelectedItem.Value + "' ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));


        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

            cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname where districtid = '" + DDistrict.SelectedItem.Value + "' ORDER BY hospitalname.hname");
            DHname.DataSource = cl.ds;
            DHname.DataTextField = "hname";
            DHname.DataValueField = "sno";
            DHname.DataBind();
            DHname.Items.Insert(0, new ListItem("--select--"));
            //****************
            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(hospitaldistrict.districtid = '" + DDistrict.SelectedItem.Value + "') ";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(hospitaldistrict.districtid = '" + DDistrict.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";
        }
        protected void DHname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(hospitaldistrict.districtid = '" + DDistrict.SelectedItem.Value + "') ";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(hospitaldistrict.districtid = '" + DDistrict.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";
        }
        protected void DHtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname where districtid = '" + DDistrict.SelectedItem.Value + "'and htype= '" + DHtype.SelectedItem.Value + "' ORDER BY hospitalname.hname");
            //DHname.DataSource = cl.ds;
            //DHname.DataTextField = "hname";
            //DHname.DataValueField = "sno";
            //DHname.DataBind();
            //DHname.Items.Insert(0, new ListItem("--select--"));
            ////****************
            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(personaldetails.cadreid = '" + DHtype.SelectedItem.Value + "') ";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(personaldetails.cadreid = '" + DHtype.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";
        }
        protected void Dpost_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(currentpost.Dcode = '" + Dpost.SelectedItem.Value + "') ";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(currentpost.Dcode = '" + Dpost.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";
        }


        protected void Button1_Click(object sender, EventArgs e)
        {// Vaccantstatus.aspx//sno, divid, districtid, hid
            //data();

            string sno, divid, districtid, hid, post;
            //***************DIVISION****************
            if (this.DDiv.SelectedIndex != 0)
            { divid = "%" + DDiv.SelectedItem.Value + "%"; }
            else { divid = "%"; }
            Session.Add("divid", divid);
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            { districtid = "%" + DDistrict.SelectedItem.Value + "%"; }
            else { districtid = "%"; }
            Session.Add("districtid", districtid);
            //***************Hospital Type****************
            if (this.DHtype.SelectedIndex != 0)
            { hid = "%" + DHtype.SelectedItem.Value + "%"; }
            else { hid = "%"; }
            Session.Add("hid", hid);
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            { sno = "%" + DHname.SelectedItem.Value + "%"; }
            else { sno = "%"; }
            Session.Add("sno", sno);
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            { post = "%" + Dpost.SelectedItem.Value + "%"; }
            else { post = "%"; }
            Session.Add("post", post);
            Response.Redirect("parap1Vaccantstatus.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap1home.aspx");
        }
    }
}