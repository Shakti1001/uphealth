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

namespace NewWebApp.Administrator
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        //SqlDataAdapter da;
        DataSet ds = new DataSet();
        EncDec EncDec = new EncDec();
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UID.Text = Request.QueryString["useid"];

            }
            //   if(
        }
        public void Userlistl()
        {
            int j;
            cl.ds = cl.DataFill("SELECT     userlavel.ulname, Ucreate.username, Ucreate.userid,hospitaldistrict.districtname, Designation.designame, Ucreate.R, Ucreate.A, Ucreate.D, Ucreate.E FROM         Ucreate INNER JOIN    userlavel ON Ucreate.lavel = userlavel.ulid INNER JOIN  Designation ON Ucreate.u_desig = designation.Desigid INNER JOIN  hospitaldistrict ON Ucreate.DisId = hospitaldistrict.districtid ORDER BY userlavel.ulname,ucreate.username");// AND postingdetails.dorelieve IS NULL)");

            if (cl.ds.Tables[0].Rows.Count > 0)//SlateGray
            {
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.SlateGray;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "Serial No";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "User Lavel";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "User Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "User ID";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "User District";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "User Designation";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "User Permission";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);
                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    TableCell tcell11 = new TableCell();
                    tcell11.BorderWidth = 1;
                    //tcell11.BorderColor = System.Drawing.Color.SlateGray;
                    tcell11.ForeColor = System.Drawing.Color.Black;
                    tcell11.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcell11);

                    TableCell tcell21 = new TableCell();
                    tcell21.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcell21.BorderWidth = 1;
                    //tcell21.BorderColor = System.Drawing.Color.SlateGray;
                    tcell21.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell21);

                    TableCell tcell31 = new TableCell();
                    tcell31.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcell31.BorderWidth = 1;
                    //tcell31.BorderColor = System.Drawing.Color.SlateGray;
                    tcell31.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell31);


                    TableCell tcell41 = new TableCell();
                    tcell41.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcell41.BorderWidth = 1;
                    //tcell41.BorderColor = System.Drawing.Color.SlateGray;
                    tcell41.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell41);
                    tcell41.Text = ("<a href=\'ChangePassword.aspx?useid=" + (cl.ds.Tables[0].Rows[j][2].ToString() + ("\'>" + (" (" + (tcell41.Text + ")</a>")))));

                    TableCell tcell51 = new TableCell();
                    tcell51.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcell51.BorderWidth = 1;
                    //tcell51.BorderColor = System.Drawing.Color.SlateGray;
                    tcell51.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell51);


                    TableCell tcell61 = new TableCell();
                    tcell61.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcell61.BorderWidth = 1;
                    //tcell61.BorderColor = System.Drawing.Color.SlateGray;
                    tcell61.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell61);

                    TableCell tcell71 = new TableCell();
                    string pr, pa, pd, pe;
                    if (!(cl.ds.Tables[0].Rows[j][5].ToString().Equals(System.DBNull.Value)))
                    {
                        pr = cl.ds.Tables[0].Rows[j][5].ToString();
                        if (pr == "1")
                        {
                            pr = "Read";
                        }
                        else
                        {
                            pr = "-";
                        }

                    }
                    else
                    {
                        pr = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][6].ToString().Equals(System.DBNull.Value)))
                    {
                        pa = cl.ds.Tables[0].Rows[j][6].ToString();
                        if (pa == "1")
                        {
                            pa = "ADD";
                        }
                        else
                        {
                            pa = "-";
                        }

                    }
                    else
                    {
                        pa = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][7].ToString().Equals(System.DBNull.Value)))
                    {
                        pd = cl.ds.Tables[0].Rows[j][7].ToString();
                        if (pd == "1")
                        {
                            pd = "DELETE";
                        }
                        else
                        {
                            pd = "-";
                        }

                    }
                    else
                    {
                        pd = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][8].ToString().Equals(System.DBNull.Value)))
                    {
                        pe = cl.ds.Tables[0].Rows[j][8].ToString();
                        if (pe == "1")
                        {
                            pe = "EDIT";
                        }
                        else
                        {
                            pe = "-";
                        }
                    }
                    else
                    {
                        pe = "";
                    }
                    tcell71.Text = pr + "/" + pa + "/" + pe + "/" + pd;
                    tcell71.BorderWidth = 1;
                    //tcell71.BorderColor = System.Drawing.Color.SlateGray;
                    tcell71.ForeColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcell71);
                    Table1.Rows.Add(rw1);

                }
            }
        }

        public void Userlist()
        {
            int j;
            cl.ds = cl.DataFill("SELECT     userlavel.ulname, Ucreate.username, Ucreate.userid,hospitaldistrict.districtname, Designation.designame, Ucreate.R, Ucreate.A, Ucreate.D, Ucreate.E FROM         Ucreate INNER JOIN    userlavel ON Ucreate.lavel = userlavel.ulid INNER JOIN  Designation ON Ucreate.u_desig = designation.Desigid INNER JOIN  hospitaldistrict ON Ucreate.DisId = hospitaldistrict.districtid ORDER BY userlavel.ulname,ucreate.username");// AND postingdetails.dorelieve IS NULL)");

            if (cl.ds.Tables[0].Rows.Count > 0)//SlateGray
            {
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.SlateGray;
                rw.BackColor = System.Drawing.Color.BurlyWood;
                rw.ForeColor = System.Drawing.Color.Maroon;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "Serial No";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;//  tcell0.ForeColor = System.Drawing.Color.Black;          
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "User Lavel";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "User Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "User ID";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "User District";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "User Designation";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "User Permission";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell6);
                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.Maroon;
                    rw1.BackColor = System.Drawing.Color.LemonChiffon;

                    TableCell tcell11 = new TableCell();
                    tcell11.BorderWidth = 1;
                    tcell11.Text = Convert.ToString(j);
                    rw1.Cells.Add(tcell11);

                    TableCell tcell21 = new TableCell();
                    tcell21.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcell21.BorderWidth = 1;
                    rw1.Cells.Add(tcell21);

                    TableCell tcell31 = new TableCell();
                    tcell31.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcell31.BorderWidth = 1;
                    rw1.Cells.Add(tcell31);


                    TableCell tcell41 = new TableCell();
                    tcell41.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcell41.BorderWidth = 1;
                    rw1.Cells.Add(tcell41);
                    tcell41.Text = ("<a href=\'ChangePassword.aspx?useid=" + (cl.ds.Tables[0].Rows[j][2].ToString() + ("\'>" + (" (" + (tcell41.Text + ")</a>")))));

                    TableCell tcell51 = new TableCell();
                    tcell51.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcell51.BorderWidth = 1;
                    rw1.Cells.Add(tcell51);


                    TableCell tcell61 = new TableCell();
                    tcell61.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcell61.BorderWidth = 1;
                    rw1.Cells.Add(tcell61);

                    TableCell tcell71 = new TableCell();
                    string pr, pa, pd, pe;
                    if (!(cl.ds.Tables[0].Rows[j][5].ToString().Equals(System.DBNull.Value)))
                    {
                        pr = cl.ds.Tables[0].Rows[j][5].ToString();
                        if (pr == "1")
                        {
                            pr = "Read";
                        }
                        else
                        {
                            pr = "-";
                        }

                    }
                    else
                    {
                        pr = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][6].ToString().Equals(System.DBNull.Value)))
                    {
                        pa = cl.ds.Tables[0].Rows[j][6].ToString();
                        if (pa == "1")
                        {
                            pa = "ADD";
                        }
                        else
                        {
                            pa = "-";
                        }

                    }
                    else
                    {
                        pa = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][7].ToString().Equals(System.DBNull.Value)))
                    {
                        pd = cl.ds.Tables[0].Rows[j][7].ToString();
                        if (pd == "1")
                        {
                            pd = "DELETE";
                        }
                        else
                        {
                            pd = "-";
                        }

                    }
                    else
                    {
                        pd = "";
                    }
                    if (!(cl.ds.Tables[0].Rows[j][8].ToString().Equals(System.DBNull.Value)))
                    {
                        pe = cl.ds.Tables[0].Rows[j][8].ToString();
                        if (pe == "1")
                        {
                            pe = "EDIT";
                        }
                        else
                        {
                            pe = "-";
                        }
                    }
                    else
                    {
                        pe = "";
                    }
                    tcell71.Text = pr + "/" + pa + "/" + pe + "/" + pd;
                    tcell71.BorderWidth = 1;
                    rw1.Cells.Add(tcell71);
                    Table1.Rows.Add(rw1);

                }
            }
        }
        public void change()
        {
            if (Conp.Text != Newp.Text)
            {
                Label3.Visible = true;
                Label3.Text = "Please Check the password";
            }
            else
            {

                try
                {
                    cl.cmd = cl.InsertDB("update Ucreate set upass='" + EncDec.EncryptRSA(Conp.Text) + "', lastupdatedtime='" + System.DateTime.Now + "' where userid='" + UID.Text + "'");
                    Label3.Visible = true;
                    Label3.Text = "Password has been Changed successfully";
                }
                catch (Exception e)
                {
                    //Response.Write(e.Message);
                    Label3.Visible = true;
                    Label3.Text = e.Message + "error";
                    Label3.Text = "Technical prb";

                }
            }

        }
        protected void Changep_Click(object sender, EventArgs e)
        {


            checkpass();

            //Label3.Visible = true;
            //Label3.Text = "your password have been successfully changed";
        }
        protected void Changeper_Click(object sender, EventArgs e)
        {
            try//upid, @upid,
            {
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("Update Ucreate set R=@R,A=@A,D=@D,E=@E where userid='" + UID.Text + "'", cl.upcon);
                if (R.Checked != true)
                {
                    cmd.Parameters.Add("@R", SqlDbType.VarChar, 1).Value = "0";
                }
                else
                {
                    cmd.Parameters.Add("@R", SqlDbType.VarChar, 1).Value = "1";
                }
                //cmd.Parameters.Add("@upid", SqlDbType.Int, 4).Value = UP.SelectedItem.Value;
                if (A.Checked != true)
                {
                    cmd.Parameters.Add("@A", SqlDbType.VarChar, 1).Value = "0";
                }
                else
                {
                    cmd.Parameters.Add("@A", SqlDbType.VarChar, 1).Value = "1";
                }
                if (D.Checked != true)
                {
                    cmd.Parameters.Add("@D", SqlDbType.VarChar, 1).Value = "0";
                }
                else
                {
                    cmd.Parameters.Add("@D", SqlDbType.VarChar, 1).Value = "1";
                }
                if (E.Checked != true)
                {
                    cmd.Parameters.Add("@E", SqlDbType.VarChar, 1).Value = "0";
                }
                else
                {
                    cmd.Parameters.Add("@E", SqlDbType.VarChar, 1).Value = "1";
                }
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Label2.Visible = true;
                    Label2.Text = "User Permission have been successfully changed";

                }
                else
                {

                    Label2.Text = "Technical Problem";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();

            }
        }
        protected void UID_TextChanged(object sender, EventArgs e)
        {


        }
        public void checkpass()
        {
            cl.ds = cl.DataFill("SELECT upass FROM Ucreate where userid='" + UID.Text + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    if (Oldp.Text == EncDec.DecryptRSA(cl.ds.Tables[0].Rows[0][0].ToString()))
                    {
                        //if (EncDec.EncryptRSA(Newp.Text) == EncDec.EncryptRSA(Conp.Text))
                        //{
                        //    //cl.ds = cl.DataFill("update Ucreate set upass='" + EncDec.EncryptRSA(Conp.Text) + "'");
                        //}
                        Label3.Visible = true;
                        Label3.Text = "your password is correct";
                        change();
                    }
                    else if (Oldp.Text != EncDec.DecryptRSA(cl.ds.Tables[0].Rows[0][0].ToString()))
                    {
                        Label3.Visible = true;
                        Label3.Text = "your password XXXX";
                    }
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "There is no password";
                }
            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "There is no User";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Panel4.Visible = true;
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel4.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel4.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            R.Checked = false;
            A.Checked = false;
            D.Checked = false;
            E.Checked = false;

            cl.ds = cl.DataFill("SELECT upass, R, A, D, E FROM Ucreate where userid='" + UID.Text + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Label3.Text = "";
                Label3.Visible = true;
                Label3.Text = EncDec.DecryptRSA(cl.ds.Tables[0].Rows[0][0].ToString());
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    if (cl.ds.Tables[0].Rows[0][1].ToString() == "1")
                        R.Checked = true;
                    else if (cl.ds.Tables[0].Rows[0][1].ToString() == "0")
                        R.Checked = false;
                }
                else
                {
                    R.Checked = false;
                }

                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    if (cl.ds.Tables[0].Rows[0][2].ToString() == "1")
                        A.Checked = true;
                    else if (cl.ds.Tables[0].Rows[0][2].ToString() == "0")
                        A.Checked = false;
                }
                else
                {
                    A.Checked = false;
                }
                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    if (cl.ds.Tables[0].Rows[0][3].ToString() == "1")
                        D.Checked = true;
                    else if (cl.ds.Tables[0].Rows[0][3].ToString() == "0")
                        D.Checked = false;
                }
                else
                {
                    D.Checked = false;
                }

                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    if (cl.ds.Tables[0].Rows[0][4].ToString() == "1")
                        E.Checked = true;
                    else if (cl.ds.Tables[0].Rows[0][4].ToString() == "0")
                        E.Checked = false;
                }
                else
                {
                    E.Checked = false;
                }
            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "There is no User";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            cl.ds = cl.DataFill("SELECT upass FROM Ucreate where userid='" + UID.Text + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Label4.Text = "";
                Label4.Visible = true;
                Label4.Text = EncDec.DecryptRSA(cl.ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                Label4.Text = "Check User Id";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                cl.upcon.Open();
                SqlCommand cmd = new SqlCommand("Delete from Ucreate  where userid='" + UID.Text + "'", cl.upcon);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Label4.Visible = true;
                    Label4.Text = "User Deleted ";

                }
                else
                {

                    Label4.Text = "Technical Problem";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.Message);
            }
            finally
            {
                cl.upcon.Close();

            }

        }
       
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Userlist();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Administrator/Ad1.aspx");
        }
    }
}