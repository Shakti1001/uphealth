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

namespace NewWebApp.Proforma2
{
    public partial class Proformachoice : System.Web.UI.Page
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
        public void runtablealpha()
        {
            //usecheck();
            //bool i;
            //i = cl.checklavel((string)Session["iduser"]);
            //if (i == true)
            //{
            //    cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM Factsheet WHERE (name LIKE '" + VALT.Text + "')order by districtname, name");

            //}
            //else
            //{
            //    cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno,dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM Factsheet WHERE (DisId ='" + Uidt.Text + "') AND (name LIKE '" + VALT.Text + "')and (postingstatus='J') order by districtname, name ");
            //}
            //int j;
            //if (cl.ds.Tables[0].Rows.Count > 0)
            //{
            //    TableRow rw = new TableRow();
            //    rw.BorderWidth = 1;
            //    rw.BorderColor = System.Drawing.Color.SlateGray;
            //    rw.BackColor = System.Drawing.Color.BurlyWood;
            //    rw.ForeColor = System.Drawing.Color.Maroon;

            //    TableCell tcell0 = new TableCell();
            //    tcell0.Text = "SerialNo";
            //    tcell0.BorderWidth = 1;
            //    tcell0.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell0.ForeColor = System.Drawing.Color.Maroon;
            //    //tcell0.Font= System.Drawing.FontStyle.Bold;
            //    rw.Cells.Add(tcell0);

            //    TableCell tcell1 = new TableCell();
            //    tcell1.Text = "ComputerID";
            //    tcell1.BorderWidth = 1;
            //    tcell1.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell1.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell1);

            //    TableCell tcell2 = new TableCell();
            //    tcell2.Text = "Seniority";
            //    tcell2.BorderWidth = 1;
            //    tcell2.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell2.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell2);

            //    TableCell tcell3 = new TableCell();
            //    tcell3.Text = "Name";
            //    tcell3.BorderWidth = 1;
            //    tcell3.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell3.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell3);

            //    TableCell tcell4 = new TableCell();
            //    tcell4.Text = "DateofBirth";
            //    tcell4.BorderWidth = 1;
            //    tcell4.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell4.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell4);

            //    TableCell tcell5 = new TableCell();
            //    tcell5.Text = "Fathername";
            //    tcell5.BorderWidth = 1;
            //    tcell5.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell5.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell5);

            //    TableCell tcell6 = new TableCell();
            //    tcell6.Text = "Home District";
            //    tcell6.BorderWidth = 1;
            //    tcell6.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell6.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell6);

            //    TableCell tcell7 = new TableCell();
            //    tcell7.Text = "Post";
            //    tcell7.BorderWidth = 1;
            //    tcell7.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell7.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell7);

            //    TableCell tcell8 = new TableCell();
            //    tcell8.Text = "Posting Status";
            //    tcell8.BorderWidth = 1;
            //    tcell8.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell8.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell8);

            //    TableCell tcell9 = new TableCell();
            //    tcell9.Text = "Cadresenno";
            //    tcell9.BorderWidth = 1;
            //    tcell9.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell9.ForeColor = System.Drawing.Color.Maroon;
            //    rw.Cells.Add(tcell9);

            //    TableCell tcell91 = new TableCell();
            //    tcell91.Text = "Print";
            //    tcell91.BorderWidth = 1;
            //    tcell91.BorderColor = System.Drawing.Color.SlateGray;
            //    rw.Cells.Add(tcell91);

            //    Table2.Rows.Add(rw);
            //    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            //    {
            //        TableRow rw1 = new TableRow();
            //        rw1.BorderWidth = 1;
            //        rw1.BorderColor = System.Drawing.Color.SlateGray;
            //        rw1.ForeColor = System.Drawing.Color.Maroon;
            //        rw1.BackColor = System.Drawing.Color.LemonChiffon;

            //        TableCell tcellk1 = new TableCell();
            //        tcellk1.BorderWidth = 1;
            //        tcellk1.BorderColor = System.Drawing.Color.SlateGray;                
            //        tcellk1.Text = Convert.ToString(j+1);
            //        rw1.Cells.Add(tcellk1);

            //        TableCell tcellk2 = new TableCell();
            //        tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();//cmp id
            //        tcellk2.BorderWidth = 1;
            //        tcellk2.BorderColor = System.Drawing.Color.SlateGray;
            //        //tcellk2.ForeColor = System.Drawing.Color.MidnightBlue;
            //        //tcellk2.BackColor = System.Drawing.Color.SlateGray;
            //        rw1.Cells.Add(tcellk2);

            //        TableCell tcellk4 = new TableCell();
            //        tcellk4.BorderWidth = 1;
            //        tcellk4.BorderColor = System.Drawing.Color.SlateGray;
            //        tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
            //        rw1.Cells.Add(tcellk4);
            //        //tcellk4.Text = ("<a href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));


            //        TableCell tcellk3 = new TableCell();
            //        tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
            //        tcellk3.BorderWidth = 1;
            //        tcellk3.BorderColor = System.Drawing.Color.SlateGray;
            //        tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
            //        rw1.Cells.Add(tcellk3);


            //        TableCell tcellk5 = new TableCell();
            //        tcellk5.Text = cl.ds.Tables[0].Rows[j][3].ToString();
            //        tcellk5.BorderWidth = 1;
            //        tcellk5.BorderColor = System.Drawing.Color.SlateGray;                
            //        rw1.Cells.Add(tcellk5);

            //        TableCell tcellk6 = new TableCell();
            //        tcellk6.Text = cl.ds.Tables[0].Rows[j][4].ToString();
            //        tcellk6.BorderWidth = 1;
            //        tcellk6.BorderColor = System.Drawing.Color.SlateGray;                
            //        rw1.Cells.Add(tcellk6);

            //        TableCell tcellk7 = new TableCell();
            //        tcellk7.BorderWidth = 1;
            //        tcellk7.BorderColor = System.Drawing.Color.SlateGray;                
            //        tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
            //        rw1.Cells.Add(tcellk7);

            //        TableCell tcellk8 = new TableCell();
            //        tcellk8.Text = cl.ds.Tables[0].Rows[j][6].ToString();
            //        tcellk8.BorderWidth = 1;
            //        tcellk8.BorderColor = System.Drawing.Color.SlateGray;               
            //        rw1.Cells.Add(tcellk8);

            //        TableCell tcellk9 = new TableCell();
            //        tcellk9.Text = cl.ds.Tables[0].Rows[j][7].ToString();
            //        tcellk9.BorderWidth = 1;
            //        tcellk9.BorderColor = System.Drawing.Color.SlateGray;                
            //        rw1.Cells.Add(tcellk9);

            //        TableCell tcellk10 = new TableCell();
            //        tcellk10.BorderWidth = 1;
            //        tcellk10.BorderColor = System.Drawing.Color.SlateGray;                
            //        tcellk10.Text = cl.ds.Tables[0].Rows[j][8].ToString();
            //        rw1.Cells.Add(tcellk10);

            //        TableCell tcellk110 = new TableCell();
            //        tcellk110.BorderWidth = 1;
            //        tcellk110.BorderColor = System.Drawing.Color.SlateGray;
            //        tcellk110.Text = "Print";
            //        rw1.Cells.Add(tcellk110);
            //        tcellk110.Text = ("<a href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk110.Text + ")</a>")))));


            //        Table2.Rows.Add(rw1);

            //    }
            //}
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
        {//SELECT     divid, divname FROM         division ORDER BY divid
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
          //  cl.ds = cl.DataFill("SELECT spname,spid from specialization");
           // splsearch.DataSource = cl.ds;
            //splsearch.DataTextField = "spname";
            //splsearch.DataValueField = "spid";
           // splsearch.DataBind();
           // splsearch.Items.Insert(0, new ListItem("--select--"));

            //****************
            cl.ds = cl.DataFill("SELECT DISTINCT cadrename, cadreid FROM cadre ORDER BY cadrename");
            DCadre.DataSource = cl.ds;
            DCadre.DataTextField = "cadrename";
            DCadre.DataValueField = "cadreid";
            DCadre.DataBind();
            DCadre.Items.Insert(0, new ListItem("--select--"));
            //***************************
            cl.ds = cl.DataFill("SELECT DISTINCT Desigid,designame  FROM designation ORDER BY designame");
            DDesign.DataSource = cl.ds;
            DDesign.DataTextField = "designame";
            DDesign.DataValueField = "Desigid";
            DDesign.DataBind();
            DDesign.Items.Insert(0, new ListItem("--select--"));
            cl.ds = cl.DataFill("SELECT DISTINCT newpostid, newpostname FROM  post ORDER BY newpostid");
            this.Dpost.DataSource = cl.ds;
            this.Dpost.DataTextField = "newpostname";
            this.Dpost.DataValueField = "newpostid";
            this.Dpost.DataBind();
            this.Dpost.Items.Insert(0, new ListItem("--select--"));
            //********************SELECT     levelid, levelcode FROM         lavel ORDER BY levelid
            cl.ds = cl.DataFill("SELECT distinct levelid, levelcode FROM lavel ORDER BY levelid");
            Dlevel.DataSource = cl.ds;
            Dlevel.DataTextField = "levelcode";
            Dlevel.DataValueField = "levelid";
            Dlevel.DataBind();
            Dlevel.Items.Insert(0, new ListItem("--select--"));

            //**********************Feeding Cadre******************
            cl.ds = cl.DataFill("SELECT DISTINCT fcadrename, fcadreid FROM fcadre ORDER BY fcadrename");
            fcadreddl.DataSource = cl.ds;
            fcadreddl.DataTextField = "fcadrename";
            fcadreddl.DataValueField = "fcadreid";
            fcadreddl.DataBind();
            fcadreddl.Items.Insert(0, new ListItem("--select--"));

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                mess.Visible = false;
                runqual();
            }
            catch (Exception ex)
            {
                //Response.Write(ex);
                mess.Visible = true;
                mess.Text = ex.Message;
                mess.Text = "Sorry For error there is some technical Problem.. Please try after some time";
                //Response.Write("Sorry For error there is some technical Problem.. Please try after some time");
            }
            finally
            {
            }
        }
        public void runqual()
        {
            //string Dist, DHna, Cmp, Desig, post, cad, lav, senno, nam, fnam;//this.Divs.Text = "%";

            string q1, q2, q3, q4, q5, q6, q7, q8, q9,qr0,qr1,qr2;
            //***************DISTRICT****************(divid LIKE '" + Divs.Text + "')  
            if (this.DDistrict.SelectedIndex != 0)
            {
                q1 = "DisId=" + DDistrict.SelectedItem.Value + "";
            }
            else { q1 = "DisId like '%'"; }
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            {
                q2 = "sno=" + DHname.SelectedItem.Value + "";
            }
            else { q2 = "sno like '%'"; }
            //*****************COMPUTER NO**************
            if (this.cmpuno.Text != "")
            {
                q3 = "idno=" + cmpuno.Text + "";
            }
            else { q3 = "idno like '%'"; }
            //****************DESIGNATION***************
            if (this.DDesign.SelectedIndex != 0)
            {
                q4 = "Desigid=" + DDesign.SelectedItem.Value + "";
            }
            else { q4 = "Desigid like '%'"; }
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            {
                q5 = "postid=" + Dpost.SelectedItem.Value + "";
            }
            else { q5 = "postid like '%'"; }
            //***************CADRE****************
            if (this.DCadre.SelectedIndex != 0)
            { q6 = "cadreid=" + DCadre.SelectedItem.Value + ""; }
            else { q6 = "cadreid like '%'"; }
            //***************LEVEL****************
            if (this.Dlevel.SelectedIndex != 0)
            { q6 = "lavel=" + Dlevel.SelectedItem.Value + ""; }
            else { q6 = "lavel like '%'"; }
            //***************SENIORITY****************
            if (this.Sen.Text != "")
            { q7 = "senno='" + Sen.Text + "'"; }
            else { q7 = "senno like '%'"; }
            //***************NAME****************
            if (this.name.Text != "")
            { q8 = "name like '%" + name.Text + "%'"; }
            else { q8 = "name like'%'"; }
            //***************FNAME****************
            if (this.fname.Text != "")
            { q9 = "fathername like '%" + fname.Text + "%'"; }
            else { q9 = "fathername like '%'"; }

            if (this.fcadreddl.SelectedIndex != 0)
            { qr0 = "fcadreid=" + fcadreddl.SelectedItem.Value + ""; }
            else { qr0 = "fcadreid like '%'"; }

            //*************Specialization*************

          //  if (this.splsearch.SelectedIndex != 0)
            //{ qr2 = "spid=" + splsearch.SelectedItem.Value + ""; }
            //else { qr2 = "spid like '%'"; }

            qr1 = " And " + q1 + " And " + q2 + " And " + q3 + " And " + q4 + " And " + q5 + " And " + q6 + " And " + q7 + " And " + q8 + " And " + q9 + "  And " + qr0 +  "";
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                distsublbl.Text = "";
                cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID, name as Name, senno as Seniority, dob as DateofBirth , fathername As Fname, districtname as Posting, hname as Hospital, newpostname as Post, convert(varchar,doposting,103)as DateOfPosting, lavel as Lavel, cadresenno as Cader,fcadreid as FeedingCadre FROM   factsheetSearchCriteria3 WHERE     (divid LIKE '" + Divs.Text + "') " + qr1 + " order by districtname,hname, name");//AND (DisId LIKE '" + Dist + "')  AND (sno LIKE '" + DHna + "') AND (idno LIKE '" + Cmp + "') AND (senno LIKE '" + senno + "') AND (name LIKE '" + nam + "') AND (fathername LIKE '" + fnam + "') AND  (Desigid LIKE '" + Desig + "') AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "')order by districtname, name");

            }
            else
            {
                //// *************************************************
                //// Hospital allotted to user  (string)Session["iduser"]
                if ((string)Session["UsDisId"] != null && (string)Session["iduser"] != null)
                {
                    //Uidt.Text = (string)Session["UsDisId"];
                    // distsublbl.Text = cl.getdistlv((string)Session["UsHtype"]);
                    distsublbl.Text = " and poposting  in (select sno from hospitalname where ddoid=" + (string)Session["iduser"] + ")";
                    cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID, name as Name, senno as Seniority, dob as DateofBirth , fathername As Fname, districtname as Posting, hname as Hospital, newpostname as Post, convert(varchar,doposting,103)as DateOfPosting, lavel as Lavel, cadresenno as Cader,fcadreid as FeedingCadre FROM   factsheetsearchCriteria1 WHERE (DisId ='" + Uidt.Text + "')" + qr1 + " " + distsublbl.Text + " order by districtname,hname, name");// AND (sno LIKE '" + DHna + "') AND (idno LIKE '" + Cmp + "') AND (senno LIKE '" + senno + "') AND (name LIKE '" + nam + "') AND (fathername LIKE '" + fnam + "') AND  (Desigid LIKE '" + Desig + "') AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "')order by districtname, name,hname");//AND (hname LIKE '" + DHna + "')
                }
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
                TableCell tcell3 = new TableCell();
                tcell3.Text = "Seniority";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                //tcell3.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell3);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                //tcell2.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell2);

                TableCell tcell8 = new TableCell();
                tcell8.Text = "Post";
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                //tcell8.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell8);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Current District";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Hospital";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                //tcell7.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell7);


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

                TableCell tcell9 = new TableCell();
                tcell9.Text = "Date Of Posting";
                tcell9.BorderWidth = 1;
                tcell9.BorderColor = System.Drawing.Color.SlateGray;
                //tcell9.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell9);

                TableCell tcell10 = new TableCell();
                tcell10.Text = "Lavel";
                tcell10.BorderWidth = 1;
                tcell10.BorderColor = System.Drawing.Color.SlateGray;
                //tcell10.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell10);

                TableCell tcell11 = new TableCell();
                tcell11.Text = "Cader";
                tcell11.BorderWidth = 1;
                tcell11.BorderColor = System.Drawing.Color.SlateGray;
                //tcell11.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell11);

                TableCell tcell13 = new TableCell();
                tcell13.Text = "FeedingCadre";
                tcell13.BorderWidth = 1;
                tcell13.BorderColor = System.Drawing.Color.SlateGray;
                //tcell11.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell13);

                TableCell tcell91 = new TableCell();
                tcell91.Text = "View";
                tcell91.BorderWidth = 1;
                tcell91.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell91);

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
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();//senno
                    rw1.Cells.Add(tcellk4);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();//name
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    //tcellk3.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk3);



                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][7].ToString();//post
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][5].ToString();//posting hospital
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][6].ToString(); //district              
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][4].ToString();//Fathers Name
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk9 = new TableCell();
                    tcellk9.Text = cl.ds.Tables[0].Rows[j][3].ToString();//Date of Birth
                    tcellk9.BorderWidth = 1;
                    tcellk9.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk9);

                    TableCell tcellk10 = new TableCell();
                    tcellk10.BorderWidth = 1;
                    tcellk10.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk10.Text = cl.ds.Tables[0].Rows[j][8].ToString(); //posting Date              
                    rw1.Cells.Add(tcellk10);

                    TableCell tcellk11 = new TableCell();
                    tcellk11.Text = cl.ds.Tables[0].Rows[j][9].ToString();//lavel
                    tcellk11.BorderWidth = 1;
                    tcellk11.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk11);

                    TableCell tcellk12 = new TableCell();
                    tcellk12.Text = cl.ds.Tables[0].Rows[j][10].ToString();//Cader
                    tcellk12.BorderWidth = 1;
                    tcellk12.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk12);

                    TableCell tcellk13 = new TableCell();
                    tcellk13.Text = cl.ds.Tables[0].Rows[j][11].ToString();//Cader
                    tcellk13.BorderWidth = 1;
                    tcellk13.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk13);

                    TableCell tcellk112 = new TableCell();
                    tcellk112.Text = "P2";
                    tcellk112.BorderWidth = 1;
                    tcellk112.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk112);
                    //tcellk112.Text = ("<a href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk112.Text + "</a>")));
                    tcellk112.Text = ("<a target='_blank' href=\'DoctorP2.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk112.Text + "</a>")));
                    Table1.Rows.Add(rw1);

                }
            }
            else
            {
                mess.Visible = true;
                mess.Text = "No Data Found for this selection";
            }
        }
        protected void Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Proforma2/RepOption.aspx");
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
            Response.Redirect("~/Proforma2/RepOption.aspx");
        }

        protected void fcadreddl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}