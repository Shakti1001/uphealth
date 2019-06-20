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

namespace NewWebApp.Administrator
{
    public partial class updateJR : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Otext.Text != "")
                {
                    cl.cmd = cl.InsertDB("update personaldetails set postingstatus='J' where idno='" + Otext.Text + "'");
                    this.Label1.Text = "Data updated";
                    Otext.Text = "";
                }
                else
                {
                    this.Label1.Text = "Technical Problem";
                    Otext.Text = "";
                }
            }
            catch (Exception ex) { Response.Write(ex); }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Otext.Text != "")
                {
                    cl.cmd = cl.InsertDB("update personaldetails set postingstatus='R',hostipaddress='"+Request.ServerVariables["REMOTE_ADDR"]+"' where idno='" + Otext.Text + "'");
                    this.Label1.Text = "Data updated";
                    Otext.Text = "";
                }
                else
                {
                    this.Label1.Text = "Technical Problem";
                    Otext.Text = "";
                }
            }
            catch (Exception ex) { Response.Write(ex); }
        }
       

        protected void Bk_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Administrator/Ad1.aspx");
        }
    }
}