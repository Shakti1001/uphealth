using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace NewWebApp.Guest
{
    public partial class dailyrepo : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            c.con.Open();
            c.cmd.CommandText = "SELECT mpr.compid, mpr.ddoid, mpr.cases, mpr.dutyid, convert(varchar(12),mpr.date,106) as date, dutytype.dutyname FROM  mpr INNER JOIN dutytype ON mpr.dutyid = dutytype.dutyid  where compid=" + Request.QueryString["compid"] + " and DATEPART(mm, mpr.date) =" + Request.QueryString["month"] + "  order by mpr.date";


            //c.cmd.CommandText = "select compid,name,post,hname,dutyname,cases from mprfinal where compid=" + Request.QueryString["compid"] + " and month=" + Request.QueryString["month"] + " ";
            SqlDataAdapter adp = new SqlDataAdapter(c.cmd);
            c.sda.Fill(c.ds);


            try
            {
                //c.con.Open();
                c.cmd.ExecuteNonQuery();
                if (c.ds.Tables[0].Rows.Count > 1)
                {
                    //lblcid.Text=c.ds.Tables[0].Rows[0][0].ToString();
                    //lblname.Text=c.ds.Tables[0].Rows[0][1].ToString();
                    //lblpost.Text=c.ds.Tables[0].Rows[0][2].ToString();
                    //lblhname.Text = c.ds.Tables[0].Rows[0][3].ToString();
                }
                GridView1.DataSource = c.ds;
                GridView1.DataBind();

            }
            finally
            {
                c.con.Close();
            }
            //c.gv(GridView1, "select compid,date,dutytype.dutyname,cases from mpr inner join dutytype on dutytype.dutyid=mpr.dutyid where compid="+Request.QueryString["compid"]+" order by date");

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}