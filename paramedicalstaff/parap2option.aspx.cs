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


namespace NewWebApp.paramedicalstaff
{
    public partial class parap2option : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
            }

        }

       


        protected void Addpers_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkA(Uidt.Text);
            if (i == true)
            {
                //Response.Redirect("~/paramedicalstaff/Alert.aspx");

                Response.Redirect("~/paramedicalstaff/parap2.aspx");//~/paramedicalstaff/p2/parap2.aspx
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void Editpers_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkE(Uidt.Text);
            if (j == true)
            {
                bool i;
                i = cl.checklavel(Uidt.Text);
                if (i == true)
                {
                    Ename.Text = "EPR";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/paramedicalstaff/parap2opradmin.aspx");//~/paramedicalstaff/p2/parap2opradmin.aspx
                }
                else
                {
                    Ename.Text = "EPR";
                    Session.Add("EDIT", Ename.Text);//~/paramedicalstaff/p2/parap2opr.aspx
                    Response.Redirect("~/paramedicalstaff/parap2opr.aspx");
                    //Response.Redirect("~/paramedicalstaff/Alert.aspx");



                }
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }

        }
        protected void EditQ_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkE(Uidt.Text);
            if (j == true)
            {
                bool i;
                i = cl.checklavel(Uidt.Text);
                if (i == true)
                {
                    Ename.Text = "EQ";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/paramedicalstaff/parap2opradmin.aspx");
                }
                else
                {
                    Ename.Text = "EQ";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/paramedicalstaff/parap2opr.aspx");


                    //Response.Redirect("~/paramedicalstaff/Alert.aspx");

                }
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void EditPost_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkE(Uidt.Text);
            if (j == true)
            {
                bool i;
                i = cl.checklavel(Uidt.Text);
                if (i == true)
                {
                    Ename.Text = "EPOST";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/paramedicalstaff/parap2opradmin.aspx");
                }
                else
                {
                    Ename.Text = "EPOST";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/paramedicalstaff/parap2opr.aspx");
                    //Response.Redirect("~/paramedicalstaff/Alert.aspx");

                }
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void EditEQN_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkE(Uidt.Text);
            if (j == true)
            {
                bool i;
                i = cl.checklavel(Uidt.Text);
                if (i == true)
                {
                    Ename.Text = "EEQN";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/paramedicalstaff/parap2opradmin.aspx");
                }
                else
                {
                    Ename.Text = "EEQN";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/paramedicalstaff/parap2opr.aspx");
                    //Response.Redirect("~/paramedicalstaff/Alert.aspx");

                }
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        //JANDR
        protected void Rsec_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/paramedicalstaff/parap2ReportOption.aspx");
                //Response.Redirect("~/paramedicalstaff/Alert.aspx");

            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void JANDR_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkE(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/paramedicalstaff/parap2JRmenu.aspx");
                //Response.Redirect("~/paramedicalstaff/Alert.aspx");

            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parahome.aspx");
        }
    }
}