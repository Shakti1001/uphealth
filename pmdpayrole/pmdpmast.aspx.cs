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

namespace NewWebApp.pmdpayrole
{
    public partial class pmdpmast : System.Web.UI.Page
    {
       ClDatabase cl = new ClDatabase();
    //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    string payidstr,npa;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cl.AddCalender(ref Imagecal, ref DOIT);
            //cl.AddCalender(ref Image1, ref IDUT);
            //this.DOIT.Attributes.Add("ReadOnly", "True");
            //this.IDUT.Attributes.Add("ReadOnly", "True");
            if ((string)Session["iduser"] == null)
            {
                Response.Redirect("~/login.aspx"); ;//jump to first page for login
            }
            Uidt.Text = (string)Session["iduser"];
            datafill();
            this.Label2.Text = Request.QueryString["idno"];
            //this.Label4.Text = Request.QueryString["payid"];
           // AttText.Text = "30";
            /*if (this.Label2.Text != "")
            {
                basicdata();
                Save.Visible = true;
                Update.Visible = false;
            }
            else if (this.Label4.Text != "")
            {
                setforedit();
                Update.Visible = true;
                Save.Visible = false;
            }*/
            //setforedit();//copy from here
            cl.ds = cl.DataFill("select payid from PMD_Pay_sal_mast where idno='" + Request.QueryString["idno"] + "'");
            
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                payidstr = cl.ds.Tables[0].Rows[0][0].ToString();
                Label4.Text = payidstr;
                basicdata();
                setforedit();
                DT1.Enabled = false;
                DEmpt.Enabled = false;
                GPFT.Enabled = false;
                DPays.Enabled = false;
                Dpayh.Enabled = false;
                DBank.Enabled = false;
                BANKAT.Enabled = false;
                DIncs.Enabled = false;
                RMARKT.Enabled = false;
                BPAYT.Enabled = false;
                GradePay.Enabled = false;
                PAN.Enabled = false;
                CCAT.Enabled = false;
                PENST.Enabled = false;
                EHRAT.Enabled = false;
                SPAYT.Enabled = false;
                pensionText.Enabled = false;
                GVTPT.Enabled = false;
                AttText.Enabled = false;
                GPFCT.Enabled = false;
                GIFT.Enabled = false;
                GSFT.Enabled = false;
                INCOMET.Enabled = false;
                GVRT.Enabled = false;
                elecbill.Enabled = false;
                SDT.Enabled = false;
                RD.Enabled = false;
                HRR.Enabled = false;
                Update.Visible = true;
                Update.Enabled = false;
                Save.Visible = false;
                GPFCF.Enabled = false;
                lic.Enabled = false;
                socded.Enabled = false;
                pftype.Enabled = false;
                rdded.Enabled = false;
                pranr.Enabled = false;
                monthr.Enabled = false;
            }
            else
            {
               
                basicdata();
                Save.Visible = true;
                Button1.Visible = false;
                Update.Visible = false;
            }
            //till here copy
            
        }
    }
    public void basicdata()
    {
        
        int i;
        for (i = 0; i <= 31; i++)
        {
            DIncs.Items.Add(i.ToString());
        }
       
       
   
      
            try
            {//ddopid
                cl.ds = cl.DataFill("SELECT     name, post, hname, districtname,ddoname,ddoid FROM pmd_salaryselect  where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    if (!(cl.ds.Tables[0].Rows[0]["name"].ToString().Equals(System.DBNull.Value)))
                    {
                        Lname.Text = cl.ds.Tables[0].Rows[0]["name"].ToString();
                    }
                    else
                    {
                        Lname.Text = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[0]["post"].ToString().Equals(System.DBNull.Value)))
                    {
                        LPost.Text = cl.ds.Tables[0].Rows[0]["post"].ToString();
                    }
                    else
                    {
                        LPost.Text = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[0]["hname"].ToString().Equals(System.DBNull.Value)))
                    {
                        LPalce.Text = cl.ds.Tables[0].Rows[0]["hname"].ToString();
                    }
                    else
                    {
                        LPalce.Text = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[0]["districtname"].ToString().Equals(System.DBNull.Value)))
                    {
                        LDist.Text = cl.ds.Tables[0].Rows[0]["districtname"].ToString();
                    }
                    else
                    {
                        LDist.Text = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[0]["ddoname"].ToString().Equals(System.DBNull.Value)))
                    {
                        DT1.Text = cl.ds.Tables[0].Rows[0]["ddoname"].ToString();
                    }
                    else
                    {
                        DT1.Text = "";
                    }
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
       
        //****************employeetype
        cl.ds = cl.DataFill("SELECT     emptname, empttypeid  FROM Pay_EmploymentType ORDER BY emptname");
        DEmpt.DataSource = cl.ds;
        DEmpt.DataTextField = "emptname";
        DEmpt.DataValueField = "empttypeid";
        DEmpt.DataBind();
        DEmpt.Items.Insert(0, new ListItem("--select--"));
        //****************scale
        cl.ds = cl.DataFill("SELECT     CONVERT(varchar, llimit) + '-' + CONVERT(varchar, ulimit) +'-GP'+ CONVERT(varchar, gp) AS scale, scaleid FROM PMD_Pay_Scale ORDER BY  llimit ");
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
       
        ////****************//DNPA
        //cl.ds = cl.DataFill("SELECT     pnpaval, pnpaid FROM Pay_npa ORDER BY pnpaval");
        //DNPA.DataSource = cl.ds;
        //DNPA.DataTextField = "pnpaval";
        //DNPA.DataValueField = "pnpaid";
        //DNPA.DataBind();
        //DNPA.Items.Insert(0, new ListItem("--select--"));
        ////****************suspend value
        cl.ds = cl.DataFill("SELECT pftype, sno FROM pftype ORDER BY pftype");
        pftype.DataSource = cl.ds;
        pftype.DataTextField = "pftype";
        pftype.DataValueField = "sno";
        pftype.DataBind();
        pftype.Items.Insert(0, new ListItem("--select--"));
        //****************bankname
        cl.ds = cl.DataFill("SELECT     bankname, bankid FROM         Pay_Bank ORDER BY bankname");
        DBank.DataSource = cl.ds;
        DBank.DataTextField = "bankname";
        DBank.DataValueField = "bankid";
        DBank.DataBind();
        DBank.Items.Insert(0, new ListItem("--select--"));
    }
    public void setforedit()
    {
        try
        {
        //cl.ds = cl.DataFill("SELECT PMD_Pay_sal_mast.idno,pmd_salaryselect.name, pmd_salaryselect.post, pmd_salaryselect.hname, pmd_salaryselect.districtname, pmd_salaryselect.ddoname,  PMD_Pay_sal_mast.empltypeid, PMD_Pay_sal_mast.ddocode, PMD_Pay_sal_mast.sectionid, PMD_Pay_sal_mast.headid, PMD_Pay_sal_mast.scaleid, PMD_Pay_sal_mast.bankid,  PMD_Pay_sal_mast.bankaccno, PMD_Pay_sal_mast.paymode, PMD_Pay_sal_mast.incdueon, PMD_Pay_sal_mast.lastincdate, PMD_Pay_sal_mast.incstatus, PMD_Pay_sal_mast.gpfno, PMD_Pay_sal_mast.gpfcontstatus, PMD_Pay_sal_mast.plino, PMD_Pay_sal_mast.nomineename, PMD_Pay_sal_mast.basicpay, PMD_Pay_sal_mast.npaall, PMD_Pay_sal_mast.dearnesspay, PMD_Pay_sal_mast.da, PMD_Pay_sal_mast.Ehra, PMD_Pay_sal_mast.cca, PMD_Pay_sal_mast.perpay, PMD_Pay_sal_mast.tpay,  PMD_Pay_sal_mast.sppay, PMD_Pay_sal_mast.gpf, PMD_Pay_sal_mast.Dhra, PMD_Pay_sal_mast.gisi, PMD_Pay_sal_mast.giss, PMD_Pay_sal_mast.incometax, PMD_Pay_sal_mast.salded, PMD_Pay_sal_mast.remarks FROM         PMD_Pay_sal_mast INNER JOIN  pmd_salaryselect ON PMD_Pay_sal_mast.idno = pmd_salaryselect.idno WHERE     (PMD_Pay_sal_mast.payid ='" + Request.QueryString["payid"] + "'  ");
            cl.ds = cl.DataFill("SELECT     PMD_Pay_sal_mast.idno, pmd_salaryselect.name, pmd_salaryselect.post, pmd_salaryselect.hname, pmd_salaryselect.districtname, pmd_salaryselect.ddoname, PMD_Pay_sal_mast.empltypeid, PMD_Pay_sal_mast.scaleid, PMD_Pay_sal_mast.headid, PMD_Pay_sal_mast.gpfno,  PMD_Pay_sal_mast.incstatus, Convert(char,PMD_Pay_sal_mast.lastincdate,101)as lastincdate, Convert(char,PMD_Pay_sal_mast.incdueon,101) as incdueon, PMD_Pay_sal_mast.bankid, PMD_Pay_sal_mast.bankaccno, PMD_Pay_sal_mast.remarks, isnull(PMD_Pay_sal_mast.basicpay,0) as basicpay, PMD_Pay_sal_mast.Ehra, PMD_Pay_sal_mast.cca, PMD_Pay_sal_mast.perpay, PMD_Pay_sal_mast.tpay,   PMD_Pay_sal_mast.sppay, PMD_Pay_sal_mast.gpf, PMD_Pay_sal_mast.gisi, PMD_Pay_sal_mast.giss, PMD_Pay_sal_mast.incometax, PMD_Pay_sal_mast.salded, PMD_Pay_sal_mast.hrr, PMD_Pay_sal_mast.pensionpay, PMD_Pay_sal_mast.ddocode,isnull(PMD_Pay_sal_mast.Gradepay,0) as Gradepay ,PMD_Pay_sal_mast.gvr,isnull(PMD_Pay_sal_mast.elecbill,0)as elecbill,PMD_Pay_sal_mast.stopsal ,isnull(PMD_Pay_sal_mast.rd,0)as rd ,PMD_Pay_sal_mast.hrr,isnull(PMD_Pay_sal_mast.panno,'')as panno, PMD_Pay_sal_mast.gpfiv,PMD_Pay_sal_mast.lic,PMD_Pay_sal_mast.socded,PMD_Pay_sal_mast.rdded,PMD_Pay_sal_mast.pftype,PMD_Pay_sal_mast.pranr,PMD_Pay_sal_mast.monthr,PMD_Pay_sal_mast.ruralall FROM PMD_Pay_sal_mast INNER JOIN pmd_salaryselect ON PMD_Pay_sal_mast.idno = pmd_salaryselect.idno WHERE PMD_Pay_sal_mast.payid =" + payidstr + "");//copy
        if (cl.ds.Tables[0].Rows.Count > 0)
        {
            
            if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
            {
                Label2.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Label2.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
            {
                Lname.Text = cl.ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                Lname.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
            {
                LPost.Text = cl.ds.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                LPost.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
            {
                LPalce.Text = cl.ds.Tables[0].Rows[0][3].ToString();
            }
            else
            {
                LPalce.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
            {
                LDist.Text = cl.ds.Tables[0].Rows[0][4].ToString();
            }
            else
            {
                LDist.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][5].ToString().Equals(System.DBNull.Value)))
            {
                DT1.Text = cl.ds.Tables[0].Rows[0][5].ToString();
            }
            else
            {
                DT1.Text = "";
            }
           
            if (!(cl.ds.Tables[0].Rows[0][6].ToString().Equals(System.DBNull.Value)))
            {
                DEmpt.SelectedIndex = DEmpt.Items.IndexOf(DEmpt.Items.FindByValue(cl.ds.Tables[0].Rows[0][6].ToString()));
            }
            else
            {
                DEmpt.SelectedIndex = 0;
            }
            if (!(cl.ds.Tables[0].Rows[0][7].ToString().Equals(System.DBNull.Value)))
            {
                DPays.SelectedIndex = DPays.Items.IndexOf(DPays.Items.FindByValue(cl.ds.Tables[0].Rows[0][7].ToString()));
            }
            else
            {
                DPays.SelectedIndex = 0;
            }

            
            if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
            {
                Dpayh.SelectedIndex = Dpayh.Items.IndexOf(Dpayh.Items.FindByValue(cl.ds.Tables[0].Rows[0][8].ToString()));
            }
            else
            {
                Dpayh.SelectedIndex = 0;
            }
            if (!(cl.ds.Tables[0].Rows[0][9].ToString().Equals(System.DBNull.Value)))
            {
                GPFT.Text = cl.ds.Tables[0].Rows[0][9].ToString();
            }
            else
            {
                GPFT.Text = "";
            }
           
           
            //**************************************************increments
            if (!(cl.ds.Tables[0].Rows[0][33].ToString().Equals(System.DBNull.Value)))
            {
                DIncs.SelectedIndex = DIncs.Items.IndexOf(DIncs.Items.FindByValue(cl.ds.Tables[0].Rows[0][33].ToString()));
            }
            else
            {
                DIncs.SelectedIndex = 0;
            }
            int stopdays = Convert.ToInt32(DIncs.SelectedIndex);
            int year = System.DateTime.Today.Year;
            int month = System.DateTime.Today.Month;
            int mdays = System.DateTime.DaysInMonth(year, month);

            AttText.Text = (mdays - stopdays).ToString();

            
            /*if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
            {
                DOIT.Text = cl.ds.Tables[0].Rows[0][14].ToString();
            }
            else
            {
                DOIT.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][15].ToString().Equals(System.DBNull.Value)))
            {
                IDUT.Text = cl.ds.Tables[0].Rows[0][15].ToString();
            }
            else
            {
                IDUT.Text = "";
            }*///today comment16 july
            //**************************************************Plino
         
            //**************************************************Bank
          
            if (!(cl.ds.Tables[0].Rows[0][13].ToString().Equals(System.DBNull.Value)))
            {
                DBank.SelectedIndex = DBank.Items.IndexOf(DBank.Items.FindByValue(cl.ds.Tables[0].Rows[0][13].ToString()));
            }
            else
            {
                DBank.SelectedIndex = 0;
            }
            if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
            {
                BANKAT.Text = cl.ds.Tables[0].Rows[0][14].ToString();
            }
            else
            {
                BANKAT.Text = "";
            }
            //**************************************************Remark
            if (!(cl.ds.Tables[0].Rows[0][15].ToString().Equals(System.DBNull.Value)))
            {
                RMARKT.Text = cl.ds.Tables[0].Rows[0][15].ToString();
            }
            else
            {
                RMARKT.Text = "";
            }
            //**********************************************************
            //******************EARNINGS********************************
            //**********************************************************
            if (!(cl.ds.Tables[0].Rows[0][16].ToString().Equals(System.DBNull.Value)))
            {
                BPAYT.Text = cl.ds.Tables[0].Rows[0][16].ToString();
            }
            else
            {
                BPAYT.Text = "";
            }
            //Grade pay****************************************
            if (!(cl.ds.Tables[0].Rows[0][30].ToString().Equals(System.DBNull.Value)))
            {
                GradePay.Text = cl.ds.Tables[0].Rows[0][30].ToString();
            }
            else
            {
                GradePay.Text = "";
            }
            //**********************************************************
            /*if (!(cl.ds.Tables[0].Rows[0][17].ToString().Equals(System.DBNull.Value)))
            {
                //DNPA.SelectedIndex = DNPA.Items.IndexOf(DNPA.Items.FindByText(cl.ds.Tables[0].Rows[0][22].ToString()));
            DNPA.Text=cl.ds.Tables[0].Rows[0][17].ToString();
            
            }
            else
            {
                DNPA.Text = "0";
            }*/
           
       
            if (!(cl.ds.Tables[0].Rows[0][17].ToString().Equals(System.DBNull.Value)))
            {
                EHRAT.Text = cl.ds.Tables[0].Rows[0][17].ToString();
            }
            else
            {
                EHRAT.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][18].ToString().Equals(System.DBNull.Value)))
            {
                CCAT.Text = cl.ds.Tables[0].Rows[0][18].ToString();
            }
            else
            {
                CCAT.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][19].ToString().Equals(System.DBNull.Value)))
            {
                PENST.Text = cl.ds.Tables[0].Rows[0][19].ToString();
            }
            else
            {
                PENST.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][20].ToString().Equals(System.DBNull.Value)))
            {
                GVTPT.Text = cl.ds.Tables[0].Rows[0][20].ToString();
            }
            else
            {
                GVTPT.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][21].ToString().Equals(System.DBNull.Value)))
            {
                SPAYT.Text = cl.ds.Tables[0].Rows[0][21].ToString();
            }
            else
            {
                SPAYT.Text = "0";
            }
            //**********************************************************
            //******************NORMAL-DEDUCTION************************
            //**********************************************************
            if (!(cl.ds.Tables[0].Rows[0][22].ToString().Equals(System.DBNull.Value)))
            {
                GPFCT.Text = cl.ds.Tables[0].Rows[0][22].ToString();
            }
            else
            {
                GPFCT.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][23].ToString().Equals(System.DBNull.Value)))
            {
                GIFT.Text = cl.ds.Tables[0].Rows[0][23].ToString();
            }
            else
            {
                GIFT.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][24].ToString().Equals(System.DBNull.Value)))
            {
                GSFT.Text = cl.ds.Tables[0].Rows[0][24].ToString();
            }
            else
            {
                GSFT.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][25].ToString().Equals(System.DBNull.Value)))
            {
                INCOMET.Text = cl.ds.Tables[0].Rows[0][25].ToString();
            }
            else
            {
                INCOMET.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][31].ToString().Equals(System.DBNull.Value)))
            {
                GVRT.Text = cl.ds.Tables[0].Rows[0][31].ToString();
            }
            else
            {
                GVRT.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][34].ToString().Equals(System.DBNull.Value)))
            {
                RD.Text = cl.ds.Tables[0].Rows[0][34].ToString();
            }
            else
            {
                RD.Text = "0";
            }

            if (!(cl.ds.Tables[0].Rows[0][26].ToString().Equals(System.DBNull.Value)))
            {
                SDT.Text = cl.ds.Tables[0].Rows[0][26].ToString();
            }
            else
            {
                SDT.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][28].ToString().Equals(System.DBNull.Value)))//from
            {
                pensionText.Text = cl.ds.Tables[0].Rows[0][28].ToString();
            }
            else
            {
                pensionText.Text = "0";
            }
          
            if (!(cl.ds.Tables[0].Rows[0][32].ToString().Equals(System.DBNull.Value)))
            {
                elecbill.Text = cl.ds.Tables[0].Rows[0][32].ToString();
            }
            else
            {
                elecbill.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][35].ToString().Equals(System.DBNull.Value)))
            {
                HRR.Text = cl.ds.Tables[0].Rows[0][35].ToString();
            }
            else
            {
                HRR.Text = "0";
            }
            if (!(cl.ds.Tables[0].Rows[0][36].ToString().Equals(System.DBNull.Value)))
            {
                PAN.Text = cl.ds.Tables[0].Rows[0][36].ToString();
            }
            else
            {
                PAN.Text = "0";
            }
            //*********************DDOID**************************
            if (!(cl.ds.Tables[0].Rows[0][29].ToString().Equals(System.DBNull.Value)))
            {
                ddoid.Text = cl.ds.Tables[0].Rows[0][29].ToString();
            }
            else
            {
                ddoid.Text = "0";
            }


            if (!(cl.ds.Tables[0].Rows[0][37].ToString().Equals(System.DBNull.Value)))
            {
                GPFCF.Text = cl.ds.Tables[0].Rows[0][37].ToString();
            }
            else
            {
                GPFCF.Text = "0";
            }

            if (!(cl.ds.Tables[0].Rows[0][38].ToString().Equals(System.DBNull.Value)))
            {
                lic.Text = cl.ds.Tables[0].Rows[0][38].ToString();
            }
            else
            {
                lic.Text = "0";
            }

            if (!(cl.ds.Tables[0].Rows[0][39].ToString().Equals(System.DBNull.Value)))
            {
                socded.Text = cl.ds.Tables[0].Rows[0][39].ToString();
            }
            else
            {
                socded.Text = "0";
            }


            if (!(cl.ds.Tables[0].Rows[0][40].ToString().Equals(System.DBNull.Value)))
            {
                rdded.Text = cl.ds.Tables[0].Rows[0][40].ToString();
            }
            else
            {
                rdded.Text = "0";
            }

            if (!(cl.ds.Tables[0].Rows[0][42].ToString().Equals(System.DBNull.Value)))
            {
                pranr.Text = cl.ds.Tables[0].Rows[0][42].ToString();
            }
            else
            {
                pranr.Text = "0";
            }

            if (!(cl.ds.Tables[0].Rows[0][43].ToString().Equals(System.DBNull.Value)))
            {
                monthr.Text = cl.ds.Tables[0].Rows[0][43].ToString();
            }
            else
            {
                monthr.Text = "0";
            }


            if (!(cl.ds.Tables[0].Rows[0][44].ToString().Equals(System.DBNull.Value)))
            {
                ruralall.Text = cl.ds.Tables[0].Rows[0][44].ToString();
            }
            else
            {
                ruralall.Text = "0";
            }




            if (!(cl.ds.Tables[0].Rows[0][41].ToString().Equals(System.DBNull.Value)))
            {
                pftype.Text = cl.ds.Tables[0].Rows[0][41].ToString();
                pftype.SelectedIndex = DBank.Items.IndexOf(DBank.Items.FindByValue(cl.ds.Tables[0].Rows[0][41].ToString()));
            }
            else
            {
                pftype.SelectedIndex = 0;
            }
            
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
    
    public void maxpice()
    {
        cl.ds = cl.DataFill("SELECT isnull(MAX(payid),0)+ 1 FROM salDeduction");
        ME.Text = cl.ds.Tables[0].Rows[0][0].ToString();

    }
    public void maxpicd()
    {
        cl.ds = cl.DataFill("SELECT isnull(MAX(payid),0)+ 1 FROM PMD_Pay_sal_mast");
        MD.Text = cl.ds.Tables[0].Rows[0][0].ToString();
    }

    public void Basicsave()
    {
        try
        {
            maxpicd();
            if (ConnectionState.Closed == cl.upcon.State)
            {
                cl.upcon.Open();//SqlCommand cmd = new SqlCommand("insert into PMD_Pay_sal_mast(payid, idno, empltypeid, ddocode, sectionid, headid, scaleid, bankid, bankaccno, paymode, incdueon, lastincdate, incstatus, gpfno, gpfcontstatus, plino, nomineename, basicpay, npaall, dearnesspay, da,Ehra, cca, perpay, tpay, sppay, gpf, Dhra, gisi, giss, incometax,salded, remarks,  modifieruserid, dataentrydate, hostipaddress)values (@payid, @idno, @empltypeid, @ddocode, @sectionid, @headid, @scaleid, @bankid, @bankaccno, @paymode, @incdueon, @lastincdate, @incstatus, @gpfno, @gpfcontstatus, @plino, @nomineename, @basicpay, @npaall, @dearnesspay, @da,@Ehra, @cca, @perpay, @tpay, @sppay, @gpf, @Dhra, @gisi, @giss, @incometax,@salded, @remarks,  @modifieruserid, @dataentrydate, @hostipaddress)", cl.upcon);
                SqlCommand cmd = new SqlCommand("pmdAddsalarybasic1", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@payid", SqlDbType.Int, 4).Value = Convert.ToInt32(MD.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];
                cmd.Parameters.Add("@pan", SqlDbType.VarChar, 20).Value = PAN.Text.ToString();
                if (DEmpt.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@empltypeid", SqlDbType.Int, 4).Value = DEmpt.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@empltypeid", SqlDbType.Int, 4).Value = 0;
                }
                cmd.Parameters.Add("@ddocode", SqlDbType.Int, 4).Value = Convert.ToInt32(ddoid.Text);
                
                if (Dpayh.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@headid", SqlDbType.Int, 4).Value = Dpayh.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@headid", SqlDbType.Int, 4).Value = 0;
                }
                if (DPays.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@scaleid", SqlDbType.Int, 4).Value = DPays.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@scaleid", SqlDbType.Int, 4).Value = 0;
                }
                if (DBank.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@bankid", SqlDbType.Int, 4).Value = DBank.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@bankid", SqlDbType.Int, 4).Value = 0;
                }
                cmd.Parameters.Add("@bankaccno", SqlDbType.NVarChar, 200).Value = BANKAT.Text.Replace("\'", "\'\'").Trim();
                
                //cmd.Parameters.Add("@incdueon", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(IDUT.Text);
                //cmd.Parameters.Add("@lastincdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DOIT.Text);
                //if (DIncs.SelectedIndex != 0)
                //{
                //    cmd.Parameters.Add("@incstatus", SqlDbType.Int, 4).Value = DIncs.SelectedItem.Value;
                //}
                //else
                //{
                cmd.Parameters.Add("@incdueon", DBNull.Value);
                cmd.Parameters.Add("@lastincdate", DBNull.Value);
                cmd.Parameters.Add("@incstatus", SqlDbType.Int, 4).Value = 0;
                //}

                cmd.Parameters.Add("@gpfno", SqlDbType.NVarChar, 200).Value = GPFT.Text.Replace("\'", "\'\'").Trim();
            
               
                ////////////////////////////////////////////////////////////////////////////////
               /* if (AttText.Text != "" || AttText.Text != "Full")
                {
                    cmd.Parameters.Add("@attendance", SqlDbType.Int, 4).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@attendance", SqlDbType.Int, 4).Value = 0;
                }*/
                ////////////////////////////////////////////////////////////////////////////////
                //Earning
                if (BPAYT.Text != "")
                {
                    cmd.Parameters.Add("@basicpay", SqlDbType.Float, 8).Value = Convert.ToDouble(BPAYT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@basicpay", SqlDbType.Float, 8).Value = 0;
                }
                //Grade pay
                if (GradePay.Text != "")
                {
                    cmd.Parameters.Add("@Gradepay", SqlDbType.Float, 8).Value = Convert.ToDouble(GradePay.Text);
                }
                else
                {
                    cmd.Parameters.Add("@Gradepay", SqlDbType.Float, 8).Value = 0;
                }
                //calculating NPA
                Double y;
                y = (Convert.ToDouble(BPAYT.Text) + Convert.ToDouble(GradePay.Text)) * 25 / 100;
                npa = Convert.ToString(Math.Ceiling(y));
                //cmd.Parameters.Add("@npaall", SqlDbType.Float, 8).Value = Convert.ToDouble(npa);
              
                if (EHRAT.Text != "")
                {
                    cmd.Parameters.Add("@Ehra", SqlDbType.Float, 8).Value = Convert.ToDouble(EHRAT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@Ehra", SqlDbType.Float, 8).Value = 0;
                }
                if (CCAT.Text != "")
                {
                    cmd.Parameters.Add("@cca", SqlDbType.Float, 8).Value = Convert.ToDouble(CCAT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@cca", SqlDbType.Float, 8).Value = 0;
                }
                if (PENST.Text != "")
                {
                    cmd.Parameters.Add("@perpay", SqlDbType.Float, 8).Value = Convert.ToDouble(PENST.Text);
                }
                else
                {
                    cmd.Parameters.Add("@perpay", SqlDbType.Float, 8).Value = 0;
                }
                if (GVTPT.Text != "")
                {
                    cmd.Parameters.Add("@tpay", SqlDbType.Float, 8).Value = Convert.ToInt32(GVTPT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@tpay", SqlDbType.Float, 8).Value = 0;
                }
                
                if (pensionText.Text != "")
                {
                    cmd.Parameters.Add("@pension", SqlDbType.Float, 8).Value = Convert.ToDouble(pensionText.Text);
                }
                else
                {
                    cmd.Parameters.Add("@pension", SqlDbType.Float, 8).Value = 0;
                }
                if (SPAYT.Text != "")
                {
                    cmd.Parameters.Add("@sppay", SqlDbType.Float, 8).Value = Convert.ToDouble(SPAYT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@sppay", SqlDbType.Float, 8).Value = 0;
                }
                //deduction
                if (GPFCT.Text != "")
                {
                    cmd.Parameters.Add("@gpf", SqlDbType.Float, 8).Value = Convert.ToDouble(GPFCT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@gpf", SqlDbType.Float, 8).Value = 0;
                }
                if (HRR.Text != "")
                {
                   cmd.Parameters.Add("@hrr", SqlDbType.Float, 8).Value = Convert.ToDouble(HRR.Text);
                }
                else
               {
                   cmd.Parameters.Add("@hrr", SqlDbType.Float, 8).Value = 0;
                }
                if (GIFT.Text != "")
                {
                    cmd.Parameters.Add("@gisi", SqlDbType.Float, 8).Value = Convert.ToDouble(GIFT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@gisi", SqlDbType.Float, 8).Value = 0;
                }
                if (GSFT.Text != "")
                {
                    cmd.Parameters.Add("@giss", SqlDbType.Float, 8).Value = Convert.ToDouble(GSFT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@giss", SqlDbType.Float, 8).Value = 0;
                }
                if (INCOMET.Text != "")
                {
                    cmd.Parameters.Add("@incometax", SqlDbType.Float, 8).Value = Convert.ToDouble(INCOMET.Text);
                }
                else
                {
                    cmd.Parameters.Add("@incometax", SqlDbType.Float, 8).Value = 0;
                }
                if (GVRT.Text != "")
                {
                    cmd.Parameters.Add("@GVRT", SqlDbType.Float, 8).Value = Convert.ToDouble(GVRT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@GVRT", SqlDbType.Float, 8).Value = 0;
                }
                if (RD.Text != "")
                {
                    cmd.Parameters.Add("@RD", SqlDbType.Float, 8).Value = Convert.ToDouble(RD.Text);
                }
                else
                {
                    cmd.Parameters.Add("@RD", SqlDbType.Float, 8).Value = 0;
                }
                if (elecbill.Text != "")
                {
                    cmd.Parameters.Add("@ebill", SqlDbType.Float, 8).Value = Convert.ToDouble(elecbill.Text);
                }
                else
                {
                    cmd.Parameters.Add("@ebill", SqlDbType.Float, 8).Value = 0;
                }
                if (SDT.Text != "")
                {
                    cmd.Parameters.Add("@salded", SqlDbType.Float, 8).Value = Convert.ToDouble(SDT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@salded", SqlDbType.Float, 8).Value = 0;
                }
                cmd.Parameters.Add("@stopsal", SqlDbType.NVarChar, 6).Value = DIncs.SelectedItem.Value.ToString();
                cmd.Parameters.Add("@remarks", SqlDbType.NVarChar, 200).Value = RMARKT.Text.Replace("\'", "\'\'").Trim();
                //system
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = Uidt.Text;
                cmd.Parameters.Add("@dataentrydate", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];


           


                if (GPFCF.Text != "")
                {
                    cmd.Parameters.Add("@gpfiv", SqlDbType.Float, 8).Value = Convert.ToDouble(GPFCF.Text);
                }
                else
                {
                    cmd.Parameters.Add("@gpfiv", SqlDbType.Float, 8).Value = 0;
                }



                if (lic.Text != "")
                {
                    cmd.Parameters.Add("@lic", SqlDbType.Float, 8).Value = Convert.ToDouble(lic.Text);
                }
                else
                {
                    cmd.Parameters.Add("@lic", SqlDbType.Float, 8).Value = 0;
                }


                if (lic.Text != "")
                {
                    cmd.Parameters.Add("@socded", SqlDbType.Float, 8).Value = Convert.ToDouble(lic.Text);
                }
                else
                {
                    cmd.Parameters.Add("@socded", SqlDbType.Float, 8).Value = 0;
                }

                if (lic.Text != "")
                {
                    cmd.Parameters.Add("@rdded", SqlDbType.Float, 8).Value = Convert.ToDouble(lic.Text);
                }
                else
                {
                    cmd.Parameters.Add("@rdded", SqlDbType.Float, 8).Value = 0;
                }
                cmd.Parameters.Add("@pftype", SqlDbType.Int, 4).Value = pftype.SelectedValue.ToString();



                if (pranr.Text != "")
                {
                    cmd.Parameters.Add("@pranr", SqlDbType.Float, 8).Value = Convert.ToDouble(pranr.Text);
                }
                else
                {
                    cmd.Parameters.Add("@pranr", SqlDbType.Float, 8).Value = 0;
                }
                if (monthr.Text != "")
                {
                    cmd.Parameters.Add("@monthr", SqlDbType.NVarChar, 200).Value = (monthr.Text);
                }
                else
                {
                    cmd.Parameters.Add("@monthr", SqlDbType.NVarChar, 200).Value = 0;
                }
                if (ruralall.Text != "")
                {
                    cmd.Parameters.Add("@ruralall", SqlDbType.Int, 4).Value = (ruralall.Text);
                }
                else
                {
                    cmd.Parameters.Add("@ruralall", SqlDbType.Int, 4).Value = 0;
                }




                if (cmd.ExecuteNonQuery() == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "Added Successfully";

                }
            }
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
                cl.upcon.Close();
            }
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
            //cmd.Parameters.Add("@payid", SqlDbType.Int, 4).Value = Convert.ToInt32(ME.Text);
            //cmd.Parameters.Add("@userid", SqlDbType.Int, 4).Value = Convert.ToInt32(T1.Text);
            //cmd.Parameters.Add("@gpfno", SqlDbType.Int, 4).Value = Convert.ToInt32(T2.Text);
            ////cmd.Parameters.Add("@ddocode", SqlDbType.Int, 4).Value = D1.SelectedItem.Value;
            ////cmd.Parameters.Add("@grtcode", SqlDbType.Int, 4).Value = D2.SelectedItem.Value;
            //cmd.Parameters.Add("@basic", SqlDbType.Float, 8).Value = Convert.ToDouble(T3.Text);
            //cmd.Parameters.Add("@hra", SqlDbType.Float, 8).Value = Convert.ToDouble(T4.Text);
            //cmd.Parameters.Add("@cca", SqlDbType.Float, 8).Value = Convert.ToDouble(T5.Text);
            //cmd.Parameters.Add("@dapay", SqlDbType.Float, 8).Value = Convert.ToDouble(T6.Text);
            //cmd.Parameters.Add("@da", SqlDbType.Float, 8).Value = Convert.ToDouble(T7.Text);
            //cmd.Parameters.Add("@npa", SqlDbType.Float, 8).Value = Convert.ToDouble(T7.Text);
            //cmd.Parameters.Add("@tpa", SqlDbType.Float, 8).Value = Convert.ToDouble(T9.Text);
            //cmd.Parameters.Add("@other", SqlDbType.Float, 8).Value = Convert.ToDouble(T10.Text);
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
            //cmd.Parameters.Add("@payid", SqlDbType.Int, 4).Value = Convert.ToInt32(MD.Text);
            //cmd.Parameters.Add("@gpf", SqlDbType.Float, 8).Value = Convert.ToDouble(T11.Text);
            //cmd.Parameters.Add("@cgegis", SqlDbType.Float, 8).Value = Convert.ToDouble(T12.Text);
            //cmd.Parameters.Add("@gpfrecovery", SqlDbType.Float, 8).Value = Convert.ToDouble(T13.Text);
            //cmd.Parameters.Add("@compadv", SqlDbType.Float, 8).Value = Convert.ToDouble(T14.Text);
            //cmd.Parameters.Add("@compinst", SqlDbType.Int, 4).Value = Convert.ToInt32(T5.Text);
            //cmd.Parameters.Add("@compci", SqlDbType.Int, 4).Value = Convert.ToInt32(T16.Text);
            //cmd.Parameters.Add("@caradv", SqlDbType.Float, 8).Value = Convert.ToDouble(T17.Text);
            //cmd.Parameters.Add("@cinst", SqlDbType.Int, 4).Value = Convert.ToInt32(T18.Text);
            //cmd.Parameters.Add("@cci", SqlDbType.Int, 4).Value = Convert.ToInt32(T19.Text);
            //cmd.Parameters.Add("@scooteradv", SqlDbType.Float, 8).Value = Convert.ToDouble(T20.Text);
            //cmd.Parameters.Add("@sint", SqlDbType.Int, 4).Value = Convert.ToInt32(T21.Text);
            //cmd.Parameters.Add("@sci", SqlDbType.Int, 4).Value = Convert.ToInt32(T22.Text);
            //cmd.Parameters.Add("@hba", SqlDbType.Float, 8).Value = Convert.ToDouble(T23.Text);
            //cmd.Parameters.Add("@hinst", SqlDbType.Int, 4).Value = Convert.ToInt32(T24.Text);
            //cmd.Parameters.Add("@hci", SqlDbType.Int, 4).Value = Convert.ToInt32(T25.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                Label1.Visible = false;
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
   
    protected void Save_Click1(object sender, EventArgs e)
    {
        if ((string)Session["ddopid"] != null)
        {
            int idnum = Convert.ToInt32(Request.QueryString["idno"]);

            cl.ds = cl.DataFill("Select * from PMD_Pay_sal_mast where idno=" + idnum + " and ddocode=" + ddoid.Text + "");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Label1.Visible = true;
                Label1.Text = ("This Record Already Exist. ");
            }
            else
            {
                Basicsave();
            }
        }
        else
        {
            Label1.Visible = true;
            Label1.Text = ("Error :Session Expire please login Again ");
        }
    }
    public void Basicupdate()
    {   Double y;
        y = (Convert.ToDouble(BPAYT.Text) + Convert.ToDouble(GradePay.Text)) * 25 / 100;
        npa = Convert.ToString(Math.Ceiling(y));
        try
        {
            
            if (ConnectionState.Closed == cl.upcon.State)
            {
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("pmdAddsalarybasic1", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@payid", SqlDbType.Int, 4).Value = Convert.ToInt32(Label4.Text);// Request.QueryString["payid"];
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Label2.Text); //Request.QueryString["idno"];
                cmd.Parameters.Add("@pan", SqlDbType.VarChar, 20).Value = PAN.Text.ToString();
                if (DEmpt.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@empltypeid", SqlDbType.Int, 4).Value = DEmpt.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@empltypeid", SqlDbType.Int, 4).Value = 0;
                }
                cmd.Parameters.Add("@ddocode", SqlDbType.Int, 4).Value = Convert.ToInt32(ddoid.Text);
             
                if (Dpayh.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@headid", SqlDbType.Int, 4).Value = Dpayh.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@headid", SqlDbType.Int, 4).Value = 0;
                }
                if (DPays.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@scaleid", SqlDbType.Int, 4).Value = DPays.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@scaleid", SqlDbType.Int, 4).Value = 0;
                }
                if (DBank.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@bankid", SqlDbType.Int, 4).Value = DBank.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@bankid", SqlDbType.Int, 4).Value = 0;
                }
                cmd.Parameters.Add("@bankaccno", SqlDbType.NVarChar, 200).Value = BANKAT.Text.Replace("\'", "\'\'").Trim();
               
                //cmd.Parameters.Add("@incdueon", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(IDUT.Text);
                //cmd.Parameters.Add("@lastincdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DOIT.Text);
                cmd.Parameters.Add("@incdueon", DBNull.Value);
                cmd.Parameters.Add("@lastincdate", DBNull.Value);
                //if (DIncs.SelectedIndex != 0)
                //{
                //    cmd.Parameters.Add("@incstatus", SqlDbType.Int, 4).Value = DIncs.SelectedItem.Value;
                //}
                //else
                //{
                    cmd.Parameters.Add("@incstatus", SqlDbType.Int, 4).Value = 0;
                //}

                cmd.Parameters.Add("@gpfno", SqlDbType.NVarChar, 200).Value = GPFT.Text.Replace("\'", "\'\'").Trim();
               
                //cmd.Parameters.Add("@attendance", SqlDbType.Int, 4).Value = 30;// Convert.ToInt32(T7.Text);
                //Earning
                if (BPAYT.Text != "")
                {
                    cmd.Parameters.Add("@basicpay", SqlDbType.Float, 8).Value = Convert.ToDouble(BPAYT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@basicpay", SqlDbType.Float, 8).Value = 0;
                }
                //Grade pay
                if (GradePay.Text != "")
                {
                    cmd.Parameters.Add("@Gradepay", SqlDbType.Float, 8).Value = Convert.ToDouble(GradePay.Text);
                }
                else
                {
                    cmd.Parameters.Add("@Gradepay", SqlDbType.Float, 8).Value = 0;
                }
                //calculating npa
                
                //cmd.Parameters.Add("@npaall", SqlDbType.Float, 8).Value = Convert.ToDouble(npa);
                
                if (EHRAT.Text != "")
                {
                    cmd.Parameters.Add("@Ehra", SqlDbType.Float, 8).Value = Convert.ToDouble(EHRAT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@Ehra", SqlDbType.Float, 8).Value = 0;
                }
                if (CCAT.Text != "")
                {
                    cmd.Parameters.Add("@cca", SqlDbType.Float, 8).Value = Convert.ToDouble(CCAT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@cca", SqlDbType.Float, 8).Value = 0;
                }
                if (PENST.Text != "")
                {
                    cmd.Parameters.Add("@perpay", SqlDbType.Float, 8).Value = Convert.ToDouble(PENST.Text);
                }
                else
                {
                    cmd.Parameters.Add("@perpay", SqlDbType.Float, 8).Value = 0;
                }
                if (GVTPT.Text != "")
                {
                    cmd.Parameters.Add("@tpay", SqlDbType.Float, 8).Value = Convert.ToInt32(GVTPT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@tpay", SqlDbType.Float, 8).Value = 0;
                }
                if (SPAYT.Text != "")
                {
                    cmd.Parameters.Add("@sppay", SqlDbType.Float, 8).Value = Convert.ToDouble(SPAYT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@sppay", SqlDbType.Float, 8).Value = 0;
                }
                if (pensionText.Text != "")
                {
                    cmd.Parameters.Add("@pension", SqlDbType.Float, 8).Value = Convert.ToDouble(pensionText.Text);
                }
                else
                {
                    cmd.Parameters.Add("@pension", SqlDbType.Float, 8).Value = 0;
                }
                /*if (AttText.Text != "" || AttText.Text != "Full")
                {
                    cmd.Parameters.Add("@attendance", SqlDbType.Int, 4).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@attendance", SqlDbType.Int, 4).Value = 0;
                }*/
                    ////////////////////////////////////////////////////////////////////////////////
                //cmd.Parameters.Add("@pensionpay", SqlDbType.Float, 8).Value = Convert.ToInt32(PENST.Text);
                //deduction
                if (GPFCT.Text != "")
                {
                    cmd.Parameters.Add("@gpf", SqlDbType.Float, 8).Value = Convert.ToDouble(GPFCT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@gpf", SqlDbType.Float, 8).Value = 0;
                }
               if (HRR.Text != "")
               {
                   cmd.Parameters.Add("@hrr", SqlDbType.Float, 8).Value = Convert.ToDouble(HRR.Text);
                }
                else
                {
                  cmd.Parameters.Add("@hrr", SqlDbType.Float, 8).Value = 0;
                }
                if (RD.Text != "")
                {
                    cmd.Parameters.Add("@RD", SqlDbType.Float, 8).Value = Convert.ToDouble(RD.Text);
                }
                else
                {
                    cmd.Parameters.Add("@RD", SqlDbType.Float, 8).Value = 0;
                }
                if (GIFT.Text != "")
                {
                    cmd.Parameters.Add("@gisi", SqlDbType.Float, 8).Value = Convert.ToDouble(GIFT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@gisi", SqlDbType.Float, 8).Value = 0;
                }
                if (GSFT.Text != "")
                {
                    cmd.Parameters.Add("@giss", SqlDbType.Float, 8).Value = Convert.ToDouble(GSFT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@giss", SqlDbType.Float, 8).Value = 0;
                }
                if (INCOMET.Text != "")
                {
                    cmd.Parameters.Add("@incometax", SqlDbType.Float, 8).Value = Convert.ToDouble(INCOMET.Text);
                }
                else
                {
                    cmd.Parameters.Add("@incometax", SqlDbType.Float, 8).Value = 0;
                }
                if (GVRT.Text != "")
                {
                    cmd.Parameters.Add("@GVRT", SqlDbType.Float, 8).Value = Convert.ToDouble(GVRT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@GVRT", SqlDbType.Float, 8).Value = 0;
                }
                if (elecbill.Text != "")
                {
                    cmd.Parameters.Add("@ebill", SqlDbType.Float, 8).Value = Convert.ToDouble(elecbill.Text);
                }
                else
                {
                    cmd.Parameters.Add("@ebill", SqlDbType.Float, 8).Value = 0;
                }
                if (SDT.Text != "")
                {
                    cmd.Parameters.Add("@salded", SqlDbType.Float, 8).Value = Convert.ToDouble(SDT.Text);
                }
                else
                {
                    cmd.Parameters.Add("@salded", SqlDbType.Float, 8).Value = 0;
                }
                cmd.Parameters.Add("@stopsal", SqlDbType.NVarChar, 6).Value = DIncs.SelectedItem.Value.ToString();
                cmd.Parameters.Add("@remarks", SqlDbType.NVarChar, 200).Value = RMARKT.Text.Replace("\'", "\'\'").Trim();
                //system
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value =Convert.ToInt32(Uidt.Text);// 1;//
                cmd.Parameters.Add("@dataentrydate", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];

                if (GPFCF.Text != "")
                {
                    cmd.Parameters.Add("@gpfiv", SqlDbType.Float, 8).Value = Convert.ToDouble(GPFCF.Text);
                }
                else
                {
                    cmd.Parameters.Add("@gpfiv", SqlDbType.Float, 8).Value = 0;
                }



                if (lic.Text != "")
                {
                    cmd.Parameters.Add("@lic", SqlDbType.Float, 8).Value = Convert.ToDouble(lic.Text);
                }
                else
                {
                    cmd.Parameters.Add("@lic", SqlDbType.Float, 8).Value = 0;
                }


                if (socded.Text != "")
                {
                    cmd.Parameters.Add("@socded", SqlDbType.Float, 8).Value = Convert.ToDouble(socded.Text);
                }
                else
                {
                    cmd.Parameters.Add("@socded", SqlDbType.Float, 8).Value = 0;
                }

                if (rdded.Text != "")
                {
                    cmd.Parameters.Add("@rdded", SqlDbType.Float, 8).Value = Convert.ToDouble(rdded.Text);
                }
                else
                {
                    cmd.Parameters.Add("@rdded", SqlDbType.Float, 8).Value = 0;
                }


                //cmd.Parameters.Add("@pftype", SqlDbType.Int, 4).Value = pftype.SelectedValue.ToString();
                if (pftype.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@pftype", SqlDbType.Int, 4).Value = pftype.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@pftype", SqlDbType.Int, 4).Value = 0;
                }



                if (pranr.Text != "")
                {
                    cmd.Parameters.Add("@pranr", SqlDbType.Float, 8).Value = Convert.ToDouble(pranr.Text);
                }
                else
                {
                    cmd.Parameters.Add("@pranr", SqlDbType.Float, 8).Value = 0;
                }
                if (monthr.Text != "")
                {
                    cmd.Parameters.Add("@monthr", SqlDbType.NVarChar, 200).Value = (monthr.Text);
                }
                else
                {
                    cmd.Parameters.Add("@monthr", SqlDbType.NVarChar, 200).Value = 0;
                }



                if (ruralall.Text != "")
                {
                    cmd.Parameters.Add("@ruralall", SqlDbType.Int, 4).Value = (ruralall.Text);
                }
                else
                {
                    cmd.Parameters.Add("@ruralall", SqlDbType.Int, 4).Value = 0;
                }



                if (cmd.ExecuteNonQuery() == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "Data Updated Successfully";
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ("Error :" + ex.Message);
            //Label1.Text = "Some error in value";
        }
        finally
        {
            if (ConnectionState.Open == cl.upcon.State)
            {
                cl.upcon.Close();
            }
        }

    }
    /*protected void Update_Click(object sender, EventArgs e)
    {
        
        
    }*/
    protected void Other_Click(object sender, EventArgs e)
    {
        Response.Redirect("pmdADVLOANENTRY.aspx?idno=" + this.Label2.Text + "&payid=" + this.Label4.Text + "");//~/payrole/ADVLOANENTRY.aspx
    }

    /*protected void GradePay_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDouble(BPAYT.Text) != 0 && Convert.ToDouble(GradePay.Text) != 0)
            {
                Double y,npa;
                y = (Convert.ToDouble(BPAYT.Text) + Convert.ToDouble(GradePay.Text)) * 25 / 100;
                npa = Convert.ToString(Math.Round(y));
                
            }
        }
        catch (Exception etn)
        {
            this.Label1.Text = Convert.ToString(etn);
            this.Label1.Text = "Problem at NPA <BR> please check entries ";
        }
    }*/
   
    protected void DBank_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DT1.Enabled = true;
        DEmpt.Enabled = true;
        GPFT.Enabled = true;
        DPays.Enabled = true;
        Dpayh.Enabled = true;
        DBank.Enabled = true;
        BANKAT.Enabled = true;
        DIncs.Enabled = true;
        RMARKT.Enabled = true;
        BPAYT.Enabled = true;
        GradePay.Enabled = true;
        PAN.Enabled = true;
        CCAT.Enabled = true;
        PENST.Enabled = true;
        EHRAT.Enabled = true;
        SPAYT.Enabled = true;
        pensionText.Enabled = true;
        GVTPT.Enabled = true;
        AttText.Enabled = true;
        GPFCT.Enabled = true;
        GIFT.Enabled = true;
        GSFT.Enabled = true;
        INCOMET.Enabled = true;
        GVRT.Enabled = true;
        elecbill.Enabled = true;
        SDT.Enabled = true;
        RD.Enabled = true;
        HRR.Enabled = true;
        GPFCF.Enabled = true;
        lic.Enabled = true;
        socded.Enabled = true;
        rdded.Enabled = true;
        pftype.Enabled = true;
        Update.Enabled = true;
        pranr.Enabled = true;
        monthr.Enabled = true;
        ruralall.Enabled = true;

     
    }
    protected void Update_Click1(object sender, EventArgs e)
    {
        Basicupdate();
    }
    /*public void DIncs_SelectedIndexChanged(object sender, EventArgs e)
    {
        int stopdays = Convert.ToInt32(DIncs.SelectedItem.Value);
        int year = System.DateTime.Today.Year;
        int month = System.DateTime.Today.Month;
        int mdays = System.DateTime.DaysInMonth(year, month);

        AttText.Text = (mdays - stopdays).ToString();
    }*/
    protected void GPFCF_TextChanged(object sender, EventArgs e)
    {

    }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        if (this.Label2.Text != "")
        {
            Response.Redirect("~/pmdpayrole/pmdpayroleselect.aspx");
        }
        else if (this.Label4.Text != "")
        {
            Response.Redirect("~/payrole/payrolledit.aspx");
        }
        }
    }
}