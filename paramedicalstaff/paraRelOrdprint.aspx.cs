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

namespace NewWebApp.paramedicalstaff
{
    public partial class paraRelOrdprint : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["iduser"] == null)
            {
                Response.Redirect("~/Authenticate/login.aspx");
            }
            this.Label1.Text = (string)Session["ODR"];
            data();
        }

        public void ordrel()
        {
            cl.ds = cl.DataFill("SELECT idno,name, designame,districtname,hname FROM parafactsearchCriteria where idno=" + Request.QueryString["idno"] + "");//"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Relievename.Text = cl.ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                Relievename.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
            {
                Postt.Text = cl.ds.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                Postt.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
            {
                PLACE.Text = cl.ds.Tables[0].Rows[0][3].ToString();
            }
            else
            {
                PLACE.Text = "";
            }
            if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
            {

                placet.Text = cl.ds.Tables[0].Rows[0][4].ToString() + "," + cl.ds.Tables[0].Rows[0][3].ToString();
            }
            else
            {
                placet.Text = "";
            }
        }
        public void orjoin()
        {
            cl.ds = cl.DataFill("SELECT idno,name, designame,districtname,hname FROM paracurrentsearchCriteria where idno=" + Request.QueryString["idno"] + "");//"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {

                    Joinname.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    Joinname.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    Postt.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    Postt.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    PLACE.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    PLACE.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {

                    placet.Text = cl.ds.Tables[0].Rows[0][4].ToString() + "," + cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    placet.Text = "";
                }

            }
        }
        public void data()
        {
            if ((string)Session["ODR"] == "REL")
            {
                ordrel();
            }
            else if ((string)Session["ODR"] == "JOIN")
            {
                orjoin();
            }
            cl.ds = cl.DataFill("SELECT orderby,orderno,Convert(char,orderdate,103) as orderdate,  Convert(char,currentdate,103)as currentdate FROM  parastatus_join_releive where statussr=" + Request.QueryString["orid"] + "");//and currentdate='" + Convert.ToDateTime(Request.QueryString["curdate"]) + "'"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    orderbyt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    OBYL.Text = orderbyt.Text;
                }
                else
                {
                    orderbyt.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    ordernot.Text = cl.ds.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    ordernot.Text = "";
                }

                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    orderdatet.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    orderdatet.Text = "";
                }
                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    curdatet.Text = cl.ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    curdatet.Text = "";
                }

            }
        }
    }
}