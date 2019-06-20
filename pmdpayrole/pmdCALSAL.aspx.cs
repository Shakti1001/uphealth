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

namespace NewWebApp.pmdpayrole
{
    public partial class pmdCALSAL : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q3, qr, q2;
        string fyear, fmonth, npa;
        int Md, j, stopdays, attdays;
        int adunt = 0;
        string salarySr;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                Uidt.Text = (string)Session["iduser"];
                if ((string)Session["ddopid"] != null)
                {
                    finalsal();
                }
                //SAL();
                //////loanenrty();
                //////Earnupdate();
            }

        }

        public void finalsal()
        {
            cl.dstimech = cl.Dtimech("select datepart(yyyy,getdate()) as dY,datepart(mm,getdate()) as dM");

            fyear = Request.QueryString["year"];
            fmonth = Request.QueryString["Month"];
            Md = System.DateTime.DaysInMonth(Convert.ToInt32(fyear), Convert.ToInt32(fmonth));
            if (Request.QueryString["DDOID"] != "ALL")
            {
                if (Request.QueryString["DDOID"].Length == 1)
                {
                    q1 = "b.ddoid=" + Request.QueryString["DDOID"] + "";
                }
                else
                {
                    q1 = "b.ddoid=" + Request.QueryString["DDOID"] + "";

                }
            }
            //******************adminunit****************

            if (Request.QueryString["adminunit"] != "0")
            {

                q2 = "b.adminunit=" + Request.QueryString["adminunit"] + "";
                qr = q1 + " and " + q2;
                adunt = 1;
            }

            else
            {
                qr = q1;
                adunt = 0;
            }
            if (adunt == 1)
            {
                cl.dshospitalid = cl.Dthospitalid("select distinct idno from pmdcalulatedsalary  where ddoid= " + (string)Session["ddopid"] + " and Smonth=" + fmonth + " and Syear=" + fyear + " and adminunit=" + Request.QueryString["adminunit"] + "");
                salarySr = "select isnull(max(Smonth),0)as maxmonth,isnull(max(syear),0) as maxyear from pmdcalulatedsalary where (ddoid=" + (string)Session["ddopid"] + ") and adminunit=" + Request.QueryString["adminunit"] + " and Syear in ( select isnull(max(Syear),0)as Syear  from pmdcalulatedsalary as a where (ddoid=" + (string)Session["ddopid"] + ") and adminunit=" + Request.QueryString["adminunit"] + "  )";

                //salarySr = "select isnull(max(Smonth),0)as maxmonth from pmdcalulatedsalary where (ddoid=40) and adminunit=414  and Syear in ( select isnull(max(Syear),0)as Syear  from pmdcalulatedsalary as a where (ddoid=40) and adminunit=414 )";

            }
            else
            {

                cl.dshospitalid = cl.Dthospitalid("select distinct idno from pmdcalulatedsalary  where ddoid= " + (string)Session["ddopid"] + " and Smonth=" + fmonth + " and Syear=" + fyear + "");
                salarySr = "select isnull(max(Smonth),0)as maxmonth,isnull(max(syear),0) as maxyear from pmdcalulatedsalary where (ddoid=" + (string)Session["ddopid"] + ")  and Syear in ( select isnull(max(Syear),0)as Syear  from pmdcalulatedsalary as a where (ddoid=" + (string)Session["ddopid"] + ") )";

            }

            //qr = q1 + " and " +q2;

            cl.ds = cl.DataFill(salarySr);

            int maxmonth = Convert.ToInt32(cl.ds.Tables[0].Rows[0][0]);
            int month = Convert.ToInt32(fmonth);
            int maxyear = Convert.ToInt32(cl.ds.Tables[0].Rows[0][1]);
            int year = Convert.ToInt32(fyear);
            if (cl.dshospitalid.Tables[0].Rows.Count > 0)
            {

                if (maxmonth == month && maxyear == year)
                {
                    this.mesg.Text = "The Salary Of " + (string)Session["ddoname"] + " for the month " + fmonth + "  and year " + fyear + " already Processed. ";//copy below 2 lines,add label and delete button in design page
                    this.mesg1.Text = "Do you want to delete it for Reprocess.";
                    GRLink.Visible = false;
                }
                else
                {
                    //this.mesg.Text = "The Salary Of " + (string)Session["ddoname"] + " for the month " + fmonth + "  and year " + fyear + " cannot be Reprocessed. ";//copy below 2 lines,add label and delete button in design page
                    //Button1.Visible = false;
                    //mesg1.Visible = false;

                    this.mesg.Text = "Salary for the month " + fmonth + " - " + fyear + " cannot be Reprocessed........... ";//copy below 2 lines,add label and delete button in design page
                    this.mesg2.Text = " You have already Processed Salary for " + maxmonth + "-" + " " + fyear + "";
                    this.mesg3.Text = " ........Delete it to Reprocess ";

                    Button1.Visible = false;
                    mesg1.Visible = false;





                }
            }
            else
            {
                SAL();
            }


        }
        public void SAL()
        {
            //maxpice();
            int count = 0;
            if (Request.QueryString["year"] != "" && Request.QueryString["Month"] != "")
            {

                cl.ds = cl.DataFill("SELECT     a.stopsal, b.ddoid, a.headid, a.scaleid, a.payid, a.idno, a.gpfno, ISNULL(a.basicpay, 0) AS basicpay, ISNULL(a.Ehra, 0) AS Ehra, ISNULL(a.cca, 0) AS cca,  ISNULL(a.perpay, 0) AS perpay, ISNULL(a.tpay, 0) AS tpay, ISNULL(a.sppay, 0) AS sppay, ISNULL(a.pensionpay, 0) AS pensionpay, ISNULL(a.gpf, 0) AS gpf,   ISNULL(a.gisi, 0) AS gisi, ISNULL(a.giss, 0) AS giss, ISNULL(a.incometax, 0) AS incometax, ISNULL(a.gvr, 0) AS gvr, ISNULL(a.hrr, 0) AS hrr, ISNULL(a.payded, 0)   AS payded, ISNULL(a.salded, 0) AS salded, ISNULL(a.remarks, 'XX') AS remarks, a.empltypeid, a.bankid, a.bankaccno, a.incdueon, a.lastincdate, a.incstatus,  ISNULL(a.Gradepay, 0) AS gradepay, ISNULL(a.elecbill, 0) AS elecbill, ISNULL(a.rd, 0) AS rd, ISNULL(a.panno, '') AS panno, b.adminunit, ISNULL(a.gpfiv,0) AS gpfiv, ISNULL(a.lic,0) AS lic, ISNULL(a.socded,0) AS sded, ISNULL(a.rdded,0) AS rdded,ISNULL(a.pftype,0) AS pftype,ISNULL(a.pranr,0) AS pranr,ISNULL(a.monthr,0) AS monthr, ISNULL(a.ruralall,0) AS ruralall   FROM         PMD_Pay_sal_mast AS a INNER JOIN pmd_salaryselect AS b ON a.idno = b.idno where " + qr + "");

                if (cl.ds.Tables[0].Rows.Count > 0)
                {

                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {

                        Response.Write(cl.ds.Tables[0].Rows[j][5].ToString());


                        stopdays = Convert.ToInt32(cl.ds.Tables[0].Rows[j]["stopsal"]);
                        attdays = Md - stopdays;

                        if (attdays.ToString() != "0")//stopsal
                        {
                            if (!(cl.ds.Tables[0].Rows[j]["ddoid"].ToString().Equals(System.DBNull.Value)))//ddocode
                            {
                                ddocode.Text = cl.ds.Tables[0].Rows[j]["ddoid"].ToString();
                            }
                            else
                            {
                                ddocode.Text = "0";
                            }

                            if (!(cl.ds.Tables[0].Rows[j][2].ToString().Equals(System.DBNull.Value)))//headid
                            {
                                headid.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                            }
                            else
                            {
                                headid.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][3].ToString().Equals(System.DBNull.Value)))//scaleid
                            {
                                scaleid.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                            }
                            else
                            {
                                scaleid.Text = "0";
                            }
                            ///payid
                            if (!(cl.ds.Tables[0].Rows[j][5].ToString().Equals(System.DBNull.Value)))//idno
                            {
                                idno.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                            }
                            else
                            {
                            }
                            if (!(cl.ds.Tables[0].Rows[j][6].ToString().Equals(System.DBNull.Value)))//gpfno
                            {
                                gpfno.Text = cl.ds.Tables[0].Rows[j][6].ToString();

                            }
                            else
                            {
                                gpfno.Text = "";
                            }
                            attendance.Text = attdays.ToString();
                            if (!(cl.ds.Tables[0].Rows[j][7].ToString().Equals(System.DBNull.Value)))//basicpay
                            {
                                basicpay.Text = basicsal(cl.ds.Tables[0].Rows[j][7].ToString(), attdays.ToString());

                            }
                            else
                            {
                                basicpay.Text = "0";
                            }

                            ///////gradepay
                            if (!(cl.ds.Tables[0].Rows[j][29].ToString().Equals(System.DBNull.Value)))//gradepay
                            {
                                // Gradepay.Text = Convert.ToString(((Convert.ToDouble(cl.ds.Tables[0].Rows[j][40].ToString()) / 30) * (Convert.ToDouble(cl.ds.Tables[0].Rows[j][8].ToString()))));
                                Gradepay.Text = basicsal(cl.ds.Tables[0].Rows[j][29].ToString(), attdays.ToString());

                            }
                            else
                            {
                                Gradepay.Text = "0";
                            }

                            if (!(cl.ds.Tables[0].Rows[j][7].ToString().Equals(System.DBNull.Value)))//npaall
                            {
                                npaall.Text = "0";
                            }


                            if (!(cl.ds.Tables[0].Rows[j][10].ToString().Equals(System.DBNull.Value)))//dapay
                            {

                                //dapay.Text =cl.ds.Tables[0].Rows[j][14].ToString();
                                //if (Convert.ToInt32(fmonth) < 6)
                                // {
                                //     dapay.Text = Convert.ToString(((Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text) + Convert.ToDouble(npaall.Text)) * 107) / 100);
                                // }
                                // else
                                // {
                                //     dapay.Text = Convert.ToString(((Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text) + Convert.ToDouble(npaall.Text)) * 113) / 100);
                                // }

                                if (Convert.ToInt32(fmonth) == 6 || Convert.ToInt32(fmonth) == 7 || Convert.ToInt32(fmonth) == 8 || Convert.ToInt32(fmonth) == 9 || Convert.ToInt32(fmonth) == 10 || Convert.ToInt32(fmonth) == 11 || Convert.ToInt32(fmonth) == 12)
                                {
                                    dapay.Text = Convert.ToString(((Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text) + Convert.ToDouble(npaall.Text)) * 125) / 100);
                                }
                                else
                                {
                                    dapay.Text = Convert.ToString(((Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text) + Convert.ToDouble(npaall.Text)) * 119) / 100);
                                }







                                Double y = Convert.ToDouble(dapay.Text);
                                int yintpart = (int)(y);
                                double ydecipart = y - yintpart;
                                if (ydecipart >= 0.50)
                                {
                                    y = yintpart + 1;
                                }
                                else
                                {
                                    y = yintpart;
                                }
                                dapay.Text = Convert.ToString(y);

                            }
                            else
                            {
                                dapay.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][8].ToString().Equals(System.DBNull.Value)))//hra
                            {
                                //hra.Text = cl.ds.Tables[0].Rows[j][15].ToString();                                
                                //hra.Text = Convert.ToString(((Convert.ToDouble(cl.ds.Tables[0].Rows[j][15].ToString()) / 30) * Convert.ToDouble(cl.ds.Tables[0].Rows[j][8].ToString())));
                                hra.Text = basicsal(cl.ds.Tables[0].Rows[j][8].ToString(), attdays.ToString());
                            }
                            else
                            {
                                hra.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][9].ToString().Equals(System.DBNull.Value)))//cca
                            {
                                //cca.Text =cl.ds.Tables[0].Rows[j][16].ToString();
                                //cca.Text = ((Convert.ToDouble(cl.ds.Tables[0].Columns["cca"].ColumnName.ToString()) / 30) * Convert.ToDouble(cl.ds.Tables[0].Columns["attendance"].ColumnName.ToString()));
                                //cca.Text = Convert.ToString(((Convert.ToDouble(cl.ds.Tables[0].Rows[j][16].ToString()) / 30) * Convert.ToDouble(cl.ds.Tables[0].Rows[j][8].ToString())));
                                cca.Text = basicsal(cl.ds.Tables[0].Rows[j][9].ToString(), attdays.ToString());
                            }
                            else
                            {
                                cca.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][10].ToString().Equals(System.DBNull.Value)))//perpay
                            {
                                perpay.Text = basicsal(cl.ds.Tables[0].Rows[j][10].ToString(), attdays.ToString());
                            }
                            else
                            {
                                perpay.Text = "0";
                            }

                            if (!(cl.ds.Tables[0].Rows[j][11].ToString().Equals(System.DBNull.Value)))//tpay
                            {
                                tpay.Text = basicsal(cl.ds.Tables[0].Rows[j][11].ToString(), attdays.ToString());
                            }
                            else
                            {
                                tpay.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][12].ToString().Equals(System.DBNull.Value)))//sppay
                            {
                                sppay.Text = basicsal(cl.ds.Tables[0].Rows[j][12].ToString(), attdays.ToString());
                            }
                            else
                            {
                                sppay.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][13].ToString().Equals(System.DBNull.Value)))//pensionpay
                            {
                                pensionpay.Text = basicsal(cl.ds.Tables[0].Rows[j][13].ToString(), attdays.ToString());

                            }
                            else
                            {
                                pensionpay.Text = "0";
                            }

                            if (!(cl.ds.Tables[0].Rows[j][14].ToString().Equals(System.DBNull.Value)))//gpf
                            {
                                gpf.Text = cl.ds.Tables[0].Rows[j][14].ToString();

                            }
                            else
                            {
                                gpf.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][15].ToString().Equals(System.DBNull.Value)))//gisi
                            {
                                gisi.Text = cl.ds.Tables[0].Rows[j][15].ToString();
                            }
                            else
                            {
                                gisi.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][16].ToString().Equals(System.DBNull.Value)))//giss
                            {
                                giss.Text = cl.ds.Tables[0].Rows[j][16].ToString();
                            }
                            else
                            {
                                giss.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][17].ToString().Equals(System.DBNull.Value)))//incometax
                            {
                                incometax.Text = cl.ds.Tables[0].Rows[j][17].ToString();
                            }
                            else
                            {
                                incometax.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][18].ToString().Equals(System.DBNull.Value)))//gvr
                            {
                                gvr.Text = cl.ds.Tables[0].Rows[j][18].ToString();
                            }
                            else
                            {
                                gvr.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][19].ToString().Equals(System.DBNull.Value)))//hrr
                            {
                                hrr.Text = cl.ds.Tables[0].Rows[j][19].ToString();
                            }
                            else
                            {
                                hrr.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][20].ToString().Equals(System.DBNull.Value)))//payded
                            {
                                payded.Text = cl.ds.Tables[0].Rows[j][20].ToString();

                            }
                            else
                            {
                                payded.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][21].ToString().Equals(System.DBNull.Value)))//Salded
                            {
                                salded.Text = cl.ds.Tables[0].Rows[j][21].ToString();

                            }
                            else
                            {
                                salded.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][22].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                remark.Text = cl.ds.Tables[0].Rows[j][22].ToString();

                            }
                            else
                            {
                                remark.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][30].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                elecbill.Text = cl.ds.Tables[0].Rows[j][30].ToString();

                            }
                            else
                            {
                                elecbill.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][31].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                Licrd.Text = cl.ds.Tables[0].Rows[j][31].ToString();

                            }
                            else
                            {
                                Licrd.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][32].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                PAN.Text = cl.ds.Tables[0].Rows[j][32].ToString();

                            }
                            else
                            {
                                PAN.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][33].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                adminunit.Text = cl.ds.Tables[0].Rows[j][33].ToString();

                            }
                            else
                            {

                                adminunit.Text = "";
                            }

                            if (!(cl.ds.Tables[0].Rows[j][34].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                gpfcf.Text = cl.ds.Tables[0].Rows[j][34].ToString();

                            }
                            else
                            {

                                gpfcf.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][35].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                lic.Text = cl.ds.Tables[0].Rows[j][35].ToString();

                            }
                            else
                            {

                                lic.Text = "";
                            }







                            if (!(cl.ds.Tables[0].Rows[j][36].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                socded.Text = cl.ds.Tables[0].Rows[j][36].ToString();

                            }
                            else
                            {

                                socded.Text = "";
                            }

                            if (!(cl.ds.Tables[0].Rows[j][37].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                rdded.Text = cl.ds.Tables[0].Rows[j][37].ToString();

                            }
                            else
                            {

                                rdded.Text = "";
                            }



                            if (!(cl.ds.Tables[0].Rows[j][38].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                pftype.Text = cl.ds.Tables[0].Rows[j][38].ToString();

                            }
                            else
                            {

                                pftype.Text = "";
                            }


                            if (!(cl.ds.Tables[0].Rows[j][39].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                pranr.Text = cl.ds.Tables[0].Rows[j][39].ToString();

                            }
                            else
                            {

                                pranr.Text = "";
                            }




                            if (!(cl.ds.Tables[0].Rows[j][40].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                monthr.Text = cl.ds.Tables[0].Rows[j][40].ToString();

                            }
                            else
                            {

                                monthr.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][40].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                monthr.Text = cl.ds.Tables[0].Rows[j][40].ToString();

                            }
                            else
                            {

                                monthr.Text = "";
                            }

                            if (!(cl.ds.Tables[0].Rows[j][41].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                ruralall.Text = cl.ds.Tables[0].Rows[j][41].ToString();

                            }
                            else
                            {

                                ruralall.Text = "";
                            }


                        }
                        else//copy else part
                        {
                            if (!(cl.ds.Tables[0].Rows[j]["ddoid"].ToString().Equals(System.DBNull.Value)))//ddocode
                            {
                                ddocode.Text = cl.ds.Tables[0].Rows[j]["ddoid"].ToString();
                            }
                            else
                            {
                                ddocode.Text = "0";
                            }

                            if (!(cl.ds.Tables[0].Rows[j][2].ToString().Equals(System.DBNull.Value)))//headid
                            {
                                headid.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                            }
                            else
                            {
                                headid.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][3].ToString().Equals(System.DBNull.Value)))//scaleid
                            {
                                scaleid.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                            }
                            else
                            {
                                scaleid.Text = "0";
                            }
                            ///payid
                            if (!(cl.ds.Tables[0].Rows[j][5].ToString().Equals(System.DBNull.Value)))//idno
                            {
                                idno.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                            }
                            else
                            {
                            }
                            if (!(cl.ds.Tables[0].Rows[j][6].ToString().Equals(System.DBNull.Value)))//gpfno
                            {
                                gpfno.Text = cl.ds.Tables[0].Rows[j][6].ToString();

                            }
                            else
                            {
                                gpfno.Text = "";
                            }
                            attendance.Text = "0";
                            /*if (!(cl.ds.Tables[0].Rows[j][7].ToString().Equals(System.DBNull.Value)))//attendance
                            {
                                attendance.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                            }
                            else
                            {
                                attendance.Text = "0";
                            }*/
                            basicpay.Text = "0";
                            Gradepay.Text = "0";
                            npaall.Text = "0";
                            dapay.Text = "0";
                            hra.Text = "0";
                            cca.Text = "0";
                            perpay.Text = "0";
                            tpay.Text = "0";
                            sppay.Text = "0";
                            pensionpay.Text = "0";
                            gpf.Text = "0";
                            gisi.Text = "0";
                            giss.Text = "0";
                            incometax.Text = "0";
                            gvr.Text = "0";
                            hrr.Text = "0";
                            payded.Text = "0";
                            salded.Text = "0";
                            remark.Text = "";
                            elecbill.Text = "0";
                            Licrd.Text = "0";
                            gpfcf.Text = "0";
                            lic.Text = "0";
                            socded.Text = "0";
                            rdded.Text = "0";
                            pftype.Text = "0";

                        }
                        try
                        {
                            datafill();
                            maintainloan();
                            Earnupdate();
                            // loanupdate();
                            Label1.Visible = true;
                            Label1.ForeColor = System.Drawing.Color.Red;
                            count = j + 1;//Count Record..
                            Label1.Text = "Successfully Salary Processed For  " + count + "  Employees";



                            mesg1.Visible = false;//copy
                            Button1.Visible = false;//copy
                            GRLink.Text = "Print Report";
                            GRLink.Visible = true;
                        }
                        catch (Exception eadded)
                        {
                            GRLink.Visible = false;
                            mesg.Visible = true;
                            mesg.Text = ("Error :" + eadded.Message);
                            //mesg.Text = "Some error in value";
                        }
                        finally
                        {
                            if (ConnectionState.Open == cl.upcon.State)
                            {
                                cl.upcon.Close();
                            }
                        }


                    }


                }//END OF third IF
                else
                {
                    this.mesg.Text = "No data To generate salary... ";
                }

            }///END OF FIRST IF
            else
            {
                //Response.Write("Please Select Proper one... ");
                this.mesg.Text = "Please Select Proper one... ";
            }
        }


        public void datafill()
        {
            try
            {
                if (ConnectionState.Closed == cl.upcon.State)
                {
                    cl.upcon.Open();
                    SqlCommand cmd = new SqlCommand("pmdcalculatedsalaryenrty1", cl.upcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ddocode", SqlDbType.Int, 4).Value = Convert.ToInt32(ddocode.Text); //Request.QueryString["idno"];

                    cmd.Parameters.Add("@headid", SqlDbType.Int, 4).Value = Convert.ToInt32(headid.Text.Trim());
                    cmd.Parameters.Add("@scaleid", SqlDbType.Int, 4).Value = Convert.ToInt32(scaleid.Text.Trim());
                    cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(idno.Text.Trim());
                    cmd.Parameters.Add("@pan", SqlDbType.VarChar, 20).Value = PAN.Text.ToString();
                    cmd.Parameters.Add("@gpfno", SqlDbType.VarChar, 50).Value = gpfno.Text.Replace("\'", "\'\'").Trim();
                    cmd.Parameters.Add("@attendance", SqlDbType.Int, 4).Value = attdays;
                    cmd.Parameters.Add("@basicpay", SqlDbType.Float, 8).Value = Convert.ToDouble(basicpay.Text.Trim());
                    cmd.Parameters.Add("@Gradepay", SqlDbType.Float, 8).Value = Convert.ToDouble(Gradepay.Text.Trim());
                    cmd.Parameters.Add("@npaall", SqlDbType.Float, 8).Value = Convert.ToDouble(npaall.Text.Trim());
                    cmd.Parameters.Add("@ebill", SqlDbType.Float, 8).Value = Convert.ToDouble(elecbill.Text.Trim());
                    //cmd.Parameters.Add("@rd", SqlDbType.Float, 8).Value = Convert.ToDouble(Licrd.Text.Trim());

                    cmd.Parameters.Add("@licrd", SqlDbType.Float, 8).Value = Convert.ToDouble(Licrd.Text.Trim());


                    cmd.Parameters.Add("@dapay", SqlDbType.Float, 8).Value = Convert.ToDouble(dapay.Text.Trim());
                    cmd.Parameters.Add("@hra", SqlDbType.Float, 8).Value = Convert.ToDouble(hra.Text.Trim());
                    cmd.Parameters.Add("@cca", SqlDbType.Float, 8).Value = Convert.ToDouble(cca.Text.Trim());
                    cmd.Parameters.Add("@perpay", SqlDbType.Float, 8).Value = Convert.ToDouble(perpay.Text.Trim());
                    cmd.Parameters.Add("@tpay", SqlDbType.Float, 8).Value = Convert.ToDouble(tpay.Text.Trim());
                    cmd.Parameters.Add("@sppay", SqlDbType.Float, 8).Value = Convert.ToDouble(sppay.Text.Trim());
                    cmd.Parameters.Add("@pensionpay", SqlDbType.Float, 8).Value = Convert.ToDouble(pensionpay.Text.Trim());
                    cmd.Parameters.Add("@gpf", SqlDbType.Float, 8).Value = Convert.ToDouble(gpf.Text.Trim());
                    cmd.Parameters.Add("@gisi", SqlDbType.Float, 8).Value = Convert.ToDouble(gisi.Text.Trim());
                    cmd.Parameters.Add("@giss", SqlDbType.Float, 8).Value = Convert.ToDouble(giss.Text.Trim());
                    cmd.Parameters.Add("@incometax", SqlDbType.Float, 8).Value = Convert.ToDouble(incometax.Text.Trim());
                    cmd.Parameters.Add("@gvr", SqlDbType.Float, 8).Value = Convert.ToDouble(gvr.Text.Trim());
                    cmd.Parameters.Add("@hrr", SqlDbType.Float, 8).Value = Convert.ToDouble(hrr.Text.Trim());
                    cmd.Parameters.Add("@payded", SqlDbType.Float, 8).Value = Convert.ToDouble(payded.Text.Trim());
                    cmd.Parameters.Add("@salded", SqlDbType.Float, 8).Value = Convert.ToDouble(salded.Text.Trim());
                    cmd.Parameters.Add("@Syear", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["year"]);
                    cmd.Parameters.Add("@SMonth", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["Month"]);
                    cmd.Parameters.Add("@salarycreatorid", SqlDbType.Int, 4).Value = Convert.ToInt32(Uidt.Text);// 1;//

                    if (adminunit.Text.Trim() != "")
                    {
                        cmd.Parameters.Add("@adminunit", SqlDbType.Int, 4).Value = Convert.ToInt32(adminunit.Text.Trim());
                    }
                    else
                    {
                        cmd.Parameters.Add("@adminunit", SqlDbType.Int, 4).Value = DBNull.Value;

                    }


                    cmd.Parameters.Add("@salarycrdate", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                    cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                    cmd.Parameters.Add("@remark", SqlDbType.VarChar, 100).Value = remark.Text.Replace("\'", "\'\'").Trim();
                    cmd.Parameters.Add("@gpfiv", SqlDbType.Int, 4).Value = Convert.ToInt32(gpfcf.Text);
                    cmd.Parameters.Add("@lic", SqlDbType.Int, 4).Value = Convert.ToInt32(lic.Text);
                    cmd.Parameters.Add("@socded", SqlDbType.Int, 4).Value = Convert.ToInt32(socded.Text);
                    cmd.Parameters.Add("@rdded", SqlDbType.Int, 4).Value = Convert.ToInt32(rdded.Text);
                    cmd.Parameters.Add("@pranr", SqlDbType.Float, 4).Value = Convert.ToDouble(pranr.Text);
                    cmd.Parameters.Add("@monthr", SqlDbType.NVarChar, 200).Value = (monthr.Text);
                    cmd.Parameters.Add("@ruralall", SqlDbType.Int, 4).Value = (ruralall.Text);
                    cmd.Parameters.Add("@pftype", SqlDbType.Int, 4).Value = Convert.ToInt32(pftype.Text);






                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Gold;
                        Label1.Text = "Added Successfully";
                        //GRLink.Visible = true;
                    }
                }

            }
            catch (Exception e)
            {
                mesg.Visible = true;
                mesg.Text = ("Error :" + e.Message);
                //mesg.Text = "Some error in value";
            }
            finally
            {
                if (ConnectionState.Open == cl.upcon.State)
                {
                    cl.upcon.Close();
                }
            }
        }
        public void Earnupdate()
        {
            //SELECT     isnull(a.lid,0) as lid,isnull(a.idno,0) as idno,  isnull(a.litemid,0) as litemid,  isnull(a.intamt,0) as intamt, b.litemname FROM         pmd_pay_loan_entry  as a RIGHT OUTER JOIN pay_optloan as b ON a.litemid = b.litemid
            //////////////////////////////////
            cl.dsE = cl.DataFillE("SELECT     optearid, optearname FROM pay_optearmast ORDER BY optearid");
            int l;
            if (cl.dsE.Tables[0].Rows.Count > 0)
            {
                for (l = 0; l <= cl.dsE.Tables[0].Rows.Count - 1; l++)
                {
                    litemid.Text = cl.dsE.Tables[0].Rows[l][1].ToString();
                    cl.dsE1 = cl.DataFillE1("SELECT isnull(b.idno,0) as idno, isnull(b.optearamt,0) as optearamt FROM  pay_optearmast AS a LEFT OUTER JOIN pmd_pay_opt_earning AS b ON a.optearid = b.optearid WHERE a.optearname='" + litemid.Text + "'");
                    int c;
                    if (cl.dsE1.Tables[0].Rows.Count > 0)
                    {
                        for (c = 0; c <= cl.dsE1.Tables[0].Rows.Count - 1; c++)
                        {
                            if (cl.dsE1.Tables[0].Rows[c][0].ToString() == idno.Text)
                            {

                                string optearn;
                                optearn = basicsal(cl.dsE1.Tables[0].Rows[c][1].ToString(), attdays.ToString());

                                //if (Convert.ToInt32(idno.Text) == 33559 || Convert.ToInt32(idno.Text)==32462)
                                //{

                                //    Response.Write(idno.Text + "---------" +"errrrrrrr"+ cl.dsE1.Tables[0].Rows[c][1].ToString()+"attttttttt"+attdays.ToString() + litemid.Text + "aaaaaaaa" + optearn + "bbbbbbb");
                                ////Response.Write(optearn);
                                //}

                                string str = "update pmdcalulatedsalary set " + litemid.Text.Trim() + "=" + optearn + " where idno=" + idno.Text + "";
                                cl.cmd = cl.InsertDB("update pmdcalulatedsalary set " + litemid.Text.Trim() + "=" + Convert.ToInt32(optearn.Trim()) + " where idno=" + idno.Text + "");
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }


        }


        protected void GRLink_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../payrole/SaldetH.aspx");
            if (GRLink.Text == "Print Report")
            {
                Response.Redirect("../pmdpayrole/pmdPayRopt.aspx");
            }
            else
            {
                Response.Redirect("../pmdpayrole/pmdGenerateBill.aspx");
            }
        }

        private int getdays(int Mday)
        {
            int getdays = 0;
            if (Mday == 4 || Mday == 6 || Mday == 8 || Mday == 9 || Mday == 11)
            {
                getdays = 30;
                return getdays;
            }
            else if (Mday == 2)
            {
                getdays = 28;
                return getdays;
            }
            else if (Mday == 1 || Mday == 3 || Mday == 5 || Mday == 7 || Mday == 10 || Mday == 12)
            {
                getdays = 31;
                return getdays;
            }
            return getdays;
        }

        ///////////Earnings

        private string basicsal(string bac, string att)
        {

            string basicsal = "0";
            Double y = Convert.ToDouble(bac);
            int yintpart = (int)(y);
            double ydecipart = y - yintpart;
            if (ydecipart >= 0.50)
            {
                y = yintpart + 1;
            }
            else
            {
                y = yintpart;
            }
            int Md;
            Md = System.DateTime.DaysInMonth(Convert.ToInt32(fyear), Convert.ToInt32(fmonth));
            // Md = getdays(Convert.ToInt32(fmonth));
            if (Md == Convert.ToInt32(attendance.Text))
            {
                basicsal = Convert.ToString(y);
            }
            else
            {
                basicsal = Convert.ToString(((y) / Md) * (Convert.ToDouble(att)));
                int intpart = (int)(Convert.ToDouble(basicsal));
                double decipart = Convert.ToDouble(basicsal) - intpart;
                if (decipart >= 0.50)
                {
                    basicsal = Convert.ToString(intpart + 1);
                }
                else
                {
                    basicsal = Convert.ToString(intpart);
                }
            }
            return basicsal;

        }
        protected void Button1_Click(object sender, EventArgs e)//copy this funtion
        {
            int year, ddoid, month, unit;
            year = Convert.ToInt32(Request.QueryString["year"]);
            ddoid = Convert.ToInt32(Request.QueryString["DDOID"]);
            month = Convert.ToInt32(Request.QueryString["Month"]);
            if (Request.QueryString["adminunit"] != "0")
            {
                unit = Convert.ToInt32(Request.QueryString["adminunit"]);
                adunt = 1;
                cmd = new SqlCommand("Delete from pmdcalulatedsalary where ddoid=" + ddoid + " and Syear=" + year + " and Smonth=" + month + " and adminunit=" + unit + "", cl.upcon);
            }
            else
            {
                cmd = new SqlCommand("Delete from pmdcalulatedsalary where ddoid=" + ddoid + " and Syear=" + year + " and Smonth=" + month + "", cl.upcon);
                adunt = 0;
            }
            updatepaidInst();
            try
            {
                cl.upcon.Open();
                cmd.ExecuteNonQuery();

                mesg1.Text = "Deleted Successfully";
                GRLink.Visible = true;
                GRLink.Text = "Bill Reprocess/Recalculate";
                Button1.Visible = false;

            }
            catch (Exception ex)
            {
                mesg1.Text = "Delete Operation Failed";
            }

            finally
            { cl.upcon.Close(); }
        }

        protected void maintainloan()
        {
            int idnum = Convert.ToInt32(idno.Text.Trim());
            string note = "";

            cl.upcon.Open();
            cl.dsloan = cl.DataFillloan("Select * from pmd_pay_loan_entry inner join pay_optloan on pmd_pay_loan_entry.litemid=pay_optloan.litemid where idno=" + idnum + "");
            if (cl.dsloan.Tables[0].Rows.Count > 0)
            {
                int i, Instpaid, totinst, Instamt;
                for (i = 0; i <= cl.dsloan.Tables[0].Rows.Count - 1; i++)
                {
                    //cl.upcon.Open();
                    int loanid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i][3]);
                    string loantype = cl.dsloan.Tables[0].Rows[i][14].ToString();
                    string dedwith = cl.dsloan.Tables[0].Rows[i][12].ToString();
                    Instpaid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]);
                    totinst = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["linst"]);


                    if (Instpaid <= totinst)
                    {
                        if ((dedwith.Equals("F") && Instpaid == 0) || (dedwith.Equals("L") && totinst - 1 == Instpaid))
                        {
                            Instamt = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i][8]) + Convert.ToInt32(cl.dsloan.Tables[0].Rows[i][10]);
                        }
                        else
                        {

                            Instamt = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i][8]);
                        }
                        Instpaid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]) + 1;
                        //currinst = Instpaid;

                        if (note == "")
                        {

                            note = note + loantype + "-" + " " + Convert.ToString(Instpaid) + "/" + Convert.ToString(totinst);
                        }

                        else
                        {

                            note = note + ", " + loantype + "-" + " " + Convert.ToString(Instpaid) + "/" + Convert.ToString(totinst);

                        }



                    }
                    else
                    {
                        Instamt = 0;

                    }


                    //SqlCommand cmd = new SqlCommand("update pmdcalulatedsalary set " + loantype + " = '" + Instamt + "' , remarks=('"+loantype+"-"+rem+"') where idno=" + idnum + " and Syear=" + fyear + " and Smonth=" + fmonth + "", cl.upcon);
                    SqlCommand cmd = new SqlCommand("update pmdcalulatedsalary set " + loantype + " = '" + Instamt + "'  where idno=" + idnum + " and Syear=" + fyear + " and Smonth=" + fmonth + "", cl.upcon);
                    cmd.ExecuteNonQuery();

                    //SqlCommand cmd =  new SqlCommand("update pmdcalulatedsalary set "+loantype+" = '"+Instamt+"' where idno="+idnum+" and Syear="+fyear+" and Smonth="+fmonth+"",cl.upcon);
                    SqlCommand cmd1 = new SqlCommand("update pmd_pay_loan_entry set nlinstpaid = " + Instpaid + " where idno=" + idnum + " and litemid=" + loanid + "", cl.upcon);
                    cmd1.ExecuteNonQuery();

                    //cl.upcon.Close();

                }

                note = "Note:-" + note;
                SqlCommand cmd2 = new SqlCommand("update pmdcalulatedsalary set note=('" + note + "')  where idno=" + idnum + " and Syear=" + fyear + " and Smonth=" + fmonth + "", cl.upcon);
                cmd2.ExecuteNonQuery();

                cl.upcon.Close();

            }


        }
        protected void updatepaidInst()
        {
            if (Request.QueryString["DDOID"] != "ALL")
            {
                if (Request.QueryString["DDOID"].Length == 1)
                {
                    q1 = "b.ddoid=" + Request.QueryString["DDOID"] + "";
                }
                else
                {
                    q1 = "b.ddoid like '%" + Request.QueryString["DDOID"] + "%' ";
                }
            }
            //******************SectionID****************

            //******************HeadID****************
            if (Request.QueryString["adminunit"] != "ALL")
            {
                if (Request.QueryString["adminunit"].Length == 1)
                {
                    q3 = "b.adminunit=" + Request.QueryString["adminunit"] + "";
                }
                else
                {
                    q3 = "b.adminunit like '%" + Request.QueryString["adminunit"] + "%' ";
                }
            }
            else
            {
                q3 = "b.adminunit like '%'";
            }
            if (Request.QueryString["adminunit"] == "0")
            {
                qr = q1 + " and " + "b.adminunit is null";
            }
            else
            {

                qr = q1 + " and " + q3;
            }
            cl.ds = cl.DataFill("SELECT     a.stopsal, b.ddoid, a.headid, a.scaleid, a.payid, a.idno, a.gpfno, ISNULL(a.basicpay, 0) AS basicpay, ISNULL(a.Ehra, 0) AS Ehra, ISNULL(a.cca, 0) AS cca,   ISNULL(a.perpay, 0) AS perpay, ISNULL(a.tpay, 0) AS tpay, ISNULL(a.sppay, 0) AS sppay, ISNULL(a.pensionpay, 0) AS pensionpay, ISNULL(a.gpf, 0) AS gpf,    ISNULL(a.gisi, 0) AS gisi, ISNULL(a.giss, 0) AS giss, ISNULL(a.incometax, 0) AS incometax, ISNULL(a.gvr, 0) AS gvr, ISNULL(a.hrr, 0) AS hrr, ISNULL(a.payded, 0)  AS payded, ISNULL(a.salded, 0) AS salded, ISNULL(a.remarks, 'XX') AS remarks, a.empltypeid, a.bankid, a.bankaccno, a.incdueon, a.lastincdate, a.incstatus,  ISNULL(a.Gradepay, 0) AS gradepay, ISNULL(a.elecbill, 0) AS elecbill, ISNULL(a.rd, 0) AS rd, ISNULL(a.panno, '') AS panno, b.adminunit FROM         PMD_Pay_sal_mast AS a INNER JOIN pmd_salaryselect AS b ON a.idno = b.idno  where " + qr + "");

            for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            {
                if (!(cl.ds.Tables[0].Rows[j][5].ToString().Equals(System.DBNull.Value)))//idno
                {
                    idno.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                }
                else
                {
                }
                int idnum = Convert.ToInt32(idno.Text.Trim());

                cl.dsloan = cl.DataFillloan("Select * from pmd_pay_loan_entry inner join pay_optloan on pmd_pay_loan_entry.litemid=pay_optloan.litemid where idno=" + idnum + "");
                if (cl.dsloan.Tables[0].Rows.Count > 0)
                {
                    int i, paid;
                    for (i = 0; i <= cl.dsloan.Tables[0].Rows.Count - 1; i++)
                    {
                        cl.upcon.Open();
                        string loantype = cl.dsloan.Tables[0].Rows[i][13].ToString();
                        int loanamt = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i][8]);
                        int loanid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i][3]);
                        paid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]);
                        int totalinst = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["linst"]);
                        if (paid == 0)
                        {
                            paid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]);
                        }
                        else
                        {
                            if (paid != totalinst)
                            {
                                paid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]) - 1;
                            }
                            else
                            {
                                paid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]);
                            }
                        }
                        SqlCommand cmd1 = new SqlCommand("update pmd_pay_loan_entry set nlinstpaid = " + paid + " where idno=" + idnum + " and litemid=" + loanid + "", cl.upcon);
                        cmd1.ExecuteNonQuery();
                        cl.upcon.Close();
                    }

                }
            }



        }
    }
}