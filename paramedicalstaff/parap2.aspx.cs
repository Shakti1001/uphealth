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


namespace NewWebApp.paramedicalstaff
{
    public partial class parap2 : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        public void msg(string msg)
        {
            string sMsg = msg.Replace("\n", "\\n");
            sMsg = msg.Replace("\"", "'");
            Response.Write(@"<script language='javascript'>");
            Response.Write(@"alert( """ + sMsg + @""" );");
            Response.Write(@"</script>");
        }
        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(idno),0)+ 1 FROM PMDpersonaldetails");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void sdate()
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                DB1.Items.Add("" + Convert.ToString(i) + "");
                DA1.Items.Add("" + Convert.ToString(i) + "");
                DJ1.Items.Add("" + Convert.ToString(i) + "");
                DC1.Items.Add("" + Convert.ToString(i) + "");
            }
            DB1.Items.Insert(0, new ListItem("0"));
            DA1.Items.Insert(0, new ListItem("0"));
            DJ1.Items.Insert(0, new ListItem("0"));
            DC1.Items.Insert(0, new ListItem("0"));
            for (i = 1; i <= 12; i++)
            {
                DB2.Items.Add("" + Convert.ToString(i) + "");
                DA2.Items.Add("" + Convert.ToString(i) + "");
                DJ2.Items.Add("" + Convert.ToString(i) + "");
                DC2.Items.Add("" + Convert.ToString(i) + "");
            }
            DB2.Items.Insert(0, new ListItem("0"));
            DA2.Items.Insert(0, new ListItem("0"));
            DJ2.Items.Insert(0, new ListItem("0"));
            DC2.Items.Insert(0, new ListItem("0"));
            //for (i = 1940; i <= 2040; i++)
            for (i = 2030; i >= 1940; i--)
            {
                DB3.Items.Add("" + Convert.ToString(i) + "");
                DA3.Items.Add("" + Convert.ToString(i) + "");
                DJ3.Items.Add("" + Convert.ToString(i) + "");
                DC3.Items.Add("" + Convert.ToString(i) + "");
            }
            DB3.Items.Insert(0, new ListItem("0"));
            DA3.Items.Insert(0, new ListItem("0"));
            DJ3.Items.Insert(0, new ListItem("0"));
            DC3.Items.Insert(0, new ListItem("0"));

        }
        public void dfill()
        {
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
            DhomeD.DataSource = cl.ds;
            DhomeD.DataTextField = "districtname";
            DhomeD.DataValueField = "districtid";
            DhomeD.DataBind();
            DhomeD.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict ORDER BY districtname");
            pDhomeD.DataSource = cl.ds;
            pDhomeD.DataTextField = "districtname";
            pDhomeD.DataValueField = "districtid";
            pDhomeD.DataBind();
            pDhomeD.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT distinct(QuaName), QuaId FROM PMDQualification ORDER BY QuaName");
            Dmqual.DataSource = cl.ds;
            Dmqual.DataTextField = "QuaName";
            Dmqual.DataValueField = "QuaId";
            Dmqual.DataBind();
            Dmqual.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT distinct(spname), spid FROM   PMDspecialization ORDER BY spname");
            Dmsub.DataSource = cl.ds;
            Dmsub.DataTextField = "spname";
            Dmsub.DataValueField = "spid";
            Dmsub.DataBind();
            Dmsub.Items.Insert(0, new ListItem("--select--"));
            //****************//SELECT     cadrename, cadreid  FROM         PMDCadre ORDER BY cadrename
            cl.ds = cl.DataFill("select feedingcadre,fcadreid from pmdfeedingcadre order by feedingcadre");
            ddlfcadre.DataSource = cl.ds;
            ddlfcadre.DataTextField = "feedingcadre";
            ddlfcadre.DataValueField = "fcadreid";
            ddlfcadre.DataBind();
            ddlfcadre.Items.Insert(0, new ListItem("--select--"));
            //cl.ds = cl.DataFill("SELECT distinct(cadrename), cadreid FROM  PMDCadre ORDER BY cadrename");
            //DCad.DataSource = cl.ds;
            //DCad.DataTextField = "cadrename";
            //DCad.DataValueField = "cadreid";
            //DCad.DataBind();
            //DCad.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT caste, id FROM  pmdcaste ORDER BY caste");
            ddlcaste.DataSource = cl.ds;
            ddlcaste.DataTextField = "caste";
            ddlcaste.DataValueField = "id";
            ddlcaste.DataBind();
            ddlcaste.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT disability, id FROM  pmddisability ORDER BY disability");
            Dsubcat.DataSource = cl.ds;
            Dsubcat.DataTextField = "disability";
            Dsubcat.DataValueField = "id";
            Dsubcat.DataBind();
            Dsubcat.Items.Insert(0, new ListItem("--select--"));
            //****************//SELECT     appbasis, appbasisid  FROM         PMDappbasis ORDER BY appbasis
            //cl.ds = cl.DataFill("SELECT  distinct(appbasisid), appbasis FROM  PMDappbasis ORDER BY appbasis");
            //DLavel.DataSource = cl.ds;
            //DLavel.DataTextField = "appbasis";
            //DLavel.DataValueField = "appbasisid";
            //DLavel.DataBind();
            //DLavel.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("select cadrename,cadreid from pmdcadre order by cadrename");
            ddlcadre.DataSource = cl.ds;
            ddlcadre.DataTextField = "cadrename";
            ddlcadre.DataValueField = "cadreid";
            ddlcadre.DataBind();
            ddlcadre.Items.Insert(0, new ListItem("--select--"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ////HttpResponse.RemoveOutputCacheItem('[""]');
                ////HttpResponse.RemoveOutputCacheItem;
                //if ((string)Session["iduser"] == null)
                //{
                //    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                //}
                maxpic();
                size();
                sdate();
                dfill();

            }
        }

        protected void s1_Click(object sender, EventArgs e)
        {
            string str = "insert into PMDpersonaldetails(idno,gpfno,name,fathername,sex,dob,homedistrictid,phomedistrictid,casteid,disabilityid,cadreid,fcadreid,senno,doapp,dojoining,doconfirmation,coupleid,enquiry,contactno,laddress,paddress,remark,creatoruserid,lastupdatedtime,hostipaddress,postingstatus,orderno,currentdate,cadrestatus,orderby,modifieruserid)values(@idno,@gpfno,@name,@fathername,@sex,@dob,@homedistrictid,@phomedistrictid,@casteid,@disabilityid,@cadreid,@fcadreid,@senno,@doapp,@dojoining,@doconfirmation,@coupleid,@enquiry,@contactno,@laddress,@paddress,@remark,@creatoruserid,@lastupdatedtime,@hostipaddress,@postingstatus,@orderno,@currentdate,@cadrestatus,@orderby,@modifieruserid)";
            parameter(str);
            //this.err.Text = "Record have been successfully Saved";

        }
        public void parameter(string str)
        {
            maxpic();
            try
            {//****************80	category	nvarchar	50	1
                //***************cadreid 0	cadre	int	4	1 fhname.Text.Replace("\'", "\'\'").Trim()
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand(str, cl.upcon);//
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@gpfno", SqlDbType.NVarChar, 50).Value = Gpfno.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = Name.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@fathername", SqlDbType.NVarChar, 50).Value = fhname.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@sex", SqlDbType.Int, 4).Value = Dsex.SelectedItem.Value;
                if (DB1.SelectedIndex != 0 && DB2.SelectedIndex != 0 && DB3.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DB2.SelectedItem.Text + "/" + DB1.SelectedItem.Text + "/" + DB3.SelectedItem.Text);
                }
                else if (DB1.SelectedIndex == 0 || DB2.SelectedIndex == 0 || DB3.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@dob", DBNull.Value);
                }
                if (DhomeD.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@homedistrictid", SqlDbType.Int, 4).Value = DhomeD.SelectedItem.Value;
                }
                else if (DhomeD.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@homedistrictid", SqlDbType.Int, 4).Value = 0;
                }
                if (pDhomeD.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@phomedistrictid", SqlDbType.Int, 4).Value = pDhomeD.SelectedItem.Value;
                }
                else if (pDhomeD.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@phomedistrictid", SqlDbType.Int, 4).Value = 0;
                }

                if (ddlcaste.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@casteid", SqlDbType.Int, 4).Value = ddlcaste.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@casteid", SqlDbType.Int, 4).Value = 0;
                }
                if (ddlcadre.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@cadreid", SqlDbType.Int, 4).Value = ddlcadre.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@cadreid", SqlDbType.Int, 4).Value = 0;
                }
                if (ddlfcadre.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@fcadreid", SqlDbType.Int, 4).Value = ddlfcadre.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@fcadreid", SqlDbType.Int, 4).Value = 0;
                }
                if (Dsubcat.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@disabilityid", SqlDbType.Int, 4).Value = Dsubcat.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@disabilityid", SqlDbType.Int, 4).Value = 0;
                }
                //if (DCad.SelectedIndex != 0)
                //{
                //    cmd.Parameters.Add("@cadre", SqlDbType.Int, 4).Value = DCad.SelectedItem.Value;
                //}
                //else
                //{
                //    cmd.Parameters.Add("@cadre", SqlDbType.Int, 4).Value = 0;
                //}
                if (CSN.Text != "")
                {
                    cmd.Parameters.Add("@senno", SqlDbType.NVarChar, 50).Value = CSN.Text.Replace("\'", "\'\'").Trim();
                }
                else
                {
                    cmd.Parameters.Add("@senno", SqlDbType.NVarChar, 50).Value = "";
                }

                if (DA1.SelectedIndex != 0 && DA2.SelectedIndex != 0 && DA3.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@doapp", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DA2.SelectedItem.Text + "/" + DA1.SelectedItem.Text + "/" + DA3.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (DA1.SelectedIndex == 0 || DA2.SelectedIndex == 0 || DA3.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@doapp", DBNull.Value);
                }
                if (DJ1.SelectedIndex != 0 && DJ2.SelectedIndex != 0 && DJ3.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@dojoining", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DJ2.SelectedItem.Text + "/" + DJ1.SelectedItem.Text + "/" + DJ3.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (DJ1.SelectedIndex == 0 || DJ2.SelectedIndex == 0 || DJ3.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@dojoining", DBNull.Value);
                }

                if (DC1.SelectedIndex != 0 && DC2.SelectedIndex != 0 && DC3.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@doconfirmation", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(DC2.SelectedItem.Text + "/" + DC1.SelectedItem.Text + "/" + DC3.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (DC1.SelectedIndex == 0 || DC2.SelectedIndex == 0 || DC3.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@doconfirmation", DBNull.Value);
                }

                //if (DLavel.SelectedIndex != 0)
                //{
                //    cmd.Parameters.Add("@appbasisid", SqlDbType.Int, 4).Value = DLavel.SelectedItem.Value;
                //}
                //else if (DLavel.SelectedIndex == 0)
                //{
                //    cmd.Parameters.Add("@appbasisid", SqlDbType.Int, 4).Value = 0;
                //}

                if (Cgpf.Text == "")
                {
                    cmd.Parameters.Add("@coupleid", SqlDbType.NVarChar, 50).Value = "NA";
                }
                else
                {
                    cmd.Parameters.Add("@coupleid", SqlDbType.NVarChar, 50).Value = Cgpf.Text.Replace("\'", "\'\'").Trim();
                }
                cmd.Parameters.Add("@enquiry", SqlDbType.NVarChar, 2).Value = "N";

                cmd.Parameters.Add("@contactno", txtmobil.Text);
                cmd.Parameters.Add("@laddress", SqlDbType.NVarChar, 255).Value = ladd.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@paddress", SqlDbType.NVarChar, 255).Value = padd.Text.Replace("\'", "\'\'").Trim();
                //cmd.Parameters.Add("@empttypeid", SqlDbType.Int, 4).Value = 1;
                cmd.Parameters.Add("@remark", SqlDbType.NVarChar, 255).Value = remark.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@creatoruserid", SqlDbType.Int, 4).Value = (string)Session["iduser"];
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@postingstatus", SqlDbType.NVarChar, 50).Value = "J";
                cmd.Parameters.Add("@orderno", SqlDbType.NVarChar, 50).Value = "";
                cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@cadrestatus", SqlDbType.NVarChar, 50).Value = "";
                cmd.Parameters.Add("@orderby", SqlDbType.NVarChar, 200).Value = "";
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = (string)Session["iduser"];
                cmd.Parameters.Add("@lock", SqlDbType.NVarChar, 50).Value = "";
                err.Visible = true;
                Response.Write(str);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    err.Text = "";
                    cl.upcon.Close();
                    Response.Redirect("parap2Posting.aspx?idno=" + maxid.Text + "");
                }
                else
                    err.Text = "Please Check the entry";

            }
            catch (Exception ex)
            {
                err.Text = "Error :" + ex.Message;
            }
            finally
            {
                cl.upcon.Close();
                //Response.Redirect("parap2Posting.aspx?idno=" + maxid.Text + "");

            }
        }

        public void datecheck()
        {
            //DateTime date1;
            //bool date1OK;
            //date1 = new DateTime(1, 1, 1);
            //try
            //{
            //    date1 = Convert.ToDateTime(doc.Text);

            //    date1OK = true;
            //}
            //catch
            //{

            //    date1OK = false;
            //    doc.Text = "";
            //}
        }

        public void clear()
        {
            //function used for clearing text box
            //foreach (Control c in ((HtmlForm)Page.FindControl("form1")).Controls)
            //{
            //    if (c is System.Web.UI.WebControls.TextBox)
            //    {
            //        TextBox tb = ((TextBox)c);
            //        tb.Text = "";
            //    }
            //}

        }
        public void size()
        {
            //foreach (Control t in ((HtmlForm)Page.FindControl("form1")).Controls)
            //{
            //    if (t is System.Web.UI.WebControls.TextBox)
            //    {
            //        TextBox tb = ((TextBox)t);
            //        tb.Height = 16;
            //        //tb.Width = 175;                
            //    }

            //}
        }
        public void setd()
        {
            //foreach (Control d in ((HtmlForm)Page.FindControl("form1")).Controls)
            //{
            //    if (d is System.Web.UI.WebControls.DropDownList)
            //    {
            //        DropDownList DT = ((DropDownList)d);
            //        DT.SelectedIndex = 0;
            //    }
            //}
        }
        protected void Gpfno_TextChanged(object sender, EventArgs e)
        {
            //if (Gpfno.Text == "")
            //{
            //    msg("gpf no cant be null");
            //    size();
            //}

        }



        protected void QSsave_Click(object sender, EventArgs e)
        {
            qual();
            Sstudy();
        }

        public void Sstudy()
        {
            cl.ds = cl.DataFill("SELECT '(' + PMDQualification.QuaName + ',' + PMDspecialization.spname + ')' AS st FROM PMDqual_det INNER JOIN  PMDQualification ON PMDqual_det.qid = PMDQualification.QuaId INNER JOIN  PMDspecialization ON PMDqual_det.sid = PMDspecialization.spid where PMDqual_det.idno ='" + Convert.ToInt32(maxid.Text) + "'");//
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                int j;
                Qmes.Visible = true;
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    if (j == 0)
                    {
                        Qmes.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    }
                    else
                    {
                        Qmes.Text = Qmes.Text + "," + cl.ds.Tables[0].Rows[j][0].ToString();
                    }
                }
            }
            else
            {
                Qmes.Text = "";
            }

        }


        public void maxpicQ()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(qid_serial),0)+ 1 FROM PMDqual_det");
            Qmes.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }

        public void qual()
        {
            try
            {
                //maxpic();
                maxpicQ();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into PMDqual_det(qid_serial,idno,gpfno,qid,sid)values(@qid_serial,@idno,@gpfno,@qid,@sid)", cl.upcon);
                cmd.Parameters.Add("@qid_serial", SqlDbType.Int, 4).Value = Convert.ToInt32(Qmes.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);//.Replace("\'", "\'\'").Trim()
                cmd.Parameters.Add("@gpfno", SqlDbType.VarChar, 250).Value = this.Gpfno.Text.Replace("\'", "\'\'").Trim();
                if (this.Dmqual.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@qid", SqlDbType.Int, 4).Value = Dmqual.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@qid", SqlDbType.Int, 4).Value = 0;
                }
                if (this.Dmqual.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@sid", SqlDbType.Int, 4).Value = Dmsub.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@sid", SqlDbType.Int, 4).Value = 0;
                }
                if (Dmqual.SelectedIndex != 0 && Dmsub.SelectedIndex != 0)
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Qmes.Visible = true;
                        Qmes.Text = "Qualification saved select other for more";
                    }
                    else
                    {
                        Qmes.Visible = true;
                        Qmes.Text = "no qualification selected";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();
                Dmqual.SelectedIndex = 0;
                Dmsub.SelectedIndex = 0;

            }
            Sstudy();

        }
        protected void Dmqual_SelectedIndexChanged(object sender, EventArgs e)
        {
            Qmes.Visible = false;
        }

        protected void pDhomeD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        protected void DhomeD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DhomeD.SelectedItem.Text == "NONE")
            {
                OtSL.Visible = true;
                Otherstatetext.Visible = true;
                OTSTATESUBMIT.Visible = true;
            }
            else
            {
                OtSL.Visible = false;
                Otherstatetext.Visible = false;
                OTSTATESUBMIT.Visible = false;
            }
        }
        public void otherstatesub()
        {
            try
            {
                cl.ds = cl.DataFill("SELECT isnull(MAX(sen),0)+ 1 FROM pmdotherhomedistrict");
                Qmes.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into pmdotherhomedistrict(sen,gpfno,idno,hname)values(@sen,@senno,@idno,@hname)", cl.upcon);
                cmd.Parameters.Add("@sen", SqlDbType.Int, 4).Value = Convert.ToInt32(Qmes.Text);
                cmd.Parameters.Add("@senno", SqlDbType.NVarChar, 50).Value = Gpfno.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@hname", SqlDbType.NVarChar, 200).Value = Otherstatetext.Text.Replace("\'", "\'\'").Trim();
                if (Otherstatetext.Text != "")
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        OtSL.Visible = false;
                        Otherstatetext.Visible = false;
                        OTSTATESUBMIT.Visible = false;
                        cl.upcon.Close();
                    }
                    else
                    {
                        cl.upcon.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                err.Text = "Error :" + ex.Message;
            }
            finally
            {
                cl.upcon.Close();
            }
        }
        protected void OTSTATESUBMIT_Click(object sender, EventArgs e)
        {
            otherstatesub();
        }

        protected void txtmobil_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Otherstatetext_TextChanged(object sender, EventArgs e)
        {

        }
        protected void DC1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2option.aspx");
        }
    }
}