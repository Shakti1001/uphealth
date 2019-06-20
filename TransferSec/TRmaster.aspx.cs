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
    public partial class TRmaster : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        testingSec tst = new testingSec();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        bool i;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.LCID = 2057;
            if (!IsPostBack)
            {
                cl.AddCalender(ref Imagecal, ref OrDate);
                this.OrDate.Attributes.Add("ReadOnly", "True");
                //Fnamet.Text = (string)Session["fullname"];

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }

                usecheck();
                ddfill();
                //sdate();
            }
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
        public void ddfill()
        {
            cl.ds = cl.DataFill("SELECT     orid, offname FROM JRofficer ORDER BY orid");
            JORDERDD.DataSource = cl.ds;
            JORDERDD.DataTextField = "offname";
            JORDERDD.DataValueField = "orid";
            JORDERDD.DataBind();
            JORDERDD.Items.Insert(0, new ListItem("--select--"));
        }
        public void usecheck()
        {

            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                //Uidt.Text = "%";
                Uidt.Text = (string)Session["iduser"];
            }
            else
            {
                Response.Redirect("~/Authenticate/login.aspx");

            }
        }


        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(TransOridd),0)+ 1 FROM TransOrderMaster");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TrNo.Text != "" && OrDate.Text != "")
            {
                TransOrderadd();
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please fill order No or order Date";
            }
        }

        public void TransOrderadd()
        {
            try
            {
                maxpic();
                if (JORDERDD.SelectedIndex != 0 && TrNo.Text != "")
                {
                    cl.upcon.Open();
                    SqlCommand cmd = new SqlCommand("NewTransOradd", cl.upcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TransOridd", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                    cmd.Parameters.Add("@TransOrbyid", SqlDbType.Int, 4).Value = JORDERDD.SelectedItem.Value;
                    //cmd.Parameters.Add("@TransOrdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DDD.SelectedItem.Text + "/" + DMM.SelectedItem.Text + "/" + DYYYY.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                    cmd.Parameters.Add("@TransOrdate", SqlDbType.DateTime, 8).Value = OrDate.Text;
                    i = tst.SQLInj_SL(this.TrNo.Text);
                    if (i == true)
                    {
                        cmd.Parameters.Add("@TransOrname", SqlDbType.VarChar, 200).Value = this.TrNo.Text;
                    }
                    else
                    {
                        return;

                    }
                    i = tst.SQLInj_SL(this.Retext.Text);
                    if (i == true)
                    {
                        cmd.Parameters.Add("@TrRemark", SqlDbType.VarChar, 200).Value = this.Retext.Text;
                    }
                    else
                    {
                        return;

                    }

                    cmd.Parameters.Add("@ipaddress", SqlDbType.VarChar, 200).Value = Request.ServerVariables["REMOTE_ADDR"];
                    cmd.Parameters.Add("@uid", SqlDbType.VarChar, 200).Value = Uidt.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Added Successfully";
                        TrNo.Text = "";
                        Retext.Text = "";
                    }
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
       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TransferSec/TRmenu.aspx");
        }
   
    }
}