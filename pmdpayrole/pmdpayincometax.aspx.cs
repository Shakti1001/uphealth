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
    public partial class pmdpayincometax : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q2, q3, q5, q6, qr, finalqr, finalqr1;
        int j;
        int flg = 0;
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





            if (Request.QueryString["adminunit"] != "0")
            {
                q6 = "a.adminunit=" + Request.QueryString["adminunit"] + "";


                qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5 + "  AND " + q6 + "";

            }
            else
            {
                q6 = "";
                qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5 + "";
            }









            //qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5 + "";
            int option = Convert.ToInt32(pftype);
            if (option != 0)
            {


                if (option == 1)//GPF
                {
                    finalqr = "SELECT     Pay_Head.headname, s.name, a.incometax, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)     + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.dapay, 0) AS PayX, ISNULL(a.panno, '')  AS panno FROM         pmdcalulatedsalary AS a INNER JOIN  pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN   Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and  a.pftype=1 and  (a.incometax!=0) order by Pay_Head.headname,poposting,Basicpay   ";
                    finalqr1 = "SELECT     SUM(ISNULL(a.incometax, 0)) AS incometax, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)    + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)   + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total FROM         pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and a.pftype=1 and  (a.incometax!=0) ";
                }



                if (option == 2)//PRAN
                {
                    finalqr = "SELECT     Pay_Head.headname, s.name, a.incometax, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)     + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.dapay, 0) AS PayX, ISNULL(a.panno, '')  AS panno FROM         pmdcalulatedsalary AS a INNER JOIN  pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN   Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and a.pftype=2 and  (a.incometax!=0)";
                    finalqr1 = "SELECT     SUM(ISNULL(a.incometax, 0)) AS incometax, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)    + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)   + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total FROM         pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid  WHERE " + qr + " and a.pftype=2 and  (a.incometax!=0) ";
                }
                if (option == 3)//ALL
                {
                    finalqr = "SELECT     Pay_Head.headname, s.name, a.incometax, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)  + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)     + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) AS grosssalary, ISNULL(a.dapay, 0) AS PayX, ISNULL(a.panno, '')  AS panno FROM         pmdcalulatedsalary AS a INNER JOIN  pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN   Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and  (a.incometax!=0)";
                    finalqr1 = "SELECT     SUM(ISNULL(a.incometax, 0)) AS incometax, SUM(ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0) + ISNULL(a.cca, 0)    + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0) + ISNULL(a.dearnesspay, 0)   + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0) - ISNULL(a.salded, 0)   + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0)) AS total FROM         pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid  WHERE " + qr + " and  (a.incometax!=0)";
                }

            }
            else
            {

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
                        flg = 1;
                    }
                }
                else
                {
                    MSGLab.Text = "Record Not Found................";

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
            //finalqr = "SELECT sum(isnull(a.incometax,0)) as incometax ,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.othall1,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0))as total FROM   pmdcalulatedsalary AS a INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid  WHERE " + qr + " ";
            try
            {
                cl.ds1 = cl.DataFill2(finalqr1);
                if (flg == 1)
                {
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
                    else
                    {
                        Response.Write("Record Not Found");

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