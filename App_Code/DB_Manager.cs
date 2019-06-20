using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for DB_Manager
/// </summary>
public class DB_Manager
{
    public SqlConnection upcon;
    public DB_Manager()
    {

        //
        // TODO: Add constructor logic here
        //
    }
    public SqlConnection Get_Connection_Local1()
    {
       
      //  upcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["uphsdpConnection"].ConnectionString);
        //return upcon;   
        
          string str = "Data Source=10.135.0.98;Initial Catalog=healthpis;user id=healthpis;password=Te^3*71ts";
        SqlConnection conn = new SqlConnection(str);
        return conn;

    }
    public SqlConnection Get_Connection_Local()
    {

        string str = "Data Source=10.135.0.98;Initial Catalog=healthpis;user id=healthpis;password=Te^3*71ts";
        SqlConnection conn = new SqlConnection(str);
        return conn;
    }
    public DataSet Return_DS(string querry)
    {
        SqlConnection con = Get_Connection_Local();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand(querry, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            con.Open();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataSet Return_DS_By_SP(string querry, string param)
    {
        SqlConnection con = Get_Connection_Local();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand(querry, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = param;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            con.Open();
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            con.Close();
        }
    }
    public DataTable Return_Dt(string querry)
    {
        //SqlConnection con = Get_Connection();
        SqlConnection con = Get_Connection_Local();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand(querry, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
   
    public DataTable Read_dist_xml(string xml_file_path)
    {
        DataTable dt = new DataTable();
        dt.ReadXml(xml_file_path);
        return dt;
    }

    public DataTable Return_Dt1(string querry)
    {
        //SqlConnection con = Get_Connection();
        SqlConnection con = Get_Connection_Local1();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand(querry, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}