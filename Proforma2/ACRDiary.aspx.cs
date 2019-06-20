using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Data;

namespace NewWebApp.Proforma2
{
    public partial class ACRDiary : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        Class1 c = new Class1();
        public SqlDataAdapter da;


        public void dfill()
        {


            c.ddl(rviewdeg, "SELECT  desigid,designame FROM designation ", "designame", "desigid");
            c.ddl(acpdeg, "SELECT  desigid,designame FROM designation", "designame", "desigid");
            c.ddl(rviewgrade, "select * from ACRgrade", "grade", "gradeid");
            c.ddl(acpgrade, "select * from ACRgrade", "grade", "gradeid");
            c.ddl(rviewdistrict, "Select districtid,districtname from hospitaldistrict order by districtname ", "districtname", "districtid");
            c.ddl(acpdistrict, "Select districtid,districtname from hospitaldistrict order by districtname ", "districtname", "districtid");
            c.ddl(initiategrade, "select * from ACRgrade", "grade", "gradeid");
            c.ddl(initiatedeg, "SELECT  desigid,designame FROM designation", "designame", "desigid");
            c.ddl(initiatedistrict, "Select districtid,districtname from hospitaldistrict order by districtname ", "districtname", "districtid");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); //jump to first page for login
                }
                Fnamet.Text = (string)Session["fullname"];
                Uidt.Text = (string)Session["iduser"];

                dfill();

                cl.ds = cl.DataFill("SELECT idno, senno,name FROM personaldetails where idno='" + Request.QueryString["idno"] + "'");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    this.idno.Text = cl.ds.Tables[0].Rows[0][0].ToString();

                    this.name.Text = cl.ds.Tables[0].Rows[0][2].ToString();


                }
                else
                {

                }
            }


        }








        public void parameter(string str)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(str, cl.upcon);


                cl.upcon.Open();
                cmd.Parameters.AddWithValue("@Idno", Convert.ToInt32(Request.QueryString["idno"]));



                cmd.Parameters.AddWithValue("@fy1", fy1.Text);
                cmd.Parameters.AddWithValue("@fy2", fy2.Text);



                cmd.Parameters.AddWithValue("@appname", this.name.Text);

                cmd.Parameters.AddWithValue("@rviewname", rviewname.Text);
                cmd.Parameters.AddWithValue("@rviewdeg", rviewdeg.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@rviewposting", rviewposting.Text);
                cmd.Parameters.AddWithValue("@rviewdistrict", initiatedistrict.SelectedItem.Text);

                if (rviewdd.SelectedIndex != 0 && rviewmm.SelectedIndex != 0 && rviewyy.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@rviewdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(rviewdd.SelectedItem.Text + "/" + rviewmm.SelectedItem.Text + "/" + rviewyy.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (rviewdd.SelectedIndex == 0 || rviewmm.SelectedIndex == 0 || rviewyy.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@rviewdate", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@rviewremark", rviewremark.Text);
                cmd.Parameters.AddWithValue("@grade", rviewgrade.SelectedItem.Text);

                cmd.Parameters.AddWithValue("@acpname", acpname.Text);
                cmd.Parameters.AddWithValue("@acpdeg", acpdeg.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@acpdistrict", rviewdistrict.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@acpposting", acpposting.Text);

                if (acpdd.SelectedIndex != 0 && acpmm.SelectedIndex != 0 && acpyy.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@acpdate", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(acpdd.SelectedItem.Text + "/" + acpmm.SelectedItem.Text + "/" + acpyy.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (acpdd.SelectedIndex == 0 || acpmm.SelectedIndex == 0 || acpyy.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@acpdate", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@fgrade", acpgrade.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@acpremark", acpremark.Text);
                cmd.Parameters.Add("@currdate", SqlDbType.DateTime, 8).Value = System.DateTime.Today;
                cmd.Parameters.Add("@hostipaddress", SqlDbType.NVarChar, 50).Value = Request.ServerVariables["REMOTE_ADDR"];



                cmd.Parameters.AddWithValue("@initiatedistrict", initiatedistrict.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@initiateposting", initiateposting.Text);
                cmd.Parameters.AddWithValue("@initiatename", initiatename.Text);
                cmd.Parameters.AddWithValue("@initiatedeg", initiatedeg.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@initiateremark", initiateremark.Text);
                cmd.Parameters.AddWithValue("@initiategrade", initiategrade.SelectedItem.Text);
                if (dd.SelectedIndex != 0 && rviewmm.SelectedIndex != 0 && rviewyy.SelectedIndex != 0)
                {
                    cmd.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = Convert.ToDateTime(dd.SelectedItem.Text + "/" + mm.SelectedItem.Text + "/" + yy.SelectedItem.Text);// Convert.ToDateTime(dojs.Text);
                }
                else if (dd.SelectedIndex == 0 || mm.SelectedIndex == 0 || yy.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@date", DBNull.Value);
                }

                cmd.ExecuteNonQuery();

                fy1.Text = "";
                fy2.Text = "";
                initiatename.Text = "";
                initiatedeg.SelectedIndex = 0;
                initiategrade.SelectedIndex = 0;
                initiateposting.Text = "";
                initiatedistrict.SelectedIndex = 0;
                rviewname.Text = "";
                acpname.Text = "";
                rviewremark.Text = "";
                rviewgrade.SelectedIndex = 0;
                acpgrade.SelectedIndex = 0;

                acpremark.Text = "";

                acpdeg.SelectedIndex = 0;
                rviewdeg.SelectedIndex = 0;
                initiateremark.Text = "";
                initiatedistrict.SelectedIndex = 0;
                rviewdistrict.SelectedIndex = 0;
                acpdistrict.SelectedIndex = 0;
                initiateposting.Text = "";
                rviewposting.Text = "";
                acpposting.Text = "";
                setdd();
                //Response.Redirect("~/savepage.aspx");
            }

            catch
            {



            }
            finally
            {

                cl.cmd = cl.InsertDB("update personaldetails set lastupdatedtime='" + System.DateTime.Now + "',hostipaddress='" + Request.ServerVariables["REMOTE_ADDR"] + "',modifieruserid='" + (string)Session["iduser"] + "' where idno='" + Request.QueryString["idno"] + "'");

            }
            GridView1.DataBind();


        }
        protected void SAVE_Click(object sender, EventArgs e)
        {

            string str = "insert into detailACR (idno,fy1,fy2,appname, initiatename,initiatedeg,initiateposting,initiatedistrict,initiateremark,initiategrade,initiatedate,rviewname,rviewdeg,rviewdistrict,rviewposting,rviewdate,rviewremark,grade,acpname,acpdeg,acpdistrict,acpposting,acpdate,fgrade,acpremark,currdate,hostipaddress) values (@idno,@fy1,@fy2,@appname,@initiatename,@initiatedeg,@initiateposting,@initiatedistrict,@initiateremark,@initiategrade,@date,@rviewname,@rviewdeg,@rviewdistrict,@rviewposting,@rviewdate,@rviewremark,@grade,@acpname,@acpdeg,@acpdistrict,@acpposting,@acpdate,@fgrade,@acpremark,@currdate,@hostipaddress)";

            parameter(str);

            Response.Write("<script>alert('ACR Save Successfully')</script>");
            //Response.Redirect("~/savepage.aspx");
            cl.upcon.Close();
        }

        public void setdd()
        {


            rviewdd.SelectedIndex = 0;
            rviewmm.SelectedIndex = 0;
            rviewyy.SelectedIndex = 0;

            acpdd.SelectedIndex = 0;
            acpmm.SelectedIndex = 0;
            acpyy.SelectedIndex = 0;

            dd.SelectedIndex = 0;
            mm.SelectedIndex = 0;
            yy.SelectedIndex = 0;
        }





        




        public string a { get; set; }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/Option.aspx");
        }
    }
}