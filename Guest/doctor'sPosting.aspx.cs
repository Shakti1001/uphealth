using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace NewWebApp.Guest
{
    public partial class doctor_sPosting : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["DBCS"].ToString(); // connection string
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddfill();
            }
        }
       
        public void ddfill()
        {
            //usecheckD();
           /* cl.ds = cl.DataFill("SELECT distinct(districtname), districtid FROM hospitaldistrict   ORDER BY districtname");
            DDistrict.DataSource = cl.ds;
            DDistrict.DataTextField = "districtname";
            DDistrict.DataValueField = "districtid";
            DDistrict.DataBind();
            DDistrict.Items.Insert(0, new ListItem("--select--"));
            cl.ds.Clear();
            cl.ds.Dispose();
  */
            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand("SELECT distinct(districtname), districtid FROM hospitaldistrict   ORDER BY districtname", con); // table name 
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset
                DropDownList1.DataTextField = ds.Tables[0].Columns["districtname"].ToString(); // text field name of table dispalyed in dropdown
                DropDownList1.DataValueField = ds.Tables[0].Columns["districtid"].ToString();             // to retrive specific  textfield name 
                DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                DropDownList1.DataBind();  //binding dropdownlist
                DropDownList1.Items.Insert(0, new ListItem("--Select--"));

                SqlCommand com1 = new SqlCommand("SELECT distinct(htype), hid FROM hospitaltype ORDER BY htype", con); // table name 
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);  // fill dataset
                DropDownList2.DataTextField = ds1.Tables[0].Columns["htype"].ToString(); // text field name of table dispalyed in dropdown
                DropDownList2.DataValueField = ds1.Tables[0].Columns["hid"].ToString();             // to retrive specific  textfield name 
                DropDownList2.DataSource = ds1.Tables[0];      //assigning datasource to the dropdownlist
                DropDownList2.DataBind();  //binding dropdownlist
                DropDownList2.Items.Insert(0, new ListItem("--Select--"));

                SqlCommand com2 = new SqlCommand("select distinct hospitalname.hname,hospitalname.sno from hospitalname inner join hospitaldistrict on hospitalname.districtid=hospitaldistrict.districtid where hospitaldistrict.districtid like '%' order by hospitalname.hname", con); // table name 
                SqlDataAdapter da2 = new SqlDataAdapter(com2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);  // fill dataset
                DropDownList3.DataTextField = ds2.Tables[0].Columns["hname"].ToString(); // text field name of table dispalyed in dropdown
                DropDownList3.DataValueField = ds2.Tables[0].Columns["sno"].ToString();             // to retrive specific  textfield name 
                DropDownList3.DataSource = ds2.Tables[0];      //assigning datasource to the dropdownlist
                DropDownList3.DataBind();  //binding dropdownlist
                DropDownList3.Items.Insert(0, new ListItem("--Select--"));

                SqlCommand com3 = new SqlCommand("SELECT DISTINCT newpostid, newpostname FROM  post ORDER BY newpostid", con); // table name 
                SqlDataAdapter da3 = new SqlDataAdapter(com3);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);  // fill dataset
                DropDownList4.DataTextField = ds3.Tables[0].Columns["newpostname"].ToString(); // text field name of table dispalyed in dropdown
                DropDownList4.DataValueField = ds3.Tables[0].Columns["newpostid"].ToString();             // to retrive specific  textfield name 
                DropDownList4.DataSource = ds3.Tables[0];      //assigning datasource to the dropdownlist
                DropDownList4.DataBind();  //binding dropdownlist
                DropDownList4.Items.Insert(0, new ListItem("--Select--"));

                SqlCommand com4 = new SqlCommand("SELECT DISTINCT cadrename, cadreid FROM cadre ORDER BY cadreid", con); // table name 
                SqlDataAdapter da4 = new SqlDataAdapter(com4);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);  // fill dataset
                DropDownList5.DataTextField = ds4.Tables[0].Columns["cadrename"].ToString(); // text field name of table dispalyed in dropdown
                DropDownList5.DataValueField = ds4.Tables[0].Columns["cadreid"].ToString();             // to retrive specific  textfield name 
                DropDownList5.DataSource = ds4.Tables[0];      //assigning datasource to the dropdownlist
                DropDownList5.DataBind();  //binding dropdownlist
                DropDownList5.Items.Insert(0, new ListItem("--Select--"));

                SqlCommand com5 = new SqlCommand("SELECT distinct levelid, levelcode FROM lavel ORDER BY levelid", con); // table name 
                SqlDataAdapter da5 = new SqlDataAdapter(com5);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);  // fill dataset
                DropDownList6.DataTextField = ds5.Tables[0].Columns["levelcode"].ToString(); // text field name of table dispalyed in dropdown
                DropDownList6.DataValueField = ds5.Tables[0].Columns["levelid"].ToString();             // to retrive specific  textfield name 
                DropDownList6.DataSource = ds5.Tables[0];      //assigning datasource to the dropdownlist
                DropDownList6.DataBind();  //binding dropdownlist
                DropDownList6.Items.Insert(0, new ListItem("--Select--"));

            }
            catch (SqlException se)
            {

                Console.WriteLine(se);
            }
       
       
       

           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand com6 = new SqlCommand("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid ='" + DropDownList1.SelectedItem.Value + "') ORDER BY hospitalname.hname", con); // table name 
                SqlDataAdapter da6 = new SqlDataAdapter(com6);
                DataSet ds6 = new DataSet();
                da6.Fill(ds6);  // fill dataset

                DropDownList3.DataSource = ds6.Tables[0];
                DropDownList3.DataTextField = "hname";
                DropDownList3.DataValueField = "sno";
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, new ListItem("--select--"));
            }
           
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0)
            {

                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand com6 = new SqlCommand("SELECT DISTINCT hospitalname.hname, hospitalname.sno FROM hospitalname INNER JOIN   hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid WHERE     (hospitaldistrict.districtid ='" + DropDownList1.SelectedItem.Value + "' and hospitalname.htype='" + DropDownList2.SelectedItem.Value + "') ORDER BY hospitalname.hname", con); // table name 
                SqlDataAdapter da6 = new SqlDataAdapter(com6);
                DataSet ds6 = new DataSet();
                da6.Fill(ds6);  // fill dataset
               
                DropDownList3.DataSource = ds6.Tables[0];
                DropDownList3.DataTextField = "hname";
                DropDownList3.DataValueField = "sno";
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, new ListItem("--select--"));
            }

        }

        public void print()
        {
            string districtid, DHt, DHna, post, cad, lav;//divid,
            
            //***************DISTRICT****************
            if (this.DropDownList1.SelectedIndex != 0)
            { districtid = DropDownList1.SelectedItem.Value; }
            else { districtid = "N"; }
            //**************HOSPITAL TYPE*****************
            if (this.DropDownList2.SelectedIndex != 0)
            { DHt = DropDownList2.SelectedItem.Value; }
            else { DHt = "N"; }
            //**************HOSPITAL NAME*****************
            if (this.DropDownList3.SelectedIndex != 0)
            { DHna = DropDownList3.SelectedItem.Value; }
            else { DHna = "N"; }
            //****************POST***************
            if (this.DropDownList4.SelectedIndex != 0)
            { post = DropDownList4.SelectedItem.Value; }
            else { post = "N"; }
            //***************CADRE****************
            if (this.DropDownList5.SelectedIndex != 0)
            { cad = DropDownList5.SelectedItem.Value; }
            else { cad = "N"; }
            //***************LEVEL****************
            if (this.DropDownList6.SelectedIndex != 0)
            { lav = DropDownList6.SelectedItem.Value; }
            else { lav = "N"; }
           

            Response.Redirect("Currentlist.aspx?Dis=" + districtid + "&DT=" + DHt + "&HN=" + DHna + "&Post=" + post + "&cader=" + cad + "&lavel=" + lav + "");


        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            print();
        }
    }
}