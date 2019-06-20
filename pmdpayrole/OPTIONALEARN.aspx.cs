using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace NewWebApp.pmdpayrole
{
    public partial class OPTIONALEARN : System.Web.UI.Page
    {
        Class1 c = new Class1();
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pdata();
                earfill();
                this.GridView2.DataBind();
                Label1.Visible = false;
                Label2.Visible = false;
            }
        }
        public void pdata()
        {
            cl.ds = cl.DataFill("SELECT idno,name FROM pmdpersonaldetails where idno='" + Request.QueryString["idno"] + "'");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                this.idno.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                this.name.Text = cl.ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {

            }
        }
        public void earfill()
        {
            cl.ds = cl.DataFill("SELECT optearid, optearname FROM pay_optearmast ORDER BY optearname");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                ErD.DataSource = cl.ds;
                ErD.DataTextField = "optearname";
                ErD.DataValueField = "optearid";
                ErD.DataBind();
                ErD.Items.Insert(0, new ListItem("--select--"));
            }
            else
            {

            }
        }
        protected void saveear_Click(object sender, EventArgs e)
        {
            earsave();
        }

        public void maxpicEAR()
        {
            cl.ds = cl.DataFill("SELECT isnull(MAX(earoptid),0)+ 1 FROM pmd_pay_opt_earning ");
            ME.Text = cl.ds.Tables[0].Rows[0][0].ToString();

        }
        public void earsave()
        {
            if (Eramt.Text != "")
            {
                try
                {
                    maxpicEAR();
                    if (ConnectionState.Closed == cl.upcon.State)
                    {
                        cl.upcon.Open();
                        SqlCommand cmd = new SqlCommand("pmdaddOPTEAR", cl.upcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@earoptid", SqlDbType.Int, 4).Value = Convert.ToInt32(ME.Text);
                        if (this.ErD.SelectedIndex != 0)
                        {
                            cmd.Parameters.Add("@optearid", SqlDbType.Int, 4).Value = this.ErD.SelectedItem.Value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@earoptid", SqlDbType.Int, 4).Value = 0;
                        }
                        cmd.Parameters.Add("@idno", SqlDbType.Int, 4).Value = Request.QueryString["idno"];

                        if (Eramt.Text != "")
                        {
                            cmd.Parameters.Add("@optearamt", SqlDbType.Float, 8).Value = Convert.ToDouble(Eramt.Text);
                        }
                        else
                        {
                            cmd.Parameters.Add("@optearamt", SqlDbType.Int, 4).Value = 0;
                        }

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            Label1.Visible = true;
                            Label1.ForeColor = System.Drawing.Color.Gold;
                            Label1.Text = "Added Successfully";
                            Eramt.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.Gold;
                    Label1.Text = ("Error :" + ex.Message);
                }
                finally
                {
                    if (ConnectionState.Open == cl.upcon.State)
                    {
                        cl.upcon.Close();
                        this.GridView2.DataBind();
                        Label2.Visible = true;
                    }
                }
            }
        }
    }
}