using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;


namespace NewWebApp.Authenticate
{
    public partial class login : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        EncDec EncDec = new EncDec();
        SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                    Label2.Visible = false;
                    Label1.Text = GetIPAddress();
                    Session.RemoveAll();
                    Session.Abandon();
                    Response.Buffer = true;
                    Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                    Response.Expires = -1500;
                    Response.CacheControl = "no-cache";
                    showData();

            }


        }
        public void Red1(object sender, EventArgs e)
        {
            Response.Redirect("../Guest/doctor'sPosting.aspx");

        }
        public void Red2(object sender, EventArgs e)
        {
            Response.Redirect("../Guest/Proformachoice.aspx");

        }
       
        public void Red4(object sender, EventArgs e)
        {
            Response.Redirect("../Guest/P2Search.aspx");

        }
        
        public void Red6(object sender, EventArgs e)
        {
            Response.Redirect("../Guest/yearrepo.aspx");

        }
       public void showData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
            try
            {
                con.Open();
                string st = "select count(*) idno from personaldetails";
                string st1 = "select count(*) idno from pmdpersonaldetails";
                string st2="select count(*) sno from hospitalname";

                SqlCommand cmd = new SqlCommand(st, con);
                SqlCommand cmd1 = new SqlCommand(st1, con);
                SqlCommand cmd2 = new SqlCommand(st2, con);

                SqlDataReader sd = cmd.ExecuteReader();
                sd.Read();
                Doct.Text = sd["idno"].ToString();
                sd.Close();
                SqlDataReader sd1 = cmd1.ExecuteReader();
                sd1.Read();               
                Pmd.Text = sd1["idno"].ToString();
                sd1.Close();
                SqlDataReader sd2 = cmd2.ExecuteReader();
                sd2.Read();
                hsname.Text = sd2["sno"].ToString();
                sd2.Close();
                con.Close();
            }
            catch (SqlException se)
            {
                Console.Write(se);
            }
        }


        protected string GetIPAddress()
        {
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            return ipaddress;
        }




        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            TextBox1.Text = "";
            email.Text = "";
            pass_wd.Text = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (email.Text != "" && pass_wd.Text != "" && TextBox1.Text != "")
                {
                    bool i;
                    i = cl.check(email.Text.Replace("\'", "\'\'").Trim(), pass_wd.Text.Replace("'", "''"));
                    if (TextBox1.Text.ToLower() == Session["CaptchaVerify"].ToString() && i == true)
                    {
                        //cl.ds = cl.DataFill("SELECT iduser,username,lavel,DisId FROM Ucreate where userid= '" + Uname.Text.Replace("'", "''") + "' and upass='" + EncDec.EncryptRSA(Pname.Text.Replace("'", "''")) + "'");
                      string logstr = "SELECT Ucreate.iduser,Ucreate.username,  Ucreate.lavel, Ucreate.DisId ,userlavel.uhtype,Ucreate.ddoid FROM Ucreate INNER JOIN  userlavel ON Ucreate.lavel = userlavel.ulid  where Ucreate.userid='" + email.Text.Replace("'", "''") + "' and Ucreate.upass='" + EncDec.EncryptRSA(pass_wd.Text.Replace("'", "''")) + "'";
                       // string logstr = "SELECT Ucreate.iduser,Ucreate.username,  Ucreate.lavel, Ucreate.DisId ,userlavel.uhtype,Ucreate.ddoid FROM Ucreate INNER JOIN  userlavel ON Ucreate.lavel = userlavel.ulid  where Ucreate.userid='" + email.Text.Replace("'", "''") + "' and Ucreate.upass='" + EncDec.DecryptRSA(pass_wd.Text.Replace("'", "''")) + "'";
                        cl.ds = cl.DataFill(logstr);
                        if (cl.ds.Tables[0].Rows.Count > 0)
                        {
                            Session.Add("iduser", cl.ds.Tables[0].Rows[0]["iduser"].ToString());
                            Session.Add("fullname", cl.ds.Tables[0].Rows[0]["username"].ToString());
                            Session.Add("DisId", cl.ds.Tables[0].Rows[0]["DisId"].ToString());
                            Session.Add("lavel", cl.ds.Tables[0].Rows[0]["lavel"].ToString());
                            Session["name1"] = Session["fullname"];
                            //Request.UserHostAddress
                            int j;
                            j = Convert.ToInt32(cl.ds.Tables[0].Rows[0]["lavel"].ToString());
                            if (j == 1 || j == 2)
                            {
                                this.Label2.Text = "";
                                cl.cmd = cl.InsertDB("update Ucreate set hostipaddress='" + Request.ServerVariables["REMOTE_ADDR"] + "' where iduser='" + cl.ds.Tables[0].Rows[0]["iduser"].ToString() + "'");
                                Response.Write("<script>alert('You are redirecting to the Admin Page...');</script>");
                                Server.Transfer("~/Administrator/home.aspx");
                            }
                            else
                            {
                                Session.Add("UsDisId", cl.ds.Tables[0].Rows[0]["DisId"].ToString());
                                Session.Add("UsHtype", cl.ds.Tables[0].Rows[0]["uhtype"].ToString());
                                Session.Add("ddoid", cl.ds.Tables[0].Rows[0]["DDOID"].ToString());
                                this.Label2.Text = "";
                                cl.cmd = cl.InsertDB("update Ucreate set hostipaddress='" + Request.ServerVariables["REMOTE_ADDR"] + "' where iduser='" + cl.ds.Tables[0].Rows[0]["iduser"].ToString() + "'");
                                Response.Write("<script>alert('You are redirecting to the User Page...');</script>");
                                Server.Transfer("~/Administrator/Uhome.aspx");
                            }

                        }
                        else
                        {

                            Label2.Text = "Invalid Login ";
                            this.Label2.Text = "Your Password has been Changed, For New Password Contact 9415759680 Or 9935278473 !";
                            this.Label2.Text = "";
                        }
                        cl.ds.Clear();
                        cl.ds.Dispose();

                    }
                    else
                    {
                        this.Label2.Text = "Your Password has been Changed, For New Password Contact 9415759680 Or 9935278473 !";
                        this.Label2.Text = "";
                        Label2.Text = "Invalid Login";
                    }
                }

            }
            catch (SqlException se)
            {
                Console.WriteLine(se);
            }
            finally
                {
                    con.Close();
                }

        }
    }
}
