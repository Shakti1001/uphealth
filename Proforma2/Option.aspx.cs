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

namespace NewWebApp.Proforma2
{
    public partial class Option : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                usecheck();
            }

        }

        private void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                this.Trans.Visible = true;
            }
            else
            {
                this.Trans.Visible = false;
            }
        }
        


        protected void Addpers_Click(object sender, EventArgs e)
        {
            bool i;
            i = cl.checkA(Uidt.Text);
            if (i == true)
            {
                bool j;
                j = cl.checklavel(Uidt.Text);
                if (j == true)
                {
                    Response.Redirect("~/Proforma2/Prof1.aspx");
                }
                else
                {
                    //Response.Redirect("~/Proforma2/Prof1.aspx");
                    Response.Redirect("~/Proforma2/Alert.aspx");
                }
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
                    Response.Redirect("~/Proforma2/Editpersonalrecord.aspx");
                }
                else
                {
                    Ename.Text = "EPR";
                    Session.Add("EDIT", Ename.Text);
                    //Response.Redirect("~/Proforma2/Editrecorduser.aspx");
                    Response.Redirect("~/Proforma2/Alert.aspx");
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
                    Response.Redirect("~/Proforma2/Editpersonalrecord.aspx");
                }
                else
                {
                    Ename.Text = "EQ";
                    Session.Add("EDIT", Ename.Text);
                    //Response.Redirect("~/Proforma2/Editrecorduser.aspx");
                    Response.Redirect("~/Proforma2/Alert.aspx");
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
                    Response.Redirect("~/Proforma2/Editpersonalrecord.aspx");
                }
                else
                {
                    Ename.Text = "EPOST";
                    Session.Add("EDIT", Ename.Text);
                    //Response.Redirect("~/Proforma2/Editrecorduser.aspx");
                    Response.Redirect("~/Proforma2/Alert.aspx");
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
                    Response.Redirect("~/Proforma2/Editpersonalrecord.aspx");
                }
                else
                {
                    Ename.Text = "EEQN";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/Proforma2/Editrecorduser.aspx");
                    //Response.Redirect("~/Proforma2/Alert.aspx");
                }
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }


        protected void Rsec_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/Proforma2/RepOption.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

        protected void Trans_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkR(Uidt.Text);
            if (j == true)
            {
                Response.Redirect("~/TransferSec/TRmenu.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        //protected void TRNG_Click1(object sender, EventArgs e)
        //{

        //    bool j;
        //    j = cl.checkE(Uidt.Text);
        //    if (j == true)
        //    {
        //        bool i;
        //        i = cl.checklavel(Uidt.Text);
        //        if (i == true)
        //        {
        //            Ename.Text = "TRNG";
        //            Session.Add("EDIT", Ename.Text);
        //            Response.Redirect("~/Proforma2/Editpersonalrecord.aspx");
        //        }
        //        else
        //        {

        //            mess.Text = "Access Denied Please Contact to Administrator";
        //            //Ename.Text = "trng";
        //           // Session.Add("EDIT", Ename.Text);
        //            //Response.Redirect("~/Proforma2/Editrecorduser.aspx");
        //            //Response.Redirect("~/Proforma2/Alert.aspx");
        //        }
        //    }
        //    else
        //    {
        //        mess.Text = "Access Denied Please Contact to Administrator";
        //    }
        //}






        //protected void TRNG_Click(object sender, EventArgs e)
        //{
        //    bool j;
        //    j = cl.checkE(Uidt.Text);
        //    if (j == true)
        //    {
        //        bool i;
        //        i = cl.checklavel(Uidt.Text);
        //        if (i == true)
        //        {
        //            Ename.Text = "TRNG";
        //            Session.Add("EDIT", Ename.Text);
        //            Response.Redirect("~/Proforma2/Editpersonalrecord.aspx");
        //        }
        //        else
        //        {
        //            Ename.Text = "TRNG";
        //            Session.Add("EDIT", Ename.Text);
        //            Response.Redirect("~/Proforma2/Editrecorduser.aspx");
        //            //Response.Redirect("~/Proforma2/Alert.aspx");
        //        }
        //    }
        //    else
        //    {
        //        mess.Text = "Access Denied Please Contact to Administrator";
        //    }
        //}



        protected void JR_Click(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkE(Uidt.Text);
            if (j == true)
            {
                bool i;
                i = cl.checklavel(Uidt.Text);
                if (i == true)
                {
                    Response.Redirect("~/Proforma2/JRmenu.aspx");
                }
                else
                {
                    if ((string)Session["UsDisId"] != null && (string)Session["ddoid"] != null)
                    {
                        Response.Redirect("~/Proforma2/JRmenu.aspx");
                    }
                    else
                    {
                        mess.Text = "Relogin Again";
                    }
                }
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
            //bool i;
            //i = cl.checkR(Uidt.Text);
            //if (i == true)
            //{
            //    Response.Redirect("~/Proforma2/Joinandrelieve/JRmenu.aspx");
            //}
            //else
            //{
            //    mess.Text = "Access Denied Please Contact to Administrator";
            //}

        }
        protected void TRNG_Click1(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkE(Uidt.Text);
            if (j == true)
            {
                bool i;
                i = cl.checklavel(Uidt.Text);
                if (i == true)
                {
                    Ename.Text = "TRNG";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/Proforma2/Editpersonalrecord.aspx");
                    //Response.Redirect("~/Proforma2/training/trnew.aspx");
                }
                else
                {
                    Ename.Text = "TRNG";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/Proforma2/Editrecorduser.aspx");
                    //Response.Redirect("~/Proforma2/Alert.aspx");
                }
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void ACR_Click1(object sender, EventArgs e)
        {
            bool j;
            j = cl.checkE(Uidt.Text);
            if (j == true)
            {
                bool i;
                i = cl.checklavel(Uidt.Text);
                if (i == true)
                {
                    Ename.Text = "ACR";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/Proforma2/Editpersonalrecord.aspx");
                    //Response.Redirect("~/Proforma2/training/trnew.aspx");
                }
                else
                {
                    Ename.Text = "ACR";
                    Session.Add("EDIT", Ename.Text);
                    Response.Redirect("~/Proforma2/Editrecorduser.aspx");
                    //Response.Redirect("~/Proforma2/Alert.aspx");
                }
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }
        protected void lnkApprove_Click(object sender, EventArgs e)
        {
            if ((string)Session["lavel"] == "5")
            {
                Response.Redirect("~/Proforma2/ApproveEdit.aspx");
            }
            else
            {
                mess.Text = "Access Denied Please Contact to Administrator";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/LoginHome.aspx");
        }
    }
}