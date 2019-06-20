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
    public partial class parap2qual : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
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
                cl.ds = cl.DataFill("SELECT gpfno,name FROM PMDpersonaldetails where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    this.sen.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    this.name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {

                }
                cl.ds = cl.DataFill("SELECT distinct(QuaName), QuaId FROM PMDQualification ORDER BY QuaName");
                DEG.DataSource = cl.ds;
                DEG.DataTextField = "QuaName";
                DEG.DataValueField = "QuaId";
                DEG.DataBind();
                DEG.Items.Insert(0, new ListItem("-sel-"));
                //****************
                cl.ds = cl.DataFill("SELECT distinct(spname), spid FROM  PMDspecialization ORDER BY spname");
                DES.DataSource = cl.ds;
                DES.DataTextField = "spname";
                DES.DataValueField = "spid";
                DES.DataBind();
                DES.Items.Insert(0, new ListItem("--select--"));
                //****************            
                GridView1.DataBind();
            }
        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(qid_serial),0)+ 1 FROM PMDqual_det");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }
        public void stfill()
        {
            try
            {
                maxpic();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("Qual", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@max", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@gpfno", SqlDbType.VarChar, 250).Value = sen.Text;
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["idno"]);
                cmd.Parameters.Add("@Qid", SqlDbType.Int, 4).Value = DEG.SelectedItem.Value;
                cmd.Parameters.Add("@Sid", SqlDbType.Int, 4).Value = DES.SelectedItem.Value;
                if (DEG.SelectedIndex != 0 && DES.SelectedIndex != 0)
                {

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Msg.Visible = true;
                        Msg.Text = "Qualification Updated";
                    }


                }
                else
                {
                    Msg.Visible = true;
                    Msg.Text = "Select the Correct One";
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
                GridView1.DataBind();

            }
        }
        public void pstfill()
        {

            try
            {
                maxpic();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into PMDqual_det(qid_serial,idno,gpfno,qid,sid)values(@max,@idno,@senno,@Qid,@Sid)", cl.upcon);
                cmd.Parameters.Add("@max", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["idno"]);
                cmd.Parameters.Add("@senno", SqlDbType.VarChar, 50).Value = sen.Text;
                cmd.Parameters.Add("@Qid", SqlDbType.Int, 4).Value = DEG.SelectedItem.Value;
                cmd.Parameters.Add("@Sid", SqlDbType.Int, 4).Value = DES.SelectedItem.Value;
                if (DEG.SelectedIndex != 0 && DES.SelectedIndex != 0)
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Msg.Visible = true;
                        Msg.Text = "Qualification Updated";
                    }
                }
                else
                {
                    Msg.Visible = true;
                    Msg.Text = "Select the Correct One";
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
                GridView1.DataBind();
            }
        }
       
        protected void save_Click(object sender, EventArgs e)
        {
            pstfill();
        }
        protected void DEG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DES_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2option.aspx");
        }
    }
}