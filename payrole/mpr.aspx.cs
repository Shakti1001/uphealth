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
using System.Data.SqlClient;

namespace NewWebApp.payrole
{
    public partial class mpr : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                usecheck();
                Label3.Visible = false;

            }
        }

        protected void report_Click(object sender, EventArgs e)
        {
            Response.Redirect("progressreport.aspx");
        }
        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
                Label1.Visible = true;
                DDONAME.Visible = true;
                fillDDO();
            }
            else
            {

                //cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                //if (cl.ds.Tables[0].Rows.Count > 0)
                //{
                //    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                //}
                //else
                //{
                //    Response.Redirect("~/login.aspx");
                //}

                //// *************************************************
                //// Hospital allotted to user  (string)Session["iduser"] 
                if ((string)Session["UsDisId"] != null && (string)Session["iduser"] != null)
                {
                    DDONAME.Visible = false;
                    Uidt.Text = (string)Session["UsDisId"];
                    Session.Add("ddopid", (string)Session["iduser"]);
                    Session.Add("ddoname", (string)Session["fullname"]);
                    setlinkstatus();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        public void fillDDO()
        {

            //cl.ds = cl.DataFill("SELECT DISTINCT Districtddo.ddoidd AS ddoidd, Districtddo.ddoname + ' Dist. ' + hospitaldistrict.districtname AS ddoname, hospitaldistrict.districtid FROM         hospitalname INNER JOIN  Districtddo ON hospitalname.ddoid = Districtddo.ddoidd INNER JOIN   hospitaldistrict ON Districtddo.ddodistrictid = hospitaldistrict.districtid   WHERE     (ddodistrictid like'" + Uidt.Text + "') ORDER BY Districtddo.ddoname + ' Dist. ' + hospitaldistrict.districtname ");
            cl.ds = cl.DataFill("SELECT DISTINCT Ucreate.iduser, Ucreate.username,Ucreate.DisId FROM         Ucreate INNER JOIN  hospitalname ON Ucreate.iduser = hospitalname.ddoid where  Ucreate.lavel not in (1,2,8) ORDER BY Ucreate.username ");
            DDONAME.DataSource = cl.ds;
            DDONAME.DataTextField = "username";
            DDONAME.DataValueField = "iduser";
            DDONAME.DataBind();
            DDONAME.Items.Insert(0, new ListItem("--select--"));
        }
        public void setddo()
        {
            bool i;
            i = cl.checkE((string)Session["iduser"]);
            if (i == true)
            {
                Response.Redirect("~/payrole/SaldetH.aspx?a=" + DDONAME.SelectedItem.Value + "");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

        protected void DDONAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDONAME.SelectedIndex != 0)
            {
                Session.Add("ddopid", DDONAME.SelectedItem.Value);
                Session.Add("ddoname", DDONAME.SelectedItem.Text);
            }
            else if (DDONAME.SelectedIndex == 0)
            {
                this.mess.Text = "Please Select DDO for MPR Data Entry";
                this.mess.Visible = true;
                SalDet.Enabled = false;
                Session.Add("ddopid", "");
            }
        }
        public void setlinkstatus()
        {
            if ((string)Session["iduser"] != null)
            {
                SalDet.Enabled = true;
                this.Label1.Text = "MPR Data Entry For : ";
                this.Label2.Text = "'" + (string)Session["fullname"] + "'";
            }
            else
            {
                this.Label1.Text = "Please Select DDO for Salary Process";
                SalDet.Enabled = false;
            }
        }

        protected void SalDet_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkE((string)Session["iduser"]);
            if (i == true)
            {
                if (DDONAME.SelectedIndex != 0)
                {
                    Response.Redirect("~/payrole/mprselect.aspx");

                }
                else
                {
                    this.mess.Visible = true;
                    this.mess.Text = "Please Select DDO for MPR Data Entry";
                }
            }
            else
            {
                Response.Redirect("~/payrole/mprselect.aspx");
            }
        }

        protected void Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administrator/LoginHome.aspx");
        }
        protected void mpentry_Click(object sender, EventArgs e)
        {
            Response.Redirect("mpentry.aspx");

            //Response.Redirect("datewisempr.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("mpentry.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/LoginHome.aspx");
        }
    }
}