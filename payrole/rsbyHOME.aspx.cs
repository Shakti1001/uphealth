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
    public partial class rsbyHOME : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    //    Label2.Visible = true;
                    c.con.Open();
                    string str = "select top 1 * from RSBYqmaster order by newid()";

                    SqlDataAdapter adp = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adp.SelectCommand = new SqlCommand(str, c.con);
                    ds.Clear();
                    adp.Fill(ds);
                    Label1.Text = ds.Tables[0].Rows[0]["qus"].ToString();
                    Label2.Text = ds.Tables[0].Rows[0]["qid"].ToString();
                }
                finally
                {

                    c.con.Close();
                }

                //c.gv(ddlhyear,"select * from hosp","","");

            }
        }
        public string GetIPAddress()
        {
            try
            {
                string ipAdd;
                HttpRequest currentRequest = HttpContext.Current.Request;
                ipAdd = currentRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (ipAdd == null || ipAdd.ToLower() == "unknown")
                    ipAdd = currentRequest.ServerVariables["REMOTE_ADDR"];

                return ipAdd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string str1 = "select * from RSBYans where iduser='" + Session["iduser"] + "' and qid='" + Label2.Text + "' and ans='" + TextBox1.Text + "'";
            SqlDataAdapter adp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand(str1, c.con);
            ds.Clear();
            adp.Fill(ds);
            //Label1.Text = ds.Tables[0].Rows[0]["qus"].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    c.con.Open();
                    c.cmd.CommandText = "insert into RSBYaudit(iduser,lvl,ip,action) values(@iduser,@lvl,@ip,@action)";
                    c.cmd.Parameters.AddWithValue("@iduser", Session["iduser"]);
                    //c.cmd.Parameters.AddWithValue("@logindate", System.DateTime.Today);
                    c.cmd.Parameters.AddWithValue("@lvl", Session["lvl"]);
                    c.cmd.Parameters.AddWithValue("@ip", GetIPAddress());
                    c.cmd.Parameters.AddWithValue("@action", "Login Successful");
                    c.cmd.ExecuteNonQuery();
                }
                finally
                {
                    c.con.Close();
                }


                Label3.Text = "Your Attendence is Registered..";

            }
            else
            {
                Label3.Text = "Incorrect Answer....Correct it.";
            }



        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("rsbyUserlogin.aspx");
        }
    }
}