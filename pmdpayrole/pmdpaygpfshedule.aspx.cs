﻿using System;
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
    public partial class pmdpaygpfshedule : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q2, q3, q4, q5, qr, q7, finalqr, finalqr1;
        int j, recfound = 0;
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
            string pftype = Request.QueryString["pftype"];
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
                MonthLabel.Text = Request.QueryString["Months"];
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


            if (Request.QueryString["adminunit"] != "0")
            {

                q7 = "s.adminunit=" + Request.QueryString["adminunit"] + "";
                qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5 + "  AND " + q7;
            }
            else
            {
                //q7 = "s.adminunit like '%'";
                q7 = "";
                qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5;
            }

            int option = Convert.ToInt32(pftype);
            if (option == 1)//MEDU
            {
                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2   WHERE " + qr + " and a.pftype=1 and (a.gpfno like '%MEDU%')   order by a.gpfno ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "and (a.gpfno like '%MEDU%') ";

            }
            if (option == 2)//PHU
            {
                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2   WHERE " + qr + " and a.pftype=1  and ( a.gpfno like '%PHU%')  order by gpfno  ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid  WHERE " + qr + "and ( gpfno like '%PHU%') ";



            }

            if (option == 3)//PU
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0) AS totalamount, ISNULL(a.dapay, 0) AS PayX,    s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2  WHERE " + qr + " and a.pftype=1  and ( a.gpfno like '%PU%')   order by gpfno  ";
                //finalqr1 = " SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt,  SUM(ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0)) AS totalamount FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + "and ( gpfno like '%PU%') ";


                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2   WHERE " + qr + " and a.pftype=1  and ( a.gpfno like '%PU%')   order by gpfno  ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "and ( gpfno like '%PU%') ";



            }
            if (option == 4)//JU
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)  + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)  + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt, ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0) AS totalamount, ISNULL(a.dapay, 0) AS PayX, s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1  and ( gpfno like '%JU%')  order by gpfno  ";
                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt,  SUM(ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0)) AS totalamount FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + "and ( gpfno like '%JU%') ";

                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2  WHERE " + qr + " and a.pftype=1  and ( gpfno like '%JU%')  order by gpfno  ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "and ( gpfno like '%JU%') ";



            }

            if (option == 5)//CPU
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)  + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)  + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt, ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0) AS totalamount, ISNULL(a.dapay, 0) AS PayX, s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1  and ( gpfno like '%CPU%')  order by gpfno  ";
                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt,  SUM(ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0)) AS totalamount FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + "and ( gpfno like '%CPU%') ";

                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2  WHERE " + qr + " and a.pftype=1  and ( gpfno like '%CPU%')  order by gpfno  ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "and ( gpfno like '%CPU%') ";





            }


            if (option == 6)//LEU
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)  + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)  + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt, ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0) AS totalamount, ISNULL(a.dapay, 0) AS PayX, s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1  and ( gpfno like '%LEU%')  order by gpfno  ";
                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt,  SUM(ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0)) AS totalamount FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + "and ( gpfno like '%LEU%') ";

                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2  WHERE " + qr + " and a.pftype=1  and ( gpfno like '%LEU%')  order by gpfno  ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "and ( gpfno like '%LEU%') ";



            }

            if (option == 7)//ALL
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,    s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2    WHERE " + qr + " order by gpfno  ";
                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "";

                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2    WHERE " + qr + " order by gpfno  ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "";

                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt,  SUM(ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0)) AS totalamount,(SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + "and ( gpfno like '%LEU%') ";



            }


            if (option == 8)//PRAN
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0) AS totalamount, ISNULL(a.dapay, 0) AS PayX,    s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2  WHERE " + qr + " and a.pftype=2 order by Pay_Head.headname,poposting,Basicpay   ";
                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=2";



                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2   WHERE " + qr + " and a.pftype=2 order by Pay_Head.headname,poposting,Basicpay   ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and a.pftype=2";

            }

            if (option == 9)//AGU
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)  + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)  + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary,ISNULL(a.Gpfadv, 0) AS instamt, ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0) AS totalamount, ISNULL(a.dapay, 0) AS PayX, s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1 and ( a.gpfno like '%AGU%')  order by Pay_Head.headname,poposting,Basicpay   ";
                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt,  SUM(ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0)) AS totalamount FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1  and ( a.gpfno like '%AGU%')";


                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2  WHERE " + qr + " and a.pftype=1 and ( a.gpfno like '%AGU%')  order by Pay_Head.headname,poposting,Basicpay   ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and a.pftype=1  and ( a.gpfno like '%AGU%')";




            }

            if (option == 10)//GAU
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)  + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)  + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary,ISNULL(a.Gpfadv, 0) AS instamt, ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0) AS totalamount, ISNULL(a.dapay, 0) AS PayX, s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1 and ( a.gpfno like '%GAU%')  order by Pay_Head.headname,poposting,Basicpay   ";
                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt,  SUM(ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0)) AS totalamount FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1 and ( a.gpfno like '%GAU%') ";

                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2  WHERE " + qr + " and a.pftype=1 and ( a.gpfno like '%GAU%')  order by Pay_Head.headname,poposting,Basicpay   ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and a.pftype=1 and ( a.gpfno like '%GAU%') ";



            }

            if (option == 11)//COOPU
            {
                //finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)  + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)  + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt, ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0) AS totalamount, ISNULL(a.dapay, 0) AS PayX, s.adminunit FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1 and ( a.gpfno like '%COOPU%')  order by Pay_Head.headname,poposting,Basicpay   ";
                //finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)  + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)   + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)   + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt,  SUM(ISNULL(a.gpf + ISNULL(pmd_pay_loan_entry.intamt, 0), 0)) AS totalamount FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2 WHERE " + qr + " and a.pftype=1  and ( a.gpfno like '%COOPU%')";



                finalqr = "SELECT     Pay_Head.headname, s.name, a.gpfno, a.gpf, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)   + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)    + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.Gpfadv, 0) AS instamt,     ISNULL(pmd_pay_loan_entry.nlinstpaid, 0) AS paidinst, ISNULL(a.dapay, 0) AS PayX,(a.gpf+ ISNULL(a.Gpfadv, 0)) as total,   s.adminunit  FROM         pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid LEFT OUTER JOIN pmd_pay_loan_entry ON a.idno = pmd_pay_loan_entry.idno AND pmd_pay_loan_entry.litemid = 2  WHERE " + qr + " and a.pftype=1 and ( a.gpfno like '%COOPU%')  order by Pay_Head.headname,poposting,Basicpay   ";
                finalqr1 = "SELECT     SUM(ISNULL(a.gpf, 0)) AS gpf, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0)     + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0)    + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0) + ISNULL(a.othall3, 0)      + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total, SUM(ISNULL(a.Gpfadv, 0)) AS toatalinstamt, (SUM(ISNULL(a.gpf, 0))+SUM(ISNULL(a.Gpfadv, 0))) as stotal FROM         pmdcalulatedsalary AS a INNER JOIN     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and a.pftype=1  and ( a.gpfno like '%COOPU%')";

            }



            try
            {
                cl.ds = cl.DataFill(finalqr);
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    recfound = 1;
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
                    tcell4.Text = "GpfNo";
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
                    tcell3.Text = "Monthly GPF Deduction";
                    tcell3.Font.Bold = true;
                    tcell3.BorderWidth = 2;
                    tcell3.BorderColor = System.Drawing.Color.Black;
                    tcell3.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell3);



                    TableCell tcell6 = new TableCell();
                    tcell6.Text = "RepaymentOfGPFAdv ";
                    tcell6.Font.Bold = true;
                    tcell6.BorderWidth = 2;
                    tcell6.BorderColor = System.Drawing.Color.Black;
                    tcell6.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell6);


                    TableCell tcell8 = new TableCell();
                    tcell8.Text = "PaidInstNo";
                    tcell8.Font.Bold = true;
                    tcell8.BorderWidth = 2;
                    tcell8.BorderColor = System.Drawing.Color.Black;
                    tcell8.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell8);

                    TableCell tcell9 = new TableCell();
                    tcell9.Text = "TotalAmount";
                    tcell9.Font.Bold = true;
                    tcell9.BorderWidth = 2;
                    tcell9.BorderColor = System.Drawing.Color.Black;
                    tcell9.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell9);
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
                        TableCell tcellk2 = new TableCell();
                        tcellk2.Text = cl.ds.Tables[0].Rows[j]["gpfno"].ToString();
                        tcellk2.BorderWidth = 1;
                        tcellk2.BorderColor = System.Drawing.Color.Black;
                        tcellk2.ForeColor = System.Drawing.Color.Black;
                        // tcellk2.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk2);

                        TableCell tcellk3 = new TableCell();
                        tcellk3.Text = cl.ds.Tables[0].Rows[j]["name"].ToString();
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
                        tcellk4.Text = cl.ds.Tables[0].Rows[j]["grosssalary"].ToString();
                        rw1.Cells.Add(tcellk4);

                        TableCell tcellk5 = new TableCell();
                        tcellk5.BorderWidth = 1;
                        tcellk5.BorderColor = System.Drawing.Color.Black;
                        tcellk5.ForeColor = System.Drawing.Color.Black;
                        //tcellk5.BackColor = System.Drawing.Color.White;
                        tcellk5.Text = cl.ds.Tables[0].Rows[j]["gpf"].ToString();
                        rw1.Cells.Add(tcellk5);



                        TableCell tcellk7 = new TableCell();
                        tcellk7.BorderWidth = 1;
                        tcellk7.BorderColor = System.Drawing.Color.Black;
                        tcellk7.ForeColor = System.Drawing.Color.Black;
                        //tcellk7.BackColor = System.Drawing.Color.White;
                        tcellk7.Text = cl.ds.Tables[0].Rows[j]["instamt"].ToString();
                        rw1.Cells.Add(tcellk7);



                        TableCell tcellk9 = new TableCell();
                        tcellk9.BorderWidth = 1;
                        tcellk9.BorderColor = System.Drawing.Color.Black;
                        tcellk9.ForeColor = System.Drawing.Color.Black;
                        //tcellk9.BackColor = System.Drawing.Color.White;
                        if (Convert.ToInt32(cl.ds.Tables[0].Rows[j]["instamt"].ToString()) != 0)
                        {
                            tcellk9.Text = cl.ds.Tables[0].Rows[j]["paidinst"].ToString();
                            rw1.Cells.Add(tcellk9);
                        }

                        else
                        {
                            tcellk9.Text = "0";
                            rw1.Cells.Add(tcellk9);
                        }


                        TableCell tcellk8 = new TableCell();
                        tcellk8.BorderWidth = 1;
                        tcellk8.BorderColor = System.Drawing.Color.Black;
                        tcellk8.ForeColor = System.Drawing.Color.Black;
                        // tcellk8.BackColor = System.Drawing.Color.White;
                        tcellk8.Text = cl.ds.Tables[0].Rows[j]["total"].ToString();
                        rw1.Cells.Add(tcellk8);
                        Table1.Rows.Add(rw1);
                        Table1.BorderColor = System.Drawing.Color.Black;
                        Table1.BorderWidth = 2;

                    }
                    calsum();
                }

                else
                {
                    recfound = 0;

                    MSGLab.Text = "Record Not Found....";

                }
            }
            catch (Exception ex)
            {
                MSGLab.Text = ex.Message;
                MSGLab.Text = finalqr;
            }
            finally { }

        }


        public void calsum()
        {

            try
            {
                if (recfound == 1)
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
                            tcellkt1.Text = "Total ";
                            rwt1.Cells.Add(tcellkt1);

                            //Headlbl.Text = cl.ds.Tables[0].Rows[j]["headname"].ToString();
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
                            //tcellkt4.Text = cl.ds1.Tables[0].Rows[j]["gpf"].ToString();
                            rwt1.Cells.Add(tcellkt4);

                            TableCell tcellkt5 = new TableCell();
                            tcellkt5.BorderWidth = 1;
                            tcellkt5.BorderColor = System.Drawing.Color.Black;
                            tcellkt5.ForeColor = System.Drawing.Color.Maroon;
                            //tcellkt5.BackColor = System.Drawing.Color.White;
                            tcellkt5.Font.Bold = true;
                            tcellkt5.Text = cl.ds1.Tables[0].Rows[j]["gpf"].ToString();
                            rwt1.Cells.Add(tcellkt5);

                            TableCell tcellkt6 = new TableCell();
                            tcellkt6.Text = cl.ds1.Tables[0].Rows[j]["toatalinstamt"].ToString();
                            tcellkt6.BorderWidth = 1;
                            tcellkt6.BorderColor = System.Drawing.Color.Black;
                            tcellkt6.Font.Bold = true;
                            tcellkt6.ForeColor = System.Drawing.Color.Maroon;
                            // tcellkt6.BackColor = System.Drawing.Color.White;
                            rwt1.Cells.Add(tcellkt6);

                            TableCell tcellkt7 = new TableCell();
                            tcellkt7.Text = "";
                            tcellkt7.BorderWidth = 1;
                            tcellkt7.BorderColor = System.Drawing.Color.Black;
                            tcellkt7.Font.Bold = true;
                            tcellkt7.ForeColor = System.Drawing.Color.Maroon;
                            //tcellkt7.BackColor = System.Drawing.Color.White;
                            rwt1.Cells.Add(tcellkt7);

                            TableCell tcellkt8 = new TableCell();
                            tcellkt8.Text = cl.ds1.Tables[0].Rows[j]["stotal"].ToString();
                            tcellkt8.BorderWidth = 1;
                            tcellkt8.BorderColor = System.Drawing.Color.Black;
                            tcellkt8.Font.Bold = true;
                            tcellkt8.ForeColor = System.Drawing.Color.Maroon;
                            // tcellkt8.BackColor = System.Drawing.Color.White;
                            rwt1.Cells.Add(tcellkt8);
                            Table1.Rows.Add(rwt1);

                        }
                    }
                }
                else
                {
                    MSGLab.Text = "Sum Not Calculated........";
                    recfound = 0;
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