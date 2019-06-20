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
    public partial class onlyhreport : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddfill();
                usecheck();
            }
        }
        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                //Uidt.Text = "%";
            }
            else
            {
                this.DDiv.Enabled = false;
                this.DDistrict.Enabled = false;
                cl.ds = cl.DataFill("SELECT isnull(DisId,0) FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    DDistrict.SelectedIndex = DDistrict.Items.IndexOf(DDistrict.Items.FindByValue(cl.ds.Tables[0].Rows[0][0].ToString()));
                    //Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();

                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
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

            cl.ds = cl.DataFill("SELECT     htype, hid FROM         hospitaltype ORDER BY htype");
            DHtype.DataSource = cl.ds;
            DHtype.DataTextField = "htype";
            DHtype.DataValueField = "hid";
            DHtype.DataBind();
            DHtype.Items.Insert(0, new ListItem("--select--"));

        }
        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDiv.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where divid='" + DDiv.SelectedItem.Value + "' ORDER BY districtname");
                DDistrict.DataSource = cl.ds;
                DDistrict.DataTextField = "districtname";
                DDistrict.DataValueField = "districtid";
                DDistrict.DataBind();
                DDistrict.Items.Insert(0, new ListItem("--select--"));
            }
        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void DHtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string divid, districtid, hid;
            //***************DIVISION****************
            if (this.DDiv.SelectedIndex != 0)
            { divid = DDiv.SelectedItem.Value; }
            else { divid = "N"; }

            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            { districtid = DDistrict.SelectedItem.Value; }
            else { districtid = "N"; }

            //***************Hospital Type****************
            if (this.DHtype.SelectedIndex != 0)
            { hid = DHtype.SelectedItem.Value; }
            else { hid = "N"; }
            //Session.Add("hid1", hid);
            Response.Redirect("~/proforma/TotHospital.aspx?a=" + divid + "&b=" + districtid + "&c=" + hid);


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

      
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../proforma/HRephome.aspx");
        } 
    }
}