using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.proforma
{
    public partial class TotHospital : System.Web.UI.Page
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

                Hospname();

            }

        }
        public void usecheck()
        {
            //bool i;
            //i = cl.checklavel((string)Session["iduser"]);
            //if (i == true)
            //{
            //    Uidt.Text = "%";
            //}
            //else
            //{
            //    cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
            //    if (cl.ds.Tables[0].Rows.Count > 0)
            //    {
            //        Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            //    }
            //    else
            //    {
            //        Response.Redirect("~/login.aspx");
            //    }
            //}


            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                //***************DISTRICT****************        
                if (Request.QueryString["b"] != "N")//DisId
                {
                    if (Request.QueryString["b"].Length == 1)
                    {
                        Uidt.Text = "districtid=" + Request.QueryString["b"] + "";
                    }
                    else
                    {
                        Uidt.Text = "districtid like '%" + Request.QueryString["b"] + "%'";
                    }
                }
                else { Uidt.Text = "districtid like '%'"; }
            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    Uidt.Text = "districtid=" + Uidt.Text + "";
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }


        }

        public void Hospname()
        {
            usecheck();
            string q1, q2, q3;
            //**************Division TYPE*****************        
            if (Request.QueryString["a"] != "N")
            {
                if (Request.QueryString["a"].Length == 1)
                {

                    q1 = "divid='" + Request.QueryString["a"] + "'";
                }
                else
                {

                    q1 = "divid Like '%" + Request.QueryString["a"] + "%'";
                }
            }
            else
            {

                q1 = "divid Like '%'";
            }
            //**************District NAME*****************
            //if (Request.QueryString["b"] != "N")
            //{
            //    if (Request.QueryString["b"].Length == 1)
            //    {

            //        q2 = "districtid='" + Request.QueryString["b"] + "'";
            //    }
            //    else
            //    {
            //        q2 = "districtid like '%" + Request.QueryString["b"] + "%'";

            //    }
            //}
            //else
            //{

            //    q2 = "districtid like '%'";
            //}

            //****************htype***************
            if (Request.QueryString["c"] != "N")
            {
                if (Request.QueryString["c"].Length == 1)
                {

                    q3 = "hid=" + Request.QueryString["c"] + "";
                }
                else
                {

                    q3 = "hid like '%" + Request.QueryString["c"] + "%' ";
                }
            }
            else
            {

                q3 = "hid like '%'";
            }
            string qr = Uidt.Text + "AND " + q1 + "AND " + q3 + "";// + q1 + "AND " 
            // bool i;
            // i = cl.checklavel((string)Session["iduser"]);
            //if (i == true)
            // {
            cl.ds = cl.DataFill("SELECT divname, districtname, tehsilname, blockname, htype, hname, sno,bedoccupacy FROM hospitallist WHERE " + qr + " order by divname, districtname, tehsilname, blockname, htype");//where divid like '" + Request.QueryString["a"] + "' and districtid like'" + Request.QueryString["b"] + "' and hid like '" + Request.QueryString["c"] + "'

            //}
            //else
            //{
            //    cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + Uidt.Text + "') order by divname, districtname, tehsilname, blockname, htype");
            //}
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Label1.Visible = false;
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.SlateGray;
                //rw.BackColor = System.Drawing.Color.Black;
                //rw.ForeColor = System.Drawing.Color.Black;


                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;
                //tcell0.Font= System.Drawing.FontStyle.Bold;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "Division Name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                // tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "District Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                //tcell2.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Tehsil Name";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                //tcell3.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Block Name";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                //tcell4.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Hospital Type";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                //tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Hospital Name";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "No Of BedS";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                //tcell7.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell7);

                //TableCell tcellx0 = new TableCell();
                //tcellx0.Text = "P1 Detail";
                //tcellx0.BorderWidth = 1;
                //tcellx0.BorderColor = System.Drawing.Color.SlateGray;
                //tcellx0.ForeColor = System.Drawing.Color.Black;
                //rw.Cells.Add(tcellx0);

                //TableCell tcellx1 = new TableCell();
                //tcellx1.Text = "P1/P2";
                //tcellx1.BorderWidth = 1;
                //tcellx1.BorderColor = System.Drawing.Color.SlateGray;
                //tcellx1.ForeColor = System.Drawing.Color.Black;
                //rw.Cells.Add(tcellx1);

                //TableCell tcellx2 = new TableCell();
                //tcellx2.Text = "Print P1 Records";
                //tcellx2.BorderWidth = 1;
                //tcellx2.BorderColor = System.Drawing.Color.SlateGray;
                //tcellx2.ForeColor = System.Drawing.Color.Black;
                //rw.Cells.Add(tcellx2);

                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.Black;
                    //rw1.ForeColor = System.Drawing.Color.Black;
                    //rw1.BackColor = System.Drawing.Color.Black;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);
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
                    //tcellk7.ForeColor = System.Drawing.Color.Black;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    Table1.Rows.Add(rw1);

                }
            }
            else
            {
                Label1.Visible = true;
                this.Label1.Text = "No data for this choice " + "<Br><BR>" + "you are  authorized  to find those records which are related to  your district";

            }
        }
    }
}