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
using System.Globalization;
using System.Threading;

namespace NewWebApp.paramedicalstaff
{
    public partial class P2print : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data();
                study();
                //runtable();
                runpost();
                //otherpost();
                enq();


            }
        }

        public void data()
        {
            this.CMPID.Text = Request.QueryString["idno"];//SELECT     PMDpersonaldetails.gpfno, PMDpersonaldetails.name, PMDpersonaldetails.fathername, PMDpersonaldetails.sex, PMDCadre.cadrename, PMDpersonaldetails.cadresenno, category.category, subcategory.scategory, hospitaldistrict.districtname, CONVERT(char, PMDpersonaldetails.dob, 106) AS dob, CONVERT(char, PMDpersonaldetails.doapp, 106) AS doapp, CONVERT(char, PMDpersonaldetails.dojoining, 106) AS dojoining, CONVERT(char, PMDpersonaldetails.doconfirmation, 106) AS doconfirmation, PMDpersonaldetails.coupleid, PMDpersonaldetails.laddress,  PMDpersonaldetails.paddress FROM         PMDpersonaldetails INNER JOIN category ON PMDpersonaldetails.catid = category.catid INNER JOIN   hospitaldistrict ON PMDpersonaldetails.homedistrictid = hospitaldistrict.districtid INNER JOIN subcategory ON PMDpersonaldetails.scatid = subcategory.scatid INNER JOIN PMDCadre ON PMDpersonaldetails.cadre = PMDCadre.cadreid 
            //cl.ds = cl.DataFill("SELECT     PMDpersonaldetails.gpfno, PMDpersonaldetails.name, PMDpersonaldetails.fathername, PMDpersonaldetails.sex, PMDCadre.cadrename, PMDpersonaldetails.senno, category.category, subcategory.scategory, hospitaldistrict.districtname, CONVERT(char, PMDpersonaldetails.dob, 106) AS dob, CONVERT(char, PMDpersonaldetails.doapp, 106) AS doapp, CONVERT(char, PMDpersonaldetails.dojoining, 106) AS dojoining, CONVERT(char, PMDpersonaldetails.doconfirmation, 106) AS doconfirmation, PMDpersonaldetails.coupleid, PMDpersonaldetails.laddress,  PMDpersonaldetails.paddress,PMDpersonaldetails.remark FROM         PMDpersonaldetails INNER JOIN category ON PMDpersonaldetails.casteid = category.catid INNER JOIN   hospitaldistrict ON PMDpersonaldetails.homedistrictid = hospitaldistrict.districtid INNER JOIN subcategory ON PMDpersonaldetails.disabilityid = subcategory.scatid INNER JOIN PMDCadre ON PMDpersonaldetails.cadreid = PMDCadre.cadreid  where PMDpersonaldetails.idno = '" + Request.QueryString["idno"] + "'  ");

            cl.ds = cl.DataFill("SELECT PMDpersonaldetails.gpfno, PMDpersonaldetails.name, PMDpersonaldetails.fathername, PMDpersonaldetails.sex, PMDCadre.cadrename,pmdfeedingcadre.feedingcadre, PMDpersonaldetails.senno, category.category, pmddisability.disability,  subcategory.scategory, hospitaldistrict.districtname, CONVERT(char, PMDpersonaldetails.dob, 106) AS dob, CONVERT(char,PMDpersonaldetails.doapp, 106) AS doapp, CONVERT(char, PMDpersonaldetails.dojoining, 106) AS dojoining, CONVERT(char, PMDpersonaldetails.doconfirmation,106) AS doconfirmation, PMDpersonaldetails.coupleid, PMDpersonaldetails.laddress, PMDpersonaldetails.paddress, PMDpersonaldetails.remark FROM  PMDpersonaldetails INNER JOIN  category ON PMDpersonaldetails.casteid = category.catid INNER JOIN hospitaldistrict ON PMDpersonaldetails.homedistrictid = hospitaldistrict.districtid INNER JOIN subcategory ON PMDpersonaldetails.disabilityid = subcategory.scatid INNER JOIN PMDCadre ON PMDpersonaldetails.cadreid = PMDCadre.cadreid INNER JOIN pmddisability ON PMDpersonaldetails.disabilityid = pmddisability.id INNER JOIN pmdfeedingcadre ON PMDpersonaldetails.fcadreid = pmdfeedingcadre.fcadreid  where PMDpersonaldetails.idno = '" + Request.QueryString["idno"] + "'");


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
                    FCADREID.Text = cl.ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    FCADREID.Text = "N.A";
                }


                if (!(cl.ds.Tables[0].Rows[0][6].ToString().Equals(System.DBNull.Value)))
                {
                    CSN.Text = cl.ds.Tables[0].Rows[0][6].ToString();

                }
                else
                {
                    CSN.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][7].ToString().Equals(System.DBNull.Value)))
                {
                    CATEGORY.Text = cl.ds.Tables[0].Rows[0][7].ToString();
                }
                else
                {
                    CATEGORY.Text = "N.A";
                }





                if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
                {
                    DISABILITY.Text = cl.ds.Tables[0].Rows[0][8].ToString();
                }
                else
                {
                    DISABILITY.Text = "N.A";
                }
                //////////////////
                if (!(cl.ds.Tables[0].Rows[0][10].ToString().Equals(System.DBNull.Value)))
                {
                    if (cl.ds.Tables[0].Rows[0][10].ToString() == "NONE")
                    {
                        try
                        {

                            cl.ds1 = cl.DataFill2("SELECT     hname FROM         PMDotherhomedistrict where idno = '" + Request.QueryString["idno"] + "'or gpfno='" + Sen.Text + "'  ");
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
                        HDIST.Text = cl.ds.Tables[0].Rows[0][10].ToString();
                    }
                    //HDIST.Text = cl.ds.Tables[0].Rows[0][8].ToString();
                }
                else
                {
                    HDIST.Text = "N.A";
                }
                //if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
                //{
                //    HDIST.Text = cl.ds.Tables[0].Rows[0][8].ToString();
                //}
                //else
                //{
                //    HDIST.Text = "N.A";
                //}
                ////////////////

                if (!(cl.ds.Tables[0].Rows[0][11].ToString().Equals(System.DBNull.Value)))
                {
                    DOB.Text = cl.ds.Tables[0].Rows[0][11].ToString();
                }
                else
                {
                    DOB.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][12].ToString().Equals(System.DBNull.Value)))
                {
                    DOA.Text = cl.ds.Tables[0].Rows[0][12].ToString();
                }

                else
                {
                    DOA.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][13].ToString().Equals(System.DBNull.Value)))
                {
                    DOJ.Text = cl.ds.Tables[0].Rows[0][13].ToString();
                }
                else
                {
                    DOJ.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
                {
                    DOC.Text = cl.ds.Tables[0].Rows[0][14].ToString();
                }
                else
                {
                    DOC.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][15].ToString().Equals(System.DBNull.Value)))
                {

                    CUID.Text = cl.ds.Tables[0].Rows[0][15].ToString();
                    if (CUID.Text == "99")
                    {
                        CUID.Text = "Couple is in other govt Service";
                    }
                    else
                    {
                        CUID.Text = cl.ds.Tables[0].Rows[0][15].ToString();
                    }
                }
                else
                {
                    CUID.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][16].ToString().Equals(System.DBNull.Value)))
                {
                    LA.Text = cl.ds.Tables[0].Rows[0][16].ToString();
                }
                else
                {
                    LA.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][17].ToString().Equals(System.DBNull.Value)))
                {
                    PA.Text = cl.ds.Tables[0].Rows[0][17].ToString();
                }
                else
                {
                    PA.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][18].ToString().Equals(System.DBNull.Value)))
                {
                    Remark.Text = cl.ds.Tables[0].Rows[0][18].ToString();
                }
                else
                {
                    Remark.Text = "N.A";
                }


            }
        }
        public void runtable()
        {
            try
            {//SELECT     PMDhospitaldesignation.designame, hospitaldistrict.districtname, hospitalname.hname, CONVERT(char, PMDpostingdetails.doposting, 103)  AS doposting, CONVERT(char, PMDpostingdetails.dorelieve, 103) AS dorelieve, hospitalname.sno, PMDpostingdetails.doposting AS pd, PMDpostingdetails.dorelieve AS pr, PMDpostingdetails.sno AS psno FROM         PMDpostingdetails INNER JOIN   hospitaldistrict ON PMDpostingdetails.districtid = hospitaldistrict.districtid INNER JOIN  PMDhospitaldesignation ON PMDpostingdetails.postid = PMDhospitaldesignation.desigid LEFT OUTER JOIN  hospitalname ON PMDpostingdetails.poposting = hospitalname.sno WHERE     (PMDpostingdetails.idno = '" + Request.QueryString["idno"] + "') ORDER BY PMDpostingdetails.doposting
                cl.ds = cl.DataFill("SELECT     PMDhospitaldesignation.designame, hospitaldistrict.districtname, hospitalname.hname, CONVERT(char, PMDpostingdetails.doposting, 103)  AS doposting, CONVERT(char, PMDpostingdetails.dorelieve, 103) AS dorelieve, hospitalname.sno, PMDpostingdetails.doposting AS pd, PMDpostingdetails.dorelieve AS pr, PMDpostingdetails.districtid, PMDpostingdetails.poposting, PMDpostingdetails.sno AS ppid FROM         PMDpostingdetails INNER JOIN   hospitaldistrict ON PMDpostingdetails.districtid = hospitaldistrict.districtid INNER JOIN  PMDhospitaldesignation ON PMDpostingdetails.postid = PMDhospitaldesignation.desigid LEFT OUTER JOIN  hospitalname ON PMDpostingdetails.poposting = hospitalname.sno WHERE     (PMDpostingdetails.idno = '" + Request.QueryString["idno"] + "') ORDER BY PMDpostingdetails.doposting");
                int j;
                if (cl.ds.Tables[0].Rows.Count > 0)
                {

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

                            if (cl.ds.Tables[0].Rows[j][8].ToString() == "0" && cl.ds.Tables[0].Rows[j][9].ToString() == "0")
                            {
                                string a = cl.ds.Tables[0].Rows[j][7].ToString();
                                string b = cl.ds.Tables[0].Rows[j][10].ToString();
                                try
                                {
                                    cl.ds1 = cl.DataFill2("SELECT     PMDpostingdetails.sno, PMDotherhospitalposting.hname, PMDpostingdetails.idno, PMDpostingdetails.doposting FROM         PMDpostingdetails INNER JOIN  PMDotherhospitalposting ON PMDpostingdetails.sno = PMDotherhospitalposting.sno WHERE     (PMDotherhospitalposting.sno = '" + Convert.ToInt32(b) + "')AND (PMDpostingdetails.idno = " + Request.QueryString["idno"] + ")");
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

                        //TableCell tcell61 = new TableCell();
                        //tcell61.Text = cl.ds.Tables[0].Rows[j][5].ToString();//dr
                        //tcell61.BorderWidth = 1;
                        //tcell61.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell61.ForeColor = System.Drawing.Color.Black;
                        //rw1.Cells.Add(tcell61);
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

        public void runpost()
        {
            try
            {//
                cl.ds = cl.DataFill("SELECT     PMDhospitaldesignation.designame, hospitaldistrict.districtname, hospitalname.hname, CONVERT(char, PMDpostingdetails.doposting, 103)  AS doposting, CONVERT(char, PMDpostingdetails.dorelieve, 103) AS dorelieve, hospitalname.sno, PMDpostingdetails.doposting AS pd, PMDpostingdetails.dorelieve AS pr, PMDpostingdetails.districtid, PMDpostingdetails.poposting, PMDpostingdetails.sno AS ppid FROM         PMDpostingdetails INNER JOIN   hospitaldistrict ON PMDpostingdetails.districtid = hospitaldistrict.districtid INNER JOIN  PMDhospitaldesignation ON PMDpostingdetails.postid = PMDhospitaldesignation.desigid LEFT OUTER JOIN  hospitalname ON PMDpostingdetails.poposting = hospitalname.sno WHERE     (PMDpostingdetails.idno = '" + Request.QueryString["idno"] + "') ORDER BY PMDpostingdetails.doposting");
                int j;//sno
                if (cl.ds.Tables[0].Rows.Count > 0)
                {

                    TableRow rw = new TableRow();
                    rw.BorderColor = System.Drawing.Color.SlateGray;
                    rw.BackColor = System.Drawing.Color.BurlyWood;
                    rw.ForeColor = System.Drawing.Color.Maroon;
                    rw.BorderWidth = 1;


                    TableCell tcell0 = new TableCell();
                    tcell0.Text = "Sr.No.";
                    tcell0.BorderWidth = 1;
                    tcell0.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell0.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcell0);

                    TableCell tcell2 = new TableCell();
                    tcell2.Text = "Post Name";
                    tcell2.BorderWidth = 1;
                    tcell2.BorderColor = System.Drawing.Color.SlateGray;
                    // tcell2.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell2);

                    TableCell tcell3 = new TableCell();
                    tcell3.Text = "District";
                    tcell3.BorderWidth = 1;
                    tcell3.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell3.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell3);

                    TableCell tcell4 = new TableCell();
                    tcell4.Text = "Hospital Name";
                    tcell4.BorderWidth = 1;
                    tcell4.BorderColor = System.Drawing.Color.SlateGray;
                    // tcell4.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell4);

                    TableCell tcell5 = new TableCell();
                    tcell5.Text = "Date Of Posting";
                    tcell5.BorderWidth = 1;
                    tcell5.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell5.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcell5);

                    TableCell tcell6 = new TableCell();
                    tcell6.Text = "Date Of Releving";
                    tcell6.BorderWidth = 1;
                    tcell6.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell6.ForeColor = System.Drawing.Color.Black;
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
                        //tcell10.ForeColor = System.Drawing.Color.Black;
                        tcell10.Text = Convert.ToString(j + 1);//sr
                        rw1.Cells.Add(tcell10);



                        TableCell tcell21 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][1].ToString().Equals(System.DBNull.Value)))
                        {
                            tcell21.Text = cl.ds.Tables[0].Rows[j][0].ToString();//post
                        }
                        else
                        {
                            tcell21.Text = "NONE";
                        }
                        tcell21.BorderWidth = 1;
                        tcell21.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell21.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell21);

                        TableCell tcell31 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][2].ToString().Equals(System.DBNull.Value)))
                        {
                            tcell31.Text = cl.ds.Tables[0].Rows[j][1].ToString();//district
                        }
                        else
                        {
                            tcell31.Text = "NONE";
                        }
                        tcell31.BorderWidth = 1;
                        tcell31.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell31.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell31);

                        TableCell tcell41 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][2].ToString().Equals(System.DBNull.Value)))//hname
                        {
                            tcell41.Text = cl.ds.Tables[0].Rows[j][2].ToString();

                            if (cl.ds.Tables[0].Rows[j][8].ToString() == "0" && cl.ds.Tables[0].Rows[j][9].ToString() == "0")
                            {
                                string a = cl.ds.Tables[0].Rows[j][7].ToString();
                                string b = cl.ds.Tables[0].Rows[j][10].ToString();
                                try
                                {
                                    cl.ds1 = cl.DataFill2("SELECT     PMDpostingdetails.sno, PMDotherhospitalposting.hname, PMDpostingdetails.idno, PMDpostingdetails.doposting FROM         PMDpostingdetails INNER JOIN  PMDotherhospitalposting ON PMDpostingdetails.sno = PMDotherhospitalposting.sno WHERE     (PMDotherhospitalposting.sno = " + b + ")AND (PMDpostingdetails.idno = " + Request.QueryString["idno"] + ")");
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
                        tcell41.ForeColor = System.Drawing.Color.DarkGreen;
                        rw1.Cells.Add(tcell41);

                        TableCell tcell51 = new TableCell();
                        tcell51.Text = cl.ds.Tables[0].Rows[j][3].ToString();//dp
                        tcell51.BorderWidth = 1;
                        tcell51.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell51.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell51);
                        //Table1.Rows.Add(rw1);

                        TableCell tcell61 = new TableCell();
                        tcell61.Text = cl.ds.Tables[0].Rows[j][4].ToString();//dr
                        tcell61.BorderWidth = 1;
                        tcell61.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell61.ForeColor = System.Drawing.Color.Black;
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


        public void otherpost()
        {
            cl.ds = cl.DataFill("SELECT  designation.designame, post.newpostname, hospitaldistrict.districtname,otherhospitalposting.hname,CONVERT (varchar, postingdetails.doposting, 106) AS doposting, CONVERT (varchar, postingdetails.dorelieve, 106) AS dorelieve,  postingdetails.sno,postingdetails.poposting   FROM personaldetails INNER JOIN postingdetails ON personaldetails.idno = postingdetails.idno INNER JOIN otherhospitalposting ON postingdetails.idno = otherhospitalposting.idno INNER JOIN designation ON postingdetails.Desigid = designation.Desigid INNER JOIN post ON postingdetails.postid = post.newpostid LEFT OUTER JOIN hospitaldistrict ON postingdetails.districtid = hospitaldistrict.districtid  WHERE     (postingdetails.idno =  '" + Request.QueryString["idno"] + "') ORDER BY  otherhospitalposting.hname, year(postingdetails.doposting) , year(postingdetails.dorelieve) DESC");// AND postingdetails.dorelieve IS NULL)");
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
                    tcell10.Text = Convert.ToString(j);
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
            {
                cl.ds = cl.DataFill("SELECT '(' + PMDQualification.QuaName + ',' + PMDspecialization.spname + ')' AS st FROM PMDqual_det INNER JOIN  PMDQualification ON PMDqual_det.qid = PMDQualification.QuaId INNER JOIN  PMDspecialization ON PMDqual_det.sid = PMDspecialization.spid where PMDqual_det.idno ='" + Request.QueryString["idno"] + "'");//
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
                cl.ds = cl.DataFill("SELECT '(' + enqtype +','+ enqstatus + ')' as st FROM  PMDEnquiry where idno ='" + Request.QueryString["idno"] + "'");//
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
                cl.ds = cl.DataFill("SELECT Designation.name, lavel.levelcode, hospitaldistrict.districtname, hospitalname.hname, CONVERT(varchar,Hpostingdetails.doposting,103) as doposting ,CONVERT(varchar,Hpostingdetails.dorelieve,103) as dorelieve FROM         Hpostingdetails INNER JOIN   hospitaldistrict ON Hpostingdetails.districtid = hospitaldistrict.districtid INNER JOIN    hospitalname ON Hpostingdetails.poposting = hospitalname.sno INNER JOIN    Designation ON Hpostingdetails.postid = Designation.Dcode INNER JOIN   lavel ON Hpostingdetails.leval = lavel.levelid WHERE postingdetails.idno ='" + Request.QueryString["idno"] + "' ORDER BY CONVERT(char, Hpostingdetails.doposting, 106)");// AND postingdetails.dorelieve IS NULL)");
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
                        tcell11.Text = Convert.ToString(j);
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