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

namespace NewWebApp.Proforma2
{
    public partial class join : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        bool i = false;
        bool j = false;
        int l = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.LCID = 2057;
            if (!IsPostBack)
            {
                cl.AddCalender(ref Imagecal, ref OrDate);
                cl.AddCalender(ref DORImage, ref DOJtext);
                this.OrDate.Attributes.Add("ReadOnly", "True");
                this.DOJtext.Attributes.Add("ReadOnly", "True");
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                //SELECT DISTINCT idno, name, senno, districtname, newpostname FROM         Rfactshee
                cl.ds = cl.DataFill("SELECT DISTINCT idno, name, senno, districtname, newpostname FROM factsheetnew2 where idno=" + Request.QueryString["idno"] + "");
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
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                //sdate();
                //sdate1();
                dfill();
            }

        }
        public void dfill()
        {
            //***************************
            cl.ds = cl.DataFill("SELECT     Desigid, designame FROM         designation ORDER BY Desigid");
            DDesign.DataSource = cl.ds;
            DDesign.DataTextField = "designame";
            DDesign.DataValueField = "Desigid";
            DDesign.DataBind();
            DDesign.Items.Insert(0, new ListItem("--select--"));
            //********************
            cl.ds = cl.DataFill("SELECT     newpostid, newpostname FROM         post ORDER BY newpostname");
            DPOST.DataSource = cl.ds;
            DPOST.DataTextField = "newpostname";
            DPOST.DataValueField = "newpostid";
            DPOST.DataBind();
            DPOST.Items.Insert(0, new ListItem("--select--"));
            //********************
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));
            //****************
            Dplace.Items.Insert(0, new ListItem("--select--"));
            //**************** Join Order *************
            cl.ds = cl.DataFill("SELECT     orid, offname FROM JRofficer ORDER BY orid");
            JORDERDD.DataSource = cl.ds;
            JORDERDD.DataTextField = "offname";
            JORDERDD.DataValueField = "orid";
            JORDERDD.DataBind();
            JORDERDD.Items.Insert(0, new ListItem("--select--"));

            //****************Level*******************

            cl.ds = cl.DataFill("SELECT     levelid, leveldesc FROM lavel ORDER BY levelid");
            ddlavel.DataSource = cl.ds;
            ddlavel.DataTextField = "leveldesc";
            ddlavel.DataValueField = "levelid";
            ddlavel.DataBind();
            ddlavel.Items.Insert(0, new ListItem("--select--"));
        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDistrict.SelectedIndex != 0)
            {//****************
                cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid =" + DDistrict.SelectedItem.Value + ") ORDER BY hospitalname.hname");
                Dplace.DataSource = cl.ds;
                Dplace.DataTextField = "hname";
                Dplace.DataValueField = "sno";
                Dplace.DataBind();
                Dplace.Items.Insert(0, new ListItem("--select--"));
            }
        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(sno),0)+ 1 FROM postingdetails");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }
        protected void BSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ornot.Text != "")
                {
                    cl.ds = cl.DataFill("SELECT     MAX(doposting) AS doposting, dorelieve FROM  postingdetails WHERE (idno = " + Request.QueryString["idno"] + ")AND (dorelieve IS NULL) GROUP BY dorelieve");
                    if (cl.ds.Tables[0].Rows.Count > 0)
                    {
                        mesg.Text = "You Are Trying To Join That Person Which  Have One Post To Relieve.......Please Do in Correct Manner";
                        this.fLink.Visible = true;
                    }
                    else
                    {
                        this.fLink.Visible = false;
                        maxpicor();
                        maxpic();
                        ////i = cl.IsDate(DMM.SelectedItem.Text + "/" + DDD.SelectedItem.Text + "/" + DYYYY.SelectedItem.Text);
                        ////j = cl.IsDate(DM1.SelectedItem.Text + "/" + DD1.SelectedItem.Text + "/" + DY1.SelectedItem.Text);
                        //i = cl.IsDate(DDD.SelectedItem.Text + "/" + DMM.SelectedItem.Text + "/" + DYYYY.SelectedItem.Text);
                        //j = cl.IsDate(DD1.SelectedItem.Text + "/" + DM1.SelectedItem.Text + "/" + DY1.SelectedItem.Text);

                        //if (i == true && j == true)
                        //{
                        //    ordersave();
                        //    postsave();
                        //}
                        //else
                        //{
                        //    this.mesg.Text = "Please select correct date..";
                        //}
                        ordersave();
                        if (l == 1)
                        {
                            postsave();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                this.mesg.Text = ex.Message;
                this.mesg.Text = "Please Check information";
            }
            finally { }

        }
        public void maxpicor()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(statussr),0)+ 1 FROM status_join_releive");
            oid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void ordersave()
        {
            try
            {


                cl.upcon.Open();

                SqlCommand cmd = new SqlCommand("joinrelieve", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@statussr", SqlDbType.Int, 4).Value = Convert.ToInt32(oid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];
                cmd.Parameters.Add("@orderno", SqlDbType.NVarChar, 50).Value = Ornot.Text.Replace("\'", "\'\'").Trim();
                if (OrDate.Text != "")
                {
                    cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(OrDate.Text);
                    //cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = OrDate.Text;
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

                if (this.DOJtext.Text != "")
                {
                    cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DOJtext.Text);
                    // cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = DOJtext.Text;

                }
                else
                {
                    cmd.Parameters.AddWithValue("@currentdate", DBNull.Value);
                }
                cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "J";
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Now;
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = Uidt.Text;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                //cmd.Parameters.Add("@udate", System.DateTime.Now);
                ///////////
                cmd.Parameters.Add("@postsrid", SqlDbType.Int, 4).Value = maxid.Text;
                cmd.Parameters.Add("@replacername", SqlDbType.VarChar, 100).Value = this.TextBox1.Text.Replace("\'", "\'\'").Trim();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Ornot.Text = "";
                    cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "', modifieruserid='" + Uidt.Text + "',postingstatus='J' where idno='" + Request.QueryString["idno"] + "'");
                    this.mesg.Text = "The Given information have been saved if you want to Print click on print button";
                    PFsheet.Visible = false;
                    l = 1;
                }
                else
                {
                    this.mesg.Text = "Error";
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
        public void postsave()
        {
            try//postadd
            {
                //            3	sno	int	4	0 //0	idno	int	4	1 //0	Desigid	int	4	1 //0	postid	int	4	1 //0	districtid	int	4	1 //0	poposting	int	4	1 //0	doposting	datetime	8	1 //0	dorelieve	datetime	8	1 //0	lastupdatedtime	datetime	8	1 //0	hostipaddress	nvarchar	50	1 //0	lock	nvarchar	50	1 //0	orderid	int	4	1
                //SqlCommand cmd = new SqlCommand("insert into postingdetails(sno,idno,Desigid,postid,districtid,poposting,doposting,dorelieve,lastupdatedtime,hostipaddress)values(@max,@idno,@Desigid,@postid,@districtid,@poposting,@doposting,@dorelieve,@lastupdatedtime,@hostipaddress)", con);
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("postadd", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sno", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["idno"]);
                cmd.Parameters.Add("@Desigid", SqlDbType.Int, 4).Value = DDesign.SelectedItem.Value;
                cmd.Parameters.Add("@postid", SqlDbType.Int, 4).Value = DPOST.SelectedItem.Value;
                cmd.Parameters.Add("@lavel", SqlDbType.Int, 4).Value = ddlavel.SelectedItem.Value;
                cmd.Parameters.Add("@districtid", SqlDbType.Int, 4).Value = DDistrict.SelectedItem.Value;
                cmd.Parameters.Add("@poposting", SqlDbType.Int, 4).Value = Dplace.SelectedItem.Value;
                //if (DDD.SelectedIndex != 0 && DMM.SelectedIndex != 0 && DYYYY.SelectedIndex != 0)
                //{
                //    cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DMM.SelectedItem.Text + "/" + DDD.SelectedItem.Text + "/" + DYYYY.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                //}
                //else if (DDD.SelectedIndex == 0 || DMM.SelectedIndex == 0 || DYYYY.SelectedIndex == 0)
                //{
                //    cmd.Parameters.AddWithValue("@doposting", DBNull.Value);
                //}

                //if (DD1.SelectedIndex != 0 && DM1.SelectedIndex != 0 && DY1.SelectedIndex != 0)
                //{
                //    cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DD1.SelectedItem.Text + "/" + DM1.SelectedItem.Text + "/" + DY1.SelectedItem.Text);//Convert.ToDateTime(
                //}
                //else if (DM1.SelectedIndex == 0 || DD1.SelectedIndex == 0 || DY1.SelectedIndex == 0)
                //{
                //    cmd.Parameters.AddWithValue("@doposting", DBNull.Value);
                //}

                if (OrDate.Text != "")
                {
                    cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DOJtext.Text);

                    // cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = OrDate.Text;

                }
                else
                {
                    cmd.Parameters.AddWithValue("@doposting", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@dorelieve", DBNull.Value);
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Now;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@lock", SqlDbType.NVarChar, 50).Value = "";
                cmd.Parameters.Add("@orderid", SqlDbType.Int, 4).Value = Convert.ToInt32(oid.Text);
                cmd.Parameters.Add("@udate", System.DateTime.Now);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mesg.Text = "";
                    cl.upcon.Close();
                    cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "', modifieruserid='" + Uidt.Text + "',postingstatus='J' where idno='" + Request.QueryString["idno"] + "'");
                    this.mesg.Text = "The Given information have been saved if you want to Print click on print button";
                    PFsheet.Visible = true;
                }
                else
                {
                    this.mesg.Text = "Technical Problem";
                }

            }
            catch (Exception ex)
            {
                this.mesg.Text = ("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();
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
            //for (i = 1940; i <= 2040; i++)
            for (i = 2030; i >= 1940; i--)
            {
                DYYYY.Items.Add("" + Convert.ToString(i) + "");
            }
            DYYYY.Items.Insert(0, new ListItem("0"));

        }
        protected void Dplace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void PFsheet_Click(object sender, EventArgs e)
        {
            //Response.Redirect("RelOrdprint.aspx?oid='" + oid.Text + "'&idno='" + Request.QueryString["idno"] + "'");
            Response.Write(("<script language=javascript>window.open(\'joinorderprint.aspx?oid=" + (oid.Text + (" &idno=" + (Request.QueryString["idno"] + "\',\'new_Win\');</script>")))));


        }
        protected void JORDERDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JORDERDD.SelectedItem.Value == "5")
            {
                this.Orbyt.Visible = true;
            }
            else { this.Orbyt.Visible = false; }

        }
        protected void fLink_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Proforma2/proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/JRmenu.aspx");
        }

        protected void ddlavel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}