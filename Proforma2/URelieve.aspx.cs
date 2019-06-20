using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace NewWebApp.Proforma2
{
    public partial class URelieve : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        testingSec tst = new testingSec();
        bool i = false;
        bool j = false;
        //DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            //cl.AddCalender(ref Imagecal, ref OrDate);
            //cl.AddCalender(ref DORImage, ref DORtext);

            Session.LCID = 2057;
            if (!IsPostBack)
            {

                cl.AddCalender(ref Imagecal, ref OrDate);
                cl.AddCalender(ref DORImage, ref DORtext);
                this.OrDate.Attributes.Add("ReadOnly", "True");
                this.DORtext.Attributes.Add("ReadOnly", "True");
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                //sdate();
                //sdate1();
                ddfill();
                runrel();//
                cl.ds = cl.DataFill("SELECT DISTINCT idno,name,senno,districtname, newpostname FROM Cfactsheet where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {

                    this.name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                    this.sen.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                    this.post.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                    this.plpost.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {

                }
            }
        }
        public void ddfill()
        { //**************** Relieve Order *************
            cl.ds = cl.DataFill("SELECT     orid, offname FROM JRofficer ORDER BY orid");
            JORDERDD.DataSource = cl.ds;
            JORDERDD.DataTextField = "offname";
            JORDERDD.DataValueField = "orid";
            JORDERDD.DataBind();
            JORDERDD.Items.Insert(0, new ListItem("--select--"));
        }
       
        protected void BSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ornot.Text != "")
                {
                    PFsheet.Visible = false;
                    //i = cl.IsDate(DDD.SelectedItem.Text + "/" + DMM.SelectedItem.Text + "/" + DYYYY.SelectedItem.Text);
                    //    j = cl.IsDate(DD1.SelectedItem.Text + "/" + DM1.SelectedItem.Text + "/" + DY1.SelectedItem.Text);
                    //    if (i == true && j == true)
                    //{
                    //    reladd();
                    //}
                    //else
                    //{
                    //    mesg.Text = "Please check date...";
                    //}
                    reladd();
                }
                else
                {
                    mesg.Text = "Please check order...";
                }
            }
            catch (Exception ex)
            {
                mesg.Text = ex.Message;
                mesg.Text = "Error";
            }
            finally { }

        }
        protected void PFsheet_Click(object sender, EventArgs e)
        {
            Response.Write(("<script language=javascript>window.open(\'RelOrdprint.aspx?oid=" + (maxid.Text + (" &idno=" + (Request.QueryString["idno"] + "\',\'new_Win\');</script>")))));
        }
        public void runrel()
        {
            cl.ds = cl.DataFill("SELECT statussr,orderby,orderno, Convert(char,orderdate,103) as orderdate,  Convert(char,currentdate,103)as currentdate FROM  status_join_releive where idno=" + Request.QueryString["idno"] + "");
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.Black;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.White;
                tcell0.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "Order By";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.White;
                tcell1.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Order No";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.White;
                tcell2.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Order Date";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.White;
                tcell3.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Issue Date";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.White;
                tcell4.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell4);

                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.Black;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.White;
                    tcellk1.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk1.BackColor = System.Drawing.Color.White;
                    tcellk1.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.White;
                    tcellk2.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk2.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.White;
                    tcellk3.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk3.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.White;
                    tcellk4.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk4.BackColor = System.Drawing.Color.White;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    rw1.Cells.Add(tcellk4);
                    tcellk4.Text = ("<a href=\'Relieve.aspx?idno=" + (cl.ds.Tables[0].Rows[j][3].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.White;
                    tcellk5.ForeColor = System.Drawing.Color.MidnightBlue;
                    tcellk5.BackColor = System.Drawing.Color.White;
                    rw1.Cells.Add(tcellk5);
                    Table1.Rows.Add(rw1);

                }
            }
        }
        public void sdate1()
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                DD1.Items.Add("" + Convert.ToString(i) + "");
            }
            DD1.Items.Insert(0, new ListItem("0"));
            for (i = 1; i <= 12; i++)
            {
                DM1.Items.Add("" + Convert.ToString(i) + "");
            }
            DM1.Items.Insert(0, new ListItem("0"));
            //for (i = 1940; i <= 2040; i++)
            for (i = 2030; i >= 1940; i--)
            {
                DY1.Items.Add("" + Convert.ToString(i) + "");
            }
            DY1.Items.Insert(0, new ListItem("0"));

        }
        public void sdate()
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                DDD.Items.Add("" + Convert.ToString(i) + "");
            }
            DDD.Items.Insert(0, new ListItem("0"));
            for (i = 1; i <= 12; i++)
            {
                DMM.Items.Add("" + Convert.ToString(i) + "");
            }
            DMM.Items.Insert(0, new ListItem("0"));
            for (i = 2030; i >= 1940; i--)
            //for (i = 1940; i <= 2040; i++)
            {
                DYYYY.Items.Add("" + Convert.ToString(i) + "");
            }
            DYYYY.Items.Insert(0, new ListItem("0"));

        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(statussr),0)+ 1 FROM status_join_releive");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void reladd()
        {
            try
            {
                maxpic();
                pickid();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("joinrelieve", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@statussr", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];
                cmd.Parameters.Add("@orderno", SqlDbType.NVarChar, 50).Value = Ornot.Text.Replace("\'", "\'\'").Trim();
                if (OrDate.Text != "")
                {
                    cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(OrDate.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@orderdate", DBNull.Value);
                }
                if (JORDERDD.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@orid", SqlDbType.Int, 4).Value = JORDERDD.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@orid", SqlDbType.Int, 4).Value = 0;
                }
                cmd.Parameters.Add("@orderby", SqlDbType.NVarChar, 50).Value = Orbyt.Text.Replace("\'", "\'\'").Trim();

                if (this.DORtext.Text != "")
                {
                    cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DORtext.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@currentdate", DBNull.Value);
                }
                if (this.retire.Checked == true)
                {
                    cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "S";
                }
                else if (this.retire.Checked == false)
                {
                    cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "R";
                }
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Now;
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = Uidt.Text;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                ///////////
                cmd.Parameters.Add("@postsrid", SqlDbType.Int, 4).Value = Convert.ToInt32(this.Label1.Text);
                i = tst.SQLInj_SL(this.TextBox1.Text);
                if (i == true)
                {
                    cmd.Parameters.Add("@replacername", SqlDbType.VarChar, 100).Value = this.TextBox1.Text.Replace("\'", "\'\'").Trim();
                }
                if (cmd.ExecuteNonQuery() == 1)
                {
                    con.Close();
                    Ornot.Text = "";

                    if (this.retire.Checked == true)
                    {
                        cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + DateTime.Now.ToString("dd/MM/yyyy") + "', modifieruserid='" + Uidt.Text + "',postingstatus='S' where idno='" + Request.QueryString["idno"] + "'");

                    }
                    else if (this.retire.Checked == false)
                    {
                        cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + DateTime.Now.ToString("dd/MM/yyyy") + "', modifieruserid='" + Uidt.Text + "',postingstatus='R' where idno='" + Request.QueryString["idno"] + "'");

                    }
                    // string dor = Convert.ToString(Convert.ToDateTime(DORtext.Text).ToString("dd/MM/yyyy"));
                    string dor = Convert.ToString(Convert.ToDateTime(DORtext.Text).ToString("MM/dd/yyyy"));
                    cl.cmd = cl.InsertDB("update postingdetails set dorelieve='" + dor + "'where idno='" + Request.QueryString["idno"] + "'and dorelieve is Null ");
                    this.mesg.Text = "The Given information have been saved if you want to Print click on print button";
                    PFsheet.Visible = true;
                }
                else
                {
                    this.mesg.Text = "";
                    Response.Write("Error :");
                }
            }
            catch (Exception ex)
            {
                this.mesg.Text = "";
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();

            }
        }
        public void reladdWW()
        {
            try
            {
                maxpic();
                pickid();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("joinrelieve", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@statussr", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];
                i = tst.SQLInj_SL(this.Ornot.Text);
                //if (i == true)
                //{
                cmd.Parameters.Add("@orderno", SqlDbType.NVarChar, 50).Value = Ornot.Text.Replace("\'", "\'\'").Trim();
                //}

                if (OrDate.Text != "")
                {
                    cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(OrDate.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@orderdate", DBNull.Value);
                }
                if (JORDERDD.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@orid", SqlDbType.Int, 4).Value = JORDERDD.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@orid", SqlDbType.Int, 4).Value = 0;
                }
                cmd.Parameters.Add("@orderby", SqlDbType.NVarChar, 50).Value = Orbyt.Text.Replace("\'", "\'\'").Trim();

                if (this.DORtext.Text != "")
                {
                    cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DORtext.Text);
                }
                {
                    cmd.Parameters.AddWithValue("@currentdate", DBNull.Value);
                }
                if (this.retire.Checked == true)
                {
                    cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "S";
                }
                else if (this.retire.Checked == false)
                {
                    cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "R";
                }
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Now;
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = Uidt.Text;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                ///////////
                cmd.Parameters.Add("@postsrid", SqlDbType.Int, 4).Value = Convert.ToInt32(this.Label1.Text);
                i = tst.SQLInj_SL(this.TextBox1.Text);
                if (i == true)
                {
                    cmd.Parameters.Add("@replacername", SqlDbType.VarChar, 100).Value = this.TextBox1.Text.Replace("\'", "\'\'").Trim();
                }
                if (cmd.ExecuteNonQuery() == 1)
                {
                    con.Close();
                    Ornot.Text = "";

                    if (this.retire.Checked == true)
                    {
                        cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + DateTime.Now.ToString("dd/MM/yyyy") + "', modifieruserid='" + Uidt.Text + "',postingstatus='S' where idno='" + Request.QueryString["idno"] + "'");

                    }
                    else if (this.retire.Checked == false)
                    {
                        cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now.ToString("dd/MM/yyyy") + "', modifieruserid='" + Uidt.Text + "',postingstatus='R' where idno='" + Request.QueryString["idno"] + "'");

                    }
                    // string dor = Convert.ToString(Convert.ToDateTime(DORtext.Text).ToString("dd/MM/yyyy"));
                    string dor = Convert.ToString(Convert.ToDateTime(DORtext.Text).ToString("MM/dd/yyyy"));
                    cl.cmd = cl.InsertDB("update postingdetails set dorelieve='" + dor + "'where idno='" + Request.QueryString["idno"] + "'and dorelieve is Null ");
                    this.mesg.Text = "The Given information have been saved if you want to Print click on print button";
                    PFsheet.Visible = true;
                }
                else
                {
                    this.mesg.Text = "";
                    Response.Write("Error :");
                }
            }
            catch (Exception ex)
            {
                this.mesg.Text = "";
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();

            }
        }
        public void pickid()
        {
            cl.ds = cl.DataFill("select sno from postingdetails where idno='" + Request.QueryString["idno"] + "'and dorelieve is Null ");
            this.Label1.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }
        protected void JORDERDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JORDERDD.SelectedItem.Value == "5")
            {
                this.Orbyt.Visible = true;
            }
            else { this.Orbyt.Visible = false; }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/JRmenu.aspx");
        }
    }
}