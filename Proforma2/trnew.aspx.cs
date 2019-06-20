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
    public partial class trnew : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        //SqlConnection con = new SqlConnection(ClDatabase.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        public SqlDataAdapter da;



        protected void Page_Load(object sender, EventArgs e)
        {



            Response.Write(idno);

            if (!IsPostBack)
            {
                // cl.AddCalender(ref fdateImage, ref fdate);
                // cl.AddCalender(ref Imagecal, ref todate);
                // this.todate.Attributes.Add("ReadOnly", "True");
                // this.fdate.Attributes.Add("ReadOnly", "True");
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Administrator/login.aspx"); //jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];
                cl.ds = cl.DataFill("SELECT  trid, trname FROM trainingid order by trname ");
                DropDownList1.DataSource = cl.ds;
                DropDownList1.DataTextField = "trname";
                DropDownList1.DataValueField = "trid";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("--select--"));

                cl.ds = cl.DataFill("SELECT idno, senno,name FROM personaldetails where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    this.idno.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    //this.sen.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                    this.name.Text = cl.ds.Tables[0].Rows[0][2].ToString();

                }
                else
                {

                }
            }
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void SAVE_Click(object sender, EventArgs e)
        {

            string str = "insert into trainingdetail (idno,trid,trplace,fromdate,todate)values(@idno,@trid,@trplace,@fromdate,@todate)";

            parameter(str);
        }

        public void parameter(string str)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(str, cl.upcon);


                cl.upcon.Open();

                cmd.Parameters.AddWithValue("@Idno", Convert.ToInt32(Request.QueryString["idno"]));
                cmd.Parameters.AddWithValue("@trplace", trplace.Text);

                cmd.Parameters.AddWithValue("@trid", DropDownList1.SelectedItem.Value);

                if (fdd.SelectedIndex != 0 && fmm.SelectedIndex != 0 && fyy.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@fromdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(fdd.SelectedItem.Text + "/" + fmm.SelectedItem.Text + "/" + fyy.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (fdd.SelectedIndex == 0 || fmm.SelectedIndex == 0 || fyy.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@fromdate", DBNull.Value);
                }


                if (todd.SelectedIndex != 0 && tomm.SelectedIndex != 0 && toyy.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@todate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(todd.SelectedItem.Text + "/" + tomm.SelectedItem.Text + "/" + toyy.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);

                }


                else if (todd.SelectedIndex == 0 || tomm.SelectedIndex == 0 || toyy.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@todate", DBNull.Value);
                }


                //if ((cmd.Parameters.Add("@fromdate", SqlDbType.DateTime, 8).Value) > (cmd.Parameters.Add("@todate", SqlDbType.DateTime, 8).Value))
                //{
                //    Response.Write("<script>alert('From Date always greater then todate')</script>");
                //}
                //else
                //{
                //    
                //}
                // this.mesg.Text = "This training has been done by you";


                cmd.ExecuteNonQuery();
            }

            catch
            {
                trplace.Text = "";

                DropDownList1.SelectedIndex = 0;
                cl.upcon.Close();

                this.mesg.Text = "This training has been done by you";

                //Response.Write(" Error :" + ex.Message);


                Response.Write("<script>alert('Save Successfully')</script>");
                // cl.upcon.Close();
            }



            finally
            {
                GridView1.DataBind();
                cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "',hostipaddress='" + Request.ServerVariables["REMOTE_ADDR"] + "',modifieruserid='" + (string)Session["iduser"] + "' where idno='" + Request.QueryString["idno"] + "'");

            }
            GridView1.DataBind();
        }
        public void setdd()
        {
            fdd.SelectedIndex = 0;
            fmm.SelectedIndex = 0;
            fyy.SelectedIndex = 0;
            todd.SelectedIndex = 0;
            tomm.SelectedIndex = 0;
            toyy.SelectedIndex = 0;

        }
        protected void BACK_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Proforma2/Option.aspx");
        }
        protected void FSheet_Click(object sender, EventArgs e)
        {
            //Response.Redirect("proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");
            Server.Transfer("proforma1print.aspx?idno=" + Request.QueryString["idno"] + "");
        }

        public DropDownList DropdownList { get; set; }
    }
}