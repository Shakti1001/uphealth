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
    public partial class bankstate : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q2, q3, q5, qr, finalqr, finalqr1;
        int j, prevbankid, k, sum;
        ArrayList bankarr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); //jump to first page for login
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
            bankarr = new ArrayList();


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

                if (option == 1)
                {
                    finalqr = " SELECT p.bankid ,d.bankname,s.name,s.hname,s.post,p.bankaccno,isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0)-isnull(a.salded,0) as grosssalary,isnull(a.gpf,0)+ isnull(a.gisi,0)+ isnull(a.giss,0)+ isnull(a.incometax,0)+ isnull(a.gvr,0)+ isnull(a.hrr,0)+ isnull(a.payded,0)+ isnull(a.Gpfadv,0)+ isnull(a.pli,0)+ isnull(a.elecbill,0)+ isnull(a.Licrd,0)+ isnull(a.hba1inst,0)+ isnull(a.hba2inst,0)+ isnull(a.hba3inst,0)+ isnull(a.hba1iinst,0)+ isnull(a.hba2iinst,0)+ isnull(a.hba3iinst,0)+isnull( a.vehinst,0)+ isnull(a.vehiinst,0)+ isnull(a.corinst,0)+ isnull(a.coriinst,0)+ isnull(a.Computer,0)+ isnull(a.Society,0)+isnull(ded1,0)+isnull(a.ded2,0)+isnull(a.ded3,0)+isnull(a.socded,0)as totded FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid inner join pay_sal_mast as p  on p.idno=a.idno inner join Pay_Bank as d on  d.bankid=p.bankid  WHERE " + qr + " and (p.gpfno like '%MEDU%') order by d.bankname  ";

                }
                if (option == 2)
                {
                    finalqr = " SELECT p.bankid ,d.bankname,s.name,s.hname,s.post,p.bankaccno,isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0)-isnull(a.salded,0) as grosssalary,isnull(a.gpf,0)+ isnull(a.gisi,0)+ isnull(a.giss,0)+ isnull(a.incometax,0)+ isnull(a.gvr,0)+ isnull(a.hrr,0)+ isnull(a.payded,0)+ isnull(a.Gpfadv,0)+ isnull(a.pli,0)+ isnull(a.elecbill,0)+ isnull(a.Licrd,0)+ isnull(a.hba1inst,0)+ isnull(a.hba2inst,0)+ isnull(a.hba3inst,0)+ isnull(a.hba1iinst,0)+ isnull(a.hba2iinst,0)+ isnull(a.hba3iinst,0)+isnull( a.vehinst,0)+ isnull(a.vehiinst,0)+ isnull(a.corinst,0)+ isnull(a.coriinst,0)+ isnull(a.Computer,0)+ isnull(a.Society,0)+isnull(ded1,0)+isnull(a.ded2,0)+isnull(a.ded3,0)+isnull(a.socded,0)as totded FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid inner join pay_sal_mast as p  on p.idno=a.idno inner join Pay_Bank as d on  d.bankid=p.bankid  WHERE " + qr + " and ( p.gpfno like '%PHU%') order by d.bankname ";

                }
                if (option == 3)
                {
                    finalqr = "SELECT p.bankid ,d.bankname,s.name,s.hname,s.post,p.bankaccno,isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0)-isnull(a.salded,0) as grosssalary,isnull(a.gpf,0)+ isnull(a.gisi,0)+ isnull(a.giss,0)+ isnull(a.incometax,0)+ isnull(a.gvr,0)+ isnull(a.hrr,0)+ isnull(a.payded,0)+ isnull(a.Gpfadv,0)+ isnull(a.pli,0)+ isnull(a.elecbill,0)+ isnull(a.Licrd,0)+ isnull(a.hba1inst,0)+ isnull(a.hba2inst,0)+ isnull(a.hba3inst,0)+ isnull(a.hba1iinst,0)+ isnull(a.hba2iinst,0)+ isnull(a.hba3iinst,0)+isnull( a.vehinst,0)+ isnull(a.vehiinst,0)+ isnull(a.corinst,0)+ isnull(a.coriinst,0)+ isnull(a.Computer,0)+ isnull(a.Society,0)+isnull(ded1,0)+isnull(a.ded2,0)+isnull(a.ded3,0)+isnull(a.socded,0)as totded FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid inner join pay_sal_mast as p  on p.idno=a.idno inner join Pay_Bank as d on  d.bankid=p.bankid  WHERE " + qr + " and p.gpfno not like '%MEDU%' and p.gpfno not like '%PHU%' and p.gpfno not like '%JU%' and p.gpfno not like '%PU%' and not p.gpfno='' order by d.bankname ";

                }

                if (option == 4)
                {
                    finalqr = "SELECT p.bankid ,d.bankname,s.name,s.hname,s.post,p.bankaccno,isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0)-isnull(a.salded,0) as grosssalary,isnull(a.gpf,0)+ isnull(a.gisi,0)+ isnull(a.giss,0)+ isnull(a.incometax,0)+ isnull(a.gvr,0)+ isnull(a.hrr,0)+ isnull(a.payded,0)+isnull(a.Gpfadv,0)+ isnull(a.pli,0)+ isnull(a.elecbill,0)+ isnull(a.Licrd,0)+ isnull(a.hba1inst,0)+ isnull(a.hba2inst,0)+ isnull(a.hba3inst,0)+ isnull(a.hba1iinst,0)+ isnull(a.hba2iinst,0)+ isnull(a.hba3iinst,0)+isnull( a.vehinst,0)+ isnull(a.vehiinst,0)+ isnull(a.corinst,0)+ isnull(a.coriinst,0)+ isnull(a.Computer,0)+ isnull(a.Society,0)+isnull(ded1,0)+isnull(a.ded2,0)+isnull(a.ded3,0)+isnull(a.socded,0)as totded FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid inner join pay_sal_mast as p  on p.idno=a.idno inner join Pay_Bank as d on  d.bankid=p.bankid  WHERE " + qr + " and p.gpfno =''order by d.bankname";

                }
                if (option == 5)
                {
                    finalqr = "SELECT p.bankid ,d.bankname,s.name,s.hname,s.post,p.bankaccno,isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0)-isnull(a.salded,0) as grosssalary,isnull(a.gpf,0)+ isnull(a.gisi,0)+ isnull(a.giss,0)+ isnull(a.incometax,0)+ isnull(a.gvr,0)+ isnull(a.hrr,0)+ isnull(a.payded,0)+isnull(a.Gpfadv,0)+ isnull(a.pli,0)+ isnull(a.elecbill,0)+ isnull(a.Licrd,0)+ isnull(a.hba1inst,0)+ isnull(a.hba2inst,0)+ isnull(a.hba3inst,0)+ isnull(a.hba1iinst,0)+ isnull(a.hba2iinst,0)+ isnull(a.hba3iinst,0)+isnull( a.vehinst,0)+ isnull(a.vehiinst,0)+ isnull(a.corinst,0)+ isnull(a.coriinst,0)+ isnull(a.Computer,0)+ isnull(a.Society,0)+isnull(ded1,0)+isnull(a.ded2,0)+isnull(a.ded3,0)+isnull(a.socded,0)as totded FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid inner join pay_sal_mast as p  on p.idno=a.idno inner join Pay_Bank as d on  d.bankid=p.bankid  WHERE " + qr + " and ( p.gpfno like '%PU%') order by d.bankname ";

                }
                if (option == 6)
                {
                    finalqr = "SELECT  p.bankid ,d.bankname,s.name,s.hname,s.post,p.bankaccno,isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0)-isnull(a.salded,0) as grosssalary,isnull(a.gpf,0)+ isnull(a.gisi,0)+ isnull(a.giss,0)+ isnull(a.incometax,0)+ isnull(a.gvr,0)+ isnull(a.hrr,0)+ isnull(a.payded,0)+isnull(a.Gpfadv,0)+ isnull(a.pli,0)+ isnull(a.elecbill,0)+ isnull(a.Licrd,0)+ isnull(a.hba1inst,0)+ isnull(a.hba2inst,0)+ isnull(a.hba3inst,0)+ isnull(a.hba1iinst,0)+ isnull(a.hba2iinst,0)+ isnull(a.hba3iinst,0)+isnull( a.vehinst,0)+ isnull(a.vehiinst,0)+ isnull(a.corinst,0)+ isnull(a.coriinst,0)+ isnull(a.Computer,0)+ isnull(a.Society,0)+isnull(ded1,0)+isnull(a.ded2,0)+isnull(a.ded3,0)+isnull(a.socded,0)as totded FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid inner join pay_sal_mast as p  on p.idno=a.idno inner join Pay_Bank as d on  d.bankid=p.bankid  WHERE " + qr + " and ( p.gpfno like '%JU%')order by d.bankname  ";

                }
            }
            else
            {
                finalqr = "SELECT p.bankid ,d.bankname,s.name,s.post,s.hname,p.bankaccno,(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.tpay,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))-(isnull(a.salded,0)) as grosssalary,isnull(a.gpf,0)+ isnull(a.gisi,0)+ isnull(a.giss,0)+ isnull(a.incometax,0)+ isnull(a.gvr,0)+ isnull(a.hrr,0)+ isnull(a.payded,0)+ isnull(a.Gpfadv,0)+ isnull(a.pli,0)+ isnull(a.elecbill,0)+ isnull(a.Licrd,0)+ isnull(a.hba1inst,0)+ isnull(a.hba2inst,0)+ isnull(a.hba3inst,0)+ isnull(a.hba1iinst,0)+ isnull(a.hba2iinst,0)+ isnull(a.hba3iinst,0)+isnull( a.vehinst,0)+ isnull(a.vehiinst,0)+ isnull(a.corinst,0)+ isnull(a.coriinst,0)+ isnull(a.Computer,0)+ isnull(a.Society,0)+isnull(ded1,0)+isnull(a.ded2,0)+isnull(a.ded3,0)+isnull(a.socded,0)as totded FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid inner join pay_sal_mast as p  on p.idno=a.idno inner join Pay_Bank as d on  d.bankid=p.bankid  WHERE " + qr + " order by d.bankname ";



            }



            cl.ds = cl.DataFill(finalqr);

            try
            {



                if (cl.ds.Tables[0].Rows.Count > 0)
                {


                    for (j = 0, k = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++, k++)
                    {


                        int nextbankid = Convert.ToInt32(cl.ds.Tables[0].Rows[j][0]);
                        string bankname = cl.ds.Tables[0].Rows[j][1].ToString();
                        if (j > 0)
                        {
                            prevbankid = Convert.ToInt32(cl.ds.Tables[0].Rows[j - 1][0]);
                        }
                        if ((j == 0) || (nextbankid != prevbankid))
                        {
                            if (j != 0)
                            {
                                TableRow rw99 = new TableRow();
                                rw99.BorderColor = System.Drawing.Color.Black;
                                TableCell tcell91 = new TableCell();
                                tcell91.Attributes.Add("colspan", "6");
                                tcell91.Style["Text-align"] = "right";
                                tcell91.Text = "Total Amount :" + sum.ToString();
                                tcell91.Font.Bold = true;
                                tcell91.BorderWidth = 2;
                                tcell91.BorderColor = System.Drawing.Color.Black;
                                tcell91.ForeColor = System.Drawing.Color.Maroon;
                                rw99.Cells.Add(tcell91);
                                Table1.Rows.Add(rw99);
                            }
                        }
                        if ((j == 0) || (nextbankid != prevbankid))
                        {
                            k = 0;
                            sum = 0;


                            TableRow rw19 = new TableRow();
                            rw19.BorderColor = System.Drawing.Color.Black;

                            TableCell tcell01 = new TableCell();
                            tcell01.Attributes.Add("colspan", "6");
                            tcell01.Style["Text-align"] = "left";
                            tcell01.Text = "BankName :" + bankname;
                            tcell01.Font.Bold = true;
                            tcell01.BorderWidth = 2;
                            tcell01.BorderColor = System.Drawing.Color.Black;
                            tcell01.ForeColor = System.Drawing.Color.Maroon;
                            rw19.Cells.Add(tcell01);
                            Table1.Rows.Add(rw19);

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
                            tcell4.Text = "Name";
                            tcell4.Font.Bold = true;
                            tcell4.BorderWidth = 2;
                            tcell4.BorderColor = System.Drawing.Color.Black;
                            tcell4.ForeColor = System.Drawing.Color.Maroon;
                            rw.Cells.Add(tcell4);


                            TableCell tcell1 = new TableCell();
                            tcell1.Text = "Designation";
                            tcell1.Font.Bold = true;
                            tcell1.BorderWidth = 2;
                            tcell1.BorderColor = System.Drawing.Color.Black;
                            tcell1.ForeColor = System.Drawing.Color.Maroon;
                            rw.Cells.Add(tcell1);

                            TableCell tcell18 = new TableCell();
                            tcell18.Text = "Place Of Posting";
                            tcell18.Font.Bold = true;
                            tcell18.BorderWidth = 2;
                            tcell18.BorderColor = System.Drawing.Color.Black;
                            tcell18.ForeColor = System.Drawing.Color.Maroon;
                            rw.Cells.Add(tcell18);

                            TableCell tcell2 = new TableCell();
                            tcell2.Text = "Account No ";
                            tcell2.Font.Bold = true;
                            tcell2.BorderWidth = 2;
                            tcell2.BorderColor = System.Drawing.Color.Black;
                            tcell2.ForeColor = System.Drawing.Color.Maroon;
                            rw.Cells.Add(tcell2);

                            TableCell tcell3 = new TableCell();
                            tcell3.Text = "Net Salary";
                            tcell3.Font.Bold = true;
                            tcell3.BorderWidth = 2;
                            tcell3.BorderColor = System.Drawing.Color.Black;
                            tcell3.ForeColor = System.Drawing.Color.Maroon;
                            rw.Cells.Add(tcell3);
                            Table1.Rows.Add(rw);
                        }

                        TableRow rw1 = new TableRow();
                        rw1.BorderWidth = 1;
                        rw1.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.ForeColor = System.Drawing.Color.Maroon;

                        TableCell tcellk1 = new TableCell();
                        tcellk1.BorderWidth = 1;
                        tcellk1.BorderColor = System.Drawing.Color.Black;
                        tcellk1.ForeColor = System.Drawing.Color.Black;
                        tcellk1.Text = Convert.ToString(k + 1);
                        rw1.Cells.Add(tcellk1);

                        TableCell tcellky = new TableCell();
                        tcellky.BorderWidth = 1;
                        tcellky.BorderColor = System.Drawing.Color.Black;
                        tcellky.ForeColor = System.Drawing.Color.Black;
                        tcellky.Text = cl.ds.Tables[0].Rows[j]["name"].ToString();
                        rw1.Cells.Add(tcellky);


                        TableCell tcellk2 = new TableCell();
                        tcellk2.Text = cl.ds.Tables[0].Rows[j]["post"].ToString();
                        tcellk2.BorderWidth = 1;
                        tcellk2.BorderColor = System.Drawing.Color.Black;
                        tcellk2.ForeColor = System.Drawing.Color.Black;
                        //tcellk2.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk2);

                        TableCell tcellk28 = new TableCell();
                        tcellk28.Text = cl.ds.Tables[0].Rows[j]["hname"].ToString();
                        tcellk28.BorderWidth = 1;
                        tcellk28.BorderColor = System.Drawing.Color.Black;
                        tcellk28.ForeColor = System.Drawing.Color.Black;
                        //tcellk2.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk28);

                        TableCell tcellk3 = new TableCell();
                        tcellk3.Text = cl.ds.Tables[0].Rows[j]["bankaccno"].ToString();
                        tcellk3.BorderWidth = 1;
                        tcellk3.BorderColor = System.Drawing.Color.Black;
                        tcellk3.ForeColor = System.Drawing.Color.Black;
                        //tcellk3.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk3);

                        TableCell tcellk4 = new TableCell();
                        tcellk4.BorderWidth = 1;
                        tcellk4.BorderColor = System.Drawing.Color.Black;
                        tcellk4.ForeColor = System.Drawing.Color.Black;
                        // tcellk4.BackColor = System.Drawing.Color.White;
                        tcellk4.Text = (Convert.ToInt32(cl.ds.Tables[0].Rows[j]["grosssalary"]) - Convert.ToInt32(cl.ds.Tables[0].Rows[j]["totded"])).ToString();
                        int netsalary = Convert.ToInt32(tcellk4.Text);
                        sum = sum + netsalary;
                        rw1.Cells.Add(tcellk4);
                        Table1.Rows.Add(rw1);
                        if (j == cl.ds.Tables[0].Rows.Count - 1)
                        {
                            TableRow rw999 = new TableRow();
                            rw999.BorderColor = System.Drawing.Color.Black;
                            TableCell tcell991 = new TableCell();
                            tcell991.Attributes.Add("colspan", "6");
                            tcell991.Style["Text-align"] = "right";
                            tcell991.Text = "Total Amount :" + sum.ToString();
                            tcell991.Font.Bold = true;
                            tcell991.BorderWidth = 2;
                            tcell991.BorderColor = System.Drawing.Color.Black;
                            tcell991.ForeColor = System.Drawing.Color.Maroon;
                            rw999.Cells.Add(tcell991);
                            Table1.Rows.Add(rw999);
                        }





                    }
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "No Record Found";

                }
            }

            catch (Exception ex)
            {
                MSGLab.Text = "Some Error Occured";
                //MSGLab.Text = ex.Message;

            }
            finally { }


        }
    }
}