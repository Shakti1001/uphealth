using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace NewWebApp.Administrator
{
    public partial class register : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["DBCS"].ToString(); // connection string
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {


                    string dat = DateTime.Now.ToString();
                    TextBox13.Text = dat;
                    Label1.Text = GetIP();
                    TextBox16.Text = dat;
                    gethome();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        protected string GetIP()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        protected void gethome()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com = new SqlCommand("SELECT distinct(hdistname), hdistid FROM homedistrict ORDER BY hdistname", con); // table name 
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            DropDownList1.DataTextField = ds.Tables[0].Columns["hdistname"].ToString(); // text field name of table dispalyed in dropdown
            DropDownList1.DataValueField = ds.Tables[0].Columns["hdistid"].ToString();             // to retrive specific  textfield name 
            DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            DropDownList1.DataBind();  //binding dropdownlist
            DropDownList1.Items.Insert(0, new ListItem("--Select--"));
            SqlCommand com1 = new SqlCommand("SELECT distinct(hdistname), hdistid FROM homedistrict ORDER BY hdistname", con); // table name 
            SqlDataAdapter da1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);  // fill dataset
            DropDownList2.DataTextField = ds1.Tables[0].Columns["hdistname"].ToString(); // text field name of table dispalyed in dropdown
            DropDownList2.DataValueField = ds1.Tables[0].Columns["hdistid"].ToString();             // to retrive specific  textfield name 
            DropDownList2.DataSource = ds1.Tables[0];      //assigning datasource to the dropdownlist
            DropDownList2.DataBind();  //binding dropdownlist
            DropDownList2.Items.Insert(0, new ListItem("--Select--"));
            SqlCommand com2 = new SqlCommand("SELECT distinct(hdistname), hdistid FROM homedistrict ORDER BY hdistname", con); // table name 
            SqlDataAdapter da2 = new SqlDataAdapter(com2);
            DataSet ds2 = new DataSet();
            da1.Fill(ds2);  // fill dataset
            DropDownList2.DataTextField = ds2.Tables[0].Columns["hdistname"].ToString(); // text field name of table dispalyed in dropdown
            DropDownList2.DataValueField = ds2.Tables[0].Columns["hdistid"].ToString();             // to retrive specific  textfield name 
            DropDownList2.DataSource = ds2.Tables[0];      //assigning datasource to the dropdownlist
            DropDownList2.DataBind();  //binding dropdownlist
            DropDownList2.Items.Insert(0, new ListItem("--Select--"));



        }
    }
}