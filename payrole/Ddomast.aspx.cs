using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NewWebApp.payrole
{
    public partial class Ddomast : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usecheck();

                gridbind();
                filld();

            }
        }
        public void gridbind()
        {

            cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy,h_supw_name FROM         hospitallist WHERE     (districtid like'" + Uidt.Text + "')AND (ddoid IS NULL) order by divname,  districtname,htype");
            GridView1.DataSource = cl.ds;
            GridView1.DataBind();
        }
        public void filld()
        {
            cl.ds = cl.DataFill("SELECT ddoname, ddoidd FROM Districtddo  WHERE     (ddodistrictid like'" + Uidt.Text + "')ORDER BY ddoname");
            DDONAME.DataSource = cl.ds;
            DDONAME.DataTextField = "ddoname";
            DDONAME.DataValueField = "ddoidd";
            DDONAME.DataBind();
            DDONAME.Items.Insert(0, new ListItem("--select--"));
        }

        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        public void vbbbb()
        {
            //Dim i As Integer
            //Dim chk As CheckBox
            //Dim rbl As RadioButtonList
            //Dim txt As TextBox
            //Dim lbl As Label
            //Dim qry As String
            //conn.Open()
            //'Accessing the value of Hidden field
            //Dim deptname As String = Me.Hidedept.Value
            //Dim hiderpn As String = Me.Hiderpn.Value

            //Try
            //    transfer_date = FormatDateTime(Now(), DateFormat.ShortDate)
            //    transfer_date = Mid(transfer_date, 4, 2) + "/" + Mid(transfer_date, 1, 2) + "/" + Mid(transfer_date, 7, 4)
            //    For i = 0 To Me.applicationgrid.Rows.Count - 1
            //        chk = Me.applicationgrid.Rows(i).FindControl("chk")
            //        If chk.Checked = True Then
            //            rbl = Me.applicationgrid.Rows(i).FindControl("radio")
            //            txt = Me.applicationgrid.Rows(i).FindControl("txt")
            //            lbl = Me.applicationgrid.Rows(i).FindControl("lbl")
            //            qry = "update registration set app_status='P',app_trns_dt='" & transfer_date & "',trns_todept='" & deptname & "',dept_rep_name='" & hiderpn & "' WHERE registration_no ='" & lbl.Text & " '"
            //            adp = New SqlDataAdapter()
            //            adp.UpdateCommand = New SqlCommand(qry, conn)
            //            adp.UpdateCommand.ExecuteNonQuery()
            //        End If
            //    Next
            //Catch ex As Exception
            //    Response.Write(ex.ToString())
            //End Try
            //Server.Transfer("applicationsend.aspx", False)
        }

        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(ddoid),0)+ 1 FROM hospitalname");
            maxidw.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }

        public void DSadd()
        {//UPDATE    DDDDO SET              ddoname = 'CMO' + ' ' + ddoname
            maxpic();
            int i;
            CheckBox chkH;
            try
            {
                for (i = 0; i <= this.GridView1.Rows.Count - 1; i++)
                {
                    chkH = (CheckBox)GridView1.Rows[i].FindControl("chkH");
                    if (chkH.Checked == true)
                    {
                        cl.cmd = cl.InsertDB("update hospitalname set h_supw_name='" + this.DAT.Text + "',ddoid='" + DDONAME.SelectedItem.Value + "' where hname='" + chkH.Text + "'");//,h_spname='" + this.DAT.Text + "'
                        //cl.cmd = cl.InsertDB("update hospitalname set h_ddoid='" + maxidw.Text + "'  where hname='" + chkH.Text + "'");
                        Label1.Visible = true;
                        Label1.Text = "Added Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                //Response.Write("Error :" + ex.Message);
                Label1.Visible = true;
                Label1.Text = ("Error :" + ex.Message);
            }
            finally
            {
                gridbind();
            }


        }

        public void DDOadd()
        {
            try
            {
                //maxpic();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into salDMas (ddocode,ddoname,address)Values(@max,@ddoname,@address)", con);
                cmd.Parameters.Add("@max", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                cmd.Parameters.Add("@ddoname", SqlDbType.VarChar, 75).Value = DNT.Text;
                cmd.Parameters.Add("@address", SqlDbType.VarChar, 200).Value = DAT.Text;
                if (DNT.Text != "" || DAT.Text != "")
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Added Successfully";
                        DNT.Text = "";
                        DAT.Text = "";
                    }


                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Select the Correct One";
                }
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = ("Error :" + ex.Message);
            }
            finally
            {
                con.Close();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DSadd();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //GridView1.Dispose();       
            //GridView2.Dispose();
        }

       
        protected void DDONAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDONAME.SelectedIndex != 0)
            {
                DAT.Text = DDONAME.SelectedItem.Text;
            }
            else
            {
                DAT.Text = "";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payrole/payrolehome.aspx");
        }
    }
}