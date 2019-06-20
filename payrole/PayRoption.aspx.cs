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
    public partial class PayRoption : System.Web.UI.Page
    {
         ClDatabase cl = new ClDatabase();
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
        Drep.Items.Insert(0, new ListItem("--select--"));
        //****************year 
        year.Items.Clear();
        //year.Items.Add("2010");
        //year.Items.Add("2011");
        //year.Items.Add("2012");
        //year.Items.Add("2013");
        year.Items.Add("2015");
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
        
        //****************payhead
        if (Convert.ToInt32(ddoid) == 4 || Convert.ToInt32(ddoid) == 76 || Convert.ToInt32(ddoid) == 79 || Convert.ToInt32(ddoid) == 80 || Convert.ToInt32(ddoid) == 85 || Convert.ToInt32(ddoid) == 88)
        {
            //cl.ds = cl.DataFill("select distinct ddocode,pay_head.headid,pay_head.headname from pay_sal_mast inner join pay_head on pay_head.headid=pay_sal_mast.headid where ddocode='" + DDOIDLab.Text + "'and (not headname='ALL')");
            cl.ds = cl.DataFill("SELECT    distinct( Pay_sal_mast.headid), Pay_Head.headname, salaryselect.ddoid FROM         Pay_sal_mast INNER JOIN salaryselect ON Pay_sal_mast.idno = salaryselect.idno INNER JOIN Pay_Head ON Pay_sal_mast.headid = Pay_Head.headid where  ddoid='" + DDOIDLab.Text + "' and (not headname='ALL') order by headname");

        
        
        }
        else
        {
            //cl.ds = cl.DataFill("select distinct ddocode,pay_head.headid,pay_head.headname from pay_sal_mast inner join pay_head on pay_head.headid=pay_sal_mast.headid where ddocode='" + ddoid + "'and (not headname='ALL')");

          cl.ds = cl.DataFill("SELECT    distinct( Pay_sal_mast.headid), Pay_Head.headname FROM         Pay_sal_mast INNER JOIN salaryselect ON Pay_sal_mast.idno = salaryselect.idno INNER JOIN Pay_Head ON Pay_sal_mast.headid = Pay_Head.headid where  (not headname='ALL') order by headname");

        
        }
        Head.DataSource = cl.ds;
        Head.DataTextField = "headname";
        Head.DataValueField = "headid";
        Head.DataBind();
        //Head.Items.Insert(0, new ListItem("ALL"));

        Head.Items.Add(new ListItem("ALL", "0"));

   


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
        //Response.Redirect("~/payrole/payreport/Xrep.aspx?a=" + Request.QueryString["a"] + "&b=" + 4);
        Response.Redirect("~/payrole/Xrep.aspx?DDO=" + (string)Session["ddopid"] + "&Head=" + Head.SelectedItem.Value + "&year=" + year.SelectedItem.Text + "&Month=" + Month.SelectedItem.Value + "");
    
    }
    public void setreport()
    {
        //if (Drep.SelectedIndex != 0)
       // {
            string HeadID,GPFser;
            //***************Section****************
            
            //**************Head*****************
            if (this.Head.SelectedIndex != 0)
            { HeadID = Head.SelectedItem.Value; }
            else { HeadID = "0"; }
            //if (this.gpfseries.SelectedIndex != 0)
            //{ GPFser = gpfseries.SelectedItem.Value; }
            //else { GPFser = "ALL"; }

            GPFser = gpfseries.SelectedItem.Value;
            if (PayReportOption == "Paybill")
            {
            //    Response.Redirect("~/payrole/payreport/Xrep.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&DDOID=" + (string)Session["ddopid"] + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
             // Response.Redirect("~/payrole/payreport/Xrep.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('Xrep.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>"); 

                //Response.Redirect("Xrep.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");

            }
            else if (PayReportOption == "GPF/New Pension Schedule")
            {
                //Response.Redirect("~/payrole/payreport/paygpfshedule.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
               // Response.Redirect("paygpfshedule.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('paygpfshedule.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser="+GPFser+"','_blank')");
                Response.Write("</script>"); 
            }
            else if (PayReportOption == "G.I.S. Schedule")
            {
                //Response.Redirect("payGIS.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&year=" + year.SelectedItem.Text + "&Month=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('payGIS.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>"); 
            }
            else if (PayReportOption == "Income Tax Schedule")
            {
                //Response.Redirect("payincometax.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('payincometax.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>"); 
            }
            else if (PayReportOption == "GVR Schedule")
            {
                //Response.Redirect("payGVR.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('payGVR.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>"); 
            }
            else if (PayReportOption == "House Buliding Adv.")
            {
                //Response.Redirect("payHBA.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('payHBASch.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>"); 
            }
            else if (PayReportOption == "HBA Schedule")
            {
                //Response.Redirect("payHBA.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('HBASch.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>");
            }
            else if (PayReportOption == "ElecBill Schedule")//Drep.SelectedItem.Text
            {
                //Response.Redirect("payHBA.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('ElecbillSch.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>");
            }
            else if (PayReportOption == "HRR Schedule")
            {
                //Response.Redirect("payHBA.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('HRRSch.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>");
            }
            else if (PayReportOption == "Bank Statement")
            {
                //Response.Redirect("payHBA.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&SectionID=" + SectionID + "&HeadID=" + HeadID + "");
                Response.Write("<script>");
                Response.Write("window.open('bankstate.aspx?sqloption=06igf41k9806cy121k96igf4806cy3434349003497797&years=" + year.SelectedItem.Text + "&Months=" + Month.SelectedItem.Value + "&Mtext=" + Month.SelectedItem.Text + "&HeadID=" + HeadID + "&GPFser=" + GPFser + "','_blank')");
                Response.Write("</script>");
            }
        }
       // else
       // {
           // this.MSGLabel.Text = "Please select Proper One...";
        //}
 

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payrole/PayRopt.aspx");
        }
    }
}