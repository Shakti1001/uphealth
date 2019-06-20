using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    public SqlConnection con = new SqlConnection();
    public SqlCommand cmd = new SqlCommand();
    public SqlCommand cmd1 = new SqlCommand();
    public SqlDataAdapter sda = new SqlDataAdapter();
    public SqlDataAdapter sda1 = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommandBuilder scb = new SqlCommandBuilder();
    public DataRow dr;
    public SqlDataReader drr;

    public Class1()
    {
        sda.SelectCommand = cmd;
        sda1.SelectCommand = cmd1;
        //  con.ConnectionString = @"Data Source=NICUP-HP;Initial Catalog=dpcms;User id=sa;Password=pass";
        //con.ConnectionString = WebConfigurationManager.ConnectionStrings["dpcmsConnection"].ConnectionString;
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["uphsdpConnectionString"].ConnectionString;

        cmd.Connection = con;
        cmd1.Connection = con;
        //
        // TODO: ddl constructor logic here
        //
    }
    public void ddl3(DropDownList id, string q, string t, string v)
    {
        cmd.CommandText = q;
        ds.Clear();

        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataTextField = t;
        id.DataValueField = v;
        id.DataBind();

        id.Items.Insert(0, "Select");

    }

    //public DataSet DataFill(string qry)
    //{
    //    ds = new DataSet();
    //    da = new SqlDataAdapter(qry, upcon);
    //    da.SelectCommand.CommandTimeout = 120;
    //    da.Fill(ds);
    //    return ds;

    //}

    public void ddl2(DropDownList id, string q, string t, string v)
    {
        cmd.CommandText = q;
        ds.Clear();

        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataTextField = t;
        id.DataValueField = v;
        id.DataBind();

        id.Items.Insert(0, "--Select DDO--");

    }
   

    public void ddl(DropDownList id, string q, string t, string v)
    {
        cmd.CommandText = q;
        ds.Clear();

        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataTextField = t;
        id.DataValueField = v;
        id.DataBind();
     //  id.Items.Insert(0, new ListItem("Select"));
        //id.Items.Insert(0, "");

    }
    
    
       public void ddlhospital(DropDownList id, string q, string t, string v)
    {
        cmd.CommandText = q;
        ds.Clear();

        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataTextField = t;
        id.DataValueField = v;
        id.DataBind();
        id.Items.Insert(0, new ListItem("Select"));
        //id.Items.Insert(0, "");

    }
    
    
   public void ddlduty(DropDownList id, string q, string t, string v)
    {

        cmd.CommandText = q;
        ds.Clear();

        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataTextField = t;
        id.DataValueField = v;
        id.DataBind();
        //id.Items.Insert(0, new ListItem("Select"));
        //id.Items.Insert(0, "");
    }
    public void ddl1(DropDownList id, string q, string t, string v)
    {
        cmd.CommandText = q;
        ds.Clear();

        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataTextField = t;
        id.DataValueField = v;
        id.DataBind();
      // id.Items.Insert(0, new ListItem("NONE"));
        //id.Items.Insert(0, "");

    }
    
    
     public void ddl5(DropDownList id, string q, string t, string v)
    {
        cmd.CommandText = q;
        ds.Clear();

        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataTextField = t;
        id.DataValueField = v;
        id.DataBind();
       id.Items.Insert(0, new ListItem("NONE"));
        //id.Items.Insert(0, "");

    }


     public bool IllegalChars(TextBox txt)
     {
         // Declare variables 
         string[] sBadChars;
         int iCounter;
         string sBadCharsstring;
         // Set IllegalChars to False 
         bool IllegalChars = false;
         sBadCharsstring = "select,drop,;,--,insert,delete,xp_,%,&,\',\\,:,;,<,>,[,],?,`,|,declare,convert,script,create,view,updat" +
         "e,sp_,exec,<script>";
         sBadChars = sBadCharsstring.Split(',');
         //   'Loop through array sBadChars using our counter & UBound function
         for (iCounter = 0; (iCounter <= sBadChars.GetUpperBound(0)); iCounter++)
         {
             // Use Function Instr to check presence of illegal character in our variable
             if (((txt.Text.IndexOf(sBadChars[iCounter]) + 1)
                         > 0))
             {
                 IllegalChars = true;
                 txt.BackColor = System.Drawing.Color.LightPink;
             }
         }
         return IllegalChars;
     }
     public void sessionterminate()
     {
         HttpContext.Current.Session.Abandon();
         HttpContext.Current.Session.Clear();
         HttpContext.Current.Session.RemoveAll();

     }

    public string autoid(string s, string q)
    {
        cmd.CommandText = q;
        ds.Clear();
        sda.Fill(ds, "vt");
        return (s + Convert.ToUInt32(ds.Tables["vt"].Rows.Count + 1));
    }

    public void gv(GridView id, string q)
    {
        cmd.CommandText = q;
        ds.Clear();
        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataBind();
    }
    public void gv1(GridView id, string q)
    {
        cmd.CommandText = q;
        ds.Clear();
        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataBind();
    }
    
     public void grdv2(GridView id, string q)
    {
        cmd.CommandText = q;
        ds.Clear();
        sda.Fill(ds, "vt");
        id.DataSource = ds.Tables["vt"];
        id.DataBind();

    }




}