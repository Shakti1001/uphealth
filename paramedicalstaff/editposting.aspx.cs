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
    public partial class editposting : System.Web.UI.Page
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
            //cl.ds = cl.DataFill("SELECT     Desigid, designame FROM         designation ORDER BY Desigid");
            //DDesign.DataSource = cl.ds;
            //DDesign.DataTextField = "designame";
            //DDesign.DataValueField = "Desigid";
            //DDesign.DataBind();
            //DDesign.Items.Insert(0, new ListItem("--select--"));
            //********************
            cl.ds = cl.DataFill("SELECT     desigid, designame FROM         PMDhospitaldesignation ORDER BY designame");
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

            cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid  ORDER BY hospitalname.hname");
            Dplace.DataSource = cl.ds;
            Dplace.DataTextField = "hname";
            Dplace.DataValueField = "sno";
            Dplace.DataBind();
            Dplace.Items.Insert(0, new ListItem("--select--"));

            //Dplace.Items.Insert(0, new ListItem("--select--"));

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                Response.Expires = -1500;
                Response.CacheControl = "no-cache";
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                dfill();
                data();
                //runpost();
                cl.ds = cl.DataFill("SELECT     PMDpersonaldetails.name, PMDpersonaldetails.senno, PMDpersonaldetails.idno FROM         PMDpostingdetails INNER JOIN                      PMDpersonaldetails ON PMDpostingdetails.idno = PMDpersonaldetails.idno  WHERE  pmdpostingdetails.sno =" + Request.QueryString["sno"] + "");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    this.sen.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                    this.name.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    this.maxid.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {

                }
            }
        }

        public void runpost()
        {
            try
            {//
                cl.ds = cl.DataFill("SELECT     hospitaldistrict.districtname, hospitalname.hname, CONVERT(char, PMDpostingdetails.doposting, 103) AS doposting, CONVERT(char, PMDpostingdetails.dorelieve,                       103) AS dorelieve, hospitalname.sno, PMDpostingdetails.doposting AS pd, PMDpostingdetails.dorelieve AS pr, pmdpostingdetails.sno AS psno,                       PMDhospitaldesignation.designame FROM         PMDpostingdetails INNER JOIN                      hospitaldistrict ON PMDpostingdetails.districtid = hospitaldistrict.districtid INNER JOIN                      PMDhospitaldesignation ON PMDpostingdetails.postid = PMDhospitaldesignation.desigid LEFT OUTER JOIN                      hospitalname ON PMDpostingdetails.poposting = hospitalname.sno  WHERE     (pmdpostingdetails.idno = '" + Request.QueryString["idno"] + "') ORDER BY pmdpostingdetails.doposting");
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
                            if (tcell41.Text == "")
                            {
                                string a = cl.ds.Tables[0].Rows[j][7].ToString();
                                try
                                {
                                    cl.ds1 = cl.DataFill2("SELECT pmdpostingdetails.sno, pmdotherhospitalposting.hname, pmdpostingdetails.idno,pmdpostingdetails.doposting FROM  pmdpostingdetails INNER JOIN  pmdotherhospitalposting ON pmdpostingdetails.sno = pmdotherhospitalposting.sno WHERE     (pmdpostingdetails.doposting = '" + DateTime.Parse(a) + "')AND (pmdpostingdetails.idno = " + Request.QueryString["idno"] + ")");//Format(Now(), "dd-MMM-yyyy")     + "'
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

                        TableCell tcell91 = new TableCell();
                        tcell91.Text = "Delete";//dr
                        tcell91.BorderWidth = 1;
                        tcell91.BorderColor = System.Drawing.Color.SlateGray;
                        //tcell91.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcell91);
                        tcell91.Text = ("<a href=\'pmddelposting.aspx?sno=" + (cl.ds.Tables[0].Rows[j][9].ToString() + ("\'>" + (" (" + (tcell91.Text + ")</a>")))));

                        Table1.Rows.Add(rw1);

                    }
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


        protected void BSAVE_Click(object sender, EventArgs e)
        {
            //duplicatecurrentpost
            //if (doa.Text=="")
            //{
            //    cl.ds = cl.DataFill("SELECT     doposting, dorelieve FROM postingdetails WHERE     (idno = " + maxid.Text + ") AND (dorelieve IS NULL)");
            //    if (cl.ds.Tables[0].Rows.Count > 0)
            //    {
            //        Msg.Text = "This Person already have one post to relieve";
            //    }
            //    else
            //    {
            //        datastore();
            //     }
            //}
            //else
            //{
            //    datastore();
            //    Server.Transfer("~/Proforma2/Posting.aspx?idno=" + Convert.ToInt32(maxid.Text) + "");

            //}

            datastore();
            Server.Transfer("~/paramedicalstaff/parap2Posting.aspx?idno=" + Convert.ToInt32(maxid.Text) + "");


        }


        public void datastore()
        {
            try
            {
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("update pmdpostingdetails set postid=@postid,districtid=@districtid,poposting=@poposting,doposting=@doposting,dorelieve=@dorelieve,lastupdatedtime=@lastupdatedtime,hostipaddress=@hostipaddress,userid=@userid where sno=" + Request.QueryString["sno"] + "", cl.upcon);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["idno"]);
                //if (DDesign.SelectedIndex != 0)
                //{
                //    cmd.Parameters.Add("@Desigid", SqlDbType.Int, 4).Value = DDesign.SelectedItem.Value;
                //}
                //else
                //{
                //    cmd.Parameters.Add("@Desigid", SqlDbType.Int, 4).Value = 0;
                //}
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

                if (dojs.Text != "")
                {
                    cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(dojs.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (dojs.Text == "")
                {
                    cmd.Parameters.AddWithValue("@doposting", DBNull.Value);
                }

                if (doa.Text != "")
                {
                    cmd.Parameters.Add("@dorelieve", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(doa.Text);//Convert.ToDateTime(
                }
                else if (doa.Text == "")
                {
                    cmd.Parameters.AddWithValue("@dorelieve", DBNull.Value);
                }
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.AddWithValue("@userid", (string)Session["iduser"]);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    cl.upcon.Close();
                    if (DDistrict.SelectedItem.Text == "NONE" && Dplace.SelectedIndex == 0)
                    {
                        //
                        try
                        {
                            cl.upcon.Open();
                            SqlCommand cmd1 = new SqlCommand("Update pmdotherhospitalposting set hname=@hname where sno=" + Request.QueryString["sno"] + "", cl.upcon);
                            cmd1.Parameters.Add("@hname", SqlDbType.NVarChar, 50).Value = OtherPost.Text;
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
                    Msg.Text = "Data Updated Successfully";
                }
                else
                {
                    Msg.Visible = true;
                    Msg.Text = "Please Check The Entry";
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

        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            //****************
            Msg.Text = "";
            cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid =" + DDistrict.SelectedItem.Value + ") ORDER BY hospitalname.hname");
            Dplace.DataSource = cl.ds;
            Dplace.DataTextField = "hname";
            Dplace.DataValueField = "sno";
            Dplace.DataBind();
            Dplace.Items.Insert(0, new ListItem("--select--"));
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
        protected void Dplace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void BACK_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2Posting.aspx?idno=" + Convert.ToInt32(maxid.Text) + "");
        }

        public void data()
        {//SELECT     districtid, poposting, Desigid, postid, convert(varchar,doposting,101)as doposting, convert(varchar,dorelieve,101) as dorelieve FROM         postingdetails WHERE     (sno = 711)
            cl.ds = cl.DataFill("SELECT     districtid, poposting, postid, CONVERT(varchar, doposting, 101) AS doposting, CONVERT(varchar, dorelieve, 101) AS dorelieve from PMDpostingdetails  WHERE     (sno =" + Request.QueryString["sno"] + ")");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    DDistrict.SelectedIndex = DDistrict.Items.IndexOf(DDistrict.Items.FindByValue(cl.ds.Tables[0].Rows[0][0].ToString()));
                    if (DDistrict.SelectedItem.Text == "NONE")
                    {

                        try
                        {
                            cl.ds1 = cl.DataFill2("SELECT pmdpostingdetails.sno, pmdotherhospitalposting.hname, pmdpostingdetails.idno,pmdpostingdetails.doposting FROM  pmdpostingdetails INNER JOIN  pmdotherhospitalposting ON pmdpostingdetails.sno = pmdotherhospitalposting.sno WHERE  pmdotherhospitalposting.sno=" + Request.QueryString["sno"] + "");//Format(Now(), "dd-MMM-yyyy")     + "'
                            if (cl.ds1.Tables[0].Rows.Count > 0)
                            {
                                Label3.Visible = true;
                                OtherPost.Visible = true;
                                OtherPost.Text = cl.ds1.Tables[0].Rows[0][1].ToString();
                            }
                            else
                            {
                                Label3.Visible = true;
                                OtherPost.Visible = true;
                                OtherPost.Text = "NONE";
                            }
                        }
                        catch (Exception ex)
                        {
                            OtherPost.Visible = false;
                            Response.Write("Error :" + ex.Message);
                        }
                        finally
                        {
                        }
                    }
                }
                else
                {
                    DDistrict.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    Dplace.SelectedIndex = Dplace.Items.IndexOf(Dplace.Items.FindByValue(cl.ds.Tables[0].Rows[0][1].ToString()));
                    if (Dplace.SelectedItem.Text == "")
                    {
                        Dplace.SelectedIndex = 0;
                    }
                }
                else
                {
                    Dplace.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    DPOST.SelectedIndex = DPOST.Items.IndexOf(DPOST.Items.FindByValue(cl.ds.Tables[0].Rows[0][2].ToString()));
                }
                else
                {
                    DPOST.SelectedIndex = 0;
                }
                //if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                //{
                //    DDesign.SelectedIndex = DDesign.Items.IndexOf(DDesign.Items.FindByValue(cl.ds.Tables[0].Rows[0][3].ToString()));
                //}
                //else
                //{
                //    DDesign.SelectedIndex=0;
                //}

                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    dojs.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    dojs.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    doa.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    doa.Text = "";
                }
            }
        }
    }
}