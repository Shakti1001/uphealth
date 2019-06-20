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

namespace NewWebApp.Proforma2
{
    public partial class totaltimeinhospital : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
                Fnamet.Text = (string)Session["fullname"];
                //Dateontext.Text=DateTime.Today.ToString("dd/MM/yyyy");
                //Dateontext.Text =Convert.ToDateTime(System.DateTime.Today);// //Dateontext.Text = DateTime.Now;
                this.Nytext.Text = "0";
                ddfill();
            }
        }
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
                distsublbl.Text = "";
            }
            else
            {
                DDiv.Visible = false;
                DL.Visible = false;
                //DL.Text = "Division Selected ";
                //cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                //if (cl.ds.Tables[0].Rows.Count > 0)
                //{
                //    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                //}
                //// *************************************************
                //// Hospital allotted to user  (string)Session["iduser"]
                if ((string)Session["UsDisId"] != null && (string)Session["iduser"] != null)
                {
                    Uidt.Text = (string)Session["UsDisId"];
                    //distsublbl.Text = cl.getdistlv((string)Session["UsHtype"]);
                    distsublbl.Text = " and poposting  in (select sno from hospitalname where ddoid=" + (string)Session["iduser"] + ")";

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
            cl.ds = cl.DataFill("SELECT DISTINCT cadrename, cadreid FROM cadre ORDER BY cadrename");
            DCadre.DataSource = cl.ds;
            DCadre.DataTextField = "cadrename";
            DCadre.DataValueField = "cadreid";
            DCadre.DataBind();
            DCadre.Items.Insert(0, new ListItem("--select--"));
            //***************************
            cl.ds = cl.DataFill("SELECT htype, hid FROM hospitaltype ORDER BY htype");
            DDType.DataSource = cl.ds;
            DDType.DataTextField = "htype";
            DDType.DataValueField = "hid";
            DDType.DataBind();
            DDType.Items.Insert(0, new ListItem("--select--"));
            cl.ds = cl.DataFill("SELECT DISTINCT newpostid, newpostname FROM  post ORDER BY newpostid");
            this.Dpost.DataSource = cl.ds;
            this.Dpost.DataTextField = "newpostname";
            this.Dpost.DataValueField = "newpostid";
            this.Dpost.DataBind();
            this.Dpost.Items.Insert(0, new ListItem("--select--"));
            //********************
            cl.ds = cl.DataFill("SELECT distinct levelid, levelcode FROM lavel ORDER BY levelid");
            Dlevel.DataSource = cl.ds;
            Dlevel.DataTextField = "levelcode";
            Dlevel.DataValueField = "levelid";
            Dlevel.DataBind();
            Dlevel.Items.Insert(0, new ListItem("--select--"));

        }



        public void VIEWS()
        {
            //DIFF VIEW
            //SELECT     DISTRICTID, IDNO, DATEDIFF(MM, DOPOSTING, GETDATE()) AS AA FROM  postingdetails WHERE     DATEDIFF(MM, DOPOSTING, DORELIEVE) IS NULL UNION SELECT     DISTRICTID, IDNO, DATEDIFF(MM, DOPOSTING, DORELIEVE) AS AA FROM         postingdetails WHERE     DATEDIFF(MM, DOPOSTING, DORELIEVE) IS NOT NULL) 

            //SELECT DISTRICTID,IDNO,SUM(AA) FROM DIFF WHERE IDNO=6862 GROUP BY DISTRICTID,IDNO ORDER BY DISTRICTID,IDNO

        }
        public void runqualTIME()
        {
            string Dist, DHna, DHt, post, cad, lav;//Cmp, Desig,senno,, nam, fnam

            //***************DIVISION****************
            bool l;
            l = cl.checklavel((string)Session["iduser"]);
            if (l == true)
            {
                if (this.DDiv.SelectedIndex != 0)
                { this.Divs.Text = "%" + DDiv.SelectedItem.Value + "%"; }
                else { this.Divs.Text = "%"; }
            }
            else
            {
                this.Divs.Text = "%";
            }
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            { Dist = "%" + DDistrict.SelectedItem.Value + "%"; }
            else { Dist = "%"; }
            //**************HOSPITAL TYPE*****************
            if (this.DDType.SelectedIndex != 0)
            { DHt = "%" + DDType.SelectedItem.Value + "%"; }
            else { DHt = "%"; }
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            { DHna = "%" + DHname.SelectedItem.Value + "%"; }
            else { DHna = "%"; }
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            { post = "%" + Dpost.SelectedItem.Value + "%"; }
            else { post = "%"; }
            //***************CADRE****************
            if (this.DCadre.SelectedIndex != 0)
            { cad = "%" + DCadre.SelectedItem.Value + "%"; }
            else { cad = "%"; }
            //***************LEVEL****************
            if (this.Dlevel.SelectedIndex != 0)
            { lav = "%" + Dlevel.SelectedItem.Value + "%"; }
            else { lav = "%"; }

            //Response.Write("<script language=javascript>window.open('TimecriteriaCurdistrict.aspx?Div=" + Nytext.Text + "&Dis=" + Dist + "&DT=" + DHt + " &HN=" + DHna + "&Post=" + post + " &cader=" + cad + "&lavel=" + lav + "&time=" + Nytext.Text + "','new_Win');</script>");
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {                      //SELECT DISTINCT  idno AS ComputerID, senno AS Seniority, name AS Name, newpostname AS Post, districtname AS Posting, hname AS Hospital, CONVERT(varchar,  doposting, 103) AS DateOfPosting, dob AS DateofBirth, fathername AS Fname, lavel AS Lavel, cadrename AS Cader, ROUND(YEARA / 12.0, 2) AS YY,  htype AS HospitalType, DisId FROM         currentsearchCriteria
                cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,senno as Seniority, name as Name,newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting,   dob as DateofBirth , fathername As Fname,    lavel as Lavel, cadrename as Cader,ROUND(YEARA / 12, 2) as 'Ctime' ,htype AS HospitalType,DisId  FROM   currentsearchCriteria WHERE (YEARA/12 >='" + Convert.ToInt32(this.Nytext.Text) + "') and (divid LIKE '" + Divs.Text + "') AND (DisId LIKE '" + Dist + "') AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "')  order by districtname,hname, name");
            }
            else
            {
                cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,senno as Seniority, name as Name,newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting,   dob as DateofBirth , fathername As Fname,    lavel as Lavel, cadrename as Cader,ROUND(YEARA / 12, 2) as 'Ctime',htype AS HospitalType,DisId FROM   currentsearchCriteria WHERE (YEARA/12 >='" + Convert.ToInt32(this.Nytext.Text) + "') and (DisId ='" + Uidt.Text + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "') order by districtname, hname,name");

            }
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                strq.Visible = false;
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.SlateGray;
                rw.BackColor = System.Drawing.Color.BurlyWood;
                rw.ForeColor = System.Drawing.Color.Maroon;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "ComputerID";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell1);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Seniority";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell3);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell2);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Post";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "District";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Palce of Posting";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Date Of Posting";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell7);

                //TableCell tcell8 = new TableCell();
                //tcell8.Text = "DateofBirth";
                //tcell8.BorderWidth = 1;
                //tcell8.BorderColor = System.Drawing.Color.SlateGray;
                //rw.Cells.Add(tcell8);

                //TableCell tcell9 = new TableCell();
                //tcell9.Text = "Fathername";
                //tcell9.BorderWidth = 1;
                //tcell9.BorderColor = System.Drawing.Color.SlateGray;
                //rw.Cells.Add(tcell9);

                //TableCell tcell10 = new TableCell();
                //tcell10.Text = "Lavel";
                //tcell10.BorderWidth = 1;
                //tcell10.BorderColor = System.Drawing.Color.SlateGray;
                //rw.Cells.Add(tcell10);

                //TableCell tcell11 = new TableCell();
                //tcell11.Text = "Cader";
                //tcell11.BorderWidth = 1;
                //tcell11.BorderColor = System.Drawing.Color.SlateGray;
                //rw.Cells.Add(tcell11);

                TableCell tcellXX1 = new TableCell();
                tcellXX1.Text = "Year Completed";
                tcellXX1.BorderWidth = 1;
                tcellXX1.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcellXX1);

                TableCell tcellX1 = new TableCell();
                tcellX1.Text = "Print";
                tcellX1.BorderWidth = 1;
                tcellX1.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcellX1);
                Table2.Rows.Add(rw);
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
                    tcellk1.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    rw1.Cells.Add(tcellk4);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    //TableCell tcellk9 = new TableCell();
                    //tcellk9.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    //tcellk9.BorderWidth = 1;
                    //tcellk9.BorderColor = System.Drawing.Color.SlateGray;
                    //rw1.Cells.Add(tcellk9);

                    //TableCell tcellk10 = new TableCell();
                    //tcellk10.BorderWidth = 1;
                    //tcellk10.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk10.Text = cl.ds.Tables[0].Rows[j][8].ToString();
                    //rw1.Cells.Add(tcellk10);

                    //TableCell tcellk11 = new TableCell();
                    //tcellk11.Text = cl.ds.Tables[0].Rows[j][9].ToString();
                    //tcellk11.BorderWidth = 1;
                    //tcellk11.BorderColor = System.Drawing.Color.SlateGray;
                    //rw1.Cells.Add(tcellk11);

                    //TableCell tcellk12 = new TableCell();
                    //tcellk12.Text = cl.ds.Tables[0].Rows[j][10].ToString();
                    //tcellk12.BorderWidth = 1;
                    //tcellk12.BorderColor = System.Drawing.Color.SlateGray;
                    //rw1.Cells.Add(tcellk12);

                    //sancode = (this.DropDownList1.SelectedItem.Text.Trim().Substring(0, 1) + ("-" + (this.DropDownList1.SelectedItem.Text.Trim().Substring((this.DropDownList1.SelectedItem.Text.Trim().Length - 1)) + ("/" + (this.DropDownList2.SelectedItem.Text.Trim().Substring(0, 1) + ("/" + this.DropDownList3.SelectedItem.Text.Trim().Substring(0, 1)))))));

                    TableCell tcelltottime = new TableCell();
                    tcelltottime.Text = cl.ds.Tables[0].Rows[j][11].ToString();
                    tcelltottime.Text = (tcelltottime.Text).Trim().Substring(0, 4) + " " + "year";
                    tcelltottime.BorderWidth = 1;
                    tcelltottime.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcelltottime);

                    TableCell tcellk13 = new TableCell();
                    tcellk13.Text = "Print";
                    tcellk13.BorderWidth = 1;
                    tcellk13.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk13);
                    tcellk13.Text = ("<a target='_blank' href=\'DoctorP2.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk13.Text + "</a>")));//("\'>"  + tcellk10.Text +"</a>")));
                    Table2.Rows.Add(rw1);
                }
            }
            else
            {
                strq.Visible = true;
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
        protected void DDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDistrict.SelectedIndex != 0 && DDType.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid ='" + DDistrict.SelectedItem.Value + "')AND (hospitalname.htype ='" + DDType.SelectedItem.Value + "') ORDER BY hospitalname.hname");
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
        protected void Dpost_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DCadre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Dlevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            //runqualTIME();
            //print();
            printXX();
        }
        public void printXX()
        {
            string Dist, DHna, DHt, post, cad, lav;

            //***************DIVISION****************
            bool l;
            l = cl.checklavel((string)Session["iduser"]);
            if (l == true)
            {
                if (this.DDiv.SelectedIndex != 0)
                { this.Divs.Text = DDiv.SelectedItem.Value; }
                else { this.Divs.Text = "N"; }
            }
            else
            {
                this.Divs.Text = "N";
            }
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            { Dist = DDistrict.SelectedItem.Value.Trim(); }
            else { Dist = "N"; }
            //**************HOSPITAL TYPE*****************
            if (this.DDType.SelectedIndex != 0)
            { DHt = DDType.SelectedItem.Value.Trim(); }
            else { DHt = "N"; }
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            { DHna = DHname.SelectedItem.Value.Trim(); }
            else { DHna = "N"; }
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            { post = Dpost.SelectedItem.Value.Trim(); }
            else { post = "N"; }
            //***************CADRE****************
            if (this.DCadre.SelectedIndex != 0)
            { cad = DCadre.SelectedItem.Value.Trim(); }
            else { cad = "N"; }
            //***************LEVEL****************
            if (this.Dlevel.SelectedIndex != 0)
            { lav = Dlevel.SelectedItem.Value.Trim(); }
            else { lav = "N"; }
            //***************DATE As On****************
            DateTime d1;
            //if (Dateontext.Text != "")
            //{ //d1 = Convert.ToDateTime(Dateontext.Text);
            //}
            //else { }
            d1 = System.DateTime.Today;
            ////////////Response.Write("<script language=javascript>window.open('TimecriteriaCurdistrict.aspx?Div="+Divs.Text+"&Dis="+Dist+"&DT="+DHt+"&HN="+DHna+"&Post="+post+"&cader="+cad+"&lavel="+lav+"&time="+Nytext.Text+"','new_Win');</script>");
            //Response.Redirect("TimecriteriaCurdistrict.aspx?Div=" + Divs.Text + "&Dis=" + Dist + "&DT=" + DHt + "&HN=" + DHna + "&Post=" + post + "&cader=" + cad + "&lavel=" + lav + "&time=" + Nytext.Text + "&d1=" + d1 + "");
            Server.Transfer("TimecriteriaCurdistrict.aspx?Div=" + Divs.Text + "&Dis=" + Dist + "&DT=" + DHt + "&HN=" + DHna + "&Post=" + post + "&cader=" + cad + "&lavel=" + lav + "&time=" + Nytext.Text + "&d1=" + d1 + " &y=" + Nytext.Text + "");
        }

        public void print()
        {
            string Dist, DHna, DHt, post, cad, lav;

            //***************DIVISION****************
            bool l;
            l = cl.checklavel((string)Session["iduser"]);
            if (l == true)
            {
                if (this.DDiv.SelectedIndex != 0)
                { this.Divs.Text = "%" + DDiv.SelectedItem.Value + "%"; }
                else { this.Divs.Text = "%"; }
            }
            else
            {
                this.Divs.Text = "%";
            }
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            { Dist = "%" + DDistrict.SelectedItem.Value + "%"; }
            else { Dist = "%"; }
            //**************HOSPITAL TYPE*****************
            if (this.DDType.SelectedIndex != 0)
            { DHt = "%" + DDType.SelectedItem.Value + "%"; }
            else { DHt = "%"; }
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            { DHna = "%" + DHname.SelectedItem.Value + "%"; }
            else { DHna = "%"; }
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            { post = "%" + Dpost.SelectedItem.Value + "%"; }
            else { post = "%"; }
            //***************CADRE****************
            if (this.DCadre.SelectedIndex != 0)
            { cad = "%" + DCadre.SelectedItem.Value + "%"; }
            else { cad = "%"; }
            //***************LEVEL****************
            if (this.Dlevel.SelectedIndex != 0)
            { lav = "%" + Dlevel.SelectedItem.Value + "%"; }
            else { lav = "%"; }
            Response.Write("<script language=javascript>window.open('TimecriteriaCurdistrict.aspx?Div=" + Divs.Text + "&Dis=" + Dist + "&DT=" + DHt + " &HN=" + DHna + "&Post=" + post + " &cader=" + cad + "&lavel=" + lav + "&time=" + Nytext.Text + "','new_Win');</script>");

        }
        protected void Refresh_Click(object sender, EventArgs e)
        {

        }

        public void runqual()
        {
            //string Dist, DHna, DHt, Cmp, Desig, post, cad, lav, senno, nam, fnam;
            ////***************DIVISION****************
            //bool l;
            //l = cl.checklavel((string)Session["iduser"]);
            //if (l == true)
            //{
            //    if (this.DDiv.SelectedIndex != 0)
            //    { this.Divs.Text = "%" + DDiv.SelectedItem.Value + "%"; }
            //    else { this.Divs.Text = "%"; }
            //}
            //else
            //{
            //    this.Divs.Text = "%";
            //}

            ////***************DISTRICT****************
            //if (this.DDistrict.SelectedIndex != 0)
            //{ Dist = "%" + DDistrict.SelectedItem.Value + "%"; }
            //else { Dist = "%"; }
            ////**************HOSPITAL TYPE*****************
            //if (this.DDType.SelectedIndex != 0)
            //{ DHt = "%" + DDType.SelectedItem.Value + "%"; }
            //else { DHt = "%"; }
            ////**************HOSPITAL NAME*****************
            //if (this.DHname.SelectedIndex != 0)
            //{ DHna = "%" + DHname.SelectedItem.Value + "%"; }
            //else { DHna = "%"; }
            ////****************POST***************
            //if (this.Dpost.SelectedIndex != 0)
            //{ post = "%" + Dpost.SelectedItem.Value + "%"; }
            //else { post = "%"; }
            ////***************CADRE****************
            //if (this.DCadre.SelectedIndex != 0)
            //{ cad = "%" + DCadre.SelectedItem.Value + "%"; }
            //else { cad = "%"; }
            ////***************LEVEL****************
            //if (this.Dlevel.SelectedIndex != 0)
            //{ lav = "%" + Dlevel.SelectedItem.Value + "%"; }
            //else { lav = "%"; }
            ////*****************COMPUTER NO**************
            ////if (this.cmpuno.Text != "")
            ////{
            ////    Cmp = this.cmpuno.Text;
            ////}
            ////Cmp = "%" + this.cmpuno.Text + "%"; 
            ////else { Cmp =this.cmpuno.Text; }
            ////**********************

            //bool i;
            //i = cl.checklavel((string)Session["iduser"]);
            //if (i == true)

            //// currentsearchCriteria           SELECT DISTINCT TOP 100 PERCENT dbo.personaldetails.idno, dbo.personaldetails.senno, dbo.personaldetails.name, dbo.personaldetails.fathername, CONVERT(Char, dbo.personaldetails.dob, 106) AS dob, dbo.hospitaldistrict.districtname, dbo.post.newpostname, dbo.personaldetails.postingstatus, dbo.personaldetails.lavel, dbo.Ucreate.DisId, dbo.Ucreate.userid, dbo.hospitaldistrict.divid, dbo.cadre.cadrename, dbo.cadre.cadreid, dbo.designation.designame, dbo.hospitalname.hname, dbo.hospitalname.sno, dbo.currentposted.doposting, dbo.currentposted.dorelieve, dbo.currentposted.Desigid, dbo.currentposted.postid FROM         dbo.cadre INNER JOIN dbo.personaldetails INNER JOIN dbo.currentposted INNER JOIN dbo.Ucreate ON dbo.currentposted.districtid = dbo.Ucreate.DisId ON dbo.personaldetails.idno = dbo.currentposted.idno INNER JOIN dbo.post ON dbo.currentposted.postid = dbo.post.newpostid ON dbo.cadre.cadreid = dbo.personaldetails.cadre INNER JOIN dbo.hospitaldistrict ON dbo.currentposted.districtid = dbo.hospitaldistrict.districtid INNER JOIN  dbo.designation ON dbo.currentposted.Desigid = dbo.designation.Desigid INNER JOIN dbo.hospitalname ON dbo.currentposted.poposting = dbo.hospitalname.sno ORDER BY dbo.personaldetails.name
            //{                       //SELECT     Distinct(idno) as ComputerID, name as Name, senno as Seniority, dob as DateofBirth , fathername As Fname, districtname as Posting, hname as Hospital, newpostname as Post, convert(varchar,doposting,103)as DateOfPosting, lavel as Lavel, cadrename as Cader FROM   currentsearchCriteria WHERE     (divid LIKE '" + Div + "') AND (DisId LIKE '" + Dist + "') AND (sno LIKE '" + DHna + "') AND (idno LIKE '" + Cmp + "') AND (senno LIKE '" + senno + "') AND (name LIKE '" + nam + "') AND (fathername LIKE '" + fnam + "') AND  (Desigid LIKE '" + Desig + "') AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "')order by districtname, name");
            //    cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,senno as Seniority, name as Name,newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting,   dob as DateofBirth , fathername As Fname,    lavel as Lavel, cadrename as Cader,htype AS HospitalType,DisId FROM   currentsearchCriteria WHERE (divid LIKE '" + Divs.Text + "') AND (DisId LIKE '" + Dist + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "') and (postingstatus='J') order by districtname,hname, name");
            //}
            //else
            //{
            //    cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,senno as Seniority, name as Name,newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting,   dob as DateofBirth , fathername As Fname,    lavel as Lavel, cadrename as Cader,htype AS HospitalType,DisId FROM   currentsearchCriteria WHERE (DisId ='" + Uidt.Text + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "') and (postingstatus='J')order by districtname, hname,name");
            //    //cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID, name as Name, senno as Seniority, dob as DateofBirth , fathername As Fname, districtname as Posting, hname as Hospital, newpostname as Post, convert(varchar,doposting,103)as DateOfPosting, lavel as Lavel, cadrename as Cader,htype AS HospitalType FROM   currentsearchCriteria order by districtname, name");//////////(idno ='" + Cmp + "') and

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
            //    rw.Cells.Add(tcell0);

            //    TableCell tcell1 = new TableCell();
            //    tcell1.Text = "ComputerID";
            //    tcell1.BorderWidth = 1;
            //    tcell1.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell1.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell1);

            //    TableCell tcell3 = new TableCell();
            //    tcell3.Text = "Seniority";
            //    tcell3.BorderWidth = 1;
            //    tcell3.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell3.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell3);

            //    TableCell tcell2 = new TableCell();
            //    tcell2.Text = "Name";
            //    tcell2.BorderWidth = 1;
            //    tcell2.BorderColor = System.Drawing.Color.SlateGray;
            //    // tcell2.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell2);



            //    TableCell tcell4 = new TableCell();
            //    tcell4.Text = "Post";//
            //    tcell4.BorderWidth = 1;
            //    tcell4.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell4.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell4);

            //    TableCell tcell5 = new TableCell();
            //    tcell5.Text = "Posting";//
            //    tcell5.BorderWidth = 1;
            //    tcell5.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell5.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell5);

            //    TableCell tcell6 = new TableCell();
            //    tcell6.Text = "Hospital";//
            //    tcell6.BorderWidth = 1;
            //    tcell6.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell6.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell6);

            //    TableCell tcell7 = new TableCell();
            //    tcell7.Text = "Date Of Posting";//
            //    tcell7.BorderWidth = 1;
            //    tcell7.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell7.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell7);

            //    TableCell tcell8 = new TableCell();
            //    tcell8.Text = "DateofBirth";
            //    tcell8.BorderWidth = 1;
            //    tcell8.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell8.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell8);

            //    TableCell tcell9 = new TableCell();
            //    tcell9.Text = "Fathername";
            //    tcell9.BorderWidth = 1;
            //    tcell9.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell9.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell9);

            //    TableCell tcell10 = new TableCell();
            //    tcell10.Text = "Lavel";
            //    tcell10.BorderWidth = 1;
            //    tcell10.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell10.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell10);

            //    TableCell tcell11 = new TableCell();
            //    tcell11.Text = "Cader";
            //    tcell11.BorderWidth = 1;
            //    tcell11.BorderColor = System.Drawing.Color.SlateGray;
            //    //tcell11.ForeColor = System.Drawing.Color.Gold;
            //    rw.Cells.Add(tcell11);

            //    TableCell tcellXX1 = new TableCell();
            //    tcellXX1.Text = "Year Completed";
            //    tcellXX1.BorderWidth = 1;
            //    tcellXX1.BorderColor = System.Drawing.Color.SlateGray;
            //    rw.Cells.Add(tcellXX1);

            //    TableCell tcellX1 = new TableCell();
            //    tcellX1.Text = "Print";
            //    tcellX1.BorderWidth = 1;
            //    tcellX1.BorderColor = System.Drawing.Color.SlateGray;
            //    rw.Cells.Add(tcellX1);

            //    Table1.Rows.Add(rw);
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
            //        tcellk1.Text = Convert.ToString(j + 1);
            //        rw1.Cells.Add(tcellk1);

            //        TableCell tcellk2 = new TableCell();
            //        tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
            //        tcellk2.BorderWidth = 1;
            //        tcellk2.BorderColor = System.Drawing.Color.SlateGray;
            //        rw1.Cells.Add(tcellk2);

            //        TableCell tcellk4 = new TableCell();
            //        tcellk4.BorderWidth = 1;
            //        tcellk4.BorderColor = System.Drawing.Color.SlateGray;
            //        tcellk4.Text = cl.ds.Tables[0].Rows[j][1].ToString();
            //        rw1.Cells.Add(tcellk4);


            //        TableCell tcellk3 = new TableCell();
            //        tcellk3.Text = cl.ds.Tables[0].Rows[j][2].ToString();
            //        tcellk3.BorderWidth = 1;
            //        tcellk3.BorderColor = System.Drawing.Color.SlateGray;
            //        tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
            //        rw1.Cells.Add(tcellk3);
            //        //tcellk3.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk3.Text + "</a>")));



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

            //        TableCell tcellk11 = new TableCell();
            //        tcellk11.Text = cl.ds.Tables[0].Rows[j][9].ToString();
            //        tcellk11.BorderWidth = 1;
            //        tcellk11.BorderColor = System.Drawing.Color.SlateGray;
            //        rw1.Cells.Add(tcellk11);

            //        TableCell tcellk12 = new TableCell();
            //        tcellk12.Text = cl.ds.Tables[0].Rows[j][10].ToString();
            //        tcellk12.BorderWidth = 1;
            //        tcellk12.BorderColor = System.Drawing.Color.SlateGray;
            //        rw1.Cells.Add(tcellk12);

            //        TableCell tcelltottime = new TableCell();
            //        ////****************************************               
            //        int a = Convert.ToInt32(cl.ds.Tables[0].Rows[j][0]);
            //        int b = Convert.ToInt32(cl.ds.Tables[0].Rows[j][12]);
            //        //SqlDataAdapter Tottime = new SqlDataAdapter("SELECT DISTINCT postingdetails.doposting, postingdetails.dorelieve, postingdetails.districtid  FROM         postingdetails INNER JOIN   currentsearchCriteria ON postingdetails.idno = currentsearchCriteria.idno WHERE     (postingdetails.idno = " + a + ") And ( postingdetails.districtid = " + b + ")", ClDatabase.ConnectionString);
            //        SqlDataAdapter Tottime = new SqlDataAdapter("SELECT    DATEDIFF(yy, postingdetails.doposting, postingdetails.dorelieve) AS Dy, postingdetails.doposting, postingdetails.dorelieve,DATEDIFF(mm, postingdetails.doposting, GETDATE()) AS Dm, currentposting.districtid,  postingdetails.idno FROM currentposting INNER JOIN postingdetails ON currentposting.idno = postingdetails.idno AND currentposting.districtid = postingdetails.districtid WHERE     (postingdetails.idno = " + a + ") And ( postingdetails.districtid = " + b + ")", ClDatabase.ConnectionString);
            //        DataSet d2 = new DataSet();
            //        cl.upcon.Open();
            //        Tottime.Fill(d2);
            //        cl.upcon.Close();
            //        if (d2.Tables[0].Rows.Count == 0)
            //        {
            //            tcelltottime.Text = "N.A.";
            //        }
            //        else
            //        {
            //            int totalt = 0;
            //            int x=0;
            //            Double tott;
            //            DateTime FD2;// fdate , FD2, FD3;
            //            for (int kk = 0; kk < d2.Tables[0].Rows.Count; kk++)
            //            {
            //                if (!(d2.Tables[0].Rows[kk][0].ToString().Equals(System.DBNull.Value)))
            //                {
            //                    if (d2.Tables[0].Rows[kk][0].ToString() != "")
            //                    {
            //                        x = Convert.ToInt32(d2.Tables[0].Rows[kk][0].ToString());

            //                    }
            //                    else if (d2.Tables[0].Rows[kk][0].ToString() == "")
            //                    {
            //                        FD2 = Convert.ToDateTime(d2.Tables[0].Rows[kk][1].ToString());
            //                        TimeSpan fd = System.DateTime.Now - FD2;
            //                        tott = fd.TotalDays;
            //                        x = Convert.ToInt32(tott);
            //                        x = x / 365;                               
            //                    }
            //                }                        
            //             totalt = totalt + x;

            //             }
            //             if (totalt == 0)
            //             {
            //                 if (Convert.ToInt32(d2.Tables[0].Rows[0][3].ToString()) > 12)
            //                 {
            //                     tcelltottime.Text = "Data Missing";
            //                 }
            //                 else
            //                 {
            //                     tcelltottime.Text = d2.Tables[0].Rows[0][3].ToString() + " " + "Month";
            //                 }
            //             }
            //             else
            //             {
            //                 tcelltottime.Text = Convert.ToString(totalt)+" "+"Year";
            //             }
            //        }

            //        tcelltottime.BorderWidth = 1;
            //        rw1.Cells.Add(tcelltottime);
            //        TableCell tcellk13 = new TableCell();
            //        tcellk13.Text = "Print";
            //        tcellk13.BorderWidth = 1;
            //        tcellk13.BorderColor = System.Drawing.Color.SlateGray;
            //        rw1.Cells.Add(tcellk13);
            //        tcellk13.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk13.Text + "</a>")));//("\'>"  + tcellk10.Text +"</a>")));


            //        Table1.Rows.Add(rw1);

            //    }
            //}
        }

        protected void AllPrintLink_Click(object sender, EventArgs e)
        {
            //if (Nytext.Text!="")
            //{
            //    //Response.Write("<script language=javascript>window.open('timebased.aspx?a=" + Nytext.Text + "&b=" + Nytext1.Text + "&c=0 &d=" + Nytext1.Text + "','new_Win');</script>")
            //    // Server.Transfer
            //    Response.Write("<script language=javascript>window.open('timebased.aspx?Y=" + Nytext.Text + "' ,'new_Win');</script>");
            //}
            //else
            //{
            //    Response.Write("<script language=javascript>window.open('timebased.aspx?Y=0' ,'new_Win');</script>");
            //}
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/RepOption.aspx");
        }
    }
}