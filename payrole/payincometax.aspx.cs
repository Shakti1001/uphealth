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
    public partial class payincometax : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q2, q3, q5, qr, finalqr, finalqr1;
        int j;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); //jump to first page for login
                }
                if ((string)Session["ddoname"] != null && (string)Session["ddopid"] != null)
                {
                    this.Label1.Text = (string)Session["ddoname"];
                    Inc_Taxt_salary();
                }
            }
        }



        public void Inc_Taxt_salary()
        {


            string gpfser = Request.QueryString["GPFser"];
            //**************years*****************        
            if (Request.QueryString["years"] != "N")
            {
                q1 = "a.Syear=" + Request.QueryString["years"] + "";
                YearLabel.Text = Request.QueryString["years"];
            }
            //**************Months*****************
            if (Request.QueryString["Months"] != "N")
            {
                q2 = "a.Smonth=" + Request.QueryString["Months"] + "";
                MonthLabel.Text = Request.QueryString["Mtext"];
            }

            //****************DDOID***************        
            q3 = "s.ddoid=" + (string)Session["ddopid"] + "";
            //******************SectionID****************

            //******************HeadID****************
            if (Request.QueryString["HeadID"] == "0")
            {
                q5 = "Pay_Head.headid like '%'";
                //q5 = "Pay_Head.headid=0";
            }
            else
            {
                if (Request.QueryString["HeadID"].Length == 1)
                {
                    q5 = "Pay_Head.headid=" + Request.QueryString["HeadID"] + "";
                }
                else
                {
                    q5 = "Pay_Head.headid like '%" + Request.QueryString["HeadID"] + "%' ";
                }
            }

            qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5 + "";
            int option = Convert.ToInt32(gpfser);
            if (option != 0)
            {

                //finalqr = "SELECT  a.idno, s.senno, a.gpfno, isnull(a.basicpay, 0) AS basicpay, isnull(a.dapay, 0) AS dapay, isnull(a.hra, 0) AS hra, isnull(a.cca, 0) AS cca, isnull(a.othall5,0) AS othall6,isnull(a.fixall2, 0) AS fixall2,  isnull(a.gpf, 0) AS gpf, isnull(a.gvr, 0) AS gvr, isnull(a.hba1inst, 0) AS hba1inst,isnull(a.hba1iinst, 0) AS hba1iinst, isnull(a.pli, 0) AS pli, isnull(a.incometax, 0) AS incometax, 0 AS totded, isnull(a.socded, 0) AS socded, s.name,isnull(a.plino, 0) AS plino, isnull(a.perpay, 0) AS perpay, isnull(a.othall1, 0) AS othall1, isnull(a.npaall, 0) AS npaall, isnull(a.othall4, 0) AS othall4,isnull(a.dearnesspay, 0) AS dearnesspay, isnull(a.fixall3, 0) AS fixall3, 0 AS GpfA, isnull(a.Dhra, 0) AS Dhra, isnull(a.hba2inst, 0) AS hba2inst, isnull(a.hba2iinst, 0) AS hba2iinst, isnull(a.gisi, 0) AS gisi, isnull(a.ded1, 0) AS ded1, isnull(a.licded, 0) AS licded, s.post, isnull(a.sppay, 0) AS sppay, isnull(a.othall2, 0) AS othall2, isnull(a.salarrear, 0) AS salarrear, isnull(a.hill, 0) AS hill, isnull(a.pensionpay, 0) AS pensionpay, isnull(a.salded, 0) AS salded, 0 AS gpf4, isnull(a.vehinst, 0) AS vehinst, isnull(a.hba3inst, 0) AS hba3inst, isnull(a.hba1iinst, 0) AS hba1iinst, isnull(a.giss, 0) AS giss, isnull(a.ded2, 0) AS ded2, isnull(a.attendance, 0) AS attendance, isnull(a.othall3, 0) AS othall3, isnull(a.otharrear,0) AS otharrear, isnull(a.othall5, 0) AS othall5, isnull(a.fixall1, 0) AS fixall1, 0 AS gpf4, isnull(a.vehiinst, 0) AS vehiinst, isnull(a.corinst, 0) AS corinst, isnull(a.coriinst, 0) AS coriinst, 0 AS gistot, isnull(a.ded3, 0) AS ded3,  a.remarks, Pay_Section.sectionname,  Pay_Head.headname, (Cast(Pay_Scale.llimit as varchar)+' -'+Cast(Pay_Scale.llimit2 as varchar)+' -'+Cast( Pay_Scale.llimit3 as varchar)+' -'+Cast(Pay_Scale.ulimit as varchar)) as payscale,isnull(a.Gradepay, 0) AS Gradepay FROM         calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid INNER JOIN  Pay_Section ON a.sectionid = Pay_Section.sectionid WHERE " + qr + " and gpfno like '%MEDU%' or '%PHU%'  order by sectionname,headname,basicpay  ";
                if (option == 1)
                {
                    finalqr = " SELECT     Pay_Head.headname, s.name, a.incometax, isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0) as grosssalary , isnull(a.dapay,0) as PayX,isnull(a.panno,'')as panno FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid WHERE " + qr + " and (gpfno like '%MEDU%')  order by gpfno  ";
                    finalqr1 = " SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + " and (gpfno like '%MEDU%') ";
                }
                if (option == 2)
                {
                    finalqr = " SELECT     Pay_Head.headname, s.name, a.incometax, isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0) as grosssalary , isnull(a.dapay,0) as PayX,isnull(a.panno,'')as panno FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid WHERE " + qr + " and ( gpfno like '%PHU%')  order by gpfno  ";
                    finalqr1 = " SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + " and (gpfno like '%PHU%') ";
                }
                if (option == 3)
                {
                    finalqr = "SELECT     Pay_Head.headname, s.name, a.incometax, isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0) as grosssalary , isnull(a.dapay,0) as PayX,isnull(a.panno,'')as panno FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid WHERE " + qr + " and gpfno not like '%MEDU%' and gpfno not like '%PHU%'and gpfno not like '%JU%' and gpfno not like '%PU%' and not gpfno='' order by headname,basicpay  ";
                    finalqr1 = "SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + " and gpfno not like '%MEDU%' and gpfno not like '%PHU%'and gpfno not like '%JU%' and gpfno not like '%PU%' and not gpfno=''";
                }

                if (option == 4)
                {
                    finalqr = "SELECT     Pay_Head.headname, s.name, a.incometax, isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0) as grosssalary , isnull(a.dapay,0) as PayX,isnull(a.panno,'')as panno FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid WHERE " + qr + " and gpfno ='' ";
                    finalqr1 = "SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + " and gpfno =''";
                }
                if (option == 5)
                {
                    finalqr = " SELECT     Pay_Head.headname, s.name, a.incometax, isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0) as grosssalary , isnull(a.dapay,0) as PayX,isnull(a.panno,'')as panno FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid WHERE " + qr + " and ( gpfno like '%PU%')  order by gpfno  ";
                    finalqr1 = " SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + " and (gpfno like '%PU%') ";
                }
                if (option == 6)
                {
                    finalqr = " SELECT     Pay_Head.headname, s.name, a.incometax, isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0) as grosssalary , isnull(a.dapay,0) as PayX,isnull(a.panno,'')as panno FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid WHERE " + qr + " and ( gpfno like '%JU%')  order by gpfno  ";
                    finalqr1 = " SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + " and (gpfno like '%JU%') ";
                }
            }
            else
            {
                finalqr = "SELECT     Pay_Head.headname, s.name, a.incometax, isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0) as grosssalary , isnull(a.dapay,0) as PayX,isnull(a.panno,'')as panno FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid WHERE " + qr + " order by gpfno ";
                finalqr1 = "SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)-isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + "  ";


            }

            try
            {
                cl.ds = cl.DataFill(finalqr);
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    //mesl.Visible = false;

                    TableRow rw = new TableRow();
                    rw.BorderColor = System.Drawing.Color.Black;

                    TableCell tcell0 = new TableCell();
                    tcell0.Text = "Serial No";
                    tcell0.Font.Bold = true;
                    tcell0.BorderWidth = 2;
                    tcell0.BorderColor = System.Drawing.Color.Black;
                    tcell0.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell0);

                    TableCell tcell4 = new TableCell();
                    tcell4.Text = "PAN No";
                    tcell4.Font.Bold = true;
                    tcell4.BorderWidth = 2;
                    tcell4.BorderColor = System.Drawing.Color.Black;
                    tcell4.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell4);


                    TableCell tcell1 = new TableCell();
                    tcell1.Text = "Name";
                    tcell1.Font.Bold = true;
                    tcell1.BorderWidth = 2;
                    tcell1.BorderColor = System.Drawing.Color.Black;
                    tcell1.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell1);

                    TableCell tcell2 = new TableCell();
                    tcell2.Text = "GrossSalary ";
                    tcell2.Font.Bold = true;
                    tcell2.BorderWidth = 2;
                    tcell2.BorderColor = System.Drawing.Color.Black;
                    tcell2.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell2);

                    TableCell tcell3 = new TableCell();
                    tcell3.Text = "Monthly I.Tax Deduction";
                    tcell3.Font.Bold = true;
                    tcell3.BorderWidth = 2;
                    tcell3.BorderColor = System.Drawing.Color.Black;
                    tcell3.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell3);
                    Table1.Rows.Add(rw);
                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {
                        TableRow rw1 = new TableRow();
                        rw1.BorderWidth = 1;
                        rw1.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.ForeColor = System.Drawing.Color.Maroon;

                        TableCell tcellk1 = new TableCell();
                        tcellk1.BorderWidth = 1;
                        tcellk1.BorderColor = System.Drawing.Color.Black;
                        tcellk1.ForeColor = System.Drawing.Color.Black;
                        tcellk1.Text = Convert.ToString(j + 1);
                        rw1.Cells.Add(tcellk1);

                        Headlbl.Text = cl.ds.Tables[0].Rows[j]["headname"].ToString();

                        TableCell tcellk5 = new TableCell();
                        tcellk5.BorderWidth = 1;
                        tcellk5.BorderColor = System.Drawing.Color.Black;
                        tcellk5.ForeColor = System.Drawing.Color.Black;
                        tcellk5.Text = cl.ds.Tables[0].Rows[j]["panno"].ToString();
                        rw1.Cells.Add(tcellk5);


                        TableCell tcellk2 = new TableCell();
                        tcellk2.Text = cl.ds.Tables[0].Rows[j]["name"].ToString();
                        tcellk2.BorderWidth = 1;
                        tcellk2.BorderColor = System.Drawing.Color.Black;
                        tcellk2.ForeColor = System.Drawing.Color.Black;
                        //tcellk2.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk2);

                        TableCell tcellk3 = new TableCell();
                        tcellk3.Text = cl.ds.Tables[0].Rows[j]["grosssalary"].ToString();
                        tcellk3.BorderWidth = 1;
                        tcellk3.BorderColor = System.Drawing.Color.Black;
                        tcellk3.ForeColor = System.Drawing.Color.Black;
                        //tcellk3.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk3);

                        TableCell tcellk4 = new TableCell();
                        tcellk4.BorderWidth = 1;
                        tcellk4.BorderColor = System.Drawing.Color.Black;
                        tcellk4.ForeColor = System.Drawing.Color.Black;
                        //tcellk4.BackColor = System.Drawing.Color.White;
                        tcellk4.Text = cl.ds.Tables[0].Rows[j]["incometax"].ToString();
                        rw1.Cells.Add(tcellk4);


                        Table1.Rows.Add(rw1);
                        Table1.BorderColor = System.Drawing.Color.Black;
                        Table1.BorderWidth = 2;

                    }
                }
            }
            catch (Exception ex)
            {
                MSGLab.Text = ex.Message;
                //MSGLab.Text = finalqr;
            }
            finally { }
            Inc_Taxt_sum();
        }

        public void Inc_Taxt_sum()
        {
            //**************years*****************        
            if (Request.QueryString["years"] != "N")
            {
                q1 = "a.Syear=" + Request.QueryString["years"] + "";
                YearLabel.Text = Request.QueryString["years"];
            }
            //**************Months*****************
            if (Request.QueryString["Months"] != "N")
            {
                q2 = "a.Smonth=" + Request.QueryString["Months"] + "";
                MonthLabel.Text = Request.QueryString["Mtext"];
            }

            //****************DDOID***************        
            q3 = "s.ddoid=" + (string)Session["ddopid"] + "";
            //******************SectionID****************

            //******************HeadID****************
            if (Request.QueryString["HeadID"] != "ALL")
            {
                if (Request.QueryString["HeadID"].Length == 1)
                {
                    q5 = "Pay_Head.headid=" + Request.QueryString["HeadID"] + "";
                }
                else
                {
                    q5 = "Pay_Head.headid like '%" + Request.QueryString["HeadID"] + "%' ";
                }
                //Headlbl.Text = q5;
            }
            else
            {
                q5 = "Pay_Head.headid like '%'";
            }

            qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5 + "";
            //finalqr = "SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.othall1,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + " ";
            try
            {
                cl.ds1 = cl.DataFill2(finalqr1);
                if (cl.ds1.Tables[0].Rows.Count > 0)
                {
                    for (j = 0; j <= cl.ds1.Tables[0].Rows.Count - 1; j++)
                    {
                        TableRow rwt1 = new TableRow();
                        rwt1.BorderWidth = 1;
                        rwt1.BorderColor = System.Drawing.Color.SlateGray;
                        rwt1.ForeColor = System.Drawing.Color.Maroon;

                        TableCell tcellkt1 = new TableCell();
                        tcellkt1.BorderWidth = 1;
                        tcellkt1.BorderColor = System.Drawing.Color.Black;
                        tcellkt1.ForeColor = System.Drawing.Color.Maroon;
                        //tcellkt1.Text = Convert.ToString(j + 1);
                        tcellkt1.Font.Bold = true;
                        tcellkt1.Text = " Total";
                        rwt1.Cells.Add(tcellkt1);

                        Headlbl.Text = cl.ds.Tables[0].Rows[j]["headname"].ToString();
                        TableCell tcellkt2 = new TableCell();
                        tcellkt2.Text = " ";
                        tcellkt2.BorderWidth = 1;
                        tcellkt2.BorderColor = System.Drawing.Color.Black;
                        tcellkt2.ForeColor = System.Drawing.Color.Maroon;
                        //tcellkt2.BackColor = System.Drawing.Color.White;
                        rwt1.Cells.Add(tcellkt2);

                        TableCell tcellkt3 = new TableCell();
                        tcellkt3.Text = "";
                        tcellkt3.BorderWidth = 1;
                        tcellkt3.BorderColor = System.Drawing.Color.Black;
                        tcellkt3.Font.Bold = true;
                        tcellkt3.ForeColor = System.Drawing.Color.Maroon;
                        //tcellkt3.BackColor = System.Drawing.Color.White;
                        rwt1.Cells.Add(tcellkt3);

                        TableCell tcellkt4 = new TableCell();
                        tcellkt4.BorderWidth = 1;
                        tcellkt4.BorderColor = System.Drawing.Color.Black;
                        tcellkt4.ForeColor = System.Drawing.Color.Maroon;
                        //tcellkt4.BackColor = System.Drawing.Color.White;
                        tcellkt4.Font.Bold = true;
                        tcellkt4.Text = cl.ds1.Tables[0].Rows[j]["total"].ToString();
                        rwt1.Cells.Add(tcellkt4);

                        TableCell tcellkt5 = new TableCell();
                        tcellkt5.BorderWidth = 1;
                        tcellkt5.BorderColor = System.Drawing.Color.Black;
                        tcellkt5.ForeColor = System.Drawing.Color.Maroon;
                        //tcellkt4.BackColor = System.Drawing.Color.White;
                        tcellkt5.Font.Bold = true;
                        tcellkt5.Text = cl.ds1.Tables[0].Rows[j]["incometax"].ToString();
                        rwt1.Cells.Add(tcellkt5);


                        Table1.Rows.Add(rwt1);

                    }
                }

            }
            catch (Exception ex)
            {
                MSGLab.Text = ex.Message;
                //MSGLab.Text = finalqr;
            }
            finally { }

        }
    }
}