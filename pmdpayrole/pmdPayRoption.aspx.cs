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

namespace NewWebApp.pmdpayrole
{
    public partial class pmdPayRoption : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
    Class1 c = new Class1();
    string PayReportOption;
    protected void Page_Load(object sender, EventArgs e)
    {
        PayReportOption = Session["report"].ToString();
        if (!IsPostBack)
        {
            if ((string)Session["iduser"] == null)
            {
                Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
            }
            if ((string)Session["ddoname"] != null && (string)Session["ddopid"] != null)
            {

                DDOText.Text = (string)Session["ddoname"];
                DDOIDLab.Text = (string)Session["ddopid"];
                dd();

                if (Request.QueryString["option"]=="2")
                {
                    c.ddl(gpfseries, "select sno,series from PMDBillSeries where report='shedule' order by series ", "series", "sno");


                }

                else
                {
                    c.ddl(gpfseries, "select * from pftype order by pftype", "pftype", "sno");

                }

                if (Request.QueryString["option"] == "8")
                {

                    c.ddl(gpfseries, "select * from pftype   where sno=3 ", "pftype", "sno");

                }


                if (Request.QueryString["option"] == "9")
                {

                    c.ddl(gpfseries, "select * from pftype   where sno=2 ", "pftype", "sno");

                }


            }
            else
            {
                this.MSGLabel.Text = "Please select Proper One...";
            }

           
        }
       
    }
    public void dd()
    {
        string ddoid = (string)Session["iduser"];
        //****************Drep
        Drep.Items.Clear();
        Drep.Items.Add("Paybill");
        Drep.Items.Add("GPF/NPP Schedule");
        Drep.Items.Add("G.I.S. Schedule");
        Drep.Items.Add("Income Tax");    
        Drep.Items.Add("GVR Schedule");
        Drep.Items.Add("HBA Schedule");
        Drep.Items.Add("ElecBill Schedule");
        Drep.Items.Add("HRR Schedule");
        Drep.Items.Add("Bank Statement");
        Drep.Items.Add("GPF Schedule Class iv");
        Drep.Items.Add("Vehicle Schedule");
        Drep.Items.Add("LIC Schedule");
        Drep.Items.Add("Vehicle Inst");
        Drep.Items.Add("HBA Insterest");
        Drep.Items.Add("Pran Schedule");
        Drep.Items.Insert(0, new ListItem("--select--"));
        //****************year 
        year.Items.Clear();
        //year.Items.Add("2010");
        //year.Items.Add("2011");
        //year.Items.Add("2012");
        //year.Items.Add("2013");
        year.Items.Add("2015");
        year.Items.Add("2016");
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
        
        //****************payhead
        if (Convert.ToInt32(ddoid) == 4 || Convert.ToInt32(ddoid) == 76 || Convert.ToInt32(ddoid) == 79 || Convert.ToInt32(ddoid) == 80 || Convert.ToInt32(ddoid) == 85 || Convert.ToInt32(ddoid) == 88)
        {
            cl.ds = cl.DataFill("select distinct ddoid,pay_head.headid,pay_head.headname from pmdcalulatedsalary inner join pay_head on pay_head.headid=pmdcalulatedsalary.headid where ddoid='" + DDOIDLab.Text + "'and (not headname='ALL')");
        }
        else
        {
            cl.ds = cl.DataFill("SELECT DISTINCT Pay_Head.headid, Pay_Head.headname FROM         pmdcalulatedsalary INNER JOIN                      Pay_Head ON Pay_Head.headid = pmdcalulatedsalary.headid where  (not headname='ALL') order by Pay_Head.headname ");
        }
        Head.DataSource = cl.ds;
        Head.DataTextField = "headname";
        Head.DataValueField = "headid";
        Head.DataBind();
        Head.Items.Insert(0, new ListItem("ALL"));
        /*cl.ds = cl.DataFill("SELECT     headname, headid FROM  Pay_Head ORDER BY headname");
        Head.DataSource = cl.ds;
        Head.DataTextField = "headname";
        Head.DataValueField = "headid";
        Head.DataBind();
        Head.Items.Insert(0, new ListItem("ALL"));*/



        cl.ds = cl.DataFill("select sno,hname from hospitalname where sno in (select distinct(adminunit) from hospitalname where ddoid='" + Session["ddopid"] + "' and adminunit is not null)");
        hname.DataSource = cl.ds;
        hname.DataTextField = "hname";
        hname.DataValueField = "sno";
        hname.DataBind();

        hname.Items.Add(new ListItem("ALL", "0"));
     

    }
   
    protected void save_Click(object sender, EventArgs e)
    {
        if ((string)Session["ddopid"] != null)
        {
            setreport();
        }
    }
    
    public void salgo()
    {
        //Response.Redirect("~/payrole/payreport/pmdXrep.aspx?a=" + Request.QueryString["a"] + "&b=" + 4);
        Response.Redirect("~/pmdpayrole/pmdXrep.aspx?DDO=" + (string)Session["ddopid"] + "&Head=" + Head.SelectedItem.Value + "&year=" + year.SelectedItem.Text + "&Month=" + Month.SelectedItem.Value + "");
    
    }
    public void setreport()
    {
        //if (Drep.SelectedIndex != 0)
       // {
            string HeadID,pftype;
            //***************Section****************
            
            //**************Head*****************
            if (this.Head.SelectedIndex != 0)
            { HeadID = Head.SelectedItem.Value; }
            else { HeadID = "ALL"; }
            //if (this.gpfseries.SelectedIndex != 0)
            //{ GPFser = gpfseries.SelectedItem.Value; }
            //else { GPFser = "ALL"; }

            pftype = gpfseries.SelectedItem.Value;
            //GPFser = gpfseries.SelectedValue.ToString();
            if (PayReportOption == "Paybill")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdXrep.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedItem.Value + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>"); 


            }
            else if (PayReportOption == "GPF Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdpaygpfshedule.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&adminunit=" + hname.SelectedItem.Value + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>"); 
            }
            else if (PayReportOption == "G.I.S. Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdpayGIS.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>"); 
            }
            else if (PayReportOption == "Income Tax Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdpayincometax.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>"); 
            }
            else if (PayReportOption == "GVR Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdpayGVR.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>"); 
            }

            else if (PayReportOption == "GPF Class iv Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdpaygpf4shedule.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }



            else if (PayReportOption == "Vehicle Advance Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('vehsch.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }


            else if (PayReportOption == "Vehicle Advance Interest Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('vehschinst.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }

            else if (PayReportOption == "HBA Interest Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('HBASchinst.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }

            else if (PayReportOption == "LIC Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('lic.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }
            else if (PayReportOption == "HBA Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('HBASch.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }
            else if (PayReportOption == "ElecBill Schedule")//Drep.SelectedItem.Text
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdElecbillSch.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }
            else if (PayReportOption == "HRR Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdHRRSch.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }
            else if (PayReportOption == "Bank Statement")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdbankstate.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }
            else if (PayReportOption == "PRAN Schedule")
            {
                Response.Write("<script>");
                Response.Write("window.open('pmdpaygpfshedule1.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&adminunit=" + hname.SelectedValue + "&HeadID=" + HeadID + "&pftype=" + pftype + "','_blank')");
                Response.Write("</script>");
            }
        }
     
    protected void gpfseries_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void hname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void year_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/pmdPayRopt.aspx");
        }
    }
}