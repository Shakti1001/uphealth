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
    public partial class namesearch : System.Web.UI.Page
    {
        string DDOUsermacth;
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                ddfill();
            }
        }
       
        //***********************For Alphabetical Order***********************

        public void runtablealpha()
        {
            usecheck();

            string q1, q2, q3, qr1;
            //***************DISTRICT****************(divid LIKE '" + Divs.Text + "')  
            if (this.Dcadre.SelectedIndex != 0)
            {
                q1 = Dcadre.SelectedItem.Value;
            }
            else { q1 = "cadre like '%'"; }
            //**************HOSPITAL NAME*****************
            if (this.Dfcadre.SelectedIndex != 0)
            {
                q2 = Dfcadre.SelectedItem.Value;
            }
            else { q2 = "fcadre like '%'"; }
            //*****************COMPUTER NO**************



            //***************FNAME****************
            if (this.name.Text != "")
            { q3 = "name like '%" + name.Text + "%'"; }
            else { q3 = "namename like '%'"; }
            qr1 = " And " + q1 + " And " + q2 + " And " + q3 + "";

            distsublbl.Text = "";


            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                if ((string)Session["pass"] == "RELRET")

                    
                {
                    cl.ds = cl.DataFill("SELECT DISTINCT IDNO,NAME,SENNO,CONVERt(nvarchar(12),dob,105) as dob,fathername,districtname,newpostname,postingstatus,lavel,sno from factsheetnew2 where exists (select * from factsheetnew2 group by sno having sno=max(sno)) and (name LIKE '" + name.Text + "%') and cadre='" + q1 + "' and fcadre='" + Convert.ToInt32(q2) + "' order by sno desc");
                }
                else if ((string)Session["pass"] == "Join")
                {
                    cl.ds = cl.DataFill("SELECT DISTINCT IDNO,NAME,SENNO,CONVERt(nvarchar(12),dob,105) as dob,fathername,districtname,newpostname,postingstatus,lavel,sno from factsheetnew2 where exists (select * from factsheetnew2 group by sno having sno=max(sno)) and (name LIKE '" + name.Text + "%') and cadre='" + q1 + "' and fcadre='" + Convert.ToInt32(q2) + "' order by sno desc");
                    //cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM factsheetsearchCriteria WHERE (name LIKE '" + VALT.Text + "')AND  (postingstatus = 'R')order by districtname, name");
                }
                else if ((string)Session["pass"] == "Trans")
                {
                    cl.ds = cl.DataFill("SELECT DISTINCT IDNO,NAME,SENNO,CONVERt(nvarchar(12),dob,105) as dob,fathername,districtname,newpostname,postingstatus,lavel,sno from factsheetnew2 where exists (select * from factsheetnew2 group by sno having sno=max(sno)) and (name LIKE '" + name.Text + "%') and cadre='" + q1 + "' and fcadre='" + Convert.ToInt32(q2) + "' order by sno desc");
                    //cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM factsheetsearchCriteria WHERE (name LIKE '" + VALT.Text + "')AND  (postingstatus = 'R')order by districtname, name");
                }
            }
            else
            {
                // changes on date june 10 2011
                //DDO and Userid match



                if ((string)Session["pass"] == "RELRET")
                {
                    cl.ds = cl.DataFill("SELECT DISTINCT IDNO,NAME,SENNO,CONVERt(nvarchar(12),dob,105) as dob,fathername,districtname,newpostname,postingstatus,lavel,sno from factsheetnew2 where exists (select * from factsheetnew2 group by sno having sno=max(sno)) and (name LIKE '" + name.Text + "%') and cadre='" + q1 + "' and fcadre='" + Convert.ToInt32(q2) + "' order by sno desc");
                }
                else if ((string)Session["pass"] == "Join")
                {
                    cl.ds = cl.DataFill("SELECT DISTINCT IDNO,NAME,SENNO,CONVERt(nvarchar(12),dob,105) as dob,fathername,districtname,newpostname,postingstatus,lavel,sno from factsheetnew2 where exists (select * from factsheetnew2 group by sno having sno=max(sno)) and (name LIKE '" + name.Text + "%') and cadre='" + q1 + "' and fcadre='" + Convert.ToInt32(q2) + "' order by sno desc");
                    //cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno,dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM factsheetsearchCriteria WHERE (name LIKE '" + VALT.Text + "')AND  (postingstatus = 'R') order by districtname, name ");//(DisId ='" + Uidt.Text + "') AND 
                }
                else if ((string)Session["pass"] == "Trans")
                {
                    cl.ds = cl.DataFill("SELECT DISTINCT IDNO,NAME,SENNO,CONVERt(nvarchar(12),dob,105) as dob,fathername,districtname,newpostname,postingstatus,lavel,sno from factsheetnew2 where exists (select * from factsheetnew2 group by sno having sno=max(sno)) and (name LIKE '" + name.Text + "%') and cadre='" + q1 + "' and fcadre='" + Convert.ToInt32(q2) + "' order by sno desc");
                    //cl.ds = cl.DataFill("SELECT DISTINCT idno,  name,senno,dob, fathername,  districtname, newpostname, postingstatus, cadresenno, lavel FROM factsheetsearchCriteria WHERE (name LIKE '" + VALT.Text + "')AND  (postingstatus = 'R') order by districtname, name ");//(DisId ='" + Uidt.Text + "') AND 
                }
            }
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.SlateGray;
                rw.BackColor = System.Drawing.Color.BurlyWood;
                rw.ForeColor = System.Drawing.Color.Maroon;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "ComputerID";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                // tcell1.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                //tcell2.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Seniority";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                //tcell3.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "DateofBirth";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                //tcell4.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Fathername";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                //tcell5.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Last Posting District";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                //tcell6.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Post";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                //tcell7.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell7);

                TableCell tcell8 = new TableCell();
                tcell8.Text = "Posting Status";
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                //tcell8.ForeColor = System.Drawing.Color.Gold;
                rw.Cells.Add(tcell8);

               
                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.Maroon;
                    rw1.BackColor = System.Drawing.Color.LemonChiffon;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);
                    //if ((string)Session["pass"] == "RELRET")
                    //{
                    //    tcellk4.Text = ("<a href=\'Relieve.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    //}
                    if ((string)Session["pass"] == "RELRET")
                    {
                        tcellk4.Text = ("<a href=\'URelieve.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    }
                    else if ((string)Session["pass"] == "Join")
                    {
                        tcellk4.Text = ("<a href=\'join.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    }
                    else if ((string)Session["pass"] == "Trans")
                    {
                        tcellk4.Text = ("<a href=\'join.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + (" (" + (tcellk4.Text + ")</a>")))));
                    }
                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk9 = new TableCell();
                    tcellk9.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcellk9.BorderWidth = 1;
                    tcellk9.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk9);

                    Table1.Rows.Add(rw1);

                }
            }
        }
        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
                DDOUsermacth = " ";
            }
            else
            {
                //// *************************************************
                //// Hospital allotted to user  (string)Session["iduser"] 
                if ((string)Session["UsDisId"] != null && (string)Session["iduser"] != null)
                {
                    Uidt.Text = (string)Session["UsDisId"];
                    DDOUsermacth = " and sno in (select sno from hospitalname where ddoid=" + (string)Session["iduser"] + ")";
                }
                else
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
            }
        }
        public void chkdsk()
        {
            usecheck();

        }

        public void ddfill()
        {//SELECT     divid, divname FROM         division ORDER BY divid
            // usecheckD();

            cl.ds = cl.DataFill("SELECT DISTINCT cadreid as cadre, cadrename FROM cadre ORDER BY cadrename");
            Dcadre.DataSource = cl.ds;
            Dcadre.DataTextField = "cadrename";
            Dcadre.DataValueField = "cadre";
            Dcadre.DataBind();
            Dcadre.Items.Insert(0, new ListItem("--select--"));

            cl.ds = cl.DataFill("SELECT distinct(fcadrename), fcadreid as fcadre FROM fcadre   ORDER BY fcadrename");
            Dfcadre.DataSource = cl.ds;
            Dfcadre.DataTextField = "fcadrename";
            Dfcadre.DataValueField = "fcadre";
            Dfcadre.DataBind();
            Dfcadre.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT DISTINCT name, id FROM alpha ORDER BY name");
            DHname.DataSource = cl.ds;
            DHname.DataTextField = "name";
            DHname.DataValueField = "id";
            DHname.DataBind();
            DHname.Items.Insert(0, new ListItem("--select--"));
            //****************

        }
        public void recount()
        {
            cl.ds = cl.DataFill("SELECT count(DISTINCT( idno))As  CTot  FROM  factsheetnew2 where name LIKE '%'AND DisId LIKE '" + Uidt.Text + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                strq.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
               strq.Text = "no Record Find";
            }
        }
        //****************************************************

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/JRmenu.aspx");
        }

        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DHname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                mess.Visible = false;
                runtablealpha();
            }
            catch (Exception ex)
            {
                //Response.Write(ex);
                mess.Visible = true;
                mess.Text = ex.Message;
                //mess.Text = "Sorry For error there is some technical Problem.. Please try after some time";
                //Response.Write("Sorry For error there is some technical Problem.. Please try after some time");
            }
            finally
            {
            }

        }
    }
}