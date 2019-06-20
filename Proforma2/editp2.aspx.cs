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
    public partial class editp2 : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        String Img;
        protected void Page_Load(object sender, EventArgs e)
        {

            FileUpload1.Visible = false;
            docimage.Visible = false;

            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                //mesg.Text = "Please Select To Edit Additional Qualification/Please Select  To Edit by Information";
                Uidt.Text = (string)Session["iduser"];
                Up.Enabled = true;
                ddfill();
                data();
                study();

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
            cl.ds = cl.DataFill("SELECT distinct(cadrename), cadreid FROM  cadre ORDER BY cadrename");
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
            //****************
            cl.ds = cl.DataFill("SELECT  distinct(levelcode), leveldesc, levelid FROM         lavel ORDER BY leveldesc");
            DLavel.DataSource = cl.ds;
            DLavel.DataTextField = "leveldesc";
            DLavel.DataValueField = "levelcode";
            DLavel.DataBind();
            DLavel.Items.Insert(0, new ListItem("--select--"));
            //****************
        }
        public void parameter(string str)
        {
            try
            {

                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand(str, cl.upcon);
                cmd.Parameters.Add("@idno", SqlDbType.NVarChar, 50).Value = Request.QueryString["idno"];
                cmd.Parameters.Add("@senno", SqlDbType.NVarChar, 50).Value = Gpfno.Text;
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
                cmd.Parameters.Add("@catid", SqlDbType.Int, 4).Value = Dcateg.SelectedItem.Value;
                cmd.Parameters.Add("@scatid", SqlDbType.Int, 4).Value = Dsubcat.SelectedItem.Value;
                cmd.Parameters.Add("@cadreid", SqlDbType.Int, 4).Value = DCad.SelectedItem.Value;
                cmd.Parameters.Add("@cadresenno", SqlDbType.NVarChar, 50).Value = CSN.Text;
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
                cmd.Parameters.Add("@lavel", SqlDbType.Int, 4).Value = DLavel.SelectedItem.Value; ;
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
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = (string)Session["iduser"];//Uidt.Text
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                if (FileUpload1.HasFile)
                {
                    Img = FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath("~/Doctors Image/") + Img);
                }
                else
                {
                    Img = "noimg.jpg";
                }
                cmd.Parameters.Add("@Image", SqlDbType.VarChar, 50).Value = Img;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                err.Visible = true;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    err.Text = "Changes Saved to Approve......!!!";
                    Up.Enabled = false;


                }
                else
                    err.Text = "Technical Problem";
                Up.Enabled = false;


            }
            catch (Exception ex)
            {
                err.Text = "Error :" + ex.Message;
            }
            finally
            {
                cl.upcon.Close();

                //s1.Enabled = false;
            }
        }
        protected void Up_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            string str = "insert into personaldetailstemp(idno,senno,name,fathername,sex,dob,homedistrictid,phomedistrictid,catid,scatid,cadre,cadresenno,doapp,dojoining,doconfirmation,lavel,coupleid,enquiry,laddress,paddress,remark,modifieruserid,lastupdatedtime,hostipaddress,Doctor_Img) values(@idno,@senno,@name,@fathername,@sex,@dob,@homedistrictid,@phomedistrictid,@catid,@scatid,@cadreid,@cadresenno,@doapp,@dojoining,@doconfirmation,@lavel,@coupleid,@enquiry,@laddress,@paddress,@remark,@modifieruserid,@lastupdatedtime,@hostipaddress,@Image)";
            //  string str = "Update personaldetailstemp set senno=@senno,name=@name,fathername=@fathername,sex=@sex,dob=@dob,homedistrictid=@homedistrictid,phomedistrictid=@phomedistrictid,catid=@catid,scatid=@scatid,cadre=@cadreid,cadresenno=@cadresenno,doapp=@doapp,dojoining=@dojoining,doconfirmation=@doconfirmation,lavel=@lavel,coupleid=@coupleid,enquiry=@enquiry,laddress=@laddress,paddress=@paddress,remark=@remark,modifieruserid=@modifieruserid,lastupdatedtime=@lastupdatedtime,hostipaddress=@hostipaddress,Doctor_Img=@Image where idno='" + Request.QueryString["idno"] + "' ";
            parameter(str);
            otherstatesub();
            data();
            study();
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
            cl.ds = cl.DataFill("select senno,name,fathername,sex,convert(varchar,dob,101)as dob,homedistrictid,catid,scatid,cadre,cadresenno,convert(varchar,doapp,101)as doapp,convert(varchar,dojoining,101)as dojoining,convert(varchar,doconfirmation,101)as doconfirmation,lavel,coupleid,phomedistrictid,laddress,paddress,remark from personaldetails where idno='" + Request.QueryString["idno"] + "'  ");
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
                    Dob.Text = cl.ds.Tables[0].Rows[0][4].ToString();//DateTime.Today.ToString("dd/MM/yyyy")
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
                            cl.ds1 = cl.DataFill2("SELECT     hname,sen FROM  otherhomedistrict where idno = '" + Request.QueryString["idno"] + "'");

                            // cl.ds1 = cl.DataFill2("SELECT     hname,sen FROM  otherhomedistrict where idno = '" + Request.QueryString["idno"] + "'or senno='" + Gpfno.Text + "'  ");
                            if (!(cl.ds1.Tables[0].Rows[0]["hname"].ToString().Equals(System.DBNull.Value)))
                            {
                                Otherstatetext.Text = cl.ds1.Tables[0].Rows[0]["hname"].ToString();
                            }
                            else
                            {
                                Otherstatetext.Text = "District Out Of Uttar Pradesh";
                            }
                            if (!(cl.ds1.Tables[0].Rows[0]["sen"].ToString().Equals(System.DBNull.Value)))
                            {
                                ohome.Text = cl.ds1.Tables[0].Rows[0]["sen"].ToString();
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
                    Dsubcat.SelectedIndex = Dsubcat.Items.IndexOf(Dsubcat.Items.FindByValue(cl.ds.Tables[0].Rows[0][7].ToString()));
                }
                else
                {
                    Dsubcat.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
                {
                    DCad.SelectedIndex = DCad.Items.IndexOf(DCad.Items.FindByValue(cl.ds.Tables[0].Rows[0][8].ToString()));
                }
                else
                {
                    DCad.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
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
                    DLavel.SelectedIndex = DLavel.Items.IndexOf(DLavel.Items.FindByValue(cl.ds.Tables[0].Rows[0][13].ToString()));
                }
                else
                {
                    DLavel.SelectedIndex = 0;
                }
                if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
                {
                    Cgpf.Text = cl.ds.Tables[0].Rows[0][14].ToString();
                }
                else
                {
                    Cgpf.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][15].ToString().Equals(System.DBNull.Value)))
                {
                    pDhomeD.SelectedIndex = pDhomeD.Items.IndexOf(pDhomeD.Items.FindByValue(cl.ds.Tables[0].Rows[0][15].ToString()));
                }
                else
                {
                    pDhomeD.SelectedIndex = 0;
                }

                //if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
                //{
                //    Cenq.Text = cl.ds.Tables[0].Rows[0][14].ToString();

                //}
                //else
                //{
                //    //CheckBox3.Visible = true;
                //}

                if (!(cl.ds.Tables[0].Rows[0][16].ToString().Equals(System.DBNull.Value)))
                {
                    ladd.Text = cl.ds.Tables[0].Rows[0][16].ToString();
                }
                else
                {
                    ladd.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][17].ToString().Equals(System.DBNull.Value)))
                {
                    padd.Text = cl.ds.Tables[0].Rows[0][17].ToString();
                }
                else
                {
                    padd.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][18].ToString().Equals(System.DBNull.Value)))
                {
                    remark.Text = cl.ds.Tables[0].Rows[0][18].ToString();
                }
                else
                {
                    remark.Text = "";
                }

                Up.Visible = true;



            }
        }
        public void study()
        {//"SELECT '(' + Qualification.QuaName+','+ specialization.spname+ ')' as st FROM Quallnew INNER JOIN Qualification ON Quallnew.Qid = Qualification.QuaId INNER JOIN specialization ON Quallnew.Sid = specialization.spid where Quallnew.userid =" + Label1.Text + ""
            ////SELECT     '(' + Qualification.QuaName + ',' + specialization.spname + ')' AS st FROM         qual_det INNER JOIN  specialization ON qual_det.sid = specialization.spid INNER JOIN  Qualification ON qual_det.qid = Qualification.QuaId WHERE     (qual_det.idno = 42) ORDER BY '(' + Qualification.QuaName + ',' + specialization.spname + ')'
            cl.ds = cl.DataFill("SELECT     '(' + Qualification.QuaName + ',' + specialization.spname + ')' AS st FROM         qual_det INNER JOIN  specialization ON qual_det.sid = specialization.spid INNER JOIN  Qualification ON qual_det.qid = Qualification.QuaId WHERE     (qual_det.idno ='" + Request.QueryString["idno"] + "') ORDER BY '(' + Qualification.QuaName + ',' + specialization.spname + ')'");//
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                int j;
                Label2.Visible = true;
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    if (j == 0)
                    {
                        Label2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    }
                    else
                    {
                        Label2.Text = Label2.Text + "," + cl.ds.Tables[0].Rows[j][0].ToString();
                    }
                }

            }

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //cl.ds.Dispose();
        }
       
        protected void OTSTATESUBMIT_Click(object sender, EventArgs e)
        {
            otherstatesub();
            Label1.Visible = true;
            Label1.Text = "HomeDistrict Updated..now press update button to edit record.!!";

        }
        public void otherstatesub()
        {
            if (Otherstatetext.Text != "")
            {
                cl.ds = cl.DataFill2("select * from otherhomedistrict where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    otherstupd();
                }
                else //if (cl.ds.Tables[0].Rows.Count == 0)
                {
                    otherstinsert();
                }
            }
        }
        public void otherstupd()
        {
            try
            {
                cl.cmd = cl.InsertDB("update otherhomedistrict set hname ='" + Otherstatetext.Text.Replace("\'", "\'\'").Trim() + "' where idno='" + Request.QueryString["idno"] + "'");
                //where sen=" + Convert.ToInt32(ohome.Text) + "");
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
                cl.ds = cl.DataFill("SELECT isnull(MAX(sen),0)+ 1 FROM otherhomedistrict");
                Qmes.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into otherhomedistrict(sen,senno,idno,hname)values(@sen,@senno,@idno,@hname)", cl.upcon);
                cmd.Parameters.Add("@sen", SqlDbType.Int, 4).Value = Convert.ToInt32(Qmes.Text);
                cmd.Parameters.Add("@senno", SqlDbType.NVarChar, 50).Value = Gpfno.Text.Replace("\'", "\'\'").Trim();
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
        protected void PFsheet_Click(object sender, EventArgs e)
        {
            //Response.Redirect("proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");
            //Server.Transfer("proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");
            Server.Transfer("DoctorP2.aspx?idno=" + Request.QueryString["idno"] + "");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Proforma2/Option.aspx");
        }
    }
}