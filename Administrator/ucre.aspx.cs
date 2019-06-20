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

namespace NewWebApp.Administrator
{
    public partial class ucre : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        //SqlDataAdapter da;
        DataSet ds = new DataSet();
        EncDec EncDec = new EncDec();
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = (string)Session["fullname"];
                R.Checked = true;
                cl.ds = cl.DataFill("SELECT ulid, ulname FROM userlavel order by ulname ");
                lavel.DataSource = cl.ds;
                lavel.DataTextField = "ulname";
                lavel.DataValueField = "ulid";
                lavel.DataBind();
                lavel.Items.Insert(0, new ListItem("--Select--"));
                //****************
                cl.ds = cl.DataFill("SELECT DISTINCT designame, Desigid FROM designation ORDER BY designame");
                DDesign.DataSource = cl.ds;
                DDesign.DataTextField = "designame";
                DDesign.DataValueField = "Desigid";
                DDesign.DataBind();
                DDesign.Items.Insert(0, new ListItem("--select--"));
                //********************
                cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
                DDistrict.DataSource = cl.ds;
                DDistrict.DataTextField = "districtname";
                DDistrict.DataValueField = "districtid";
                DDistrict.DataBind();
                DDistrict.Items.Insert(0, new ListItem("--select--"));

            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {


            maxpic();
            //cl.ds = cl.InsertDB("Insert into Ucreate (iduser,userid,username,upass,lavel,upid,R,A,D,E) values('" + maxid.Text + "','" + userid.Text + "','" + username.Text + "','" + EncDec.EncryptRSA(upass.Text) + "'," + lavel.SelectedItem.Value + "," + UP.SelectedItem.Value + " )");
            try//upid, @upid,1	u_desig	int	4	10	u_dist	int	4	1,@lastupdatedtime
            {
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("Insert into Ucreate(iduser,userid,username,upass,lavel,R,A,D,E,u_desig,DisId) values(@iduser,@userid,@username,@upass,@lavel,@R,@A,@D,@E,@u_desig,@u_dist)", cl.upcon);
                cmd.Parameters.Add("@iduser", SqlDbType.Int, 4).Value = maxid.Text;
                cmd.Parameters.Add("@userid", SqlDbType.VarChar, 50).Value = userid.Text;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 200).Value = username.Text;
                cmd.Parameters.Add("@upass", SqlDbType.VarChar, 50).Value = EncDec.EncryptRSA(upass.Text);
                cmd.Parameters.Add("@lavel", SqlDbType.Int, 4).Value = lavel.SelectedItem.Value;
                if (R.Checked != true)
                {
                    cmd.Parameters.Add("@R", SqlDbType.Int, 4).Value = "0";
                }
                else
                {
                    cmd.Parameters.Add("@R", SqlDbType.Int, 4).Value = "1";
                }
                //cmd.Parameters.Add("@upid", SqlDbType.Int, 4).Value = UP.SelectedItem.Value;
                if (A.Checked != true)
                {
                    cmd.Parameters.Add("@A", SqlDbType.Int, 4).Value = "0";
                }
                else
                {
                    cmd.Parameters.Add("@A", SqlDbType.Int, 4).Value = "1";
                }
                if (D.Checked != true)
                {
                    cmd.Parameters.Add("@D", SqlDbType.Int, 4).Value = "0";
                }
                else
                {
                    cmd.Parameters.Add("@D", SqlDbType.Int, 4).Value = "1";
                }
                if (E.Checked != true)
                {
                    cmd.Parameters.Add("@E", SqlDbType.Int, 4).Value = "0";
                }
                else
                {
                    cmd.Parameters.Add("@E", SqlDbType.Int, 4).Value = "1";
                }
                cmd.Parameters.Add("@u_desig", SqlDbType.Int, 4).Value = DDesign.SelectedItem.Value;
                cmd.Parameters.Add("@u_dist", SqlDbType.Int, 4).Value = DDistrict.SelectedItem.Value;
                //cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Now;
                //if (lavel.SelectedIndex != 0 && UP.SelectedIndex != 0)
                if (lavel.SelectedIndex != 0 && DDistrict.SelectedIndex != 0 && DDesign.SelectedIndex != 0)
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Label2.Visible = true;
                        Label2.Text = "User Creation Successfull";
                        userid.Text = "";
                        username.Text = "";
                        upass.Text = "";
                        DDistrict.SelectedIndex = 0;
                        A.Checked = false;
                        D.Checked = false;
                        E.Checked = false;
                    }
                    else
                    {
                        Label2.Visible = true;
                        Label2.Text = "Please Check UserId";
                    }
                }
                else
                {
                    Label2.Visible = true;
                    Label2.Text = "Please Fill Right Information";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
                Label2.Visible = true;
                Label2.Text = "Please Check UserId";
            }
            finally
            {
                cl.upcon.Close();
                GridView1.DataBind();
            }


        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(iduser),0)+ 1 FROM Ucreate");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }

        public void Userlist()
        {
            int j;
            cl.ds = cl.DataFill("SELECT     userlavel.ulname, Ucreate.username, Ucreate.userid,hospitaldistrict.districtname, Designation.designame, Ucreate.R, Ucreate.A, Ucreate.D, Ucreate.E FROM         Ucreate INNER JOIN    userlavel ON Ucreate.lavel = userlavel.ulid INNER JOIN  Designation ON Ucreate.u_desig = designation.Desigid INNER JOIN  hospitaldistrict ON Ucreate.DisId = hospitaldistrict.districtid ORDER BY userlavel.ulname");// AND postingdetails.dorelieve IS NULL)");

            if (cl.ds.Tables[0].Rows.Count > 0)//SlateGray
            {
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.SlateGray;
                rw.BackColor = System.Drawing.Color.BurlyWood;
                rw.ForeColor = System.Drawing.Color.Maroon;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "Serial No";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;//  tcell0.ForeColor = System.Drawing.Color.Black;          
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "User Lavel";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "User Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "User ID";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "User District";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "User Designation";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "User Permission";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell6);
                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.Maroon;
                    rw1.BackColor = System.Drawing.Color.LemonChiffon;

                    TableCell tcell11 = new TableCell();
                    tcell11.BorderWidth = 1;
                    //tcell11.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell11.ForeColor = System.Drawing.Color.Black;
                    tcell11.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcell11);

                    TableCell tcell21 = new TableCell();
                    tcell21.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcell21.BorderWidth = 1;
                    //tcell21.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell21.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell21);

                    TableCell tcell31 = new TableCell();
                    tcell31.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcell31.BorderWidth = 1;
                    //tcell31.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell31.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell31);


                    TableCell tcell41 = new TableCell();
                    tcell41.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcell41.BorderWidth = 1;
                    //tcell41.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell41.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell41);
                    tcell41.Text = ("<a href=\'ChangePassword.aspx?useid=" + (cl.ds.Tables[0].Rows[j][2].ToString() + ("\'>" + (" (" + (tcell41.Text + ")</a>")))));

                    TableCell tcell51 = new TableCell();
                    tcell51.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcell51.BorderWidth = 1;
                    //tcell51.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell51.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell51);


                    TableCell tcell61 = new TableCell();
                    tcell61.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcell61.BorderWidth = 1;
                    //tcell61.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell61.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell61);

                    TableCell tcell71 = new TableCell();
                    string pr, pa, pd, pe;
                    if (!(cl.ds.Tables[0].Rows[j][5].ToString().Equals(System.DBNull.Value)))
                    {
                        pr = cl.ds.Tables[0].Rows[j][5].ToString();
                        if (pr == "1")
                        {
                            pr = "Read";
                        }
                        else
                        {
                            pr = "-";
                        }

                    }
                    else
                    {
                        pr = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][6].ToString().Equals(System.DBNull.Value)))
                    {
                        pa = cl.ds.Tables[0].Rows[j][6].ToString();
                        if (pa == "1")
                        {
                            pa = "ADD";
                        }
                        else
                        {
                            pa = "-";
                        }

                    }
                    else
                    {
                        pa = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][7].ToString().Equals(System.DBNull.Value)))
                    {
                        pd = cl.ds.Tables[0].Rows[j][7].ToString();
                        if (pd == "1")
                        {
                            pd = "DELETE";
                        }
                        else
                        {
                            pd = "-";
                        }

                    }
                    else
                    {
                        pd = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][8].ToString().Equals(System.DBNull.Value)))
                    {
                        pe = cl.ds.Tables[0].Rows[j][8].ToString();
                        if (pe == "1")
                        {
                            pe = "EDIT";
                        }
                        else
                        {
                            pe = "-";
                        }
                    }
                    else
                    {
                        pe = "";
                    }
                    tcell71.Text = pr + "/" + pa + "/" + pe + "/" + pd;
                    tcell71.BorderWidth = 1;
                    //tcell71.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell71.ForeColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcell71);
                    Table1.Rows.Add(rw1);

                }
            }
        }
        protected void lavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lavel.SelectedItem.Text == "Admin")
            {
                A.Checked = true;
                E.Checked = true;
                R.Checked = true;
                D.Checked = true;
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.Label3.Visible = true;
            Userlist();
        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    this.Label3.Visible = false;
        //    this.Table1.Visible = false;
        //}
       

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Administrator/Ad1.aspx");
        }
    }
}