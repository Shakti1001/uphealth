using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace NewWebApp.payrole
{
    public partial class rsbyUserlogin : System.Web.UI.Page
    {
        Class1 c = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }

        }
        protected void btnlogin_click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();

                string str = "Select username,upper(upass) as upass,iduser,userid,lavel,disid from RSBYloginuser  where (userid='" + txtuserid.Text + "' and upass='" + txtpass.Text + "')";




                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand(str, c.con);
                ds.Clear();
                adp.Fill(ds);

                Session["iduser"] = ds.Tables[0].Rows[0][2];
                Session["lvl"] = ds.Tables[0].Rows[0][4];
                //Session["deg"] = ds.Tables[0].Rows[0][3];
                //Session["name"] = ds.Tables[0].Rows[0][2];
                if (txtuserid.Text == "")
                {
                    Response.Write("<Script>alert('User-Id Field Can not Be Null')</script>");
                }

                else if (ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<Script>alert('Wrong Password Or User-Id')</script>");

                    txtuserid.Text = "";
                    txtpass.Text = "";
                }
                else
                {
                    Response.Redirect("rsbyHOME.aspx");

                    //    if (ds.Tables[0].Rows[0][1].ToString().Equals("1"))
                    //    {
                    //        Response.Redirect("Selection.aspx?id=" + ds.Tables[0].Rows[0][0].ToString());

                    //    }

                    //    else if (ds.Tables[0].Rows[0][1].ToString().Equals("2"))
                    //    {
                    //        Response.Redirect("Selection.aspx?id=" + ds.Tables[0].Rows[0][0].ToString());

                    //    }

                    //    else if (ds.Tables[0].Rows[0][1].ToString().Equals("3"))
                    //    {
                    //        Response.Redirect("RRegister.aspx?id=" + ds.Tables[0].Rows[0][0].ToString());
                    //    }

                    //    // Response.Write("<script>alert('Your id no.="+ds.Tables[0].Rows[0][0].ToString()+"')</script>");
                    //    //  Response.Redirect("Selection.aspx");

                    //}

                }

            }

            finally
            {

                c.con.Close();
            }
        }
    
    }
}