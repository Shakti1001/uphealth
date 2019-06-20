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
    public partial class parap1recadd : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); //jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                if ((string)Session["val"] == "E")
                {
                    Hospname();
                }
                else if ((string)Session["val"] == "A")
                {
                    HospnameAdd();
                }

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

        public void Hospname()
        {
            usecheck();
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            //SELECT     TOP 100 PERCENT dbo.division.divname, dbo.hospitaldistrict.districtname, dbo.Tehsil.tehsilname, dbo.hospitaltype.htype, dbo.hospitalname.hname, 
            //                      dbo.hospitalname.bedoccupacy, dbo.division.divid, dbo.hospitaldistrict.districtid, dbo.Tehsil.tehsilid, dbo.hospitaltype.hid, dbo.hospitalname.sno, 
            //                      dbo.Block.blockid, dbo.Block.blockname
            //FROM         dbo.hospitalname INNER JOIN
            //                      dbo.hospitaldistrict ON dbo.hospitalname.districtid = dbo.hospitaldistrict.districtid INNER JOIN
            //                      dbo.division ON dbo.hospitaldistrict.divid = dbo.division.divid INNER JOIN
            //                      dbo.Tehsil ON dbo.hospitalname.tehsilid = dbo.Tehsil.tehsilid INNER JOIN
            //                      dbo.hospitaltype ON dbo.hospitalname.htype = dbo.hospitaltype.hid INNER JOIN
            //                      dbo.Block ON dbo.hospitalname.blockid = dbo.Block.blockid
            //ORDER BY dbo.hospitaldistrict.districtname, dbo.hospitaltype.htype, dbo.hospitalname.hname
            if (i == true)
            {
                cl.ds = cl.DataFill("SELECT divname, districtname, tehsilname, blockname, htype, hname, sno,bedoccupacy FROM hospitallist");

            }
            else
            {
                cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + Uidt.Text + "') ");
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
                //tcell0.ForeColor = System.Drawing.Color.Maroon;
                //tcell0.Font= System.Drawing.FontStyle.Bold;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "Division Name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                //tcell1.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "District Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                //tcell2.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Tehsil Name";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                //tcell3.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Block Name";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                //tcell4.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Hospital Type";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                // tcell5.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Hospital Name";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell6);

                //TableCell tcell8 = new TableCell();
                //tcell8.Text = "ADD P1 Records";
                //tcell8.BorderWidth = 1;
                //tcell8.BorderColor = System.Drawing.Color.SlateGray;
                ////tcell8.ForeColor = System.Drawing.Color.Maroon;
                //rw.Cells.Add(tcell8);

                TableCell tcell9 = new TableCell();
                tcell9.Text = "Add/Edit P1";
                tcell9.BorderWidth = 1;
                tcell9.BorderColor = System.Drawing.Color.SlateGray;
                //tcell9.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell9);

                TableCell tcellx1 = new TableCell();
                tcellx1.Text = "Print P1";
                tcellx1.BorderWidth = 1;
                tcellx1.BorderColor = System.Drawing.Color.SlateGray;
                tcellx1.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcellx1);

                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.Black;
                    rw1.ForeColor = System.Drawing.Color.Maroon;
                    rw1.BackColor = System.Drawing.Color.LemonChiffon;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk1.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk1.BackColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk2.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk2.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk3.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk3.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk4.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk4.BackColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);


                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk5.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk5.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk6.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk6.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.ForeColor = System.Drawing.Color.DarkGreen;
                    //tcellk7.BackColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);
                    //tcellk7.Text = ("<a href=\'Hdetails.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk7.Text + ")</a>")))));


                    //ADD Hospital(POST)Details
                    //// TableCell tcellk9 = new TableCell();
                    //// tcellk9.Text = "ADD P1";
                    //// tcellk9.BorderWidth = 1;
                    //// tcellk9.BorderColor = System.Drawing.Color.SlateGray;
                    ////// tcellk9.ForeColor = System.Drawing.Color.MidnightBlue;
                    //// //tcellk9.BackColor = System.Drawing.Color.SlateGray;
                    //// rw1.Cells.Add(tcellk9);                
                    //// Session.Add("val", "A");
                    //// tcellk9.Text = ("<a   href=\'Hpcheckpost.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk9.Text + " )</a>")))));//Request.QueryString["idno"]




                    //Print Details
                    TableCell tcellk10 = new TableCell();
                    tcellk10.Text = "Add/Edit";
                    tcellk10.BorderWidth = 1;
                    tcellk10.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk10.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk10.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk10);

                    Session.Add("val", "E");
                    //tcellk10.Text = ("<a href=\'Hpcheckpost.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk10.Text + ")</a>")))));
                    tcellk10.Text = ("<a href=\'parap1rec.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + tcellk10.Text + "</a>")));


                    TableCell tcellk11 = new TableCell();
                    tcellk11.Text = "Print";
                    tcellk11.BorderWidth = 1;
                    tcellk11.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk11);
                    //tcellk11.Text = ("<a href=\'Hdetails.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk11.Text + ")</a>")))));


                    //tcellk11.Text = ("<script language=javascript>window.open(\'Hpcheckpost.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString()) + (" &idno=" + (tcellk11.Text) + "\',\'new_Win\');</script>"));
                    tcellk11.Text = ("<a target='_blank' href=\'parap1hdet.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + tcellk11.Text + "</a>")));
                    //<a href="zz.html" target="_blank">About</a>


                    ////<script language="javascript">
                    ////function showwindow()
                    ////    { 
                    ////        handle1=window.open("WebForm3.aspx?selectedcategory="+"","handle1","toolbar=no,location=no,status=no,menubar=no,scrollbars=no,width=850,height=600"); 
                    ////    }
                    ////</script>
                    Table1.Rows.Add(rw1);

                }
            }
        }


        public void HospnameAdd()
        {
            usecheck();
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                cl.ds = cl.DataFill("SELECT divname, districtname, tehsilname, blockname, htype, hname, sno,bedoccupacy FROM hospitallist");

            }
            else
            {
                cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + Uidt.Text + "') ");
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
                tcell1.Text = "Division Name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "District Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Tehsil Name";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Block Name";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Hospital Type";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Hospital Name";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell6);

                TableCell tcell8 = new TableCell();
                tcell8.Text = "ADD P1 Records";
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell8);

                Table2.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.Black;
                    rw1.ForeColor = System.Drawing.Color.Maroon;
                    rw1.BackColor = System.Drawing.Color.LemonChiffon;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk1.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk1.BackColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk2.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk2.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk3.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk3.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk4.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk4.BackColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);


                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk6.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk6.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.ForeColor = System.Drawing.Color.DarkGreen;
                    //tcellk7.BackColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);
                    //tcellk7.Text = ("<a href=\'Hdetails.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk7.Text + ")</a>")))));


                    //ADD Hospital(POST)Details
                    TableCell tcellk9 = new TableCell();
                    tcellk9.Text = "ADD P1";
                    tcellk9.BorderWidth = 1;
                    tcellk9.BorderColor = System.Drawing.Color.SlateGray;
                    // tcellk9.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk9.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk9);
                    Session.Add("val", "A");
                    tcellk9.Text = ("<a   href=\'parap1rec.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk9.Text + " )</a>")))));//Request.QueryString["idno"]

                    Table2.Rows.Add(rw1);

                }
            }
        }
        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap1home.aspx");
        }
    }
}