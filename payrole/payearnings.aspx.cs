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
    public partial class payearnings : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                basicdata();
                datafill();
            }
        }
        public void basicdata()
        {
            cl.ds = cl.DataFill("SELECT     name, post, hname, districtname,ddoname,ddoid FROM         salaryselect  where idno='" + Request.QueryString["idno"] + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    Lname.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Lname.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    LPost.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    LPost.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    LPalce.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    LPalce.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    LDist.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    LDist.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    T11.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    T11.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][5].ToString().Equals(System.DBNull.Value)))
                {
                    Label2.Text = cl.ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    Label2.Text = "";
                }
            }
            else
            {

            }
        }
        public void datafill()
        {
            //****************office
            //cl.ds = cl.DataFill("SELECT     ddoname, ddoidd FROM  Districtddo where  ddodistrictid='"+ 27 +"' ORDER BY ddoname");
            //Doff.DataSource = cl.ds;
            //Doff.DataTextField = "ddoname";
            //Doff.DataValueField = "ddoidd";
            //Doff.DataBind();
            //Doff.Items.Insert(0, new ListItem("--select--"));
            //****************Unit
            cl.ds = cl.DataFill("SELECT     sectionname, sectionid FROM Pay_Section ORDER BY sectionname");
            DUnit.DataSource = cl.ds;
            DUnit.DataTextField = "sectionname";
            DUnit.DataValueField = "sectionid";
            DUnit.DataBind();
            DUnit.Items.Insert(0, new ListItem("--select--"));
            //****************employeetype
            cl.ds = cl.DataFill("SELECT     emptname, empttypeid  FROM Pay_EmploymentType ORDER BY emptname");
            DEmpt.DataSource = cl.ds;
            DEmpt.DataTextField = "emptname";
            DEmpt.DataValueField = "empttypeid";
            DEmpt.DataBind();
            DEmpt.Items.Insert(0, new ListItem("--select--"));
            //****************scale
            cl.ds = cl.DataFill("SELECT     CONVERT(varchar, llimit) + '-' + CONVERT(varchar, ulimit) AS scale, scaleid FROM Pay_Scale ORDER BY CONVERT(varchar, llimit) + '-' + CONVERT(varchar, ulimit) DESC");
            DPays.DataSource = cl.ds;
            DPays.DataTextField = "scale";
            DPays.DataValueField = "scaleid";
            DPays.DataBind();
            DPays.Items.Insert(0, new ListItem("--select--"));
            //****************payhead
            cl.ds = cl.DataFill("SELECT     headname, headid FROM  Pay_Head ORDER BY headname");
            Dpayh.DataSource = cl.ds;
            Dpayh.DataTextField = "headname";
            Dpayh.DataValueField = "headid";
            Dpayh.DataBind();
            Dpayh.Items.Insert(0, new ListItem("--select--"));
            //****************DA
            cl.ds = cl.DataFill("SELECT     daid, dacode FROM Pay_DA");
            DDAcode.DataSource = cl.ds;
            DDAcode.DataTextField = "daid";
            DDAcode.DataValueField = "dacode";
            DDAcode.DataBind();
            DDAcode.Items.Insert(0, new ListItem("--select--"));
            ////****************//DNPA
            cl.ds = cl.DataFill("SELECT     pnpaval, pnpaid FROM Pay_npa ORDER BY pnpaval");
            DNPA.DataSource = cl.ds;
            DNPA.DataTextField = "pnpaval";
            DNPA.DataValueField = "pnpaid";
            DNPA.DataBind();
            DNPA.Items.Insert(0, new ListItem("--select--"));
            ////****************suspend value
            cl.ds = cl.DataFill("SELECT susvalue, suspid FROM Pay_Suspend ORDER BY susvalue");
            DSuspend.DataSource = cl.ds;
            DSuspend.DataTextField = "susvalue";
            DSuspend.DataValueField = "suspid";
            DSuspend.DataBind();
            DSuspend.Items.Insert(0, new ListItem("--select--"));
            //****************bankname
            cl.ds = cl.DataFill("SELECT     bankname, bankid FROM         Pay_Bank ORDER BY bankname");
            DBank.DataSource = cl.ds;
            DBank.DataTextField = "bankname";
            DBank.DataValueField = "bankid";
            DBank.DataBind();
            DBank.Items.Insert(0, new ListItem("--select--"));
        }

        public void maxpicd()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(payid),0)+ 1 FROM salDeduction");
            MD.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }

        public void maxpice()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(payid),0)+ 1 FROM salDeduction");
            ME.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }

        public void Basicsave()
        {
            try
            {
                //maxpicd();

                //0	bankid	int	4	1//0	bankaccno	nvarchar	200	1//0	paymode	nvarchar	50	1//0	incdueon	datetime	8	1//0	lastincdate	datetime	8	1//0	incstatus	nvarchar	50	1//0	gpfno	nvarchar	100	1//0	gpfcontstatus	nvarchar	50	1//0	plino	nvarchar	100	1//0	nomineename	nvarchar	200	1//0	attendance	int	4	1//0	basicpay	int	4	1//0	npaall	int	4	1//0	dearnesspay	int	4	1//0	pensionpay	int	4	1//0	da	int	4	1//0	cca	int	4	1//0	perpay	int	4	1//0	tpay	int	4	1//0	sppay	int	4	1//0	gpf	int	4	1//0	hra	int	4	1//0	gisi	int	4	1//0	giss	int	4	1//0	incometax	int	4	1//0	yearofentry	int	4	1//0	monthofentry	int	4	1//0	hill	int	4	1//0	salarrear	int	4	1//0	otharrear	int	4	1//0	hrr	int	4	1//0	gvr	int	4	1//0	gpfadv	int	4	1//0	gpfinst	int	4	1//0	gpftotded	int	4	1//0	gpfinspaid	int	4	1//0	gpfinstot	int	4	1//0	pli	int	4	1//0	remarks	nvarchar	200	1//0	modifieruserid	int	4	1//0	dataentrydate	datetime	8	1//0	hostipaddress	nvarchar	200	1//0	salded	int	4	1
                cl.upcon.Open();//SELECT     payid, idno, empltypeid, ddocode, sectionid, headid, scaleid, bankid, bankaccno, paymode, incdueon, lastincdate, incstatus, gpfno, gpfcontstatus, plino, nomineename, attendance, basicpay, npaall, dearnesspay, pensionpay, da, cca, perpay, tpay, sppay, gpf, hra, gisi, giss, incometax, remarks,  modifieruserid, dataentrydate, hostipaddress, salded FROM         Pay_sal_mast
                SqlCommand cmd = new SqlCommand("insert into salDeduction(payid, idno, empltypeid, ddocode, sectionid, headid, scaleid, bankid, bankaccno, paymode, incdueon, lastincdate, incstatus, gpfno, gpfcontstatus, plino, nomineename, attendance, basicpay, npaall, dearnesspay, pensionpay, da, cca, perpay, tpay, sppay, gpf, hra, gisi, giss, incometax, remarks,  modifieruserid, dataentrydate, hostipaddress, salded)values (@payid, @idno, @empltypeid, @ddocode, @sectionid, @headid, @scaleid, @bankid, @bankaccno, @paymode, @incdueon, @lastincdate, @incstatus, @gpfno, @gpfcontstatus, @plino, @nomineename, @attendance, @basicpay, @npaall, @dearnesspay, @pensionpay, @da, @cca, @perpay, @tpay, @sppay, @gpf, @hra, @gisi, @giss, @incometax, @remarks,  @modifieruserid, @dataentrydate, @hostipaddress, @salded)", cl.upcon);
                cmd.Parameters.Add("@payid", SqlDbType.Int, 4).Value = Convert.ToInt32(MD.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];
                cmd.Parameters.Add("@empltypeid", SqlDbType.Int, 4).Value = DEmpt.SelectedItem.Value;
                cmd.Parameters.Add("@ddocode", SqlDbType.Int, 4).Value = Convert.ToInt32(Label2.Text);
                cmd.Parameters.Add("@sectionid", SqlDbType.Int, 4).Value = DUnit.SelectedItem.Value;
                cmd.Parameters.Add("@headid", SqlDbType.Int, 4).Value = Dpayh.SelectedItem.Value;
                cmd.Parameters.Add("@scaleid", SqlDbType.Int, 4).Value = DPays.SelectedItem.Value;
                cmd.Parameters.Add("@bankid", SqlDbType.Int, 4).Value = DBank.SelectedItem.Value;
                cmd.Parameters.Add("@bankaccno", SqlDbType.NVarChar, 200).Value = Convert.ToInt32(T6.Text);
                cmd.Parameters.Add("@paymode", SqlDbType.Int, 4).Value = DPaymode.SelectedItem.Value;
                cmd.Parameters.Add("@incdueon", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(T4.Text);
                cmd.Parameters.Add("@lastincdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(T3.Text);
                cmd.Parameters.Add("@incstatus", SqlDbType.Int, 4).Value = DIncs.SelectedItem.Value;
                cmd.Parameters.Add("@gpfno", SqlDbType.NVarChar, 200).Value = T1.Text;
                cmd.Parameters.Add("@gpfcontstatus", SqlDbType.Int, 4).Value = DGpfc.SelectedItem.Value;
                cmd.Parameters.Add("@plino", SqlDbType.NVarChar, 100).Value = T5.Text;
                cmd.Parameters.Add("@nomineename", SqlDbType.NVarChar, 200).Value = T2.Text;
                cmd.Parameters.Add("@attendance", SqlDbType.Int, 4).Value = Convert.ToInt32(T7.Text);
                //Earning
                cmd.Parameters.Add("@basicpay", SqlDbType.Float, 8).Value = Convert.ToInt32(T9.Text);
                cmd.Parameters.Add("@npaall", SqlDbType.Float, 8).Value = DNPA.SelectedItem.Value;
                cmd.Parameters.Add("@dearnesspay", SqlDbType.Float, 8).Value = Convert.ToDouble(T10.Text);
                cmd.Parameters.Add("@pensionpay", SqlDbType.Float, 8).Value = Convert.ToInt32(T21.Text);
                cmd.Parameters.Add("@da", SqlDbType.Int, 4).Value = Convert.ToInt32(T22.Text);
                cmd.Parameters.Add("@cca", SqlDbType.Float, 8).Value = Convert.ToDouble(T13.Text);
                cmd.Parameters.Add("@perpay", SqlDbType.Float, 8).Value = Convert.ToInt32(T21.Text);
                cmd.Parameters.Add("@tpay", SqlDbType.Float, 8).Value = Convert.ToInt32(T22.Text);
                cmd.Parameters.Add("@sppay", SqlDbType.Float, 8).Value = Convert.ToDouble(T23.Text);
                //deduction
                cmd.Parameters.Add("@gpf", SqlDbType.Float, 8).Value = Convert.ToInt32(T23.Text);
                cmd.Parameters.Add("@hra", SqlDbType.Float, 8).Value = Convert.ToInt32(T12.Text);
                cmd.Parameters.Add("@gisi", SqlDbType.Float, 8).Value = Convert.ToInt32(T16.Text);
                cmd.Parameters.Add("@giss", SqlDbType.Float, 8).Value = Convert.ToDouble(T17.Text);
                cmd.Parameters.Add("@incometax", SqlDbType.Float, 8).Value = Convert.ToInt32(T18.Text);
                cmd.Parameters.Add("@remarks", SqlDbType.Int, 4).Value = Convert.ToInt32(T19.Text);
                //system
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Float, 8).Value = Convert.ToDouble(T20.Text);
                cmd.Parameters.Add("@dataentrydate", SqlDbType.Int, 4).Value = Convert.ToInt32(T21.Text);
                cmd.Parameters.Add("@hostipaddress", SqlDbType.Int, 4).Value = Convert.ToInt32(T22.Text);
                cmd.Parameters.Add("@salded", SqlDbType.Float, 8).Value = Convert.ToDouble(T23.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "Added Successfully";

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
        public void esave()
        {
            //2	payid	int	4	0
            //0	userid	int	4	1
            //0	gpfno	int	4	1
            //0	ddocode	int	4	1
            //0	grtcode	int	4	1
            //0	basic	float	8	1
            //0	hra	float	8	1
            //0	cca	float	8	1
            //0	dapay	float	8	1
            //0	da	float	8	1
            //0	npa	float	8	1
            //0	tpa	float	8	1
            //1	other	float	8	1

            try
            {
                //maxpice();
                cl.upcon.Open();//payid,userid,gpfno,ddocode,grtcode,basic,hra,cca,dapay,da,npa,tpa,other
                SqlCommand cmd = new SqlCommand("insert into salEarnings(payid,userid,gpfno,ddocode,grtcode,basic,hra,cca,dapay,da,npa,tpa,other)values(@payid,@userid,@gpfno,@ddocode,@grtcode,@basic,@hra,@cca,@dapay,@da,@npa,@tpa,@other)", cl.upcon);
                cmd.Parameters.Add("@payid", SqlDbType.Int, 4).Value = Convert.ToInt32(ME.Text);
                cmd.Parameters.Add("@userid", SqlDbType.Int, 4).Value = Convert.ToInt32(T1.Text);
                cmd.Parameters.Add("@gpfno", SqlDbType.Int, 4).Value = Convert.ToInt32(T2.Text);
                //cmd.Parameters.Add("@ddocode", SqlDbType.Int, 4).Value = D1.SelectedItem.Value;
                //cmd.Parameters.Add("@grtcode", SqlDbType.Int, 4).Value = D2.SelectedItem.Value;
                cmd.Parameters.Add("@basic", SqlDbType.Float, 8).Value = Convert.ToDouble(T3.Text);
                cmd.Parameters.Add("@hra", SqlDbType.Float, 8).Value = Convert.ToDouble(T4.Text);
                cmd.Parameters.Add("@cca", SqlDbType.Float, 8).Value = Convert.ToDouble(T5.Text);
                cmd.Parameters.Add("@dapay", SqlDbType.Float, 8).Value = Convert.ToDouble(T6.Text);
                cmd.Parameters.Add("@da", SqlDbType.Float, 8).Value = Convert.ToDouble(T7.Text);
                cmd.Parameters.Add("@npa", SqlDbType.Float, 8).Value = Convert.ToDouble(T8.Text);
                cmd.Parameters.Add("@tpa", SqlDbType.Float, 8).Value = Convert.ToDouble(T9.Text);
                cmd.Parameters.Add("@other", SqlDbType.Float, 8).Value = Convert.ToDouble(T10.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "Added Successfully";

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
        public void dsave()
        {
            try
            {
                //maxpicd();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into salDeduction(payid,gpf,cgegis,gpfrecovery,compadv,compinst,compci,caradv,cinst,cci,scooteradv,sint,sci,hba,hinst,hci)values (@payid,@gpf,@cgegis,@gpfrecovery,@compadv,@compinst,@compci,@caradv,@cinst,@cci,@scooteradv,@sint,@sci,@hba,@hinst,@hci)", cl.upcon);
                cmd.Parameters.Add("@payid", SqlDbType.Int, 4).Value = Convert.ToInt32(MD.Text);
                cmd.Parameters.Add("@gpf", SqlDbType.Float, 8).Value = Convert.ToDouble(T11.Text);
                cmd.Parameters.Add("@cgegis", SqlDbType.Float, 8).Value = Convert.ToDouble(T12.Text);
                cmd.Parameters.Add("@gpfrecovery", SqlDbType.Float, 8).Value = Convert.ToDouble(T13.Text);
                cmd.Parameters.Add("@compadv", SqlDbType.Float, 8).Value = Convert.ToDouble(T14.Text);
                cmd.Parameters.Add("@compinst", SqlDbType.Int, 4).Value = Convert.ToInt32(T5.Text);
                cmd.Parameters.Add("@compci", SqlDbType.Int, 4).Value = Convert.ToInt32(T16.Text);
                cmd.Parameters.Add("@caradv", SqlDbType.Float, 8).Value = Convert.ToDouble(T17.Text);
                cmd.Parameters.Add("@cinst", SqlDbType.Int, 4).Value = Convert.ToInt32(T18.Text);
                cmd.Parameters.Add("@cci", SqlDbType.Int, 4).Value = Convert.ToInt32(T19.Text);
                cmd.Parameters.Add("@scooteradv", SqlDbType.Float, 8).Value = Convert.ToDouble(T20.Text);
                cmd.Parameters.Add("@sint", SqlDbType.Int, 4).Value = Convert.ToInt32(T21.Text);
                //cmd.Parameters.Add("@sci", SqlDbType.Int, 4).Value = Convert.ToInt32(T22.Text);
                //cmd.Parameters.Add("@hba", SqlDbType.Float, 8).Value = Convert.ToDouble(T23.Text);
                //cmd.Parameters.Add("@hinst", SqlDbType.Int, 4).Value = Convert.ToInt32(T24.Text);
                //cmd.Parameters.Add("@hci", SqlDbType.Int, 4).Value = Convert.ToInt32(T25.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "Added Successfully";

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
        protected void Button2_Click(object sender, EventArgs e)
        {
            maxpicd();
            maxpice();
            if (MD.Text == MD.Text)
            {
                esave();
                dsave();
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = " Technical Error ";
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/payrole/payroleselect.aspx");
        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            //1	payid	int	4	0 //0	idno	int	4	1 //0	empltypeid	int	4	1 //0	ddocode	int	4	1 //0	sectionid	int	4	1
            //0	headid	int	4	1 //0	scaleid	int	4	1 //0	bankid	int	4	1 //0	bankaccno	nvarchar	200	1 //0	paymode	nvarchar	50	1
            //0	incdueon	datetime	8	1 //0	lastincdate	datetime	8	1 //0	incstatus	nvarchar	50	1 //0	gpfno	nvarchar	100	1
            //0	gpfcontstatus	nvarchar	50	1 //0	plino	nvarchar	100	1 //0	nomineename	nvarchar	200	1 //0	attendance	int	4	1
            //Basic E
            //0	basicpay	int	4	1 //0	npaall	int	4	1 //0	dearnesspay	int	4	1 //0	pensionpay	int	4	1 //0	da	int	4	1
            //0	cca	int	4	1 //0	perpay	int	4	1 //0	tpay	int	4	1 //0	sppay	int	4	1 
            //Basic D
            //0	gpf	int	4	1//0	hra	int	4	1 //0	gisi	int	4	1 //0	giss	int	4	1 //0	incometax	int	4	1 //0	yearofentry	int	4	1 //0	monthofentry	int	4	1
            //0	hill	int	4	1 //0	salarrear	int	4	1 //0	otharrear	int	4	1 //0	hrr	int	4	1 //0	gvr	int	4	1//0	gpfadv	int	4	1
            //0	gpfinst	int	4	1 //0	gpftotded	int	4	1 //0	gpfinspaid	int	4	1 //0	gpfinstot	int	4	1 //0	pli	int	4	1
            //0	remarks	nvarchar	200	1 //0	modifieruserid	int	4	1 //0	dataentrydate	datetime	8	1 //0	hostipaddress	nvarchar	200	1
            //0	salded	int	4	1

        }
    }
}