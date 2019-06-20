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
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace NewWebApp.OldDoctor
{
    public partial class DoctorP2 : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data();
                study();
                runtable();
                //otherpost();
                enq();


            }
        }

        public void data()
        {
            this.CMPID.Text = Request.QueryString["idno"];
            //cl.ds = cl.DataFill("SELECT     Hpersonaldeails31jan14.senno, Hpersonaldeails31jan14.name, Hpersonaldeails31jan14.fathername, Hpersonaldeails31jan14.sex, cadre.cadrename, Hpersonaldeails31jan14.cadresenno, category.category, subcategory.scategory, hospitaldistrict.districtname, CONVERT(varchar, Hpersonaldeails31jan14.dob, 103) AS dob, CONVERT(varchar,Hpersonaldeails31jan14.doapp, 103) AS doapp, CONVERT(varchar, Hpersonaldeails31jan14.dojoining, 103) AS dojoining, CONVERT(varchar,Hpersonaldeails31jan14.doconfirmation, 103) AS doconfirmation, Hpersonaldeails31jan14.couplegpf,  Hpersonaldeails31jan14.laddress, Hpersonaldeails31jan14.paddress FROM  Hpersonaldeails31jan14 INNER JOIN  category ON Hpersonaldeails31jan14.catid = category.catid INNER JOIN cadre ON Hpersonaldeails31jan14.cadreid = cadre.cadreid INNER JOIN  hospitaldistrict ON Hpersonaldeails31jan14.homedistrictid = hospitaldistrict.districtid INNER JOIN subcategory ON Hpersonaldeails31jan14.scatid = subcategory.scatid where Hpersonaldeails31jan14.idno = " + Label1.Text + "  ");//'" + Convert.ToInt32((string)Session["insertid"]) + "'


            //cl.ds = cl.DataFill("SELECT     personaldeails31jan14.senno, personaldeails31jan14.name, personaldeails31jan14.fathername, personaldeails31jan14.sex, cadre.cadrename, personaldeails31jan14.cadresenno, category.category, subcategory.scategory, hospitaldistrict.districtname, CONVERT(char, personaldeails31jan14.dob, 106) AS dob, CONVERT(char,personaldeails31jan14.doapp, 106) AS doapp, CONVERT(char, personaldeails31jan14.dojoining, 106) AS dojoining, CONVERT(char,personaldeails31jan14.doconfirmation, 106) AS doconfirmation, personaldeails31jan14.coupleid,  personaldeails31jan14.laddress, personaldeails31jan14.paddress,dbo.personaldeails31jan14.lavel,personaldeails31jan14.remark,personaldeails31jan14.Doctor_Img FROM  personaldeails31jan14 INNER JOIN  category ON personaldeails31jan14.catid = category.catid INNER JOIN cadre ON personaldeails31jan14.cadre = cadre.cadreid INNER JOIN  hospitaldistrict ON personaldeails31jan14.homedistrictid = hospitaldistrict.districtid INNER JOIN subcategory ON personaldeails31jan14.scatid = subcategory.scatid where personaldeails31jan14.idno = '" + Request.QueryString["idno"] + "'  ");//'" + Convert.ToInt32((string)Session["insertid"]) + "'
            cl.ds = cl.DataFill("SELECT     personaldeails31jan14.senno, personaldeails31jan14.name, personaldeails31jan14.fathername, personaldeails31jan14.sex, cadre.cadrename, personaldeails31jan14.cadresenno, category.category, subcategory.scategory, hospitaldistrict.districtname, CONVERT(char, personaldeails31jan14.dob, 106) AS dob, CONVERT(char,personaldeails31jan14.doapp, 106) AS doapp, CONVERT(char, personaldeails31jan14.dojoining, 106) AS dojoining, CONVERT(char,personaldeails31jan14.doconfirmation, 106) AS doconfirmation, personaldeails31jan14.coupleid,  personaldeails31jan14.laddress, personaldeails31jan14.paddress,dbo.personaldeails31jan14.lavel,personaldeails31jan14.remark FROM  personaldeails31jan14 INNER JOIN  category ON personaldeails31jan14.catid = category.catid INNER JOIN cadre ON personaldeails31jan14.cadre = cadre.cadreid INNER JOIN  hospitaldistrict ON personaldeails31jan14.homedistrictid = hospitaldistrict.districtid INNER JOIN subcategory ON personaldeails31jan14.scatid = subcategory.scatid where personaldeails31jan14.idno = '" + Request.QueryString["idno"] + "'  ");//'" + Convert.ToInt32((string)Session["insertid"]) + "'

            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    Sen.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    //GPF.Text = cl.ds.Tables[0].Columns["senno"].ColumnName.ToString();
                }
                else
                {
                    Sen.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    Name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                    //Name.Text = cl.ds.Tables[0].Columns["name"].ColumnName.ToString();
                }
                else
                {
                    Name.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    FNAME.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    FNAME.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    SEX.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                    if (SEX.Text == "1")
                        SEX.Text = "Female";
                    else
                        SEX.Text = "Male";
                }
                else
                {
                    SEX.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    CADRE.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    CADRE.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][5].ToString().Equals(System.DBNull.Value)))
                {
                    CSN.Text = cl.ds.Tables[0].Rows[0][5].ToString();

                }
                else
                {
                    CSN.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][6].ToString().Equals(System.DBNull.Value)))
                {
                    CATEGORY.Text = cl.ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    CATEGORY.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][7].ToString().Equals(System.DBNull.Value)))
                {
                    SCATEGORY.Text = cl.ds.Tables[0].Rows[0][7].ToString();
                }
                else
                {
                    SCATEGORY.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
                {
                    if (cl.ds.Tables[0].Rows[0][8].ToString() == "NONE")
                    {
                        try
                        {

                            cl.ds1 = cl.DataFill2("SELECT     hname FROM         otherhomedistrict where idno = '" + Request.QueryString["idno"] + "'or senno='" + Sen.Text + "'  ");
                            if (!(cl.ds1.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                            {
                                HDIST.Text = cl.ds1.Tables[0].Rows[0][0].ToString();
                            }
                            else
                            {
                                HDIST.Text = "District Out Of Uttar Pradesh";
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error :" + ex.Message);
                        }

                    }

                    else
                    {
                        HDIST.Text = cl.ds.Tables[0].Rows[0][8].ToString();
                    }
                    //HDIST.Text = cl.ds.Tables[0].Rows[0][8].ToString();
                }
                else
                {
                    HDIST.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][9].ToString().Equals(System.DBNull.Value)))
                {
                    DOB.Text = cl.ds.Tables[0].Rows[0][9].ToString();
                }
                else
                {
                    DOB.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][10].ToString().Equals(System.DBNull.Value)))
                {
                    DOA.Text = cl.ds.Tables[0].Rows[0][10].ToString();
                }

                else
                {
                    DOA.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][11].ToString().Equals(System.DBNull.Value)))
                {
                    DOJ.Text = cl.ds.Tables[0].Rows[0][11].ToString();
                }
                else
                {
                    DOJ.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][12].ToString().Equals(System.DBNull.Value)))
                {
                    DOC.Text = cl.ds.Tables[0].Rows[0][12].ToString();
                }
                else
                {
                    DOC.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][13].ToString().Equals(System.DBNull.Value)))
                {

                    CUID.Text = cl.ds.Tables[0].Rows[0][13].ToString();
                    if (CUID.Text == "99")
                    {
                        CUID.Text = "Couple is in other govt Service";
                    }
                    else
                    {
                        CUID.Text = cl.ds.Tables[0].Rows[0][13].ToString();
                    }
                }
                else
                {
                    CUID.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
                {
                    LA.Text = cl.ds.Tables[0].Rows[0][14].ToString();
                }
                else
                {
                    LA.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][15].ToString().Equals(System.DBNull.Value)))
                {
                    PA.Text = cl.ds.Tables[0].Rows[0][15].ToString();
                }
                else
                {
                    PA.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][16].ToString().Equals(System.DBNull.Value)))
                {
                    Llavel.Text = cl.ds.Tables[0].Rows[0][16].ToString();
                }
                else
                {
                    Llavel.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][17].ToString().Equals(System.DBNull.Value)))
                {
                    Remark.Text = cl.ds.Tables[0].Rows[0][17].ToString();
                }
                else
                {
                    Remark.Text = "";
                }
                //if (!(cl.ds.Tables[0].Rows[0][18].ToString().Equals(System.DBNull.Value)))
                //{
                //    string imgname = cl.ds.Tables[0].Rows[0][18].ToString();

                //    Image1.ImageUrl = "~/Doctors Image/" + imgname;

                //}
                //else
                //{

                //    Image1.ImageUrl = "~/Doctors Image/noimg.jpg";
                //}
            }
        }
        public void runtable()
        {//SELECT     postingdetails31jan1431jan14.sno, designation.designame, post.newpostname, hospitaldistrict.districtname, hospitalname.hname, CONVERT(char, postingdetails31jan1431jan14.doposting, 106) AS doposting, CONVERT(char, postingdetails31jan1431jan14.dorelieve, 106) AS dorelieve, postingdetails31jan14.doposting AS pd, postingdetails31jan14.dorelieve AS pr FROM         postingdetails31jan14 INNER JOIN  hospitaldistrict ON postingdetails31jan14.districtid = hospitaldistrict.districtid INNER JOIN  designation ON postingdetails31jan14.Desigid = designation.Desigid INNER JOIN  post ON postingdetails31jan14.postid = post.newpostid LEFT OUTER JOIN   hospitalname ON postingdetails31jan14.poposting = hospitalname.sno WHERE     (postingdetails31jan14.idno = '" + Request.QueryString["idno"] + "') ORDER BY postingdetails31jan14.doposting
            //cl.ds = cl.DataFill("SELECT     designation.designame, post.newpostname, hospitaldistrict.districtname, hospitalname.hname, CONVERT(varchar, postingdetails31jan14.doposting, 106) AS doposting,CONVERT(varchar, postingdetails31jan14.dorelieve, 106) AS dorelieve, postingdetails31jan14.doposting AS pd, postingdetails31jan14.dorelieve AS pr FROM  postingdetails31jan14 INNER JOIN    hospitaldistrict ON postingdetails31jan14.districtid = hospitaldistrict.districtid INNER JOIN hospitalname ON postingdetails31jan14.poposting = hospitalname.sno INNER JOIN  designation ON postingdetails31jan14.Desigid = designation.Desigid INNER JOIN  post ON postingdetails31jan14.postid = post.newpostid WHERE     (postingdetails31jan14.idno =  '" + Request.QueryString["idno"] + "') ORDER BY postingdetails31jan14.doposting");// AND postingdetails31jan14.dorelieve IS NULL)");// ORDER BY year(postingdetails31jan14.doposting) , year(postingdetails31jan14.dorelieve) DESC
            try
            {//
                cl.ds = cl.DataFill("SELECT     designation.designame, post.newpostname, hospitaldistrict.districtname, hospitalname.hname, CONVERT(char, postingdetails31jan14.doposting, 103) AS doposting, CONVERT(char, postingdetails31jan14.dorelieve, 103) AS dorelieve,hospitalname.sno, postingdetails31jan14.doposting AS pd, postingdetails31jan14.dorelieve AS pr,postingdetails31jan14.districtid, postingdetails31jan14.poposting, postingdetails31jan14.sno AS ppid FROM  postingdetails31jan14 INNER JOIN hospitaldistrict ON postingdetails31jan14.districtid = hospitaldistrict.districtid INNER JOIN designation ON postingdetails31jan14.Desigid = designation.Desigid INNER JOIN post ON postingdetails31jan14.postid = post.newpostid LEFT OUTER JOIN  hospitalname ON postingdetails31jan14.poposting = hospitalname.sno WHERE     (postingdetails31jan14.idno = '" + Request.QueryString["idno"] + "') ORDER BY postingdetails31jan14.doposting");
                int j;
                if (cl.ds.Tables[0].Rows.Count > 0)
                {

                    TableRow rw = new TableRow();
                    //rw.BackColor = System.Drawing.Color.Coral;
                    rw.BorderWidth = 1;
                    rw.Font.Bold = true;
                    rw.BorderColor = System.Drawing.Color.SlateGray;

                    TableCell tcell0 = new TableCell();
                    tcell0.Text = "Sr.No.";
                    tcell0.BorderWidth = 1;
                    tcell0.BorderColor = System.Drawing.Color.SlateGray;
                    tcell0.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell0);


                    TableCell tcell1 = new TableCell();
                    tcell1.Text = "Designation";
                    tcell1.BorderWidth = 1;
                    tcell1.BorderColor = System.Drawing.Color.SlateGray;
                    tcell1.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell1);

                    TableCell tcell2 = new TableCell();
                    tcell2.Text = "Post Name";
                    tcell2.BorderWidth = 1;
                    tcell2.BorderColor = System.Drawing.Color.SlateGray;
                    tcell2.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell2);

                    TableCell tcell3 = new TableCell();
                    tcell3.Text = "District";
                    tcell3.BorderWidth = 1;
                    tcell3.BorderColor = System.Drawing.Color.SlateGray;
                    tcell3.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell3);

                    TableCell tcell4 = new TableCell();
                    tcell4.Text = "Hospital Name";
                    tcell4.BorderWidth = 1;
                    tcell4.BorderColor = System.Drawing.Color.SlateGray;
                    tcell4.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell4);

                    TableCell tcell5 = new TableCell();
                    tcell5.Text = "Date Of Posting";
                    tcell5.BorderWidth = 1;
                    tcell5.BorderColor = System.Drawing.Color.SlateGray;
                    tcell5.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell5);

                    TableCell tcell6 = new TableCell();
                    tcell6.Text = "Date Of Relieving";
                    tcell6.BorderWidth = 1;
                    tcell6.BorderColor = System.Drawing.Color.SlateGray;
                    tcell6.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell6);

                    Table1.Rows.Add(rw);
                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {
                        TableRow rw1 = new TableRow();
                        rw1.BorderWidth = 1;
                        rw1.BorderColor = System.Drawing.Color.SlateGray;

                        TableCell tcell10 = new TableCell();
                        tcell10.BorderWidth = 1;
                        tcell10.BorderColor = System.Drawing.Color.SlateGray;
                        tcell10.ForeColor = System.Drawing.Color.Black;
                        tcell10.Text = Convert.ToString(j + 1);//sr
                        rw1.Cells.Add(tcell10);

                        TableCell tcell11 = new TableCell();
                        tcell11.BorderWidth = 1;
                        tcell11.BorderColor = System.Drawing.Color.SlateGray;
                        tcell11.ForeColor = System.Drawing.Color.Black;
                        if (!(cl.ds.Tables[0].Rows[j][0].ToString().Equals(System.DBNull.Value)))
                        {
                            tcell11.Text = cl.ds.Tables[0].Rows[j][0].ToString();//desig
                        }
                        else
                        {
                            tcell11.Text = "NONE";
                        }
                        rw1.Cells.Add(tcell11);

                        TableCell tcell21 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][1].ToString().Equals(System.DBNull.Value)))
                        {
                            tcell21.Text = cl.ds.Tables[0].Rows[j][1].ToString();//post
                        }
                        else
                        {
                            tcell21.Text = "NONE";
                        }
                        tcell21.BorderWidth = 1;
                        tcell21.BorderColor = System.Drawing.Color.SlateGray;
                        tcell21.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell21);

                        TableCell tcell31 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][2].ToString().Equals(System.DBNull.Value)))
                        {
                            tcell31.Text = cl.ds.Tables[0].Rows[j][2].ToString();//district
                        }
                        else
                        {
                            tcell31.Text = "NONE";
                        }
                        tcell31.BorderWidth = 1;
                        tcell31.BorderColor = System.Drawing.Color.SlateGray;
                        tcell31.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell31);

                        TableCell tcell41 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][3].ToString().Equals(System.DBNull.Value)))//hname
                        {
                            tcell41.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                            ////tcell41.Text = "NONE";
                            //DateTime a = Convert.ToDateTime(cl.ds.Tables[0].Rows[j][4].ToString());
                            ////SqlDataAdapter IM1 = new SqlDataAdapter("SELECT DISTINCT sno, hname, doposting, dorelieve, poposting, districtname FROM fpostother WHERE     (idno = '" + Request.QueryString["idno"] + "') AND (dorelieve = 0)", ClDatabase.ConnectionString);
                            //SqlDataAdapter IM1 = new SqlDataAdapter("SELECT postingdetails31jan14.sno, otherhospitalposting.hname, postingdetails31jan14.idno FROM  postingdetails31jan14 INNER JOIN  otherhospitalposting ON postingdetails31jan14.sno = otherhospitalposting.sno WHERE     (postingdetails31jan14.doposting = '" + a + "')AND (postingdetails31jan14.idno = " + Request.QueryString["idno"] + " ", ClDatabase.ConnectionString);
                            //DataSet d2 = new DataSet();
                            //cl.upcon.Open();
                            //IM1.Fill(d2);
                            //cl.upcon.Close();
                            //if (d2.Tables[0].Rows.Count == 0)
                            //{
                            //    tcell41.Text = "NONE";
                            //}
                            //else
                            //{
                            //    tcell41.Text = d2.Tables[0].Rows[0][2].ToString();
                            //}
                            //DateTime dt = new DateTime(cl.ds.Tables[0].Rows[j][4].ToString());
                            //DateTime utcdt = dt.ToUniversalTime();
                            //String format = "MM/dd/yyyy hh:mm:sszzz";
                            //String str = dt.ToString(format);
                            //String utcstr = utcdt.ToString(format);//tcell41.Text == "" && 
                            if (cl.ds.Tables[0].Rows[j][9].ToString() == "0" && cl.ds.Tables[0].Rows[j][10].ToString() == "0")
                            {
                                string a = cl.ds.Tables[0].Rows[j][7].ToString();
                                string b = cl.ds.Tables[0].Rows[j][11].ToString();
                                //DateTime a = Format(cl.ds.Tables[0].Rows[j][4].ToString("dd-MMM-yyyy"));

                                try
                                {
                                    //CultureInfo en = new CultureInfo("en-US");
                                    //Thread.CurrentThread.CurrentCulture = en;
                                    //DateTime x = DateTime.ParseExact(a, "MM/dd/yyyy hh:mm:ss", en.DateTimeFormat);
                                    // a = DateTime.Parse(a);
                                    //Convert.ToDateTime(cl.ds.Tables[0].Rows[j][4].ToString(), "dd/mm/yyyy")
                                    //DateTime x= DateTime.ParseExact(a, "MM/dd/yyyy hh:mm:ss", en. DateTimeStyles.NoCurrentDateDefault); 
                                    cl.ds1 = cl.DataFill2("SELECT postingdetails31jan14.sno, otherhospitalposting.hname, postingdetails31jan14.idno,postingdetails31jan14.doposting FROM  postingdetails31jan14 INNER JOIN  otherhospitalposting ON postingdetails31jan14.sno = otherhospitalposting.sno WHERE     (postingdetails31jan14.sno= '" + Convert.ToInt32(b) + "')AND (postingdetails31jan14.idno = " + Request.QueryString["idno"] + ")");//Format(Now(), "dd-MMM-yyyy")     + "'//WHERE     (postingdetails31jan14.idno = 70) AND (postingdetails31jan14.sno = 6287)
                                    if (cl.ds1.Tables[0].Rows.Count > 0)
                                    {
                                        tcell41.Text = cl.ds1.Tables[0].Rows[0][1].ToString();
                                    }
                                    else
                                    {
                                        tcell41.Text = "NONE";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Response.Write("Error :" + ex.Message);
                                }
                                finally
                                {
                                }

                            }
                        }
                        else
                        {
                            tcell41.Text = "NONE";
                        }

                        tcell41.BorderWidth = 1;
                        tcell41.BorderColor = System.Drawing.Color.SlateGray;
                        tcell41.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell41);

                        TableCell tcell51 = new TableCell();
                        tcell51.Text = cl.ds.Tables[0].Rows[j][4].ToString();//dp
                        tcell51.BorderWidth = 1;
                        tcell51.BorderColor = System.Drawing.Color.SlateGray;
                        tcell51.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell51);
                        //Table1.Rows.Add(rw1);

                        TableCell tcell61 = new TableCell();
                        tcell61.Text = cl.ds.Tables[0].Rows[j][5].ToString();//dr
                        tcell61.BorderWidth = 1;
                        tcell61.BorderColor = System.Drawing.Color.SlateGray;
                        tcell61.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell61);
                        Table1.Rows.Add(rw1);

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
            }
        }
        public void datess()
        {
            //*****************************************
            //RangeValidator
            //        Regx.ValidationExpression = @"^(([1-9])|(0[1-9])|(1[0-2]))\/((0[1-9])|([1-31]))\/((\d{2})|(\d{4}))$"; 
            //*****************************************
            //        class[C#]
            //        using System;
            //        using System.Globalization;
            //        using System.Threading;

            //        public class TestClass
            //        {
            //        public static void Main()
            //        {
            //            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //            DateTime dt = DateTime.Now;
            //            Console.WriteLine("Today is {0}", DateTime.Now.ToString("d"));

            //            // Increments dt by one day.
            //            dt = dt.AddDays(1);
            //            Console.WriteLine("Tomorrow is {0}", dt.ToString("d"));

            //        }
            //}
            //*****************************************

            //DateTime SubmitDate = new DateTime();
            //System.Globalization.CultureInfo culture = new CultureInfo("en-GB", true);
            //if (DBO.Text.ToString() != "")
            //{
            //    SubmitDate = DateTime.Parse(DBO.Text.ToString(), culture, DateTimeStyles.NoCurrentDateDefault);
            //}

            //if (SubmitDate > DateTime.Now)
            //    Response.Write("The Submission Date is Greater than Current Date");

        }


        public void otherpost()
        {
            cl.ds = cl.DataFill("SELECT  designation.designame, post.newpostname, hospitaldistrict.districtname,otherhospitalposting.hname,CONVERT (varchar, postingdetails31jan14.doposting, 106) AS doposting, CONVERT (varchar, postingdetails31jan14.dorelieve, 106) AS dorelieve,  postingdetails31jan14.sno,postingdetails31jan14.poposting   FROM personaldeails31jan14 INNER JOIN postingdetails31jan14 ON personaldeails31jan14.idno = postingdetails31jan14.idno INNER JOIN otherhospitalposting ON postingdetails31jan14.idno = otherhospitalposting.idno INNER JOIN designation ON postingdetails31jan14.Desigid = designation.Desigid INNER JOIN post ON postingdetails31jan14.postid = post.newpostid LEFT OUTER JOIN hospitaldistrict ON postingdetails31jan14.districtid = hospitaldistrict.districtid  WHERE     (postingdetails31jan14.idno =  '" + Request.QueryString["idno"] + "') ORDER BY  otherhospitalposting.hname, year(postingdetails31jan14.doposting) , year(postingdetails31jan14.dorelieve) DESC");// AND postingdetails31jan14.dorelieve IS NULL)");
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                this.Label2.Visible = true;
                TableRow rw = new TableRow();
                //rw.BackColor = System.Drawing.Color.Coral;
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.SlateGray;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "Sr.No.";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;

                rw.Cells.Add(tcell0);


                TableCell tcell1 = new TableCell();
                tcell1.Text = "Designation";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;

                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Post Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black;

                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "District";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black;

                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Other Hospital Name";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black;

                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Date Of Posting";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;

                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Date Of Releving";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;

                rw.Cells.Add(tcell6);

                Table3.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;

                    TableCell tcell10 = new TableCell();
                    tcell10.BorderWidth = 1;
                    tcell10.BorderColor = System.Drawing.Color.SlateGray;
                    tcell10.ForeColor = System.Drawing.Color.Black;
                    tcell10.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcell10);

                    TableCell tcell11 = new TableCell();
                    tcell11.BorderWidth = 1;
                    tcell11.BorderColor = System.Drawing.Color.SlateGray;
                    tcell11.ForeColor = System.Drawing.Color.Black;
                    tcell11.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    rw1.Cells.Add(tcell11);

                    TableCell tcell21 = new TableCell();
                    tcell21.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcell21.BorderWidth = 1;
                    tcell21.BorderColor = System.Drawing.Color.SlateGray;
                    tcell21.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell21);

                    TableCell tcell31 = new TableCell();
                    tcell31.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcell31.BorderWidth = 1;
                    tcell31.BorderColor = System.Drawing.Color.SlateGray;
                    tcell31.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell31);

                    TableCell tcell41 = new TableCell();
                    tcell41.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcell41.BorderWidth = 1;
                    tcell41.BorderColor = System.Drawing.Color.SlateGray;
                    tcell41.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell41);

                    TableCell tcell51 = new TableCell();
                    tcell51.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcell51.BorderWidth = 1;
                    tcell51.BorderColor = System.Drawing.Color.SlateGray;
                    tcell51.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell51);


                    TableCell tcell61 = new TableCell();
                    tcell61.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    tcell61.BorderWidth = 1;
                    tcell61.BorderColor = System.Drawing.Color.SlateGray;
                    tcell61.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell61);
                    Table3.Rows.Add(rw1);

                }
            }

        }

        public void study()
        {
            //cl.ds = cl.DataFill("SELECT     '(' + Qualification.QuaName + ',' + specialization.spname + ')' AS st FROM qual_det INNER JOIN  Qualification ON qual_det.qid = Qualification.QuaId INNER JOIN  specialization ON qual_det.sid = specialization.spid where qual_det.idno ='" + Request.QueryString["idno"] + "'");//
            try
            {//
                cl.ds = cl.DataFill("SELECT Qualification.QuaName +'(' + specialization.spname + ')' AS st FROM qual_det INNER JOIN  Qualification ON qual_det.qid = Qualification.QuaId INNER JOIN  specialization ON qual_det.sid = specialization.spid where qual_det.idno ='" + Request.QueryString["idno"] + "'");//
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    int j;
                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {
                        if (j == 0)
                        {
                            QD.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                        }
                        else
                        {
                            QD.Text = QD.Text + "," + cl.ds.Tables[0].Rows[j][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
            }
        }

        public void enq()
        {
            try
            {
                cl.ds = cl.DataFill("SELECT '(' + enqtype +','+ enqstatus + ')' as st FROM  Enquiry where idno ='" + Request.QueryString["idno"] + "'");//
                if (cl.ds.Tables[0].Rows.Count > 0)//enqtype + enqstatus
                {
                    int j;
                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {
                        if (j == 0)
                        {
                            Enq.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                        }
                        else
                        {
                            Enq.Text = Enq.Text + "," + cl.ds.Tables[0].Rows[j][0].ToString();
                        }

                    }

                }
                else
                {
                    Enq.Text = "N.A.";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
            }
        }
        public void runqual()
        {

            try
            {
                int j;
                cl.ds = cl.DataFill("SELECT Designation.name, lavel.levelcode, hospitaldistrict.districtname, hospitalname.hname, CONVERT(varchar,Hpostingdetails31jan14.doposting,103) as doposting ,CONVERT(varchar,Hpostingdetails31jan14.dorelieve,103) as dorelieve FROM         Hpostingdetails31jan14 INNER JOIN   hospitaldistrict ON Hpostingdetails31jan14.districtid = hospitaldistrict.districtid INNER JOIN    hospitalname ON Hpostingdetails31jan14.poposting = hospitalname.sno INNER JOIN    Designation ON Hpostingdetails31jan14.postid = Designation.Dcode INNER JOIN   lavel ON Hpostingdetails31jan14.leval = lavel.levelid WHERE postingdetails31jan14.idno ='" + Request.QueryString["idno"] + "' ORDER BY CONVERT(char, Hpostingdetails31jan14.doposting, 106)");// AND postingdetails31jan14.dorelieve IS NULL)");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    TableRow rw = new TableRow();
                    rw.BorderWidth = 1;
                    rw.BorderColor = System.Drawing.Color.Black;
                    TableCell tcell1 = new TableCell();
                    tcell1.Text = "Serial No";
                    tcell1.BorderWidth = 1;
                    tcell1.BorderColor = System.Drawing.Color.Black;
                    tcell1.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcell1);

                    TableCell tcell2 = new TableCell();
                    tcell2.Text = "Name of Degree/Diploma";
                    tcell2.BorderWidth = 1;
                    tcell2.BorderColor = System.Drawing.Color.Black;
                    tcell2.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcell2);

                    TableCell tcell3 = new TableCell();
                    tcell3.Text = "Specialization/Subject";
                    tcell3.BorderWidth = 1;
                    tcell3.BorderColor = System.Drawing.Color.Black;
                    tcell3.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcell3);
                    Table2.Rows.Add(rw);
                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {
                        TableRow rw1 = new TableRow();
                        rw1.BorderWidth = 1;
                        rw1.BorderColor = System.Drawing.Color.Black;
                        TableCell tcell11 = new TableCell();
                        tcell11.BorderWidth = 1;
                        tcell11.BorderColor = System.Drawing.Color.Black;
                        tcell11.ForeColor = System.Drawing.Color.Black;
                        //tcell11.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                        tcell11.Text = Convert.ToString(j + 1);
                        rw1.Cells.Add(tcell11);

                        TableCell tcell21 = new TableCell();
                        tcell21.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                        tcell21.BorderWidth = 1;
                        tcell21.BorderColor = System.Drawing.Color.Black;
                        tcell21.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell21);

                        TableCell tcell31 = new TableCell();
                        tcell31.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                        tcell31.BorderWidth = 1;
                        tcell31.BorderColor = System.Drawing.Color.Black;
                        tcell31.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell31);
                        Table2.Rows.Add(rw1);
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
            }
        }

        protected void Page_unLoad(object sender, EventArgs e)
        {

        }
    }
}