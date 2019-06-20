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
    public partial class paraCurrentlistchoice : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                Fnamet.Text = (string)Session["fullname"];
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
                cl.ds.Clear();
                cl.ds.Dispose();

            }
            else
            {
                DDiv.Visible = false;
                //DL.Visible = false;
                DL.Text = "Division Selected ";
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
                cl.ds.Clear();
                cl.ds.Dispose();
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
            cl.ds.Clear();
            cl.ds.Dispose();
            //****************
            cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid  where hospitaldistrict.districtid like '" + Uidt.Text + "' ORDER BY hospitalname.hname");
            DHname.DataSource = cl.ds;
            DHname.DataTextField = "hname";
            DHname.DataValueField = "sno";
            DHname.DataBind();
            DHname.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();
            //****************
            cl.ds = cl.DataFill("SELECT DISTINCT cadrename, cadreid FROM pmdcadre ORDER BY cadrename");
            DCadre.DataSource = cl.ds;
            DCadre.DataTextField = "cadrename";
            DCadre.DataValueField = "cadreid";
            DCadre.DataBind();
            DCadre.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();
            //***************************
            //cl.ds = cl.DataFill("SELECT laveldesc, lavelid FROM   pmdlavel ORDER BY htype");
            //fcadre.DataSource = cl.ds;
            //fcadre.DataTextField = "laveldesc";
            //fcadre.DataValueField = "lavelid";
            //fcadre.DataBind();
            //fcadre.Items.Insert(0, new ListItem("--select--"));
            //cl.ds.Clear();
            //cl.ds.Dispose();
            cl.ds = cl.DataFill("SELECT  fcadreid, feedingcadre FROM  pmdfeedingcadre ORDER BY fcadreid");
            this.Dlevel.DataSource = cl.ds;
            this.Dlevel.DataTextField = "feedingcadre";
            this.Dlevel.DataValueField = "fcadreid";
            this.Dlevel.DataBind();
            this.Dlevel.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();
            //********************
            cl.ds = cl.DataFill("SELECT distinct desigid, designame FROM PMDhospitaldesignation ORDER BY desigid");
            Dpost.DataSource = cl.ds;
            Dpost.DataTextField = "designame";
            Dpost.DataValueField = "desigid";
            Dpost.DataBind();
            Dpost.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();

        }


        public void runqual()
        {
            string Dist, DHna, DHt, post, cad, lav;//Cmp, Desig,senno, nam,, fnam
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
            //if (this.DDType.SelectedIndex != 0)
            //{ DHt = "%" + DDType.SelectedItem.Value + "%"; }
            //else { DHt = "%"; }        
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
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                //strq.Text = "SELECT Distinct(idno) as ComputerID,senno as Seniority, name as Name,newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting,   dob as DateofBirth , fathername As Fname,    lavel as Lavel, cadrename as Cader,htype AS HospitalType FROM   pmdcurrentsearchCriteria WHERE (divid LIKE '" + Divs.Text + "') AND (DisId LIKE '" + Dist + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "')  order by districtname,hname, name";

                strq.Text = "SELECT Distinct(idno) as ComputerID,senno as Seniority, name as Name,newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting,   dob as DateofBirth , fathername As Fname,    lavel as Lavel, cadrename as Cader,htype AS HospitalType FROM   paracurrentsearchCriteria WHERE (divid LIKE '" + Divs.Text + "') AND (DisId LIKE '" + Dist + "') AND (sno LIKE '" + DHna + "')AND (postid LIKE '" + post + "') AND (feedincadre LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "')  order by districtname,hname, name";
            }
            else
            {
                //strq.Text = "SELECT Distinct(idno) as ComputerID,senno as Seniority, name as Name,newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting,   dob as DateofBirth , fathername As Fname,    lavel as Lavel, cadrename as Cader,htype AS HospitalType FROM   pmdcurrentsearchCriteria WHERE (DisId ='" + Uidt.Text + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "') order by districtname, hname,name";

                strq.Text = "SELECT Distinct(idno) as ComputerID,senno as Seniority, name as Name,newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting,   dob as DateofBirth , fathername As Fname,    lavel as Lavel, cadrename as Cader,htype AS HospitalType FROM   paracurrentsearchCriteria WHERE (DisId ='" + Uidt.Text + "') AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "') AND (feedincadre LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "') order by districtname, hname,name";

            }
            cl.ds = cl.DataFill(strq.Text);
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                this.LinkButton1.Visible = true;
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
                // tcell2.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell2);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Post";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                //tcell4.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "District";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                //tcell5.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Place Of Posting";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Date Of Posting";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                //tcell7.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell7);



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
                    tcellk1.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);
                    tcellk2.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk2.Text + "</a>")));

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
                    //tcellk3.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk3.Text + "</a>")));



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

                    Table1.Rows.Add(rw1);
                }
                cl.ds.Clear();
                cl.ds.Dispose();
            }
            else
            {
                this.LinkButton1.Visible = false;
                mess.Text = "Sorry There Is No Data According To This Selection";
            }

        }
        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDiv.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT DISTINCT districtid,districtname  FROM     hospitaldistrict WHERE     (divid = '" + DDiv.SelectedItem.Value + "') ORDER BY districtname");
                DDistrict.DataSource = cl.ds;
                DDistrict.DataTextField = "districtname";
                DDistrict.DataValueField = "districtid";
                DDistrict.DataBind();
                DDistrict.Items.Insert(0, new ListItem("--select--"));
                this.Divs.Text = "%" + DDiv.SelectedItem.Value + "%";
                cl.ds.Clear();
                cl.ds.Dispose();
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











        //protected void DDType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DDistrict.SelectedIndex != 0 && DDType.SelectedIndex != 0)
        //    {
        //        cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid ='" + DDistrict.SelectedItem.Value + "' and hospitalname.htype='" + DDType.SelectedItem.Value + "') ORDER BY hospitalname.hname");
        //        DHname.DataSource = cl.ds;
        //        DHname.DataTextField = "hname";
        //        DHname.DataValueField = "sno";
        //        DHname.DataBind();
        //        DHname.Items.Insert(0, new ListItem("--select--"));
        //    }
        //}
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
            //runqual();
            print();
        }
        protected void Refresh_Click(object sender, EventArgs e)
        {

        }
        public void printXX()
        {
            string dividC, districtidC, DHtC, DHnaC, postC, cadC, lavC;
            //***************DIVISION****************
            if (this.DDiv.SelectedIndex != 0)
            { dividC = "%" + DDiv.SelectedItem.Value + "%"; }
            else { dividC = "%"; }
            Session.Add("dividC", dividC);
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            { districtidC = "%" + DDistrict.SelectedItem.Value + "%"; }
            else { districtidC = "%"; }
            Session.Add("districtidC", districtidC);
            //**************HOSPITAL TYPE*****************
            //if (this.DDType.SelectedIndex != 0)
            //{ DHtC = "%" + DDType.SelectedItem.Value + "%"; }
            //else { DHtC = "%"; }
            //Session.Add("DHtC", DHtC);
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            { DHnaC = "%" + DHname.SelectedItem.Value + "%"; }
            else { DHnaC = "%"; }
            Session.Add("DHnaC", DHnaC);
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            { postC = "%" + Dpost.SelectedItem.Value + "%"; }
            else { postC = "%"; }
            Session.Add("postC", postC);
            //***************CADRE****************
            if (this.DCadre.SelectedIndex != 0)
            { cadC = "%" + DCadre.SelectedItem.Value + "%"; }
            else { cadC = "%"; }
            Session.Add("cadC", cadC);
            //***************LEVEL****************
            if (this.Dlevel.SelectedIndex != 0)
            { lavC = "%" + Dlevel.SelectedItem.Value + "%"; }
            else { lavC = "%"; }
            Session.Add("lavC", lavC);
            Response.Write("<script language=javascript>window.open('paraCurrentlistprint.aspx' ,'new_Win');</script>");
            //Response.Redirect("~/Proforma2/Currentlistprint.aspx");
        }
        public void print()
        {
            string districtid, DHt, DHna, post, cad, lav;//divid,
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
            { districtid = DDistrict.SelectedItem.Value; }
            else { districtid = "N"; }
            //**************HOSPITAL TYPE*****************
            //if (this.DDType.SelectedIndex != 0)
            //{ DHt =DDType.SelectedItem.Value; }
            //else { DHt = "N"; }       
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            { DHna = DHname.SelectedItem.Value; }
            else { DHna = "N"; }
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            { post = Dpost.SelectedItem.Value; }
            else { post = "N"; }
            //***************CADRE****************
            if (this.DCadre.SelectedIndex != 0)
            { cad = DCadre.SelectedItem.Value; }
            else { cad = "N"; }
            //***************LEVEL****************
            if (this.Dlevel.SelectedIndex != 0)
            { lav = Dlevel.SelectedItem.Value; }
            else { lav = "N"; }
            //Response.Write("<script language=javascript>window.open('Currentlistprint.aspx?Div=" + Divs.Text + "&Dis=" + districtid + "&DT=" + DHt + "&HN=" + DHna + "&Post=" + post + "&cader=" + cad + "&lavel=" + lav + "','new_Win');</script>");
            // Response.Write("<script language=javascript>window.open('Currentlistprint.aspx' ,'new_Win');</script>");
            //Response.Write("<script language=javascript>window.open('Currlistallprint.aspx' ,'new_Win');</script>");
            Response.Redirect("paraCurrentlistprint.aspx?Div=" + Divs.Text + "&Dis=" + districtid + "&HN=" + DHna + "&Post=" + post + "&cader=" + cad + "&feedincadre=" + lav + "");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            print();
        }
        protected void AllLink_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/RepOption.aspx");
        }
    }
}