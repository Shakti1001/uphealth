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

namespace NewWebApp.pmdpayrole
{
    public partial class ChangeUpass : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        EncDec EncDec = new EncDec();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null || (string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                this.Fnamet.Text = (string)Session["fullname"];
                this.Uidt.Text = (string)Session["iduser"];
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Ntext.Text != "" && Otext.Text != "")
            {

                if (Ntext.Text.Length <= 10)
                {
                    string oldpwd = Otext.Text;
                    cl.ds = cl.DataFill("select upass from Ucreate where iduser='" + Uidt.Text + "'");
                    string pwd = cl.ds.Tables[0].Rows[0][0].ToString();
                    string opwd = EncDec.DecryptRSA(pwd);
                    if (Otext.Text != opwd)
                    {
                        this.mess.Visible = true;
                        this.mess.Text = "Your old Password is not Correct";
                    }
                    else
                    {
                        cl.cmd = cl.InsertDB("update Ucreate set upass='" + EncDec.EncryptRSA(Ntext.Text) + "', lastupdatedtime='" + System.DateTime.Now + "' where iduser='" + Uidt.Text + "'");
                        this.Otext.Text = "";
                        this.Ntext.Text = "";
                        this.mess.Visible = true;
                        this.mess.Text = "Password has been changed Successfully";
                    }
                }
                else
                {
                    this.mess.Visible = true;
                    this.mess.Text = "Maximum Password length should be 10 Characters";
                }
            }
            else
            {
                this.mess.Visible = true;
                this.mess.Text = "Please Fill Both given Old Password And Your  New Password ";
            }
        }
    }
}