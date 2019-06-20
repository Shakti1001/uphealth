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
    public partial class Editrel : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                data();
                dfill();

            }
        }
        public void dfill()
        {

            //**************** Join Order *************
            cl.ds = cl.DataFill("SELECT     orid, offname FROM JRofficer ORDER BY orid");
            JORDERDD.DataSource = cl.ds;
            JORDERDD.DataTextField = "offname";
            JORDERDD.DataValueField = "orid";
            JORDERDD.DataBind();
            JORDERDD.Items.Insert(0, new ListItem("--select--"));
        }
        public void data()
        {
            cl.ds = cl.DataFill("SELECT idno,orderby,orderno, Convert(varchar,orderdate,101) as orderdate,Convert(varchar,currentdate,101)as currentdate,orid,postsrid FROM  status_join_releive where statussr=" + Request.QueryString["statussr"] + "");//and currentdate='" + Convert.ToDateTime(Request.QueryString["curdate"]) + "'"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    this.idnoL.Text = cl.ds.Tables[0].Rows[0][0].ToString();

                }
                else
                {
                    this.idnoL.Text = "";
                }
                /////////////////////////////////////////
                if (!(cl.ds.Tables[0].Rows[0][5].ToString().Equals(System.DBNull.Value)))
                {
                    if (cl.ds.Tables[0].Rows[0][5].ToString() != "5")
                    {
                        JORDERDD.SelectedIndex = JORDERDD.Items.IndexOf(JORDERDD.Items.FindByValue(cl.ds.Tables[0].Rows[0][5].ToString()));
                    }
                    else
                    {
                        JORDERDD.SelectedIndex = 0;
                        if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                        {
                            orderbyt.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                            this.Orbyt.Text = cl.ds.Tables[0].Rows[0][1].ToString();

                        }
                        else
                        {
                            orderbyt.Text = "";
                            this.Orbyt.Text = "";
                        }
                    }

                }
                else
                {
                    JORDERDD.SelectedIndex = 0;
                    orderbyt.Text = "";
                    this.Orbyt.Text = "";
                }
                /////////////////////////////////////////
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    ordernot.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                    Ornot.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    ordernot.Text = "";
                    Ornot.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    orderdatet.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                    ORDText.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    orderdatet.Text = "";
                    ORDText.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    curdatet.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                    JRText.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    curdatet.Text = "";
                    JRText.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][6].ToString().Equals(System.DBNull.Value)))
                {
                    this.oid.Text = cl.ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    this.oid.Text = "";
                }

            }
            cl.ds = cl.DataFill("SELECT idno,name, newpostname,districtname,hname FROM factsheetsearchCriteria where idno=" + this.idnoL.Text + "");//"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    Relievename.Text = cl.ds.Tables[0].Rows[0][1].ToString();//Relievename//Joinname
                }
                else
                {
                    Relievename.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    Postt.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    Postt.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {

                    placet.Text = cl.ds.Tables[0].Rows[0][4].ToString() + "," + cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    placet.Text = "";
                }
                //////////////////////////////////////////
            }

        }
        public void relupdate()
        {
            cl.cmd = cl.InsertDB("update postingdetails set  dorelieve='" + Convert.ToDateTime(JRText.Text) + "' where idno=" + this.idnoL.Text + " and sno= " + Convert.ToInt32(oid.Text) + "");//doposting='" + Convert.ToDateTime((curdate.Text.Trim()) + "',Convert.ToDateTime(Dob.Text)
            cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "', modifieruserid='" + Uidt.Text + "',postingstatus='R' where idno=" + this.idnoL.Text + "");

        }
        

        public void ordersave()
        {
            try
            {
                pickid();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("joinrelieve", cl.upcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@statussr", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["statussr"]);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(this.idnoL.Text);
                cmd.Parameters.Add("@orderno", SqlDbType.NVarChar, 50).Value = Ornot.Text.Replace("\'", "\'\'").Trim();
                //cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime((ORDText.Text).Trim());
                cmd.Parameters.Add("@orderdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime((ORDText.Text).TrimEnd());
                cmd.Parameters.Add("@orid", SqlDbType.Int, 4).Value = JORDERDD.SelectedItem.Value;
                cmd.Parameters.Add("@orderby", SqlDbType.NVarChar, 50).Value = Orbyt.Text.Replace("\'", "\'\'").Trim();
                //cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime((JRText.Text.Trim()));
                cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(JRText.Text);
                cmd.Parameters.Add("@postingstatus", SqlDbType.VarChar, 2).Value = "R";
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Now;
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = Uidt.Text;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                //cmd.Parameters.Add("@postsrid", SqlDbType.Int, 4).Value = 0;
                cmd.Parameters.Add("@postsrid", SqlDbType.Int, 4).Value = Convert.ToInt32(this.oid.Text);//)
                cmd.Parameters.Add("@replacername", SqlDbType.VarChar, 100).Value = this.TextBox1.Text.Replace("\'", "\'\'").Trim();
                //postsrid
                if (cmd.ExecuteNonQuery() == 1)
                {
                    cl.upcon.Close();
                    this.mesg.Text = "The Given information have been saved if you want to Print click on print button";
                }
                else
                {
                    this.mesg.Text = "Error";
                }
            }
            catch (Exception ex)
            {
                this.mesg.Text = "Error In OrderSave :" + ex.Message;
            }
            finally
            {
                cl.upcon.Close();

            }
        }

        protected void BSAVE_Click(object sender, EventArgs e)
        {
            // cl.cmd = cl.InsertDB("update Ucreate set lastupdatedtime='" + System.DateTime.Now + "' where iduser='" + cl.ds.Tables[0].Rows[0][0].ToString() + "'");
            if ((string)Session["pass"] == "RELRET")
            {
                try { ordersave(); }
                catch (Exception ex) { this.mesg.Text = ("Error In ordersave :" + ex.Message); }
                try { relupdate(); }
                catch (Exception ex) { this.mesg.Text = ("Error In PostSave :" + ex.Message); }
                finally
                {
                    data();
                    dfill();

                }

            }
            else if ((string)Session["pass"] == "Join")
            {
                //try { ordersave(); }
                //catch (Exception ex) { this.mesg.Text = ("Error In ordersave :" + ex.Message); }
                //try { postsave(); }
                //catch (Exception ex) { this.mesg.Text = ("Error In PostSave :" + ex.Message); }
                //finally
                //{
                //    data();
                //    dfill();

                //}
            }
        }
        public void pickid()
        {
            //SELECT   postsrid FROM         status_join_releive where idno=7593 and   statussr=60
            cl.ds = cl.DataFill("SELECT   postsrid FROM         status_join_releive where idno='" + this.idnoL.Text + "'and statussr='" + Request.QueryString["statussr"] + "' ");
            this.oid.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }
        protected void PFsheet_Click(object sender, EventArgs e)
        {
            Response.Write(("<script language=javascript>window.open(\'RelOrdprint.aspx?oid=" + (Request.QueryString["statussr"] + (" &idno=" + (this.idnoL.Text + "\',\'new_Win\');</script>")))));
        }
        protected void JORDERDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JORDERDD.SelectedItem.Value == "5")
            {
                this.Orbyt.Visible = true;
            }
            else { this.Orbyt.Visible = false; }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/JRmenu.aspx");
        }
    }
}