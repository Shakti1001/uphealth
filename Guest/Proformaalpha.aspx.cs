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

namespace NewWebApp.Guest
{
    public partial class Proformaalpha : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string DDOUsermacth;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((string)Session["iduser"] == null)
            //{
            //    Response.Redirect("~/login.aspx"); ;//jump to first page for login
            //}
            //Fnamet.Text = (string)Session["fullname"];

        }


        public void runtablealpha()
        {



            //usecheck();        
            //bool i;
            //i = cl.checklavel((string)Session["iduser"]);
            ////if (i == true)
            ////{
            ////    //cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM Factsheet WHERE (name LIKE '" + VALT.Text + "')order by districtname, name");

            ////    cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno,districtname,dob, doa,doj ,  cdistrict, newpostname  FROM guestview WHERE (name LIKE '" + VALT.Text + "')  order by  name ");


            ////}
            ////else
            ////{

            //cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno,dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM Factsheet WHERE  (name LIKE '" + VALT.Text + "')and (postingstatus='J') " + DDOUsermacth + " order by districtname, name ");

            cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno,districtname,dob, doa,doj ,  cdistrict, newpostname  FROM guestview WHERE  (name LIKE '" + VALT.Text + "') " + DDOUsermacth + "  order by  name ");


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
            //    tcell91.Text = "View";
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
            //        tcellk1.Text = Convert.ToString(j + 1);
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
            //        tcellk110.Text = "P2";
            //        rw1.Cells.Add(tcellk110);
            //        tcellk110.Text = ("<a target='_blank' href=\'DoctorP2.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk110.Text + "</a>")));


            //        Table2.Rows.Add(rw1);

            //    }
            //}




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
                tcell1.Text = "CompId";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                //tcell1.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                //tcell2.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Sen.No";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                //tcell3.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "HomeDistrict";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                //tcell4.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "DateOfBirth";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                //tcell5.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "DateOfAppointment";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "DateOfJoining";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                //tcell7.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell7);

                //TableCell tcell8 = new TableCell();
                //tcell8.Text = "Posting Status";
                //tcell8.BorderWidth = 1;
                //tcell8.BorderColor = System.Drawing.Color.SlateGray;
                ////tcell8.ForeColor = System.Drawing.Color.Maroon;
                //rw.Cells.Add(tcell8);

                //TableCell tcell9 = new TableCell();
                //tcell9.Text = "Cadresenno";
                //tcell9.BorderWidth = 1;
                //tcell9.BorderColor = System.Drawing.Color.SlateGray;
                ////tcell9.ForeColor = System.Drawing.Color.Maroon;
                //rw.Cells.Add(tcell9);


                TableCell tcell9 = new TableCell();
                tcell9.Text = "PresentDistrict";
                tcell9.BorderWidth = 1;
                tcell9.BorderColor = System.Drawing.Color.SlateGray;
                //tcell9.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell9);



                TableCell tcell99 = new TableCell();
                tcell99.Text = "Post";
                tcell99.BorderWidth = 1;
                tcell99.BorderColor = System.Drawing.Color.SlateGray;
                //tcell9.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell99);






                TableCell tcell91 = new TableCell();
                tcell91.Text = "View";
                tcell91.BorderWidth = 1;
                tcell91.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell91);

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
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();//cmp id
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk2.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk2.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);



                    TableCell tcellk41 = new TableCell();
                    tcellk41.BorderWidth = 1;
                    tcellk41.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk41.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    rw1.Cells.Add(tcellk41);







                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);
                    //tcellk4.Text = ("<a href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));


                    //TableCell tcellk3 = new TableCell();
                    //tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    //tcellk3.BorderWidth = 1;
                    //tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    //rw1.Cells.Add(tcellk3);


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

                    //TableCell tcellk101 = new TableCell();
                    //tcellk101.BorderWidth = 1;
                    //tcellk101.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk101.Text = cl.ds.Tables[0].Rows[j][9].ToString();
                    //rw1.Cells.Add(tcellk101);

                    //TableCell tcellk102 = new TableCell();
                    //tcellk102.BorderWidth = 1;
                    //tcellk102.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk102.Text = cl.ds.Tables[0].Rows[j][10].ToString();
                    //rw1.Cells.Add(tcellk102);






                    TableCell tcellk110 = new TableCell();
                    tcellk110.BorderWidth = 1;
                    tcellk110.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk110.Text = "P2";
                    rw1.Cells.Add(tcellk110);
                    tcellk110.Text = ("<a target='_blank' href=\'DoctorP2.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk110.Text + "</a>")));


                    Table2.Rows.Add(rw1);

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
                DDOUsermacth = "";
            }
            else
            {
                ////// changes on date june 10 2011
                ////    //    //DDO and Userid match
                //if ((string)Session["UsDisId"] != null && (string)Session["ddoid"] != null)
                //{
                //    Uidt.Text = (string)Session["UsDisId"];
                //    DDOUsermacth = " and poposting  in (select sno from hospitalname where ddoid=" + (string)Session["ddoid"] + ")";
                //    //distsublbl.Text = cl.getdistlv((string)Session["UsHtype"]);
                // }

                //    //Uidt.Text = cl.checklavel_Dist((string)Session["iduser"]).Substring(2, 2);
                ////cl.ds = cl.DataFill("SELECT DisId,DDOID FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                ////if (cl.ds.Tables[0].Rows.Count > 0)
                ////{
                ////   Uidt.Text = cl.ds.Tables[0].Rows[0]["DisId"].ToString();
                ////    DDOIDLBL.Text = cl.ds.Tables[0].Rows[0]["DDOID"].ToString();
                ////   }


                //// *************************************************
                //// Hospital allotted to user  (string)Session["iduser"]
                if ((string)Session["iduser"] != null && (string)Session["UsDisId"] != null)
                {
                    Uidt.Text = (string)Session["UsDisId"];
                    DDOUsermacth = " and poposting in (select sno from hospitalname where ddoid=" + (string)Session["iduser"] + ")";
                }
                else
                {
                    //Response.Redirect("~/login.aspx");
                }
            }
        }







        public void chkdsk()
        {
            //usecheck();
            //cl.ds = cl.DataFill("SELECT count(DISTINCT(idno))As  CTot  FROM  Factsheet where name LIKE '" + VALT.Text + "'AND DisId LIKE '" + Uidt.Text + "' ");
            cl.ds = cl.DataFill("SELECT count(DISTINCT(idno))As  CTot  FROM  Factsheet where name LIKE '" + VALT.Text + "'");


            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Ctot.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Ctot.Text = "no Record Find";
            }
        }


        public void recount()
        {
            cl.ds = cl.DataFill("SELECT count(DISTINCT( idno))As  CTot  FROM  Factsheet where name LIKE '" + VALT.Text + "'AND DisId LIKE '" + Uidt.Text + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Ctot.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Ctot.Text = "no Record Find";
            }
        }
        protected void Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/newguest/ghome.aspx");
        }

        //***********************For Alphabetical Order***********************
        protected void A_Click(object sender, EventArgs e)
        {
            VALT.Text = "A%";
            chkdsk();
            runtablealpha();

        }
        protected void B_Click(object sender, EventArgs e)
        {
            VALT.Text = "b%";
            chkdsk();
            runtablealpha();

        }
        protected void C_Click(object sender, EventArgs e)
        {
            VALT.Text = "c%";
            chkdsk();
            runtablealpha();

        }
        protected void D_Click(object sender, EventArgs e)
        {
            VALT.Text = "d%";
            chkdsk();
            runtablealpha();

        }
        protected void E_Click(object sender, EventArgs e)
        {
            VALT.Text = "e%";
            chkdsk();
            runtablealpha();

        }
        protected void F_Click(object sender, EventArgs e)
        {
            VALT.Text = "f%";
            chkdsk();
            runtablealpha();

        }
        protected void G_Click(object sender, EventArgs e)
        {
            VALT.Text = "g%";
            chkdsk();
            runtablealpha();

        }
        protected void H_Click(object sender, EventArgs e)
        {
            VALT.Text = "h%";
            chkdsk();
            runtablealpha();

        }
        protected void I_Click(object sender, EventArgs e)
        {
            VALT.Text = "i%";
            chkdsk();
            runtablealpha();

        }
        protected void J_Click(object sender, EventArgs e)
        {
            VALT.Text = "j%";
            chkdsk();
            runtablealpha();

        }
        protected void K_Click(object sender, EventArgs e)
        {
            VALT.Text = "k%";
            chkdsk();
            runtablealpha();

        }
        protected void L_Click(object sender, EventArgs e)
        {
            VALT.Text = "l%";
            chkdsk();
            runtablealpha();

        }
        protected void M_Click(object sender, EventArgs e)
        {
            VALT.Text = "m%";
            chkdsk();
            runtablealpha();

        }
        protected void N_Click(object sender, EventArgs e)
        {
            VALT.Text = "n%";
            chkdsk();
            runtablealpha();

        }
        protected void O_Click(object sender, EventArgs e)
        {
            VALT.Text = "o%";
            chkdsk();
            runtablealpha();

        }
        protected void P_Click(object sender, EventArgs e)
        {
            VALT.Text = "p%";
            chkdsk();
            runtablealpha();

        }
        protected void Q_Click(object sender, EventArgs e)
        {
            VALT.Text = "q%";
            chkdsk();
            runtablealpha();

        }
        protected void R_Click(object sender, EventArgs e)
        {
            VALT.Text = "r%";
            chkdsk();
            runtablealpha();

        }
        protected void S_Click(object sender, EventArgs e)
        {
            VALT.Text = "s%";
            chkdsk();
            runtablealpha();

        }
        protected void T_Click(object sender, EventArgs e)
        {
            VALT.Text = "t%";
            chkdsk();
            runtablealpha();

        }
        protected void U_Click(object sender, EventArgs e)
        {
            VALT.Text = "u%";
            chkdsk();
            runtablealpha();

        }
        protected void V_Click(object sender, EventArgs e)
        {
            VALT.Text = "v%";
            chkdsk();
            runtablealpha();

        }
        protected void W_Click(object sender, EventArgs e)
        {
            VALT.Text = "w%";
            chkdsk();
            runtablealpha();

        }
        protected void X_Click(object sender, EventArgs e)
        {
            VALT.Text = "x%";
            chkdsk();
            runtablealpha();

        }
        protected void Y_Click(object sender, EventArgs e)
        {
            VALT.Text = "y%";
            chkdsk();
            runtablealpha();

        }
        protected void Z_Click(object sender, EventArgs e)
        {
            VALT.Text = "z%";
            chkdsk();
            runtablealpha();

        }
        protected void VALT_TextChanged(object sender, EventArgs e)
        {
            VALT.Text = "%" + VALT.Text + "" + "%";
            chkdsk();
            //runtablealpha();
            VALT.Visible = false;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno,dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM Factsheet  order by  name ");

            cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno,districtname,dob, doa,doj ,  cdistrict, newpostname  FROM guestview  order by  name ");



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
                tcell1.Text = "CompId";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                //tcell1.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                //tcell2.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Sen.No";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                //tcell3.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "HomeDistrict";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                //tcell4.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "DateOfBirth";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                //tcell5.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "DateOfAppoint.";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "DateOfJoining";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                //tcell7.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell7);

                //TableCell tcell8 = new TableCell();
                //tcell8.Text = "Posting Status";
                //tcell8.BorderWidth = 1;
                //tcell8.BorderColor = System.Drawing.Color.SlateGray;
                ////tcell8.ForeColor = System.Drawing.Color.Maroon;
                //rw.Cells.Add(tcell8);

                //TableCell tcell9 = new TableCell();
                //tcell9.Text = "Cadresenno";
                //tcell9.BorderWidth = 1;
                //tcell9.BorderColor = System.Drawing.Color.SlateGray;
                ////tcell9.ForeColor = System.Drawing.Color.Maroon;
                //rw.Cells.Add(tcell9);


                TableCell tcell9 = new TableCell();
                tcell9.Text = "PresentDistrict";
                tcell9.BorderWidth = 1;
                tcell9.BorderColor = System.Drawing.Color.SlateGray;
                //tcell9.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell9);



                TableCell tcell99 = new TableCell();
                tcell99.Text = "PresentPost";
                tcell99.BorderWidth = 1;
                tcell99.BorderColor = System.Drawing.Color.SlateGray;
                //tcell9.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell99);






                TableCell tcell91 = new TableCell();
                tcell91.Text = "View";
                tcell91.BorderWidth = 1;
                tcell91.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell91);

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
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();//cmp id
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk2.ForeColor = System.Drawing.Color.MidnightBlue;
                    //tcellk2.BackColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);



                    TableCell tcellk41 = new TableCell();
                    tcellk41.BorderWidth = 1;
                    tcellk41.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk41.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    rw1.Cells.Add(tcellk41);







                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);
                    //tcellk4.Text = ("<a href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));


                    //TableCell tcellk3 = new TableCell();
                    //tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    //tcellk3.BorderWidth = 1;
                    //tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    //rw1.Cells.Add(tcellk3);


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

                    //TableCell tcellk101 = new TableCell();
                    //tcellk101.BorderWidth = 1;
                    //tcellk101.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk101.Text = cl.ds.Tables[0].Rows[j][9].ToString();
                    //rw1.Cells.Add(tcellk101);

                    //TableCell tcellk102 = new TableCell();
                    //tcellk102.BorderWidth = 1;
                    //tcellk102.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk102.Text = cl.ds.Tables[0].Rows[j][10].ToString();
                    //rw1.Cells.Add(tcellk102);






                    TableCell tcellk110 = new TableCell();
                    tcellk110.BorderWidth = 1;
                    tcellk110.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk110.Text = "P2";
                    rw1.Cells.Add(tcellk110);
                    tcellk110.Text = ("<a target='_blank' href=\'DoctorP2.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk110.Text + "</a>")));


                    Table2.Rows.Add(rw1);

                }
            }

        }
    }
}