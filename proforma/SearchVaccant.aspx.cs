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

namespace NewWebApp.proforma
{
    public partial class SearchVaccant : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q2, q3, q4, q5, q6;
        //SqlConnection upcon = new SqlConnection(ClDatabase.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddfill();
                usecheck();
                count.Text = "0";
            }
        }
        public void ddfill()
        {
            cl.ds = cl.DataFill("SELECT DISTINCT divname, divid FROM  division ORDER BY divname");
            DDiv.DataSource = cl.ds;
            DDiv.DataTextField = "divname";
            DDiv.DataValueField = "divid";
            DDiv.DataBind();
            DDiv.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname ORDER BY hospitalname.hname");
            DHname.DataSource = cl.ds;
            DHname.DataTextField = "hname";
            DHname.DataValueField = "sno";
            DHname.DataBind();
            DHname.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT     htype, hid FROM         hospitaltype ORDER BY htype");
            DHtype.DataSource = cl.ds;
            DHtype.DataTextField = "htype";
            DHtype.DataValueField = "hid";
            DHtype.DataBind();
            DHtype.Items.Insert(0, new ListItem("--select--"));
            //***************************
            cl.ds = cl.DataFill("SELECT     newpostname, newpostid FROM         post ORDER BY newpostname");
            Dpost.DataSource = cl.ds;
            Dpost.DataTextField = "newpostname";
            Dpost.DataValueField = "newpostid";
            Dpost.DataBind();
            Dpost.Items.Insert(0, new ListItem("--select--"));
        }
        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                //Uidt.Text = "%";
            }
            else
            {
                this.DDiv.Enabled = false;
                this.DDistrict.Enabled = false;
                cl.ds = cl.DataFill("SELECT isnull(DisId,0) FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    DDistrict.SelectedIndex = DDistrict.Items.IndexOf(DDistrict.Items.FindByValue(cl.ds.Tables[0].Rows[0][0].ToString()));
                    cl.ds1 = cl.DataFill2("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname where districtid = '" + DDistrict.SelectedItem.Value + "' ORDER BY hospitalname.hname");
                    DHname.DataSource = cl.ds1;
                    DHname.DataTextField = "hname";
                    DHname.DataValueField = "sno";
                    DHname.DataBind();
                    DHname.Items.Insert(0, new ListItem("--select--"));
                    //Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();

                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDiv.SelectedIndex != 0)
            {
                try
                {

                    cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where divid='" + DDiv.SelectedItem.Value + "' ORDER BY districtname");
                    DDistrict.DataSource = cl.ds;
                    DDistrict.DataTextField = "districtname";
                    DDistrict.DataValueField = "districtid";
                    DDistrict.DataBind();
                    DDistrict.Items.Insert(0, new ListItem("--select--"));
                    clik.Text = "";
                }
                catch (Exception ex)
                {

                    clik.Text = ex.Message;
                    clik.Text = "Select Properly";

                }
            }



            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(hospitaldistrict.divid = '" + DDiv.SelectedItem.Value + "')";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(hospitaldistrict.divid = '" + DDiv.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";

        }
        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DDistrict.SelectedIndex != 0)
            {
                try
                {

                    cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname where districtid = '" + DDistrict.SelectedItem.Value + "' ORDER BY hospitalname.hname");
                    DHname.DataSource = cl.ds;
                    DHname.DataTextField = "hname";
                    DHname.DataValueField = "sno";
                    DHname.DataBind();
                    DHname.Items.Insert(0, new ListItem("--select--"));
                    clik.Text = "";
                }
                catch (Exception ex)
                {
                    //Response.Write(ex.Message);
                    clik.Text = ex.Message;
                    clik.Text = "Select Properly";
                    //Response.Write("");
                }
            }
            //****************
            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(hospitaldistrict.districtid = '" + DDistrict.SelectedItem.Value + "') ";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(hospitaldistrict.districtid = '" + DDistrict.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";
        }
        protected void DHname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(hospitaldistrict.districtid = '" + DDistrict.SelectedItem.Value + "') ";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(hospitaldistrict.districtid = '" + DDistrict.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";
        }
        protected void DHtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDistrict.SelectedIndex != 0 && DHtype.SelectedIndex != 0)
            {
                cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname where districtid = '" + DDistrict.SelectedItem.Value + "'and  htype='" + DHtype.SelectedItem.Value + "' ORDER BY hospitalname.hname");
                DHname.DataSource = cl.ds;
                DHname.DataTextField = "hname";
                DHname.DataValueField = "sno";
                DHname.DataBind();
                DHname.Items.Insert(0, new ListItem("--select--"));
            }

            //cl.ds = cl.DataFill("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname where districtid = '" + DDistrict.SelectedItem.Value + "'and htype= '" + DHtype.SelectedItem.Value + "' ORDER BY hospitalname.hname");
            //DHname.DataSource = cl.ds;
            //DHname.DataTextField = "hname";
            //DHname.DataValueField = "sno";
            //DHname.DataBind();
            //DHname.Items.Insert(0, new ListItem("--select--"));
            ////****************
            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(personaldetails.cadreid = '" + DHtype.SelectedItem.Value + "') ";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(personaldetails.cadreid = '" + DHtype.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";
        }
        protected void Dpost_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clik.Text = "0";
            //if (count.Text == "0")
            //{
            //    strq.Text = strq.Text + "(currentpost.Dcode = '" + Dpost.SelectedItem.Value + "') ";
            //}
            //else if (count.Text == "1")
            //{
            //    strq.Text = strq.Text + "AND" + "(currentpost.Dcode = '" + Dpost.SelectedItem.Value + "') ";
            //}
            //count.Text = "1";
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            //string sno, divid, districtid, hid,post;
            ////***************DIVISION****************
            //if (this.DDiv.SelectedIndex != 0)
            //{divid = "%" + DDiv.SelectedItem.Value + "%"; }
            //else { divid = "%"; }
            //Session.Add("divid", divid);
            ////***************DISTRICT****************
            //if (this.DDistrict.SelectedIndex != 0)
            //{ districtid = "%" + DDistrict.SelectedItem.Value + "%"; }
            //else { districtid = "%"; }
            //Session.Add("districtid", districtid);
            ////***************Hospital Type****************
            //if (this.DHtype.SelectedIndex != 0)
            //{ hid = "%" + DHtype.SelectedItem.Value + "%"; }
            //else { hid = "%"; }
            //Session.Add("hid", hid);
            ////**************HOSPITAL NAME*****************
            //if (this.DHname.SelectedIndex != 0)
            //{ sno = "%" + DHname.SelectedItem.Value + "%"; }
            //else { sno = "%"; }
            //Session.Add("sno", sno);
            ////****************POST***************
            //if (this.Dpost.SelectedIndex != 0)
            //{ post = "%" + Dpost.SelectedItem.Text + "%"; }
            //else { post = "%"; }
            //Session.Add("post", post);      
            //Response.Redirect("Vaccantstatus.aspx");
            RND();
            Session.Add("post", q5);
            string qr = "Where " + q1 + " AND " + q2 + " AND " + q3 + " AND " + q4 + "";
            Session.Add("zr", qr);
            Response.Redirect("Cpostdetail.aspx");
        }
        public void RND()
        {
            if (this.DDiv.SelectedIndex != 0)
            {
                if (DDiv.SelectedItem.Value.Length == 1)
                {
                    q1 = "divid =" + DDiv.SelectedItem.Value + "";
                }
                else
                    q1 = "divid like '%" + DDiv.SelectedItem.Value + "%'";
            }
            else
            {
                q1 = "divid like '%'";
            }
            //***************DISTRICT****************
            if (this.DDistrict.SelectedIndex != 0)
            {
                if (DDistrict.SelectedItem.Value.Length == 1)
                {
                    q2 = "districtid =" + DDistrict.SelectedItem.Value + "";
                }
                else
                    q2 = "districtid like '%" + DDistrict.SelectedItem.Value + "%'";
            }
            else
            {
                q2 = "districtid like '%'";
            }
            //***************Hospital Type****************
            if (this.DHtype.SelectedIndex != 0)
            {
                if (DHtype.SelectedItem.Value.Length == 1)
                {
                    q3 = "hid =" + DHtype.SelectedItem.Value + "";
                }
                else
                    q3 = "hid like '%" + DHtype.SelectedItem.Value + "%'";
            }
            else
            {
                q3 = "hid like '%'";
            }
            //**************HOSPITAL NAME*****************
            if (this.DHname.SelectedIndex != 0)
            {
                if (DHname.SelectedItem.Value.Length == 1)
                {
                    q4 = "sno =" + DHname.SelectedItem.Value + "";
                }
                else
                    q4 = "sno like '%" + DHname.SelectedItem.Value + "%'";
            }
            else
            {
                q4 = "sno like '%'";
            }
            //****************POST***************
            //if (this.Dpost.SelectedIndex != 0)
            //{
            //    if (Dpost.SelectedItem.Value.Length == 1)
            //    {
            //        q5 = "'" + Dpost.SelectedItem.Value + "'";
            //    }
            //    else
            //        q5 = "'%" + Dpost.SelectedItem.Value + "%'";
            //}
            //else
            //{
            //    q5 ="%";
            //}
            //****************POST***************
            if (this.Dpost.SelectedIndex != 0)
            {
                if (Dpost.SelectedItem.Value.Length == 1)
                {
                    q5 = Dpost.SelectedItem.Text;
                }
                else
                    q5 = Dpost.SelectedItem.Text;
            }
            else
            {
                q5 = "MO";
            }
            //Session.Add("post", q5);
            //string qr ="Where " + q1 + " AND " + q2 + " AND " + q3 + " AND " + q4 +"";
            //Session.Add("zr", qr);
            //Response.Redirect("Cpostdetail.aspx");
            //Response.Redirect("Cpostdetail.aspx?qr=" + qr + "&q5=" + q6 + "");
            //Server.Transfer("Vaccantstatus.aspx?qrsr=" + qrsr  );
            //SELECT divname, districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM hospitallist where divid like @divid and districtid like @districtid and hid like @hid and sno like @sno
            //SELECT post.newpostname, hospitalrecord.posts, hospitalrecord.withcadre, hospitalrecord.withoutcadre, hospitalrecord.Extrapost, hospitalrecord.posts - hospitalrecord.withcadre - hospitalrecord.Extrapost AS vacantpost, post.newpostid FROM hospitalrecord INNER JOIN post ON hospitalrecord.postid = post.newpostid INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno WHERE (hospitalname.sno = @sno)and (post.newpostname like @post)

            //string qr = q6 + "AND " + Uidt.Text + "AND " + q1 + "AND " + q2 + "AND " + q3 + "AND " + q5 + "AND " + q4 + "";
            /////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////

            ////***************DIVISION****************
            //if (this.DDiv.SelectedIndex != 0)
            //{ divid ="'"+"%"+DDiv.SelectedItem.Value+"%"+"'"; }
            //else { divid ="'"+"%"+"'"; }
            ////***************DISTRICT****************
            //if (this.DDistrict.SelectedIndex != 0)
            //{ districtid ="'"+"%"+DDistrict.SelectedItem.Value+"%"+"'"; }
            //else { districtid ="'"+"%"+"'"; }
            ////***************Hospital Type****************
            //if (this.DHtype.SelectedIndex != 0)
            //{ hid ="'"+"%"+DHtype.SelectedItem.Value+"%"+"'"; }
            //else { hid ="'"+"%"+"'"; }
            ////**************HOSPITAL NAME*****************
            //if (this.DHname.SelectedIndex != 0)
            //{ sno ="'"+"%"+DHname.SelectedItem.Value+"%"+"'"; }
            //else { sno ="'"+"%"+"'"; }
            ////****************POST***************
            //if (this.Dpost.SelectedIndex != 0)
            //{ post ="'"+"%"+Dpost.SelectedItem.Value+"%"+"'"; }
            //else { post ="'"+"%"+"'"; }

            //Label1.Text = Session["rollno"] + "," + Session["streamcd"] + "," + Session["regno"] + "NOW" + Request.QueryString["rollno"] + "," + Request.QueryString["regno"] + "," + Request.QueryString["streamcd"];
            //Server.Transfer("choiceposition.aspx?streamcd=" + Session["streamcd"].ToString() + "&rollno=" + Session["rollno"].ToString() + "&regno=" + Session["regno"].ToString());



            //Response.Write(("<script language=javascript>window.open(\'Vaccantstatus.aspx?divid=" + (divid + (" &districtid=" + (districtid + "\',\'new_Win\');</script>")))));
            //Response.Write(("<script language=javascript>window.open(\'Vaccantstatus.aspx?divid=" + (divid + (" &districtid=" + (districtid + (" &hid=" + (hid + (" &sno=" + (sno + "\',\'new_Win\');</script>")))))))));
            //Response.Write(("<script language=javascript>window.open(\'Vaccantstatus.aspx?divid=" + (divid + ("&districtid=" + (districtid + ("&hid=" + (hid + ("&sno=" + (sno + "\',\'new_Win\');</script>")))))))));
            //Response.Write(("<script language=javascript>window.open(\'Vaccantstatus.aspx?divid=" + (divid + ("&districtid=" + (districtid + ("&hid=" + (hid + ("&sno=" + (sno + "\',\'new_Win\');</script>")))))))));

            //Server.Transfer("Vaccantstatus.aspx?divid=" + divid + "&districtid=" + districtid + "&hid=" + hid +"&sno=" + sno );
            //string qrsr = "like"+divid+"and districtid like"+districtid+" and hid like"+hid +" and sno like "+sno+"";
            //Response.Redirect("Vaccantstatus.aspx?divid=" + Session["divid"].ToString() + "&districtid=" + Session["districtid"].ToString() + "&hid=" + Session["hid"].ToString() + "&sno=" + Session["sno"].ToString());

            // Server.Transfer("Vaccantstatus.aspx?divid=" + divid + "&districtid=" + districtid + "&hid=" + hid + "&sno=" + sno,true);
            //Response.Write(("<script language=javascript>window.open(\'Vaccantstatus.aspx?divid=" + ("+divid+" + ("&districtid=" + ("+districtid+" + ("&hid=" + ("+hid+" + ("&sno=" + ("+sno+" + "\',\'new_Win\');</script>")))))))));
            //string qrsr = " where divid like'" + divid + "'and districtid like'" + districtid + "' and hid like'" + hid + "' and sno like '" + sno + "'";
            //Response.Write(("<script language=javascript>window.open(\'Vaccantstatus.aspx?qrsr=" + qrsr + "\',\'new_Win\');</script>"));
            //Response.Redirect("Vaccantstatus.aspx?qrsr=" + qrsr + "");
            //Server.Transfer("Vaccantstatus.aspx?qrsr=" + qrsr  );
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (this.Dpost.SelectedIndex != 0)
            {
                if (Dpost.SelectedItem.Value.Length == 1)
                {
                    q5 = Dpost.SelectedItem.Text;
                }
                else
                    q5 = Dpost.SelectedItem.Text;
            }
            else
            {
                q5 = "NONE";
            }
            Session.Add("post", q5);
            Response.Redirect("postwisevacancy.aspx");
        }

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/proforma/HRephome.aspx");
        }
    }
}