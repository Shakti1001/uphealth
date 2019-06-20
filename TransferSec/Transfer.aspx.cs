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

namespace NewWebApp.TransferSec
{
    public partial class Transfer : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        testingSec secAU = new testingSec();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                //SELECT DISTINCT idno, name, senno, districtname, newpostname FROM         Rfactshee
                cl.ds = cl.DataFill("SELECT DISTINCT idno,name,senno,districtname, newpostname FROM Cfactsheet where idno=" + Request.QueryString["idno"] + "");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {

                    this.name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                    this.sen.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                    this.post.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                    this.plpost.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    Response.Write("Already Releived No joining yet");
                    Response.End();
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];

                dfill();
                pick();
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
            cl.ds = cl.DataFill("SELECT     TransOrderMaster.TransOridd, TransOrderMaster.TransOrname+' Dated :'+Convert(nvarchar,TransOrderMaster.TransOrdate,103)+'  By  '+ JRofficer.offname As Orno FROM         TransOrderMaster INNER JOIN   JRofficer ON TransOrderMaster.TransOrbyid = JRofficer.orid order By TransOrderMaster.lastupdatedtime");
            JORDERDD.DataSource = cl.ds;
            JORDERDD.DataTextField = "Orno";
            JORDERDD.DataValueField = "TransOridd";
            JORDERDD.DataBind();
            JORDERDD.Items.Insert(0, new ListItem("--select--"));
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
        protected void Dplace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pick()
        {
            if ((string)Session["trorder"] != null)
            {
                JORDERDD.SelectedIndex = JORDERDD.Items.IndexOf(JORDERDD.Items.FindByText((string)Session["trorder"]));
                this.TrLabel.Text = (string)Session["trorder"];
            }
        }
        protected void JORDERDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JORDERDD.SelectedIndex != 0)
            {
                this.TrLabel.Text = JORDERDD.SelectedItem.Text;
                Session.Add("trorder", JORDERDD.SelectedItem.Text);
            }
        }
        protected void BSAVE_Click(object sender, EventArgs e)
        {
            if (JORDERDD.SelectedIndex != 0)
            {
                transferadd();
            }

        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(und_Tr_id),0)+ 1 FROM [transfer_data]");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void transferadd()
        {
            try
            {//under_transfer

                maxpic();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("TransOradd", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@und_Tr_id", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@TransOridd", SqlDbType.Int, 4).Value = Convert.ToInt32(JORDERDD.SelectedItem.Value);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];
                cmd.Parameters.Add("@trdistrictid", SqlDbType.Int, 4).Value = Convert.ToInt32(DDistrict.SelectedItem.Value);
                cmd.Parameters.Add("@trplaceid", SqlDbType.Int, 4).Value = Convert.ToInt32(Dplace.SelectedItem.Value);
                cmd.Parameters.Add("@uid", SqlDbType.Int, 4).Value = Uidt.Text;
                cmd.Parameters.Add("@ipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                ///////////
                if (cmd.ExecuteNonQuery() == 1)
                {
                    cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "', modifieruserid='" + Uidt.Text + "',postingstatus='T' where idno='" + Request.QueryString["idno"] + "'");
                    cl.upcon.Close();
                    this.mesg.Text = "The Given Transfer information have been saved ";
                    LinkButton1.Visible = true;
                    LinkButton1.Text = "The Given information have been saved ..More ";
                    JORDERDD.SelectedIndex = 0;
                }
                else
                {
                    this.mesg.Text = "";
                    LinkButton1.Visible = false;
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

        protected void PFsheet_Click(object sender, EventArgs e)
        {

        }
        protected void fLink_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TransferSec/namesearch.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TransferSec/TRmenu.aspx");
        }
    }
}