using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB
{
    protected static string strConnect;
    public DB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    static DB()
    {
        strConnect = System.Configuration.ConfigurationManager.AppSettings["uphsdpcon"];
    }
    public SqlConnection GetConnection()
    {
        SqlConnection oConnection = new SqlConnection(strConnect);
        return oConnection;
    }
    public bool check(string name, string pass)
    {
        strConnect = System.Configuration.ConfigurationManager.AppSettings["uphsdpcon"];
        SqlConnection oConnection = new SqlConnection(strConnect);
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("select * from users where username='" + name + "' and password='" + EncDec.DecryptRSA(pass) + "'", oConnection);
        ds.Clear();
        adp.Fill(ds, "users");
        if (ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

