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

namespace NewWebApp.proforma
{
    public partial class ListOfHospital : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); //jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                if ((string)(Session["REP"]) == "P1Detail")
                {
                    Hospnamep1det();
                }
                else if ((string)(Session["REP"]) == "P1vsP2")
                {
                    Hospnamep1vsp2();
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
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        public void Hospnamep1vsp2()
        {
            usecheck();
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                cl.ds = cl.DataFill("SELECT divname, districtname, tehsilname, blockname, htype, hname, sno,bedoccupacy FROM hospitallist order by divname, districtname, tehsilname, blockname, htype");

            }
            else
            {
                cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + Uidt.Text + "') order by divname, districtname, tehsilname, blockname, htype ");
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
                tcell0.ForeColor = System.Drawing.Color.Maroon;
                //tcell0.Font= System.Drawing.FontStyle.Bold;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "Division Name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "District Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Tehsil Name";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Block Name";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Hospital Type";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Hospital Name";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "No Of BedS";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell7);

                TableCell tcellx1 = new TableCell();
                tcellx1.Text = "P1/P2";
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
                    tcellk1.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
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
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.ForeColor = System.Drawing.Color.DarkGreen;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk11 = new TableCell();
                    tcellk11.Text = "Print P1 Vs P2";
                    tcellk11.BorderWidth = 1;
                    tcellk11.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk11);
                    //tcellk11.Text = ("<a href=\'vacantpostdetails.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk11.Text + ")</a>")))));
                    tcellk11.Text = ("<a target='_blank' href=\'P1vsP2.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + tcellk11.Text + "</a>")));


                    Table1.Rows.Add(rw1);

                }
            }
        }

        public void Hospnamep1det()
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
                cl.ds = cl.DataFill("SELECT divname, districtname, tehsilname, blockname, htype, hname, sno,bedoccupacy FROM hospitallist order by divname, districtname, tehsilname, blockname, htype");

            }
            else
            {
                cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + Uidt.Text + "') order by divname, districtname, tehsilname, blockname, htype ");
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
                tcell0.ForeColor = System.Drawing.Color.Maroon;
                //tcell0.Font= System.Drawing.FontStyle.Bold;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "Division Name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "District Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Tehsil Name";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Block Name";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Hospital Type";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Hospital Name";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "No Of BedS";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell7);

                //TableCell tcellx0 = new TableCell();
                //tcellx0.Text = "P1 Detail";
                //tcellx0.BorderWidth = 1;
                //tcellx0.BorderColor = System.Drawing.Color.SlateGray;
                //tcellx0.ForeColor = System.Drawing.Color.Maroon;
                //rw.Cells.Add(tcellx0);

                //TableCell tcellx1 = new TableCell();
                //tcellx1.Text = "P1/P2"; 
                //tcellx1.BorderWidth = 1;
                //tcellx1.BorderColor = System.Drawing.Color.SlateGray;
                //tcellx1.ForeColor = System.Drawing.Color.Maroon;
                //rw.Cells.Add(tcellx1);

                TableCell tcellx2 = new TableCell();
                tcellx2.Text = "View P1 Records";
                tcellx2.BorderWidth = 1;
                tcellx2.BorderColor = System.Drawing.Color.SlateGray;
                tcellx2.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcellx2);

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
                    tcellk1.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
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
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.ForeColor = System.Drawing.Color.DarkGreen;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);


                    TableCell tcellk12 = new TableCell();
                    tcellk12.Text = "P1";
                    tcellk12.BorderWidth = 1;
                    tcellk12.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk12);
                    tcellk12.Text = ("<a target='_blank' href=\'Hdetails.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + tcellk12.Text + "</a>")));

                    Table1.Rows.Add(rw1);

                }
            }
        }
        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/proforma/HRephome.aspx");
        }
    }
}