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

namespace NewWebApp.paramedicalstaff
{
    public partial class paraproformachoice : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                ddfill();
            }
        }

        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
            }
        }

        //****************************************************
        //**********************For Choice Order******************************
        public void usecheckD()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
                cl.ds = cl.DataFill("SELECT DISTINCT divid, divname FROM division ORDER BY divname");
                DDiv.DataSource = cl.ds;
                DDiv.DataTextField = "divname";
                DDiv.DataValueField = "divid";
                DDiv.DataBind();
                DDiv.Items.Insert(0, new ListItem("--select--"));

            }
            else
            {
                DDiv.Visible = false;
                DL.Visible = false;
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
            }
        }
        public void ddfill()
        {
            usecheckD();
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where districtid like '" + Uidt.Text + "'  ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid  where hospitaldistrict.districtid like '" + Uidt.Text + "' ORDER BY hospitalname.hname");
            DHname.DataSource = cl.ds;
            DHname.DataTextField = "hname";
            DHname.DataValueField = "sno";
            DHname.DataBind();
            DHname.Items.Insert(0, new ListItem("--select--"));
            //****************        
            cl.ds = cl.DataFill("SELECT distinct(cadrename), cadreid FROM  PMDCadre ORDER BY cadrename");
            DCadre.DataSource = cl.ds;
            DCadre.DataTextField = "cadrename";
            DCadre.DataValueField = "cadreid";
            DCadre.DataBind();
            DCadre.Items.Insert(0, new ListItem("--select--"));
            //***************************        
            cl.ds = cl.DataFill("SELECT     Desigid, designame FROM         PMDhospitaldesignation ORDER BY Desigid");
            Dpost.DataSource = cl.ds;
            Dpost.DataTextField = "designame";
            Dpost.DataValueField = "Desigid";
            Dpost.DataBind();
            Dpost.Items.Insert(0, new ListItem("--select--"));
            //********************SELECT     levelid, levelcode FROM         lavel ORDER BY levelid
            cl.ds = cl.DataFill("SELECT     hid, htype FROM         hospitaltype ORDER BY hid");
            htype.DataSource = cl.ds;
            htype.DataTextField = "htype";
            htype.DataValueField = "hid";
            htype.DataBind();
            htype.Items.Insert(0, new ListItem("--select--"));

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try { runqualC(); }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Write("Sorry For error there is some technical Problem.. Please try after some time");
            }
            finally { }
        }



        public void runqualC()
        {
            //string Dist, DHna, Cmp, post, cad, senno, nam, fnam;//Desig,lav,//this.Divs.Text = "%";
            string q1, q2, q3, q4, q5, q6, q7, q8, qr1, qr2;
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            {
                q1 = "districtid =" + DDistrict.SelectedItem.Value + "";
            }
            else { q1 = "districtid like '%'"; }
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            { q2 = "sno=" + DHname.SelectedItem.Value + ""; }
            else { q2 = "sno like '%'"; }
            //*****************COMPUTER NO**************
            if (this.cmpuno.Text != "")
            { q3 = "idno=" + cmpuno.Text + ""; }
            else { q3 = "idno like '%'"; }
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            { q4 = "postid=" + Dpost.SelectedItem.Value + ""; }
            else { q4 = "postid like '%'"; }
            //***************CADRE****************
            if (this.DCadre.SelectedIndex != 0)
            { q5 = "cadreid=" + DCadre.SelectedItem.Value + ""; }
            else { q5 = "cadreid like '%'"; }
            //***************GPFNO****************
            if (this.htype.SelectedIndex != 0)
            { q6 = "hid='" + htype.SelectedItem.Value + "'"; }
            else { q6 = "hid like '%'"; }


            //***************NAME****************
            if (this.name.Text != "")
            { q7 = "name like '%" + name.Text + "%'"; }
            else { q7 = "name like '%'"; }
            //***************FNAME****************
            if (this.fname.Text != "")
            { q8 = "fathername like '%" + fname.Text + "%'"; }
            else { q8 = "fathername like '%'"; }
            qr1 = " And " + q1 + " And " + q2 + " And " + q3 + " AND " + q4 + " And " + q5 + " and " + q6 + "And " + q7 + " And " + q8 + "";//And " + q9 + "


            qr2 = " And " + q2 + " And " + q3 + " And " + q4 + " And " + q5 + " And " + q7 + " And " + q8 + "";//And " + q9 + "
            bool i;
            i = cl.checklavel((string)Session["iduser"]);


            if (i == true)
            {
                //cl.ds = cl.DataFill("SELECT DISTINCT idno AS ComputerID, gpfno AS Seniority,name AS Name,designame AS Post, districtname AS Posting, hname AS Hospital, fathername AS Fname, Convert(varchar,dob,103) AS DateofBirth,   CONVERT(varchar, doposting, 103) AS DateOfPosting, cadreid AS Cader FROM         parafactsearchCriteria WHERE     (divid LIKE '" + Divs.Text + "')" + qr1 + "order by districtname, name,hname");// AND (DisId LIKE '" + Dist + "')  AND (sno LIKE '" + DHna + "') AND (idno LIKE '" + Cmp + "') AND (gpfno LIKE '" + senno + "') AND (name LIKE '" + nam + "') AND (fathername LIKE '" + fnam + "') AND   (postid LIKE '" + post + "')  AND (cadreid LIKE '" + cad + "')


                cl.ds = cl.DataFill("SELECT DISTINCT idno AS ComputerID, name AS Name,fathername AS Fname, Convert(varchar,dob,103) AS DateofBirth,districtname AS Posting,hname AS Hospital, designame AS Post,     CONVERT(varchar, doposting, 103) AS DateOfPosting FROM  pmd_currentposted WHERE     (divid LIKE '" + Divs.Text + "')" + qr1 + " order by districtname, name,hname");// AND (DisId LIKE '" + Dist + "')  AND (sno LIKE '" + DHna + "') AND (idno LIKE '" + Cmp + "') AND (gpfno LIKE '" + senno + "') AND (name LIKE '" + nam + "') AND (fathername LIKE '" + fnam + "') AND   (postid LIKE '" + post + "')  AND (cadreid LIKE '" + cad + "')

                //Response.Write("SELECT DISTINCT idno AS ComputerID, name AS Name,fathername AS Fname, Convert(varchar,dob,103) AS DateofBirth,districtname AS Posting,hname AS Hospital, designame AS Post,     CONVERT(varchar, doposting, 103) AS DateOfPosting FROM  pmd_currentposted WHERE     (divid LIKE '" + Divs.Text + "')" + qr1 + " order by districtname, name,hname");

            }
            else
            {
                cl.ds = cl.DataFill("SELECT DISTINCT idno AS ComputerID, name AS Name,fathername AS Fname, Convert(varchar,dob,103) AS DateofBirth,  districtname AS Posting,hname AS Hospital, designame AS Post,   CONVERT(varchar, doposting, 103) AS DateOfPosting FROM  pmd_currentposted WHERE (districtid ='" + Uidt.Text + "')" + qr2 + "  order by districtname, name,hname");//AND (sno LIKE '" + DHna + "') AND (idno LIKE '" + Cmp + "') AND (gpfno LIKE '" + senno + "') AND (name LIKE '" + nam + "') AND (fathername LIKE '" + fnam + "') AND (postid LIKE '" + post + "') AND (cadreid LIKE '" + cad + "')







            }
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.SlateGray;
                rw.BackColor = System.Drawing.Color.BurlyWood;
                rw.ForeColor = System.Drawing.Color.Maroon;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                //tcell0.ForeColor = System.Drawing.Color.Gold;
                //tcell0.Font= System.Drawing.FontStyle.Bold;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "ComputerID";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                //tcell1.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell1);
                //TableCell tcell3 = new TableCell();
                //tcell3.Text = "GPF Number";
                //tcell3.BorderWidth = 1;
                //tcell3.BorderColor = System.Drawing.Color.SlateGray;
                ////tcell3.ForeColor = System.Drawing.Color.Gold;
                //rw.Cells.Add(tcell3);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                //tcell2.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell2);


                TableCell tcell4 = new TableCell();
                tcell4.Text = "Fathername";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                //tcell4.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell4);


                TableCell tcell5 = new TableCell();
                tcell5.Text = "DateofBirth";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                //tcell5.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell5);




                TableCell tcell6 = new TableCell();
                tcell6.Text = "District";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell6);


                TableCell tcell7 = new TableCell();
                tcell7.Text = "Posting Place";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                //tcell7.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell7);


                TableCell tcell8 = new TableCell();
                tcell8.Text = "Post";
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                //tcell8.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell8);


                TableCell tcell9 = new TableCell();
                tcell9.Text = "Date Of Posting";
                tcell9.BorderWidth = 1;
                tcell9.BorderColor = System.Drawing.Color.SlateGray;
                //tcell9.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell9);




                TableCell tcell11 = new TableCell();
                tcell11.Text = "View";
                tcell11.BorderWidth = 1;
                tcell11.BorderColor = System.Drawing.Color.SlateGray;
                //tcell11.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell11);







                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.Maroon;
                    rw1.BackColor = System.Drawing.Color.LemonChiffon;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);//sr
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();//cmpno
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][1].ToString();//senno
                    rw1.Cells.Add(tcellk4);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][2].ToString();//name
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    //tcellk3.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][3].ToString();//post
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][4].ToString();//posting hospital
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString(); //district              
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][6].ToString();//Fathers Name
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk9 = new TableCell();
                    tcellk9.Text = cl.ds.Tables[0].Rows[j][7].ToString();//Date of Birth
                    tcellk9.BorderWidth = 1;
                    tcellk9.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk9);

                    //TableCell tcellk10 = new TableCell();
                    //tcellk10.BorderWidth = 1;
                    //tcellk10.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk10.Text = cl.ds.Tables[0].Rows[j][8].ToString(); //posting Date              
                    //rw1.Cells.Add(tcellk10);

                    //TableCell tcellk12 = new TableCell();
                    //tcellk12.Text = cl.ds.Tables[0].Rows[j][9].ToString();//Cader
                    //tcellk12.BorderWidth = 1;
                    //tcellk12.BorderColor = System.Drawing.Color.SlateGray;
                    //rw1.Cells.Add(tcellk12);

                    TableCell tcellk112 = new TableCell();
                    tcellk112.Text = "P2";
                    tcellk112.BorderWidth = 1;
                    tcellk112.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk112);
                    //tcellk112.Text = ("<a href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk112.Text + "</a>")));
                    tcellk112.Text = ("<a target='_blank' href=\'parap2Factsheetprint.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk112.Text + "</a>")));
                    Table1.Rows.Add(rw1);
                }

            }

        }
       
        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDiv.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT DISTINCT districtid,districtname  FROM         hospitaldistrict WHERE     (divid = '" + DDiv.SelectedItem.Value + "') ORDER BY districtname");
                DDistrict.DataSource = cl.ds;
                DDistrict.DataTextField = "districtname";
                DDistrict.DataValueField = "districtid";
                DDistrict.DataBind();
                DDistrict.Items.Insert(0, new ListItem("--select--"));
                this.Divs.Text = "%" + DDiv.SelectedItem.Value + "%";
            }
            else
            {
                this.Divs.Text = "%";
            }

        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDistrict.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid ='" + DDistrict.SelectedItem.Value + "') ORDER BY hospitalname.hname");
                DHname.DataSource = cl.ds;
                DHname.DataTextField = "hname";
                DHname.DataValueField = "sno";
                DHname.DataBind();
                DHname.Items.Insert(0, new ListItem("--select--"));
            }
        }
        protected void DHname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DDesign_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Dpost_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DCadre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Dlevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Refresh_Click(object sender, EventArgs e)
        {

        }
        protected void Sen_TextChanged(object sender, EventArgs e)
        {

        }
        protected void name_TextChanged(object sender, EventArgs e)
        {

        }
        protected void fname_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2ReportOption.aspx");
        }
    }
}