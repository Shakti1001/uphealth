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

namespace NewWebApp.payrole
{
    public partial class payrolehome : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
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

            }

        }
        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
            }
            else
            {
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

        protected void DDO_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkE((string)Session["iduser"]);
            if (i == true)
            {
                Response.Redirect("~/payrole/Ddomast.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void SalDet_Click(object sender, EventArgs e)
        {
            //Session.Add("ddo", DDONAME.SelectedItem.Value);
            //Session.Add("ddoname", DDONAME.SelectedItem.Text);
            Response.Redirect("SaldetH.aspx");


            //this.Label1.Visible = true;
            //fillDDO();
            //this.DDONAME.Visible = true;


        }
        public void fillDDO()
        {
            usecheck();
            cl.ds = cl.DataFill("SELECT DISTINCT Districtddo.ddoidd AS ddoidd, Districtddo.ddoname + ' Dist. ' + hospitaldistrict.districtname AS ddoname, hospitaldistrict.districtid FROM         hospitalname INNER JOIN  Districtddo ON hospitalname.ddoid = Districtddo.ddoidd INNER JOIN   hospitaldistrict ON Districtddo.ddodistrictid = hospitaldistrict.districtid   WHERE     (ddodistrictid like'" + Uidt.Text + "') ORDER BY Districtddo.ddoname + ' Dist. ' + hospitaldistrict.districtname ");
            DDONAME.DataSource = cl.ds;
            DDONAME.DataTextField = "ddoname";
            DDONAME.DataValueField = "ddoidd";
            DDONAME.DataBind();
            DDONAME.Items.Insert(0, new ListItem("--select--"));
        }


        

        protected void Addddo_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkE(Uidt.Text);
            if (i == true)
            {
                Response.Redirect("~/payrole/Ddomaster.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

        protected void DDONAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("ddo", DDONAME.SelectedItem.Value);
            Session.Add("ddoname", DDONAME.SelectedItem.Text);
            Response.Redirect("SaldetH.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/LoginHome.aspx");
        }
    }
}