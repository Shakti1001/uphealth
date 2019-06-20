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

namespace NewWebApp.paramedicalstaff
{
    public partial class parajoin : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        int l = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
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
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                sdate();
                sdate1();
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
            cl.ds = cl.DataFill("SELECT desigid, designame FROM   PMDhospitaldesignation ORDER BY designame ");
            DPOST.DataSource = cl.ds;
            DPOST.DataTextField = "designame";
            DPOST.DataValueField = "desigid";
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
        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            //****************
            cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid =" + DDistrict.SelectedItem.Value + ") ORDER BY hospitalname.hname");
            Dplace.DataSource = cl.ds;
            Dplace.DataTextField = "hname";
            Dplace.DataValueField = "sno";
            Dplace.DataBind();
            Dplace.Items.Insert(0, new ListItem("--select--"));
        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(sno),0)+ 1 FROM PMDpostingdetails");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }
        protected void BSAVE_Click(object sender, EventArgs e)
        {
            postsave();
            ordersave();








        }
        public void maxpicor()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(statussr),0)+ 1 FROM parastatus_join_releive");
            oid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void ordersave()
        {
            try
            {
                maxpicor();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("parajoinrelieve", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@statussr", SqlDbType.Int, 4).Value = Convert.ToInt32(oid.Text);
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
                cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "J";
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Now;
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = Uidt.Text;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                if (cmd.ExecuteNonQuery() == 1)
                {
                    cl.cmd = cl.InsertDB("update PMDpersonaldetails set lastupdatedtime='" + System.DateTime.Now + "', modifieruserid='" + Uidt.Text + "',postingstatus='J' where idno='" + Request.QueryString["idno"] + "'");
                    this.mesg.Text = "The Given information have been saved if you want to Print click on print button";
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
                maxpic();
                cl.upcon.Open();
                //SqlCommand cmd = new SqlCommand("insert into postingdetails(sno,idno,Desigid,postid,districtid,poposting,doposting,dorelieve,lastupdatedtime,hostipaddress)values(@max,@idno,@Desigid,@postid,@districtid,@poposting,@doposting,@dorelieve,@lastupdatedtime,@hostipaddress)", con);
                SqlCommand cmd = new SqlCommand("parapostadd1", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sno", SqlDbType.Int, 10).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 10).Value = Convert.ToInt32(Request.QueryString["idno"]);
                //cmd.Parameters.Add("@Desigid", SqlDbType.Int, 4).Value = DDesign.SelectedItem.Value;
                cmd.Parameters.Add("@postid", SqlDbType.Int, 4).Value = DPOST.SelectedItem.Value;
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

                if (DD1.SelectedIndex != 0 && DM1.SelectedIndex != 0 && DY1.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DM1.SelectedItem.Text + "/" + DD1.SelectedItem.Text + "/" + DY1.SelectedItem.Text);//Convert.ToDateTime(
                }
                else if (DM1.SelectedIndex == 0 || DD1.SelectedIndex == 0 || DY1.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@doposting", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@dorelieve", DBNull.Value);
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@lock", SqlDbType.NVarChar, 50).Value = "";

                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mesg.Text = "";
                    cl.upcon.Close();
                    cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "', modifieruserid='" + Uidt.Text + "',postingstatus='J' where idno='" + Request.QueryString["idno"] + "'");
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
            Session.Add("ODR", "JOIN");
            Response.Write(("<script language=javascript>window.open(\'paraRelOrdprint.aspx?oid=" + (oid.Text + (" &idno=" + (Request.QueryString["idno"] + "\',\'new_Win\');</script>")))));


        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (Ornot.Text != "")
                {
                    cl.ds = cl.DataFill("SELECT     MAX(doposting) AS doposting, dorelieve FROM  pmdpostingdetails WHERE (idno = " + Request.QueryString["idno"] + ")AND (dorelieve IS NULL) GROUP BY dorelieve");
                    if (cl.ds.Tables[0].Rows.Count > 0)
                    {
                        mesg.Text = "You Are Trying To Join That Person Which  Have One Post To Relieve.......Please Do in Correct Manner";
                        //this.fLink.Visible = true;
                    }
                    else
                    {
                        //this.fLink.Visible = false;
                        maxpicor();
                        maxpic();

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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2JRmenu.aspx");
        }
    }
}