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
    public partial class HBASchinst : System.Web.UI.Page
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
            if (option != 0)
            {


                if (option == 1)//.............................................GPF
                {

                    finalqr = "SELECT      a.empsalid,PMDpersonaldetails.name,a.gpfno as GPFNo, a.hba1iinst, a.hba2iinst, a.hba3iinst,( ISNULL(a.hba1iinst, 0)   + ISNULL(a.hba2iinst, 0) + ISNULL(a.hba3iinst, 0)) AS Totalintamt FROM         pmdcalulatedsalary AS a INNER JOIN    PMDpersonaldetails ON a.idno = PMDpersonaldetails.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno WHERE " + qr + " and ((a.hba1iinst <> 0) OR  (a.hba2iinst <> 0) OR  (a.hba3iinst <> 0)) and a.pftype=1 ";
                    finalqr1 = "   SELECT     SUM(ISNULL(a.hba1iinst, 0)) AS hba1iinst,SUM(ISNULL(a.hba2iinst, 0)) AS hba2iinst,SUM(ISNULL(a.hba3iinst, 0)) AS hba3iinst, SUM(ISNULL(a.hba1iinst, 0)+ ISNULL(a.hba2iinst, 0) + ISNULL(a.hba3iinst, 0))as TotalAmount FROM  pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid where " + qr + " and a.pftype=1";


                }

                if (option == 2)//.............................................PRAN
                {

                    finalqr = "SELECT      a.empsalid,PMDpersonaldetails.name,a.gpfno as GPFNo, a.hba1iinst, a.hba2iinst, a.hba3iinst,( ISNULL(a.hba1iinst, 0)   + ISNULL(a.hba2iinst, 0) + ISNULL(a.hba3iinst, 0)) AS Totalintamt FROM         pmdcalulatedsalary AS a INNER JOIN    PMDpersonaldetails ON a.idno = PMDpersonaldetails.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno WHERE " + qr + " and ((a.hba1iinst <> 0) OR  (a.hba2iinst <> 0) OR  (a.hba3iinst <> 0)) and a.pftype=2 ";
                    finalqr1 = "   SELECT     SUM(ISNULL(a.hba1iinst, 0)) AS hba1iinst,SUM(ISNULL(a.hba2iinst, 0)) AS hba2iinst,SUM(ISNULL(a.hba3iinst, 0)) AS hba3iinst, SUM(ISNULL(a.hba1iinst, 0)+ ISNULL(a.hba2iinst, 0) + ISNULL(a.hba3iinst, 0))as TotalAmount FROM  pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid where " + qr + " and a.pftype=2";



                }

                if (option == 3)//..............ALL
                {



                    finalqr = "SELECT      a.empsalid,PMDpersonaldetails.name,a.gpfno as GPFNo, a.hba1iinst, a.hba2iinst, a.hba3iinst,( ISNULL(a.hba1iinst, 0)   + ISNULL(a.hba2iinst, 0) + ISNULL(a.hba3iinst, 0)) AS Totalintamt FROM         pmdcalulatedsalary AS a INNER JOIN    PMDpersonaldetails ON a.idno = PMDpersonaldetails.idno INNER JOIN    Pay_Head ON a.headid = Pay_Head.headid INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno WHERE " + qr + " and ((a.hba1iinst <> 0) OR  (a.hba2iinst <> 0) OR  (a.hba3iinst <> 0)) ";
                    finalqr1 = "   SELECT     SUM(ISNULL(a.hba1iinst, 0)) AS hba1iinst,SUM(ISNULL(a.hba2iinst, 0)) AS hba2iinst,SUM(ISNULL(a.hba3iinst, 0)) AS hba3iinst, SUM(ISNULL(a.hba1iinst, 0)+ ISNULL(a.hba2iinst, 0) + ISNULL(a.hba3iinst, 0))as TotalAmount FROM  pmdcalulatedsalary AS a INNER JOIN   pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN  Pay_Head ON a.headid = Pay_Head.headid where " + qr + " and ((a.hba1iinst <> 0) OR  (a.hba2iinst <> 0) OR  (a.hba3iinst <> 0))";
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
                    tcell4.Text = "HBA1 Insterest Inst.";
                    tcell4.Font.Bold = true;
                    tcell4.BorderWidth = 2;
                    tcell4.BorderColor = System.Drawing.Color.Black;
                    tcell4.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell4);


                    TableCell tcell5 = new TableCell();
                    tcell5.Text = "HBA2 Insterest Inst.";
                    tcell5.Font.Bold = true;
                    tcell5.BorderWidth = 2;
                    tcell5.BorderColor = System.Drawing.Color.Black;
                    tcell5.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell5);

                    TableCell tcell6 = new TableCell();
                    tcell6.Text = "HBA3 Insterest Inst.";
                    tcell6.Font.Bold = true;
                    tcell6.BorderWidth = 2;
                    tcell6.BorderColor = System.Drawing.Color.Black;
                    tcell6.ForeColor = System.Drawing.Color.Maroon;
                    rw.Cells.Add(tcell6);




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


                        TableCell tcellk2 = new TableCell();
                        tcellk2.Text = cl.ds.Tables[0].Rows[j]["EmpSalID"].ToString();
                        tcellk2.BorderWidth = 1;
                        tcellk2.BorderColor = System.Drawing.Color.Black;
                        tcellk2.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcellk2);

                        TableCell tcellk3 = new TableCell();
                        tcellk3.Text = cl.ds.Tables[0].Rows[j]["Name"].ToString();
                        tcellk3.BorderWidth = 1;
                        tcellk3.BorderColor = System.Drawing.Color.Black;
                        tcellk3.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcellk3);

                        TableCell tcellk4 = new TableCell();
                        tcellk4.Text = cl.ds.Tables[0].Rows[j]["GPFNo"].ToString();
                        tcellk4.BorderWidth = 1;
                        tcellk4.BorderColor = System.Drawing.Color.Black;
                        tcellk4.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcellk4);

                        TableCell tcellk5 = new TableCell();
                        tcellk5.BorderWidth = 1;
                        tcellk5.BorderColor = System.Drawing.Color.Black;
                        tcellk5.ForeColor = System.Drawing.Color.Black;
                        tcellk5.Text = cl.ds.Tables[0].Rows[j]["hba1iinst"].ToString();
                        rw1.Cells.Add(tcellk5);

                        TableCell tcellk6 = new TableCell();
                        tcellk6.BorderWidth = 1;
                        tcellk6.BorderColor = System.Drawing.Color.Black;
                        tcellk6.ForeColor = System.Drawing.Color.Black;
                        tcellk6.Text = cl.ds.Tables[0].Rows[j]["hba2iinst"].ToString();
                        rw1.Cells.Add(tcellk6);



                        TableCell tcellk7 = new TableCell();
                        tcellk7.BorderWidth = 1;
                        tcellk7.BorderColor = System.Drawing.Color.Black;
                        tcellk7.ForeColor = System.Drawing.Color.Black;
                        tcellk7.Text = cl.ds.Tables[0].Rows[j]["hba3iinst"].ToString();
                        rw1.Cells.Add(tcellk7);

                        TableCell tcellk11 = new TableCell();
                        tcellk11.BorderWidth = 1;
                        tcellk11.BorderColor = System.Drawing.Color.Black;
                        tcellk11.ForeColor = System.Drawing.Color.Black;
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
            }
            finally { }
            HBA_Taxt_sum();
        }

        private void HBA_Taxt_sum()
        {

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
                            tcellkt1.Font.Bold = true;
                            tcellkt1.Text = "Total ";
                            rwt1.Cells.Add(tcellkt1);


                            TableCell tcellkt2 = new TableCell();
                            tcellkt2.Text = " ";
                            tcellkt2.BorderWidth = 1;
                            tcellkt2.BorderColor = System.Drawing.Color.Black;
                            tcellkt2.ForeColor = System.Drawing.Color.Maroon;
                            rwt1.Cells.Add(tcellkt2);

                            TableCell tcellkt3 = new TableCell();
                            tcellkt3.Text = " ";
                            tcellkt3.BorderWidth = 1;
                            tcellkt3.BorderColor = System.Drawing.Color.Black;
                            tcellkt3.ForeColor = System.Drawing.Color.Maroon;
                            rwt1.Cells.Add(tcellkt3);


                            TableCell tcellkt4 = new TableCell();
                            tcellkt4.Text = " ";
                            tcellkt4.BorderWidth = 1;
                            tcellkt4.BorderColor = System.Drawing.Color.Black;
                            tcellkt4.Font.Bold = true;
                            tcellkt4.ForeColor = System.Drawing.Color.Maroon;
                            rwt1.Cells.Add(tcellkt4);




                            TableCell tcellkt5 = new TableCell();
                            tcellkt5.BorderWidth = 1;
                            tcellkt5.BorderColor = System.Drawing.Color.Black;
                            tcellkt5.ForeColor = System.Drawing.Color.Maroon;
                            tcellkt5.Font.Bold = true;
                            tcellkt5.Text = cl.ds1.Tables[0].Rows[j]["hba1iinst"].ToString();
                            rwt1.Cells.Add(tcellkt5);

                            TableCell tcellkt6 = new TableCell();
                            tcellkt6.BorderWidth = 1;
                            tcellkt6.BorderColor = System.Drawing.Color.Black;
                            tcellkt6.ForeColor = System.Drawing.Color.Maroon;
                            tcellkt6.Font.Bold = true;
                            tcellkt6.Text = cl.ds1.Tables[0].Rows[j]["hba2iinst"].ToString();
                            rwt1.Cells.Add(tcellkt6);

                            TableCell tcellkt7 = new TableCell();
                            tcellkt7.Text = cl.ds1.Tables[0].Rows[j]["hba3iinst"].ToString();
                            tcellkt7.BorderWidth = 1;
                            tcellkt7.BorderColor = System.Drawing.Color.Black;
                            tcellkt7.Font.Bold = true;
                            tcellkt7.ForeColor = System.Drawing.Color.Maroon;
                            rwt1.Cells.Add(tcellkt7);



                            TableCell tcellkt11 = new TableCell();
                            tcellkt11.Text = cl.ds1.Tables[0].Rows[j]["TotalAmount"].ToString();
                            tcellkt11.BorderWidth = 1;
                            tcellkt11.BorderColor = System.Drawing.Color.Black;
                            tcellkt11.Font.Bold = true;
                            tcellkt11.ForeColor = System.Drawing.Color.Maroon;
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

            catch (Exception ex)
            {
                MSGLab.Text = ex.Message;
                //MSGLab.Text = finalqr;
            }
            finally { }

        }
    }
}