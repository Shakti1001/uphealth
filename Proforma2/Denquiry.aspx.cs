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

namespace NewWebApp.Proforma2
{
    public partial class Denquiry : System.Web.UI.Page
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
                    Response.Redirect("~/Administrator/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                cl.ds = cl.DataFill("SELECT senno,name FROM personaldetails where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    this.sen.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    this.name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {

                }
            }

        }
        protected void DET_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DES.SelectedItem.Text != "Imposed Panishment")
            {
                //Eqr.Enabled = false;
                //Comp.Enabled = false;
                EResult.Enabled = false;
                EResult.Text = "";

            }
            else
            {

                //Eqr.Enabled = true;
                //Comp.Enabled = true;
                EResult.Enabled = true;
            }

        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(enqid),0)+ 1 FROM Enquiry");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        protected void SAVE_Click(object sender, EventArgs e)
        {
            //        1	enqid	int	4	0
            //0	idno	int	4	1
            //0	enqtype	nvarchar	100	1
            //0	enqstatus	nvarchar	100	1
            //0	enqresult	nvarchar	100	1

            try
            {
                maxpic();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into Enquiry(enqid,idno,enqtype,enqstatus,enqresult)values(@enqid,@idno,@enqtype,@enqstatus,@enqresult)", cl.upcon);
                cmd.Parameters.Add("@enqid", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text); ;//
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["idno"]);
                cmd.Parameters.Add("@enqtype", SqlDbType.VarChar, 100).Value = DET.SelectedItem.Text;
                cmd.Parameters.Add("@enqstatus", SqlDbType.VarChar, 100).Value = DES.SelectedItem.Value;
                cmd.Parameters.Add("@enqresult", SqlDbType.VarChar, 100).Value = EResult.Text;//,@enqofficer,@enqresult
                //err.Visible = true;
                if (cmd.ExecuteNonQuery() == 1)
                    Response.Write("");
                else
                    Response.Write("no Enquiry selected");

            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();
                //clear();
                EResult.Text = "";
                GridView1.DataBind();
                cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "',hostipaddress='" + Request.ServerVariables["REMOTE_ADDR"] + "',modifieruserid='" + (string)Session["iduser"] + "' where idno='" + Request.QueryString["idno"] + "'");

            }
            GridView1.DataBind();
        }
        public void clear()
        {  //function used for clearing text box
            foreach (Control c in ((HtmlForm)Page.FindControl("form1")).Controls)
            {
                if (c is System.Web.UI.WebControls.TextBox)
                {
                    TextBox tb = ((TextBox)c);
                    tb.Text = "";
                }
            }

        }


        protected void FSheet_Click(object sender, EventArgs e)
        {
            //Response.Redirect("proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");
            Server.Transfer("proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");
        }
        
       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/Option.aspx");
        }
    }
}