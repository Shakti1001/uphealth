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

namespace NewWebApp.paramedicalstaff
{
    public partial class paraRelieve : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        //DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                sdate();
                sdate1();
                runrel();//
                cl.ds = cl.DataFill("SELECT DISTINCT idno, name, gpfno, districtname, designame FROM parafactsearchCriteria where idno='" + Request.QueryString["idno"] + "'");
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
       
        protected void BSAVE_Click(object sender, EventArgs e)
        {
            reladd();
        }
        protected void PFsheet_Click(object sender, EventArgs e)
        {
            Session.Add("ODR", "REL");
            Response.Write(("<script language=javascript>window.open(\'paraRelOrdprint.aspx?oid=" + (maxid.Text + (" &idno=" + (Request.QueryString["idno"] + "\',\'new_Win\');</script>")))));
        }
        public void runrel()
        {
            cl.ds = cl.DataFill("SELECT statussr,orderby,orderno, Convert(char,orderdate,103) as orderdate,  Convert(char,currentdate,103)as currentdate FROM  parastatus_join_releive where idno=" + Request.QueryString["idno"] + "");
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
                    tcellk4.Text = ("<a href=\'paraRelieve.aspx?idno=" + (cl.ds.Tables[0].Rows[j][3].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));

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
            cl.ds = cl.DataFill("SELECT isnull(MAX(statussr),0)+ 1 FROM parastatus_join_releive");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void reladd()
        {
            try
            {
                maxpic();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("parajoinrelieve", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@statussr", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];
                cmd.Parameters.Add("@orderno", SqlDbType.NVarChar, 50).Value = Ornot.Text.Replace("\'", "\'\'").Trim();
                if (DDD.SelectedIndex != 0 && DMM.SelectedIndex != 0 && DYYYY.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DMM.SelectedItem.Text + "/" + DDD.SelectedItem.Text + "/" + DYYYY.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (DDD.SelectedIndex == 0 || DMM.SelectedIndex == 0 || DYYYY.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@orderdate", DBNull.Value);
                }
                cmd.Parameters.Add("@orderby", SqlDbType.NVarChar, 50).Value = Orbyt.Text.Replace("\'", "\'\'").Trim();
                if (DD1.SelectedIndex != 0 && DM1.SelectedIndex != 0 && DY1.SelectedIndex != 0)
                {

                    cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DM1.SelectedItem.Text + "/" + DD1.SelectedItem.Text + "/" + DY1.SelectedItem.Text);
                    curdate.Text = DM1.SelectedItem.Text + "/" + DD1.SelectedItem.Text + "/" + DY1.SelectedItem.Text;
                }
                else if (DM1.SelectedIndex == 0 || DD1.SelectedIndex == 0 || DY1.SelectedIndex == 0)
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
                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mesg.Text = "The Given information have been saved if you want to Print click on print button";
                    con.Close();
                    cl.cmd = cl.InsertDB("update PMDpersonaldetails set lastupdatedtime='" + System.DateTime.Now + "', modifieruserid='" + Uidt.Text + "',postingstatus='R' where idno='" + Request.QueryString["idno"] + "'");
                    cl.cmd = cl.InsertDB("update PMDpostingdetails set dorelieve='" + Convert.ToDateTime(this.curdate.Text) + "'where idno='" + Request.QueryString["idno"] + "'and dorelieve is Null");

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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2JRmenu.aspx");
        }

    }
}