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
    public partial class Hpcheckpost : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];

                ddfill();
                mastdata();
                data();

                // GridView1.DataBind();
                //SELECT     sno, hname FROM         hospitalname ORDER BY hname
                //SELECT     cadre.cadrename as Cader, hospitalname.hname as HospitalName, specialization.spname As Specialization, Designation.name As  Designation , lavel.levelcode as Level, hospitalrecord.posts as  SanctionedPost, hospitalrecord.posts - hospitalrecord.vaccantpost AS FilledPost, hospitalrecord.attachedpost as AttachedPost, hospitalrecord.vaccantpost as VaccantPost FROM         hospitalrecord INNER JOIN  specialization ON hospitalrecord.spid = specialization.spid INNER JOIN  cadre ON hospitalrecord.cadre = cadre.cadreid INNER JOIN  Designation ON hospitalrecord.desigid = Designation.Dcode INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno INNER JOIN  lavel ON hospitalrecord.lavel = lavel.levelcode ORDER BY hospitalname.hname
            }
        }
        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            //****************
            if (DDiv.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where divid =" + DDiv.SelectedItem.Value + " ORDER BY districtname");
                DDistrict.DataSource = cl.ds;
                DDistrict.DataTextField = "districtname";
                DDistrict.DataValueField = "districtid";
                DDistrict.DataBind();
                DDistrict.Items.Insert(0, new ListItem("--select--"));
            }
            else
            {

            }
            //****************
        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDistrict.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT hname, sno FROM  hospitalname WHERE districtid =" + DDistrict.SelectedItem.Value + "ORDER BY hname");
                DHNAME.DataSource = cl.ds;
                DHNAME.DataTextField = "hname";
                DHNAME.DataValueField = "sno";
                DHNAME.DataBind();
                DHNAME.Items.Insert(0, new ListItem("--select--"));
            }
        }
        protected void DHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDistrict.SelectedIndex != 0 && DHT.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT hname, sno FROM  hospitalname WHERE districtid =" + DDistrict.SelectedItem.Value + " and htype = " + DHT.SelectedItem.Value + " ORDER BY hname");
                DHNAME.DataSource = cl.ds;
                DHNAME.DataTextField = "hname";
                DHNAME.DataValueField = "sno";
                DHNAME.DataBind();
                DHNAME.Items.Insert(0, new ListItem("--select--"));
            }
            else
            {

            }
        }
        public void mastdata()
        {
            cl.ds = cl.DataFill("SELECT divname, divid FROM         division ORDER BY divname");
            DDiv.DataSource = cl.ds;
            DDiv.DataTextField = "divname";
            DDiv.DataValueField = "divid";
            DDiv.DataBind();
            DDiv.Items.Insert(0, new ListItem("--select--"));

            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));

            cl.ds = cl.DataFill("SELECT hname, sno FROM  hospitalname  ORDER BY hname");
            DHNAME.DataSource = cl.ds;
            DHNAME.DataTextField = "hname";
            DHNAME.DataValueField = "sno";
            DHNAME.DataBind();
            DHNAME.Items.Insert(0, new ListItem("--select--"));

            cl.ds = cl.DataFill("SELECT DISTINCT hospitaltype.htype, hospitaltype.hid FROM hospitaltype INNER JOIN   hospitalname ON hospitaltype.hid = hospitalname.htype  ORDER BY hospitaltype.htype");
            DHT.DataSource = cl.ds;
            DHT.DataTextField = "htype";
            DHT.DataValueField = "hid";
            DHT.DataBind();
            DHT.Items.Insert(0, new ListItem("--select--"));
        }
        public void ddfill()
        {
            //usecheck();         

            cl.ds = cl.DataFill("SELECT DISTINCT spname, spid FROM specialization ORDER BY spname");
            DCadre.DataSource = cl.ds;
            DCadre.DataTextField = "spname";
            DCadre.DataValueField = "spid";
            DCadre.DataBind();
            DCadre.Items.Insert(0, new ListItem("--select--"));
            cl.ds = cl.DataFill("SELECT     newpostname, newpostid FROM post ORDER BY newpostname");
            DPost.DataSource = cl.ds;
            DPost.DataTextField = "newpostname";
            DPost.DataValueField = "newpostid";
            DPost.DataBind();
            DPost.Items.Insert(0, new ListItem("--select--"));
            cl.ds = cl.DataFill("SELECT hname, sno FROM  hospitalname ORDER BY hname");
            DHNAME.DataSource = cl.ds;
            DHNAME.DataTextField = "hname";
            DHNAME.DataValueField = "sno";
            DHNAME.DataBind();
            DHNAME.Items.Insert(0, new ListItem("--select--"));
        }

        public void data()
        {//SELECT   divname,  districtname, tehsilname, blockname, htype, hname,  bedoccupacy FROM         hospitallist WHERE     sno = '" + Request.QueryString["sno"] + "'  
            //SELECT     divid, districtid, tehsilid, blockid, sno, bedoccupacy FROM         hospitallist WHERE     (sno = 3758)
            cl.ds = cl.DataFill("Select divid, districtid,hid,sno, tehsilid, blockid,  bedoccupacy FROM         hospitallist  where sno='" + Request.QueryString["sno"] + "'  ");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {

                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    this.DDiv.SelectedIndex = DDiv.Items.IndexOf(DDiv.Items.FindByValue(cl.ds.Tables[0].Rows[0][0].ToString()));
                    //if ((string)Session["val"] == "A")
                    //{
                    DDiv.Enabled = false;
                    //}
                }
                else
                {
                    DDiv.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    this.DDistrict.SelectedIndex = DDistrict.Items.IndexOf(DDistrict.Items.FindByValue(cl.ds.Tables[0].Rows[0][1].ToString()));
                    DDistrict.Enabled = false;
                }
                else
                {
                    DDistrict.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    this.DHT.SelectedIndex = DHT.Items.IndexOf(DHT.Items.FindByValue(cl.ds.Tables[0].Rows[0][2].ToString()));
                    DHT.Enabled = false;
                }
                else
                {
                    DHT.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    this.DHNAME.SelectedIndex = DHNAME.Items.IndexOf(DHNAME.Items.FindByValue(cl.ds.Tables[0].Rows[0][3].ToString()));
                    DHNAME.Enabled = false;
                }
                else
                {
                    DHNAME.SelectedIndex = 0;
                }
                GridView1.DataBind();


            }
        }


        protected void DDesign_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Dlevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //GridView1.Dispose();
            hospitalrecadd();
            //SELECT     cadre.cadrename, hospitalname.hname, specialization.spname, Designation.name, lavel.levelcode, hospitalrecord.posts, hospitalrecord.posts - hospitalrecord.vaccantpost AS fillpost, hospitalrecord.attachedpost, hospitalrecord.vaccantpost FROM         hospitalrecord INNER JOIN  specialization ON hospitalrecord.spid = specialization.spid INNER JOIN  cadre ON hospitalrecord.cadre = cadre.cadreid INNER JOIN  Designation ON hospitalrecord.desigid = Designation.Dcode INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno INNER JOIN  lavel ON hospitalrecord.lavel = lavel.levelcode ORDER BY hospitalname.hname
            //GridView1.DataBind();
        }

        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(sno),0)+ 1 FROM hospitalrecord");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void hospitalrecadd()
        {
            try
            {
                maxpic();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("Hrecadd", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sno", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                if (DHNAME.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@hnameid", SqlDbType.Int, 4).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@hnameid", SqlDbType.Int, 4).Value = DHNAME.SelectedItem.Value;
                }
                ///
                if (DPost.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@postid", SqlDbType.Int, 4).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@postid", SqlDbType.Int, 4).Value = DPost.SelectedItem.Value;
                }
                if (DCadre.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@speciality", SqlDbType.Int, 4).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@speciality", SqlDbType.Int, 4).Value = DCadre.SelectedItem.Value;
                }
                if (TSP.Text == "")
                {
                    cmd.Parameters.Add("@posts", SqlDbType.Int, 4).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@posts", SqlDbType.Int, 4).Value = Convert.ToInt32(TSP.Text);
                }
                //if(APCRText.Text=="")
                //{
                //    cmd.Parameters.Add("@withcadre", SqlDbType.Int, 4).Value = 0;
                //}
                //else
                //{
                //    cmd.Parameters.Add("@withcadre", SqlDbType.Int, 4).Value =Convert.ToInt32(APCRText.Text);
                //}
                //if(WCRText.Text=="")
                //{
                //    cmd.Parameters.Add("@withoutcadre", SqlDbType.Int, 4).Value = 0;
                //}
                //else
                //{
                //    cmd.Parameters.Add("@withoutcadre", SqlDbType.Int, 4).Value  =Convert.ToInt32(WCRText.Text);
                //}

                //if (TAtt.Text == "")
                //{
                //    cmd.Parameters.Add("@Extrapost", SqlDbType.Int, 4).Value = 0;
                //}
                //else
                //{
                //    cmd.Parameters.Add("@Extrapost", SqlDbType.Int, 4).Value = Convert.ToInt32(TAtt.Text);
                //}
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = (string)Session["iduser"];
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];

                if (cmd.ExecuteNonQuery() == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = " Record Added Successfully";
                    //this.TAtt.Text = "";
                    //this.APCRText.Text = "";
                    //this.WCRText.Text = "";
                    GridView1.DataBind();
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

            }
        }
        //public void usecheck()
        //{
        //    bool i;
        //    i = cl.checklavel((string)Session["iduser"]);
        //    if (i == true)
        //    {
        //        Uidt.Text = "%";
        //        cl.ds = cl.DataFill("SELECT DISTINCT divname, divid FROM  division ORDER BY divname");
        //        DDiv.DataSource = cl.ds;
        //        DDiv.DataTextField = "divname";
        //        DDiv.DataValueField = "divid";
        //        DDiv.DataBind();
        //        DDiv.Items.Insert(0, new ListItem("--select--"));
        //    }
        //    else
        //    {
        //        cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
        //        if (cl.ds.Tables[0].Rows.Count > 0)
        //        {
        //            Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        //            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where districtid =" + Uidt.Text + " ORDER BY districtname");
        //            DDistrict.DataSource = cl.ds;
        //            DDistrict.DataTextField = "districtname";
        //            DDistrict.DataValueField = "districtid";
        //            DDistrict.DataBind();
        //            DDistrict.Items.Insert(0, new ListItem("--select--"));
        //            DDiv.Items.Insert(0, new ListItem("Already Selected"));
        //        }
        //        else
        //        {
        //            Response.Redirect("~/login.aspx");
        //        }
        //    }
        //}

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../proforma/LHospitalopration.aspx");
        }
   
    }
}