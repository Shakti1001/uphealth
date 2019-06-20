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
    public partial class pmdpayslip : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        int i, j, Count, idno, month, year;
        string Earname, Dedname, fmonth;
        ArrayList Earnamelist, Dednamelist, Earvallist, Dedvallist;

        protected void Page_Load(object sender, EventArgs e)
        {
            idno = Convert.ToInt32(Session["idnum"]);
            month = Convert.ToInt32(Session["Smonth"]);
            fmonth = Session["fsmonth"].ToString();
            year = Convert.ToInt32(Session["Syear"]);

            showpayslip();
        }
        protected void showpayslip()
        {

            cl.upcon.Open();
            cl.ds = cl.DataFill("Select * from pmdcalulatedsalary where idno='" + idno + "' and Smonth='" + month + "'and Syear='" + year + "'");
            Earnamelist = new ArrayList();
            Earvallist = new ArrayList();
            Dednamelist = new ArrayList();
            Dedvallist = new ArrayList();
            Earnamelist.Capacity = 30;
            Earvallist.Capacity = 30;
            Dednamelist.Capacity = 30;
            Dedvallist.Capacity = 30;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {




                cl.dsid = cl.DataFilleid("select  basicpay, Gradepay, npaall, dapay, hra, cca,  perpay, tpay, sppay, pensionpay,  othall1, othall2, othall3, othall4, othall5, othall6, fixall1, fixall2, fixall3, hill, salarrear, otharrear,salded,attendance from pmdcalulatedsalary where idno='" + idno + "' and Smonth='" + month + "'and Syear='" + year + "'");
                cl.dshba = cl.DataFillhba("select  gpf, gisi, giss, incometax, gvr, hrr, payded,Gpfadv, pli, elecbill, Licrd, hba1inst, hba2inst, hba3inst, hba1iinst, hba2iinst, hba3iinst, vehinst, vehiinst, corinst, coriinst, Computer, Society, ded1, ded2, ded3, socded   from pmdcalulatedsalary where idno='" + idno + "' and Smonth='" + month + "'and Syear='" + year + "'");
                for (i = 0; i <= 22; i++)
                {
                    if (cl.dsid.Tables[0].Rows[0][i].ToString().Equals("0") || cl.dsid.Tables[0].Rows[0][i].ToString().Equals(""))
                    {
                    }
                    else
                    {
                        Earname = GetEarname();
                        Earnamelist.Add(Earname);
                        Earvallist.Add(cl.dsid.Tables[0].Rows[0][i].ToString());

                    }

                }
                for (j = 0; j <= 26; j++)
                {

                    if (cl.dshba.Tables[0].Rows[0][j].ToString().Equals("0") || cl.dshba.Tables[0].Rows[0][j].ToString().Equals(""))
                    {
                    }
                    else
                    {
                        Dedname = GetDedname();
                        Dednamelist.Add(Dedname);
                        Dedvallist.Add(cl.dshba.Tables[0].Rows[0][j].ToString());

                    }
                }
                printslip();
                grossearnded();
                cl.upcon.Close();


            }
            else
            {
                Label1.Visible = true;

                Label1.Text = "Salary not Processed for Selected Month & Year,Contact DDo...";
            }


        }
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
        protected void printslip()
        {  ///////////////////////////////istrow

            cl.ds = cl.DataFill("SELECT     pmd_pay_sal_mast.idno, pmd_salaryselect.name, pmd_salaryselect.post, pmd_salaryselect.hname, pmd_salaryselect.districtname, pmd_salaryselect.ddoname, pmd_pay_sal_mast.empltypeid, pmd_pay_sal_mast.scaleid, pmd_pay_sal_mast.headid, pmd_pay_sal_mast.gpfno,  pmd_pay_sal_mast.incstatus, Convert(char,pmd_pay_sal_mast.lastincdate,101)as lastincdate, Convert(char,pmd_pay_sal_mast.incdueon,101) as incdueon, pmd_pay_sal_mast.bankid, pmd_pay_sal_mast.bankaccno, pmd_pay_sal_mast.remarks, isnull(pmd_pay_sal_mast.basicpay,0) as basicpay, pmd_pay_sal_mast.Ehra, pmd_pay_sal_mast.cca, pmd_pay_sal_mast.perpay, pmd_pay_sal_mast.tpay,   pmd_pay_sal_mast.sppay, pmd_pay_sal_mast.gpf, pmd_pay_sal_mast.gisi, pmd_pay_sal_mast.giss, pmd_pay_sal_mast.incometax, pmd_pay_sal_mast.salded, pmd_pay_sal_mast.hrr, pmd_pay_sal_mast.pensionpay, pmd_pay_sal_mast.ddocode,isnull(pmd_pay_sal_mast.Gradepay,0) as Gradepay ,pmd_pay_sal_mast.gvr,isnull(pmd_pay_sal_mast.elecbill,0)as elecbill,pmd_pay_sal_mast.stopsal ,isnull(pmd_pay_sal_mast.rd,0)as rd ,pmd_pay_sal_mast.hrr,isnull(pmd_pay_sal_mast.panno,'')as panno FROM pmd_pay_sal_mast INNER JOIN pmd_salaryselect ON pmd_pay_sal_mast.idno = pmd_salaryselect.idno WHERE pmd_pay_sal_mast.idno ='" + idno + "'");

            /*TableRow rwv1 = new TableRow();
            rwv1.Width = Unit.Percentage(100);
            rwv1.BorderWidth = 0;
            rwv1.BorderColor = System.Drawing.Color.Black;
            rwv1.BackColor = System.Drawing.Color.White;

            TableCell tcellxv1 = new TableCell();
            tcellxv1.Attributes.Add("colspan", "4");

            tcellxv1.BorderWidth = 0;
            tcellxv1.Text = "Department Of Medical Health & Family Welfare ";
            tcellxv1.ForeColor = System.Drawing.Color.Navy;
            tcellxv1.Style["Text-align"] = "Center";
            tcellxv1.BorderColor = System.Drawing.Color.SlateGray;
            rwv1.Cells.Add(tcellxv1);

            Table1.Rows.Add(rwv1);

            TableRow rwv2 = new TableRow();
            rwv2.Width = Unit.Percentage(100);
            rwv2.BorderWidth = 0;
            rwv2.BorderColor = System.Drawing.Color.Black;
            rwv2.BackColor = System.Drawing.Color.White;


            TableCell tcellxv2 = new TableCell();
            tcellxv2.Attributes.Add("colspan", "4");
            tcellxv2.Style["Text-align"] = "Center";
            tcellxv2.BorderWidth = 0;
            tcellxv2.Text = "Govt. Of Uttar Pradesh ";
            tcellxv2.ForeColor = System.Drawing.Color.Navy;
            tcellxv2.BorderColor = System.Drawing.Color.SlateGray;
            rwv2.Cells.Add(tcellxv2);

            Table1.Rows.Add(rwv2);

            TableRow rwv3 = new TableRow();
            rwv3.Width = Unit.Percentage(100);
            rwv3.BorderWidth = 0;
            rwv3.BorderColor = System.Drawing.Color.Black;
            rwv3.BackColor = System.Drawing.Color.White;


            TableCell tcellxv3 = new TableCell();
            tcellxv3.Attributes.Add("colspan", "4");
            tcellxv3.Style["Text-align"] = "Center";
            tcellxv3.BorderWidth = 0;
            tcellxv3.Text = "(Payslip)";
            tcellxv3.ForeColor = System.Drawing.Color.Navy;
            tcellxv3.BorderColor = System.Drawing.Color.SlateGray;
            rwv3.Cells.Add(tcellxv3);

            Table1.Rows.Add(rwv3);

      

            TableRow rw6 = new TableRow();
            rw6.Width = Unit.Percentage(100);

            rw6.BorderWidth = 0;
            rw6.BorderColor = System.Drawing.Color.Black;
            rw6.BackColor = System.Drawing.Color.White;

            TableCell tcellp = new TableCell();
            tcellp.BorderWidth = 0;
            tcellp.Attributes.Add("colspan", "4");
            tcellp.Style["Text-align"] = "left";
            //tcellp.Style["height"] = "100%";
            // tcellp.Text = Label3.Text;
            //Label3.Visible = false;
            tcellp.Font.Bold = true;
            tcellp.ForeColor = System.Drawing.Color.Navy;
            rw6.Cells.Add(tcellp);
            Table1.Rows.Add(rw6);

            TableRow rw7 = new TableRow();
            rw7.Width = Unit.Percentage(100);

            rw7.BorderWidth = 0;
            rw7.BorderColor = System.Drawing.Color.Black;
            rw7.BackColor = System.Drawing.Color.White;

            TableCell tcellq = new TableCell();
            tcellq.BorderWidth = 0;
            tcellq.Attributes.Add("colspan", "4");
            //tcellq.Style["height"] = "100%";
            tcellq.Style["Text-align"] = "left";
            //tcellq.Text = Label2.Text;
            //Label2.Visible = false;
            tcellq.Font.Bold = true;
            tcellq.ForeColor = System.Drawing.Color.Navy;
            rw7.Cells.Add(tcellq);
            Table1.Rows.Add(rw7);*/

            TableRow rw3 = new TableRow();
            rw3.Width = Unit.Percentage(100);
            rw3.BorderWidth = 1;
            rw3.BorderColor = System.Drawing.Color.Black;
            rw3.BackColor = System.Drawing.Color.White;

            TableCell tcell11 = new TableCell();
            tcell11.BorderWidth = 0;
            tcell11.Text = "(CompId)Name";
            tcell11.Style["width"] = "20%";
            tcell11.Style["Text-align"] = "left";
            tcell11.Font.Bold = true;
            tcell11.ForeColor = System.Drawing.Color.Black;
            rw3.Cells.Add(tcell11);

            TableCell tcell22 = new TableCell();
            tcell22.BorderWidth = 0;
            tcell22.Style["width"] = "20%";
            tcell22.Style["Text-align"] = "left";
            tcell22.Text = "(" + cl.ds.Tables[0].Rows[0][0].ToString() + ")" + cl.ds.Tables[0].Rows[0][1].ToString();
            tcell22.Font.Bold = false;
            tcell22.ForeColor = System.Drawing.Color.Black;
            rw3.Cells.Add(tcell22);

            TableCell tcell33x = new TableCell();
            tcell33x.BorderWidth = 0;
            tcell33x.Text = "Month/Year";
            tcell33x.Style["Text-align"] = "left";
            tcell33x.Font.Bold = true;
            tcell33x.ForeColor = System.Drawing.Color.Black;
            rw3.Cells.Add(tcell33x);

            TableCell tcell111x = new TableCell();
            tcell111x.BorderWidth = 0;
            tcell111x.Style["Text-align"] = "left";
            //tcell111x.Text = Drpmon.SelectedItem.ToString() + ", " + "2011";
            tcell111x.Text = fmonth + ", " + year.ToString();
            tcell111x.Font.Bold = false;
            tcell111x.ForeColor = System.Drawing.Color.Black;
            rw3.Cells.Add(tcell111x);

            Table2.Rows.Add(rw3);
            ////////////////////////////////////secondrow

            TableRow rw5 = new TableRow();
            rw5.Width = Unit.Percentage(100);
            rw5.BorderWidth = 0;
            rw5.BorderColor = System.Drawing.Color.Black;
            rw5.BackColor = System.Drawing.Color.White;

            TableCell tcell11a = new TableCell();
            tcell11a.BorderWidth = 0;
            tcell11a.Text = "Designation";
            tcell11a.Style["Text-align"] = "left";
            tcell11.Style["width"] = "25%";
            tcell11a.Font.Bold = true;
            tcell11a.ForeColor = System.Drawing.Color.Black;
            rw5.Cells.Add(tcell11a);

            TableCell tcell22b = new TableCell();
            tcell22b.BorderWidth = 0;
            tcell22b.Style["width"] = "25%";
            tcell22b.Style["Text-align"] = "left";
            tcell22b.Text = cl.ds.Tables[0].Rows[0][2].ToString();
            tcell22b.Font.Bold = false;
            tcell22b.ForeColor = System.Drawing.Color.Black;
            rw5.Cells.Add(tcell22b);

            TableCell tcell222b = new TableCell();
            tcell222b.BorderWidth = 0;
            tcell222b.Style["Text-align"] = "left";
            tcell222b.Text = "Attendence";
            tcell222b.Font.Bold = true;
            tcell222b.ForeColor = System.Drawing.Color.Black;
            rw5.Cells.Add(tcell222b);

            //int stopdays = Convert.ToInt32(cl.ds.Tables[0].Rows[0][33].ToString());
            // int year1 = System.DateTime.Today.Year;
            // int month1 = System.DateTime.Today.Month;
            //int mdays = System.DateTime.DaysInMonth(year1, month1);
            // string att = (mdays - stopdays).ToString();

            TableCell tcell333c = new TableCell();
            tcell333c.BorderWidth = 0;
            tcell333c.Style["Text-align"] = "left";
            // tcell333c.Text = att;
            tcell333c.Text = cl.dsid.Tables[0].Rows[0][23].ToString();
            tcell333c.Font.Bold = false;
            tcell333c.ForeColor = System.Drawing.Color.Black;
            rw5.Cells.Add(tcell333c);

            Table2.Rows.Add(rw5);
            ///////////////////////////////////thirdrow
            TableRow rw4 = new TableRow();
            rw4.Width = Unit.Percentage(100);
            rw4.BorderWidth = 0;
            rw4.BorderColor = System.Drawing.Color.Black;
            rw4.BackColor = System.Drawing.Color.White;

            TableCell tcell33 = new TableCell();
            tcell33.BorderWidth = 0;
            tcell33.Style["Text-align"] = "left";
            tcell33.Text = "Place Of Posting";
            tcell33.Font.Bold = true;
            tcell33.ForeColor = System.Drawing.Color.Black;
            rw4.Cells.Add(tcell33);

            TableCell tcell111 = new TableCell();
            tcell111.BorderWidth = 0;
            tcell111.Style["Text-align"] = "left";
            tcell111.Text = cl.ds.Tables[0].Rows[0][3].ToString();
            tcell111.Font.Bold = false;
            tcell111.ForeColor = System.Drawing.Color.Black;
            rw4.Cells.Add(tcell111);

            TableCell tcellc = new TableCell();
            tcellc.BorderWidth = 0;
            tcellc.Style["Text-align"] = "left";
            tcellc.Text = "DistrictName";
            tcellc.Font.Bold = true;
            tcellc.ForeColor = System.Drawing.Color.Black;
            rw4.Cells.Add(tcellc);

            TableCell tcellaa = new TableCell();
            tcellaa.BorderWidth = 0;
            tcellaa.Style["Text-align"] = "left";
            tcellaa.Text = cl.ds.Tables[0].Rows[0][4].ToString();
            tcellaa.Font.Bold = false;
            tcellaa.ForeColor = System.Drawing.Color.Black;
            rw4.Cells.Add(tcellaa);

            Table2.Rows.Add(rw4);





            /////////////////////////////////finish row

            //////////////////////////////////

            /* TableRow rw2 = new TableRow();
             rw2.Width = Unit.Percentage(100);
             rw2.BorderWidth = 0;
             rw2.BorderColor = System.Drawing.Color.Black;
             rw2.BackColor = System.Drawing.Color.White;

             TableCell tcellx = new TableCell();
             tcellx.BorderWidth = 0;
             tcellx.Attributes.Add("colspan", "2");
             tcellx.Style["Text-align"] = "left";
             tcellx.Text = "Earnings";
             tcellx.Font.Bold = true;
             tcellx.ForeColor = System.Drawing.Color.Navy;
             rw2.Cells.Add(tcellx);

             TableCell tcelly = new TableCell();
             tcelly.BorderWidth = 0;
             tcelly.Attributes.Add("colspan", "2");
             tcelly.Style["Text-align"] = "left";
             tcelly.Text = "Deductions";
             tcelly.Font.Bold = true;
             tcelly.ForeColor = System.Drawing.Color.Navy;
             rw2.Cells.Add(tcelly);

             Table1.Rows.Add(rw2);*/

            if (Earvallist.Count > Dedvallist.Count)
            {
                Count = Earvallist.Count;
            }
            else
            {
                Count = Dedvallist.Count;

            }
            for (i = 0; i <= Count - 1; i++)
            {
                TableRow rw1 = new TableRow();
                rw1.Width = Unit.Percentage(100);
                rw1.BorderWidth = 0;
                rw1.BorderColor = System.Drawing.Color.SlateGray;
                rw1.BackColor = System.Drawing.Color.White;




                TableCell tcell1 = new TableCell();
                tcell1.BorderWidth = 0;
                tcell1.Attributes.Add("colspan", "1");
                tcell1.Style["Text-align"] = "left";
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw1.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.BorderWidth = 0;
                tcell2.Attributes.Add("colspan", "1");
                // tcell2.Style["Text-align"] = "left";
                tcell2.ForeColor = System.Drawing.Color.Black;
                tcell2.Font.Bold = false;
                rw1.Cells.Add(tcell2);

                if (i < Earvallist.Count)
                {
                    tcell1.Text = Earnamelist[i].ToString();
                    tcell2.Text = Earvallist[i].ToString();
                }
                else
                {
                    tcell1.Text = "";
                    tcell2.Text = "";
                }

                TableCell tcell3 = new TableCell();
                tcell3.BorderWidth = 0;
                tcell3.Attributes.Add("colspan", "1");
                tcell3.Style["Text-align"] = "left";
                tcell3.ForeColor = System.Drawing.Color.Black;
                rw1.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.BorderWidth = 0;
                tcell4.Attributes.Add("colspan", "1");
                // tcell4.Style["Text-align"] = "left";
                tcell4.ForeColor = System.Drawing.Color.Black;
                tcell4.Font.Bold = false;
                rw1.Cells.Add(tcell4);

                if (i < Dedvallist.Count)
                {
                    tcell3.Text = Dednamelist[i].ToString();
                    tcell4.Text = Dedvallist[i].ToString();
                }
                else
                {
                    tcell3.Text = "";
                    tcell4.Text = "";
                }

                Table1.Rows.Add(rw1);
            }


        }
        protected void grossearnded()
        {
            cl.dsid = cl.DataFilleid("select sum(isnull(basicpay,0) +isnull(Gradepay,0)+ isnull(npaall,0)+ isnull(dapay,0)+ isnull(hra,0)+ isnull(cca,0)+ isnull(perpay,0) + isnull(tpay,0) + isnull(sppay,0) + isnull(pensionpay,0)+ isnull(othall1,0)+ isnull(othall2,0) + isnull(othall3,0) + isnull(othall4,0) + isnull(othall5,0) + isnull(othall6,0)+ isnull(fixall1,0)+isnull(fixall2,0)+ isnull(fixall3,0)+ isnull(hill,0)+isnull(salarrear,0)+ isnull(otharrear,0)-isnull(salded,0)) as netearning from pmdcalulatedsalary where idno='" + idno + "' and Smonth='" + month + "'and Syear='" + year + "' ");
            cl.dshba = cl.DataFillhba("select  sum(isnull(gpf,0) + isnull(gisi,0) + isnull(giss,0) + isnull(incometax,0) + isnull(gvr,0) + isnull(hrr,0) + isnull(payded,0) + isnull(Gpfadv,0) + isnull(pli,0) + isnull(elecbill,0) + isnull(Licrd,0) + isnull(hba1inst,0) + isnull(hba2inst,0) + isnull(hba3inst,0) + isnull(hba1iinst,0) + isnull(hba2iinst,0) + isnull(hba3iinst,0) + isnull(vehinst,0) + isnull(vehiinst,0) + isnull(corinst,0) + isnull(coriinst,0) + isnull(Computer,0) + isnull(Society,0) + isnull(ded1,0) + isnull(ded2,0) + isnull(ded3,0) + isnull(socded,0)) as netded   from pmdcalulatedsalary where idno='" + idno + "' and Smonth='" + month + "'and Syear='" + year + "' ");

            totearning.Text = cl.dsid.Tables[0].Rows[0][0].ToString();//total earning

            totded.Text = cl.dshba.Tables[0].Rows[0][0].ToString();//total deductions

            int netsal = Convert.ToInt32(cl.dsid.Tables[0].Rows[0][0].ToString()) - Convert.ToInt32(cl.dshba.Tables[0].Rows[0][0].ToString());
            netsalary.Text = netsal.ToString();//net salary
            netsalword.Text = "(Rupees " + retWord(netsal) + " only )";
            /* TableRow rw2 = new TableRow();
             rw2.Width = Unit.Percentage(100);
             rw2.BorderWidth = 0;
             rw2.BorderColor = System.Drawing.Color.Black;
             rw2.BackColor = System.Drawing.Color.White;
        
             TableCell tcell11 = new TableCell();
             tcell11.BorderWidth = 0;
             tcell11.Attributes.Add("colspan", "1");
             tcell11.Style["Text-align"] = "left";
             tcell11.Text = "Gross Salary :";
             tcell11.Font.Bold = true;
             tcell11.ForeColor = System.Drawing.Color.Navy;
             rw2.Cells.Add(tcell11);

             TableCell tcell110 = new TableCell();
             tcell110.BorderWidth = 0;
             tcell110.Attributes.Add("colspan", "1");
             tcell110.Style["Text-align"] = "left";
             tcell110.Text = cl.dsid.Tables[0].Rows[0][0].ToString();
             tcell110.Font.Bold = true;
             tcell110.ForeColor = System.Drawing.Color.Navy;
             rw2.Cells.Add(tcell110);

             TableCell tcell220 = new TableCell();
             tcell220.BorderWidth = 0;
             tcell220.Attributes.Add("colspan", "1");
             tcell220.Style["Text-align"] = "left";
             tcell220.Text = "Total Deduction :";
             tcell220.Font.Bold = true;
             tcell220.ForeColor = System.Drawing.Color.Navy;
             rw2.Cells.Add(tcell220);
             Table1.Rows.Add(rw2);

             TableCell tcell22 = new TableCell();
             tcell22.BorderWidth = 0;
             tcell22.Attributes.Add("colspan", "1");
             tcell22.Style["Text-align"] = "left";
             tcell22.Text = cl.dshba.Tables[0].Rows[0][0].ToString();
             tcell22.Font.Bold = true;
             tcell22.ForeColor = System.Drawing.Color.Navy;
             rw2.Cells.Add(tcell22);
             Table1.Rows.Add(rw2);



             int netsalary = Convert.ToInt32(cl.dsid.Tables[0].Rows[0][0].ToString()) - Convert.ToInt32(cl.dshba.Tables[0].Rows[0][0].ToString());

             TableRow rwvXG = new TableRow();
             rwvXG.Width = Unit.Percentage(100);
             rwvXG.BorderWidth = 0;
             rwvXG.BorderColor = System.Drawing.Color.SlateGray;
             rwvXG.BackColor = System.Drawing.Color.White;

             TableCell tcellxv2G = new TableCell();
             tcellxv2G.Attributes.Add("colspan", "4");
             tcellxv2G.Style["Text-align"] = "left";
             // tcellxv2G.Style["padding-left"] = "17%";
             tcellxv2G.Text = "Net Salary:" + netsalary.ToString();
             tcellxv2G.ForeColor = System.Drawing.Color.Navy;
             rwvXG.Cells.Add(tcellxv2G);

             Table1.Rows.Add(rwvXG);*/





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
    }
}