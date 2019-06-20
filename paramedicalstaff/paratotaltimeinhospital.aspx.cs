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
    public partial class paratotaltimeinhospital : System.Web.UI.Page
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

            }
            else
            {
                DDiv.Visible = false;
                DL.Visible = false;
                //DL.Text = "Division Selected ";
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
            //****************        
            cl.ds = cl.DataFill("SELECT distinct(cadrename), cadreid FROM  PMDCadre ORDER BY cadrename");
            DCadre.DataSource = cl.ds;
            DCadre.DataTextField = "cadrename";
            DCadre.DataValueField = "cadreid";
            DCadre.DataBind();
            DCadre.Items.Insert(0, new ListItem("--select--"));
            //***************************
            cl.ds = cl.DataFill("SELECT htype, hid FROM         hospitaltype ORDER BY htype");
            DDType.DataSource = cl.ds;
            DDType.DataTextField = "htype";
            DDType.DataValueField = "hid";
            DDType.DataBind();
            DDType.Items.Insert(0, new ListItem("--select--"));

            //***************************        
            cl.ds = cl.DataFill("SELECT     Desigid, designame FROM         PMDhospitaldesignation ORDER BY Desigid");
            Dpost.DataSource = cl.ds;
            Dpost.DataTextField = "designame";
            Dpost.DataValueField = "Desigid";
            Dpost.DataBind();
            Dpost.Items.Insert(0, new ListItem("--select--"));
            //********************

        }

        public void runqualTIME()
        {
            //string Dist, DHna, DHt,  post, cad ;
            string q1, q3, q4, q5, qr1, qr2;//q2,q6, q7, q8,
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            {
                q1 = "DisId =" + DDistrict.SelectedItem.Value + "";
            }
            else { q1 = "DisId like '%'"; }

            //**************HOSPITAL TYPE*****************
            //if (this.DDType.SelectedIndex != 0)
            //{ q2 = "sno=" + DDType.SelectedItem.Value + ""; }
            //else { q2 = "sno like '%'"; }
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            { q3 = "sno=" + DHname.SelectedItem.Value + ""; }
            else { q3 = "sno like '%'"; }
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            { q4 = "postid=" + Dpost.SelectedItem.Value + ""; }
            else { q4 = "postid like '%'"; }
            //***************CADRE****************
            if (this.DCadre.SelectedIndex != 0)
            { q5 = "cadreid=" + DCadre.SelectedItem.Value + ""; }
            else { q5 = "cadreid like '%'"; }
            ////*****************COMPUTER NO**************
            //if (this.cmpuno.Text != "")
            //{ q3 = "idno=" + cmpuno.Text + ""; }
            //else { q3 = "idno like '%'"; }
            //if (this.Sen.Text != "")
            //***************GPFNO****************
            //{ q6 = "gpfno=" + Sen.Text + ""; }
            //else { q6 = "gpfno like '%'"; }
            ////***************NAME****************
            //if (this.name.Text != "")
            //{ q7 = "name like '%" + name.Text + "%'"; }
            //else { q7 = "name like '%'"; }
            ////***************FNAME****************
            //if (this.fname.Text != "")
            //{ q8 = "fathername like '%" + fname.Text + "%'"; }
            //else { q8 = "fathername like '%'"; }

            qr1 = " And " + q1 + " And " + q3 + " And " + q4 + " AND " + q5 + "";//And " + q9 + "
            qr2 = " And " + q3 + " And " + q4 + " AND " + q5 + "";
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
            //**********************

            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                cl.ds = cl.DataFill("SELECT DISTINCT  idno AS ComputerID, gpfno AS Seniority, name AS Name, designame AS Post, districtname AS Posting, hname AS Hospital, CONVERT(varchar, doposting, 103) AS DateOfPosting, CONVERT(varchar,dob,103) AS DateofBirth, fathername AS Fname, cadrename AS Cader, ROUND(YEARA / 12.0, 2) AS Ctime, DisId FROM         paracurrentsearchCriteria WHERE (YEARA/12 >'" + Convert.ToInt32(this.Nytext.Text) + "') and (divid LIKE '" + Divs.Text + "')" + qr1 + " order by districtname,hname, name"); //AND (DisId LIKE '" + Dist + "')AND (sno LIKE '" + DHna + "')AND (postid LIKE '" + post + "')  AND (cadreid LIKE '" + cad + "') 
            }
            else
            {
                cl.ds = cl.DataFill("SELECT DISTINCT  idno AS ComputerID, gpfno AS Seniority, name AS Name, designame AS Post, districtname AS Posting, hname AS Hospital, CONVERT(varchar, doposting, 103) AS DateOfPosting, CONVERT(varchar,dob,103) AS DateofBirth, fathername AS Fname, cadrename AS Cader, ROUND(YEARA / 12.0, 2) AS Ctime, DisId FROM         paracurrentsearchCriteria WHERE (YEARA/12 >'" + Convert.ToInt32(this.Nytext.Text) + "')and (DisId ='" + Uidt.Text + "') " + qr1 + " order by districtname,hname, name");//AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "') AND (cadreid LIKE '" + cad + "')order by districtname, hname,name");

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
                tcell5.Text = "Posting";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Hospital";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Date Of Posting";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell7);

                TableCell tcell8 = new TableCell();
                tcell8.Text = "DateofBirth";
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell8);

                TableCell tcell9 = new TableCell();
                tcell9.Text = "Fathername";
                tcell9.BorderWidth = 1;
                tcell9.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell9);

                TableCell tcell11 = new TableCell();
                tcell11.Text = "Cader";
                tcell11.BorderWidth = 1;
                tcell11.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell11);

                TableCell tcellXX1 = new TableCell();
                tcellXX1.Text = "Year Completed";
                tcellXX1.BorderWidth = 1;
                tcellXX1.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcellXX1);

                TableCell tcellX1 = new TableCell();
                tcellX1.Text = "View";
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

                    TableCell tcellk9 = new TableCell();
                    tcellk9.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcellk9.BorderWidth = 1;
                    tcellk9.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk9);

                    TableCell tcellk10 = new TableCell();
                    tcellk10.BorderWidth = 1;
                    tcellk10.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk10.Text = cl.ds.Tables[0].Rows[j][8].ToString();
                    rw1.Cells.Add(tcellk10);

                    //TableCell tcellk11 = new TableCell();
                    //tcellk11.Text = cl.ds.Tables[0].Rows[j][9].ToString();
                    //tcellk11.BorderWidth = 1;
                    //tcellk11.BorderColor = System.Drawing.Color.SlateGray;
                    //rw1.Cells.Add(tcellk11);

                    TableCell tcellk12 = new TableCell();
                    tcellk12.Text = cl.ds.Tables[0].Rows[j][9].ToString();
                    tcellk12.BorderWidth = 1;
                    tcellk12.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk12);

                    //sancode = (this.DropDownList1.SelectedItem.Text.Trim().Substring(0, 1) + ("-" + (this.DropDownList1.SelectedItem.Text.Trim().Substring((this.DropDownList1.SelectedItem.Text.Trim().Length - 1)) + ("/" + (this.DropDownList2.SelectedItem.Text.Trim().Substring(0, 1) + ("/" + this.DropDownList3.SelectedItem.Text.Trim().Substring(0, 1)))))));

                    TableCell tcelltottime = new TableCell();
                    tcelltottime.Text = cl.ds.Tables[0].Rows[j][10].ToString();
                    tcelltottime.Text = (tcelltottime.Text).Trim().Substring(0, 4) + " " + "year";
                    tcelltottime.BorderWidth = 1;
                    tcelltottime.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcelltottime);

                    TableCell tcellk13 = new TableCell();
                    tcellk13.Text = "P2";
                    tcellk13.BorderWidth = 1;
                    tcellk13.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk13);
                    tcellk13.Text = ("<a target='_blank' href=\'parap2Factsheetprint.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk13.Text + "</a>")));//("\'>"  + tcellk10.Text +"</a>")));


                    Table2.Rows.Add(rw1);

                }
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            try { runqualTIME(); }
            catch (Exception ex) { Response.Write(ex); }
            finally { }
        }


        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DDType_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void Refresh_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2ReportOption.aspx");
        }
    }
}