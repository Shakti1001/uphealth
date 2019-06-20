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

namespace NewWebApp.TransferSec
{
    public partial class TransferList : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    if ((string)Session["iduser"] == null)
                    {
                        Response.Redirect("~/Authenticate/login.aspx");
                    }
                    Fnamet.Text = (string)Session["fullname"];
                    Uidt.Text = (string)Session["iduser"];
                    ddfill();
                }
            }
        }
        private void ddfill()
        {
            //**************** Join Order *************
            cl.ds = cl.DataFill("SELECT     TransOrderMaster.TransOridd, TransOrderMaster.TransOrname+' Dated :'+Convert(nvarchar,TransOrderMaster.TransOrdate,103)+'  By  '+ JRofficer.offname As Orno FROM         TransOrderMaster INNER JOIN   JRofficer ON TransOrderMaster.TransOrbyid = JRofficer.orid order By TransOrderMaster.lastupdatedtime");
            JORDERDD.DataSource = cl.ds;
            JORDERDD.DataTextField = "Orno";
            JORDERDD.DataValueField = "TransOridd";
            JORDERDD.DataBind();
            JORDERDD.Items.Insert(0, new ListItem("--select--"));
            cl.ds = cl.DataFill("SELECT     TransOrderMaster.TransOridd, Convert(nvarchar,TransOrderMaster.TransOrdate,103)  As Ordate FROM         TransOrderMaster INNER JOIN   JRofficer ON TransOrderMaster.TransOrbyid = JRofficer.orid order By TransOrderMaster.lastupdatedtime");
            TrDateDD.DataSource = cl.ds;
            TrDateDD.DataTextField = "Ordate";
            TrDateDD.DataValueField = "TransOridd";
            TrDateDD.DataBind();
            TrDateDD.Items.Insert(0, new ListItem("--select--"));

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
                cl.ds1 = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds1.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds1.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
            }
        }
        public void runtransfer()
        {
            usecheck();
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {

                cl.ds = cl.DataFill("SELECT  idno, name,senno, dob, fathername,newpostname,  trfrom,trto ,postingstatus FROM Tr_list WHERE TransOridd=" + JORDERDD.SelectedItem.Value + " and postingstatus='T' order by TransOrdate,name");

            }
            else
            {
                Response.End();
            }
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                mesg.Text = "";
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
                // tcell1.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                //tcell2.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Seniority";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                //tcell3.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "DateofBirth";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                //tcell4.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Fathername";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                //tcell5.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Designation";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Transfer From";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                //tcell7.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell7);

                TableCell tcell8 = new TableCell();
                tcell8.Text = "Transfer To";
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                //tcell8.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell8);

                TableCell tcell9 = new TableCell();
                tcell9.Text = "Posting Status";
                tcell9.BorderWidth = 1;
                tcell9.BorderColor = System.Drawing.Color.SlateGray;
                //tcell9.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell9);

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
                    tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);

                    tcellk4.Text = ("<a href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    //Server.Transfer("~/Proforma2/proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");

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



                    TableCell tcellk10 = new TableCell();
                    tcellk10.BorderWidth = 1;
                    tcellk10.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk10.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcellk10.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk10);


                    TableCell tcellk9 = new TableCell();
                    tcellk9.Text = cl.ds.Tables[0].Rows[j][8].ToString();
                    tcellk9.BorderWidth = 1;
                    if (tcellk9.Text == "T")
                    {
                        tcellk9.ForeColor = System.Drawing.Color.DarkRed;
                        tcellk9.Text = "Under Transfer";
                    }
                    else if (tcellk9.Text == "J")
                    {
                        tcellk9.ForeColor = System.Drawing.Color.DarkGreen;
                        tcellk9.Text = "Joined";
                    }
                    else if (tcellk9.Text == "R")
                    {
                        tcellk9.ForeColor = System.Drawing.Color.SlateGray;
                        tcellk9.Text = "Relieved";
                    }
                    rw1.Cells.Add(tcellk9);

                    Table1.Rows.Add(rw1);

                }
            }
            else
            {
                mesg.Text = "...!!!   No record Found...";
            }
        }
        protected void BSAVE_Click(object sender, EventArgs e)
        {
            runtransfer();
        }

       
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TransferSec/TRmenu.aspx");
        }
    }
}