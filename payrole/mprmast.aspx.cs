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
using System.Security.Policy;

namespace NewWebApp.payrole
{
    public partial class mprmast : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        Class1 c = new Class1();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        string payidstr, npa;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //TextBox1.Text = "";
                //c.gv(GridView1, "select convert(varchar(12),date,106),dutyid,cases from mpr where compid=15572 and datepart(month,date)=(datepart(month,(select max(date) from mpr where compid=15572)))and datepart(year,date)=(datepart(year,(select max(date) from mpr where compid="+Request.QueryString["idno"]+"))) order by date desc");
                //c.gv(GridView1, "SELECT     CONVERT(varchar(12), mpr.date, 106) AS LDATE, mpr.cases, dutytype.dutyname FROM  mpr INNER JOIN dutytype ON mpr.dutyid = dutytype.dutyid WHERE     (mpr.compid = " + Request.QueryString["idno"] + ") AND (DATEPART(month, mpr.date) = DATEPART(month,(SELECT     MAX(date) AS Expr1 FROM          mpr AS mpr_2 WHERE      (compid = " + Request.QueryString["idno"] + ")))) AND (DATEPART(year, mpr.date) = DATEPART(year,(SELECT     MAX(date) AS Expr1 FROM          mpr AS mpr_1 WHERE      (compid = " + Request.QueryString["idno"] + ")))) ORDER BY mpr.date DESC");

                c.gv(GridView1, "SELECT TOP (31) mpr.idno,CONVERT(varchar(12), mpr.date, 106) as[Date] , mpr.cases as[Cases] , dutytype.dutyname as[Duty Name]  FROM  mpr INNER JOIN dutytype ON mpr.dutyid = dutytype.dutyid WHERE     (mpr.compid = " + Request.QueryString["idno"] + ") ORDER BY mpr.date DESC ");


                if (GridView1.Rows.Count > 0)
                {
                    GridView1.HeaderRow.Cells[2].Visible = false;


                    foreach (GridViewRow gvr in GridView1.Rows)
                    {
                        gvr.Cells[2].Visible = false;


                    }

                }

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                Uidt.Text = (string)Session["iduser"];
                this.Label2.Text = Request.QueryString["idno"];

                //cl.ds = cl.DataFill("select payid from pay_sal_mast where idno='" + Request.QueryString["idno"] + "'");

                //if (cl.ds.Tables[0].Rows.Count > 0)
                //{
                //    payidstr = cl.ds.Tables[0].Rows[0][0].ToString();
                //    Label4.Text = payidstr;
                basicdata();

                DT1.Enabled = false;
                //    DEmpt.Enabled = false;

                //    Save.Visible = false;
                //}
                //else
                //{

                //    basicdata();
                //    Save.Visible = true;

                //}
                //till here copy

            }
        }
       
        public void basicdata()
        {
            string a, b, c, d, e;
            try
            {//ddopid
                cl.ds = cl.DataFill("SELECT     name, post, hname, districtname,ddoname,ddoid FROM salaryselect  where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    if (!(cl.ds.Tables[0].Rows[0]["name"].ToString().Equals(System.DBNull.Value)))
                    {
                        a = cl.ds.Tables[0].Rows[0]["name"].ToString();
                    }
                    else
                    {
                        a = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[0]["post"].ToString().Equals(System.DBNull.Value)))
                    {
                        b = cl.ds.Tables[0].Rows[0]["post"].ToString();
                    }
                    else
                    {
                        b = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[0]["hname"].ToString().Equals(System.DBNull.Value)))
                    {
                        c = cl.ds.Tables[0].Rows[0]["hname"].ToString();
                    }
                    else
                    {
                        c = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[0]["districtname"].ToString().Equals(System.DBNull.Value)))
                    {
                        d = cl.ds.Tables[0].Rows[0]["districtname"].ToString();
                    }
                    else
                    {
                        d = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[0]["ddoname"].ToString().Equals(System.DBNull.Value)))
                    {
                        DT1.Text = cl.ds.Tables[0].Rows[0]["ddoname"].ToString();
                    }
                    else
                    {
                        DT1.Text = "";
                    }

                    lblname.Text = a.Trim() + ", " + b.Trim() + ", " + c.Trim();

                    if (!(cl.ds.Tables[0].Rows[0]["ddoid"].ToString().Equals(System.DBNull.Value)))
                    {
                        ddoid.Text = cl.ds.Tables[0].Rows[0]["ddoid"].ToString();
                    }


                    else
                    {
                        ddoid.Text = "";
                    }
                }

                else
                {

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
            }
        }

        public void Basicsave()
        {

            if (ConnectionState.Closed == cl.upcon.State)
            {
                cl.upcon.Open();//SqlCommand cmd = new SqlCommand("insert into Pay_sal_mast(payid, idno, empltypeid, ddocode, sectionid, headid, scaleid, bankid, bankaccno, paymode, incdueon, lastincdate, incstatus, gpfno, gpfcontstatus, plino, nomineename, basicpay, npaall, dearnesspay, da,Ehra, cca, perpay, tpay, sppay, gpf, Dhra, gisi, giss, incometax,salded, remarks,  modifieruserid, dataentrydate, hostipaddress)values (@payid, @idno, @empltypeid, @ddocode, @sectionid, @headid, @scaleid, @bankid, @bankaccno, @paymode, @incdueon, @lastincdate, @incstatus, @gpfno, @gpfcontstatus, @plino, @nomineename, @basicpay, @npaall, @dearnesspay, @da,@Ehra, @cca, @perpay, @tpay, @sppay, @gpf, @Dhra, @gisi, @giss, @incometax,@salded, @remarks,  @modifieruserid, @dataentrydate, @hostipaddress)", cl.upcon);
                SqlCommand cmd = new SqlCommand("insert into mpr(compid,ddoid,date,dutyid,cases) values(@compid,@ddoid,@date,@dutyid,@cases)", cl.upcon);
                cmd.Parameters.AddWithValue("@compid", Request.QueryString["idno"]);
                cmd.Parameters.AddWithValue("@ddoid", ddoid.Text);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(txtdate.Text));
                cmd.Parameters.AddWithValue("@dutyid", ddlduty.SelectedValue);
                cmd.Parameters.AddWithValue("@cases", txtcase.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    Label1.Visible = true;
                    Label1.Text = "Added Successfully";
                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.Text = ("Error :" + ex.Message);
                }
                finally
                {
                    if (ConnectionState.Open == cl.upcon.State)
                    {
                        txtdate.Text = "";
                        txtcase.Text = "";
                        ddlduty.SelectedIndex = 0;
                        cl.upcon.Close();
                    }
                }
            }

        }


        protected void Save_Click1(object sender, EventArgs e)
        {
            //Basicsave();
            if ((string)Session["ddopid"] != null)
            {
                int idnum = Convert.ToInt32(Request.QueryString["idno"]);
                //string strdate = Convert.ToString(txtdate.Text);

                //if (ddlduty.SelectedIndex != 3 || ddlduty.SelectedIndex != 4 || ddlduty.SelectedIndex != 5 || ddlduty.SelectedIndex != 6 || ddlduty.SelectedIndex != 7 || ddlduty.SelectedIndex != 8 || ddlduty.SelectedIndex != 9 || ddlduty.SelectedIndex != 10 || ddlduty.SelectedIndex != 11 || ddlduty.SelectedIndex != 12 || ddlduty.SelectedIndex != 13 || ddlduty.SelectedIndex != 14 || ddlduty.SelectedIndex != 15)
                //{
                txtcase.Visible = true;
                Label5.Visible = true;
                cl.ds = cl.DataFill("Select compid,dutyid,ddoid,convert(char,date,101) as date from mpr where compid='" + idnum + "' and ddoid='" + ddoid.Text + "' and date='" + txtdate.Text + "'and dutyid='" + ddlduty.SelectedValue + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Label1.Visible = true;
                    Label1.Text = ("This Record Already Exist. ");

                }
                else
                {
                    Basicsave();
                }
                //}

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = ("Error:Session Expire please login Again ");
            }

            c.gv(GridView1, "SELECT     TOP (31) mpr.idno, CONVERT(varchar(12), mpr.date, 106) AS [Date], mpr.cases as[Cases], dutytype.dutyname as[DutyName] FROM  mpr INNER JOIN dutytype ON mpr.dutyid = dutytype.dutyid WHERE     (mpr.compid = " + Request.QueryString["idno"] + ") ORDER BY mpr.date DESC ");


            if (GridView1.Rows.Count > 0)
            {
                GridView1.HeaderRow.Cells[2].Visible = false;


                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    gvr.Cells[2].Visible = false;


                }

            }


        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //protected void ddlduty_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int idnum = Convert.ToInt32(Request.QueryString["idno"]);
        //    if (ddlduty.SelectedIndex == 3 || ddlduty.SelectedIndex == 4 || ddlduty.SelectedIndex == 5 || ddlduty.SelectedIndex == 6 || ddlduty.SelectedIndex == 7 || ddlduty.SelectedIndex == 8 || ddlduty.SelectedIndex == 9 || ddlduty.SelectedIndex == 10 || ddlduty.SelectedIndex == 11 || ddlduty.SelectedIndex == 12 || ddlduty.SelectedIndex == 13 || ddlduty.SelectedIndex == 14 || ddlduty.SelectedIndex == 15)
        //    {
        //        cl.ds = cl.DataFill("Select compid,dutyid,ddoid,convert(char,date,101) as date from mpr where compid='" + idnum + "' and ddoid='" + ddoid.Text + "' and date='" + txtdate.Text + "'and dutyid='" + ddlduty.SelectedValue + "'");
        //        txtcase.Visible = false;
        //        Label5.Visible = false;

        //    }
        //}
        protected void deleting(object sender, GridViewDeleteEventArgs e)
        {
            c.con.Open();
            c.cmd.CommandText = "delete from mpr where mpr.idno=" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString()) + "";
            c.cmd.ExecuteNonQuery();
            c.gv(GridView1, "SELECT     TOP (31) mpr.idno,CONVERT(varchar(12), mpr.date, 106) as [Date] , mpr.cases as[Cases] , dutytype.dutyname as[DutyName]  FROM  mpr INNER JOIN dutytype ON mpr.dutyid = dutytype.dutyid WHERE     (mpr.compid = " + Request.QueryString["idno"] + ") ORDER BY mpr.date DESC ");

            Label1.Text = "Deleted Successfully...";
            if (GridView1.Rows.Count > 0)
            {
                GridView1.HeaderRow.Cells[2].Visible = false;


                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    gvr.Cells[2].Visible = false;


                }

            }

            c.con.Close();

        }
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (this.Label2.Text != "")
            {
                Response.Redirect("~/payrole/mprselect.aspx");
            }
            else if (this.Label4.Text != "")
            {
                Response.Redirect("~/payrole/payrolledit.aspx");
            }
        }
    }
}