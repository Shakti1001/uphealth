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
    public partial class yearlyrepo : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        int i, j, Count, idno, month, year, k;
        string Earname, Dedname, fmonth, syear;
        ArrayList Earnamelist, Dednamelist, Earvallist, Dedvallist, totearnin, totdeduction, netsalari, montnm, totmonthear, totmonthded, monthlynetsal;
        ArrayList basicval, gradeval, npaval, dapayval, hraval, ccaval, perpayval, tpayval, sppayval, pensionval, othall1val, othall2val, othall3val, othall4val, othall5val, othall6val, fixall1val, fixall2val, fixall3val, hillval, salalrrearval, otharrearval, saldedval;
        ArrayList gpfval, gisival, gissval, incometaxval, gvrval, hrrval, paydedval, gpfinstval, plival, elecbillval, Licrdval, hba1instval, hba2instval, hba3instval, hba1iinstval, hba2iinstval, hba3iinstval, vehinstval, vehiinstval, corinstval, coriinstval, Compval, societyval, ded1val, ded2val, ded3val, socdedval;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerr.Visible = false;
            idno = Convert.ToInt32(Session["idnum"]);
            // month = Convert.ToInt32(Session["Smonth"]);
            //fmonth = Session["fsmonth"].ToString();
            syear = Session["Fyear"].ToString();
            year = Convert.ToInt32(syear.Substring(0, 4));

            lblyear.Text = syear;
            findname();
            definearrear();
            definededarr();
            printearningvalues();
            //showpayslip();
        }
        protected void findname()
        {
            cl.dsloan = cl.DataFillloan("select calulatedsalary.idno,salaryselect.name, salaryselect.post, salaryselect.hname, salaryselect.districtname, salaryselect.ddoname  FROM calulatedsalary INNER JOIN salaryselect ON calulatedsalary.idno = salaryselect.idno WHERE calulatedsalary.idno ='" + idno + "'");
            if (cl.dsloan.Tables[0].Rows.Count > 0)
            {
                TableRow rw1 = new TableRow();
                rw1.Width = Unit.Percentage(100);
                rw1.BorderWidth = 0;
                rw1.BorderColor = System.Drawing.Color.Black;
                //rw1.BackColor = System.Drawing.Color.White;

                TableCell tcell11 = new TableCell();
                tcell11.BorderWidth = 0;
                tcell11.Text = "(CompId)Name";
                tcell11.Style["width"] = "50%";
                tcell11.Style["Text-align"] = "left";
                tcell11.Font.Bold = true;
                tcell11.ForeColor = System.Drawing.Color.Black;
                rw1.Cells.Add(tcell11);

                TableCell tcell12 = new TableCell();
                tcell12.BorderWidth = 0;
                //tcell12.Style["width"] = "10%";
                tcell12.Style["Text-align"] = "left";
                tcell12.Text = "(" + cl.dsloan.Tables[0].Rows[0][0].ToString() + ")" + cl.dsloan.Tables[0].Rows[0][1].ToString();
                tcell12.Font.Bold = false;
                tcell12.ForeColor = System.Drawing.Color.Black;
                rw1.Cells.Add(tcell12);
                Table4.Rows.Add(rw1);

                TableRow rw2 = new TableRow();
                rw2.Width = Unit.Percentage(100);
                rw2.BorderWidth = 0;
                rw2.BorderColor = System.Drawing.Color.Black;
                // rw2.BackColor = System.Drawing.Color.White;

                TableCell tcell21 = new TableCell();
                tcell21.BorderWidth = 0;
                tcell21.Text = "Post";
                tcell21.Style["width"] = "50%";
                tcell21.Style["Text-align"] = "left";
                tcell21.Font.Bold = true;
                tcell21.ForeColor = System.Drawing.Color.Black;
                rw2.Cells.Add(tcell21);

                TableCell tcell22 = new TableCell();
                tcell22.BorderWidth = 0;
                //  tcell22.Style["width"] = "10%";
                tcell22.Style["Text-align"] = "left";
                tcell22.Text = cl.dsloan.Tables[0].Rows[0][2].ToString();
                tcell22.Font.Bold = false;
                tcell22.ForeColor = System.Drawing.Color.Black;
                rw2.Cells.Add(tcell22);
                Table4.Rows.Add(rw2);

                TableRow rw3 = new TableRow();
                rw3.Width = Unit.Percentage(100);
                rw3.BorderWidth = 0;
                rw3.BorderColor = System.Drawing.Color.Black;
                //rw3.BackColor = System.Drawing.Color.White;

                TableCell tcell31 = new TableCell();
                tcell31.BorderWidth = 0;
                tcell31.Text = "Hospital Name";
                tcell31.Style["width"] = "50%";
                tcell31.Style["Text-align"] = "left";
                tcell31.Font.Bold = true;
                tcell31.ForeColor = System.Drawing.Color.Black;
                rw3.Cells.Add(tcell31);

                TableCell tcell32 = new TableCell();
                tcell32.BorderWidth = 0;
                // tcell32.Style["width"] = "10%";
                tcell32.Style["Text-align"] = "left";
                tcell32.Text = cl.dsloan.Tables[0].Rows[0][3].ToString();
                tcell32.Font.Bold = false;
                tcell32.ForeColor = System.Drawing.Color.Black;
                rw3.Cells.Add(tcell32);
                Table4.Rows.Add(rw3);

                TableRow rw4 = new TableRow();
                rw4.Width = Unit.Percentage(100);
                rw4.BorderWidth = 0;
                rw4.BorderColor = System.Drawing.Color.Black;
                // rw4.BackColor = System.Drawing.Color.White;

                TableCell tcell41 = new TableCell();
                tcell41.BorderWidth = 0;
                tcell41.Text = "District Name";
                tcell41.Style["width"] = "50%";
                tcell41.Style["Text-align"] = "left";
                tcell41.Font.Bold = true;
                tcell41.ForeColor = System.Drawing.Color.Black;
                rw4.Cells.Add(tcell41);

                TableCell tcell42 = new TableCell();
                tcell42.BorderWidth = 0;
                // tcell42.Style["width"] = "10%";
                tcell42.Style["Text-align"] = "left";
                tcell42.Text = cl.dsloan.Tables[0].Rows[0][4].ToString();
                tcell42.Font.Bold = false;
                tcell42.ForeColor = System.Drawing.Color.Black;
                rw4.Cells.Add(tcell42);
                Table4.Rows.Add(rw4);

                TableRow rw5 = new TableRow();
                rw5.Width = Unit.Percentage(100);
                rw5.BorderWidth = 0;
                rw5.BorderColor = System.Drawing.Color.Black;
                //rw5.BackColor = System.Drawing.Color.White;

                TableCell tcell51 = new TableCell();
                tcell51.BorderWidth = 0;
                tcell51.Text = "DDO name";
                tcell51.Style["width"] = "50%";
                tcell51.Style["Text-align"] = "left";
                tcell51.Font.Bold = true;
                tcell51.ForeColor = System.Drawing.Color.Black;
                rw5.Cells.Add(tcell51);

                TableCell tcell52 = new TableCell();
                tcell52.BorderWidth = 0;
                //tcell52.Style["width"] = "10%";
                tcell52.Style["Text-align"] = "left";
                tcell52.Text = cl.dsloan.Tables[0].Rows[0][5].ToString();
                tcell52.Font.Bold = false;
                tcell52.ForeColor = System.Drawing.Color.Black;
                rw5.Cells.Add(tcell52);
                Table4.Rows.Add(rw5);
            }
            /* else
             {
                 lblerr.Visible = true;
                 lblerr.Text = "No Record found";
             }*/

        }

        public string monthnm(int number)
        { //string n=number.ToString();
            int n = number;
            string[] month = { "", "January", "february", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string mont = month[n];
            return mont;
        }
        protected void definearrear()
        {
            montnm = new ArrayList();
            totmonthear = new ArrayList();
            basicval = new ArrayList();
            gradeval = new ArrayList();
            npaval = new ArrayList();
            dapayval = new ArrayList();
            hraval = new ArrayList();
            ccaval = new ArrayList();
            perpayval = new ArrayList();
            tpayval = new ArrayList();
            sppayval = new ArrayList();
            pensionval = new ArrayList();
            othall1val = new ArrayList();
            othall2val = new ArrayList();
            othall3val = new ArrayList();
            othall4val = new ArrayList();
            othall5val = new ArrayList();
            othall6val = new ArrayList();
            fixall1val = new ArrayList();
            fixall2val = new ArrayList();
            fixall3val = new ArrayList();
            hillval = new ArrayList();
            salalrrearval = new ArrayList();
            otharrearval = new ArrayList();
            saldedval = new ArrayList();
            monthlynetsal = new ArrayList();
            montnm.Capacity = 30;
            totmonthear.Capacity = 30;
            basicval.Capacity = 30;
            gradeval.Capacity = 30;
            npaval.Capacity = 30;
            dapayval.Capacity = 80;
            hraval.Capacity = 30;
            ccaval.Capacity = 30;
            perpayval.Capacity = 30;
            tpayval.Capacity = 30;
            sppayval.Capacity = 30;
            pensionval.Capacity = 30;
            othall1val.Capacity = 30;
            othall2val.Capacity = 30;
            othall3val.Capacity = 30;
            othall4val.Capacity = 30;
            othall5val.Capacity = 30;
            othall6val.Capacity = 30;
            fixall1val.Capacity = 30;
            fixall2val.Capacity = 30;
            fixall3val.Capacity = 30;
            hillval.Capacity = 30;
            salalrrearval.Capacity = 30;
            otharrearval.Capacity = 30;
            saldedval.Capacity = 30;
            monthlynetsal.Capacity = 40;

        }
        protected void definededarr()
        {
            Earnamelist = new ArrayList();
            Earvallist = new ArrayList();
            Dednamelist = new ArrayList();
            Dedvallist = new ArrayList();
            totearnin = new ArrayList();
            totdeduction = new ArrayList();
            netsalari = new ArrayList();

            Earnamelist.Capacity = 30;
            Earvallist.Capacity = 30;
            Dednamelist.Capacity = 30;
            Dedvallist.Capacity = 30;
            totearnin.Capacity = 30;
            totdeduction.Capacity = 30;
            netsalari.Capacity = 30;

            totmonthded = new ArrayList();
            gpfval = new ArrayList();
            gisival = new ArrayList();
            gissval = new ArrayList();
            incometaxval = new ArrayList();
            gvrval = new ArrayList();
            hrrval = new ArrayList();
            paydedval = new ArrayList();
            gpfinstval = new ArrayList();
            plival = new ArrayList();
            elecbillval = new ArrayList();
            Licrdval = new ArrayList();
            hba1instval = new ArrayList();
            hba2instval = new ArrayList();
            hba3instval = new ArrayList();
            hba1iinstval = new ArrayList();
            hba2iinstval = new ArrayList();
            hba3iinstval = new ArrayList();
            vehinstval = new ArrayList();
            vehiinstval = new ArrayList();
            corinstval = new ArrayList();
            coriinstval = new ArrayList();
            Compval = new ArrayList();
            societyval = new ArrayList();
            ded1val = new ArrayList();
            ded2val = new ArrayList();
            ded3val = new ArrayList();
            socdedval = new ArrayList();
            totmonthded.Capacity = 30;
            gpfval.Capacity = 30;
            gisival.Capacity = 30;
            gissval.Capacity = 30;
            incometaxval.Capacity = 30;
            gvrval.Capacity = 30;
            hrrval.Capacity = 30;
            paydedval.Capacity = 30;
            gpfinstval.Capacity = 30;
            plival.Capacity = 30;
            elecbillval.Capacity = 30;
            Licrdval.Capacity = 30;
            hba1instval.Capacity = 30;
            hba1iinstval.Capacity = 30;
            hba2instval.Capacity = 30;
            hba2iinstval.Capacity = 30;
            hba3instval.Capacity = 30;
            hba3iinstval.Capacity = 30;
            vehinstval.Capacity = 30;
            vehiinstval.Capacity = 30;
            corinstval.Capacity = 30;
            coriinstval.Capacity = 30;
            Compval.Capacity = 30;
            societyval.Capacity = 30;
            ded1val.Capacity = 30;
            ded2val.Capacity = 30;
            ded3val.Capacity = 30;
            socdedval.Capacity = 30;

        }
        /* protected void showpayslip()
         {

             cl.upcon.Open();
             cl.ds = cl.DataFill("Select * from calulatedsalary where idno='" + idno + "' and  Syear='" + year + "' order by Smonth");
             Earnamelist = new ArrayList();
             Earvallist = new ArrayList();
             Dednamelist = new ArrayList();
             Dedvallist = new ArrayList();
             totearnin = new ArrayList();
             totdeduction = new ArrayList();
             netsalari = new ArrayList();
         
             Earnamelist.Capacity = 30;
             Earvallist.Capacity = 30;
             Dednamelist.Capacity = 30;
             Dedvallist.Capacity = 30;
             totearnin.Capacity = 30;
             totdeduction.Capacity = 30;
             netsalari.Capacity = 30;
             if (cl.ds.Tables[0].Rows.Count > 0)
             {
            

                     //int month1 = Convert.ToInt32(cl.ds.Tables[0].Rows[k]["Smonth"]);
                     cl.dsid = cl.DataFilleid("select  basicpay, Gradepay, npaall, dapay, hra, cca,  perpay, tpay, sppay, pensionpay,  othall1, othall2, othall3, othall4, othall5, othall6, fixall1, fixall2, fixall3, hill, salarrear, otharrear,salded,attendance from calulatedsalary where idno='" + idno + "' and Syear='" + year + "'order by Smonth");
                     cl.dshba = cl.DataFillhba("select  gpf, gisi, giss, incometax, gvr, hrr, payded,gpfinst, pli, elecbill, Licrd, hba1inst, hba2inst, hba3inst, hba1iinst, hba2iinst, hba3iinst, vehinst, vehiinst, corinst, coriinst, Computer, Society, ded1, ded2, ded3, socded   from calulatedsalary where idno='" + idno + "'and   Syear='" + year + "'order by Smonth");
                     for (i = 0; i <= 22; i++)
                     {
                   
                             Earname = GetEarname();
                             Earnamelist.Add(Earname);
                             //Earvallist.Add(cl.dsid.Tables[0].Rows[0][i].ToString());

                   

                     }
                     for (j = 0; j <= 26; j++)
                     {
                                                   
                             Dedname = GetDedname();
                             Dednamelist.Add(Dedname);
                            // Dedvallist.Add(cl.dshba.Tables[0].Rows[0][j].ToString());

                      }
                    // printslip();
                     // grossearnded();
                     //printearningvalues();
                    // printdeduction();
                     cl.upcon.Close();
            

             }
             else
             {
                 lblerr.Visible = true;

                // Label1.Text = "Salary not Processed for Selected Month & Year,Contact DDo...";
                 lblerr.Text = "no record found";
             }


         }*/
        protected string GetEarname()
        {
            if (i == 0)
            {
                Earname = "BasicPay";
            }
            if (i == 1)
            {
                Earname = "GradePay";
            }
            if (i == 2)
            {
                Earname = "NPA";
            }
            if (i == 3)
            {
                Earname = "DA";
            }
            if (i == 4)
            {
                Earname = "HRA";
            }
            if (i == 5)
            {
                Earname = "CCA";

            }
            if (i == 6)
            {
                Earname = "Per.Pay";
            }
            if (i == 7)
            {
                Earname = "Trans.Allow";
            }
            if (i == 8)
            {
                Earname = "Spec.Pay";
            }
            if (i == 9)
            {
                Earname = "PensionPay";
            }
            if (i == 10)
            {
                Earname = "OtherAllow1";
            }
            if (i == 11)
            {
                Earname = "OtherAllow2";
            }
            if (i == 12)
            {
                Earname = "OtherAllow3";
            }
            if (i == 13)
            {
                Earname = "OtherAllow4";

            }
            if (i == 14)
            {
                Earname = "OtherAllow5";
            }
            if (i == 15)
            {
                Earname = "OtherAllow6";
            }
            if (i == 16)
            {
                Earname = "FixAllow1";
            }
            if (i == 17)
            {
                Earname = "FixAllow2";
            }
            if (i == 18)
            {
                Earname = "FixAllow3";
            }

            if (i == 19)
            {
                Earname = "HillAllow";
            }
            if (i == 20)
            {
                Earname = "SalArrear";
            }
            if (i == 21)
            {
                Earname = "OtherArrear";
            }
            if (i == 22)
            {
                Earname = "Salded";
            }
            return Earname;

        }
        protected string GetDedname()
        {
            if (j == 0)
            {
                Dedname = "GPF";
            }
            if (j == 1)
            {
                Dedname = "GISI";
            }
            if (j == 2)
            {
                Dedname = "GISS";
            }
            if (j == 3)
            {
                Dedname = "IncomeTax";
            }
            if (j == 4)
            {
                Dedname = "GVR";
            }
            if (j == 5)
            {
                Dedname = "HRR";

            }
            if (j == 6)
            {
                Dedname = "PayDed";
            }


            if (j == 7)
            {
                Dedname = "GPFAdv";
            }
            if (j == 8)
            {
                Dedname = "PLI";
            }
            if (j == 9)
            {
                Dedname = "ElecBill";
            }
            if (j == 10)
            {
                Dedname = "LIC/RD";
            }
            if (j == 11)
            {
                Dedname = "HBA1";

            }
            if (j == 12)
            {
                Dedname = "HBA2";
            }
            if (j == 13)
            {
                Dedname = "HBA3";
            }
            if (j == 14)
            {
                Dedname = "HBA1Inst";
            }
            if (j == 15)
            {
                Dedname = "HBA2Inst";
            }
            if (j == 16)
            {
                Dedname = "HBA3Inst";
            }

            if (j == 17)
            {
                Dedname = "Veh.Adv";
            }
            if (j == 18)
            {
                Dedname = "Veh.AdvInst";
            }
            if (j == 19)
            {
                Dedname = "CarAdv";
            }
            if (j == 20)
            {
                Dedname = "CarAdvInst";
            }
            if (j == 21)
            {
                Dedname = "Comp.Adv";
            }
            if (j == 22)
            {
                Dedname = "Society";
            }
            if (j == 23)
            {
                Dedname = "Ded1";
            }
            if (j == 24)
            {
                Dedname = "Ded2";

            }
            if (j == 25)
            {
                Dedname = "Ded3";
            }
            if (j == 26)
            {
                Dedname = "SocDed";
            }
            return Dedname;
        }

        /* protected void printslip()
         {
             TableRow rw1 = new TableRow();
             rw1.Width = Unit.Percentage(100);
             rw1.BorderWidth = 2;
             rw1.BorderColor = System.Drawing.Color.SlateGray;
             rw1.BackColor = System.Drawing.Color.White;

             TableCell tcell2 = new TableCell();
             tcell2.BorderWidth = 2;
             tcell2.Attributes.Add("colspan", "1");
             tcell2.Style["Text-align"] = "left";
             tcell2.Text = "Earning";
             tcell2.ForeColor = System.Drawing.Color.Black;
             rw1.Cells.Add(tcell2);
             Table1.Rows.Add(rw1);
             for (i = 0; i <= Earnamelist.Count-1; i++)
             {
                 TableRow rw2 = new TableRow();
                 rw2.Width = Unit.Percentage(100);
                 rw2.BorderWidth = 2;
                 rw2.BorderColor = System.Drawing.Color.SlateGray;
                 rw2.BackColor = System.Drawing.Color.White;

                 TableCell tcell1 = new TableCell();
                 tcell1.BorderWidth = 2;
                 tcell1.Attributes.Add("colspan", "1");
                 tcell1.Style["Text-align"] = "left";
                 tcell1.Text = Earnamelist[i].ToString();
                 tcell1.ForeColor = System.Drawing.Color.Black;
                 rw2.Cells.Add(tcell1);
                 Table1.Rows.Add(rw2);
             }
             TableRow rw3 = new TableRow();
             rw3.Width = Unit.Percentage(100);
             rw3.BorderWidth = 2;
             rw3.BorderColor = System.Drawing.Color.SlateGray;
             rw3.BackColor = System.Drawing.Color.White;

             TableCell tcell3 = new TableCell();
             tcell3.BorderWidth = 2;
             tcell3.Attributes.Add("colspan", "1");
             tcell3.Style["Text-align"] = "left";
             tcell3.Text = "Total";
             tcell3.ForeColor = System.Drawing.Color.Black;
             tcell3.BackColor = System.Drawing.Color.LightBlue;
             rw3.Cells.Add(tcell3);
             Table1.Rows.Add(rw3);
      
         }
         protected void printdeduction()
         {
             TableRow rw1 = new TableRow();
             rw1.Width = Unit.Percentage(100);
             rw1.BorderWidth = 2;
             rw1.BorderColor = System.Drawing.Color.SlateGray;
             rw1.BackColor = System.Drawing.Color.White;

             TableCell tcell2 = new TableCell();
             tcell2.BorderWidth = 2;
             tcell2.Attributes.Add("colspan", "1");
             tcell2.Style["Text-align"] = "left";
             tcell2.Text = "Deduction";
             tcell2.ForeColor = System.Drawing.Color.Black;
             rw1.Cells.Add(tcell2);
             Table5.Rows.Add(rw1);
             for (i = 0; i <= Dednamelist.Count-1; i++)
             {
                 TableRow rw2 = new TableRow();
                 rw2.Width = Unit.Percentage(100);
                 rw2.BorderWidth = 2;
                 rw2.BorderColor = System.Drawing.Color.SlateGray;
                 rw2.BackColor = System.Drawing.Color.White;

                 TableCell tcell1 = new TableCell();
                 tcell1.BorderWidth = 2;
                 tcell1.Attributes.Add("colspan", "1");
                 tcell1.Style["Text-align"] = "left";
                 tcell1.Text = Dednamelist[i].ToString();
                 tcell1.ForeColor = System.Drawing.Color.Black;
                 rw2.Cells.Add(tcell1);
                 Table5.Rows.Add(rw2);
             }
             TableRow rw3 = new TableRow();
             rw3.Width = Unit.Percentage(100);
             rw3.BorderWidth = 2;
             rw3.BorderColor = System.Drawing.Color.SlateGray;
             rw3.BackColor = System.Drawing.Color.White;

             TableCell tcell3 = new TableCell();
             tcell3.BorderWidth = 2;
             tcell3.Attributes.Add("colspan", "1");
             tcell3.Style["Text-align"] = "left";
             tcell3.Text = "Total";
             tcell3.ForeColor = System.Drawing.Color.Black;
             tcell3.BackColor = System.Drawing.Color.LightBlue;
             rw3.Cells.Add(tcell3);
             Table5.Rows.Add(rw3);
             TableRow rw33 = new TableRow();
             rw33.Width = Unit.Percentage(100);
             rw33.BorderWidth = 2;
             rw33.BorderColor = System.Drawing.Color.SlateGray;
            // rw33.BackColor = System.Drawing.Color.White;
             TableCell tcell33 = new TableCell();
             tcell33.BorderWidth = 2;
             tcell33.Attributes.Add("colspan", "1");
             tcell33.Style["Text-align"] = "left";
             tcell33.Text = "Net Salary";
             tcell33.ForeColor = System.Drawing.Color.Black;
             tcell33.BackColor = System.Drawing.Color.CadetBlue;
             rw33.Cells.Add(tcell33);
             Table5.Rows.Add(rw33);
        

         }*/
        protected void printearningvalues()
        {
            cl.upcon.Close();
            cl.upcon.Open();
            int yr = year + 1;
            // cl.dsD = cl.DataFill2("Select * from calulatedsalary where idno='" + idno + "' and  Syear='" + year + "' order by Smonth");
            cl.dsD = cl.DataFill2("Select * from calulatedsalary where idno='" + idno + "' and ((Syear='" + year + "'and Smonth>2) or (Syear='" + yr + "' and (Smonth=1 or Smonth=2))) order by Syear,Smonth");
            //int month1 = Convert.ToInt32(cl.DataFillhba.Tables[0].Rows[k]["Smonth"]);
            if (cl.dsD.Tables[0].Rows.Count > 0)
            {
                for (k = 0; k <= cl.dsD.Tables[0].Rows.Count - 1; k++)
                {
                    montnm.Add(cl.dsD.Tables[0].Rows[k]["Smonth"]);
                    int month1 = Convert.ToInt32(cl.dsD.Tables[0].Rows[k]["Smonth"]);
                    int year1 = Convert.ToInt32(cl.dsD.Tables[0].Rows[k]["Syear"]);
                    //monthnm(month1);
                    cl.dsD1 = cl.DataFillD1("select  isnull(basicpay,0)as basicpay,isnull(Gradepay,0)as gradepay,isnull(npaall,0)as npa,isnull(dapay,0)as dapay,isnull(hra,0)as hra,isnull(cca,0)as cca,isnull(perpay,0)as perpay,isnull(tpay,0)as tpay,isnull(sppay,0)as sppay, isnull(pensionpay,0)as pensionpay,isnull(othall1,0)as othall1,isnull(othall2,0)as othall2, isnull(othall3,0)as othall3,isnull(othall4,0)as othall4, isnull(othall5,0)as othall5,isnull(othall6,0)as othall6,isnull(fixall1,0)as fixall1,isnull(fixall2,0)as fixall2,isnull(fixall3,0)as fixall3,isnull(hill,0)as hill,isnull(salarrear,0)as salarrear,isnull(otharrear,0)as otharrear,isnull(salded,0)as salded,isnull(attendance,0)as attendance from calulatedsalary where idno='" + idno + "'and Smonth='" + month1 + "' and  Syear='" + year1 + "'");
                    cl.dsE = cl.DataFillE("select  isnull(gpf,0)as gpf,isnull(gisi,0)as gisi,isnull(giss,0)as giss,isnull(incometax,0)as incometax,isnull(gvr,0)as gvr,isnull(hrr,0)as hrr,isnull(payded,0)as payded,isnull(Gpfadv,0)as Gpfadv, isnull(pli,0) as pli,isnull(elecbill,0)as elecbill,isnull(Licrd,0) as Licrd,isnull(hba1inst,0) as hba1inst,isnull(hba2inst,0)as hba2inst,isnull(hba3inst,0)as hba3inst,isnull(hba1iinst,0)as hba1iinst,isnull(hba2iinst,0)as hba2iinst,isnull(hba3iinst,0)as hba3iinst,isnull(vehinst,0)as vehinst,isnull(vehiinst,0)as vehiinst,isnull(corinst,0)as corinst,isnull(coriinst,0)as coriinst,isnull(Computer,0)as Computer,isnull(Society,0)as Society,isnull(ded1,0)as ded1,isnull(ded2,0)as ded2,isnull(ded3,0)as ded3,isnull(socded,0)as socded   from calulatedsalary  where idno='" + idno + "'and Smonth='" + month1 + "' and Syear='" + year1 + "'");

                    basicval.Add(cl.dsD1.Tables[0].Rows[0]["basicpay"]);
                    gradeval.Add(cl.dsD1.Tables[0].Rows[0]["gradepay"]);
                    npaval.Add(cl.dsD1.Tables[0].Rows[0]["npa"]);
                    dapayval.Add(cl.dsD1.Tables[0].Rows[0]["dapay"]);
                    hraval.Add(cl.dsD1.Tables[0].Rows[0]["hra"]);
                    ccaval.Add(cl.dsD1.Tables[0].Rows[0]["cca"]);
                    perpayval.Add(cl.dsD1.Tables[0].Rows[0]["perpay"]);
                    tpayval.Add(cl.dsD1.Tables[0].Rows[0]["tpay"]);
                    sppayval.Add(cl.dsD1.Tables[0].Rows[0]["sppay"]);
                    pensionval.Add(cl.dsD1.Tables[0].Rows[0]["pensionpay"]);
                    othall1val.Add(cl.dsD1.Tables[0].Rows[0]["othall1"]);
                    othall2val.Add(cl.dsD1.Tables[0].Rows[0]["othall2"]);
                    othall3val.Add(cl.dsD1.Tables[0].Rows[0]["othall3"]);
                    othall4val.Add(cl.dsD1.Tables[0].Rows[0]["othall4"]);
                    othall5val.Add(cl.dsD1.Tables[0].Rows[0]["othall5"]);
                    othall6val.Add(cl.dsD1.Tables[0].Rows[0]["othall6"]);
                    fixall1val.Add(cl.dsD1.Tables[0].Rows[0]["fixall1"]);
                    fixall2val.Add(cl.dsD1.Tables[0].Rows[0]["fixall2"]);
                    fixall3val.Add(cl.dsD1.Tables[0].Rows[0]["fixall3"]);
                    hillval.Add(cl.dsD1.Tables[0].Rows[0]["hill"]);
                    salalrrearval.Add(cl.dsD1.Tables[0].Rows[0]["salarrear"]);
                    otharrearval.Add(cl.dsD1.Tables[0].Rows[0]["otharrear"]);
                    saldedval.Add(cl.dsD1.Tables[0].Rows[0]["salded"]);

                    /////////////////////deduction////////////////////////

                    gpfval.Add(cl.dsE.Tables[0].Rows[0]["gpf"]);
                    gisival.Add(cl.dsE.Tables[0].Rows[0]["gisi"]);
                    gissval.Add(cl.dsE.Tables[0].Rows[0]["giss"]);
                    incometaxval.Add(cl.dsE.Tables[0].Rows[0]["incometax"]);
                    gvrval.Add(cl.dsE.Tables[0].Rows[0]["gvr"]);
                    hrrval.Add(cl.dsE.Tables[0].Rows[0]["hrr"]);
                    paydedval.Add(cl.dsE.Tables[0].Rows[0]["payded"]);
                    gpfinstval.Add(cl.dsE.Tables[0].Rows[0]["Gpfadv"]);
                    plival.Add(cl.dsE.Tables[0].Rows[0]["pli"]);
                    elecbillval.Add(cl.dsE.Tables[0].Rows[0]["elecbill"]);
                    Licrdval.Add(cl.dsE.Tables[0].Rows[0]["Licrd"]);
                    hba1instval.Add(cl.dsE.Tables[0].Rows[0]["hba1inst"]);
                    hba2instval.Add(cl.dsE.Tables[0].Rows[0]["hba2inst"]);
                    hba3instval.Add(cl.dsE.Tables[0].Rows[0]["hba3inst"]);
                    hba1iinstval.Add(cl.dsE.Tables[0].Rows[0]["hba1iinst"]);
                    hba2iinstval.Add(cl.dsE.Tables[0].Rows[0]["hba2iinst"]);
                    hba3iinstval.Add(cl.dsE.Tables[0].Rows[0]["hba3iinst"]);
                    vehinstval.Add(cl.dsE.Tables[0].Rows[0]["vehinst"]);
                    vehiinstval.Add(cl.dsE.Tables[0].Rows[0]["vehiinst"]);
                    corinstval.Add(cl.dsE.Tables[0].Rows[0]["corinst"]);
                    coriinstval.Add(cl.dsE.Tables[0].Rows[0]["coriinst"]);
                    Compval.Add(cl.dsE.Tables[0].Rows[0]["Computer"]);
                    societyval.Add(cl.dsE.Tables[0].Rows[0]["Society"]);
                    ded1val.Add(cl.dsE.Tables[0].Rows[0]["ded1"]);
                    ded2val.Add(cl.dsE.Tables[0].Rows[0]["ded2"]);
                    ded3val.Add(cl.dsE.Tables[0].Rows[0]["ded3"]);
                    socdedval.Add(cl.dsE.Tables[0].Rows[0]["socded"]);

                    cl.dsid = cl.DataFilleid("select sum(isnull(basicpay,0) +isnull(Gradepay,0)+ isnull(npaall,0)+ isnull(dapay,0)+ isnull(hra,0)+ isnull(cca,0)+ isnull(perpay,0) + isnull(tpay,0) + isnull(sppay,0) + isnull(pensionpay,0)+ isnull(othall1,0)+ isnull(othall2,0) + isnull(othall3,0) + isnull(othall4,0) + isnull(othall5,0) + isnull(othall6,0)+ isnull(fixall1,0)+isnull(fixall2,0)+ isnull(fixall3,0)+ isnull(hill,0)+isnull(salarrear,0)+ isnull(otharrear,0)-isnull(salded,0)) as netearning from calulatedsalary where idno='" + idno + "' and Smonth='" + month1 + "'and Syear='" + year1 + "'  ");
                    cl.dshba = cl.DataFillhba("select  sum(isnull(gpf,0) + isnull(gisi,0) + isnull(giss,0) + isnull(incometax,0) + isnull(gvr,0) + isnull(hrr,0) + isnull(payded,0) + isnull(Gpfadv,0) + isnull(pli,0) + isnull(elecbill,0) + isnull(Licrd,0) + isnull(hba1inst,0) + isnull(hba2inst,0) + isnull(hba3inst,0) + isnull(hba1iinst,0) + isnull(hba2iinst,0) + isnull(hba3iinst,0) + isnull(vehinst,0) + isnull(vehiinst,0) + isnull(corinst,0) + isnull(coriinst,0) + isnull(Computer,0) + isnull(Society,0) + isnull(ded1,0) + isnull(ded2,0) + isnull(ded3,0) + isnull(socded,0)) as netded   from calulatedsalary where idno='" + idno + "' and Smonth='" + month1 + "'and Syear='" + year1 + "' ");

                    totmonthear.Add(cl.dsid.Tables[0].Rows[0][0].ToString());
                    totmonthded.Add(cl.dshba.Tables[0].Rows[0][0].ToString());
                    monthlynetsal.Add((Convert.ToInt32(cl.dsid.Tables[0].Rows[0][0]) - Convert.ToInt32(cl.dshba.Tables[0].Rows[0][0])).ToString());


                }
                //////////////////////////////// EARNINGS//////////////////////////////
                ///////////////////////////////////////////////////////////////////////

                TableRow rw1 = new TableRow();
                rw1.Width = Unit.Percentage(100);
                rw1.BorderWidth = 2;
                rw1.BorderColor = System.Drawing.Color.SlateGray;
                rw1.BackColor = System.Drawing.Color.White;
                TableCell tcellearn = new TableCell();
                tcellearn.BorderWidth = 1;
                tcellearn.Font.Bold = true;
                tcellearn.Attributes.Add("colspan", "1");
                tcellearn.Style["Text-align"] = "left";
                tcellearn.Text = "Earnings";
                tcellearn.ForeColor = System.Drawing.Color.Black;
                rw1.Cells.Add(tcellearn);
                for (i = 0; i <= montnm.Count - 1; i++)
                {
                    TableCell tcell23 = new TableCell();
                    tcell23.BorderWidth = 1;
                    tcell23.Attributes.Add("colspan", "1");
                    tcell23.Style["Text-align"] = "left";
                    tcell23.Text = monthnm(Convert.ToInt32(montnm[i])).ToString();
                    tcell23.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell23);

                }
                TableCell tcelltot = new TableCell();
                tcelltot.BorderWidth = 1;
                tcelltot.Attributes.Add("colspan", "1");
                tcelltot.Style["Text-align"] = "center";
                tcelltot.Text = " Total ";
                tcelltot.ForeColor = System.Drawing.Color.Black;
                tcelltot.BackColor = System.Drawing.Color.LightBlue;
                rw1.Cells.Add(tcelltot);

                Table2.Rows.Add(rw1);

                TableRow rw2 = new TableRow();
                rw2.Width = Unit.Percentage(100);
                rw2.BorderWidth = 2;
                rw2.BorderColor = System.Drawing.Color.SlateGray;
                rw2.BackColor = System.Drawing.Color.White;
                TableCell tcellbasic = new TableCell();
                tcellbasic.BorderWidth = 1;
                tcellbasic.Font.Bold = true;
                tcellbasic.Attributes.Add("colspan", "1");
                tcellbasic.Style["Text-align"] = "left";
                tcellbasic.Text = "Basic Pay";
                tcellbasic.ForeColor = System.Drawing.Color.Black;
                rw2.Cells.Add(tcellbasic);
                for (i = 0; i <= basicval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = basicval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rw2.Cells.Add(tcell12);

                }
                TableCell tcelltotbasic = new TableCell();
                tcelltotbasic.BorderWidth = 1;
                tcelltotbasic.Attributes.Add("colspan", "1");
                tcelltotbasic.Style["Text-align"] = "left";
                tcelltotbasic.Text = basictot().ToString();
                tcelltotbasic.ForeColor = System.Drawing.Color.Black;
                rw2.Cells.Add(tcelltotbasic);

                Table2.Rows.Add(rw2);

                TableRow rw3 = new TableRow();
                rw3.Width = Unit.Percentage(100);
                rw3.BorderWidth = 2;
                rw3.BorderColor = System.Drawing.Color.SlateGray;
                rw3.BackColor = System.Drawing.Color.White;
                TableCell tcellgrade = new TableCell();
                tcellgrade.BorderWidth = 1;
                tcellgrade.Font.Bold = true;
                tcellgrade.Attributes.Add("colspan", "1");
                tcellgrade.Style["Text-align"] = "left";
                tcellgrade.Text = "Grade Pay";
                tcellgrade.ForeColor = System.Drawing.Color.Black;
                rw3.Cells.Add(tcellgrade);
                for (i = 0; i <= gradeval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = gradeval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw3.Cells.Add(tcell13);

                }
                TableCell tcelltotgrade = new TableCell();
                tcelltotgrade.BorderWidth = 1;
                tcelltotgrade.Attributes.Add("colspan", "1");
                tcelltotgrade.Style["Text-align"] = "left";
                tcelltotgrade.Text = gradepaytot().ToString();
                tcelltotgrade.ForeColor = System.Drawing.Color.Black;
                rw3.Cells.Add(tcelltotgrade);

                Table2.Rows.Add(rw3);

                TableRow rw4 = new TableRow();
                rw4.Width = Unit.Percentage(100);
                rw4.BorderWidth = 2;
                rw4.BorderColor = System.Drawing.Color.SlateGray;
                rw4.BackColor = System.Drawing.Color.White;
                TableCell tcellnpa = new TableCell();
                tcellnpa.BorderWidth = 1;
                tcellnpa.Font.Bold = true;
                tcellnpa.Attributes.Add("colspan", "1");
                tcellnpa.Style["Text-align"] = "left";
                tcellnpa.Text = "NPA";
                tcellnpa.ForeColor = System.Drawing.Color.Black;
                rw4.Cells.Add(tcellnpa);
                for (i = 0; i <= npaval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = npaval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw4.Cells.Add(tcell13);

                }
                TableCell tcelltotnpa = new TableCell();
                tcelltotnpa.BorderWidth = 1;
                tcelltotnpa.Attributes.Add("colspan", "1");
                tcelltotnpa.Style["Text-align"] = "left";
                tcelltotnpa.Text = npatot().ToString();
                tcelltotnpa.ForeColor = System.Drawing.Color.Black;
                rw4.Cells.Add(tcelltotnpa);
                Table2.Rows.Add(rw4);

                TableRow rw5 = new TableRow();
                rw5.Width = Unit.Percentage(100);
                rw5.BorderWidth = 2;
                rw5.BorderColor = System.Drawing.Color.SlateGray;
                rw5.BackColor = System.Drawing.Color.White;
                TableCell tcellda = new TableCell();
                tcellda.BorderWidth = 1;
                tcellda.Font.Bold = true;
                tcellda.Attributes.Add("colspan", "1");
                tcellda.Style["Text-align"] = "left";
                tcellda.Text = "DA";
                tcellda.ForeColor = System.Drawing.Color.Black;
                rw5.Cells.Add(tcellda);
                for (i = 0; i <= dapayval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = dapayval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw5.Cells.Add(tcell13);

                }
                TableCell tcelltotda = new TableCell();
                tcelltotda.BorderWidth = 1;
                tcelltotda.Attributes.Add("colspan", "1");
                tcelltotda.Style["Text-align"] = "left";
                tcelltotda.Text = dapaytot().ToString();
                tcelltotda.ForeColor = System.Drawing.Color.Black;
                rw5.Cells.Add(tcelltotda);
                Table2.Rows.Add(rw5);


                TableRow rw6 = new TableRow();
                rw6.Width = Unit.Percentage(100);
                rw6.BorderWidth = 2;
                rw6.BorderColor = System.Drawing.Color.SlateGray;
                rw6.BackColor = System.Drawing.Color.White;

                TableCell tcellhra = new TableCell();
                tcellhra.BorderWidth = 1;
                tcellhra.Font.Bold = true;
                tcellhra.Attributes.Add("colspan", "1");
                tcellhra.Style["Text-align"] = "left";
                tcellhra.Text = "HRA";
                tcellhra.ForeColor = System.Drawing.Color.Black;
                rw6.Cells.Add(tcellhra);
                for (i = 0; i <= hraval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = hraval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw6.Cells.Add(tcell13);

                }

                TableCell tcelltothra = new TableCell();
                tcelltothra.BorderWidth = 1;
                tcelltothra.Attributes.Add("colspan", "1");
                tcelltothra.Style["Text-align"] = "left";
                tcelltothra.Text = hratot().ToString();
                tcelltothra.ForeColor = System.Drawing.Color.Black;
                rw6.Cells.Add(tcelltothra);
                Table2.Rows.Add(rw6);

                TableRow rw7 = new TableRow();
                rw7.Width = Unit.Percentage(100);
                rw7.BorderWidth = 2;
                rw7.BorderColor = System.Drawing.Color.SlateGray;
                rw7.BackColor = System.Drawing.Color.White;

                TableCell tcellcca = new TableCell();
                tcellcca.BorderWidth = 1;
                tcellcca.Font.Bold = true;
                tcellcca.Attributes.Add("colspan", "1");
                tcellcca.Style["Text-align"] = "left";
                tcellcca.Text = "CCA";
                tcellcca.ForeColor = System.Drawing.Color.Black;
                rw7.Cells.Add(tcellcca);
                for (i = 0; i <= ccaval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = ccaval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw7.Cells.Add(tcell13);

                }
                TableCell tcelltotcca = new TableCell();
                tcelltotcca.BorderWidth = 1;
                tcelltotcca.Attributes.Add("colspan", "1");
                tcelltotcca.Style["Text-align"] = "left";
                tcelltotcca.Text = ccatot().ToString();
                tcelltotcca.ForeColor = System.Drawing.Color.Black;
                rw7.Cells.Add(tcelltotcca);

                Table2.Rows.Add(rw7);

                TableRow rw8 = new TableRow();
                rw8.Width = Unit.Percentage(100);
                rw8.BorderWidth = 2;
                rw8.BorderColor = System.Drawing.Color.SlateGray;
                rw8.BackColor = System.Drawing.Color.White;

                TableCell tcellperpay = new TableCell();
                tcellperpay.BorderWidth = 1;
                tcellperpay.Font.Bold = true;
                tcellperpay.Attributes.Add("colspan", "1");
                tcellperpay.Style["Text-align"] = "left";
                tcellperpay.Text = "PerPay";
                tcellperpay.ForeColor = System.Drawing.Color.Black;
                rw8.Cells.Add(tcellperpay);
                for (i = 0; i <= perpayval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = perpayval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw8.Cells.Add(tcell13);

                }

                TableCell tcelltotperpay = new TableCell();
                tcelltotperpay.BorderWidth = 1;
                tcelltotperpay.Attributes.Add("colspan", "1");
                tcelltotperpay.Style["Text-align"] = "left";
                tcelltotperpay.Text = perpaytot().ToString();
                tcelltotperpay.ForeColor = System.Drawing.Color.Black;
                rw8.Cells.Add(tcelltotperpay);
                Table2.Rows.Add(rw8);


                TableRow rw9 = new TableRow();
                rw9.Width = Unit.Percentage(100);
                rw9.BorderWidth = 2;
                rw9.BorderColor = System.Drawing.Color.SlateGray;
                rw9.BackColor = System.Drawing.Color.White;
                TableCell tcelltransall = new TableCell();
                tcelltransall.BorderWidth = 1;
                tcelltransall.Font.Bold = true;
                tcelltransall.Attributes.Add("colspan", "1");
                tcelltransall.Style["Text-align"] = "left";
                tcelltransall.Text = "TransAllow.";
                tcelltransall.ForeColor = System.Drawing.Color.Black;
                rw9.Cells.Add(tcelltransall);
                for (i = 0; i <= tpayval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = tpayval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw9.Cells.Add(tcell13);

                }
                TableCell tcelltottpay = new TableCell();
                tcelltottpay.BorderWidth = 1;
                tcelltottpay.Attributes.Add("colspan", "1");
                tcelltottpay.Style["Text-align"] = "left";
                tcelltottpay.Text = tpaytot().ToString();
                tcelltottpay.ForeColor = System.Drawing.Color.Black;
                rw9.Cells.Add(tcelltottpay);
                Table2.Rows.Add(rw9);



                TableRow rw10 = new TableRow();
                rw10.Width = Unit.Percentage(100);
                rw10.BorderWidth = 2;
                rw10.BorderColor = System.Drawing.Color.SlateGray;
                rw10.BackColor = System.Drawing.Color.White;
                TableCell tcellspecpay = new TableCell();
                tcellspecpay.BorderWidth = 1;
                tcellspecpay.Font.Bold = true;
                tcellspecpay.Attributes.Add("colspan", "1");
                tcellspecpay.Style["Text-align"] = "left";
                tcellspecpay.Text = "SpecPay.";
                tcellspecpay.ForeColor = System.Drawing.Color.Black;
                rw10.Cells.Add(tcellspecpay);

                for (i = 0; i <= sppayval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = sppayval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw10.Cells.Add(tcell13);

                }
                TableCell tcelltotsppay = new TableCell();
                tcelltotsppay.BorderWidth = 1;
                tcelltotsppay.Attributes.Add("colspan", "1");
                tcelltotsppay.Style["Text-align"] = "left";
                tcelltotsppay.Text = sppaytot().ToString();
                tcelltotsppay.ForeColor = System.Drawing.Color.Black;
                rw10.Cells.Add(tcelltotsppay);
                Table2.Rows.Add(rw10);


                TableRow rw11 = new TableRow();
                rw11.Width = Unit.Percentage(100);
                rw11.BorderWidth = 2;
                rw11.BorderColor = System.Drawing.Color.SlateGray;
                rw11.BackColor = System.Drawing.Color.White;

                TableCell tcellpensionpay = new TableCell();
                tcellpensionpay.BorderWidth = 1;
                tcellpensionpay.Font.Bold = true;
                tcellpensionpay.Attributes.Add("colspan", "1");
                tcellpensionpay.Style["Text-align"] = "left";
                tcellpensionpay.Text = "PensionPay";
                tcellpensionpay.ForeColor = System.Drawing.Color.Black;
                rw11.Cells.Add(tcellpensionpay);

                for (i = 0; i <= pensionval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = pensionval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw11.Cells.Add(tcell13);

                }
                TableCell tcellpension = new TableCell();
                tcellpension.BorderWidth = 1;
                tcellpension.Attributes.Add("colspan", "1");
                tcellpension.Style["Text-align"] = "left";
                tcellpension.Text = pensionpaytot().ToString();
                tcellpension.ForeColor = System.Drawing.Color.Black;
                rw11.Cells.Add(tcellpension);

                Table2.Rows.Add(rw11);

                TableRow rw12 = new TableRow();
                rw12.Width = Unit.Percentage(100);
                rw12.BorderWidth = 2;
                rw12.BorderColor = System.Drawing.Color.SlateGray;
                rw12.BackColor = System.Drawing.Color.White;


                TableCell tcellothall1 = new TableCell();
                tcellothall1.BorderWidth = 1;
                tcellothall1.Font.Bold = true;
                tcellothall1.Attributes.Add("colspan", "1");
                tcellothall1.Style["Text-align"] = "left";
                tcellothall1.Text = "OtherAllow1";
                tcellothall1.ForeColor = System.Drawing.Color.Black;
                rw12.Cells.Add(tcellothall1);

                for (i = 0; i <= othall1val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = othall1val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw12.Cells.Add(tcell13);

                }
                TableCell tcelltotothall1 = new TableCell();
                tcelltotothall1.BorderWidth = 1;
                tcelltotothall1.Attributes.Add("colspan", "1");
                tcelltotothall1.Style["Text-align"] = "left";
                tcelltotothall1.Text = othall1tot().ToString();
                tcelltotothall1.ForeColor = System.Drawing.Color.Black;
                rw12.Cells.Add(tcelltotothall1);
                Table2.Rows.Add(rw12);


                TableRow rw13 = new TableRow();
                rw13.Width = Unit.Percentage(100);
                rw13.BorderWidth = 2;
                rw13.BorderColor = System.Drawing.Color.SlateGray;
                rw13.BackColor = System.Drawing.Color.White;

                TableCell tcellothall2 = new TableCell();
                tcellothall2.BorderWidth = 1;
                tcellothall2.Font.Bold = true;
                tcellothall2.Attributes.Add("colspan", "1");
                tcellothall2.Style["Text-align"] = "left";
                tcellothall2.Text = "OtherAllow2";
                tcellothall2.ForeColor = System.Drawing.Color.Black;
                rw13.Cells.Add(tcellothall2);

                for (i = 0; i <= othall2val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = othall2val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw13.Cells.Add(tcell13);

                }
                TableCell tcelltototha2 = new TableCell();
                tcelltototha2.BorderWidth = 1;
                tcelltototha2.Attributes.Add("colspan", "1");
                tcelltototha2.Style["Text-align"] = "left";
                tcelltototha2.Text = othall2tot().ToString();
                tcelltototha2.ForeColor = System.Drawing.Color.Black;
                rw13.Cells.Add(tcelltototha2);
                Table2.Rows.Add(rw13);

                TableRow rw14 = new TableRow();
                rw14.Width = Unit.Percentage(100);
                rw14.BorderWidth = 2;
                rw14.BorderColor = System.Drawing.Color.SlateGray;
                rw14.BackColor = System.Drawing.Color.White;

                TableCell tcellothall3 = new TableCell();
                tcellothall3.BorderWidth = 1;
                tcellothall3.Font.Bold = true;
                tcellothall3.Attributes.Add("colspan", "1");
                tcellothall3.Style["Text-align"] = "left";
                tcellothall3.Text = "OtherAllow3";
                tcellothall3.ForeColor = System.Drawing.Color.Black;
                rw14.Cells.Add(tcellothall3);

                for (i = 0; i <= othall3val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = othall3val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw14.Cells.Add(tcell13);

                }
                TableCell tcelltototha3 = new TableCell();
                tcelltototha3.BorderWidth = 1;
                tcelltototha3.Attributes.Add("colspan", "1");
                tcelltototha3.Style["Text-align"] = "left";
                tcelltototha3.Text = othall3tot().ToString();
                tcelltototha3.ForeColor = System.Drawing.Color.Black;
                rw14.Cells.Add(tcelltototha3);
                Table2.Rows.Add(rw14);

                TableRow rw15 = new TableRow();
                rw15.Width = Unit.Percentage(100);
                rw15.BorderWidth = 2;
                rw15.BorderColor = System.Drawing.Color.SlateGray;
                rw15.BackColor = System.Drawing.Color.White;


                TableCell tcellothall4 = new TableCell();
                tcellothall4.BorderWidth = 1;
                tcellothall4.Font.Bold = true;
                tcellothall4.Attributes.Add("colspan", "1");
                tcellothall4.Style["Text-align"] = "left";
                tcellothall4.Text = "OtherAllow4";
                tcellothall4.ForeColor = System.Drawing.Color.Black;
                rw15.Cells.Add(tcellothall4);

                for (i = 0; i <= othall4val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = othall4val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw15.Cells.Add(tcell13);

                }
                TableCell tcelltototha4 = new TableCell();
                tcelltototha4.BorderWidth = 1;
                tcelltototha4.Attributes.Add("colspan", "1");
                tcelltototha4.Style["Text-align"] = "left";
                tcelltototha4.Text = othall4tot().ToString();
                tcelltototha4.ForeColor = System.Drawing.Color.Black;
                rw15.Cells.Add(tcelltototha4);
                Table2.Rows.Add(rw15);

                TableRow rw16 = new TableRow();
                rw16.Width = Unit.Percentage(100);
                rw16.BorderWidth = 2;
                rw16.BorderColor = System.Drawing.Color.SlateGray;
                rw16.BackColor = System.Drawing.Color.White;


                TableCell tcellothall5 = new TableCell();
                tcellothall5.BorderWidth = 1;
                tcellothall5.Font.Bold = true;
                tcellothall5.Attributes.Add("colspan", "1");
                tcellothall5.Style["Text-align"] = "left";
                tcellothall5.Text = "OtherAllow5";
                tcellothall5.ForeColor = System.Drawing.Color.Black;
                rw16.Cells.Add(tcellothall5);


                for (i = 0; i <= othall5val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = othall5val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw16.Cells.Add(tcell13);

                }
                TableCell tcelltototha5 = new TableCell();
                tcelltototha5.BorderWidth = 1;
                tcelltototha5.Attributes.Add("colspan", "1");
                tcelltototha5.Style["Text-align"] = "left";
                tcelltototha5.Text = othall5tot().ToString();
                tcelltototha5.ForeColor = System.Drawing.Color.Black;
                rw16.Cells.Add(tcelltototha5);
                Table2.Rows.Add(rw16);

                TableRow rw17 = new TableRow();
                rw17.Width = Unit.Percentage(100);
                rw17.BorderWidth = 2;
                rw17.BorderColor = System.Drawing.Color.SlateGray;
                rw17.BackColor = System.Drawing.Color.White;

                TableCell tcellothall6 = new TableCell();
                tcellothall6.BorderWidth = 1;
                tcellothall6.Font.Bold = true;
                tcellothall6.Attributes.Add("colspan", "1");
                tcellothall6.Style["Text-align"] = "left";
                tcellothall6.Text = "OtherAllow6";
                tcellothall6.ForeColor = System.Drawing.Color.Black;
                rw17.Cells.Add(tcellothall6);

                for (i = 0; i <= othall6val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = othall6val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw17.Cells.Add(tcell13);

                }
                TableCell tcelltototha6 = new TableCell();
                tcelltototha6.BorderWidth = 1;
                tcelltototha6.Attributes.Add("colspan", "1");
                tcelltototha6.Style["Text-align"] = "left";
                tcelltototha6.Text = othall6tot().ToString();
                tcelltototha6.ForeColor = System.Drawing.Color.Black;
                rw17.Cells.Add(tcelltototha6);
                Table2.Rows.Add(rw17);

                TableRow rw18 = new TableRow();
                rw18.Width = Unit.Percentage(100);
                rw18.BorderWidth = 2;
                rw18.BorderColor = System.Drawing.Color.SlateGray;
                rw18.BackColor = System.Drawing.Color.White;

                TableCell tcellfixall1 = new TableCell();
                tcellfixall1.BorderWidth = 1;
                tcellfixall1.Font.Bold = true;
                tcellfixall1.Attributes.Add("colspan", "1");
                tcellfixall1.Style["Text-align"] = "left";
                tcellfixall1.Text = "FixAllow1";
                tcellfixall1.ForeColor = System.Drawing.Color.Black;
                rw18.Cells.Add(tcellfixall1);

                for (i = 0; i <= fixall1val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = fixall1val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw18.Cells.Add(tcell13);

                }

                TableCell tcellfixa1 = new TableCell();
                tcellfixa1.BorderWidth = 1;
                tcellfixa1.Attributes.Add("colspan", "1");
                tcellfixa1.Style["Text-align"] = "left";
                tcellfixa1.Text = fixall1tot().ToString();
                tcellfixa1.ForeColor = System.Drawing.Color.Black;
                rw18.Cells.Add(tcellfixa1);
                Table2.Rows.Add(rw18);

                TableRow rw19 = new TableRow();
                rw19.Width = Unit.Percentage(100);
                rw19.BorderWidth = 2;
                rw19.BorderColor = System.Drawing.Color.SlateGray;
                rw19.BackColor = System.Drawing.Color.White;

                TableCell tcellfixall2 = new TableCell();
                tcellfixall2.BorderWidth = 1;
                tcellfixall2.Font.Bold = true;
                tcellfixall2.Attributes.Add("colspan", "1");
                tcellfixall2.Style["Text-align"] = "left";
                tcellfixall2.Text = "FixAllow2";
                tcellfixall2.ForeColor = System.Drawing.Color.Black;
                rw19.Cells.Add(tcellfixall2);

                for (i = 0; i <= fixall2val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = fixall2val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw19.Cells.Add(tcell13);

                }
                TableCell tcellfixa2 = new TableCell();
                tcellfixa2.BorderWidth = 1;
                tcellfixa2.Attributes.Add("colspan", "1");
                tcellfixa2.Style["Text-align"] = "left";
                tcellfixa2.Text = fixall2tot().ToString();
                tcellfixa2.ForeColor = System.Drawing.Color.Black;
                rw19.Cells.Add(tcellfixa2);
                Table2.Rows.Add(rw19);

                TableRow rw20 = new TableRow();
                rw20.Width = Unit.Percentage(100);
                rw20.BorderWidth = 2;
                rw20.BorderColor = System.Drawing.Color.SlateGray;
                rw20.BackColor = System.Drawing.Color.White;

                TableCell tcellfixall3 = new TableCell();
                tcellfixall3.BorderWidth = 1;
                tcellfixall3.Font.Bold = true;
                tcellfixall3.Attributes.Add("colspan", "1");
                tcellfixall3.Style["Text-align"] = "left";
                tcellfixall3.Text = "FixAllow3";
                tcellfixall3.ForeColor = System.Drawing.Color.Black;
                rw20.Cells.Add(tcellfixall3);

                for (i = 0; i <= fixall3val.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = fixall3val[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw20.Cells.Add(tcell13);

                }
                TableCell tcellfixa3 = new TableCell();
                tcellfixa3.BorderWidth = 1;
                tcellfixa3.Attributes.Add("colspan", "1");
                tcellfixa3.Style["Text-align"] = "left";
                tcellfixa3.Text = fixall3tot().ToString();
                tcellfixa3.ForeColor = System.Drawing.Color.Black;
                rw20.Cells.Add(tcellfixa3);
                Table2.Rows.Add(rw20);

                TableRow rw21 = new TableRow();
                rw21.Width = Unit.Percentage(100);
                rw21.BorderWidth = 2;
                rw21.BorderColor = System.Drawing.Color.SlateGray;
                rw21.BackColor = System.Drawing.Color.White;

                TableCell tcellhillall = new TableCell();
                tcellhillall.BorderWidth = 1;
                tcellhillall.Font.Bold = true;
                tcellhillall.Attributes.Add("colspan", "1");
                tcellhillall.Style["Text-align"] = "left";
                tcellhillall.Text = "HillAllow";
                tcellhillall.ForeColor = System.Drawing.Color.Black;
                rw21.Cells.Add(tcellhillall);

                for (i = 0; i <= hillval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = hillval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw21.Cells.Add(tcell13);

                }

                TableCell tcellhill = new TableCell();
                tcellhill.BorderWidth = 1;
                tcellhill.Attributes.Add("colspan", "1");
                tcellhill.Style["Text-align"] = "left";
                tcellhill.Text = hilltot().ToString();
                tcellhill.ForeColor = System.Drawing.Color.Black;
                rw21.Cells.Add(tcellhill);
                Table2.Rows.Add(rw21);

                TableRow rw22 = new TableRow();
                rw22.Width = Unit.Percentage(100);
                rw22.BorderWidth = 2;
                rw22.BorderColor = System.Drawing.Color.SlateGray;
                rw22.BackColor = System.Drawing.Color.White;

                TableCell tcellsalarrear = new TableCell();
                tcellsalarrear.BorderWidth = 1;
                tcellsalarrear.Font.Bold = true;
                tcellsalarrear.Attributes.Add("colspan", "1");
                tcellsalarrear.Style["Text-align"] = "left";
                tcellsalarrear.Text = "SalArrear";
                tcellsalarrear.ForeColor = System.Drawing.Color.Black;
                rw22.Cells.Add(tcellsalarrear);

                for (i = 0; i <= salalrrearval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = salalrrearval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw22.Cells.Add(tcell13);

                }

                TableCell tcellsalarear = new TableCell();
                tcellsalarear.BorderWidth = 1;
                tcellsalarear.Attributes.Add("colspan", "1");
                tcellsalarear.Style["Text-align"] = "left";
                tcellsalarear.Text = salarreartot().ToString();
                tcellsalarear.ForeColor = System.Drawing.Color.Black;
                rw22.Cells.Add(tcellsalarear);
                Table2.Rows.Add(rw22);

                TableRow rw23 = new TableRow();
                rw23.Width = Unit.Percentage(100);
                rw23.BorderWidth = 2;
                rw23.BorderColor = System.Drawing.Color.SlateGray;
                rw23.BackColor = System.Drawing.Color.White;

                TableCell tcellothrear = new TableCell();
                tcellothrear.BorderWidth = 1;
                tcellothrear.Font.Bold = true;
                tcellothrear.Attributes.Add("colspan", "1");
                tcellothrear.Style["Text-align"] = "left";
                tcellothrear.Text = "OtherArrear";
                tcellothrear.ForeColor = System.Drawing.Color.Black;
                rw23.Cells.Add(tcellothrear);

                for (i = 0; i <= otharrearval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = otharrearval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw23.Cells.Add(tcell13);

                }
                TableCell tcellothar = new TableCell();
                tcellothar.BorderWidth = 1;
                tcellothar.Attributes.Add("colspan", "1");
                tcellothar.Style["Text-align"] = "left";
                tcellothar.Text = otharreartot().ToString();
                tcellothar.ForeColor = System.Drawing.Color.Black;
                rw23.Cells.Add(tcellothar);
                Table2.Rows.Add(rw23);

                TableRow rw24 = new TableRow();
                rw24.Width = Unit.Percentage(100);
                rw24.BorderWidth = 2;
                rw24.BorderColor = System.Drawing.Color.SlateGray;
                rw24.BackColor = System.Drawing.Color.White;

                TableCell tcellsaalded = new TableCell();
                tcellsaalded.BorderWidth = 1;
                tcellsaalded.Font.Bold = true;
                tcellsaalded.Attributes.Add("colspan", "1");
                tcellsaalded.Style["Text-align"] = "left";
                tcellsaalded.Text = "SalDed";
                tcellsaalded.ForeColor = System.Drawing.Color.Black;
                rw24.Cells.Add(tcellsaalded);
                for (i = 0; i <= saldedval.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = saldedval[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Black;
                    rw24.Cells.Add(tcell13);

                }
                TableCell tcellsalded = new TableCell();
                tcellsalded.BorderWidth = 1;
                tcellsalded.Attributes.Add("colspan", "1");
                tcellsalded.Style["Text-align"] = "left";
                tcellsalded.Text = saldedtot().ToString();
                tcellsalded.ForeColor = System.Drawing.Color.Black;
                rw24.Cells.Add(tcellsalded);
                Table2.Rows.Add(rw24);

                TableRow rw25 = new TableRow();
                rw25.Width = Unit.Percentage(100);
                rw25.BorderWidth = 2;
                rw25.BorderColor = System.Drawing.Color.SlateGray;
                rw25.BackColor = System.Drawing.Color.LightBlue;

                TableCell tcelltotall = new TableCell();
                tcelltotall.BorderWidth = 1;
                tcelltotall.Font.Bold = true;
                tcelltotall.Attributes.Add("colspan", "1");
                tcelltotall.Style["Text-align"] = "left";
                tcelltotall.Text = "Total";
                tcelltotall.ForeColor = System.Drawing.Color.Black;
                rw25.Cells.Add(tcelltotall);

                for (i = 0; i <= totmonthear.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = totmonthear[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.DarkMagenta;
                    rw25.Cells.Add(tcell13);

                }


                TableCell tcelltotal = new TableCell();
                tcelltotal.BorderWidth = 1;
                tcelltotal.Attributes.Add("colspan", "1");
                tcelltotal.Style["Text-align"] = "left";
                tcelltotal.Text = totalearningg().ToString();
                tcelltotal.ForeColor = System.Drawing.Color.DarkMagenta;
                tcelltotal.BackColor = System.Drawing.Color.LightBlue;
                rw25.Cells.Add(tcelltotal);
                Table2.Rows.Add(rw25);

                /////////////////// ////////////////////////////////// DEDUCTIONS/////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////

                TableRow rwd1 = new TableRow();
                rwd1.Width = Unit.Percentage(100);
                rwd1.BorderWidth = 2;
                rwd1.BorderColor = System.Drawing.Color.SlateGray;
                rwd1.BackColor = System.Drawing.Color.White;

                TableCell tcellded = new TableCell();
                tcellded.BorderWidth = 1;
                tcellded.Font.Bold = true;
                //  tcellded.Attributes.Add("colspan", "1");
                tcellded.Style["Text-align"] = "left";
                tcellded.Text = "Deductions";
                tcellded.ForeColor = System.Drawing.Color.Black;
                rwd1.Cells.Add(tcellded);

                for (i = 0; i <= montnm.Count - 1; i++)
                {
                    TableCell tcell23 = new TableCell();
                    tcell23.BorderWidth = 1;
                    tcell23.Attributes.Add("colspan", "1");
                    tcell23.Style["Text-align"] = "left";
                    tcell23.Text = monthnm(Convert.ToInt32(montnm[i])).ToString();
                    tcell23.ForeColor = System.Drawing.Color.Black;
                    rwd1.Cells.Add(tcell23);

                }
                TableCell tcelltotd = new TableCell();
                tcelltotd.BorderWidth = 1;
                tcelltotd.Attributes.Add("colspan", "1");
                tcelltotd.Style["Text-align"] = "center";
                tcelltotd.Text = " Total ";
                tcelltotd.ForeColor = System.Drawing.Color.Black;
                tcelltotd.BackColor = System.Drawing.Color.LightBlue;
                rwd1.Cells.Add(tcelltotd);

                Table3.Rows.Add(rwd1);

                TableRow rwd2 = new TableRow();
                rwd2.Width = Unit.Percentage(100);
                rwd2.BorderWidth = 2;
                rwd2.BorderColor = System.Drawing.Color.SlateGray;
                rwd2.BackColor = System.Drawing.Color.White;

                TableCell tcellgpf = new TableCell();
                tcellgpf.BorderWidth = 1;
                tcellgpf.Font.Bold = true;
                //  tcellgpf.Attributes.Add("colspan", "1");
                tcellgpf.Style["Text-align"] = "left";
                tcellgpf.Text = "GPF";
                tcellgpf.ForeColor = System.Drawing.Color.Black;
                rwd2.Cells.Add(tcellgpf);

                for (i = 0; i <= gpfval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = gpfval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd2.Cells.Add(tcell12);

                }
                TableCell tcelltotgpf = new TableCell();
                tcelltotgpf.BorderWidth = 1;
                tcelltotgpf.Attributes.Add("colspan", "1");
                tcelltotgpf.Style["Text-align"] = "left";
                tcelltotgpf.Text = gpftot().ToString();
                tcelltotgpf.ForeColor = System.Drawing.Color.Black;
                rwd2.Cells.Add(tcelltotgpf);

                Table3.Rows.Add(rwd2);

                TableRow rwd3 = new TableRow();
                rwd3.Width = Unit.Percentage(100);
                rwd3.BorderWidth = 2;
                rwd3.BorderColor = System.Drawing.Color.SlateGray;
                rwd3.BackColor = System.Drawing.Color.White;
                TableCell tcellgisi = new TableCell();
                tcellgisi.BorderWidth = 1;
                tcellgisi.Font.Bold = true;
                //  tcellgisi.Attributes.Add("colspan", "1");
                tcellgisi.Style["Text-align"] = "left";
                tcellgisi.Text = "GISI";
                tcellgisi.ForeColor = System.Drawing.Color.Black;
                rwd3.Cells.Add(tcellgisi);
                for (i = 0; i <= gisival.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = gisival[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd3.Cells.Add(tcell12);

                }
                TableCell tcelltotgisi = new TableCell();
                tcelltotgisi.BorderWidth = 1;
                tcelltotgisi.Attributes.Add("colspan", "1");
                tcelltotgisi.Style["Text-align"] = "left";
                tcelltotgisi.Text = gisitot().ToString();
                tcelltotgisi.ForeColor = System.Drawing.Color.Black;
                rwd3.Cells.Add(tcelltotgisi);

                Table3.Rows.Add(rwd3);

                TableRow rwd4 = new TableRow();
                rwd4.Width = Unit.Percentage(100);
                rwd4.BorderWidth = 2;
                rwd4.BorderColor = System.Drawing.Color.SlateGray;
                rwd4.BackColor = System.Drawing.Color.White;
                TableCell tcellgiss = new TableCell();
                tcellgiss.BorderWidth = 1;
                tcellgiss.Font.Bold = true;
                //   tcellgiss.Attributes.Add("colspan", "1");
                tcellgiss.Style["Text-align"] = "left";
                tcellgiss.Text = "GISS";
                tcellgiss.ForeColor = System.Drawing.Color.Black;
                rwd4.Cells.Add(tcellgiss);

                for (i = 0; i <= gissval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = gissval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd4.Cells.Add(tcell12);

                }
                TableCell tcelltotgiss = new TableCell();
                tcelltotgiss.BorderWidth = 1;
                tcelltotgiss.Attributes.Add("colspan", "1");
                tcelltotgiss.Style["Text-align"] = "left";
                tcelltotgiss.Text = gisstot().ToString();
                tcelltotgiss.ForeColor = System.Drawing.Color.Black;
                rwd4.Cells.Add(tcelltotgiss);

                Table3.Rows.Add(rwd4);


                TableRow rwd5 = new TableRow();
                rwd5.Width = Unit.Percentage(100);
                rwd5.BorderWidth = 2;
                rwd5.BorderColor = System.Drawing.Color.SlateGray;
                rwd5.BackColor = System.Drawing.Color.White;

                TableCell tcellintax = new TableCell();
                tcellintax.BorderWidth = 1;
                tcellintax.Font.Bold = true;
                //  tcellintax.Attributes.Add("colspan", "1");
                tcellintax.Style["Text-align"] = "left";
                tcellintax.Text = "Income Tax";
                tcellintax.ForeColor = System.Drawing.Color.Black;
                rwd5.Cells.Add(tcellintax);


                for (i = 0; i <= incometaxval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = incometaxval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd5.Cells.Add(tcell12);

                }
                TableCell tcelltotIT = new TableCell();
                tcelltotIT.BorderWidth = 1;
                tcelltotIT.Attributes.Add("colspan", "1");
                tcelltotIT.Style["Text-align"] = "left";
                tcelltotIT.Text = ITtot().ToString();
                tcelltotIT.ForeColor = System.Drawing.Color.Black;
                rwd5.Cells.Add(tcelltotIT);

                Table3.Rows.Add(rwd5);

                TableRow rwd6 = new TableRow();
                rwd6.Width = Unit.Percentage(100);
                rwd6.BorderWidth = 2;
                rwd6.BorderColor = System.Drawing.Color.SlateGray;
                rwd6.BackColor = System.Drawing.Color.White;

                TableCell tcellgvr = new TableCell();
                tcellgvr.BorderWidth = 1;
                tcellgvr.Font.Bold = true;
                //tcellgvr.Attributes.Add("colspan", "1");
                tcellgvr.Style["Text-align"] = "left";
                tcellgvr.Text = "GVR";
                tcellgvr.ForeColor = System.Drawing.Color.Black;
                rwd6.Cells.Add(tcellgvr);

                for (i = 0; i <= gvrval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = gvrval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd6.Cells.Add(tcell12);

                }
                TableCell tcelltotgvr = new TableCell();
                tcelltotgvr.BorderWidth = 1;
                tcelltotgvr.Attributes.Add("colspan", "1");
                tcelltotgvr.Style["Text-align"] = "left";
                tcelltotgvr.Text = gvrtot().ToString();
                tcelltotgvr.ForeColor = System.Drawing.Color.Black;
                rwd6.Cells.Add(tcelltotgvr);

                Table3.Rows.Add(rwd6);

                TableRow rwd7 = new TableRow();
                rwd7.Width = Unit.Percentage(100);
                rwd7.BorderWidth = 2;
                rwd7.BorderColor = System.Drawing.Color.SlateGray;
                rwd7.BackColor = System.Drawing.Color.White;

                TableCell tcellhrr = new TableCell();
                tcellhrr.BorderWidth = 1;
                tcellhrr.Font.Bold = true;
                // tcellhrr.Attributes.Add("colspan", "1");
                tcellhrr.Style["Text-align"] = "left";
                tcellhrr.Text = "HRR";
                tcellhrr.ForeColor = System.Drawing.Color.Black;
                rwd7.Cells.Add(tcellhrr);

                for (i = 0; i <= hrrval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = hrrval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd7.Cells.Add(tcell12);

                }
                TableCell tcelltothrr = new TableCell();
                tcelltothrr.BorderWidth = 1;
                tcelltothrr.Attributes.Add("colspan", "1");
                tcelltothrr.Style["Text-align"] = "left";
                tcelltothrr.Text = hrrtot().ToString();
                tcelltothrr.ForeColor = System.Drawing.Color.Black;
                rwd7.Cells.Add(tcelltothrr);

                Table3.Rows.Add(rwd7);

                TableRow rwd8 = new TableRow();
                rwd8.Width = Unit.Percentage(100);
                rwd8.BorderWidth = 2;
                rwd8.BorderColor = System.Drawing.Color.SlateGray;
                rwd8.BackColor = System.Drawing.Color.White;

                TableCell tcellpayded = new TableCell();
                tcellpayded.BorderWidth = 1;
                tcellpayded.Font.Bold = true;
                //tcellpayded.Attributes.Add("colspan", "1");
                tcellpayded.Style["Text-align"] = "left";
                tcellpayded.Text = "PayDed";
                tcellpayded.ForeColor = System.Drawing.Color.Black;
                rwd8.Cells.Add(tcellpayded);

                for (i = 0; i <= paydedval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = paydedval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd8.Cells.Add(tcell12);

                }
                TableCell tcelltotpayded = new TableCell();
                tcelltotpayded.BorderWidth = 1;
                tcelltotpayded.Attributes.Add("colspan", "1");
                tcelltotpayded.Style["Text-align"] = "left";
                tcelltotpayded.Text = paydedtot().ToString();
                tcelltotpayded.ForeColor = System.Drawing.Color.Black;
                rwd8.Cells.Add(tcelltotpayded);
                Table3.Rows.Add(rwd8);

                TableRow rwd9 = new TableRow();
                rwd9.Width = Unit.Percentage(100);
                rwd9.BorderWidth = 2;
                rwd9.BorderColor = System.Drawing.Color.SlateGray;
                rwd9.BackColor = System.Drawing.Color.White;

                TableCell tcellgpfadv = new TableCell();
                tcellgpfadv.BorderWidth = 1;
                tcellgpfadv.Font.Bold = true;
                // tcellgpfadv.Attributes.Add("colspan", "1");
                tcellgpfadv.Style["Text-align"] = "left";
                tcellgpfadv.Text = "GpfAdv";
                tcellgpfadv.ForeColor = System.Drawing.Color.Black;
                rwd9.Cells.Add(tcellgpfadv);


                for (i = 0; i <= gpfinstval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = gpfinstval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd9.Cells.Add(tcell12);

                }
                TableCell tcelltotgpfi = new TableCell();
                tcelltotgpfi.BorderWidth = 1;
                tcelltotgpfi.Attributes.Add("colspan", "1");
                tcelltotgpfi.Style["Text-align"] = "left";
                tcelltotgpfi.Text = gpfinsttot().ToString();
                tcelltotgpfi.ForeColor = System.Drawing.Color.Black;
                rwd9.Cells.Add(tcelltotgpfi);
                Table3.Rows.Add(rwd9);

                TableRow rwd10 = new TableRow();
                rwd10.Width = Unit.Percentage(100);
                rwd10.BorderWidth = 2;
                rwd10.BorderColor = System.Drawing.Color.SlateGray;
                rwd10.BackColor = System.Drawing.Color.White;

                TableCell tcellpli = new TableCell();
                tcellpli.BorderWidth = 1;
                tcellpli.Font.Bold = true;
                //  tcellpli.Attributes.Add("colspan", "1");
                tcellpli.Style["Text-align"] = "left";
                tcellpli.Text = "PLI";
                tcellpli.ForeColor = System.Drawing.Color.Black;
                rwd10.Cells.Add(tcellpli);

                for (i = 0; i <= plival.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = plival[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd10.Cells.Add(tcell12);

                }
                TableCell tcelltotpli = new TableCell();
                tcelltotpli.BorderWidth = 1;
                tcelltotpli.Attributes.Add("colspan", "1");
                tcelltotpli.Style["Text-align"] = "left";
                tcelltotpli.Text = plitot().ToString();
                tcelltotpli.ForeColor = System.Drawing.Color.Black;
                rwd10.Cells.Add(tcelltotpli);
                Table3.Rows.Add(rwd10);

                TableRow rwd11 = new TableRow();
                rwd11.Width = Unit.Percentage(100);
                rwd11.BorderWidth = 2;
                rwd11.BorderColor = System.Drawing.Color.SlateGray;
                rwd11.BackColor = System.Drawing.Color.White;


                TableCell tcellEB = new TableCell();
                tcellEB.BorderWidth = 1;
                tcellEB.Font.Bold = true;
                //tcellEB.Attributes.Add("colspan", "1");
                tcellEB.Style["Text-align"] = "left";
                tcellEB.Text = "ElecBill";
                tcellEB.ForeColor = System.Drawing.Color.Black;
                rwd11.Cells.Add(tcellEB);

                for (i = 0; i <= elecbillval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = elecbillval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd11.Cells.Add(tcell12);

                }
                TableCell tcelltotelecbill = new TableCell();
                tcelltotelecbill.BorderWidth = 1;
                tcelltotelecbill.Attributes.Add("colspan", "1");
                tcelltotelecbill.Style["Text-align"] = "left";
                tcelltotelecbill.Text = elecbilltot().ToString();
                tcelltotelecbill.ForeColor = System.Drawing.Color.Black;
                rwd11.Cells.Add(tcelltotelecbill);
                Table3.Rows.Add(rwd11);

                TableRow rwd12 = new TableRow();
                rwd12.Width = Unit.Percentage(100);
                rwd12.BorderWidth = 2;
                rwd12.BorderColor = System.Drawing.Color.SlateGray;
                rwd12.BackColor = System.Drawing.Color.White;

                TableCell tcelllicrd = new TableCell();
                tcelllicrd.BorderWidth = 1;
                tcelllicrd.Font.Bold = true;
                // tcelllicrd.Attributes.Add("colspan", "1");
                tcelllicrd.Style["Text-align"] = "left";
                tcelllicrd.Text = "LIC/RD";
                tcelllicrd.ForeColor = System.Drawing.Color.Black;
                rwd12.Cells.Add(tcelllicrd);


                for (i = 0; i <= Licrdval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = Licrdval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd12.Cells.Add(tcell12);

                }
                TableCell tcelltotlicrd = new TableCell();
                tcelltotlicrd.BorderWidth = 1;
                tcelltotlicrd.Attributes.Add("colspan", "1");
                tcelltotlicrd.Style["Text-align"] = "left";
                tcelltotlicrd.Text = licrdtot().ToString();
                tcelltotlicrd.ForeColor = System.Drawing.Color.Black;
                rwd12.Cells.Add(tcelltotlicrd);
                Table3.Rows.Add(rwd12);

                TableRow rwd13 = new TableRow();
                rwd13.Width = Unit.Percentage(100);
                rwd13.BorderWidth = 2;
                rwd13.BorderColor = System.Drawing.Color.SlateGray;
                rwd13.BackColor = System.Drawing.Color.White;

                TableCell tcellhbaa1 = new TableCell();
                tcellhbaa1.BorderWidth = 1;
                tcellhbaa1.Font.Bold = true;
                // tcellhbaa1.Attributes.Add("colspan", "1");
                tcellhbaa1.Style["Text-align"] = "left";
                tcellhbaa1.Text = "HBA1";
                tcellhbaa1.ForeColor = System.Drawing.Color.Black;
                rwd13.Cells.Add(tcellhbaa1);


                for (i = 0; i <= hba1instval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = hba1instval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd13.Cells.Add(tcell12);

                }
                TableCell tcelltothba1 = new TableCell();
                tcelltothba1.BorderWidth = 1;
                tcelltothba1.Attributes.Add("colspan", "1");
                tcelltothba1.Style["Text-align"] = "left";
                tcelltothba1.Text = hba1itot().ToString();
                tcelltothba1.ForeColor = System.Drawing.Color.Black;
                rwd13.Cells.Add(tcelltothba1);
                Table3.Rows.Add(rwd13);


                TableRow rwd14 = new TableRow();
                rwd14.Width = Unit.Percentage(100);
                rwd14.BorderWidth = 2;
                rwd14.BorderColor = System.Drawing.Color.SlateGray;
                rwd14.BackColor = System.Drawing.Color.White;

                TableCell tcellhbaa2 = new TableCell();
                tcellhbaa2.BorderWidth = 1;
                tcellhbaa2.Font.Bold = true;
                // tcellhbaa2.Attributes.Add("colspan", "1");
                tcellhbaa2.Style["Text-align"] = "left";
                tcellhbaa2.Text = "HBA2";
                tcellhbaa2.ForeColor = System.Drawing.Color.Black;
                rwd14.Cells.Add(tcellhbaa2);

                for (i = 0; i <= hba2instval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = hba2instval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd14.Cells.Add(tcell12);

                }
                TableCell tcelltothba2 = new TableCell();
                tcelltothba2.BorderWidth = 1;
                tcelltothba2.Attributes.Add("colspan", "1");
                tcelltothba2.Style["Text-align"] = "left";
                tcelltothba2.Text = hba2itot().ToString();
                tcelltothba2.ForeColor = System.Drawing.Color.Black;
                rwd14.Cells.Add(tcelltothba2);
                Table3.Rows.Add(rwd14);

                TableRow rwd15 = new TableRow();
                rwd15.Width = Unit.Percentage(100);
                rwd15.BorderWidth = 2;
                rwd15.BorderColor = System.Drawing.Color.SlateGray;
                rwd15.BackColor = System.Drawing.Color.White;


                TableCell tcellhbaa3 = new TableCell();
                tcellhbaa3.BorderWidth = 1;
                tcellhbaa3.Font.Bold = true;
                //tcellhbaa3.Attributes.Add("colspan", "1");
                tcellhbaa3.Style["Text-align"] = "left";
                tcellhbaa3.Text = "HBA3";
                tcellhbaa3.ForeColor = System.Drawing.Color.Black;
                rwd15.Cells.Add(tcellhbaa3);

                for (i = 0; i <= hba3instval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = hba3instval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd15.Cells.Add(tcell12);

                }
                TableCell tcelltothba3 = new TableCell();
                tcelltothba3.BorderWidth = 1;
                tcelltothba3.Attributes.Add("colspan", "1");
                tcelltothba3.Style["Text-align"] = "left";
                tcelltothba3.Text = hba3itot().ToString();
                tcelltothba3.ForeColor = System.Drawing.Color.Black;
                rwd15.Cells.Add(tcelltothba3);
                Table3.Rows.Add(rwd15);

                TableRow rwd16 = new TableRow();
                rwd16.Width = Unit.Percentage(100);
                rwd16.BorderWidth = 2;
                rwd16.BorderColor = System.Drawing.Color.SlateGray;
                rwd16.BackColor = System.Drawing.Color.White;

                TableCell tcellhbaa1i = new TableCell();
                tcellhbaa1i.BorderWidth = 1;
                tcellhbaa1i.Font.Bold = true;
                //  tcellhbaa1i.Attributes.Add("colspan", "1");
                tcellhbaa1i.Style["Text-align"] = "left";
                tcellhbaa1i.Text = "HBA1Inst";
                tcellhbaa1i.ForeColor = System.Drawing.Color.Black;
                rwd16.Cells.Add(tcellhbaa1i);

                for (i = 0; i <= hba1iinstval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = hba1iinstval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd16.Cells.Add(tcell12);

                }
                TableCell tcelltothba1ad = new TableCell();
                tcelltothba1ad.BorderWidth = 1;
                tcelltothba1ad.Attributes.Add("colspan", "1");
                tcelltothba1ad.Style["Text-align"] = "left";
                tcelltothba1ad.Text = hba1iitot().ToString();
                tcelltothba1ad.ForeColor = System.Drawing.Color.Black;
                rwd16.Cells.Add(tcelltothba1ad);
                Table3.Rows.Add(rwd16);

                TableRow rwd17 = new TableRow();
                rwd17.Width = Unit.Percentage(100);
                rwd17.BorderWidth = 2;
                rwd17.BorderColor = System.Drawing.Color.SlateGray;
                rwd17.BackColor = System.Drawing.Color.White;


                TableCell tcellhbaa2i = new TableCell();
                tcellhbaa2i.BorderWidth = 1;
                tcellhbaa2i.Font.Bold = true;
                //tcellhbaa2i.Attributes.Add("colspan", "1");
                tcellhbaa2i.Style["Text-align"] = "left";
                tcellhbaa2i.Text = "HBA2Inst";
                tcellhbaa2i.ForeColor = System.Drawing.Color.Black;
                rwd17.Cells.Add(tcellhbaa2i);


                for (i = 0; i <= hba2iinstval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = hba2iinstval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd17.Cells.Add(tcell12);

                }
                TableCell tcelltothba2ad = new TableCell();
                tcelltothba2ad.BorderWidth = 1;
                tcelltothba2ad.Attributes.Add("colspan", "1");
                tcelltothba2ad.Style["Text-align"] = "left";
                tcelltothba2ad.Text = hba2iitot().ToString();
                tcelltothba2ad.ForeColor = System.Drawing.Color.Black;
                rwd17.Cells.Add(tcelltothba2ad);
                Table3.Rows.Add(rwd17);

                TableRow rwd18 = new TableRow();
                rwd18.Width = Unit.Percentage(100);
                rwd18.BorderWidth = 2;
                rwd18.BorderColor = System.Drawing.Color.SlateGray;
                rwd18.BackColor = System.Drawing.Color.White;


                TableCell tcellhbaa3i = new TableCell();
                tcellhbaa3i.BorderWidth = 1;
                tcellhbaa3i.Font.Bold = true;
                // tcellhbaa3i.Attributes.Add("colspan", "1");
                tcellhbaa3i.Style["Text-align"] = "left";
                tcellhbaa3i.Text = "HBA3Inst";
                tcellhbaa3i.ForeColor = System.Drawing.Color.Black;
                rwd18.Cells.Add(tcellhbaa3i);

                for (i = 0; i <= hba3iinstval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = hba3iinstval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd18.Cells.Add(tcell12);

                }
                TableCell tcelltothba3ad = new TableCell();
                tcelltothba3ad.BorderWidth = 1;
                tcelltothba3ad.Attributes.Add("colspan", "1");
                tcelltothba3ad.Style["Text-align"] = "left";
                tcelltothba3ad.Text = hba3iitot().ToString(); ;
                tcelltothba3ad.ForeColor = System.Drawing.Color.Black;
                rwd18.Cells.Add(tcelltothba3ad);
                Table3.Rows.Add(rwd18);

                TableRow rwd19 = new TableRow();
                rwd19.Width = Unit.Percentage(100);
                rwd19.BorderWidth = 2;
                rwd19.BorderColor = System.Drawing.Color.SlateGray;
                rwd19.BackColor = System.Drawing.Color.White;

                TableCell tcellvehiadv = new TableCell();
                tcellvehiadv.BorderWidth = 1;
                tcellvehiadv.Font.Bold = true;
                // tcellvehiadv.Attributes.Add("colspan", "1");
                tcellvehiadv.Style["Text-align"] = "left";
                tcellvehiadv.Text = "VehAdv";
                tcellvehiadv.ForeColor = System.Drawing.Color.Black;
                rwd19.Cells.Add(tcellvehiadv);

                for (i = 0; i <= vehinstval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = vehinstval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd19.Cells.Add(tcell12);

                }
                TableCell tcelltotvehi = new TableCell();
                tcelltotvehi.BorderWidth = 1;
                tcelltotvehi.Attributes.Add("colspan", "1");
                tcelltotvehi.Style["Text-align"] = "left";
                tcelltotvehi.Text = vehitot().ToString();
                tcelltotvehi.ForeColor = System.Drawing.Color.Black;
                rwd19.Cells.Add(tcelltotvehi);
                Table3.Rows.Add(rwd19);

                TableRow rwd20 = new TableRow();
                rwd20.Width = Unit.Percentage(100);
                rwd20.BorderWidth = 2;
                rwd20.BorderColor = System.Drawing.Color.SlateGray;
                rwd20.BackColor = System.Drawing.Color.White;

                TableCell tcellvehiadvin = new TableCell();
                tcellvehiadvin.BorderWidth = 1;
                tcellvehiadvin.Font.Bold = true;
                // tcellvehiadvin.Attributes.Add("colspan", "1");
                tcellvehiadvin.Style["Text-align"] = "left";
                tcellvehiadvin.Text = "VehAdv Inst";
                tcellvehiadvin.ForeColor = System.Drawing.Color.Black;
                rwd20.Cells.Add(tcellvehiadvin);

                for (i = 0; i <= vehiinstval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = vehiinstval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd20.Cells.Add(tcell12);

                }
                TableCell tcelltotvehii = new TableCell();
                tcelltotvehii.BorderWidth = 1;
                tcelltotvehii.Attributes.Add("colspan", "1");
                tcelltotvehii.Style["Text-align"] = "left";
                tcelltotvehii.Text = vehiitot().ToString();
                tcelltotvehii.ForeColor = System.Drawing.Color.Black;
                rwd20.Cells.Add(tcelltotvehii);
                Table3.Rows.Add(rwd20);

                TableRow rwd21 = new TableRow();
                rwd21.Width = Unit.Percentage(100);
                rwd21.BorderWidth = 2;
                rwd21.BorderColor = System.Drawing.Color.SlateGray;
                rwd21.BackColor = System.Drawing.Color.White;

                TableCell tcellcaaradv = new TableCell();
                tcellcaaradv.BorderWidth = 1;
                tcellcaaradv.Font.Bold = true;
                //  tcellcaaradv.Attributes.Add("colspan", "1");
                tcellcaaradv.Style["Text-align"] = "left";
                tcellcaaradv.Text = "CarAdv";
                tcellcaaradv.ForeColor = System.Drawing.Color.Black;
                rwd21.Cells.Add(tcellcaaradv);

                for (i = 0; i <= corinstval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = corinstval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd21.Cells.Add(tcell12);

                }
                TableCell tcelltotcori = new TableCell();
                tcelltotcori.BorderWidth = 1;
                tcelltotcori.Attributes.Add("colspan", "1");
                tcelltotcori.Style["Text-align"] = "left";
                tcelltotcori.Text = coritot().ToString();
                tcelltotcori.ForeColor = System.Drawing.Color.Black;
                rwd21.Cells.Add(tcelltotcori);
                Table3.Rows.Add(rwd21);

                TableRow rwd22 = new TableRow();
                rwd22.Width = Unit.Percentage(100);
                rwd22.BorderWidth = 2;
                rwd22.BorderColor = System.Drawing.Color.SlateGray;
                rwd22.BackColor = System.Drawing.Color.White;

                TableCell tcellcaaradvi = new TableCell();
                tcellcaaradvi.BorderWidth = 1;
                tcellcaaradvi.Font.Bold = true;
                // tcellcaaradvi.Attributes.Add("colspan", "1");
                tcellcaaradvi.Style["Text-align"] = "left";
                tcellcaaradvi.Text = "CarAdv Inst";
                tcellcaaradvi.ForeColor = System.Drawing.Color.Black;
                rwd22.Cells.Add(tcellcaaradvi);

                for (i = 0; i <= coriinstval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = coriinstval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd22.Cells.Add(tcell12);

                }
                TableCell tcelltotcorii = new TableCell();
                tcelltotcorii.BorderWidth = 1;
                tcelltotcorii.Attributes.Add("colspan", "1");
                tcelltotcorii.Style["Text-align"] = "left";
                tcelltotcorii.Text = coriitot().ToString();
                tcelltotcorii.ForeColor = System.Drawing.Color.Black;
                rwd22.Cells.Add(tcelltotcorii);
                Table3.Rows.Add(rwd22);

                TableRow rwd23 = new TableRow();
                rwd23.Width = Unit.Percentage(100);
                rwd23.BorderWidth = 2;
                rwd23.BorderColor = System.Drawing.Color.SlateGray;
                rwd23.BackColor = System.Drawing.Color.White;

                TableCell tcellcomppadv = new TableCell();
                tcellcomppadv.BorderWidth = 1;
                tcellcomppadv.Font.Bold = true;
                // tcellcomppadv.Attributes.Add("colspan", "1");
                tcellcomppadv.Style["Text-align"] = "left";
                tcellcomppadv.Text = "CompAdv";
                tcellcomppadv.ForeColor = System.Drawing.Color.Black;
                rwd23.Cells.Add(tcellcomppadv);

                for (i = 0; i <= Compval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = Compval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd23.Cells.Add(tcell12);

                }
                TableCell tcelltotcomp = new TableCell();
                tcelltotcomp.BorderWidth = 1;
                tcelltotcomp.Attributes.Add("colspan", "1");
                tcelltotcomp.Style["Text-align"] = "left";
                tcelltotcomp.Text = comptot().ToString();
                tcelltotcomp.ForeColor = System.Drawing.Color.Black;
                rwd23.Cells.Add(tcelltotcomp);
                Table3.Rows.Add(rwd23);

                TableRow rwd24 = new TableRow();
                rwd24.Width = Unit.Percentage(100);
                rwd24.BorderWidth = 2;
                rwd24.BorderColor = System.Drawing.Color.SlateGray;
                rwd24.BackColor = System.Drawing.Color.White;

                TableCell tcellsoci = new TableCell();
                tcellsoci.BorderWidth = 1;
                tcellsoci.Font.Bold = true;
                //  tcellsoci.Attributes.Add("colspan", "1");
                tcellsoci.Style["Text-align"] = "left";
                tcellsoci.Text = "Society";
                tcellsoci.ForeColor = System.Drawing.Color.Black;
                rwd24.Cells.Add(tcellsoci);

                for (i = 0; i <= societyval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = societyval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd24.Cells.Add(tcell12);

                }
                TableCell tcelltotsociety = new TableCell();
                tcelltotsociety.BorderWidth = 1;
                tcelltotsociety.Attributes.Add("colspan", "1");
                tcelltotsociety.Style["Text-align"] = "left";
                tcelltotsociety.Text = Societytot().ToString();
                tcelltotsociety.ForeColor = System.Drawing.Color.Black;
                rwd24.Cells.Add(tcelltotsociety);
                Table3.Rows.Add(rwd24);

                TableRow rwd25 = new TableRow();
                rwd25.Width = Unit.Percentage(100);
                rwd25.BorderWidth = 2;
                rwd25.BorderColor = System.Drawing.Color.SlateGray;
                rwd25.BackColor = System.Drawing.Color.White;

                TableCell tcelldedd1 = new TableCell();
                tcelldedd1.BorderWidth = 1;
                tcelldedd1.Font.Bold = true;
                // tcelldedd1.Attributes.Add("colspan", "1");
                tcelldedd1.Style["Text-align"] = "left";
                tcelldedd1.Text = "Ded1";
                tcelldedd1.ForeColor = System.Drawing.Color.Black;
                rwd25.Cells.Add(tcelldedd1);

                for (i = 0; i <= ded1val.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = ded1val[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd25.Cells.Add(tcell12);

                }
                TableCell tcelltotded1 = new TableCell();
                tcelltotded1.BorderWidth = 1;
                tcelltotded1.Attributes.Add("colspan", "1");
                tcelltotded1.Style["Text-align"] = "left";
                tcelltotded1.Text = ded1tot().ToString();
                tcelltotded1.ForeColor = System.Drawing.Color.Black;
                rwd25.Cells.Add(tcelltotded1);
                Table3.Rows.Add(rwd25);

                TableRow rwd26 = new TableRow();
                rwd26.Width = Unit.Percentage(100);
                rwd26.BorderWidth = 2;
                rwd26.BorderColor = System.Drawing.Color.SlateGray;
                rwd26.BackColor = System.Drawing.Color.White;

                TableCell tcelldedd2 = new TableCell();
                tcelldedd2.BorderWidth = 1;
                tcelldedd2.Font.Bold = true;
                // tcelldedd2.Attributes.Add("colspan", "1");
                tcelldedd2.Style["Text-align"] = "left";
                tcelldedd2.Text = "Ded2";
                tcelldedd2.ForeColor = System.Drawing.Color.Black;
                rwd26.Cells.Add(tcelldedd2);

                for (i = 0; i <= ded2val.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = ded2val[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd26.Cells.Add(tcell12);

                }
                TableCell tcelltotded2 = new TableCell();
                tcelltotded2.BorderWidth = 1;
                tcelltotded2.Attributes.Add("colspan", "1");
                tcelltotded2.Style["Text-align"] = "left";
                tcelltotded2.Text = ded2tot().ToString();
                tcelltotded2.ForeColor = System.Drawing.Color.Black;
                rwd26.Cells.Add(tcelltotded2);
                Table3.Rows.Add(rwd26);

                TableRow rwd27 = new TableRow();
                rwd27.Width = Unit.Percentage(100);
                rwd27.BorderWidth = 2;
                rwd27.BorderColor = System.Drawing.Color.SlateGray;
                rwd27.BackColor = System.Drawing.Color.White;

                TableCell tcelldedd3 = new TableCell();
                tcelldedd3.BorderWidth = 1;
                tcelldedd3.Font.Bold = true;
                //tcelldedd3.Attributes.Add("colspan", "1");
                tcelldedd3.Style["Text-align"] = "left";
                tcelldedd3.Text = "Ded3";
                tcelldedd3.ForeColor = System.Drawing.Color.Black;
                rwd27.Cells.Add(tcelldedd3);

                for (i = 0; i <= ded3val.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = ded3val[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd27.Cells.Add(tcell12);

                }
                TableCell tcelltotded3 = new TableCell();
                tcelltotded3.BorderWidth = 1;
                tcelltotded3.Attributes.Add("colspan", "1");
                tcelltotded3.Style["Text-align"] = "left";
                tcelltotded3.Text = ded3tot().ToString();
                tcelltotded3.ForeColor = System.Drawing.Color.Black;
                rwd27.Cells.Add(tcelltotded3);
                Table3.Rows.Add(rwd27);

                TableRow rwd28 = new TableRow();
                rwd28.Width = Unit.Percentage(100);
                rwd28.BorderWidth = 2;
                rwd28.BorderColor = System.Drawing.Color.SlateGray;
                rwd28.BackColor = System.Drawing.Color.White;

                TableCell tcellsocdedd = new TableCell();
                tcellsocdedd.BorderWidth = 1;
                tcellsocdedd.Font.Bold = true;
                // tcellsocdedd.Attributes.Add("colspan", "1");
                tcellsocdedd.Style["Text-align"] = "left";
                tcellsocdedd.Text = "SocDed";
                tcellsocdedd.ForeColor = System.Drawing.Color.Black;
                rwd28.Cells.Add(tcellsocdedd);

                for (i = 0; i <= socdedval.Count - 1; i++)
                {
                    TableCell tcell12 = new TableCell();
                    tcell12.BorderWidth = 1;
                    tcell12.Attributes.Add("colspan", "1");
                    tcell12.Style["Text-align"] = "left";
                    tcell12.Text = socdedval[i].ToString();
                    tcell12.ForeColor = System.Drawing.Color.Black;
                    rwd28.Cells.Add(tcell12);

                }
                TableCell tcelltotsocded = new TableCell();
                tcelltotsocded.BorderWidth = 1;
                tcelltotsocded.Attributes.Add("colspan", "1");
                tcelltotsocded.Style["Text-align"] = "left";
                tcelltotsocded.Text = socdedtot().ToString();
                tcelltotsocded.ForeColor = System.Drawing.Color.Black;
                rwd28.Cells.Add(tcelltotsocded);
                Table3.Rows.Add(rwd28);

                TableRow rwd29 = new TableRow();
                rwd29.Width = Unit.Percentage(100);
                rwd29.BorderWidth = 2;
                rwd29.BorderColor = System.Drawing.Color.SlateGray;
                rwd29.BackColor = System.Drawing.Color.LightBlue;

                TableCell tcelltottded = new TableCell();
                tcelltottded.BorderWidth = 1;
                tcelltottded.Font.Bold = true;
                //  tcelltottded.Attributes.Add("colspan", "1");
                tcelltottded.Style["Text-align"] = "left";
                tcelltottded.Text = "Total";
                tcelltottded.ForeColor = System.Drawing.Color.Black;
                rwd29.Cells.Add(tcelltottded);

                for (i = 0; i <= totmonthded.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = totmonthded[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.DarkMagenta;
                    rwd29.Cells.Add(tcell13);

                }


                TableCell tcelltotalded = new TableCell();
                tcelltotalded.BorderWidth = 1;
                tcelltotalded.Attributes.Add("colspan", "1");
                tcelltotalded.Style["Text-align"] = "left";
                tcelltotalded.Text = totaldedu().ToString();
                tcelltotalded.ForeColor = System.Drawing.Color.DarkMagenta;
                tcelltotalded.BackColor = System.Drawing.Color.LightBlue;
                rwd29.Cells.Add(tcelltotalded);
                Table3.Rows.Add(rwd29);

                TableRow rwd30 = new TableRow();
                rwd30.Width = Unit.Percentage(100);
                rwd30.BorderWidth = 2;
                rwd30.BorderColor = System.Drawing.Color.SlateGray;
                rwd30.BackColor = System.Drawing.Color.CadetBlue;

                TableCell tcellnett = new TableCell();
                tcellnett.BorderWidth = 1;
                tcellnett.Font.Bold = true;
                // tcellnett.Attributes.Add("colspan", "1");
                tcellnett.Style["Text-align"] = "left";
                tcellnett.Text = "NetSalary";
                tcellnett.ForeColor = System.Drawing.Color.Black;
                rwd30.Cells.Add(tcellnett);

                for (i = 0; i <= monthlynetsal.Count - 1; i++)
                {
                    TableCell tcell13 = new TableCell();
                    tcell13.BorderWidth = 1;
                    tcell13.Attributes.Add("colspan", "1");
                    tcell13.Style["Text-align"] = "left";
                    tcell13.Text = monthlynetsal[i].ToString();
                    tcell13.ForeColor = System.Drawing.Color.Maroon;
                    rwd30.Cells.Add(tcell13);

                }


                TableCell tcellnetearded = new TableCell();
                tcellnetearded.BorderWidth = 1;
                tcellnetearded.Attributes.Add("colspan", "1");
                tcellnetearded.Style["Text-align"] = "left";
                tcellnetearded.Text = netsalary().ToString();
                tcellnetearded.ForeColor = System.Drawing.Color.Maroon;
                tcellnetearded.BackColor = System.Drawing.Color.CadetBlue;
                rwd30.Cells.Add(tcellnetearded);
                Table3.Rows.Add(rwd30);

                Lblnet.Text = netsalary().ToString();


            }

            else
            {
                lblerr.Visible = true;
                lblerr.Text = "No Record found";
            }
            cl.upcon.Close();
        }
        public string retWord(int number)
        {

            if (number == 0) return "Zero";



            int[] num = new int[4];

            int first = 0;

            int u, h, t;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {

                sb.Append("Minus ");

                number = -number;

            }

            string[] words0 = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven ", "Eight ", "Nine " };

            string[] words = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };

            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

            string[] words3 = { " Thousand ", " Lakh ", " Crore " };

            num[0] = number % 1000; // units

            num[1] = number / 1000;

            num[2] = number / 100000;

            num[1] = num[1] - 100 * num[2]; // thousands

            num[3] = number / 10000000; // crores

            num[2] = num[2] - 100 * num[3]; // lakhs



            for (int i = 3; i > 0; i--)
            {

                if (num[i] != 0)
                {

                    first = i;

                    break;

                }

            }

            for (int i = first; i >= 0; i--)
            {

                if (num[i] == 0) continue;

                u = num[i] % 10; // ones

                t = num[i] / 10;

                h = num[i] / 100; // hundreds

                t = t - 10 * h; // tens

                if (h > 0)

                    sb.Append(words0[h] + " Hundred ");

                if (u > 0 || t > 0)

                    if (h > 0 || i == 0) sb.Append("and ");

                if (t == 0)

                    sb.Append(words0[u]);

                else if (t == 1)

                    sb.Append(words[u]);

                else

                    sb.Append(words2[t - 2] + words0[u]);



                if (i != 0) sb.Append(words3[i - 1]);


            }
            return sb.ToString().TrimEnd();

        }
        protected int basictot()
        {
            int totbasic = 0;
            for (i = 0; i <= basicval.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(basicval[i]);

            }
            return totbasic;
        }
        protected int gradepaytot()
        {
            int totgrade = 0;
            for (i = 0; i <= gradeval.Count - 1; i++)
            {
                totgrade += Convert.ToInt32(gradeval[i]);

            }
            return totgrade;
        }
        protected int npatot()
        {
            int totnpa = 0;
            for (i = 0; i <= npaval.Count - 1; i++)
            {
                totnpa += Convert.ToInt32(npaval[i]);

            }
            return totnpa;
        }
        protected int dapaytot()
        {
            int totdapay = 0;
            for (i = 0; i <= dapayval.Count - 1; i++)
            {
                totdapay += Convert.ToInt32(dapayval[i]);

            }
            return totdapay;
        }
        protected int hratot()
        {
            int tothra = 0;
            for (i = 0; i <= hraval.Count - 1; i++)
            {
                tothra += Convert.ToInt32(hraval[i]);

            }
            return tothra;
        }
        protected int ccatot()
        {
            int totcca = 0;
            for (i = 0; i <= ccaval.Count - 1; i++)
            {
                totcca += Convert.ToInt32(ccaval[i]);

            }
            return totcca;
        }
        protected int perpaytot()
        {
            int totperpay = 0;
            for (i = 0; i <= perpayval.Count - 1; i++)
            {
                totperpay += Convert.ToInt32(perpayval[i]);

            }
            return totperpay;
        }
        protected int tpaytot()
        {
            int tottpay = 0;
            for (i = 0; i <= tpayval.Count - 1; i++)
            {
                tottpay += Convert.ToInt32(tpayval[i]);

            }
            return tottpay;
        }
        protected int sppaytot()
        {
            int totsppay = 0;
            for (i = 0; i <= sppayval.Count - 1; i++)
            {
                totsppay += Convert.ToInt32(sppayval[i]);

            }
            return totsppay;
        }
        protected int pensionpaytot()
        {
            int totpensionpay = 0;
            for (i = 0; i <= pensionval.Count - 1; i++)
            {
                totpensionpay += Convert.ToInt32(pensionval[i]);

            }
            return totpensionpay;
        }
        protected int othall1tot()
        {
            int totothall1 = 0;
            for (i = 0; i <= othall1val.Count - 1; i++)
            {
                totothall1 += Convert.ToInt32(othall1val[i]);

            }
            return totothall1;
        }
        protected int othall2tot()
        {
            int totbasic = 0;
            for (i = 0; i <= othall2val.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(othall2val[i]);

            }
            return totbasic;
        }
        protected int othall3tot()
        {
            int totbasic = 0;
            for (i = 0; i <= othall3val.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(othall3val[i]);

            }
            return totbasic;
        }
        protected int othall4tot()
        {
            int totbasic = 0;
            for (i = 0; i <= othall4val.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(othall4val[i]);

            }
            return totbasic;
        }
        protected int othall5tot()
        {
            int totbasic = 0;
            for (i = 0; i <= othall5val.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(othall5val[i]);

            }
            return totbasic;
        }
        protected int othall6tot()
        {
            int totbasic = 0;
            for (i = 0; i <= othall6val.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(othall6val[i]);

            }
            return totbasic;
        }
        protected int fixall1tot()
        {
            int totbasic = 0;
            for (i = 0; i <= fixall1val.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(fixall1val[i]);

            }
            return totbasic;
        }
        protected int fixall2tot()
        {
            int totbasic = 0;
            for (i = 0; i <= fixall2val.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(fixall2val[i]);

            }
            return totbasic;
        }
        protected int fixall3tot()
        {
            int totbasic = 0;
            for (i = 0; i <= fixall3val.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(fixall3val[i]);

            }
            return totbasic;
        }
        protected int hilltot()
        {
            int totbasic = 0;
            for (i = 0; i <= hillval.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(hillval[i]);

            }
            return totbasic;
        }
        protected int salarreartot()
        {
            int totbasic = 0;
            for (i = 0; i <= salalrrearval.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(salalrrearval[i]);

            }
            return totbasic;
        }
        protected int otharreartot()
        {
            int totbasic = 0;
            for (i = 0; i <= otharrearval.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(otharrearval[i]);

            }
            return totbasic;
        }
        protected int saldedtot()
        {
            int totbasic = 0;
            for (i = 0; i <= saldedval.Count - 1; i++)
            {
                totbasic += Convert.ToInt32(saldedval[i]);

            }
            return totbasic;
        }
        protected int totalearningg()
        {
            int totear = 0;
            for (i = 0; i <= totmonthear.Count - 1; i++)
            {
                totear += Convert.ToInt32(totmonthear[i]);

            }
            return totear;
        }
        protected int totaldedu()
        {
            int total = 0;
            for (i = 0; i <= totmonthded.Count - 1; i++)
            {
                total += Convert.ToInt32(totmonthded[i]);

            }
            return total;
        }
        protected int netsalary()
        {
            int net = Convert.ToInt32(totalearningg()) - Convert.ToInt32(totaldedu());

            LblNetSalWord.Text = " (Rupees " + retWord(net) + " only) ";
            return net;
        }
        protected int gpftot()
        {
            int total = 0;
            for (i = 0; i <= gpfval.Count - 1; i++)
            {
                total += Convert.ToInt32(gpfval[i]);

            }
            return total;
        }

        protected int gisitot()
        {
            int total = 0;
            for (i = 0; i <= gisival.Count - 1; i++)
            {
                total += Convert.ToInt32(gisival[i]);

            }
            return total;
        }
        protected int gisstot()
        {
            int total = 0;
            for (i = 0; i <= gissval.Count - 1; i++)
            {
                total += Convert.ToInt32(gissval[i]);

            }
            return total;
        }
        protected int ITtot()
        {
            int total = 0;
            for (i = 0; i <= incometaxval.Count - 1; i++)
            {
                total += Convert.ToInt32(incometaxval[i]);

            }
            return total;
        }
        protected int gvrtot()
        {
            int total = 0;
            for (i = 0; i <= gvrval.Count - 1; i++)
            {
                total += Convert.ToInt32(gvrval[i]);

            }
            return total;
        }

        protected int hrrtot()
        {
            int total = 0;
            for (i = 0; i <= hrrval.Count - 1; i++)
            {
                total += Convert.ToInt32(hrrval[i]);

            }
            return total;
        }
        protected int paydedtot()
        {
            int total = 0;
            for (i = 0; i <= paydedval.Count - 1; i++)
            {
                total += Convert.ToInt32(paydedval[i]);

            }
            return total;
        }

        protected int gpfinsttot()
        {
            int total = 0;
            for (i = 0; i <= gpfinstval.Count - 1; i++)
            {
                total += Convert.ToInt32(gpfinstval[i]);

            }
            return total;
        }
        protected int plitot()
        {
            int total = 0;
            for (i = 0; i <= plival.Count - 1; i++)
            {
                total += Convert.ToInt32(plival[i]);

            }
            return total;
        }

        protected int elecbilltot()
        {
            int total = 0;
            for (i = 0; i <= elecbillval.Count - 1; i++)
            {
                total += Convert.ToInt32(elecbillval[i]);

            }
            return total;
        }

        protected int licrdtot()
        {
            int total = 0;
            for (i = 0; i <= Licrdval.Count - 1; i++)
            {
                total += Convert.ToInt32(Licrdval[i]);

            }
            return total;
        }

        protected int hba1itot()
        {
            int total = 0;
            for (i = 0; i <= hba1instval.Count - 1; i++)
            {
                total += Convert.ToInt32(hba1instval[i]);

            }
            return total;
        }
        protected int hba2itot()
        {
            int total = 0;
            for (i = 0; i <= hba2instval.Count - 1; i++)
            {
                total += Convert.ToInt32(hba2instval[i]);

            }
            return total;
        }

        protected int hba3itot()
        {
            int total = 0;
            for (i = 0; i <= hba3instval.Count - 1; i++)
            {
                total += Convert.ToInt32(hba3instval[i]);

            }
            return total;
        }

        protected int hba1iitot()
        {
            int total = 0;
            for (i = 0; i <= hba1iinstval.Count - 1; i++)
            {
                total += Convert.ToInt32(hba1iinstval[i]);

            }
            return total;
        }
        protected int hba2iitot()
        {
            int total = 0;
            for (i = 0; i <= hba2iinstval.Count - 1; i++)
            {
                total += Convert.ToInt32(hba2iinstval[i]);

            }
            return total;
        }

        protected int hba3iitot()
        {
            int total = 0;
            for (i = 0; i <= hba3iinstval.Count - 1; i++)
            {
                total += Convert.ToInt32(hba3iinstval[i]);

            }
            return total;
        }
        protected int vehitot()
        {
            int total = 0;
            for (i = 0; i <= vehinstval.Count - 1; i++)
            {
                total += Convert.ToInt32(vehinstval[i]);

            }
            return total;
        }
        protected int vehiitot()
        {
            int total = 0;
            for (i = 0; i <= vehiinstval.Count - 1; i++)
            {
                total += Convert.ToInt32(vehiinstval[i]);

            }
            return total;
        }
        protected int coritot()
        {
            int total = 0;
            for (i = 0; i <= corinstval.Count - 1; i++)
            {
                total += Convert.ToInt32(corinstval[i]);

            }
            return total;
        }
        protected int coriitot()
        {
            int total = 0;
            for (i = 0; i <= coriinstval.Count - 1; i++)
            {
                total += Convert.ToInt32(coriinstval[i]);

            }
            return total;
        }
        protected int comptot()
        {
            int total = 0;
            for (i = 0; i <= Compval.Count - 1; i++)
            {
                total += Convert.ToInt32(Compval[i]);

            }
            return total;
        }
        protected int Societytot()
        {
            int total = 0;
            for (i = 0; i <= societyval.Count - 1; i++)
            {
                total += Convert.ToInt32(societyval[i]);

            }
            return total;
        }
        protected int ded1tot()
        {
            int total = 0;
            for (i = 0; i <= ded1val.Count - 1; i++)
            {
                total += Convert.ToInt32(ded1val[i]);

            }
            return total;
        }
        protected int ded2tot()
        {
            int total = 0;
            for (i = 0; i <= ded2val.Count - 1; i++)
            {
                total += Convert.ToInt32(ded2val[i]);

            }
            return total;
        }
        protected int ded3tot()
        {
            int total = 0;
            for (i = 0; i <= ded3val.Count - 1; i++)
            {
                total += Convert.ToInt32(ded3val[i]);

            }
            return total;
        }
        protected int socdedtot()
        {
            int total = 0;
            for (i = 0; i <= socdedval.Count - 1; i++)
            {
                total += Convert.ToInt32(socdedval[i]);

            }
            return total;
        }
   

    }
}