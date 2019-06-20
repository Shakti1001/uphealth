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
using System.Security.Policy;

namespace NewWebApp.proforma
{
    public partial class Hospitaladd : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }

                usecheck();
                ddfill();
            }
        }
        public void usechecka()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId,DDOID FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0]["DisId"].ToString();
                    DDOIDLBL.Text = cl.ds.Tables[0].Rows[0]["DDOID"].ToString();
                }
                else
                {
                    Response.Redirect("~/Authenticate/login.aspx");
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
                cl.ds = cl.DataFill("SELECT DISTINCT divname, divid FROM  division ");
                DDiv.DataSource = cl.ds;
                DDiv.DataTextField = "divname";
                DDiv.DataValueField = "divid";
                DDiv.DataBind();
                DDiv.Items.Insert(0, new ListItem("--select--"));
                //****************

            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    string division=Uidt.Text;
                    //cl.ds1 = cl.DataFill("SELECT DISTINCT division.divname, division.divid FROM division INNER JOIN  hospitaldistrict ON division.divid = hospitaldistrict.divid WHERE     (hospitaldistrict.districtid =" + Uidt.Text + "");
                    //DDiv.DataSource = cl.ds1;
                    //DDiv.DataTextField = "divname";
                    //DDiv.DataValueField = "divid";
                    //DDiv.DataBind();

                    DDiv.Items.Insert(0, new ListItem(""));
                    cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where districtid=" + Uidt.Text + " ORDER BY districtname");
                    DDist.DataSource = cl.ds;
                    DDist.DataTextField = "districtname";
                    DDist.DataValueField = "districtid";
                    DDist.DataBind();
                    DDist.Items.Insert(0, new ListItem("--select--"));
                    //****************

                }
                else
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
            }
        }
        //SELECT DISTINCT division.divname, division.divid FROM         division INNER JOIN  hospitaldistrict ON division.divid = hospitaldistrict.divid WHERE     (hospitaldistrict.districtid LIKE '%')

        public void ddfill()
        {

            //***************************
            cl.ds = cl.DataFill("SELECT DISTINCT htype, hid FROM hospitaltype ORDER BY htype");
            DHT.DataSource = cl.ds;
            DHT.DataTextField = "htype";
            DHT.DataValueField = "hid";
            DHT.DataBind();
            DHT.Items.Insert(0, new ListItem("--select--"));

        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(sno),0)+ 1 FROM hospitalname");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }

        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DDiv.SelectedIndex != 0)
            {//****************
                cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where divid=" + DDiv.SelectedItem.Value + " ORDER BY districtname");
                DDist.DataSource = cl.ds;
                DDist.DataTextField = "districtname";
                DDist.DataValueField = "districtid";
                DDist.DataBind();
                DDist.Items.Insert(0, new ListItem("--select--"));
                //****************
            }
        }

        protected void DTEH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDiv.SelectedIndex != 0) || (DDist.SelectedIndex != 0) || (DTEH.SelectedIndex != 0))
            {
                //****************SELECT blockname, blockid FROM Block
                cl.ds = cl.DataFill("SELECT blockname, blockid FROM Block Where divid='" + DDiv.SelectedItem.Value + "' AND districtid='" + DDist.SelectedItem.Value + "' AND tehsilid = '" + DTEH.SelectedItem.Value +"'");
                DBLK.DataSource = cl.ds;
                DBLK.DataTextField = "blockname";
                DBLK.DataValueField = "blockid";
                DBLK.DataBind();
                DBLK.Items.Insert(0, new ListItem("NONE"));
            }
        }
        protected void DBLK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
protected void DDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDist.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT DISTINCT tehsilname, tehsilid FROM  Tehsil WHERE   districtid=" + DDist.SelectedItem.Value + " ORDER BY tehsilname");
                DTEH.DataSource = cl.ds;
                DTEH.DataTextField = "tehsilname";
                DTEH.DataValueField = "tehsilid";
                DTEH.DataBind();
                DTEH.Items.Insert(0, new ListItem("NONE"));

                cl.ds = cl.DataFill("SELECT blockname, blockid FROM Block Where  districtid=" + DDist.SelectedItem.Value + " ");
                DBLK.DataSource = cl.ds;
                DBLK.DataTextField = "blockname";
                DBLK.DataValueField = "blockid";
                DBLK.DataBind();
                DBLK.Items.Insert(0, new ListItem("NONE"));
            }
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.IsInteger(NOBText.Text);
            if (j == true)
            {
                try
                {
                    hospitaladd();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }


        }
        protected void maxid_TextChanged(object sender, EventArgs e)
        {

        }
        public void hospitaladd()
        {
            try
            {
                //maxid.Text = "236";
                maxpic();
                cl.upcon.Open();
                //con.Open();
                SqlCommand cmd = new SqlCommand("hospitaladd", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@max",maxid.Text);
                //Response.Write(maxid.Text);

                cmd.Parameters.Add("@max", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@districtid", SqlDbType.Int, 4).Value = DDist.SelectedItem.Value;



                if (DTEH.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@tehsilid", SqlDbType.Int, 4).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@tehsilid", SqlDbType.Int, 4).Value = DTEH.SelectedItem.Value;
                }
                if (DBLK.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@blockid", SqlDbType.Int, 4).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@blockid", SqlDbType.Int, 4).Value = DBLK.SelectedItem.Value;
                }

                cmd.Parameters.Add("@htype", SqlDbType.Int, 4).Value = DHT.SelectedItem.Value;
                cmd.Parameters.Add("@FRUstatus", SqlDbType.Int, 4).Value = Convert.ToInt32(FRU.Text);
                cmd.Parameters.Add("@BuildingStatus", SqlDbType.Int, 4).Value = Convert.ToInt32(building.Text);
                cmd.Parameters.Add("@bedoccupacy", SqlDbType.Int, 4).Value = Convert.ToInt32(NOBText.Text);

                //cmd.Parameters.AddWithValue("@bedoccupacy",NOBText.Text);

                //cmd.Parameters.AddWithValue("@hname",HosN.Text);
                cmd.Parameters.Add("@hname", SqlDbType.VarChar, 250).Value = HosN.Text;
                if (DDist.SelectedIndex != 0 || DHT.SelectedIndex != 0 || HosN.Text == "")
                {

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Added Successfully";
                        HosN.Text = "";
                    }


                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Select the Correct One";
                }

            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = ("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();
                //con.Close();

            }
        }
       
        public void Hospname()
        {
            //usechecka();
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                cl.ds = cl.DataFill("SELECT divname, districtname, tehsilname, blockname, htype, hname, sno,bedoccupacy FROM hospitallist");

            }
            else
            {
                ////cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + Uidt.Text + "') ");
                //// changes on date june 10 2011
                ////DDO and Userid match
                //if ((string)Session["UsDisId"] != null && (string)Session["ddoid"] != null)
                //{
                //    string DDOUsermacth;
                //    DDOUsermacth = " and sno in (select sno from hospitalname where ddoid=" + (string)Session["ddoid"] + ")";
                //    cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + (string)Session["UsDisId"] + "') " + DDOUsermacth + "  order by divname, districtname, tehsilname, blockname, htype");
                //}
                //else
                //{
                //    Response.Redirect("~/login.aspx");
                //}

                //// *************************************************
                //// Hospital allotted to user  (string)Session["iduser"]
                if ((string)Session["iduser"] != null)
                {
                    string DDOUsermacth;
                    DDOUsermacth = " and sno in (select sno from hospitalname where ddoid=" + (string)Session["iduser"] + ")";
                    cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM  hospitallist WHERE     (districtid ='" + (string)Session["UsDisId"] + "') " + DDOUsermacth + "  order by divname, districtname, tehsilname, blockname, htype");
                }
                else
                {
                    Response.Redirect("~/Authenticate/login.aspx");
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

                //TableCell tcell8 = new TableCell();
                //tcell8.Text = "ADD P1 Records Details";
                //tcell8.BorderWidth = 1;
                //tcell8.BorderColor = System.Drawing.Color.SlateGray;           
                //rw.Cells.Add(tcell8);

                //TableCell tcell9 = new TableCell();
                //tcell9.Text = "Edit P1 Records";
                //tcell9.BorderWidth = 1;
                //tcell9.BorderColor = System.Drawing.Color.SlateGray;           
                //rw.Cells.Add(tcell9);

                //TableCell tcellx1 = new TableCell();
                //tcellx1.Text = "Print P1 Records";
                //tcellx1.BorderWidth = 1;
                //tcellx1.BorderColor = System.Drawing.Color.SlateGray;
                //tcellx1.ForeColor = System.Drawing.Color.Maroon;
                //rw.Cells.Add(tcellx1);

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

                    ////ADD Hospital(POST)Details
                    //TableCell tcellk9 = new TableCell();
                    //tcellk9.Text = "ADD P1";
                    //tcellk9.BorderWidth = 1;
                    //tcellk9.BorderColor = System.Drawing.Color.SlateGray;              
                    //rw1.Cells.Add(tcellk9);
                    //Session.Add("val", "A");
                    //tcellk9.Text = ("<a href=\'Hpcheckpost.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk9.Text + ")</a>")))));


                    ////Print Details
                    //TableCell tcellk10 = new TableCell();
                    //tcellk10.Text = "Edit P1";
                    //tcellk10.BorderWidth = 1;
                    //tcellk10.BorderColor = System.Drawing.Color.SlateGray;                
                    //rw1.Cells.Add(tcellk10);

                    //Session.Add("val", "E");
                    //tcellk10.Text = ("<a href=\'Hpcheckpost.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk10.Text + ")</a>")))));

                    //TableCell tcellk11 = new TableCell();
                    //tcellk11.Text = "Print P1";
                    //tcellk11.BorderWidth = 1;
                    //tcellk11.BorderColor = System.Drawing.Color.SlateGray;               
                    //rw1.Cells.Add(tcellk11);
                    //tcellk11.Text = ("<a href=\'Hdetails.aspx?sno=" + (cl.ds.Tables[0].Rows[j][6].ToString() + ("\'>" + (" (" + (tcellk11.Text + ")</a>")))));

                    Table1.Rows.Add(rw1);

                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Hospname();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/proforma/p1.aspx");
        }
    }
}