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
    public partial class joinorderprint : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        SqlCommand cmd = new SqlCommand();
        testingSec tst = new testingSec();
        bool i;
        bool j;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["iduser"] == null)
            {
                Response.Redirect("~/Authenticate/login.aspx");
            }
            chkdata();
        }
        public void chkdata()
        {
            i = tst.SQLInj_SL(Request.QueryString["oid"]);
            j = tst.SQLInj_SL(Request.QueryString["idno"]);
            if (i == true && j == true)
            {
                Prnlbl.Text = " चि० एवं स्व० सेवाए /हस्ता० /" + System.DateTime.Today.Year + " / " + Request.QueryString["oid"];
                data();
            }
        }
        public void data()
        {
            string o = Request.QueryString["oid"];
            string id = Request.QueryString["idno"];
            if (o != " " && id != "")
            {
                cl.ds = cl.DataFill("SELECT DISTINCT idno,name, newpostname,districtname,hname FROM currentsearchCriteria where idno=" + Request.QueryString["idno"] + "");//"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
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

                        placet.Text = cl.ds.Tables[0].Rows[0][4].ToString() + " , " + cl.ds.Tables[0].Rows[0][3].ToString();
                    }
                    else
                    {
                        placet.Text = "";
                    }
                    ////////////////////////////////////////////
                }
                //cl.ds = cl.DataFill("SELECT orderby,orderno, Convert(char,orderdate,103) as orderdate,  Convert(char,currentdate,103)as currentdate FROM  status_join_releive where statussr=" + Request.QueryString["oid"] + "");//and currentdate='" + Convert.ToDateTime(Request.QueryString["curdate"]) + "'"SELECT DISTINCT idno,  name,senno, dob, fathername,  districtname, newpostname FROM Cfactsheet");
                cl.ds = cl.DataFill("SELECT      JRofficer.offname, status_join_releive.orderno, CONVERT(char, status_join_releive.orderdate, 103) AS orderdate, CONVERT(char, status_join_releive.currentdate, 103) AS currentdate,status_join_releive.orderby,JRofficer.orid, status_join_releive.replacername FROM         status_join_releive INNER JOIN  JRofficer ON status_join_releive.orid = JRofficer.orid where statussr=" + Request.QueryString["oid"] + "");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                    {
                        if (cl.ds.Tables[0].Rows[0][5].ToString() != "5")
                        {
                            orderbyt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                            OBYL.Text = orderbyt.Text;
                        }
                        else
                        {
                            orderbyt.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                            OBYL.Text = orderbyt.Text;
                        }
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
                    if (!(cl.ds.Tables[0].Rows[0][6].ToString().Equals(System.DBNull.Value)))
                    {
                        replacername.Text = cl.ds.Tables[0].Rows[0][6].ToString();
                    }
                    else
                    {
                        replacername.Text = "";
                    }





                    this.Label2.Visible = false;
                }
            }
            else
            {
                this.Label2.Visible = true;
                this.Label2.Text = "There Is No Order To Print";
            }
        }
    }
}