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
    public partial class Dyn : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                ddfill();

            }
        }

        public void ddfill()
        {
            //****************
            cl.ds = cl.DataFill("SELECT name FROM sysobjects WHERE (type = 'U') ORDER BY name");
            DropDownList1.DataSource = cl.ds;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "name";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--select--"));
            //**************** 
        }
        public void qr()
        {

            //1 gy in division having post not equal gy and deg equal gy
            //2 gy in division having post not equal gy and deg equal gy  or 
            //////////////////////////////////////
            //All tables/views from database--------
            //sp_tables
            //////////////////////////////////////

            //to know everything about a table-------
            //sp_help MyTableName    
            //sp_msforeachtable "sp_help '?'"
            ////////////////////////////////////

            //to know total table and there records--------------
            //sp_msforeachtable "select '?' TableName, count(*) as TotalRecords from ?"
            ///////////////////////////////////

            //to find out specific table name---------
            //select * from sysobjects where name like ‘P%’
            ////////////////////////////////////////

            //to find out specific rowcount in a table----------
            //select rowcnt from sysindexes where name in (select name from sysobjects where parent_obj in(select id from sysobjects where name = 'Table_Name'))
            ///////////////////////////////////

            //procedure to find out a tables columns no-------------------

            //create Procedure Prc_GetColumnCount
            // @TableName varchar(20)
            //as
            //  Begin
            //    Select Count(Name) from Syscolumns Where id = (Select id from SysObjects Where name = @TableName) End

            //   Prc_GetColumnCount 'TableName'
            //////////////////////////////////

            //procedure to find out a tables columns name-------------------
            //create Procedure Prc_GetColumnname
            //@TableName varchar(20)
            //as
            //Begin
            //Select name from Syscolumns
            //Where
            //id =
            //(Select id from SysObjects Where name = @TableName)
            //End
            //   Prc_Prc_GetColumnname 'TableName'
            ////////////////////////////////

            //tables from database--------- 
            //SELECT     TOP 100 PERCENT name FROM         dbo.sysobjects WHERE     (xtype = 'U')  ORDER BY name
            //////////////////////////////////////

            //to find out database table with no of columns--------
            //SELECT TOP 100 PERCENT WITH TIES c.TABLE_NAME , COUNT(*) NumColumns FROM INFORMATION_SCHEMA.[COLUMNS ] c inner join INFORMATION_SCHEMA.[TABLES] t ON C.TABLE_SCHEMA = t.TABLE_SCHEMA and c.TABLE_NAME = T.TABLE_NAME GROUP BY c.TABLE_NAME ORDER BY c.TABLE_NAME 
            /////////////////////////////////
            //describe a table---------------
            //SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'table name'
            ////////////////////////////////

            //        SELECT     dbo.currentposted.idno, dbo.personaldetails.name, dbo.personaldetails.dob, dbo.hospitaldistrict.districtname, dbo.post.newpostname, 
            //                      dbo.Qualification.QuaName, dbo.specialization.spname
            //FROM         dbo.currentposted INNER JOIN
            //                      dbo.personaldetails ON dbo.currentposted.idno = dbo.personaldetails.idno INNER JOIN
            //                      dbo.post ON dbo.currentposted.postid = dbo.post.newpostid INNER JOIN
            //                      dbo.qual_det ON dbo.personaldetails.idno = dbo.qual_det.idno INNER JOIN
            //                      dbo.Qualification ON dbo.qual_det.qid = dbo.Qualification.QuaId INNER JOIN
            //                      dbo.specialization ON dbo.qual_det.sid = dbo.specialization.spid INNER JOIN
            //                      dbo.hospitaldistrict ON dbo.currentposted.districtid = dbo.hospitaldistrict.districtid




        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cl.ds = cl.DataFill("SELECT * FROM " + this.DropDownList1.SelectedItem.Text + "");
            DropDownList2.DataSource = cl.ds;
            this.DropDownList2.DataTextField = cl.ds.Tables[0].Rows[0][1].ToString();
            DropDownList2.DataValueField = cl.ds.Tables[0].Rows[0][0].ToString();
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("--select--"));
            //**************** 
        }
        public void valandtext()
        {
            if (Dfield.SelectedItem.Value == "1")
            {
                Text1.Visible = true;
                Dval.Visible = false;
            }
            if (Dfield.SelectedItem.Value == "2")
            {
                Text1.Visible = true;
                Dval.Visible = false;
            }
            if (Dfield.SelectedItem.Value == "3")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                Dval.Items.Clear();
                //'*******POST NAME***********
                cl.ds = cl.DataFill("SELECT newpostname, newpostid  FROM  post ORDER BY newpostname");
                Dval.DataSource = cl.ds;
                //Dval.DataTextField = cl.ds.Tables[0].Rows[0][0].ToString();
                //Dval.DataValueField = cl.ds.Tables[0].Rows[0][1].ToString();
                Dval.DataTextField = "newpostname";
                Dval.DataValueField = "newpostid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));

            }
            if (Dfield.SelectedItem.Value == "4")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                Dval.Items.Clear();
                //'*******posting District***********            
                cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "districtname";
                Dval.DataValueField = "districtid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Dfield.SelectedItem.Value == "5")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                Dval.Items.Clear();
                //'*******Posting Palce**********SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname ORDER BY hospitalname.hname
                cl.ds = cl.DataFill("SELECT DISTINCT hname, sno, districtid  FROM         hospitalname  WHERE     (districtid <> 0) ORDER BY districtid, hname");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "hname";
                Dval.DataValueField = "sno";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Dfield.SelectedItem.Value == "6")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                Dval.Items.Clear();
                //'*******Home District*********** 
                cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "districtname";
                Dval.DataValueField = "districtid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Dfield.SelectedItem.Value == "7")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                Dval.Items.Clear();
                //'*******Qualification*********** 
                cl.ds = cl.DataFill("SELECT distinct(QuaName), QuaId FROM Qualification ORDER BY QuaName");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "QuaName";
                Dval.DataValueField = "QuaId";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Dfield.SelectedItem.Value == "8")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                Dval.Items.Clear();
                //'*******specialization*********** 
                cl.ds = cl.DataFill("SELECT distinct(spname), spid FROM  specialization ORDER BY spname");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "spname";
                Dval.DataValueField = "spid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Dfield.SelectedItem.Value == "9")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                Dval.Items.Clear();
                //'*******Cadre*********** 
                cl.ds = cl.DataFill("SELECT  cadrename, cadreid FROM cadre ORDER BY cadrename");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "cadrename";
                Dval.DataValueField = "cadreid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
        }
        protected void Dfield_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                valandtext();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        public void listtext()
        {
            if (Selfield.SelectedItem.Value == "1")
            {
                Text1.Visible = true;
                Dval.Visible = false;
            }
            if (Selfield.SelectedItem.Value == "2")
            {
                Text1.Visible = true;
                Dval.Visible = false;
            }
            if (Selfield.SelectedItem.Value == "3")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                //'*******POST NAME***********
                cl.ds = cl.DataFill("SELECT newpostname, newpostid  FROM  post ORDER BY newpostname");
                Dval.DataSource = cl.ds;
                //Dval.DataTextField = cl.ds.Tables[0].Rows[0][0].ToString();
                //Dval.DataValueField = cl.ds.Tables[0].Rows[0][1].ToString();
                Dval.DataTextField = "newpostname";
                Dval.DataValueField = "newpostid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));

            }
            if (Selfield.SelectedItem.Value == "4")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                //'*******posting District***********            
                cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "districtname";
                Dval.DataValueField = "districtid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Selfield.SelectedItem.Value == "5")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                //'*******Posting Palce**********SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname ORDER BY hospitalname.hname
                cl.ds = cl.DataFill("SELECT DISTINCT hname, sno, districtid  FROM         hospitalname  WHERE     (districtid <> 0) ORDER BY districtid, hname");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "hname";
                Dval.DataValueField = "sno";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Selfield.SelectedItem.Value == "6")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                //'*******Home District*********** 
                cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "districtname";
                Dval.DataValueField = "districtid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Selfield.SelectedItem.Value == "7")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                //'*******Qualification*********** 
                cl.ds = cl.DataFill("SELECT distinct(QuaName), QuaId FROM Qualification ORDER BY QuaName");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "QuaName";
                Dval.DataValueField = "QuaId";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Selfield.SelectedItem.Value == "8")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                //'*******specialization*********** 
                cl.ds = cl.DataFill("SELECT distinct(spname), spid FROM  specialization ORDER BY spname");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "spname";
                Dval.DataValueField = "spid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Selfield.SelectedItem.Value == "9")
            {
                Text1.Visible = false;
                Dval.Visible = true;
                //'*******Cadre*********** 
                cl.ds = cl.DataFill("SELECT  cadrename, cadreid FROM cadre ORDER BY cadrename");
                Dval.DataSource = cl.ds;
                Dval.DataTextField = "cadrename";
                Dval.DataValueField = "cadreid";
                Dval.DataBind();
                Dval.Items.Insert(0, new ListItem("--select--"));
            }
            if (Selfield.SelectedItem.Value == "10")
            {
                Text1.Visible = true;
                Dval.Visible = false;
            }
        }
        protected void Selfield_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Text1.Text = "";
                Dval.Items.Clear();
                listtext();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public void view()
        {
            //        SELECT DISTINCT 
            //                      TOP 100 PERCENT dbo.personaldetails.idno, dbo.personaldetails.senno, dbo.personaldetails.name AS name, dbo.personaldetails.fathername, 
            //                      CONVERT(Char, dbo.personaldetails.dob, 106) AS DateofBirth, dbo.hospitaldistrict.districtname AS PostingDistrict, 
            //                      dbo.post.newpostname AS Postname, dbo.personaldetails.lavel, dbo.hospitaldistrict.divid, dbo.cadre.cadrename AS Cadre, dbo.cadre.cadreid, 
            //                      dbo.hospitalname.hname AS PostingPlace, dbo.hospitalname.sno, dbo.currentposted.doposting, dbo.currentposted.dorelieve, 
            //                      dbo.currentposted.Desigid, dbo.currentposted.postid, dbo.Qualification.QuaName AS Qualification, dbo.specialization.spname AS Specialization, 
            //                      dbo.homedistrict.hdistname AS Homedistrict
            //FROM         dbo.cadre INNER JOIN
            //                      dbo.personaldetails INNER JOIN
            //                      dbo.currentposted ON dbo.personaldetails.idno = dbo.currentposted.idno INNER JOIN
            //                      dbo.post ON dbo.currentposted.postid = dbo.post.newpostid ON dbo.cadre.cadreid = dbo.personaldetails.cadre INNER JOIN
            //                      dbo.hospitaldistrict ON dbo.currentposted.districtid = dbo.hospitaldistrict.districtid INNER JOIN
            //                      dbo.hospitalname ON dbo.currentposted.poposting = dbo.hospitalname.sno INNER JOIN
            //                      dbo.qual_det ON dbo.personaldetails.idno = dbo.qual_det.idno INNER JOIN
            //                      dbo.Qualification ON dbo.qual_det.qid = dbo.Qualification.QuaId INNER JOIN
            //                      dbo.specialization ON dbo.qual_det.sid = dbo.specialization.spid INNER JOIN
            //                      dbo.homedistrict ON dbo.personaldetails.homedistrictid = dbo.homedistrict.hdistid
            //ORDER BY dbo.personaldetails.name
        }
        public void setvallike()
        {
            //*********************name*****************q1 = "hid Like '%" + Request.QueryString["DT"] + "%'";
            if (Selfield.SelectedItem.Text == "name" && Text1.Text != "" && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "name like '%" + Text1.Text + "%'";
            }//*********************DateofBirth*****************
            if (Selfield.SelectedItem.Text == "DateofBirth" && Text1.Text != "" && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "DateofBirth like '%" + Text1.Text + "%'";
            }//*********************postname*****************
            if (Selfield.SelectedItem.Text == "Postname" && Dval.SelectedIndex != 0 && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "Postname like '%" + Dval.SelectedItem.Text + "%'";
            }//*********************postingdistrict*****************
            if (Selfield.SelectedItem.Text == "PostingDistrict" && Dval.SelectedIndex != 0 && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "PostingDistrict like '%" + Dval.SelectedItem.Text + "%'";
            }//*********************postingplace*****************
            if (Selfield.SelectedItem.Text == "PostingPlace" && Dval.SelectedIndex != 0 && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "PostingPlace like '%" + Dval.SelectedItem.Text + "%'";
            }//*********************HomeDistrict*****************
            if (Selfield.SelectedItem.Text == "Homedistrict" && Dval.SelectedIndex != 0 && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "Homedistrict like '%" + Dval.SelectedItem.Text + "%'";
            }//*********************Qualification*****************
            if (Selfield.SelectedItem.Text == "Qualification" && Dval.SelectedIndex != 0 && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "Qualification like '%" + Dval.SelectedItem.Text + "%'";
            }//*********************Specialization*****************
            if (Selfield.SelectedItem.Text == "Specialization" && Dval.SelectedIndex != 0 && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "Specialization like '%" + Dval.SelectedItem.Text + "%'";
            }//*********************Cadre*****************
            if (Selfield.SelectedItem.Text == "Cadre" && Dval.SelectedIndex != 0 && Doprat.SelectedItem.Text == "like")
            {
                StringLabel.Text = "Cadre like '%" + Dval.SelectedItem.Text + "%'";
            }
        }
        public void setval()
        {
            //select name, DateofBirth, Postname,PostingDistrict, PostingPlace,Homedistrict,Qualification,Specialization,Cadre
            //*********************name*****************
            if (Selfield.SelectedItem.Text == "name" && Text1.Text != "" && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "name" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Text1.Text + "'";
            }//*********************DateofBirth*****************
            if (Selfield.SelectedItem.Text == "DateofBirth" && Text1.Text != "" && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "DateofBirth" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Text1.Text + "'";
            }//*********************postname*****************
            if (Selfield.SelectedItem.Text == "Postname" && Dval.SelectedIndex != 0 && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "Postname" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Dval.SelectedItem.Text + "'";
            }//*********************postingdistrict*****************
            if (Selfield.SelectedItem.Text == "PostingDistrict" && Dval.SelectedIndex != 0 && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "PostingDistrict" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Dval.SelectedItem.Text + "'";
            }//*********************postingplace*****************
            if (Selfield.SelectedItem.Text == "PostingPlace" && Dval.SelectedIndex != 0 && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "PostingPlace" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Dval.SelectedItem.Text + "'";
            }//*********************HomeDistrict*****************
            if (Selfield.SelectedItem.Text == "Homedistrict" && Dval.SelectedIndex != 0 && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "Homedistrict" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Dval.SelectedItem.Text + "'" + "AND";
            }//*********************Qualification*****************
            if (Selfield.SelectedItem.Text == "Qualification" && Dval.SelectedIndex != 0 && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "Qualification" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Dval.SelectedItem.Text + "'";
            }//*********************Specialization*****************
            if (Selfield.SelectedItem.Text == "Specialization" && Dval.SelectedIndex != 0 && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "Specialization" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Dval.SelectedItem.Text + "'";
            }//*********************Cadre*****************
            if (Selfield.SelectedItem.Text == "Cadre" && Dval.SelectedIndex != 0 && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "Cadre" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Dval.SelectedItem.Text + "'";
            }
            //*********************dateofjoining*****************
            if (Selfield.SelectedItem.Text == "DateofJoining" && Text1.Text != "" && Doprat.SelectedIndex != 0)
            {
                StringLabel.Text = "dojoining" + "" + "" + Doprat.SelectedItem.Text + "" + "" + "'" + Text1.Text + "'";
            }//*********************DateofBirth*****************
        }
        protected void stringList_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringText.Text = StringText.Text + " " + stringList.SelectedItem.Text;
            this.stringList.Items.Remove(stringList.SelectedItem);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.stringList.Items.Clear();
        }
       
        protected void Select_Click(object sender, EventArgs e)
        {
            StringLabel.Text = "";
            try
            {
                if (Doprat.SelectedIndex != 0 && Doprat.SelectedItem.Text != "like")
                {
                    setval();
                }
                else if (Doprat.SelectedIndex != 0 && Doprat.SelectedItem.Text == "like")
                {
                    setvallike();
                }
            }
            catch (Exception ex)
            {
                errmess.Text = ex.Message;
                errmess.Text = "please check selection";
            }
            if (StringLabel.Text != "")
            {
                this.stringList.Items.Add(StringLabel.Text);
            }
        }
        protected void open_Click(object sender, EventArgs e)
        {
            if (count.Text == "0")
            {
                StringText.Text = "(";
                count.Text = "1";
            }
            else
            {
                StringText.Text = StringText.Text + "(";
            }

        }
        protected void ButtAnd_Click(object sender, EventArgs e)
        {
            StringText.Text = StringText.Text + "AND";
        }
        protected void ButtOR_Click(object sender, EventArgs e)
        {
            StringText.Text = StringText.Text + "OR";
        }
        protected void Bclose_Click(object sender, EventArgs e)
        {
            StringText.Text = StringText.Text + ")";
        }
        protected void BRef_Click(object sender, EventArgs e)
        {
            StringText.Text = "";
        }
        protected void BCheckCri_Click(object sender, EventArgs e)
        {

            try
            {
                errmess.Text = "";
                BViewR.Enabled = true;
                errmess.Visible = true;
                reccount();
                //StringText.Enabled = false;

            }
            catch (Exception ex)
            {
                errmess.Visible = true;
                errmess.Text = ex.Message;
                //
            }
        }
        protected void BViewR_Click(object sender, EventArgs e)
        {

            //errmess.Text = "";
            Session.Add("NOR", errmess.Text);
            Session.Add("criteria", StringText.Text);
            Response.Redirect("DRepPrint.aspx");
            //try
            //{
            //    //runtabold();
            //    runtab();
            //}
            //catch (Exception ex)
            //{
            //    errmess.Visible = true;
            //    errmess.Text = ex.Message;
            //    //
            //}

            //Response.Redirect("DRepPrint.aspx?criteria=" + (StringText.Text + (" &NOR=" + (errmess.Text + "");
            //Response.Write(("<script language=javascript>window.open(\'DRepPrint.aspx?criteria=" + (StringText.Text + (" &NOR=" + (errmess.Text + "\',\'new_Win\');</script>")))));
            //Response.Write(("<script language=javascript>window.open(\'DRepPrint.aspx'new_Win\');</script>"));
            //Server.Transfer();
        }
        public void runtab()
        {

            string qrf = "SELECT     idno,senno,name, DateofBirth, Postname, PostingDistrict, PostingPlace, Homedistrict, Qualification, Specialization, Cadre FROM  dynamicQ WHERE " + StringText.Text + "order by name,PostingDistrict";
            cl.ds = cl.DataFill(qrf);
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                errmess.Visible = false;
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.ForeColor = System.Drawing.Color.Black;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "Name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcellS = new TableCell();
                tcellS.Text = "Sen No";
                tcellS.BorderWidth = 1;
                tcellS.BorderColor = System.Drawing.Color.SlateGray;
                tcellS.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcellS);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "DateofBirth";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Postname";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "PostingDistrict";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "PostingPlace";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Homedistrict";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "ComputerID";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell7);
                TableCell tcell8 = new TableCell();
                tcell8.Text = "Qualification";//
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                tcell8.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell8);
                TableCell tcell9c = new TableCell();
                tcell9c.Text = "Specialization";//
                tcell9c.BorderWidth = 1;
                tcell9c.BorderColor = System.Drawing.Color.SlateGray;
                tcell9c.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell9c);
                TableCell tcell9q = new TableCell();
                tcell9q.Text = "Cadre";//
                tcell9q.BorderWidth = 1;
                tcell9q.BorderColor = System.Drawing.Color.SlateGray;
                tcell9q.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell9q);
                Table1.Rows.Add(rw);

                //for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {

                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.SlateGray;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);
                    //tcellk1.Text = Convert.ToString(TextBox1.Text);
                    rw1.Cells.Add(tcellk1);

                    if (cl.ds.Tables[0].Rows[j + 1][0].ToString() != cl.ds.Tables[0].Rows[j][0].ToString())
                    {
                        TableCell tcellk6 = new TableCell();
                        tcellk6.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                        tcellk6.BorderWidth = 1;
                        tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk6);

                        TableCell tcellkS = new TableCell();
                        tcellkS.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                        tcellkS.BorderWidth = 1;
                        tcellkS.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellkS);

                        TableCell tcellk7 = new TableCell();
                        tcellk7.BorderWidth = 1;
                        tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                        tcellk7.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                        rw1.Cells.Add(tcellk7);

                        TableCell tcellk8 = new TableCell();
                        tcellk8.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                        tcellk8.BorderWidth = 1;
                        tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk8);

                        TableCell tcellk2 = new TableCell();
                        tcellk2.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                        tcellk2.BorderWidth = 1;
                        tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk2);

                        TableCell tcellk4 = new TableCell();
                        tcellk4.BorderWidth = 1;
                        tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                        tcellk4.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                        rw1.Cells.Add(tcellk4);


                        TableCell tcellk3 = new TableCell();
                        tcellk3.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                        tcellk3.BorderWidth = 1;
                        tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk3);

                        TableCell tcellk5 = new TableCell();
                        tcellk5.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                        tcellk5.BorderWidth = 1;
                        tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk5);
                        tcellk5.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk5.Text + "</a>")));

                        TableCell tcellk3q = new TableCell();
                        tcellk3q.Text = cl.ds.Tables[0].Rows[j][8].ToString();
                        tcellk3q.BorderWidth = 1;
                        tcellk3q.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk3q);

                        TableCell tcellk3w = new TableCell();
                        tcellk3w.Text = cl.ds.Tables[0].Rows[j][9].ToString();
                        tcellk3w.BorderWidth = 1;
                        tcellk3w.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk3w);

                        TableCell tcellk3e = new TableCell();
                        tcellk3e.Text = cl.ds.Tables[0].Rows[j][10].ToString();
                        tcellk3e.BorderWidth = 1;
                        tcellk3e.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk3e);
                    }
                    Table1.Rows.Add(rw1);
                    //l = Convert.ToInt32(TextBox1.Text) + 1;
                }
            }
            else
            {
                errmess.Visible = true;
                errmess.Text = "Sorry,No Record Found";
            }
        }
        public void reccount()
        {
            string qrf = "SELECT count(distinct(idno)) as No FROM  dynamicQ WHERE " + StringText.Text + " ";
            cl.ds = cl.DataFill(qrf);
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                errmess.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                errmess.Text = "There is Some Problem in selection.... ";
            }

        }
        public void runtabold()
        {
            string qrf = "SELECT     idno,name, DateofBirth, Postname, PostingDistrict, PostingPlace, Homedistrict, Qualification, Specialization, Cadre  FROM  dynamicQ WHERE " + StringText.Text + "order by name,PostingDistrict";
            cl.ds = cl.DataFill(qrf);
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                errmess.Visible = false;
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.ForeColor = System.Drawing.Color.Black;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "DateofBirth";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Postname";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "PostingDistrict";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "PostingPlace";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Homedistrict";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "ComputerID";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell7);
                TableCell tcell8 = new TableCell();
                tcell8.Text = "Qualification";//
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                tcell8.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell8);
                TableCell tcell9c = new TableCell();
                tcell9c.Text = "Specialization";//
                tcell9c.BorderWidth = 1;
                tcell9c.BorderColor = System.Drawing.Color.SlateGray;
                tcell9c.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell9c);
                TableCell tcell9q = new TableCell();
                tcell9q.Text = "Cadre";//
                tcell9q.BorderWidth = 1;
                tcell9q.BorderColor = System.Drawing.Color.SlateGray;
                tcell9q.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell9q);
                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.SlateGray;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk4);


                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);
                    tcellk5.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk5.Text + "</a>")));

                    TableCell tcellk3q = new TableCell();
                    tcellk3q.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcellk3q.BorderWidth = 1;
                    tcellk3q.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3q);

                    TableCell tcellk3w = new TableCell();
                    tcellk3w.Text = cl.ds.Tables[0].Rows[j][8].ToString();
                    tcellk3w.BorderWidth = 1;
                    tcellk3w.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3w);

                    TableCell tcellk3e = new TableCell();
                    tcellk3e.Text = cl.ds.Tables[0].Rows[j][9].ToString();
                    tcellk3e.BorderWidth = 1;
                    tcellk3e.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3e);
                    Table1.Rows.Add(rw1);
                }

            }
            else
            {
                errmess.Visible = true;
                errmess.Text = "Sorry,No Record Found";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/RepOption.aspx");
        }
    }
}