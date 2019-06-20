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

namespace NewWebApp.payrole
{
    public partial class CALSAL : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q3, qr;
        string fyear, fmonth, npa;
        int Md, j, stopdays, attdays;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                Uidt.Text = (string)Session["iduser"];
                if ((string)Session["ddopid"] != null)
                {
                    finalsal();
                }

            }

        }

        public void finalsal()
        {
            cl.dstimech = cl.Dtimech("select datepart(yyyy,getdate()) as dY,datepart(mm,getdate()) as dM");

            fyear = Request.QueryString["year"];
            fmonth = Request.QueryString["Month"];

            // Md = getdays(Convert.ToInt32(fmonth));
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
                    // q1 = "b.ddoid like '%" + Request.QueryString["DDOID"] + "%' ";
                }
            }
            //******************SectionID****************

            //******************HeadID****************
            if (Request.QueryString["HeadID"] != "ALL")
            {
                if (Request.QueryString["HeadID"].Length == 1)
                {
                    q3 = "a.headid=" + Request.QueryString["HeadID"] + "";
                }
                else
                {
                    q3 = "a.headid like '%" + Request.QueryString["HeadID"] + "%' ";
                }
            }
            else
            {
                q3 = "a.headid like '%'";
            }
            qr = q1 + " and " + q3;

            cl.dshospitalid = cl.Dthospitalid("select distinct idno from calulatedsalary  where ddoid= " + (string)Session["ddopid"] + " and Smonth=" + fmonth + " and Syear=" + fyear + "");
            string salarySr = "select isnull(max(Smonth),0)as maxmonth from calulatedsalary where (ddoid=" + (string)Session["ddopid"] + ") and Syear in ( select isnull(max(Syear),0)as Syear  from calulatedsalary as a where (ddoid=" + (string)Session["ddopid"] + "))";
            cl.ds = cl.DataFill(salarySr);

            int maxmonth = Convert.ToInt32(cl.ds.Tables[0].Rows[0][0]);

            int month = Convert.ToInt32(fmonth);
            if (cl.dshospitalid.Tables[0].Rows.Count > 0)
            {
                if (maxmonth == month)
                {
                    this.mesg.Text = "The Salary Of " + (string)Session["ddoname"] + " for the month " + fmonth + "  and year " + fyear + " already Processed. ";//copy below 2 lines,add label and delete button in design page
                    this.mesg1.Text = "Do you want to delete it for Reprocess.";
                    GRLink.Visible = false;
                }
                else
                {
                    //this.mesg.Text = "The Salary Of " + (string)Session["ddoname"] + " for the month " + fmonth + "  and year " + fyear + " cannot be Reprocessed. ";//copy below 2 lines,add label and delete button in design page

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
            if (Request.QueryString["year"] != "" && Request.QueryString["Month"] != "")
            {
                cl.ds = cl.DataFill("SELECT     a.stopsal, b.ddoid, a.headid, a.scaleid, a.payid, a.idno, a.gpfno, isnull(a.basicpay,0) as basicpay, isnull(a.Ehra,0) as Ehra ,isnull(a.cca,0)as cca,isnull(a.perpay,0) as perpay ,isnull(a.tpay,0) as tpay ,isnull(a.sppay,0) as sppay ,isnull(a.pensionpay,0) as pensionpay,isnull(a.gpf,0) as gpf ,isnull(a.gisi,0) as gisi ,isnull(a.giss,0) as giss  ,isnull(a.incometax,0) as incometax ,isnull(a.gvr,0) as gvr ,isnull(a.hrr,0) as hrr  ,isnull(a.payded,0) as payded,isnull(a.salded,0) as salded ,isnull(a.remarks,'XX') as remarks, a.empltypeid,  a.bankid, a.bankaccno, a.incdueon, a.lastincdate, a.incstatus, isnull(a.gradepay,0) as gradepay,isnull(a.elecbill,0)as elecbill,isnull(a.rd,0)as rd ,isnull(panno,'')as panno FROM  Pay_sal_mast AS a INNER JOIN salaryselect AS b ON a.idno = b.idno  where " + qr + "");

                if (cl.ds.Tables[0].Rows.Count > 0)
                {

                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {

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
                                Gradepay.Text = basicsal(cl.ds.Tables[0].Rows[j][29].ToString(), attdays.ToString());

                            }
                            else
                            {
                                Gradepay.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][7].ToString().Equals(System.DBNull.Value)))//npaall
                            {
                                if (Convert.ToInt32(Gradepay.Text) != 0)
                                {

                                    (npaall.Text) = (Gradepay.Text);

                                    Gradepay.Text = "0";
                                }
                                else
                                {
                                    npaall.Text = "0";

                                }



                                //Double y;
                                //y = (Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text)) / 4;
                                //int yintpart = (int)(y);
                                //double ydecipart = y - yintpart;
                                //if (ydecipart >= 0.50)
                                //{
                                //    y = yintpart + 1;
                                //}
                                //else
                                //{
                                //    y = yintpart;
                                //}
                                //npa = Convert.ToString(y);
                                //npaall.Text = npa;

                            }
                            else
                            {
                                npaall.Text = "0";
                            }


                            //if (Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text) + Convert.ToDouble(npaall.Text) > 85000)
                            //{
                            //    npaall.Text = Convert.ToString(85000 - (Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text)));
                            //}


                            if (!(cl.ds.Tables[0].Rows[j][10].ToString().Equals(System.DBNull.Value)))//dapay
                            {

                                if (Convert.ToInt32(fmonth) == 6 || Convert.ToInt32(fmonth) == 7 || Convert.ToInt32(fmonth) == 8 || Convert.ToInt32(fmonth) == 9 || Convert.ToInt32(fmonth) == 10 || Convert.ToInt32(fmonth) == 11 || Convert.ToInt32(fmonth) == 12)
                                {
                                    //dapay.Text = Convert.ToString(((Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text) + Convert.ToDouble(npaall.Text)) * 2) / 100);

                                    dapay.Text = Convert.ToString(((Convert.ToDouble(basicpay.Text) + Convert.ToDouble(npaall.Text)) * 2) / 100);
                                }
                                else
                                {
                                    //dapay.Text = Convert.ToString(((Convert.ToDouble(basicpay.Text) + Convert.ToDouble(Gradepay.Text) + Convert.ToDouble(npaall.Text)) * 2) / 100);


                                    dapay.Text = Convert.ToString(((Convert.ToDouble(basicpay.Text) + Convert.ToDouble(npaall.Text)) * 2) / 100);
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
                                hra.Text = basicsal(cl.ds.Tables[0].Rows[j][8].ToString(), attdays.ToString());
                            }
                            else
                            {
                                hra.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][9].ToString().Equals(System.DBNull.Value)))//cca
                            {
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

                            if (!(cl.ds.Tables[0].Rows[j][14].ToString().Equals(System.DBNull.Value)))//gpfadv
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
                            /*if (!(cl.ds.Tables[0].Rows[j][23].ToString().Equals(System.DBNull.Value)))//Salded
                            {
                                salded.Text = cl.ds.Tables[0].Rows[j][23].ToString();

                            }
                            else
                            {
                                salded.Text = "0";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][24].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                remark.Text = cl.ds.Tables[0].Rows[j][24].ToString();

                            }
                            else
                            {
                                remark.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][32].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                elecbill.Text = cl.ds.Tables[0].Rows[j][32].ToString();

                            }
                            else
                            {
                                elecbill.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][33].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                Licrd.Text = cl.ds.Tables[0].Rows[j][33].ToString();

                            }
                            else
                            {
                                Licrd.Text = "";
                            }
                            if (!(cl.ds.Tables[0].Rows[j][34].ToString().Equals(System.DBNull.Value)))//remark
                            {
                                PAN.Text = cl.ds.Tables[0].Rows[j][34].ToString();

                            }
                            else
                            {
                                PAN.Text = "";
                            }*/

                        }
                        try
                        {
                            datafill();
                            maintainloan();
                            Earnupdate();
                            // loanupdate();
                            Label1.Visible = true;
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Text = "Salary updated / Added Successfully";
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

        public void maxpice()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(empsalid),0)+ 1 FROM calulatedsalary");
            ME.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void datafill()
        {
            try
            {
                if (ConnectionState.Closed == cl.upcon.State)
                {
                    cl.upcon.Open();



                    SqlCommand cmd = new SqlCommand("calculatedsalaryenrty1", cl.upcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //npaall.Text= Gradepay.Text;
                    // Gradepay.Text = "0";
                    cmd.Parameters.Add("@ddocode", SqlDbType.Int, 4).Value = Convert.ToInt32(ddocode.Text); //Request.QueryString["idno"];

                    cmd.Parameters.Add("@headid", SqlDbType.Int, 4).Value = Convert.ToInt32(headid.Text.Trim());
                    cmd.Parameters.Add("@scaleid", SqlDbType.Int, 4).Value = Convert.ToInt32(scaleid.Text.Trim());
                    cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(idno.Text.Trim());
                    cmd.Parameters.Add("@pan", SqlDbType.VarChar, 20).Value = PAN.Text.ToString();
                    cmd.Parameters.Add("@gpfno", SqlDbType.VarChar, 50).Value = gpfno.Text.Replace("\'", "\'\'").Trim();
                    cmd.Parameters.Add("@attendance", SqlDbType.Int, 4).Value = attdays;
                    cmd.Parameters.Add("@basicpay", SqlDbType.Float, 8).Value = Convert.ToDouble(basicpay.Text.Trim());
                    cmd.Parameters.Add("@npaall", SqlDbType.Float, 8).Value = Convert.ToDouble(npaall.Text.Trim());
                    cmd.Parameters.Add("@Gradepay", SqlDbType.Float, 8).Value = Convert.ToDouble(Gradepay.Text.Trim());
                    //cmd.Parameters.Add("@Gradepay", SqlDbType.Float, 8).Value = Convert.ToDouble(Gradepay.Text.Trim());
                    //cmd.Parameters.Add("@npaall", SqlDbType.Float, 8).Value = Convert.ToDouble(npaall.Text.Trim());



                    cmd.Parameters.Add("@ebill", SqlDbType.Float, 8).Value = Convert.ToDouble(elecbill.Text.Trim());
                    cmd.Parameters.Add("@rd", SqlDbType.Float, 8).Value = Convert.ToDouble(Licrd.Text.Trim());
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
                    cmd.Parameters.Add("@salarycrdate", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                    cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                    cmd.Parameters.Add("@remark", SqlDbType.VarChar, 100).Value = remark.Text.Replace("\'", "\'\'").Trim();

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
            //SELECT     isnull(a.lid,0) as lid,isnull(a.idno,0) as idno,  isnull(a.litemid,0) as litemid,  isnull(a.intamt,0) as intamt, b.litemname FROM         pay_loan_entry  as a RIGHT OUTER JOIN pay_optloan as b ON a.litemid = b.litemid
            //////////////////////////////////
            cl.dsE = cl.DataFillE("SELECT     optearid, optearname FROM pay_optearmast ORDER BY optearid");
            int l;
            if (cl.dsE.Tables[0].Rows.Count > 0)
            {
                for (l = 0; l <= cl.dsE.Tables[0].Rows.Count - 1; l++)
                {
                    litemid.Text = cl.dsE.Tables[0].Rows[l][1].ToString();
                    cl.dsE1 = cl.DataFillE1("SELECT isnull(b.idno,0) as idno, isnull(b.optearamt,0) as optearamt FROM  pay_optearmast AS a LEFT OUTER JOIN pay_opt_earning AS b ON a.optearid = b.optearid WHERE a.optearname='" + litemid.Text + "'");
                    int c;
                    if (cl.dsE1.Tables[0].Rows.Count > 0)
                    {
                        for (c = 0; c <= cl.dsE1.Tables[0].Rows.Count - 1; c++)
                        {
                            if (cl.dsE1.Tables[0].Rows[c][0].ToString() == idno.Text)
                            {
                                string optearn;
                                optearn = basicsal(cl.dsE1.Tables[0].Rows[c][1].ToString(), attdays.ToString());



                                string str = "update calulatedsalary set " + litemid.Text.Trim() + "=" + optearn + " where idno=" + idno.Text + "";
                                cl.cmd = cl.InsertDB("update calulatedsalary set " + litemid.Text.Trim() + "=" + Convert.ToInt32(optearn.Trim()) + " where idno=" + idno.Text + "");
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }


        }
        /*public void loanupdate()
        {
            //SELECT     isnull(a.lid,0) as lid,isnull(a.idno,0) as idno,  isnull(a.litemid,0) as litemid,  isnull(a.intamt,0) as intamt, b.litemname FROM         pay_loan_entry  as a RIGHT OUTER JOIN pay_optloan as b ON a.litemid = b.litemid
            //////////////////////////////////
            cl.dsD = cl.DataFillD("SELECT litemname, litemid FROM pay_optloan  where litemid<>0 ORDER BY litemid");
            int l;
            if (cl.dsD.Tables[0].Rows.Count > 0)
            {

                for (l = 0; l <= cl.dsD.Tables[0].Rows.Count - 1; l++)
                {
                    litemid.Text=cl.dsD.Tables[0].Rows[l][0].ToString();
                    cl.dsD1 = cl.DataFillD1("SELECT isnull(a.idno,0) as idno,isnull(a.intamt,0) as intamt,a.nlinstpaid FROM pay_loan_entry  as a RIGHT OUTER JOIN pay_optloan as b ON a.litemid = b.litemid WHERE b.litemname ='" + litemid.Text + "'");
                    int c,paid;
                
                    if (cl.dsD1.Tables[0].Rows.Count > 0)
                    {
                            for (c = 0; c <= cl.dsD1.Tables[0].Rows.Count - 1; c++)
                            {
                             paid = Convert.ToInt32(cl.dsD1.Tables[0].Rows[c][2]) + 1;
                             if (cl.dsD1.Tables[0].Rows[c][0].ToString()==idno.Text)
                             {
                                 // string str = "update calulatedsalary set " + litemid.Text.Trim() + "=" + cl.ds.Tables[0].Rows[c][1].ToString() + " where idno=" + idno.Text + "";
                                 cl.cmd = cl.InsertDB("update calulatedsalary set " + litemid.Text.Trim() + "=" + cl.dsD1.Tables[0].Rows[c][1].ToString() + " where idno=" + idno.Text + "");
                                 cl.cmd1 = cl.InsertDB("Update pay_loan_entry set nlinstpaid = paid where idno=" + idno.Text + "");
                             }
                             else
                             {
                             }
                             }
                    }
                }
            }    
    
        }*/

        public void loan()
        {
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            ////////////////////////////////////
            //////////////////////////////////////calculating other earnings
            /////////////////////////////////////
            //////////cl.ds1 = cl.DataFill2("SELECT optearname, optearid FROM pay_optearmast order by optearid");
            //////////int k;
            //////////if (cl.ds1.Tables[0].Rows.Count > 0)
            //////////{
            //////////    for (k = 0; k <= cl.ds1.Tables[0].Rows.Count - 1; k++)
            //////////    {
            //////////        optearid.Text = cl.ds.Tables[0].Rows[j][1].ToString();//isnull(sum( pay_loan_entry.intamt),0)
            //////////        cl.ds1 = cl.DataFill2("SELECT  isnull(sum(optearamt),0) as optearamt  FROM pay_opt_earning where idno=" + idno.Text + " and optearid=" + optearid.Text + "");
            //////////        if (cl.ds1.Tables[0].Rows.Count > 0)
            //////////        {
            //////////            if (!(cl.ds.Tables[0].Rows[j][0].ToString().Equals(System.DBNull.Value)))//othall1
            //////////            {
            //////////                //rs("othall1.Text ="0";
            //////////            }
            //////////            else
            //////////            {
            //////////            }

            //////////        }
            //////////    }
            //////////    //////////////////////////
            //////////    ////////////////////////////Edn other Earnings
            //////////    ///////////////////////////

            //**************/////////
            //**************/////////Main Deduction
            //**************/////////
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            ////////////////////////////////////calculating other Deduction
            ///////////////////////////////////
            ////////cl.ds1 = cl.DataFill2("SELECT litemname, litemid FROM pay_optloan  where litemid<>0 ORDER BY litemid");
            ////////int l;
            ////////if (cl.ds1.Tables[0].Rows.Count > 0)
            ////////{
            ////////    for (l = 0; l <= cl.ds1.Tables[0].Rows.Count - 1; l++)
            ////////    {
            ////////        //litemid.Text=cl.ds.Tables[0].Rows[j][1].ToString();
            ////////        cl.ds1 = cl.DataFill2("SELECT     isnull(sum(intamt),0) as intamt FROM  pay_loan_entry WHERE idno =" + idno.Text + " and litemid=" + litemid.Text + "");
            ////////        if (cl.ds1.Tables[0].Rows.Count > 0)
            ////////        {

            ////////            if (!(cl.ds.Tables[0].Rows[j][0].ToString().Equals(System.DBNull.Value)))//coradv
            ////////            {
            ////////                //rs("coradv.Text ="0";
            ////////            }
            ////////            else
            ////////            {
            ////////            }
            ////////        }
            ////////    }
            ////////}
            //////////////////////////////////
            ////////////////////////////////////End other Deduction
            ///////////////////////////////////
        }
        protected void GRLink_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../payrole/SaldetH.aspx");
            if (GRLink.Text == "Print Report")
            {
                Response.Redirect("../payrole/PayRopt.aspx");
            }
            else
            {
                Response.Redirect("../payrole/GenerateBill.aspx");
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

                // Double xy = Convert.ToDouble(Convert.ToInt32(basicsal));
                Double xy = Convert.ToDouble(basicsal);
                int xyintpart = (int)(xy);
                double xydecipart = xy - xyintpart;
                if (xydecipart >= 0.50)
                {
                    xy = xyintpart + 1;
                }
                else
                {
                    xy = xyintpart;
                }



                basicsal = Convert.ToString(xy);

            }
            return basicsal;

        }
        protected void Button1_Click(object sender, EventArgs e)//copy this funtion
        {
            int year, ddoid, month;
            year = Convert.ToInt32(Request.QueryString["year"]);
            ddoid = Convert.ToInt32(Request.QueryString["DDOID"]);
            month = Convert.ToInt32(Request.QueryString["Month"]);
            updatepaidInst();
            try
            {
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("Delete from calulatedsalary where ddoid=" + ddoid + " and Syear=" + year + " and Smonth=" + month + "", cl.upcon);

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

            cl.dsloan = cl.DataFillloan("Select * from Pay_loan_entry inner join pay_optloan on Pay_loan_entry.litemid=pay_optloan.litemid where idno=" + idnum + "");
            if (cl.dsloan.Tables[0].Rows.Count > 0)
            {
                int i, Instpaid, totinst, Instamt;
                for (i = 0; i <= cl.dsloan.Tables[0].Rows.Count - 1; i++)
                {
                    cl.upcon.Open();
                    string loantype = cl.dsloan.Tables[0].Rows[i][14].ToString();
                    string dedwith = cl.dsloan.Tables[0].Rows[i][12].ToString();
                    Instpaid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]);
                    totinst = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["linst"]);
                    if (Instpaid != totinst)
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
                    }
                    else
                    {
                        Instamt = 0;
                        Instpaid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]);

                    }
                    int loanid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i][3]);
                    SqlCommand cmd = new SqlCommand("update calulatedsalary set " + loantype + " = '" + Instamt + "' where idno=" + idnum + " and Syear=" + fyear + " and Smonth=" + fmonth + "", cl.upcon);
                    SqlCommand cmd1 = new SqlCommand("update pay_loan_entry set nlinstpaid = " + Instpaid + " where idno=" + idnum + " and litemid=" + loanid + "", cl.upcon);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cl.upcon.Close();
                }

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
            if (Request.QueryString["HeadID"] != "ALL")
            {
                if (Request.QueryString["HeadID"].Length == 1)
                {
                    q3 = "a.headid=" + Request.QueryString["HeadID"] + "";
                }
                else
                {
                    q3 = "a.headid like '%" + Request.QueryString["HeadID"] + "%' ";
                }
            }
            else
            {
                q3 = "a.headid like '%'";
            }
            qr = q1 + " and " + q3;
            cl.ds = cl.DataFill("SELECT     a.stopsal, b.ddoid, a.headid, a.scaleid, a.payid, a.idno, a.gpfno, isnull(a.basicpay,0) as basicpay, isnull(a.Ehra,0) as Ehra ,isnull(a.cca,0)as cca,isnull(a.perpay,0) as perpay ,isnull(a.tpay,0) as tpay ,isnull(a.sppay,0) as sppay ,isnull(a.pensionpay,0) as pensionpay,isnull(a.gpf,0) as gpf ,isnull(a.gisi,0) as gisi ,isnull(a.giss,0) as giss  ,isnull(a.incometax,0) as incometax ,isnull(a.gvr,0) as gvr ,isnull(a.hrr,0) as hrr  ,isnull(a.payded,0) as payded,isnull(a.salded,0) as salded ,isnull(a.remarks,'XX') as remarks, a.empltypeid,  a.bankid, a.bankaccno, a.incdueon, a.lastincdate, a.incstatus, isnull(a.gradepay,0) as gradepay,isnull(a.elecbill,0)as elecbill,isnull(a.rd,0)as rd ,isnull(panno,'')as panno FROM  Pay_sal_mast AS a INNER JOIN salaryselect AS b ON a.idno = b.idno  where " + qr + "");

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

                cl.dsloan = cl.DataFillloan("Select * from Pay_loan_entry inner join pay_optloan on Pay_loan_entry.litemid=pay_optloan.litemid where idno=" + idnum + "");
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
                        if (paid == 0)
                        {
                            paid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]);
                        }
                        else
                        {
                            paid = Convert.ToInt32(cl.dsloan.Tables[0].Rows[i]["nlinstpaid"]) - 1;
                        }

                        SqlCommand cmd1 = new SqlCommand("update pay_loan_entry set nlinstpaid = " + paid + " where idno=" + idnum + " and litemid=" + loanid + "", cl.upcon);
                        cmd1.ExecuteNonQuery();
                        cl.upcon.Close();
                    }

                }
            }



        }
        /* public sub checkmax()
         {
             SELECT     MAX(Syear) AS MaxSyear_ddo FROM         calulatedsalary where [ddoid]=10

         } */
    }
}