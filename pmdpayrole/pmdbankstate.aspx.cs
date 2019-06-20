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
    public partial class pmdbankstate : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q2, q3, q5, q6, q7, qr, finalqr, finalqr1;
        int j, prevbankid, k, sum;
        ArrayList bankarr;
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
            bankarr = new ArrayList();


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
            if (option != 0)
            {


                if (option == 1)//notalloted
                {
                    finalqr = "SELECT     p.bankid, d.bankname, s.name, s.hname, s.post, p.bankaccno, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0)  + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0)   + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0)   + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) - ISNULL(a.salded, 0) AS grosssalary,  ISNULL(a.gpf, 0) + ISNULL(a.gisi, 0)  + ISNULL(a.giss, 0) + ISNULL(a.incometax, 0) + ISNULL(a.gvr, 0) + ISNULL(a.hrr, 0) + ISNULL(a.payded, 0) + ISNULL(a.Gpfadv, 0) + ISNULL(a.pli, 0) + ISNULL(a.elecbill, 0) + ISNULL(a.hba1inst, 0) + ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0) + ISNULL(a.hba1iinst, 0) + ISNULL(a.hba2iinst, 0)  + ISNULL(a.hba3iinst, 0) + ISNULL(a.vehinst, 0) + ISNULL(a.vehiinst, 0) + ISNULL(a.corinst, 0) + ISNULL(a.coriinst, 0) + ISNULL(a.Computer, 0)  + ISNULL(a.ded1, 0) + ISNULL(a.ded2, 0) + ISNULL(a.ded3, 0) +ISNULL(a.gpfiv, 0)+ISNULL(a.gpf4adv, 0)+isnull(a.lic,0)   AS totded FROM         pmdcalulatedsalary AS a INNER JOIN  pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_Pay_sal_mast AS p ON p.idno = a.idno INNER JOIN  Pay_Bank AS d ON d.bankid = p.bankid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "  and  a.pftype=1 order by d.bankname ";

                }

                if (option == 2)//PRAN
                {
                    finalqr = "SELECT     p.bankid, d.bankname, s.name, s.hname, s.post, p.bankaccno, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0)  + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0)   + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0)   + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) - ISNULL(a.salded, 0) AS grosssalary,  ISNULL(a.gpf, 0) + ISNULL(a.gisi, 0)  + ISNULL(a.giss, 0) + ISNULL(a.incometax, 0) + ISNULL(a.gvr, 0) + ISNULL(a.hrr, 0) + ISNULL(a.payded, 0) + ISNULL(a.Gpfadv, 0) + ISNULL(a.pli, 0) + ISNULL(a.elecbill, 0) + ISNULL(a.hba1inst, 0) + ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0) + ISNULL(a.hba1iinst, 0) + ISNULL(a.hba2iinst, 0)  + ISNULL(a.hba3iinst, 0) + ISNULL(a.vehinst, 0) + ISNULL(a.vehiinst, 0) + ISNULL(a.corinst, 0) + ISNULL(a.coriinst, 0) + ISNULL(a.Computer, 0)  + ISNULL(a.ded1, 0) + ISNULL(a.ded2, 0) + ISNULL(a.ded3, 0) +ISNULL(a.gpfiv, 0)+ISNULL(a.gpf4adv, 0)+isnull(a.lic,0)   AS totded FROM         pmdcalulatedsalary AS a INNER JOIN  pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_Pay_sal_mast AS p ON p.idno = a.idno INNER JOIN  Pay_Bank AS d ON d.bankid = p.bankid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "  and  a.pftype=2 order by d.bankname ";

                }

                if (option == 3)//ALL
                {
                    finalqr = "SELECT     p.bankid, d.bankname, s.name, s.hname, s.post, p.bankaccno, ISNULL(a.Gradepay, 0) + ISNULL(a.basicpay, 0) + ISNULL(a.dapay, 0) + ISNULL(a.hra, 0)  + ISNULL(a.cca, 0) + ISNULL(a.othall6, 0) + ISNULL(a.fixall2, 0) + ISNULL(a.perpay, 0) + ISNULL(a.tpay, 0) + ISNULL(a.npaall, 0) + ISNULL(a.othall4, 0)   + ISNULL(a.dearnesspay, 0) + ISNULL(a.fixall3, 0) + ISNULL(a.sppay, 0) + ISNULL(a.othall2, 0) + ISNULL(a.salarrear, 0) + ISNULL(a.hill, 0) + ISNULL(a.pensionpay, 0)   + ISNULL(a.othall3, 0) + ISNULL(a.otharrear, 0) + ISNULL(a.othall5, 0) + ISNULL(a.fixall1, 0) - ISNULL(a.salded, 0) AS grosssalary,  ISNULL(a.gpf, 0) + ISNULL(a.gisi, 0)  + ISNULL(a.giss, 0) + ISNULL(a.incometax, 0) + ISNULL(a.gvr, 0) + ISNULL(a.hrr, 0) + ISNULL(a.payded, 0) + ISNULL(a.Gpfadv, 0) + ISNULL(a.pli, 0) + ISNULL(a.elecbill, 0) + ISNULL(a.hba1inst, 0) + ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0) + ISNULL(a.hba1iinst, 0) + ISNULL(a.hba2iinst, 0)  + ISNULL(a.hba3iinst, 0) + ISNULL(a.vehinst, 0) + ISNULL(a.vehiinst, 0) + ISNULL(a.corinst, 0) + ISNULL(a.coriinst, 0) + ISNULL(a.Computer, 0)  + ISNULL(a.ded1, 0) + ISNULL(a.ded2, 0) + ISNULL(a.ded3, 0) +ISNULL(a.gpfiv, 0)+ISNULL(a.gpf4adv, 0)+isnull(a.lic,0)  AS totded FROM         pmdcalulatedsalary AS a INNER JOIN  pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid INNER JOIN PMD_Pay_sal_mast AS p ON p.idno = a.idno INNER JOIN  Pay_Bank AS d ON d.bankid = p.bankid INNER JOIN PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " order by d.bankname  ";

                }
            }
            else
            {
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