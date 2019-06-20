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

namespace NewWebApp.paramedicalstaff
{
    public partial class paraEditsearch : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
            }
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
            VALT.Visible = false;
        }
        public void runtablealpha()
        {

            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                if ((string)Session["pass"] == "RELRET")
                {
                    cl.ds = cl.DataFill("SELECT parastatus_join_releive.idno,parafactsearchCriteria.name,parafactsearchCriteria.gpfno,parastatus_join_releive.orderno, Convert(Char,parastatus_join_releive.orderdate,103)as orderdate,  parastatus_join_releive.orderby,Convert(Char,parastatus_join_releive.currentdate,103) as currentdate,  parastatus_join_releive.postingstatus, parastatus_join_releive.modifieruserid,parastatus_join_releive.statussr FROM parastatus_join_releive INNER JOIN  parafactsearchCriteria ON parastatus_join_releive.idno = parafactsearchCriteria.idno WHERE (parafactsearchCriteria.name LIKE '" + VALT.Text + "')And (parastatus_join_releive.postingstatus<>'J')Order By parastatus_join_releive.currentdate, name");
                }
                else if ((string)Session["pass"] == "Join")
                {
                    cl.ds = cl.DataFill("SELECT parastatus_join_releive.idno,parafactsearchCriteria.name,parafactsearchCriteria.gpfno,parastatus_join_releive.orderno, Convert(Char,parastatus_join_releive.orderdate,103)as orderdate,  parastatus_join_releive.orderby,Convert(Char,parastatus_join_releive.currentdate,103) as currentdate,  parastatus_join_releive.postingstatus, parastatus_join_releive.modifieruserid,parastatus_join_releive.statussr FROM parastatus_join_releive INNER JOIN  parafactsearchCriteria ON parastatus_join_releive.idno = parafactsearchCriteria.idno WHERE (parafactsearchCriteria.name LIKE '" + VALT.Text + "')And (parastatus_join_releive.postingstatus='J')Order By parastatus_join_releive.currentdate, name");
                }

            }
            else
            {
                if ((string)Session["pass"] == "RELRET")
                {
                    cl.ds = cl.DataFill("SELECT parastatus_join_releive.idno,parafactsearchCriteria.name,parafactsearchCriteria.gpfno,parastatus_join_releive.orderno, Convert(Char,parastatus_join_releive.orderdate,103)as orderdate,  parastatus_join_releive.orderby,Convert(Char,parastatus_join_releive.currentdate,103) as currentdate,  parastatus_join_releive.postingstatus, parastatus_join_releive.modifieruserid,parastatus_join_releive.statussr FROM parastatus_join_releive INNER JOIN  parafactsearchCriteria ON parastatus_join_releive.idno = parafactsearchCriteria.idno WHERE parastatus_join_releive.modifieruserid='" + this.Uidt.Text + "' And (parafactsearchCriteria.name LIKE '" + VALT.Text + "')And (parastatus_join_releive.postingstatus<>'J')Order By parastatus_join_releive.currentdate, name");
                }
                else if ((string)Session["pass"] == "Join")
                {
                    cl.ds = cl.DataFill("SELECT parastatus_join_releive.idno,parafactsearchCriteria.name,parafactsearchCriteria.gpfno,parastatus_join_releive.orderno, Convert(Char,parastatus_join_releive.orderdate,103)as orderdate,  parastatus_join_releive.orderby,Convert(Char,parastatus_join_releive.currentdate,103) as currentdate,  parastatus_join_releive.postingstatus, parastatus_join_releive.modifieruserid,parastatus_join_releive.statussr FROM parastatus_join_releive INNER JOIN  parafactsearchCriteria ON parastatus_join_releive.idno = parafactsearchCriteria.idno WHERE parastatus_join_releive.modifieruserid='" + this.Uidt.Text + "' And (parafactsearchCriteria.name LIKE '" + VALT.Text + "')And (parastatus_join_releive.postingstatus='J')Order By parastatus_join_releive.currentdate, name");
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
                tcell0.ForeColor = System.Drawing.Color.Maroon;
                //tcell0.Font= System.Drawing.FontStyle.Bold;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "ComputerID";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Seniority";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Order No";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "orderdate";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "orderby";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Join/Relive Date";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell7);

                TableCell tcell8 = new TableCell();
                tcell8.Text = "Posting Status";//postingstatus
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                tcell8.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell8);
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

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);
                    if ((string)Session["pass"] == "RELRET")
                    {
                        tcellk4.Text = ("<a href=\'paraEditJR.aspx?statussr=" + (cl.ds.Tables[0].Rows[j][9].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    }
                    else if ((string)Session["pass"] == "Join")
                    {
                        tcellk4.Text = ("<a href=\'paraEditJR.aspx?statussr=" + (cl.ds.Tables[0].Rows[j][9].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    }
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
                    Table1.Rows.Add(rw1);

                }
            }
        }

        public void chkdsk()
        {
            //usecheck();        
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2JRmenu.aspx");
        }
    }
}