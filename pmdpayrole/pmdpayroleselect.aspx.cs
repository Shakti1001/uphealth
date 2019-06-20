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

namespace NewWebApp.pmdpayrole
{
    public partial class pmdpayroleselect : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string DDOUsermacth;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["iduser"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            Fnamet.Text = (string)Session["fullname"];

        }
        public void runtablealpha()
        {
            usecheck();
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                //new comment cl.ds = cl.DataFill("SELECT     idno, senno, name, fathername, dob, districtname, post, hname FROM         salaryselect WHERE     (idno NOT IN(SELECT     idno FROM Pay_sal_mast))and (name LIKE '" + VALT.Text +"') "+ DDOUsermacth + " order by  name");
                cl.ds = cl.DataFill("SELECT     idno, senno, name, fathername, dob, districtname, post, hname FROM  pmd_salaryselect WHERE name LIKE '" + VALT.Text + "' " + DDOUsermacth + " order by  name");//copy
                //cl.ds = cl.DataFill("SELECT idno, senno, name, fathername, dob, districtname, post, hname FROM salaryselect  WHERE (name LIKE '" + VALT.Text + "')and ddoid='" + (string)Session["ddo"]+ "'order by  name");//Request.QueryString["a"]

            }
            else
            {
                //cl.ds = cl.DataFill("SELECT idno, senno, name, fathername, dob, districtname, post, hname FROM salaryselect WHERE     (idno NOT IN(SELECT     idno FROM Pay_sal_mast))and (districtid ='" + Uidt.Text + "') AND (name LIKE '" + VALT.Text + "')and  ddoid='" + (string)Session["ddo"] + "'order by  name ");
                //    new comment cl.ds = cl.DataFill("SELECT idno, senno, name, fathername, dob, districtname, post, hname FROM salaryselect WHERE     (idno NOT IN(SELECT     idno FROM Pay_sal_mast)) AND (name LIKE '" + VALT.Text + "') " + DDOUsermacth + " order by  name ");
                cl.ds = cl.DataFill("SELECT idno, senno, name, fathername, dob, districtname, post, hname FROM pmd_salaryselect WHERE  name LIKE '" + VALT.Text + "' " + DDOUsermacth + " order by  name ");//copy

            }
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                mesl.Visible = false;
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.Black;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.White;
                tcell0.ForeColor = System.Drawing.Color.Maroon;
                //tcell0.Font= System.Drawing.FontStyle.Bold;
                rw.Cells.Add(tcell0);



                TableCell tcell1 = new TableCell();
                tcell1.Text = "ComputerID";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.White;
                tcell1.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Seniority";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.White;
                tcell2.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell2);


                TableCell tcell3 = new TableCell();
                tcell3.Text = "Name";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.White;
                tcell3.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Fathername";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.White;
                tcell4.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "DateofBirth";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.White;
                tcell5.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Posting District";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.White;
                tcell6.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Post";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.White;
                tcell7.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell7);

                TableCell tcell8 = new TableCell();
                tcell8.Text = "Hospital Name";
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.White;
                tcell8.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell8);

                TableCell tcell9 = new TableCell();
                tcell9.Text = "Status";
                tcell9.BorderWidth = 1;
                tcell9.BorderColor = System.Drawing.Color.White;
                tcell9.ForeColor = System.Drawing.Color.Maroon;
                rw.Cells.Add(tcell9);

                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    string idnum = cl.ds.Tables[0].Rows[j][0].ToString();
                    cl.dsst = cl.DataFillSt("select payid from pmd_pay_sal_mast where idno='" + idnum + "'");

                    if (cl.dsst.Tables[0].Rows.Count > 0)
                    {
                        Label1.Text = "(E)";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label1.Text = "(B)";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.Black;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.White;
                    tcellk1.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk1.BackColor = System.Drawing.Color.White;
                    tcellk1.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.White;
                    tcellk2.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk2.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.White;
                    tcellk3.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk3.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.White;
                    //tcellk4.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk4.BackColor = System.Drawing.Color.White;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);
                    //tcellk4.Text = ("<a href=\'paymast.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    //tcellk4.Text = ("<a href=\'payearnings.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    tcellk4.Text = ("<a href=\'pmdpmast.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.White;
                    tcellk5.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk5.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk5);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.White;
                    tcellk6.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk6.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.White;
                    tcellk7.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk7.BackColor = System.Drawing.Color.White;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.White;
                    tcellk8.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk8.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk9 = new TableCell();
                    tcellk9.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcellk9.BorderWidth = 1;
                    tcellk9.BorderColor = System.Drawing.Color.White;
                    tcellk9.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk9.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk9);
                    Table1.Rows.Add(rw1);

                    TableCell tcellk10 = new TableCell();
                    tcellk10.Text = Label1.Text;
                    tcellk10.BorderWidth = 1;
                    tcellk10.BorderColor = System.Drawing.Color.White;
                    tcellk10.ForeColor = Label1.ForeColor;
                    tcellk10.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk10);

                }
            }
            else
            {
                mesl.Visible = true;
                mesl.Text = "Sorry, There Is No Data According To This DDO,Please Select DDO";
            }
        }
        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {

                if ((string)Session["ddopid"] != null)
                {
                    Uidt.Text = "%";
                    DDOUsermacth = " and sno in (select sno from hospitalname where ddoid=" + (string)Session["ddopid"] + ")";

                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            else
            {
                //cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                //if (cl.ds.Tables[0].Rows.Count > 0)
                //{
                //    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                //}
                //else
                //{
                //    Response.Redirect("~/login.aspx");
                //}
                //// *************************************************
                //// Hospital allotted to user  (string)Session["iduser"] 
                if ((string)Session["UsDisId"] != null && (string)Session["ddopid"] != null && (string)Session["iduser"] != null)
                {
                    Uidt.Text = (string)Session["UsDisId"];
                    DDOUsermacth = " and sno in (select sno from hospitalname where ddoid=" + (string)Session["ddopid"] + ")";
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }



            }
        }
        public void chkdsk()
        {
            usecheck();
            //  cl.ds = cl.DataFill("SELECT count(DISTINCT(idno))As  CTot  FROM  salaryselect where name LIKE '" + VALT.Text + "'AND districtid LIKE '" + Uidt.Text + "' and ddoid='" + Request.QueryString["a"] + "'");
            cl.ds = cl.DataFill("SELECT count(DISTINCT(idno))As  CTot  FROM  pmd_salaryselect where (name LIKE '" + VALT.Text + "') " + DDOUsermacth + " ");

            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Ctot.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Ctot.Text = "no Record Find";
            }
        }
        protected void FactSheetA_Click(object sender, EventArgs e)
        {

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

        }
        //protected void submit_Click(object sender, EventArgs e)
        //{
        //    if (CompText.Text != "")
        //    {
        //        Response.Redirect("payearnings.aspx?idno=" + CompText.Text + "");
        //    }
        //    else
        //    {
        //        mesl.Text = "Please Enter ComputerID first";
        //    }
        //}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/pmdSaldetH.aspx?a=" + Request.QueryString["a"] + "");
        }
    }
}