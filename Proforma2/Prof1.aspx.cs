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
    public partial class Prof1 : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        String Img;
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
            cl.ds = cl.DataFill("SELECT isnull(MAX(idno),0)+ 1 FROM personaldetails");
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
            for (i = 2030; i >= 1940; i--)
            //for (i = 1940; i <= 2040; i++)
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
            cl.ds = cl.DataFill("SELECT distinct(QuaName), QuaId FROM Qualification ORDER BY QuaName");
            Dmqual.DataSource = cl.ds;
            Dmqual.DataTextField = "QuaName";
            Dmqual.DataValueField = "QuaId";
            Dmqual.DataBind();
            Dmqual.Items.Insert(0, new ListItem("-sel-"));
            //****************
            cl.ds = cl.DataFill("SELECT distinct(spname), spid FROM  specialization ORDER BY spname");
            Dmsub.DataSource = cl.ds;
            Dmsub.DataTextField = "spname";
            Dmsub.DataValueField = "spid";
            Dmsub.DataBind();
            Dmsub.Items.Insert(0, new ListItem("--select--"));
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
            cl.ds = cl.DataFill("SELECT  distinct(levelcode), leveldesc, levelid FROM         lavel ORDER BY leveldesc");
            DLavel.DataSource = cl.ds;
            DLavel.DataTextField = "leveldesc";
            DLavel.DataValueField = "levelcode";
            DLavel.DataBind();
            DLavel.Items.Insert(0, new ListItem("--select--"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.Visible = false;
            docimage.Visible = false;

            if (!IsPostBack)
            {
                //HttpResponse.RemoveOutputCacheItem('[""]');
                //HttpResponse.RemoveOutputCacheItem;
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }
                maxpic();
                size();
                sdate();
                dfill();

            }
        }

        protected void s1_Click(object sender, EventArgs e)
        {
            string str = "insert into personaldetails(idno,senno,name,fathername,sex,dob,homedistrictid,phomedistrictid,catid ,scatid ,cadre,cadresenno,doapp,dojoining,doconfirmation,lavel,coupleid,enquiry,laddress,paddress,empttypeid,remark,creatoruserid,lastupdatedtime,hostipaddress,postingstatus,modifieruserid,Doctor_Img,phoneno,Mobileno,udate)values(@idno,@senno,@name,@fathername,@sex,@dob,@homedistrictid,@phomedistrictid,@catid ,@scatid ,@cadre,@cadresenno,@doapp,@dojoining,@doconfirmation,@lavel,@coupleid,@enquiry,@laddress,@paddress,@empttypeid,@remark,@creatoruserid,@lastupdatedtime,@hostipaddress,@postingstatus,@modifieruserid,@Image,@phoneno,@Mobileno,@udate)";
            parameter(str);


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
                cmd.Parameters.Add("@senno", SqlDbType.NVarChar, 50).Value = Gpfno.Text.Replace("\'", "\'\'").Trim();
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

                if (Dcateg.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@catid", SqlDbType.Int, 4).Value = Dcateg.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@catid", SqlDbType.Int, 4).Value = 0;
                }
                if (Dsubcat.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@scatid", SqlDbType.Int, 4).Value = Dsubcat.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@scatid", SqlDbType.Int, 4).Value = 0;
                }
                if (DCad.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@cadre", SqlDbType.Int, 4).Value = DCad.SelectedItem.Value;
                }
                else
                {
                    cmd.Parameters.Add("@cadre", SqlDbType.Int, 4).Value = 0;
                }
                if (CSN.Text != "")
                {
                    cmd.Parameters.Add("@cadresenno", SqlDbType.NVarChar, 50).Value = CSN.Text.Replace("\'", "\'\'").Trim();
                }
                else
                {
                    cmd.Parameters.Add("@cadresenno", SqlDbType.NVarChar, 50).Value = "";
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

                if (DLavel.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@lavel", SqlDbType.Int, 4).Value = DLavel.SelectedItem.Value;
                }
                else if (DLavel.SelectedIndex == 0)
                {
                    cmd.Parameters.Add("@lavel", SqlDbType.Int, 4).Value = 0;
                }

                if (Cgpf.Text == "")
                {
                    cmd.Parameters.Add("@coupleid", SqlDbType.NVarChar, 50).Value = "NA";
                }
                else
                {
                    cmd.Parameters.Add("@coupleid", SqlDbType.NVarChar, 50).Value = Cgpf.Text.Replace("\'", "\'\'").Trim();
                }
                cmd.Parameters.Add("@enquiry", SqlDbType.NVarChar, 2).Value = "N";
                cmd.Parameters.Add("@laddress", SqlDbType.NVarChar, 255).Value = ladd.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@paddress", SqlDbType.NVarChar, 255).Value = padd.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@empttypeid", SqlDbType.Int, 4).Value = 1;
                cmd.Parameters.Add("@remark", SqlDbType.NVarChar, 255).Value = remark.Text.Replace("\'", "\'\'").Trim();
                cmd.Parameters.Add("@creatoruserid", SqlDbType.Int, 4).Value = (string)Session["iduser"];
                cmd.Parameters.Add("@lastupdatedtime", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@postingstatus", SqlDbType.NVarChar, 50).Value = "J";
                cmd.Parameters.Add("@orderno", SqlDbType.NVarChar, 50).Value = "";
                cmd.Parameters.Add("@currentdate", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@cadrestatus", SqlDbType.NVarChar, 50).Value = "";
                cmd.Parameters.Add("@orderby", SqlDbType.NVarChar, 200).Value = "";
                cmd.Parameters.Add("@phoneno", SqlDbType.NVarChar, 50).Value = phone.Text;
                cmd.Parameters.Add("@Mobileno", SqlDbType.NVarChar, 50).Value = mobile.Text;
                cmd.Parameters.Add("@udate", SqlDbType.NVarChar, 50).Value = System.DateTime.Today;
                cmd.Parameters.Add("@modifieruserid", SqlDbType.Int, 4).Value = (string)Session["iduser"];
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
                cmd.Parameters.Add("@lock", SqlDbType.NVarChar, 50).Value = "";
                err.Visible = true;
                Response.Write(str);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    err.Text = "";
                    cl.upcon.Close();
                    try { qual(); }
                    catch (Exception ex)
                    {
                        err.Visible = true;
                        err.Text = ex.Message;
                        err.Text = "Please check the entry";
                    }
                    finally
                    { //Response.Redirect("Pdetchek.aspx?idno=" + maxid.Text + "");
                        Response.Redirect("posting.aspx?idno=" + maxid.Text + "");
                    }

                }
                else
                {
                    cl.upcon.Close();
                    err.Text = "PLEASE CHECK THE GIVEN INFORMATION";
                }

            }
            catch (Exception ex)
            {
                err.Text = "Error :" + ex.Message;
            }
            finally
            {
                cl.upcon.Close();
                //Response.Redirect("posting.aspx?idno=" + maxid.Text + "");          

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
        public void ddropdown()
        {
            //Reset the dropdown to default selected value.
            //DropDownList ddl = new DropDownList();
            //ddl = (DropDownList)this.Master.FindControl("Content").FindControl("myNewTable").FindControl("DropDownList1");
            //ddl.SelectedValue = "-1";
            //ddl = (DropDownList)this.Master.FindControl("Content").FindControl("myNewTable").FindControl("DropDownList2");
            //ddl.SelectedValue = "-1";
            //ddl = (DropDownList)this.Master.FindControl("Content").FindControl("myNewTable").FindControl("DropDownList5");
            //ddl.SelectedValue = "-1";
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
        public void data()
        {

            ////// senno,name,fathername,sex,dob,homedistrictid,category,subcat,cadre,cadresenno,doapp,dojoining,doconfirmation,mainQ,mainS,lavel,couplegpf,enquiry,laddress,paddress,remark,userid,lastupdatedtime,hostipaddress,postingstatus,orderno,currentdate,cadrestatus,orderby
            ////cl.ds = cl.DataFill("select senno,name,fathername,sex,convert(varchar,dob,101)as dob,homedistrictid,catid ,scatid ,cadreid,cadresenno,convert(varchar,doapp,101)as doapp,convert(varchar,dojoining,101)as dojoining,convert(varchar,doconfirmation,101)as doconfirmation,couplegpf,enquiry,laddress,paddress,remark,userid,lastupdatedtime,hostipaddress,postingstatus,orderno,currentdate,cadrestatus,orderby from personaldetails where senno='" + Request.QueryString["sennob"] + "'  ");
            ////if (cl.ds.Tables[0].Rows.Count > 0)
            ////{
            ////    if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        Gpfno.Text = cl.ds.Tables[0].Rows[0][0].ToString();
            ////    }
            ////    else
            ////    {
            ////        Gpfno.Text = "";
            ////    }

            ////    Gpfno.Enabled = false;
            ////    if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        Name.Text = cl.ds.Tables[0].Rows[0][1].ToString();                            
            ////    }
            ////    else
            ////    {
            ////        Name.Text = "";
            ////    }
            ////    if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        fhname.Text = cl.ds.Tables[0].Rows[0][2].ToString(); 
            ////    }
            ////    else
            ////    {
            ////        fhname.Text = "";
            ////    }

            ////    if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        Dsex.SelectedIndex = Dsex.Items.IndexOf(Dsex.Items.FindByValue(cl.ds.Tables[0].Rows[0][3].ToString()));
            ////    }
            ////    else
            ////    {
            ////        Dsex.SelectedIndex = 0;
            ////    }
            ////    if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        //Dob.Text = cl.ds.Tables[0].Rows[0][4].ToString();
            ////    }
            ////    else
            ////    {
            ////        DB1.SelectedIndex = 0; DB2.SelectedIndex = 0; DB3.SelectedIndex = 0;
            ////    }
            ////    if (!(cl.ds.Tables[0].Rows[0][5].ToString().Equals(System.DBNull.Value)))
            ////        {
            ////            DhomeD.SelectedIndex = DhomeD.Items.IndexOf(DhomeD.Items.FindByValue(cl.ds.Tables[0].Rows[0][5].ToString()));
            ////        }
            ////    else
            ////        {
            ////            DhomeD.SelectedIndex = 0;
            ////        }
            ////    if (!(cl.ds.Tables[0].Rows[0][6].ToString().Equals(System.DBNull.Value)))
            ////        {
            ////            Dcateg.SelectedIndex = Dcateg.Items.IndexOf(Dcateg.Items.FindByValue(cl.ds.Tables[0].Rows[0][6].ToString()));
            ////        }
            ////    else
            ////        {
            ////            Dcateg.SelectedIndex = 0;
            ////        }

            ////     if (!(cl.ds.Tables[0].Rows[0][7].ToString().Equals(System.DBNull.Value)))
            ////        {
            ////            Dsubcat.SelectedIndex = Dsubcat.Items.IndexOf(Dsubcat.Items.FindByValue(cl.ds.Tables[0].Rows[0][7].ToString()));
            ////        }
            ////     else
            ////        {
            ////            Dsubcat.SelectedIndex = 0;
            ////        }
            ////     if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
            ////        {
            ////        DCad.SelectedIndex = DCad.Items.IndexOf(DCad.Items.FindByValue(cl.ds.Tables[0].Rows[0][8].ToString()));
            ////         }
            ////     else
            ////         {
            ////        DCad.SelectedIndex = 0;
            ////        }
            ////        if (!(cl.ds.Tables[0].Rows[0][8].ToString().Equals(System.DBNull.Value)))
            ////        {
            ////            CSN.Text = cl.ds.Tables[0].Rows[0][9].ToString();

            ////        }
            ////        else
            ////        {
            ////            CSN.Text = "";
            ////        }
            ////        if (!(cl.ds.Tables[0].Rows[0][10].ToString().Equals(System.DBNull.Value)))
            ////        {
            ////            //doa.Text = cl.ds.Tables[0].Rows[0][10].ToString();
            ////        }

            ////        else
            ////        {
            ////            DA1.SelectedIndex = 0; DA2.SelectedIndex = 0; DA3.SelectedIndex = 0;
            ////        }

            ////    if (!(cl.ds.Tables[0].Rows[0][11].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////       // dojs.Text = cl.ds.Tables[0].Rows[0][11].ToString();
            ////    }
            ////    else
            ////    {
            ////        DJ1.SelectedIndex = 0; DJ2.SelectedIndex = 0; DJ3.SelectedIndex = 0;
            ////    }

            ////    if (!(cl.ds.Tables[0].Rows[0][12].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////       // doc.Text = cl.ds.Tables[0].Rows[0][12].ToString();
            ////    }
            ////    else
            ////    {
            ////        DC1.SelectedIndex = 0; DC2.SelectedIndex = 0; DC3.SelectedIndex = 0;
            ////    }

            ////    //if (!(cl.ds.Tables[0].Rows[0][13].ToString().Equals(System.DBNull.Value)))
            ////    //{
            ////    //    Dmqual.SelectedIndex = Dmqual.Items.IndexOf(Dmqual.Items.FindByValue(cl.ds.Tables[0].Rows[0][13].ToString()));
            ////    //}
            ////    //else
            ////    //{
            ////    //    Dmqual.SelectedIndex = 0;
            ////    //}

            ////    //if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
            ////    //{
            ////    //    Dmsub.SelectedIndex = Dmsub.Items.IndexOf(Dmsub.Items.FindByValue(cl.ds.Tables[0].Rows[0][14].ToString()));
            ////    //}
            ////    //else
            ////    //{
            ////    //    Dmsub.SelectedIndex = 0;
            ////    //}

            ////    if (!(cl.ds.Tables[0].Rows[0][13].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        Cgpf.Text = cl.ds.Tables[0].Rows[0][13].ToString();
            ////    }
            ////    else
            ////    {
            ////        Cgpf.Text = "";
            ////    }

            ////    if (!(cl.ds.Tables[0].Rows[0][14].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        Cenq.Text = cl.ds.Tables[0].Rows[0][14].ToString();
            ////        
            ////    }
            ////    else
            ////    {
            ////        
            ////    }

            ////    if (!(cl.ds.Tables[0].Rows[0][15].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        ladd.Text = cl.ds.Tables[0].Rows[0][15].ToString();
            ////    }
            ////    else
            ////    {
            ////        ladd.Text = "";
            ////    }
            ////    if (!(cl.ds.Tables[0].Rows[0][16].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        padd.Text = cl.ds.Tables[0].Rows[0][16].ToString();
            ////    }
            ////    else
            ////    {
            ////        padd.Text = "";
            ////    }
            ////    if (!(cl.ds.Tables[0].Rows[0][17].ToString().Equals(System.DBNull.Value)))
            ////    {
            ////        remark.Text = cl.ds.Tables[0].Rows[0][17].ToString();
            ////    }
            ////    else
            ////    {
            ////        remark.Text = "";
            ////    }
            ////    s1.Enabled = false;
            ////    Up.Visible = true;



            //}
        }


        protected void QSsave_Click(object sender, EventArgs e)
        {
            qual();
            Sstudy();
        }

        public void Sstudy()
        {
            cl.ds = cl.DataFill("SELECT '(' + Qualification.QuaName + ',' + specialization.spname + ')' AS st FROM qual_det INNER JOIN  Qualification ON qual_det.qid = Qualification.QuaId INNER JOIN  specialization ON qual_det.sid = specialization.spid where qual_det.idno ='" + Convert.ToInt32(maxid.Text) + "'");//
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
            cl.ds = cl.DataFill("SELECT isnull(MAX(qid_serial),0)+ 1 FROM qual_det");
            Qmes.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }

        public void qual()
        {
            try
            {
                //maxpic();
                maxpicQ();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into qual_det(qid_serial,idno,senno,qid,sid)values(@qid_serial,@idno,@senno,@qid,@sid)", cl.upcon);
                cmd.Parameters.Add("@qid_serial", SqlDbType.Int, 4).Value = Convert.ToInt32(Qmes.Text);
                cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);//.Replace("\'", "\'\'").Trim()
                cmd.Parameters.Add("@senno", SqlDbType.VarChar, 250).Value = this.Gpfno.Text.Replace("\'", "\'\'").Trim();
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

        public void otherstatesub()
        {
            try
            {
                cl.ds = cl.DataFill("SELECT isnull(MAX(sen),0)+ 1 FROM otherhomedistrict");
                Qmes.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("insert into otherhomedistrict(sen,senno,idno,hname)values(@sen,@senno,@idno,@hname)", cl.upcon);
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
        protected void OTSTATESUBMIT_Click(object sender, EventArgs e)
        {
            otherstatesub();
        }
       
        protected void phone_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/Option.aspx");
        }
    }
}