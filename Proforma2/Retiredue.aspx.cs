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

namespace NewWebApp.Proforma2
{
    public partial class Retiredue : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddfill();
                sdate();
                sdate1();
            }
        }
        public void usecheckD()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
                cl.ds = cl.DataFill("SELECT DISTINCT divid, divname FROM division ORDER BY divname");
                DDiv.DataSource = cl.ds;
                DDiv.DataTextField = "divname";
                DDiv.DataValueField = "divid";
                DDiv.DataBind();
                DDiv.Items.Insert(0, new ListItem("--select--"));

            }
            else
            {
                DDiv.Visible = false;
                DL.Text = "Division Selected ";
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }

        public void ddfill()
        {
            usecheckD();
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where districtid like '" + Uidt.Text + "'  ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));
            //****************
        }

        public void sdate1()
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                DD1.Items.Add("" + Convert.ToString(i) + "");
            }
            DD1.Items.Insert(0, new ListItem("0"));
            for (i = 1; i <= 12; i++)
            {
                DM1.Items.Add("" + Convert.ToString(i) + "");
            }
            DM1.Items.Insert(0, new ListItem("0"));
            //for (i = 1940; i <= 2040; i++)
            for (i = 2030; i >= 1940; i--)
            {
                DY1.Items.Add("" + Convert.ToString(i) + "");
            }
            DY1.Items.Insert(0, new ListItem("0"));

        }
        public void sdate()
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                DDD.Items.Add("" + Convert.ToString(i) + "");
            }
            DDD.Items.Insert(0, new ListItem("0"));
            for (i = 1; i <= 12; i++)
            {
                DMM.Items.Add("" + Convert.ToString(i) + "");
            }
            DMM.Items.Insert(0, new ListItem("0"));
            // for (i = 1940; i <= 2040; i++)
            for (i = 2030; i >= 1940; i--)
            {
                DYYYY.Items.Add("" + Convert.ToString(i) + "");
            }
            DYYYY.Items.Insert(0, new ListItem("0"));

        }
        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDiv.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT DISTINCT districtid,districtname  FROM         hospitaldistrict WHERE     (divid = '" + DDiv.SelectedItem.Value + "') ORDER BY districtname");
                DDistrict.DataSource = cl.ds;
                DDistrict.DataTextField = "districtname";
                DDistrict.DataValueField = "districtid";
                DDistrict.DataBind();
                DDistrict.Items.Insert(0, new ListItem("--select--"));
                this.Divs.Text = "%" + DDiv.SelectedItem.Value + "%";
            }
            else
            {
                this.Divs.Text = "%";
            }
        }
       
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                selection();
            }
            catch (Exception ex)
            {
                mess.Text = ex.Message;
                mess.Text = "Tech Prb";
            }
            finally
            {

            }
        }
        public void selection()
        {
            string Dist;
            DateTime fdate;
            //DateTime fdate2;
            DateTime tdate;
            //DateTime tdate2;

            //***************DIVISION****************
            bool l;
            l = cl.checklavel((string)Session["iduser"]);
            if (l == true)
            {
                if (this.DDiv.SelectedIndex != 0)
                { this.Divs.Text = DDiv.SelectedItem.Value; }
                else { this.Divs.Text = "N"; }
            }
            else
            {
                this.Divs.Text = "N";
            }
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            { Dist = DDistrict.SelectedItem.Value.Trim(); }
            else { Dist = "N"; }
            //***************From Date****************
            //if (DDD.SelectedIndex != 0 && DMM.SelectedIndex != 0 && DYYYY.SelectedIndex != 0)
            if (DMM.SelectedIndex != 0 && DYYYY.SelectedIndex != 0)
            {
                if (DMM.SelectedItem.Text == "2")
                {
                    DDD.SelectedItem.Text = "28";
                }

                else
                {
                    DDD.SelectedItem.Text = "30";
                }
                fdate = Convert.ToDateTime((DMM.SelectedItem.Text + "/" + Convert.ToInt32(DDD.SelectedItem.Text) + "/" + DYYYY.SelectedItem.Text));
            }
            else
            {
                fdate = System.DateTime.Today;
            }
            //***************To Date****************
            //if (DM1.SelectedIndex != 0 && DD1.SelectedIndex != 0 && DY1.SelectedIndex != 0)
            if (DM1.SelectedIndex != 0 && DY1.SelectedIndex != 0)
            {
                if (DM1.SelectedItem.Text == "2")
                {
                    DD1.SelectedItem.Text = "28";
                }
                else
                {
                    DD1.SelectedItem.Text = "30";
                }
                tdate = Convert.ToDateTime((DM1.SelectedItem.Text + "/" + Convert.ToInt32(DD1.SelectedItem.Text) + "/" + DY1.SelectedItem.Text));
            }
            else //if (DM1.SelectedIndex == 0 || DD1.SelectedIndex == 0 || DY1.SelectedIndex == 0)
            {
                tdate = System.DateTime.Today;
                //tdate2 = System.DateTime.Today;
            }
            Response.Redirect("Retiredocprint.aspx?Div=" + Divs.Text + "&Dis=" + Dist + "&DT1=" + fdate + "&DT2=" + tdate + "");//&C1=" + fdate2 + "&C2" + tdate2 + "");
            //Response.Write("<script language=javascript>window.open('Retiredocprint.aspx?Div=" + Divs.Text + "&Dis=" + Dist + "&DT1=" + fdate + "&DT2=" + tdate + "','new_Win');</script>");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Proforma2/RetireDoctlist.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/RepOption.aspx");
        }
    }
}