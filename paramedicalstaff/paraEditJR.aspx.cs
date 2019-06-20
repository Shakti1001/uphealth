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

namespace NewWebApp.paramedicalstaff
{
    public partial class paraEditJR : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                data();
                dfill();
                setdata();
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

            cl.ds = cl.DataFill("SELECT DISTINCT hname, sno FROM hospitalname  ORDER BY hname");
            Dplace.DataSource = cl.ds;
            Dplace.DataTextField = "hname";
            Dplace.DataValueField = "sno";
            Dplace.DataBind();
            Dplace.Items.Insert(0, new ListItem("--select--"));
        }
        public void data()
        {
            cl.ds = cl.DataFill("SELECT idno,orderby,orderno, Convert(varchar,orderdate,101) as orderdate,  Convert(varchar,currentdate,101)as currentdate FROM  status_join_releive where statussr=" + Request.QueryString["statussr"] + "");//and currentdate='" + Convert.ToDateTime(Request.QueryString["curdate"]) + "'"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    this.idnoL.Text = cl.ds.Tables[0].Rows[0][0].ToString();

                }
                else
                {
                    this.idnoL.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    orderbyt.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                    this.Orbyt.Text = cl.ds.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    orderbyt.Text = "";
                    this.Orbyt.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    ordernot.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                    Ornot.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    ordernot.Text = "";
                    Ornot.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    orderdatet.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                    ORDText.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    orderdatet.Text = "";
                    ORDText.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    curdatet.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                    JRText.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    curdatet.Text = "";
                    JRText.Text = "";
                }

            }
            cl.ds = cl.DataFill("SELECT idno,name, newpostname,districtname,hname FROM factsheetsearchCriteria where idno=" + this.idnoL.Text + "");//"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    Relievename.Text = cl.ds.Tables[0].Rows[0][1].ToString();//Relievename//Joinname
                }
                else
                {
                    Relievename.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    Postt.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    Postt.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {

                    placet.Text = cl.ds.Tables[0].Rows[0][4].ToString() + "," + cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    placet.Text = "";
                }
                //////////////////////////////////////////
            }

        }
        public void setdata()
        {
            cl.ds = cl.DataFill("SELECT     Desigid, postid, districtid, poposting,doposting,sno FROM  postingdetails where idno=" + this.idnoL.Text + " and orderid=" + Request.QueryString["statussr"] + "");//"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    DDesign.SelectedIndex = DDesign.Items.IndexOf(DDesign.Items.FindByValue(cl.ds.Tables[0].Rows[0][0].ToString()));
                }
                else
                {
                    DDesign.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    DPOST.SelectedIndex = DPOST.Items.IndexOf(DPOST.Items.FindByValue(cl.ds.Tables[0].Rows[0][1].ToString()));
                }
                else
                {
                    DPOST.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    DDistrict.SelectedIndex = DDistrict.Items.IndexOf(DDistrict.Items.FindByValue(cl.ds.Tables[0].Rows[0][2].ToString()));
                }
                else
                {
                    DDistrict.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    Dplace.SelectedIndex = Dplace.Items.IndexOf(Dplace.Items.FindByValue(cl.ds.Tables[0].Rows[0][3].ToString()));
                }
                else
                {
                    Dplace.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    curdate.Text = cl.ds.Tables[0].Rows[0][4].ToString().Trim();
                }
                else
                {
                    curdate.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][5].ToString().Equals(System.DBNull.Value)))
                {
                    this.oid.Text = cl.ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    this.oid.Text = "";
                }
            }
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
        protected void Dplace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void ordersave()
        {
            try
            {
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("joinrelieve", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@statussr", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["statussr"]);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(this.idnoL.Text);
                cmd.Parameters.Add("@orderno", SqlDbType.NVarChar, 50).Value = Ornot.Text.Replace("\'", "\'\'").Trim();
                //cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime((ORDText.Text).Trim());
                cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime((ORDText.Text).TrimEnd());
                cmd.Parameters.Add("@orderby", SqlDbType.NVarChar, 50).Value = Orbyt.Text.Replace("\'", "\'\'").Trim();
                //cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime((JRText.Text.Trim()));
                cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = JRText.Text;
                if ((string)Session["pass"] == "RELRET")
                {
                    cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "R";
                }
                else if ((string)Session["pass"] == "Join")
                {
                    cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "J";
                }
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Now;
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = Uidt.Text;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                if (cmd.ExecuteNonQuery() == 1)
                {
                    cl.upcon.Close();
                    this.mesg.Text = "The Given information have been saved if you want to Print click on print button";

                }
                else
                {
                    this.mesg.Text = "Error";

                }
            }
            catch (Exception ex)
            {
                this.mesg.Text = "Error In OrderSave :" + ex.Message;
                //Response.Write("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();

            }
        }
        public void postsave()
        {
            try
            {
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("postadd", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sno", SqlDbType.Int, 4).Value = Convert.ToInt32(this.oid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(this.idnoL.Text);
                cmd.Parameters.Add("@Desigid", SqlDbType.Int, 4).Value = DDesign.SelectedItem.Value;
                cmd.Parameters.Add("@postid", SqlDbType.Int, 4).Value = DPOST.SelectedItem.Value;
                cmd.Parameters.Add("@districtid", SqlDbType.Int, 4).Value = DDistrict.SelectedItem.Value;
                cmd.Parameters.Add("@poposting", SqlDbType.Int, 4).Value = Dplace.SelectedItem.Value;
                if ((string)Session["pass"] == "RELRET")
                {
                    cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = Convert.ToDateTime((curdate.Text.Trim()));
                    cmd.Parameters.Add("@dorelieve", SqlDbType.DateTime, 8).Value = Convert.ToDateTime((JRText.Text.Trim()));
                }
                else if ((string)Session["pass"] == "Join")
                {
                    cmd.Parameters.Add("@doposting", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(curdate.Text);
                    cmd.Parameters.AddWithValue("@dorelieve", DBNull.Value);
                }
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@lock", SqlDbType.NVarChar, 50).Value = "";

                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mesg.Text = "";
                    cl.upcon.Close();
                    cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "', modifieruserid='" + Uidt.Text + "',postingstatus='J' where idno=" + this.idnoL.Text + "");
                }
                else
                {
                    this.mesg.Text = "Technical Problem";
                }

            }
            catch (Exception ex)
            {

                this.mesg.Text = ("Error In Postsave :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();
            }
        }
        protected void BSAVE_Click(object sender, EventArgs e)
        {
            // cl.cmd = cl.InsertDB("update Ucreate set lastupdatedtime='" + System.DateTime.Now + "' where iduser='" + cl.ds.Tables[0].Rows[0][0].ToString() + "'");
            ordersave();
            postsave();
        }
        protected void PFsheet_Click(object sender, EventArgs e)
        {
            Response.Write(("<script language=javascript>window.open(\'paraRelOrdprint.aspx?oid=" + (Request.QueryString["statussr"] + (" &idno=" + (this.idnoL.Text + "\',\'new_Win\');</script>")))));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2JRmenu.aspx");
        }
    }
}