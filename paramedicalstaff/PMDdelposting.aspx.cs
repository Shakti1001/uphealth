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
using System.Globalization;
using System.Threading;

namespace NewWebApp.paramedicalstaff
{
    public partial class PMDdelposting : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                Response.Expires = -1500;
                Response.CacheControl = "no-cache";
                contid();
                delpost();
            }
        }
        public void contid()
        {
            cl.ds = cl.DataFill("Select idno From PMDpostingdetails Where sno='" + Request.QueryString["sno"] + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    this.Label1.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    cl.cmd = cl.InsertDB("update PMDpersonaldetails set lastupdatedtime='" + System.DateTime.Now + "',hostipaddress='" + Request.ServerVariables["REMOTE_ADDR"] + "',modifieruserid='" + (string)Session["iduser"] + "' where idno='" + this.Label1.Text + "'");
                }
            }
        }
        public void delpost()
        {

            cl.cmd = cl.InsertDB("Delete from PMDpostingdetails where sno='" + Request.QueryString["sno"] + "'");
            Response.Redirect("parap2Posting.aspx?idno=" + this.Label1.Text + "");
            //Response.Redirect("posting.aspx");
        }
    }
}