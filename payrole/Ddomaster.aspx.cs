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

namespace NewWebApp.payrole
{
    public partial class Ddomaster : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Fnamet.Text = (string)Session["fullname"];

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx"); ;//jump to first page for login
                }

                usecheck();
                //ddfill();
            }
        }
        public void usechecka()
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
        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
                cl.ds = cl.DataFill("SELECT DISTINCT divname, divid FROM         division ");
                DDiv.DataSource = cl.ds;
                DDiv.DataTextField = "divname";
                DDiv.DataValueField = "divid";
                DDiv.DataBind();
                DDiv.Items.Insert(0, new ListItem("--select--"));
                //****************

            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();

                    DDiv.Items.Insert(0, new ListItem("selected"));
                    cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where districtid=" + Uidt.Text + " ORDER BY districtname");
                    DDist.DataSource = cl.ds;
                    DDist.DataTextField = "districtname";
                    DDist.DataValueField = "districtid";
                    DDist.DataBind();
                    DDist.Items.Insert(0, new ListItem("--select--"));
                    //****************

                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        //SELECT DISTINCT division.divname, division.divid FROM         division INNER JOIN  hospitaldistrict ON division.divid = hospitaldistrict.divid WHERE     (hospitaldistrict.districtid LIKE '%')


        public void maxpic()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(ddoidd),0)+ 1 FROM Districtddo");
            maxid.Text = cl.ds.Tables[0].Rows[0][0].ToString();
        }

        protected void DDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            //****************
            cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict where divid=" + DDiv.SelectedItem.Value + " ORDER BY districtname");
            DDist.DataSource = cl.ds;
            DDist.DataTextField = "districtname";
            DDist.DataValueField = "districtid";
            DDist.DataBind();
            DDist.Items.Insert(0, new ListItem("--select--"));
            //****************
        }



        protected void DDist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            hospitaladd();
        }
        protected void maxid_TextChanged(object sender, EventArgs e)
        {

        }
        public void hospitaladd()
        {
            try
            {
                maxpic();
                if (DDist.SelectedIndex != 0 && DDONAMET.Text != "")
                {
                    cl.upcon.Open();
                    SqlCommand cmd = new SqlCommand("DDOadd", cl.upcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ddoidd", SqlDbType.Int, 4).Value = Convert.ToInt32(maxid.Text);
                    cmd.Parameters.Add("@ddodistrictid", SqlDbType.Int, 4).Value = DDist.SelectedItem.Value;
                    cmd.Parameters.Add("@ddoname", SqlDbType.VarChar, 200).Value = DDONAMET.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Added Successfully";
                        DDONAMET.Text = "";
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
                cl.upcon.Close();

            }
        }
       
        public void Hospname()
        {
            usechecka();
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {//SELECT     hospitaldistrict.districtname, Districtddo.ddoname FROM         Districtddo INNER JOIN hospitaldistrict ON Districtddo.ddodistrictid = hospitaldistrict.districtid ORDER BY hospitaldistrict.districtname
                cl.ds = cl.DataFill("SELECT     division.divname, hospitaldistrict.districtname, Districtddo.ddoname FROM         Districtddo INNER JOIN  hospitaldistrict ON Districtddo.ddodistrictid = hospitaldistrict.districtid INNER JOIN  division ON hospitaldistrict.divid = division.divid ORDER BY hospitaldistrict.districtname");

            }
            else
            {
                cl.ds = cl.DataFill("SELECT     division.divname, hospitaldistrict.districtname, Districtddo.ddoname FROM         Districtddo INNER JOIN  hospitaldistrict ON Districtddo.ddodistrictid = hospitaldistrict.districtid INNER JOIN  division ON hospitaldistrict.divid = division.divid WHERE     (districtid ='" + Uidt.Text + "') ORDER BY hospitaldistrict.districtname ");
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
                tcell1.Text = "Division Name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "District Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell2);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "DDO Name";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                rw.Cells.Add(tcell6);

                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.Black;
                    rw1.ForeColor = System.Drawing.Color.Maroon;
                    rw1.BackColor = System.Drawing.Color.LemonChiffon;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);
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
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk4);
                    Table1.Rows.Add(rw1);

                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Hospname();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
             Response.Redirect("~/payrole/payrolehome.aspx");
       
        }
    }
}