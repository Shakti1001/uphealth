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


namespace NewWebApp.pmdpayrole
{
    public partial class pmdSaldetH : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd;
        int optselect;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                usecheck();
                //Label3.Visible = false;

            }
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
                    Response.Redirect("~/Authenticate/login.aspx");
                }
            }
        }
        public void fillDDO()
        {

            //cl.ds = cl.DataFill("SELECT DISTINCT Ucreate.iduser, Ucreate.username, Ucreate.DisId, hospitalname.htype FROM         Ucreate INNER JOIN hospitalname ON Ucreate.iduser = hospitalname.ddoid WHERE     (Ucreate.lavel NOT IN (1, 2, 8))ORDER BY Ucreate.username");
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
            else //3921
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
                this.mess.Text = "Please Select DDO for Salary Process";
                this.mess.Visible = true;

                SalDet.Enabled = false;

                LADD.Enabled = false;
                //CCSal.Enabled = false;
                GPayB.Enabled = false;
                GPayRep.Enabled = false;
                statuslink.Enabled = true;
                Session.Add("ddopid", "");
            }

        }
        public void setlinkstatus()
        {
            if ((string)Session["iduser"] != null)
            {
                SalDet.Enabled = true;

                LADD.Enabled = true;
                //CCSal.Enabled = true;
                GPayB.Enabled = true;
                GPayRep.Enabled = true;
                this.Label1.Text = "Salary Process For : ";
                this.Label2.Text = "'" + (string)Session["fullname"] + "'";
            }
            else
            {
                this.Label1.Text = "Please Select DDO for Salary Process";
                SalDet.Enabled = false;

                LADD.Enabled = false;
                //CCSal.Enabled = false;
                GPayB.Enabled = false;
                GPayRep.Enabled = false;
            }
        }

        protected void SalDet_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/payrole/payroleselect.aspx?a="+Request.QueryString["a"]);//+"&b="+4);
            //Response.Redirect("~/payrole/payroleselect.aspx?a=" + DDONAME.SelectedItem.Value + "");
            //Session.Add("ddo", DDONAME.SelectedItem.Value);
            bool i;
            i = cl.checkE((string)Session["iduser"]);
            if (i == true)
            {
                if (DDONAME.SelectedIndex != 0)
                {
                    Response.Redirect("~/pmdpayrole/pmdpayroleselect.aspx");

                }
                else
                {
                    this.mess.Visible = true;
                    this.mess.Text = "Please Select DDO for Salary Process";
                }


            }
            else
            {
                Response.Redirect("~/pmdpayrole/pmdpayroleselect.aspx");
            }
        }

        protected void LADD_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/payrole/ADVLOANENTRY.aspx");
            bool i;
            i = cl.checkE((string)Session["iduser"]);
            if (i == true)
            {
                if (DDONAME.SelectedIndex != 0)
                {
                    Response.Redirect("~/pmdpayrole/pmdloanedit.aspx?optselect=" + 1 + "");
                }
                else
                {
                    this.mess.Visible = true;
                    this.mess.Text = "Please Select DDO for Salary Process";
                }
            }
            else
            {
                Response.Redirect("~/pmdpayrole/pmdLoanedit.aspx?optselect=" + 1 + "");
            }
            optselect = 1;

        }
        protected void ELADD_Click(object sender, EventArgs e)
        {

        }
       
        //protected void CCSal_Click(object sender, EventArgs e)
        //{
        //     bool i;
        //    i = cl.checkE((string)Session["iduser"]);
        //    if (i == true)
        //    {
        //        if (DDONAME.SelectedIndex != 0)
        //        {
        //            Response.Redirect("~/pmdpayrole/pmdDDOcrosscheck.aspx");
        //        }
        //        else
        //        {
        //            this.mess.Visible = true;
        //            this.mess.Text = "Please Select DDO for Salary Process";
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("~/pmdpayrole/pmdDDOcrosscheck.aspx");
        //    }
        //}
        protected void GPayB_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkE((string)Session["iduser"]);
            if (i == true)
            {
                if (DDONAME.SelectedIndex != 0)
                {
                    Response.Redirect("~/pmdpayrole/pmdGenerateBill.aspx");
                }
                else
                {
                    this.mess.Visible = true;
                    this.mess.Text = "Please Select DDO for Salary Process";
                }
            }
            else
            {
                Response.Redirect("~/pmdpayrole/pmdGenerateBill.aspx");
            }
        }
        protected void GPayRep_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/payrole/payreport/PayRoption.aspx");
            bool i;
            i = cl.checkE((string)Session["iduser"]);
            if (i == true)
            {
                if (DDONAME.SelectedIndex != 0)
                {
                    //Response.Redirect("~/payrole/payreport/PayRoption.aspx");
                    Response.Redirect("~/pmdpayrole/pmdPayRopt.aspx");
                }
                else
                {
                    this.mess.Visible = true;
                    this.mess.Text = "Please Select DDO for Salary Process";
                }
            }
            else
            {
                //Response.Redirect("~/payrole/payreport/PayRoption.aspx");
                Response.Redirect("~/payrole/PayRopt.aspx");
            }
        }
        protected void statusrep_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/pmdStatusrep.aspx");

        }
        protected void payslip_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/pmdgenpayslip.aspx");
        }
        protected void yedreport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/pmdyearreport.aspx");
        }
        //protected void increment_Click(object sender, EventArgs e)
        //{
        //    string ddoid = (string)Session["iduser"];
        //    //cl.ds = cl.DataFill("select Increment from pay_sal_mast where ddocode=" + (string)Session["iduser"] + " and Increment='Y'");
        //    cl.ds = cl.DataFill("select Increment from pay_sal_mast where idno in (select idno from salaryselect where ddoid=" + (string)Session["iduser"] + ") and Increment='Y'");

        //    if (cl.ds.Tables[0].Rows.Count != 0)
        //    {
        //        //LinkButton1.Visible = false;
        //        //Label3.Visible = true;
        //        //Label3.ForeColor = System.Drawing.Color.Red;
        //        //Label3.Text = "You have already Applied Increment Once";
        //    }
        //    else
        //    {
        //        try
        //        {
        //            cl.upcon.Open();
        //            //cl.ds = cl.DataFill("Select * from pay_sal_mast where ddocode=" + ddoid + "");
        //            cl.ds = cl.DataFill("Select * from pay_sal_mast where idno in (select idno from salaryselect where ddoid=" + (string)Session["iduser"] + ")");
        //            if (cl.ds.Tables[0].Rows.Count > 0)
        //            {
        //                int j;
        //                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
        //                {
        //                    int idnum = Convert.ToInt32(cl.ds.Tables[0].Rows[j]["idno"]);
        //                    double Basicpay = Convert.ToDouble(cl.ds.Tables[0].Rows[j]["basicpay"]);
        //                    double gradepay = Convert.ToDouble(cl.ds.Tables[0].Rows[j]["Gradepay"]);
        //                    double Increbasicpay = Basicpay + Convert.ToDouble((Basicpay + gradepay) * .03);
        //                    int numintpart = (int)(Increbasicpay);
        //                    int lastdigit = (numintpart % 10);
        //                    if (lastdigit > 0)
        //                    {
        //                        Increbasicpay = numintpart + 10 - lastdigit;
        //                    }
        //                    else
        //                    {
        //                        Increbasicpay = numintpart;
        //                    }

        //                    //cmd = new SqlCommand("update pay_sal_mast set basicpay = '" + Increbasicpay + "',Increment='Y'  where idno='" + idnum + "' and ddocode=" + ddoid + "", cl.upcon);
        //                    cmd = new SqlCommand("update pay_sal_mast set basicpay = '" + Increbasicpay + "',Increment='Y'  where idno='" + idnum + "' ", cl.upcon);



        //                    cmd.ExecuteNonQuery();

        //                }

        //                if (cmd.ExecuteNonQuery() == 1)
        //                {
        //                    //Label3.Visible = true;
        //                    //Label3.ForeColor = System.Drawing.Color.Green;
        //                    //Label3.Text = "Increment applied for all doctors...please correct basic salary of those who are not eligible for increment";
        //                }
        //            }
        //            else
        //            {
        //                Label3.Visible = true;
        //                Label3.ForeColor = System.Drawing.Color.Red;
        //                Label3.Text = "No record Found";

        //            }




        //        }
        //        catch (Exception ex)
        //        {
        //            //Response.Write("Error: + ex.Message");
        //            Label3.Visible = true;
        //            Label3.ForeColor = System.Drawing.Color.Red;
        //            Label3.Text = "Error:Some Error Occured";
        //        }

        //        finally
        //        { cl.upcon.Close(); }
        //    }
        //}
        protected void optionern_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkE((string)Session["iduser"]);
            if (i == true)
            {
                if (DDONAME.SelectedIndex != 0)
                {
                    Response.Redirect("~/pmdpayrole/pmdloanedit.aspx?optselect=" + 2 + "");
                }
                else
                {
                    this.mess.Visible = true;
                    this.mess.Text = "Please Select DDO for Salary Process";
                }
            }
            else
            {
                Response.Redirect("~/pmdpayrole/pmdloanedit.aspx?optselect=" + 2 + "");
            }
            optselect = 2;
        }
        protected void unitadmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/adminunit.aspx");
        }
        protected void incmnt_Click(object sender, EventArgs e)
        {
            string ddoid = (string)Session["iduser"];
            var now = DateTime.Now;
            var currentMonth = now.Month;
            cl.ds = cl.DataFill("SELECT     pmd_salaryselect.idno, pmd_salaryselect.name, pmd_salaryselect.districtname, pmd_salaryselect.ddoid, pmd_salaryselect.districtid, pmd_salaryselect.ddoname, pmd_salaryselect.poposting, PMD_Pay_sal_mast.incrementyear, PMD_Pay_sal_mast.Increment, PMD_Pay_sal_mast.basicpay, PMD_Pay_sal_mast.Gradepay, PMD_Pay_sal_mast.pensionpay FROM         pmd_salaryselect INNER JOIN PMD_Pay_sal_mast ON pmd_salaryselect.idno = PMD_Pay_sal_mast.idno WHERE (ddoid='" + (string)Session["iduser"] + "' and (year(getdate())=PMD_Pay_sal_mast.incrementyear))");
            //   cl.ds = cl.DataFill("select idno,basicpay,Gradepay,Increment  from pay_sal_mast where idno in (select idno from salaryselect where ddoid=" + (string)Session["iduser"] + ") and Increment='Y'");
            try
            {
                // if (cl.ds.Tables[0].Rows.Count != 0)
                if ((cl.ds.Tables[0].Rows.Count != 0) && (currentMonth > 6))
                {
                    cl.upcon.Open();
                    int j;
                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {

                        int idnum = Convert.ToInt32(cl.ds.Tables[0].Rows[j]["idno"]);
                        double Basicpay = Convert.ToDouble(cl.ds.Tables[0].Rows[j]["basicpay"]);
                        double gradepay = Convert.ToDouble(cl.ds.Tables[0].Rows[j]["Gradepay"]);
                        double Increbasicpay = Basicpay + Convert.ToDouble((Basicpay + gradepay) * .03);
                        int numintpart = (int)(Increbasicpay);
                        int lastdigit = (numintpart % 10);
                        if (lastdigit > 0)
                        {
                            Increbasicpay = numintpart + 10 - lastdigit;
                        }
                        else
                        {
                            Increbasicpay = numintpart;
                        }
                        //  cmd = new SqlCommand("update pay_sal_mast set basicpay = '" + Increbasicpay + "',Increment='N'  where idno='" + idnum + "' ", cl.upcon);
                        cmd = new SqlCommand("update pmd_pay_sal_mast set basicpay = '" + Increbasicpay + "',incrementyear=incrementyear+1  where idno='" + idnum + "' ", cl.upcon);
                        cmd.ExecuteNonQuery();
                    }

                    Label6.Visible = true;
                    Label6.ForeColor = System.Drawing.Color.Green;
                    Label6.Text = "Increment applied for " + (j) + " Paramedical Staff ...please correct basic salary of those who are not eligible for increment";

                }
                else
                {
                    //LinkButton1.Visible = false;
                    Label6.Visible = true;
                    Label6.ForeColor = System.Drawing.Color.Red;
                    Label6.Text = "You have already Applied Increment Once";
                }
            }

            catch (Exception ex)
            {
                Label6.Visible = true;
                Label6.ForeColor = System.Drawing.Color.Red;
                Label6.Text = "Error:Some Error Occured";
            }

            finally
            {
                cl.upcon.Close();
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parahome.aspx");
        }
    }
}