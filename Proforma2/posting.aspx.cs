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
using System.Data.SqlClient;
using System.Security.Policy;

namespace NewWebApp.Proforma2
{
    public partial class posting : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();

        public void msg(string msg)
        {
            string sMsg = msg.Replace("\n", "\\n");
            sMsg = msg.Replace("\"", "'");
            Response.Write(@"<script language='javascript'>");
            Response.Write(@"alert( """ + sMsg + @""" );");
            Response.Write(@"</script>");
        }
        public void confirm(string msg, string hiddenfield_name)
        {
            string sMsg = msg.Replace("\n", "\\n");
            sMsg = msg.Replace("\"", "'");
            //StringBuilder sb = new StringBuilder(); 
            Response.Write(@"<INPUT type=hidden value='0' name='" + hiddenfield_name + "'>");
            Response.Write(@"<script language='javascript'>");
            Response.Write(@" if(confirm( """ + sMsg + @""" ))");
            Response.Write(@" { ");
            Response.Write("document.forms[0]." + hiddenfield_name + ".value='1';" + "document.forms[0].submit(); }");
            Response.Write(@" else { ");
            Response.Write("document.forms[0]." + hiddenfield_name + ".value='0'; }");
            Response.Write(@"</script>");
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
            cl.ds.Clear();
            cl.ds.Dispose();
            //********************
            cl.ds = cl.DataFill("SELECT     newpostid, newpostname FROM         post ORDER BY newpostname");
            DPOST.DataSource = cl.ds;
            DPOST.DataTextField = "newpostname";
            DPOST.DataValueField = "newpostid";
            DPOST.DataBind();
            DPOST.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();

            //********************
            cl.ds = cl.DataFill("SELECT     leveldesc, levelid FROM         lavel ORDER BY leveldesc");
            lvl.DataSource = cl.ds;
            lvl.DataTextField = "leveldesc";
            lvl.DataValueField = "levelid";
            lvl.DataBind();
            lvl.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();

            //********************
            cl.ds = cl.DataFill("SELECT ureasonname, ureasonid FROM ureason ORDER BY ureasonname");
            updreason.DataSource = cl.ds;
            updreason.DataTextField = "ureasonname";
            updreason.DataValueField = "ureasonid";
            updreason.DataBind();
            updreason.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();
            //********************
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();
            //****************
            Dplace.Items.Insert(0, new ListItem("--select--"));

        }
        public void runpost()
        {
            try
            {//
                cl.ds = cl.DataFill("SELECT  designation.designame, post.newpostname, hospitaldistrict.districtname, hospitalname.hname, CONVERT(char, postingdetails.doposting, 103) AS doposting, CONVERT(char, postingdetails.dorelieve, 103) AS dorelieve,hospitalname.sno, postingdetails.doposting AS pd, postingdetails.dorelieve AS pr,postingdetails.districtid, postingdetails.poposting, postingdetails.sno FROM  postingdetails INNER JOIN hospitaldistrict ON postingdetails.districtid = hospitaldistrict.districtid INNER JOIN designation ON postingdetails.Desigid = designation.Desigid INNER JOIN post ON postingdetails.postid = post.newpostid LEFT OUTER JOIN  hospitalname ON postingdetails.poposting = hospitalname.sno WHERE     (postingdetails.idno = '" + Request.QueryString["idno"] + "') ORDER BY postingdetails.doposting");
                int j;//sno
                if (cl.ds.Tables[0].Rows.Count > 0)
                {

                    TableRow rw = new TableRow();
                    rw.BorderColor = System.Drawing.Color.SlateGray;
                    rw.BackColor = System.Drawing.Color.BurlyWood;
                    rw.ForeColor = System.Drawing.Color.Maroon;
                    rw.BorderWidth = 1;


                    TableCell tcell0 = new TableCell();
                    tcell0.Text = "Sr.No.";
                    tcell0.BorderWidth = 1;
                    tcell0.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell0.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell0);


                    TableCell tcell1 = new TableCell();
                    tcell1.Text = "Designation";
                    tcell1.BorderWidth = 1;
                    tcell1.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell1.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell1);

                    TableCell tcell2 = new TableCell();
                    tcell2.Text = "Post Name";
                    tcell2.BorderWidth = 1;
                    tcell2.BorderColor = System.Drawing.Color.SlateGray;
                    // tcell2.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell2);

                    TableCell tcell3 = new TableCell();
                    tcell3.Text = "District";
                    tcell3.BorderWidth = 1;
                    tcell3.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell3.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell3);

                    TableCell tcell4 = new TableCell();
                    tcell4.Text = "Hospital Name";
                    tcell4.BorderWidth = 1;
                    tcell4.BorderColor = System.Drawing.Color.SlateGray;
                    // tcell4.ForeColor = System.Drawing.Color.Black;

                    rw.Cells.Add(tcell4);

                    TableCell tcell5 = new TableCell();
                    tcell5.Text = "Date Of Posting";
                    tcell5.BorderWidth = 1;
                    tcell5.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell5.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcell5);

                    TableCell tcell6 = new TableCell();
                    tcell6.Text = "Date Of Relieving";
                    tcell6.BorderWidth = 1;
                    tcell6.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell6.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcell6);

                    TableCell tcellEd = new TableCell();
                    tcellEd.Text = "Edit";
                    tcellEd.BorderWidth = 1;
                    tcellEd.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell7.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcellEd);

                    TableCell tcell7 = new TableCell();
                    tcell7.Text = "Delete";
                    tcell7.BorderWidth = 1;
                    tcell7.BorderColor = System.Drawing.Color.SlateGray;
                    //tcell7.ForeColor = System.Drawing.Color.Black;
                    rw.Cells.Add(tcell7);

                    Table1.Rows.Add(rw);
                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {
                        TableRow rw1 = new TableRow();
                        rw1.BorderWidth = 1;
                        rw1.BorderColor = System.Drawing.Color.SlateGray;

                        TableCell tcell10 = new TableCell();
                        tcell10.BorderWidth = 1;
                        tcell10.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell10.ForeColor = System.Drawing.Color.Black;
                        tcell10.Text = Convert.ToString(j + 1);//sr
                        rw1.Cells.Add(tcell10);

                        TableCell tcell11 = new TableCell();
                        tcell11.BorderWidth = 1;
                        tcell11.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell11.ForeColor = System.Drawing.Color.Black;
                        if (!(cl.ds.Tables[0].Rows[j][0].ToString().Equals(System.DBNull.Value)))
                        {
                            tcell11.Text = cl.ds.Tables[0].Rows[j][0].ToString();//desig
                        }
                        else
                        {
                            tcell11.Text = "NONE";
                        }
                        rw1.Cells.Add(tcell11);

                        TableCell tcell21 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][1].ToString().Equals(System.DBNull.Value)))
                        {
                            tcell21.Text = cl.ds.Tables[0].Rows[j][1].ToString();//post
                        }
                        else
                        {
                            tcell21.Text = "NONE";
                        }
                        tcell21.BorderWidth = 1;
                        tcell21.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell21.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell21);

                        TableCell tcell31 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][2].ToString().Equals(System.DBNull.Value)))
                        {
                            tcell31.Text = cl.ds.Tables[0].Rows[j][2].ToString();//district
                        }
                        else
                        {
                            tcell31.Text = "NONE";
                        }
                        tcell31.BorderWidth = 1;
                        tcell31.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell31.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell31);

                        TableCell tcell41 = new TableCell();
                        if (!(cl.ds.Tables[0].Rows[j][3].ToString().Equals(System.DBNull.Value)))//hname
                        {
                            tcell41.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                            if (cl.ds.Tables[0].Rows[j][9].ToString() == "0" && cl.ds.Tables[0].Rows[j][10].ToString() == "0")
                            {
                                string a = cl.ds.Tables[0].Rows[j][7].ToString();
                                string b = cl.ds.Tables[0].Rows[j][11].ToString();
                                try
                                {
                                    cl.ds1 = cl.DataFill2("SELECT postingdetails.sno, otherhospitalposting.hname, postingdetails.idno,postingdetails.doposting FROM  postingdetails INNER JOIN  otherhospitalposting ON postingdetails.sno = otherhospitalposting.sno WHERE     (postingdetails.sno= '" + Convert.ToInt32(b) + "')AND (postingdetails.idno = " + Request.QueryString["idno"] + ")");//Format(Now(), "dd-MMM-yyyy")     + "'//WHERE     (postingdetails.idno = 70) AND (postingdetails.sno = 6287)
                                    if (cl.ds1.Tables[0].Rows.Count > 0)
                                    {
                                        tcell41.Text = cl.ds1.Tables[0].Rows[0][1].ToString();
                                    }
                                    else
                                    {
                                        tcell41.Text = "NONE";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Response.Write("Error :" + ex.Message);
                                }
                                finally
                                {
                                }
                            }

                        }
                        else
                        {
                            tcell41.Text = "NONE";
                        }

                        tcell41.BorderWidth = 1;
                        tcell41.BorderColor = System.Drawing.Color.SlateGray;
                        tcell41.ForeColor = System.Drawing.Color.DarkGreen;
                        rw1.Cells.Add(tcell41);

                        TableCell tcell51 = new TableCell();
                        tcell51.Text = cl.ds.Tables[0].Rows[j][4].ToString();//dp
                        tcell51.BorderWidth = 1;
                        tcell51.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell51.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell51);
                        //Table1.Rows.Add(rw1);

                        TableCell tcell61 = new TableCell();
                        tcell61.Text = cl.ds.Tables[0].Rows[j][5].ToString();//dr
                        tcell61.BorderWidth = 1;
                        tcell61.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell61.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell61);

                        TableCell tcellE = new TableCell();
                        tcellE.Text = "Edit";//dr
                        tcellE.BorderWidth = 1;
                        tcellE.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell91.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcellE);
                        tcellE.Text = ("<a href=\'editposting.aspx?sno=" + (cl.ds.Tables[0].Rows[j][11].ToString() + ("\'>" + (" (" + (tcellE.Text + ")</a>")))));

                        TableCell tcell91 = new TableCell();
                        tcell91.Text = "Delete";//dr
                        tcell91.BorderWidth = 1;
                        tcell91.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell91.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell91);
                        tcell91.Text = ("<a href=\'delposting.aspx?sno=" + (cl.ds.Tables[0].Rows[j][11].ToString() + ("\'>" + (" (" + (tcell91.Text + ")</a>")))));
                        Table1.Rows.Add(rw1);

                    }
                }
                cl.ds.Clear();
                cl.ds.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                sdate();
                sdate1();
                dfill();
                runpost();
                cl.ds = cl.DataFill("SELECT senno,name FROM personaldetails where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    this.sen.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    this.name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {

                }
                cl.ds.Clear();
                cl.ds.Dispose();
            }
        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(sno),0)+ 1 FROM postingdetails");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            cl.ds.Clear();
            cl.ds.Dispose();
        }
        protected void BSAVE_Click(object sender, EventArgs e)
        {
            //duplicatecurrentpost
            if (DM1.SelectedIndex == 0 || DD1.SelectedIndex == 0 || DY1.SelectedIndex == 0)
            {
                cl.ds = cl.DataFill("SELECT     doposting, dorelieve FROM postingdetails WHERE     (idno = " + Request.QueryString["idno"] + ") AND (dorelieve IS NULL)");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Msg.Text = "This Person already have one post to relieve";
                }
                else
                {
                    datastore();
                    setdd();
                }
                cl.ds.Clear();
                cl.ds.Dispose();
            }
            else
            {
                datastore();
                setdd();
            }

        }
        public void datastore()
        {
            try
            {

                maxpic();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into postingdetails(sno,idno,Desigid,postid,districtid,poposting,doposting,dorelieve,lastupdatedtime,hostipaddress,udate,userid,lavel,orderno,orderdate,updreason)values(@max,@idno,@Desigid,@postid,@districtid,@poposting,@doposting,@dorelieve,@lastupdatedtime,@hostipaddress,@udate,@userid,@lavel,@ordno,@orddat,@updreason)", cl.upcon);
                cmd.Parameters.Add("@max", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["idno"]);
                if (DDesign.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@Desigid", SqlDbType.Int, 4).Value = DDesign.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Desigid", SqlDbType.Int, 4).Value = 0;
                }
                if (DPOST.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@postid", SqlDbType.Int, 4).Value = DPOST.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@postid", SqlDbType.Int, 4).Value = 0;
                }
                if (DDistrict.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@districtid", SqlDbType.Int, 4).Value = DDistrict.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@districtid", SqlDbType.Int, 4).Value = 0;
                }

                if (Dplace.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@poposting", SqlDbType.Int, 4).Value = Dplace.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@poposting", SqlDbType.Int, 4).Value = 0;
                }

                if (DDD.SelectedIndex != 0 && DMM.SelectedIndex != 0 && DYYYY.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DMM.SelectedItem.Text + "/" + DDD.SelectedItem.Text + "/" + DYYYY.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (DDD.SelectedIndex == 0 || DMM.SelectedIndex == 0 || DYYYY.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@doposting", DBNull.Value);
                }

                if (DD1.SelectedIndex != 0 && DM1.SelectedIndex != 0 && DY1.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@dorelieve", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DM1.SelectedItem.Text + "/" + DD1.SelectedItem.Text + "/" + DY1.SelectedItem.Text);//Convert.ToDateTime(
                }
                else if (DM1.SelectedIndex == 0 || DD1.SelectedIndex == 0 || DY1.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@dorelieve", DBNull.Value);
                }
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@udate", SqlDbType.NVarChar, 50).Value = System.DateTime.Today;
                cmd.Parameters.AddWithValue("@userid", (string)Session["iduser"]);
                
                if (lvl.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@lavel", SqlDbType.Int, 4).Value = lvl.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@lavel", SqlDbType.Int, 4).Value = 0;
                }
                cmd.Parameters.AddWithValue("@ordno", ordno.Text);
                cmd.Parameters.Add("@orddat", SqlDbType.VarChar,50).Value=orddat.Text;
                if (updreason.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@updreason", SqlDbType.Int, 4).Value = updreason.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@updreason", SqlDbType.Int, 4).Value = 0;
                }

                if (cmd.ExecuteNonQuery() == 1)
                {
                    cl.upcon.Close();
                    if (DDistrict.SelectedItem.Text == "NONE" && Dplace.SelectedIndex == 0)
                    {
                        //
                        try
                        {
                            cl.upcon.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into otherhospitalposting(sno,idno,hname)values(@sno,@idno,@hname)", cl.upcon);
                            cmd1.Parameters.Add("@sno", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                            cmd1.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["idno"]);
                            cmd1.Parameters.Add("@hname", SqlDbType.NVarChar, 50).Value = OtherDist.Text + " ," + OtherPost.Text;
                            if (cmd1.ExecuteNonQuery() == 1)
                            {
                                cl.upcon.Close();
                            }
                            else
                            {
                                Msg.Text = "Technical Problem";
                            }
                        }
                        catch (Exception ex)
                        {
                            Msg.Visible = true;
                            Msg.Text = ("Error :" + ex.Message);
                        }
                        finally
                        {
                            cl.upcon.Close();
                        }

                    }
                    Msg.Text = "Data save Successfully";
                    //runpost();                   
                }
                else
                {
                    Msg.Text = "Technical Problem";
                }

            }
            catch (Exception ex)
            {
                Msg.Visible = true;
                Msg.Text = ("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();
                runpost();
            }
        }
        public void setdd()
        {
            DDD.SelectedIndex = 0;
            DMM.SelectedIndex = 0;
            DYYYY.SelectedIndex = 0;
            DD1.SelectedIndex = 0;
            DM1.SelectedIndex = 0;
            DY1.SelectedIndex = 0;

        }
        public void setd()
        {
            foreach (Control d in ((HtmlForm)Page.FindControl("form1")).Controls)
            {
                if (d is System.Web.UI.WebControls.DropDownList)
                {
                    DropDownList DT = ((DropDownList)d);
                    DT.SelectedIndex = 0;
                }
            }
        }
        protected void PFsheet_Click(object sender, EventArgs e)
        {
            //Response.Redirect("proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");
            Server.Transfer("DoctorP2.aspx?idno=" + Request.QueryString["idno"] + "");
        }

        protected void GridView3_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void Enq_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/Denquiry.aspx?idno=" + Request.QueryString["idno"] + "");
        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDistrict.SelectedIndex != 0)
            {
                //****************
                cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid =" + DDistrict.SelectedItem.Value + ") ORDER BY hospitalname.hname");
                Dplace.DataSource = cl.ds;
                Dplace.DataTextField = "hname";
                Dplace.DataValueField = "sno";
                Dplace.DataBind();
                Dplace.Items.Insert(0, new ListItem("--select--"));
                cl.ds.Clear();
                cl.ds.Dispose();
                if (DDistrict.SelectedItem.Text == "NONE")
                {
                    this.OtherDist.Visible = true;
                    Dplace.Enabled = false;
                    this.OtherPost.Visible = true;
                    this.Label2.Visible = true;
                    this.Label3.Visible = true;
                }
                else
                {
                    this.OtherDist.Visible = false;
                    Dplace.Enabled = true;
                    this.OtherPost.Visible = false;
                    this.Label2.Visible = false;
                    this.Label3.Visible = false;
                }
            }
        }
        protected void Dplace_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            // for (i = 1940; i <= 2040; i++)
            for (i = 2030; i >= 1940; i--)
            {
                DYYYY.Items.Add("" + Convert.ToString(i) + "");
            }
            DYYYY.Items.Insert(0, new ListItem("0"));

        }


        protected void DYYYY_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/Option.aspx");
        }
    }
}