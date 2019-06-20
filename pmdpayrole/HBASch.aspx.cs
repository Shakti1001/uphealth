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
    public partial class HBASch : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q2, q3, q5, q6, q7, qr, finalqr, finalqr1;
        int j;
        int flg = 0;
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
                q7 = "";
                qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5;
            }



            int option = Convert.ToInt32(pftype);
            if (option != 0)
            {
                if (option == 1)//..............................................GPF+NOTALLOTTED
                {
                    finalqr = "SELECT      a.empsalid,PMDpersonaldetails.name,a.gpfno as GPFNo, a.hba1inst, a.hba2inst, a.hba3inst,( ISNULL(a.hba1inst, 0)   + ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0)) AS Totalintamt FROM         pmdcalulatedsalary AS a INNER JOIN    PMDpersonaldetails ON a.idno = PMDpersonaldetails.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno WHERE ( " + qr + ") and ((a.hba1inst <> 0) OR  (a.hba2inst <> 0) OR  (a.hba3inst <> 0)) and a.pftype=1 order by gpfno  ";
                    finalqr1 = "  SELECT     SUM(ISNULL(a.hba1inst, 0)) AS hba1inst,SUM(ISNULL(a.hba2inst, 0)) AS hba2inst,SUM(ISNULL(a.hba3inst, 0)) AS hba3inst, SUM(ISNULL(a.hba1inst, 0)+ ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0))as TotalAmount FROM  pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid where " + qr + " and a.pftype=1 ";
                }



                if (option == 2)//..............................................PRAN
                {
                    finalqr = "SELECT      a.empsalid,PMDpersonaldetails.name,a.gpfno as GPFNo, a.hba1inst, a.hba2inst, a.hba3inst,( ISNULL(a.hba1inst, 0)   + ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0)) AS Totalintamt FROM         pmdcalulatedsalary AS a INNER JOIN    PMDpersonaldetails ON a.idno = PMDpersonaldetails.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno WHERE ( " + qr + ") and ((a.hba1inst <> 0) OR  (a.hba2inst <> 0) OR  (a.hba3inst <> 0)) and a.pftype=2 order by gpfno  ";
                    finalqr1 = "  SELECT     SUM(ISNULL(a.hba1inst, 0)) AS hba1inst,SUM(ISNULL(a.hba2inst, 0)) AS hba2inst,SUM(ISNULL(a.hba3inst, 0)) AS hba3inst, SUM(ISNULL(a.hba1inst, 0)+ ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0))as TotalAmount FROM  pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid where " + qr + " and a.pftype=2";
                }


                if (option == 3)//......................ALL
                {

                    finalqr = "SELECT      a.empsalid,PMDpersonaldetails.name,a.gpfno as GPFNo, a.hba1inst, a.hba2inst, a.hba3inst,( ISNULL(a.hba1inst, 0)   + ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0)) AS Totalintamt FROM         pmdcalulatedsalary AS a INNER JOIN    PMDpersonaldetails ON a.idno = PMDpersonaldetails.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno WHERE " + qr + " and ((a.hba1inst <> 0) OR  (a.hba2inst <> 0) OR  (a.hba3inst <> 0)) ";
                    finalqr1 = "   SELECT     SUM(ISNULL(a.hba1inst, 0)) AS hba1inst,SUM(ISNULL(a.hba2inst, 0)) AS hba2inst,SUM(ISNULL(a.hba3inst, 0)) AS hba3inst, SUM(ISNULL(a.hba1inst, 0)+ ISNULL(a.hba2inst, 0) + ISNULL(a.hba3inst, 0))as TotalAmount FROM  pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid where " + qr + "";
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


                    TableCell tcell1 = new TableCell();
                    tcell1.Text = "EmpSalID";
                    tcell1.Font.Bold = true;
                    tcell1.BorderWidth = 2;
                    tcell1.BorderColor = System.Drawing.Color.Black;
                    tcell1.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell1);

                    TableCell tcell2 = new TableCell();
                    tcell2.Text = "Name";
                    tcell2.Font.Bold = true;
                    tcell2.BorderWidth = 2;
                    tcell2.BorderColor = System.Drawing.Color.Black;
                    tcell2.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell2);

                    TableCell tcell3 = new TableCell();
                    tcell3.Text = "GPF No";
                    tcell3.Font.Bold = true;
                    tcell3.BorderWidth = 2;
                    tcell3.BorderColor = System.Drawing.Color.Black;
                    tcell3.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell3);






                    TableCell tcell4 = new TableCell();
                    tcell4.Text = "HBA1 Inst.";
                    tcell4.Font.Bold = true;
                    tcell4.BorderWidth = 2;
                    tcell4.BorderColor = System.Drawing.Color.Black;
                    tcell4.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell4);


                    TableCell tcell5 = new TableCell();
                    tcell5.Text = "HBA2 Inst.";
                    tcell5.Font.Bold = true;
                    tcell5.BorderWidth = 2;
                    tcell5.BorderColor = System.Drawing.Color.Black;
                    tcell5.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell5);

                    TableCell tcell6 = new TableCell();
                    tcell6.Text = "HBA3 Inst.";
                    tcell6.Font.Bold = true;
                    tcell6.BorderWidth = 2;
                    tcell6.BorderColor = System.Drawing.Color.Black;
                    tcell6.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell6);

                    //TableCell tcell7 = new TableCell();
                    //tcell7.Text = "hba1iinst";
                    //tcell7.Font.Bold = true;
                    //tcell7.BorderWidth = 2;
                    //tcell7.BorderColor = System.Drawing.Color.Black;
                    //tcell7.ForeColor = System.Drawing.Color.Maroon;
                    //rw.Cells.Add(tcell7);

                    //TableCell tcell8 = new TableCell();
                    //tcell8.Text = "hba2iinst";
                    //tcell8.Font.Bold = true;
                    //tcell8.BorderWidth = 2;
                    //tcell8.BorderColor = System.Drawing.Color.Black;
                    //tcell8.ForeColor = System.Drawing.Color.Maroon;
                    //rw.Cells.Add(tcell8);

                    //TableCell tcell9 = new TableCell();
                    //tcell9.Text = "hba3iinst";
                    //tcell9.Font.Bold = true;
                    //tcell9.BorderWidth = 2;
                    //tcell9.BorderColor = System.Drawing.Color.Black;
                    //tcell9.ForeColor = System.Drawing.Color.Maroon;
                    //rw.Cells.Add(tcell9);


                    TableCell tcell10 = new TableCell();
                    tcell10.Text = "TotalAmount";
                    tcell10.Font.Bold = true;
                    tcell10.BorderWidth = 2;
                    tcell10.BorderColor = System.Drawing.Color.Black;
                    tcell10.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell10);



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

                        //Headlbl.Text = cl.ds.Tables[0].Rows[j]["EmpSalID"].ToString();

                        TableCell tcellk2 = new TableCell();
                        tcellk2.Text = cl.ds.Tables[0].Rows[j]["EmpSalID"].ToString();
                        tcellk2.BorderWidth = 1;
                        tcellk2.BorderColor = System.Drawing.Color.Black;
                        tcellk2.ForeColor = System.Drawing.Color.Black;
                        //// tcellk2.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk2);

                        TableCell tcellk3 = new TableCell();
                        tcellk3.Text = cl.ds.Tables[0].Rows[j]["Name"].ToString();
                        tcellk3.BorderWidth = 1;
                        tcellk3.BorderColor = System.Drawing.Color.Black;
                        tcellk3.ForeColor = System.Drawing.Color.Black;
                        //tcellk3.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk3);

                        TableCell tcellk4 = new TableCell();
                        tcellk4.Text = cl.ds.Tables[0].Rows[j]["GPFNo"].ToString();
                        tcellk4.BorderWidth = 1;
                        tcellk4.BorderColor = System.Drawing.Color.Black;
                        tcellk4.ForeColor = System.Drawing.Color.Black;
                        //tcellk3.BackColor = System.Drawing.Color.White;
                        rw1.Cells.Add(tcellk4);

                        TableCell tcellk5 = new TableCell();
                        tcellk5.BorderWidth = 1;
                        tcellk5.BorderColor = System.Drawing.Color.Black;
                        tcellk5.ForeColor = System.Drawing.Color.Black;
                        //tcellk4.BackColor = System.Drawing.Color.White;
                        tcellk5.Text = cl.ds.Tables[0].Rows[j]["hba1inst"].ToString();
                        rw1.Cells.Add(tcellk5);

                        TableCell tcellk6 = new TableCell();
                        tcellk6.BorderWidth = 1;
                        tcellk6.BorderColor = System.Drawing.Color.Black;
                        tcellk6.ForeColor = System.Drawing.Color.Black;
                        //tcellk5.BackColor = System.Drawing.Color.White;
                        tcellk6.Text = cl.ds.Tables[0].Rows[j]["hba2inst"].ToString();
                        rw1.Cells.Add(tcellk6);



                        TableCell tcellk7 = new TableCell();
                        tcellk7.BorderWidth = 1;
                        tcellk7.BorderColor = System.Drawing.Color.Black;
                        tcellk7.ForeColor = System.Drawing.Color.Black;
                        //tcellk7.BackColor = System.Drawing.Color.White;
                        tcellk7.Text = cl.ds.Tables[0].Rows[j]["hba3inst"].ToString();
                        rw1.Cells.Add(tcellk7);



                        //TableCell tcellk8 = new TableCell();
                        //tcellk8.BorderWidth = 1;
                        //tcellk8.BorderColor = System.Drawing.Color.Black;
                        //tcellk8.ForeColor = System.Drawing.Color.Black;
                        ////tcellk9.BackColor = System.Drawing.Color.White;
                        //tcellk8.Text = cl.ds.Tables[0].Rows[j]["hba1iinst"].ToString();
                        //rw1.Cells.Add(tcellk8);

                        //TableCell tcellk9 = new TableCell();
                        //tcellk9.BorderWidth = 1;
                        //tcellk9.BorderColor = System.Drawing.Color.Black;
                        //tcellk9.ForeColor = System.Drawing.Color.Black;
                        //// tcellk8.BackColor = System.Drawing.Color.White;
                        //tcellk9.Text = cl.ds.Tables[0].Rows[j]["hba2iinst"].ToString();
                        //rw1.Cells.Add(tcellk9);

                        //TableCell tcellk10 = new TableCell();
                        //tcellk10.BorderWidth = 1;
                        //tcellk10.BorderColor = System.Drawing.Color.Black;
                        //tcellk10.ForeColor = System.Drawing.Color.Black;
                        //// tcellk9.BackColor = System.Drawing.Color.White;
                        //tcellk10.Text = cl.ds.Tables[0].Rows[j]["hba3iinst"].ToString();
                        //rw1.Cells.Add(tcellk10);

                        TableCell tcellk11 = new TableCell();
                        tcellk11.BorderWidth = 1;
                        tcellk11.BorderColor = System.Drawing.Color.Black;
                        tcellk11.ForeColor = System.Drawing.Color.Black;
                        // tcellk9.BackColor = System.Drawing.Color.White;
                        tcellk11.Text = cl.ds.Tables[0].Rows[j]["Totalintamt"].ToString();
                        rw1.Cells.Add(tcellk11);





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
            HBA_Taxt_sum();
        }

        private void HBA_Taxt_sum()
        {

            //finalqr = "SELECT sum(isnull(a.gpf,0)) as gpf,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.othall1,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0)) as total ,sum(isnull(pay_loan_entry.intamt,0)) as toatalinstamt ,sum(isnull(a.gpf+isnull(pay_loan_entry.intamt,0),0))as totalamount FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid INNER JOIN  Pay_Section ON a.sectionid = Pay_Section.sectionid LEFT OUTER JOIN pay_loan_entry on a.idno= pay_loan_entry.idno and pay_loan_entry.litemid=2 WHERE " + qr + " ";
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
                            tcellkt1.Text = "Total ";
                            rwt1.Cells.Add(tcellkt1);

                            ////Headlbl.Text = cl.ds.Tables[0].Rows[j]["headname"].ToString();
                            TableCell tcellkt2 = new TableCell();
                            tcellkt2.Text = " ";
                            tcellkt2.BorderWidth = 1;
                            tcellkt2.BorderColor = System.Drawing.Color.Black;
                            tcellkt2.ForeColor = System.Drawing.Color.Maroon;
                            //tcellkt2.BackColor = System.Drawing.Color.White;
                            rwt1.Cells.Add(tcellkt2);

                            TableCell tcellkt3 = new TableCell();
                            tcellkt3.Text = " ";
                            tcellkt3.BorderWidth = 1;
                            tcellkt3.BorderColor = System.Drawing.Color.Black;
                            //tcellkt3.Font.Bold=true;
                            tcellkt3.ForeColor = System.Drawing.Color.Maroon;
                            // tcellkt3.BackColor = System.Drawing.Color.White;
                            rwt1.Cells.Add(tcellkt3);


                            TableCell tcellkt4 = new TableCell();
                            tcellkt4.Text = " ";
                            tcellkt4.BorderWidth = 1;
                            tcellkt4.BorderColor = System.Drawing.Color.Black;
                            tcellkt4.Font.Bold = true;
                            tcellkt4.ForeColor = System.Drawing.Color.Maroon;
                            //  tcellkt3.BackColor = System.Drawing.Color.White;
                            rwt1.Cells.Add(tcellkt4);




                            TableCell tcellkt5 = new TableCell();
                            tcellkt5.BorderWidth = 1;
                            tcellkt5.BorderColor = System.Drawing.Color.Black;
                            tcellkt5.ForeColor = System.Drawing.Color.Maroon;
                            //tcellkt4.BackColor = System.Drawing.Color.White;
                            tcellkt5.Font.Bold = true;
                            tcellkt5.Text = cl.ds1.Tables[0].Rows[j]["hba1inst"].ToString();
                            //tcellkt4.Text = cl.ds1.Tables[0].Rows[j]["gpf"].ToString();
                            rwt1.Cells.Add(tcellkt5);

                            TableCell tcellkt6 = new TableCell();
                            tcellkt6.BorderWidth = 1;
                            tcellkt6.BorderColor = System.Drawing.Color.Black;
                            tcellkt6.ForeColor = System.Drawing.Color.Maroon;
                            //tcellkt5.BackColor = System.Drawing.Color.White;
                            tcellkt6.Font.Bold = true;
                            tcellkt6.Text = cl.ds1.Tables[0].Rows[j]["hba2inst"].ToString();
                            rwt1.Cells.Add(tcellkt6);

                            TableCell tcellkt7 = new TableCell();
                            tcellkt7.Text = cl.ds1.Tables[0].Rows[j]["hba3inst"].ToString();
                            tcellkt7.BorderWidth = 1;
                            tcellkt7.BorderColor = System.Drawing.Color.Black;
                            tcellkt7.Font.Bold = true;
                            tcellkt7.ForeColor = System.Drawing.Color.Maroon;
                            //tcellkt7.BackColor = System.Drawing.Color.White;
                            rwt1.Cells.Add(tcellkt7);

                            TableCell tcellkt11 = new TableCell();
                            tcellkt11.Text = cl.ds1.Tables[0].Rows[j]["TotalAmount"].ToString();
                            tcellkt11.BorderWidth = 1;
                            tcellkt11.BorderColor = System.Drawing.Color.Black;
                            tcellkt11.Font.Bold = true;
                            tcellkt11.ForeColor = System.Drawing.Color.Maroon;
                            //tcellkt11.BackColor = System.Drawing.Color.White;
                            rwt1.Cells.Add(tcellkt11);
                            Table1.Rows.Add(rwt1);


                        }

                    }
                }
                else
                {

                    flg = 0;
                }
            }


            //public void Inc_Taxt_sum()
            // {

               //finalqr = "SELECT sum(isnull(a.gpf,0)) as gpf,sum(isnull(a.gradepay,0)+isnull(a.basicpay,0)+isnull(a.dapay,0)+isnull(a.hra,0)+isnull(a.cca,0)+isnull(a.othall6,0)+isnull(a.fixall2,0)+isnull(a.perpay,0)+isnull(a.othall1,0)+isnull(a.npaall,0)+isnull(a.othall4,0)+isnull(a.dearnesspay,0)+isnull(a.fixall3,0)+isnull(a.sppay,0)+isnull(a.othall2,0)+isnull(a.salarrear,0)+isnull(a.hill,0)+isnull(a.pensionpay,0)+isnull(a.salded,0)+isnull(a.othall3,0)+isnull(a.otharrear,0)+isnull(a.othall5,0)+isnull(a.fixall1,0)) as total ,sum(isnull(pay_loan_entry.intamt,0)) as toatalinstamt ,sum(isnull(a.gpf+isnull(pay_loan_entry.intamt,0),0))as totalamount FROM   calulatedsalary AS a INNER JOIN salaryselect AS s ON a.idno = s.idno INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN  Pay_Scale ON a.scaleid = Pay_Scale.scaleid INNER JOIN  Pay_Section ON a.sectionid = Pay_Section.sectionid LEFT OUTER JOIN pay_loan_entry on a.idno= pay_loan_entry.idno and pay_loan_entry.litemid=2 WHERE " + qr + " ";
            //try
            //{
            //            cl.ds1 = cl.DataFill2(finalqr1);
            //            if (cl.ds1.Tables[0].Rows.Count > 0)
            //            {
            //                for (j = 0; j <= cl.ds1.Tables[0].Rows.Count - 1; j++)
            //                {
            //                    TableRow rwt1 = new TableRow();
            //                    rwt1.BorderWidth = 1;
            //                    rwt1.BorderColor = System.Drawing.Color.SlateGray;
            //                    rwt1.ForeColor = System.Drawing.Color.Maroon;

        //                    TableCell tcellkt1 = new TableCell();
            //                    tcellkt1.BorderWidth = 1;
            //                    tcellkt1.BorderColor = System.Drawing.Color.Black;
            //                    tcellkt1.ForeColor = System.Drawing.Color.Maroon;
            //                    //tcellkt1.Text = Convert.ToString(j + 1);
            //                    tcellkt1.Font.Bold = true;
            //                    tcellkt1.Text = "Total ";
            //                    rwt1.Cells.Add(tcellkt1);

        //                    //Headlbl.Text = cl.ds.Tables[0].Rows[j]["headname"].ToString();
            //                    TableCell tcellkt2 = new TableCell();
            //                    tcellkt2.Text = " ";
            //                    tcellkt2.BorderWidth = 1;
            //                    tcellkt2.BorderColor = System.Drawing.Color.Black;
            //                    tcellkt2.ForeColor = System.Drawing.Color.Maroon;
            //                    //tcellkt2.BackColor = System.Drawing.Color.White;
            //                    rwt1.Cells.Add(tcellkt2);

        //                    //TableCell tcellkt3 = new TableCell();
            //                   // tcellkt3.Text = "";
            //                   // tcellkt3.BorderWidth = 1;
            //                   // tcellkt3.BorderColor = System.Drawing.Color.Black;
            //                   // tcellkt3.Font.Bold=true;
            //                  //  tcellkt3.ForeColor = System.Drawing.Color.Maroon;
            //                    //tcellkt3.BackColor = System.Drawing.Color.White;
            //                   // rwt1.Cells.Add(tcellkt3);

        //                    TableCell tcellkt4 = new TableCell();
            //                    tcellkt4.BorderWidth = 1;
            //                    tcellkt4.BorderColor = System.Drawing.Color.Black;
            //                    tcellkt4.ForeColor = System.Drawing.Color.Maroon;
            //                    //tcellkt4.BackColor = System.Drawing.Color.White;
            //                    tcellkt4.Font.Bold=true;
            //                    tcellkt4.Text = cl.ds1.Tables[0].Rows[j]["total"].ToString();
            //                    //tcellkt4.Text = cl.ds1.Tables[0].Rows[j]["gpf"].ToString();
            //                    rwt1.Cells.Add(tcellkt4);

        //                    TableCell tcellkt5 = new TableCell();
            //                    tcellkt5.BorderWidth = 1;
            //                    tcellkt5.BorderColor = System.Drawing.Color.Black;
            //                    tcellkt5.ForeColor = System.Drawing.Color.Maroon;
            //                    //tcellkt5.BackColor = System.Drawing.Color.White;
            //                    tcellkt5.Font.Bold = true;
            //                    tcellkt5.Text = cl.ds1.Tables[0].Rows[j]["hba1inst"].ToString();
            //                    rwt1.Cells.Add(tcellkt5);

        //                    //TableCell tcellkt6 = new TableCell();
            //                    //tcellkt6.Text = cl.ds1.Tables[0].Rows[j]["toatalinstamt"].ToString();
            //                   // tcellkt6.BorderWidth = 1;
            //                  //  tcellkt6.BorderColor = System.Drawing.Color.Black;
            //                  //  tcellkt6.Font.Bold = true;
            //                  //  tcellkt6.ForeColor = System.Drawing.Color.Maroon;
            //                   // tcellkt6.BackColor = System.Drawing.Color.White;
            //                   // rwt1.Cells.Add(tcellkt6);

        //                    TableCell tcellkt7 = new TableCell();
            //                    tcellkt7.Text = "";
            //                    tcellkt7.BorderWidth = 1;
            //                    tcellkt7.BorderColor = System.Drawing.Color.Black;
            //                    tcellkt7.Font.Bold = true;
            //                    tcellkt7.ForeColor = System.Drawing.Color.Maroon;
            //                    //tcellkt7.BackColor = System.Drawing.Color.White;
            //                    rwt1.Cells.Add(tcellkt7);

        //                   // TableCell tcellkt8 = new TableCell();
            //                  //  tcellkt8.Text = cl.ds1.Tables[0].Rows[j]["totalamount"].ToString();
            //                  //  tcellkt8.BorderWidth = 1;
            //                   // tcellkt8.BorderColor = System.Drawing.Color.Black;
            //                   // tcellkt8.Font.Bold = true;
            //                    //tcellkt8.ForeColor = System.Drawing.Color.Maroon;
            //                   // tcellkt8.BackColor = System.Drawing.Color.White;
            //                  //  rwt1.Cells.Add(tcellkt8);*/




        //                    Table1.Rows.Add(rwt1);

        //}
            //}
            //            }

               //}




            catch (Exception ex)
            {
                MSGLab.Text = ex.Message;
                //MSGLab.Text = finalqr;
            }
            finally { }

        }
    }
}