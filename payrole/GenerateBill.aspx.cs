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
    public partial class GenerateBill : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                if ((string)Session["ddoname"] != null && (string)Session["ddopid"] != null)
                {
                    DDOText.Text = (string)Session["ddoname"];
                    DDOIDLab.Text = (string)Session["ddopid"];
                    dd();
                }
                else
                {
                    this.MSGLabel.Text = "Please select Proper One...";
                }
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void save_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Image.Visible = true;
            cancel.Visible = true;
        }
        public void dd()
        {

            //****************year 
            year.Items.Clear();
            //year.Items.Add("2010");
            //year.Items.Add("2011");

            //year.Items.Add("2013");
            // year.Items.Add("2014");
            // year.Items.Add("2015");
            year.Items.Add("2016");
            year.Items.Add("2017");
            //year.Items.Insert(0, new ListItem("ALL"));        
            //****************paymonth
            cl.ds = cl.DataFill("SELECT     monthname, monthid  FROM Pay_Month ORDER BY monthid, monthname");
            Month.DataSource = cl.ds;
            Month.DataTextField = "monthname";
            Month.DataValueField = "monthid";
            Month.DataBind();
            //Month.Items.Insert(0, new ListItem("--select--"));

            //****************DDO
            cl.ds = cl.DataFill("SELECT DISTINCT Districtddo.ddoidd AS ddoidd, Districtddo.ddoname + ' Dist. ' + hospitaldistrict.districtname AS ddoname, hospitaldistrict.districtid FROM         hospitalname INNER JOIN  Districtddo ON hospitalname.ddoid = Districtddo.ddoidd INNER JOIN   hospitaldistrict ON Districtddo.ddodistrictid = hospitaldistrict.districtid   WHERE     (Districtddo.ddoname + ' Dist. ' + hospitaldistrict.districtname ='" + DDOText.Text + "') ");
            DDO.DataSource = cl.ds;
            DDO.DataTextField = "ddoname";
            DDO.DataValueField = "ddoidd";
            DDO.DataBind();
            DDO.Visible = false;
            //****************paySection
            cl.ds = cl.DataFill("SELECT sectionname, sectionid FROM  Pay_Section ORDER BY sectionname");
            Section.DataSource = cl.ds;
            Section.DataTextField = "sectionname";
            Section.DataValueField = "sectionid";
            Section.DataBind();
            Section.Items.Insert(0, new ListItem("ALL"));
            //****************payhead
            cl.ds = cl.DataFill("SELECT     headname, headid FROM  Pay_Head ORDER BY headname");
            Head.DataSource = cl.ds;
            Head.DataTextField = "headname";
            Head.DataValueField = "headid";
            Head.DataBind();
            Head.Items.Insert(0, new ListItem("ALL"));

        }

        
        protected void Image_Click1(object sender, ImageClickEventArgs e)
        {
            string SectionID, HeadID;
            //***************Section****************
            if (this.Section.SelectedIndex != 0)
            { SectionID = Section.SelectedItem.Value; }
            else { SectionID = "ALL"; }
            //**************Head*****************
            if (this.Head.SelectedIndex != 0)
            { HeadID = Head.SelectedItem.Value; }
            else { HeadID = "ALL"; }
            //Response.Redirect("~/payrole/CALSAL.aspx?DDOID=" + DDO.SelectedItem.Value + "&HeadID=" + Head.SelectedItem.Value + "&SectionID=" + Section.SelectedItem.Value + "&year=" + year.SelectedItem.Text + "&Month=" + Month.SelectedItem.Value + "");
            Response.Redirect("~/payrole/CALSAL.aspx?DDOID=" + (string)Session["ddopid"] + "&HeadID=" + Head.SelectedItem.Value + "&SectionID=" + Section.SelectedItem.Value + "&year=" + year.SelectedItem.Text + "&Month=" + Month.SelectedItem.Value + "");

            //Response.Redirect("~/payrole/Salcalculation.aspx?Head="+Head.SelectedItem.Value+"&year="+year.SelectedItem.Text+"&Month="+Month.SelectedItem.Value+"");
            //if (Head.SelectedItem.Text != "All")
            //{
            //    Response.Redirect("~/payrole/CALSAL.aspx?Head=" + Head.SelectedItem.Value + "&year=" + year.SelectedItem.Text + "&Month=" + Month.SelectedItem.Value + "");
            //}
            //else
            //{
            //    Response.Redirect("~/payrole/CALSAL.aspx?Head=0&year=" + year.SelectedItem.Text + "&Month=" + Month.SelectedItem.Value + "");
            //}

        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payrole/SaldetH.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payrole/SaldetH.aspx");
        }
    }
}