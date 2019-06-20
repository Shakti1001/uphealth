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
    public partial class Editrecorduser : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                Ename.Text = (string)Session["Edit"];
                Uidt.Text = (string)Session["iduser"];
                //cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE     (iduser ='" + Uidt.Text + "')");
                //if (cl.ds.Tables[0].Rows.Count > 0)
                //{
                //    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                //}
                if ((string)Session["UsDisId"] != null && (string)Session["ddoid"] != null)
                {
                    Uidt.Text = (string)Session["UsDisId"];
                    //gethtype();
                    distsublbl.Text = " and poposting in (select sno from hospitalname where ddoid=" + (string)Session["ddoid"] + ")";
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }

            }
        }
        //private void gethtype()
        //{
        //    if ((string)Session["UsHtype"] == "0")
        //    {
        //        this.distsublbl.Text = " in (select sno from hospitalname where htype not in (1,2,3,21)) ";
        //    }
        //    else if ((string)Session["UsHtype"] == "1")
        //    {
        //        this.distsublbl.Text = " in (select sno from hospitalname where htype  in (1)) ";

        //    }
        //    else if ((string)Session["UsHtype"] == "2")
        //    {
        //        this.distsublbl.Text = " in (select sno from hospitalname where htype  in (2)) ";

        //    }
        //    else if ((string)Session["UsHtype"] == "3")
        //    {
        //        this.distsublbl.Text = " in (select sno from hospitalname where htype  in (3)) ";

        //    }
        //    else if ((string)Session["UsHtype"] == "21")
        //    {
        //        this.distsublbl.Text = " in (select sno from hospitalname where htype  in (21)) ";

        //    }
        //}


        public void chkdsk()
        {
            if (Ename.Text == "EPR")
            {
                Fnamet.Text = "Personal Details";
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                GridView1.DataBind();
            }
            else if (Ename.Text == "EPOST")
            {
                Fnamet.Text = "Posting Details";
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
                Panel4.Visible = false;
                GridView3.DataBind();
            }
            else if (Ename.Text == "EQ")
            {
                Fnamet.Text = "Qualification Details";
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                Panel4.Visible = false;
                GridView2.DataBind();
            }
            else if (Ename.Text == "EEQN")
            {
                Fnamet.Text = "Enquiry Details";
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = true;
                GridView4.DataBind();
            }
            else if (Ename.Text == "TRNG")
            {
                Fnamet.Text = "Training  Details";
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = true;
                Panel6.Visible = false;
                Panel7.Visible = false;

                GridView5.DataBind();
            }
            else if (Ename.Text == "ACR")
            {
                Fnamet.Text = "ACR Dairy ";
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = true;
                Panel7.Visible = false;

                GridView6.DataBind();
            }

            else if (Ename.Text == "ACRView")
            {
                Fnamet.Text = "ACR Dairy ";
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = true;
                GridView7.DataBind();
            }

        }
       
        protected void A_Click(object sender, EventArgs e)
        {
            VALT.Text = "A%";
            chkdsk();

        }

        protected void B_Click(object sender, EventArgs e)
        {
            VALT.Text = "b%";
            chkdsk();

        }
        protected void C_Click(object sender, EventArgs e)
        {
            VALT.Text = "c%";
            chkdsk();

        }
        protected void D_Click(object sender, EventArgs e)
        {
            VALT.Text = "d%";
            chkdsk();

        }
        protected void E_Click(object sender, EventArgs e)
        {
            VALT.Text = "e%";
            chkdsk();

        }
        protected void F_Click(object sender, EventArgs e)
        {
            VALT.Text = "f%";
            chkdsk();

        }
        protected void G_Click(object sender, EventArgs e)
        {
            VALT.Text = "g%";
            chkdsk();

        }
        protected void H_Click(object sender, EventArgs e)
        {
            VALT.Text = "h%";
            chkdsk();

        }
        protected void I_Click(object sender, EventArgs e)
        {
            VALT.Text = "i%";
            chkdsk();

        }
        protected void J_Click(object sender, EventArgs e)
        {
            VALT.Text = "j%";
            chkdsk();

        }
        protected void K_Click(object sender, EventArgs e)
        {
            VALT.Text = "k%";
            chkdsk();

        }
        protected void L_Click(object sender, EventArgs e)
        {
            VALT.Text = "l%";
            chkdsk();

        }
        protected void M_Click(object sender, EventArgs e)
        {
            VALT.Text = "m%";
            chkdsk();

        }
        protected void N_Click(object sender, EventArgs e)
        {
            VALT.Text = "n%";
            chkdsk();

        }
        protected void O_Click(object sender, EventArgs e)
        {
            VALT.Text = "o%";
            chkdsk();

        }
        protected void P_Click(object sender, EventArgs e)
        {
            VALT.Text = "p%";
            chkdsk();

        }
        protected void Q_Click(object sender, EventArgs e)
        {
            VALT.Text = "q%";
            chkdsk();

        }
        protected void R_Click(object sender, EventArgs e)
        {
            VALT.Text = "r%";
            chkdsk();

        }
        protected void S_Click(object sender, EventArgs e)
        {
            VALT.Text = "s%";
            chkdsk();

        }
        protected void T_Click(object sender, EventArgs e)
        {
            VALT.Text = "t%";
            chkdsk();

        }
        protected void U_Click(object sender, EventArgs e)
        {
            VALT.Text = "u%";
            chkdsk();

        }

        protected void V_Click(object sender, EventArgs e)
        {
            VALT.Text = "v%";
            chkdsk();

        }
        protected void W_Click(object sender, EventArgs e)
        {
            VALT.Text = "w%";
            chkdsk();

        }
        protected void X_Click(object sender, EventArgs e)
        {
            VALT.Text = "x%";
            chkdsk();

        }
        protected void Y_Click(object sender, EventArgs e)
        {
            VALT.Text = "y%";
            chkdsk();

        }
        protected void Z_Click(object sender, EventArgs e)
        {
            VALT.Text = "z%";
            chkdsk();

        }
        protected void VALT_TextChanged(object sender, EventArgs e)
        {
            VALT.Text = VALT.Text + "" + "%";
            chkdsk();
            VALT.Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            VALT.Visible = true;

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/Option.aspx");
        }
    }
}