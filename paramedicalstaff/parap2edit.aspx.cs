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
    public partial class parap2edit : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); ;//jump to first page for login
                }
                //mesg.Text = "Please Select To Edit Additional Qualification/Please Select  To Edit by Information";
                Uidt.Text = (string)Session["iduser"];
                ddfill();
                data();
                //study();

            }
        }
        public void ddfill()
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
            cl.ds = cl.DataFill("SELECT distinct(cadrename), cadreid FROM  PMDcadre ORDER BY cadrename");
            DCad.DataSource = cl.ds;
            DCad.DataTextField = "cadrename";
            DCad.DataValueField = "cadreid";
            DCad.DataBind();
            DCad.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT distinct(category), catid FROM  category ORDER BY category");
            Dcateg.DataSource = cl.ds;
            Dcateg.DataTextField = "category";
            Dcateg.DataValueField = "catid";
            Dcateg.DataBind();
            Dcateg.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("SELECT distinct(scategory), scatid FROM  subcategory ORDER BY scategory");
            Dsubcat.DataSource = cl.ds;
            Dsubcat.DataTextField = "scategory";
            Dsubcat.DataValueField = "scatid";
            Dsubcat.DataBind();
            Dsubcat.Items.Insert(0, new ListItem("--select--"));
            //****************
            //cl.ds = cl.DataFill("SELECT  distinct(appbasisid), appbasis FROM  PMDappbasis ORDER BY appbasis");
            //DLavel.DataSource = cl.ds;
            //DLavel.DataTextField = "appbasis";
            //DLavel.DataValueField = "appbasisid";
            //DLavel.DataBind();
            //DLavel.Items.Insert(0, new ListItem("--select--"));
            //****************
            cl.ds = cl.DataFill("select feedingcadre,fcadreid from pmdfeedingcadre order by cadreid");
            ddlempcat.DataSource = cl.ds;
            ddlempcat.DataTextField = "feedingcadre";
            ddlempcat.DataValueField = "fcadreid";
            ddlempcat.DataBind();
            ddlempcat.Items.Insert(0, new ListItem("--select--"));
        }
        public void parameter(string str)
        {
            try
            {

                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand(str, cl.upcon);
                cmd.Parameters.Add("@gpfno", SqlDbType.NVarChar, 50).Value = Gpfno.Text;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = Name.Text;
                cmd.Parameters.Add("@fathername", SqlDbType.NVarChar, 50).Value = fhname.Text;
                cmd.Parameters.Add("@sex", SqlDbType.NVarChar, 8).Value = Dsex.SelectedItem.Value;
                if (Dob.Text != "")
                {
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(Dob.Text);
                }
                else if (Dob.Text == "")
                {
                    cmd.Parameters.AddWithValue("@dob", DBNull.Value);

                }
                //convert(varchar,FieldName,101)     Convert.ToDateTime(Format(Dob.Text, "dd/MM/yyyy"))    Convert.ToDateTime(doa.Text)
                cmd.Parameters.Add("@homedistrictid", SqlDbType.Int, 4).Value = DhomeD.SelectedItem.Value;
                if (pDhomeD.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@phomedistrictid", SqlDbType.Int, 4).Value = pDhomeD.SelectedItem.Value;
                }
                else if (pDhomeD.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@phomedistrictid", SqlDbType.Int, 4).Value = 0;
                }

                cmd.Parameters.Add("@cadreid", SqlDbType.Int, 4).Value = DCad.SelectedItem.Value;



                if (ddlempcat.SelectedIndex == 0)
                {

                    cmd.Parameters.Add("@fcadreid", SqlDbType.Int, 4).Value = 0;
                    //err.Text = "Select Feeding Cadre";
                }
                else
                {
                    cmd.Parameters.Add("@fcadreid", SqlDbType.Int, 4).Value = ddlempcat.SelectedItem.Value;

                }



                cmd.Parameters.Add("@senno", SqlDbType.NVarChar, 50).Value = CSN.Text;
                if (doa.Text != "")
                {
                    cmd.Parameters.Add("@doapp", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(doa.Text);
                }
                else if (doa.Text == "")
                {
                    cmd.Parameters.AddWithValue("@doapp", DBNull.Value);

                }
                if (dojs.Text != "")
                {
                    cmd.Parameters.Add("@dojoining", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(dojs.Text);
                }
                else if (dojs.Text == "")
                {
                    cmd.Parameters.AddWithValue("@dojoining", DBNull.Value);

                }

                if (doc.Text != "")
                {
                    cmd.Parameters.Add("@doconfirmation", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(doc.Text);
                }

                else if (doc.Text == "")
                {
                    cmd.Parameters.AddWithValue("@doconfirmation", DBNull.Value);

                }

                cmd.Parameters.Add("@casteid", SqlDbType.Int, 4).Value = Dcateg.SelectedItem.Value;
                //if (DLavel.SelectedIndex != 0)
                //{
                //    cmd.Parameters.Add("@appbasisid", SqlDbType.Int, 4).Value = DLavel.SelectedItem.Value;
                //}
                //else if (DLavel.SelectedIndex == 0)
                //{
                //    cmd.Parameters.Add("@appbasisid", SqlDbType.Int, 4).Value = 0;
                //}
                //cmd.Parameters.Add("@appbasisid", SqlDbType.Int, 4).Value = DLavel.SelectedItem.Value; ;
                if (Cgpf.Text == "")
                {
                    cmd.Parameters.Add("@coupleid", SqlDbType.NVarChar, 50).Value = "NA";
                }
                else
                {
                    cmd.Parameters.Add("@coupleid", SqlDbType.NVarChar, 50).Value = Cgpf.Text;
                }
                cmd.Parameters.Add("@enquiry", SqlDbType.NVarChar, 4).Value = "N";
                cmd.Parameters.Add("@laddress", SqlDbType.NVarChar, 255).Value = ladd.Text;
                cmd.Parameters.Add("@paddress", SqlDbType.NVarChar, 255).Value = padd.Text;
                cmd.Parameters.Add("@remark", SqlDbType.NVarChar, 255).Value = remark.Text;

                cmd.Parameters.Add("@contactno", SqlDbType.NVarChar, 255).Value = txtmobil.Text;

                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = (string)Session["iduser"];//Uidt.Text
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];

                cmd.Parameters.Add("@disabilityid", SqlDbType.Int, 4).Value = Dsubcat.SelectedItem.Value;
                err.Visible = true;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    err.Text = "Succuessfully Updated";
                }
                else
                    err.Text = "Technical Problem";

            }
            catch (Exception ex)
            {
                err.Text = "Error :" + ex.Message;
                //RequiredFieldValidator2.Validate = true;
            }
            finally
            {
                cl.upcon.Close();
            }
        }
        protected void Up_Click(object sender, EventArgs e)
        {




            string str = "Update PMDpersonaldetails set gpfno=@gpfno,name=@name,fathername=@fathername,sex=@sex,dob=@dob,homedistrictid=@homedistrictid,phomedistrictid=@phomedistrictid,casteid=@casteid,fcadreid=@fcadreid,cadreid=@cadreid,senno=@senno,doapp=@doapp,dojoining=@dojoining,doconfirmation=@doconfirmation,coupleid=@coupleid,enquiry=@enquiry,laddress=@laddress,paddress=@paddress,disabilityid=@disabilityid,remark=@remark,modifieruserid=@modifieruserid,lastupdatedtime=@lastupdatedtime,hostipaddress=@hostipaddress,contactno=@contactno where idno='" + Request.QueryString["idno"] + "' ";
            parameter(str);
            otherstatesub();
            data();


            //study();
        }
        protected void pDhomeD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Gpfno_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Name_TextChanged(object sender, EventArgs e)
        {

        }
        public void data()
        {
            cl.ds = cl.DataFill("select gpfno,name,fathername,sex,convert(varchar,dob,101)as dob,homedistrictid,casteid,cadreid,fcadreid,senno,convert(varchar,doapp,101)as doapp,convert(varchar,dojoining,101)as dojoining,convert(varchar,doconfirmation,101)as doconfirmation,coupleid,phomedistrictid,laddress,paddress,remark,contactno,disabilityid from PMDpersonaldetails where idno='" + Request.QueryString["idno"] + "'  ");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    Gpfno.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Gpfno.Text = "";
                }

                //Gpfno.Enabled = false;
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    Name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    Name.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    fhname.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    fhname.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    Dsex.SelectedIndex = Dsex.Items.IndexOf(Dsex.Items.FindByValue(cl.ds.Tables[0].Rows[0][3].ToString()));
                }
                else
                {
                    Dsex.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    Dob.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    Dob.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][5].ToString().Equals(System.DBNull.Value)))
                {
                    DhomeD.SelectedIndex = DhomeD.Items.IndexOf(DhomeD.Items.FindByValue(cl.ds.Tables[0].Rows[0][5].ToString()));

                    if (DhomeD.SelectedItem.Text == "NONE")
                    {
                        OtSL.Visible = true;
                        Otherstatetext.Visible = true;
                        //OTSTATESUBMIT.Visible = true;
                        try
                        {

                            cl.ds1 = cl.DataFill2("SELECT     hname,sen FROM  PMDotherhomedistrict where idno = '" + Request.QueryString["idno"] + "'or gpfno='" + Gpfno.Text + "'  ");
                            if (!(cl.ds1.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                            {
                                Otherstatetext.Text = cl.ds1.Tables[0].Rows[0][0].ToString();
                            }
                            else
                            {
                                Otherstatetext.Text = "District Out Of Uttar Pradesh";
                            }
                            if (!(cl.ds1.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                            {
                                ohome.Text = cl.ds1.Tables[0].Rows[0][1].ToString();
                            }
                            else
                            {
                                ohome.Text = "0";
                            }

                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error :" + ex.Message);
                        }
                    }
                    else
                    {
                        OtSL.Visible = false;
                        Otherstatetext.Visible = false;
                        OTSTATESUBMIT.Visible = false;
                    }

                }
                else
                {
                    DhomeD.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][6].ToString().Equals(System.DBNull.Value)))
                {
                    Dcateg.SelectedIndex = Dcateg.Items.IndexOf(Dcateg.Items.FindByValue(cl.ds.Tables[0].Rows[0][6].ToString()));
                }
                else
                {
                    Dcateg.SelectedIndex = 0;
                }

                if (!(cl.ds.Tables[0].Rows[0][7].ToString().Equals(System.DBNull.Value)))
                {
                    //Dsubcat.SelectedIndex = Dsubcat.Items.IndexOf(Dsubcat.Items.FindByValue(cl.ds.Tables[0].Rows[0][7].ToString()));

                    DCad.SelectedIndex = DCad.Items.IndexOf(DCad.Items.FindByValue(cl.ds.Tables[0].Rows[0][7].ToString()));

                }
                else
                {
                    DCad.SelectedIndex = 0;
                    //Dsubcat.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
                {
                    //DCad.SelectedIndex = DCad.Items.IndexOf(DCad.Items.FindByValue(cl.ds.Tables[0].Rows[0][8].ToString()));

                    ddlempcat.SelectedIndex = ddlempcat.Items.IndexOf(ddlempcat.Items.FindByValue(cl.ds.Tables[0].Rows[0][8].ToString()));
                }
                else
                {
                    ddlempcat.SelectedIndex = 0;
                    ////DCad.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][9].ToString().Equals(System.DBNull.Value)))
                {
                    CSN.Text = cl.ds.Tables[0].Rows[0][9].ToString();

                }
                else
                {
                    CSN.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][10].ToString().Equals(System.DBNull.Value)))
                {
                    doa.Text = cl.ds.Tables[0].Rows[0][10].ToString();
                }

                else
                {
                    doa.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][11].ToString().Equals(System.DBNull.Value)))
                {
                    dojs.Text = cl.ds.Tables[0].Rows[0][11].ToString();
                }
                else
                {
                    dojs.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][12].ToString().Equals(System.DBNull.Value)))
                {
                    doc.Text = cl.ds.Tables[0].Rows[0][12].ToString();
                }
                else
                {
                    doc.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][13].ToString().Equals(System.DBNull.Value)))
                {
                    Cgpf.Text = cl.ds.Tables[0].Rows[0][13].ToString();
                    //DLavel.SelectedIndex = DLavel.Items.IndexOf(DLavel.Items.FindByValue(cl.ds.Tables[0].Rows[0][13].ToString()));
                }
                else
                {
                    Cgpf.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
                {
                    pDhomeD.SelectedIndex = pDhomeD.Items.IndexOf(pDhomeD.Items.FindByValue(cl.ds.Tables[0].Rows[0][14].ToString()));
                }
                else
                {
                    pDhomeD.SelectedIndex = 0;
                }

                if (!(cl.ds.Tables[0].Rows[0][15].ToString().Equals(System.DBNull.Value)))
                {
                    ladd.Text = cl.ds.Tables[0].Rows[0][15].ToString();
                    //pDhomeD.SelectedIndex = pDhomeD.Items.IndexOf(pDhomeD.Items.FindByValue(cl.ds.Tables[0].Rows[0][15].ToString()));
                }
                else
                {
                    ladd.Text = "";  //pDhomeD.SelectedIndex = 0;
                }


                if (!(cl.ds.Tables[0].Rows[0][16].ToString().Equals(System.DBNull.Value)))
                {
                    padd.Text = cl.ds.Tables[0].Rows[0][16].ToString();
                }
                else
                {
                    padd.Text = "";
                    //ladd.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][17].ToString().Equals(System.DBNull.Value)))
                {
                    remark.Text = cl.ds.Tables[0].Rows[0][17].ToString();
                    //padd.Text = cl.ds.Tables[0].Rows[0][17].ToString();
                }
                else
                {
                    remark.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][18].ToString().Equals(System.DBNull.Value)))
                {
                    txtmobil.Text = cl.ds.Tables[0].Rows[0][18].ToString();
                }
                else
                {
                    txtmobil.Text = "";
                }


                if (!(cl.ds.Tables[0].Rows[0][19].ToString().Equals(System.DBNull.Value)))
                {
                    Dsubcat.SelectedIndex = Dsubcat.Items.IndexOf(Dsubcat.Items.FindByValue(cl.ds.Tables[0].Rows[0][19].ToString()));
                }
                else
                {
                    Dsubcat.SelectedIndex = 0;
                }

                Up.Visible = true;



            }
        }
        //public void study()
        //{  cl.ds = cl.DataFill("SELECT     '(' + PMDQualification.QuaName + ',' + PMDspecialization.spname + ')' AS st FROM         PMDqual_det INNER JOIN  PMDspecialization ON PMDqual_det.sid = PMDspecialization.spid INNER JOIN  PMDQualification ON PMDqual_det.qid = PMDQualification.QuaId WHERE     (PMDqual_det.idno ='" + Request.QueryString["idno"] + "') ORDER BY '(' + PMDQualification.QuaName + ',' + PMDspecialization.spname + ')'");//
        //if (cl.ds.Tables[0].Rows.Count > 0)
        //{
        //    int j;
        //    Label2.Visible = true;
        //    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
        //    {
        //        if (j == 0)
        //        {
        //            Label2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
        //        }
        //        else
        //        {
        //            Label2.Text = Label2.Text + "," + cl.ds.Tables[0].Rows[j][0].ToString();
        //        }
        //    }

        //}
        //else
        //{
        //    Label2.Text = "Not Found";
        //}

        //}

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //cl.ds.Dispose();
        }
        
        protected void OTSTATESUBMIT_Click(object sender, EventArgs e)
        {

        }
        public void otherstatesub()
        {
            if (Otherstatetext.Text != "")
            {
                cl.ds = cl.DataFill2("select * from PMDotherhomedistrict where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    otherstupd();
                }
                else
                {
                    otherstinsert();
                }
            }
        }
        public void otherstupd()
        {
            try
            {
                cl.cmd = cl.InsertDB("update PMDotherhomedistrict set hname ='" + Otherstatetext.Text.Replace("\'", "\'\'").Trim() + "',idno='" + Request.QueryString["idno"] + "' where sen=" + Convert.ToInt32(ohome.Text) + "");
            }
            catch (Exception ex)
            {
                err.Text = "Error :" + ex.Message;
            }
            finally
            {
            }
        }

        public void otherstinsert()
        {
            try
            {
                cl.ds = cl.DataFill("SELECT isnull(MAX(sen),0)+ 1 FROM PMDotherhomedistrict");
                Qmes.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into PMDotherhomedistrict(sen,gpfno,idno,hname)values(@sen,@gpfno,@idno,@hname)", cl.upcon);
                cmd.Parameters.Add("@sen", SqlDbType.Int, 4).Value = Convert.ToInt32(Qmes.Text);
                cmd.Parameters.Add("@gpfno", SqlDbType.NVarChar, 50).Value = Gpfno.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(Request.QueryString["idno"]);
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
        public void otherstatesubXX()
        {
            if (Otherstatetext.Text != "")
            {
                try
                {
                    cl.cmd = cl.InsertDB("update PMDotherhomedistrict set hname ='" + Otherstatetext.Text.Replace("\'", "\'\'").Trim() + "',idno='" + Request.QueryString["idno"] + "' where sen='" + Convert.ToInt32(ohome.Text) + "'");
                }
                catch (Exception ex)
                {
                    err.Text = "Error :" + ex.Message;
                }
                finally
                {
                }
            }
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/paramedicalstaff/parap2option.aspx");
        }
    }
}