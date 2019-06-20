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
    public partial class ADVLOANENTRY : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string date, month, year, sacdate;
        int idnum;
        string dedw;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                pdata();
                this.GridView1.DataBind();
                this.GridView2.DataBind();

            }
            idnum = Convert.ToInt32(Request.QueryString["idno"]);

        }

        public void pdata()
        {
            cl.ds = cl.DataFill("SELECT senno,name FROM personaldetails where idno='" + Request.QueryString["idno"] + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                this.sen.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                this.name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {

            }
        }
        public void maxpicl()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(lid),0)+ 1 FROM pay_loan_entry");
            ME.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void dedsave()
        {

            date = datedrp.SelectedValue;
            month = mondrp.SelectedValue;
            year = yeardrp.SelectedValue;
            sacdate = date + "/" + month + "/" + year;
            if (dedwithDrp.SelectedIndex == 0)
            {
                dedw = "No";

            }
            else
            {
                dedw = dedwithDrp.SelectedValue.ToString();

            }

            if (LamtT.Text != "" && insttext.Text != "")
            {
                try
                {
                    maxpicl();
                    if (ConnectionState.Closed == cl.upcon.State)
                    {
                        cl.upcon.Open();
                        SqlCommand cmd = new SqlCommand("AddOPTDED", cl.upcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@lid", SqlDbType.Int, 4).Value = Convert.ToInt32(ME.Text);
                        cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];
                        if (this.DLoan.SelectedIndex != 0)
                        {
                            cmd.Parameters.Add("@litemid", SqlDbType.Int, 4).Value = this.DLoan.SelectedItem.Value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@litemid", SqlDbType.Int, 4).Value = 0;
                        }
                        cmd.Parameters.Add("@TLrate", SqlDbType.Float, 8).Value = Convert.ToDouble(LamtT.Text);
                        cmd.Parameters.Add("@linst", SqlDbType.Int, 4).Value = Convert.ToInt32(TInst.Text);
                        cmd.Parameters.Add("@ldatesactioned", SqlDbType.VarChar, 50).Value = sacdate;
                        cmd.Parameters.Add("@nlinstpaid", SqlDbType.Int, 4).Value = Convert.ToInt32(InstpaidT.Text);
                        if (LamtT.Text != "" && insttext.Text != "")
                        {
                            //cmd.Parameters.Add("@intamt", SqlDbType.Int, 4).Value = (Convert.ToInt32(LamtT.Text) / Convert.ToInt32(TInst.Text));
                            cmd.Parameters.Add("@intamt", SqlDbType.Int, 4).Value = Convert.ToInt32(insttext.Text);
                        }
                        else
                        {
                            cmd.Parameters.Add("@intamt", SqlDbType.Int, 4).Value = 0;
                        }
                        cmd.Parameters.Add("@ltype", SqlDbType.Int, 4).Value = 1;
                        cmd.Parameters.Add("@adamt", SqlDbType.Float, 8).Value = Convert.ToDouble(adamt.Text);



                        cmd.Parameters.Add("@dedwith", SqlDbType.VarChar, 1).Value = dedw;
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            Label1.Visible = true;
                            Label1.ForeColor = System.Drawing.Color.Gold;
                            Label1.Text = "Added Successfully";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.Gold;
                    Label1.Text = ("Error :" + ex.Message);
                }
                finally
                {
                    if (ConnectionState.Open == cl.upcon.State)
                    {
                        cl.upcon.Close();
                        this.GridView1.DataBind();
                    }
                }
            }
        }
        protected void saveded_Click(object sender, EventArgs e)
        {
            if (saveded.Text.Equals("Save Deduction"))
            {

                dedsave();
            }
            if (saveded.Text.Equals("Update deduction"))
            {
                dedupdate();
            }

        }
        private void loanfill()
        {
            int i;
            for (i = 01; i <= 31; i++)
            {
                if (i <= 9)
                {
                    datedrp.Items.Add("0" + i.ToString());
                }
                else
                {
                    datedrp.Items.Add(i.ToString());
                }
            }
            for (i = 1950; i <= 2016; i++)
            {
                yeardrp.Items.Add(i.ToString());
            }

            dedwithDrp.Items.Insert(0, new ListItem("--select--"));
            dedwithDrp.SelectedIndex = 0;
            cl.ds = cl.DataFill("SELECT litemname2,litemid FROM pay_optloan ORDER BY litemname");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                DLoan.DataSource = cl.ds;
                DLoan.DataTextField = "litemname2";
                DLoan.DataValueField = "litemid";
                DLoan.DataBind();
                DLoan.Items.Insert(0, new ListItem("--select--"));
            }
            else
            {

            }
        }
        public void earfill()
        {
            cl.ds = cl.DataFill("SELECT optearid, optearname FROM pay_optearmast ORDER BY optearname");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                ErD.DataSource = cl.ds;
                ErD.DataTextField = "optearname";
                ErD.DataValueField = "optearid";
                ErD.DataBind();
                ErD.Items.Insert(0, new ListItem("--select--"));
            }
            else
            {

            }
        }
        public void maxpicEAR()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(earoptid),0)+ 1 FROM pay_opt_earning");
            ME.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void earsave()
        {
            if (Eramt.Text != "")
            {
                try
                {
                    maxpicEAR();
                    if (ConnectionState.Closed == cl.upcon.State)
                    {
                        cl.upcon.Open();
                        SqlCommand cmd = new SqlCommand("addOPTEAR", cl.upcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@earoptid", SqlDbType.Int, 4).Value = Convert.ToInt32(ME.Text);
                        if (this.ErD.SelectedIndex != 0)
                        {
                            cmd.Parameters.Add("@optearid", SqlDbType.Int, 4).Value = this.ErD.SelectedItem.Value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@earoptid", SqlDbType.Int, 4).Value = 0;
                        }
                        cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];

                        if (Eramt.Text != "")
                        {
                            cmd.Parameters.Add("@optearamt", SqlDbType.Float, 8).Value = Convert.ToDouble(Eramt.Text);
                        }
                        else
                        {
                            cmd.Parameters.Add("@optearamt", SqlDbType.Int, 4).Value = 0;
                        }

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            Label1.Visible = true;
                            Label1.ForeColor = System.Drawing.Color.Gold;
                            Label1.Text = "Added Successfully";
                            Eramt.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.Gold;
                    Label1.Text = ("Error :" + ex.Message);
                }
                finally
                {
                    if (ConnectionState.Open == cl.upcon.State)
                    {
                        cl.upcon.Close();
                        this.GridView2.DataBind();
                    }
                }
            }
        }
        protected void saveear_Click(object sender, EventArgs e)
        {
            earsave();
        }
        public void dedupdate()
        {
            idnum = Convert.ToInt32(Request.QueryString["idno"]);
            int lid = Convert.ToInt32(Label2.Text);
            date = datedrp.SelectedValue;
            month = mondrp.SelectedValue;
            year = yeardrp.SelectedValue;
            sacdate = date + "/" + month + "/" + year;
            if (dedwithDrp.SelectedIndex == 0)
            {
                dedw = "N";

            }
            else
            {
                dedw = dedwithDrp.SelectedValue.ToString();

            }



            try
            {
                cl.upcon.Open();
                cl.cmd = new SqlCommand("update pay_loan_entry set litemid=" + DLoan.SelectedValue + ",TLrate=" + LamtT.Text + ",intamt=" + insttext.Text + ",adamt=" + adamt.Text + ",ldatesactioned='" + sacdate + "',linst=" + TInst.Text + ",nlinstpaid=" + InstpaidT.Text + ",dedwith='" + dedw + "' where idno='" + idnum + "' and lid='" + lid + "'", cl.upcon);
                cl.cmd.ExecuteNonQuery();
                if (cl.cmd.ExecuteNonQuery() == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "Updated Succesfully";
                    saveded.Text = "Save Deduction";
                    saveded.Visible = true;
                    DLoan.SelectedIndex = 0;
                    LamtT.Text = "";
                    insttext.Text = "";
                    adamt.Text = "";
                    TInst.Text = "";
                    InstpaidT.Text = "";
                    datedrp.SelectedIndex = 0;
                    mondrp.SelectedIndex = 0;
                    yeardrp.SelectedIndex = 0;
                    dedwithDrp.SelectedIndex = 0;


                }
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = ("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();
                this.GridView1.DataBind();

            }

        }
        public void earupdate()
        {
        }
        protected void OptEar_CheckedChanged(object sender, EventArgs e)
        {
            //if (OptEar.Checked = true)
            //{
            PanelER.Visible = true;
            Panelded.Visible = false;
            Optded.Checked = false;
            Label1.Visible = false;
            earfill();
            //}
        }
        protected void Optded_CheckedChanged(object sender, EventArgs e)
        {
            //CmbFillLoanType();
            //if (Optded.Checked = true)
            //{
            Panelded.Visible = true;
            PanelER.Visible = false;
            OptEar.Checked = false;
            Label1.Visible = false;
            loanfill();
            // }
            //else
            //{
            //    Panelded.Visible = true;
            //    PanelER.Visible = false;
            //    OptEar.Checked = false;
            //    Label1.Visible = false;
            //}
        }

       
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Select")
            {
                saveded.Text = "Update deduction";
                saveded.Visible = true;
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                cl.ds = cl.DataFill("SELECT pay_loan_entry.lid, pay_optloan.litemname, pay_loan_entry.TLrate,pay_loan_entry.litemid, pay_loan_entry.linst, pay_loan_entry.ldatesactioned , pay_loan_entry.nlinstpaid FROM pay_optloan INNER JOIN pay_loan_entry ON pay_optloan.litemid = pay_loan_entry.litemid INNER JOIN Pay_sal_mast ON pay_loan_entry.idno = Pay_sal_mast.idno WHERE (pay_loan_entry.idno = " + idnum + ")");
                string lid = cl.ds.Tables[0].Rows[RowIndex][0].ToString();
                Label2.Text = lid;
                string itemid = cl.ds.Tables[0].Rows[RowIndex][3].ToString();

                try
                {
                    cl.upcon.Open();
                    cl.ds = cl.DataFill("SELECT * FROM pay_optloan INNER JOIN pay_loan_entry ON pay_optloan.litemid = pay_loan_entry.litemid INNER JOIN Pay_sal_mast ON pay_loan_entry.idno = Pay_sal_mast.idno WHERE (pay_loan_entry.idno = " + idnum + ") and pay_loan_entry.litemid=" + itemid + " and lid=" + lid + "");
                    //DLoan.SelectedValue = cl.ds.Tables[0].Rows[0][14].ToString();

                    DLoan.SelectedIndex = DLoan.Items.IndexOf(DLoan.Items.FindByValue(itemid));
                    LamtT.Text = cl.ds.Tables[0].Rows[0][7].ToString();
                    insttext.Text = cl.ds.Tables[0].Rows[0][11].ToString();
                    adamt.Text = cl.ds.Tables[0].Rows[0][13].ToString();
                    TInst.Text = cl.ds.Tables[0].Rows[0][8].ToString();
                    InstpaidT.Text = cl.ds.Tables[0].Rows[0][10].ToString();
                    string dedwith = cl.ds.Tables[0].Rows[0][15].ToString();
                    if (dedwith.Equals("No"))
                    {
                        dedwithDrp.SelectedIndex = 0;
                    }
                    sacdate = (cl.ds.Tables[0].Rows[0][9]).ToString();
                    date = sacdate.Substring(0, 2);
                    month = sacdate.Substring(3, 2);
                    year = sacdate.Substring(6, 4);
                    datedrp.SelectedIndex = datedrp.Items.IndexOf(datedrp.Items.FindByValue(date));
                    mondrp.SelectedIndex = mondrp.Items.IndexOf(mondrp.Items.FindByValue(month));
                    yeardrp.SelectedIndex = yeardrp.Items.IndexOf(yeardrp.Items.FindByValue(year));
                    dedwithDrp.SelectedIndex = dedwithDrp.Items.IndexOf(dedwithDrp.Items.FindByValue(dedwith));


                }
                catch (Exception ex)
                {
                    Response.Write("Error:" + ex.Message);
                    //Label2.Text = "Error:+ ex.Message";
                }

                finally
                { cl.upcon.Close(); }

            }
        }





        protected void DdlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaldetH.aspx");
        }
    }
}