using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Policy;
using System.IO;
using System.Text;
using System.Security.Cryptography;


/// <summary>
/// Summary description for ClDatabase
/// </summary>
public class ClDatabase
{
    static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
    public SqlConnection upcon;
    public SqlCommand cmd;    
    public DataSet ds1;    
    public DataSet ds;
    public DataSet dsE;
    public DataSet dsD;
    public DataSet dsE1;
    public DataSet dsD1;
    public DataSet dstimech;
    public DataSet dshospitalid;
    public DataSet dsid;
    public DataSet dshba;
    public DataSet dshba1;
    public DataSet dshba2;
    public DataSet dshba3;
    public DataSet dsloan;
    public DataSet dsst;
    public SqlDataAdapter da;
    public SqlDataAdapter daE;
    public SqlDataAdapter daD;
    public SqlDataAdapter daE1;
    public SqlDataAdapter daD1;
    public SqlDataAdapter da1;
    public SqlDataAdapter datimech;
    public SqlDataAdapter dahospitalid;
    public SqlDataReader dr;
    public SqlDataReader dr1;    
    public SqlCommand cmd1;
  
    public ClDatabase()
    {
        //
        // TODO: Add constructor logic here
        // 
        upcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        //conh=new SqlConnection(ConfigurationSettings.AppSettings["uphsdpcon"].ToString());                 
	}
    public  bool IsInteger(string theValue)
    {
        try
        {
            Convert.ToInt32(theValue);
            return true;
        }
        catch
        {
            return false;
        }
    } //IsInteger
    public  bool IsDecimal(string theValue)
    {
        try
        {
            Convert.ToDouble(theValue);
            return true;
        } 
        catch 
        {
            return false;
        }
    } //IsDecimal
    public bool IsDate(string data)
    {
        bool result = true;
        try
        {
            DateTime.Parse(data);
        }
        catch (FormatException)
        {
            result = false;
        }
        return result;
    }//Isdate
    


    public bool check(string name, string pass)
   {
       SqlDataAdapter adp = new SqlDataAdapter();
       DataSet ds = new DataSet();
       string EncryptedPas = EncDec.EncryptRSA(pass);
       adp.SelectCommand = new SqlCommand("select iduser from Ucreate where userid='" + name + "' and upass='" + EncryptedPas + "'", upcon);
       ds.Clear();
       adp.Fill(ds);
       if (ds.Tables[0].Rows.Count == 0)
        {
          return false;
        }
       else
       {
          return true;

        }
     }




    public void AddCalender(ref Image img, ref TextBox txt)
    {
        img.Attributes.Add("onClick", "popUpCalendar(" + txt.ClientID + ", " + txt.ClientID + ", 'dd/mm/yyyy');");
    }

    public bool IllegalChars(TextBox txt)
    {
        // Declare variables 
        string[] sBadChars;
        int iCounter;
        string sBadCharsstring;
        // Set IllegalChars to False 
        bool IllegalChars = false;
        sBadCharsstring = "select,drop,;,--,insert,delete,xp_,%,&,\',\\,:,;,<,>,[,],?,`,|,declare,convert,script,create,view,update,sp_,exec,<script>";
        sBadChars = sBadCharsstring.Split(',');
        //   'Loop through array sBadChars using our counter & UBound function
        for (iCounter = 0; (iCounter <= sBadChars.GetUpperBound(0)); iCounter++)
        {
            // Use Function Instr to check presence of illegal character in our variable
            if (((txt.Text.IndexOf(sBadChars[iCounter]) + 1) > 0))
            {
                IllegalChars = true;
                txt.Text = "";
            }
        }
        return IllegalChars;
    }


    public string getdistlv(string htype)
    {
        string getdistlv = "";
        if (htype == "0")
        {
            getdistlv = " and poposting  in (select sno from hospitalname where htype not in (1,2,3,21)) ";
        }
        else if (htype == "1")
        {
            getdistlv = " and poposting  in (select sno from hospitalname where htype  in (1)) ";

        }
        else if (htype == "2")
        {
            getdistlv = " and poposting  in (select sno from hospitalname where htype  in (2)) ";

        }
        else if (htype == "3")
        {
            getdistlv = " and poposting  in (select sno from hospitalname where htype  in (3)) ";

        }
        else if (htype == "21")
        {
            getdistlv = " and poposting  in (select sno from hospitalname where htype  in (21)) ";

        }

        return getdistlv;
    }
    public DataSet Dthospitalid(string qry1)
    {
        dshospitalid = new DataSet();
        dahospitalid = new SqlDataAdapter(qry1, upcon);
        dahospitalid.Fill(dshospitalid);
        return dshospitalid;
    }
    public string checklavel_Dist(string userid)
    {
        string checklavel_Dist = "";
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT     Ucreate.lavel, userlavel.uhtype, Ucreate.DisId FROM Ucreate INNER JOIN  userlavel ON Ucreate.lavel = userlavel.ulid  where Ucreate.iduser='" + userid + "'", upcon);
        ds.Clear();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return checklavel_Dist;
        }
        else
        {
            //Distlvl = ds.Tables[0].Rows[0][1].ToString() + "/" + ds.Tables[0].Rows[0][2].ToString();
            checklavel_Dist = ds.Tables[0].Rows[0][1].ToString();

            if (checklavel_Dist == "0")
            {
                checklavel_Dist = " and poposting  in (select sno from hospitalname where htype not in (1,2,3,21)) ";
            }
            else if (checklavel_Dist == "1")
            {
                checklavel_Dist = " and poposting  in (select sno from hospitalname where htype  in (1)) ";

            }
            else if (checklavel_Dist == "2")
            {
                checklavel_Dist = " and poposting  in (select sno from hospitalname where htype  in (2)) ";

            }
            else if (checklavel_Dist == "3")
            {
                checklavel_Dist = " and poposting  in (select sno from hospitalname where htype  in (3)) ";

            }
            else if (checklavel_Dist == "21")
            {
                checklavel_Dist = " and poposting  in (select sno from hospitalname where htype  in (21)) ";

            }

            return checklavel_Dist;
        }


    }


    public bool checklavel(string userid)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT lavel FROM Ucreate  where iduser='" + userid + "'", upcon);
        ds.Clear();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        else
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "1" || ds.Tables[0].Rows[0][0].ToString() == "2")
           //if (ds.Tables[0].Rows[0][0].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
    
        
    public bool checkALLper(string userid)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT R,A,D,E FROM Ucreate  where iduser='" + userid + "'", upcon);
        ds.Clear();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {            
            return false;
        }
        else
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "1" && ds.Tables[0].Rows[0][1].ToString() == "1" && ds.Tables[0].Rows[0][2].ToString() == "1" && ds.Tables[0].Rows[0][3].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }
    }
    public bool checkR(string userid)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT R FROM Ucreate  where iduser='" + userid + "'", upcon);
        ds.Clear();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        else
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "1" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool checkA(string userid)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT A FROM Ucreate  where iduser='" + userid + "'", upcon);
        ds.Clear();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        else
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    public bool checkD(string userid)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT D FROM Ucreate  where iduser='" + userid + "'", upcon);
        ds.Clear();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        else
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool checkE(string userid)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT  E FROM Ucreate  where iduser='" + userid + "'", upcon);
        ds.Clear();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        else
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    public static String ConnectionString
    {
        get
        {
           
            //return ConfigurationSettings.AppSettings["uphsdpcon"];
            return System.Configuration.ConfigurationManager.AppSettings["DBCS"];
        }
    }
    public DataSet Dtimech(string qry1)
    {
        dstimech = new DataSet();
        datimech = new SqlDataAdapter(qry1, upcon);
        datimech.Fill(dstimech);
        return dstimech;
    }
    public SqlDataReader SelectDB(string qry)
    {
        cmd = new SqlCommand(qry, upcon);
        upcon.Open();
        dr1 = cmd.ExecuteReader();
        //upcon.Close();
        return dr1;
    }

    public SqlCommand InsertDB(string qry)
    {
        cmd = new SqlCommand(qry, upcon);
        try
        {
            if ((upcon.State == ConnectionState.Closed))
            {
                upcon.Open();
            }
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            string Er = "Error in GetObject()-> " + e.ToString();
            throw new Exception(Er);
        }
        finally
        {
            if ((upcon.State == ConnectionState.Open))
            {
                upcon.Close(); 
            }
            
        }
        return cmd;
    }

    public void UpdateDB(string qry)
    {
        cmd = new SqlCommand(qry, upcon);
        upcon.Open();
        cmd.ExecuteNonQuery();
        upcon.Close();
    }

    public void DeleteDB(string qry)
    {
        cmd = new SqlCommand(qry, upcon);
        upcon.Open();
        cmd.ExecuteNonQuery();
        upcon.Close();
    }

    public DataSet DataFill(string qry)
    {
        ds = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(ds);
        return ds;        

    }
    public DataSet DataFillloan(string qry)
    {
        dsloan = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(dsloan);
        return dsloan;

    }
    public DataSet DataFilleid(string qry)
    {
        dsid = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(dsid);
        return dsid;

    }
    public DataSet DataFillhba(string qry)
    {
        dshba = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(dshba);
        return dshba;

    }
    public DataSet DataFillhba1(string qry)
    {
        dshba1 = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(dshba1);
        return dshba1;

    }
    public DataSet DataFillhba2(string qry)
    {
        dshba2 = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(dshba2);
        return dshba2;

    }
    public DataSet DataFillhba3(string qry)
    {
        dshba3 = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(dshba3);
        return dshba3;

    }
    public DataSet DataFillSt(string qry)
    {
        dsst = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(dsst);
        return dsst;

    }
    
    public DataSet DataFill2(string qry1)
    {
        ds1 = new DataSet();
        da1 = new SqlDataAdapter(qry1, upcon);
        da1.Fill(ds1);
        return ds1;
    }
    public DataSet DataFillE(string qryE)
    {
        dsE = new DataSet();
        daE = new SqlDataAdapter(qryE, upcon);
        daE.Fill(dsE);
        return dsE;
    }
    public DataSet DataFillE1(string qryE)
    {
        dsE1 = new DataSet();
        daE1 = new SqlDataAdapter(qryE, upcon);
        daE1.Fill(dsE1);
        return dsE1;
    }
    public DataSet DataFillD(string qryD)
    {
        dsD = new DataSet();
        daD = new SqlDataAdapter(qryD, upcon);
        daD.Fill(dsD);
        return dsD;
    }
    public DataSet DataFillD1(string qryD)
    {
        dsD1 = new DataSet();
        daD1 = new SqlDataAdapter(qryD, upcon);
        daD1.Fill(dsD1);
        return dsD1;
    }

    public void updateData(string qry, DataSet dataSet)
    {
        upcon.Open();
        ds = new DataSet();
        da = new SqlDataAdapter(qry, upcon);
        da.Fill(ds);
        SqlCommandBuilder sqlCom = new SqlCommandBuilder(da);
        da.Update(dataSet);
        upcon.Close();
    }

    public DataTable fillData(DataTable dt, string qry)
    {
        SqlCommand cmd = new SqlCommand(qry, upcon);
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }

    public DataSet saveData(DataSet ds, string tableName, string qry)
    {
        SqlCommand cmd = new SqlCommand(qry, upcon);
        da = new SqlDataAdapter(cmd);
        da.Fill(ds, tableName);
        return ds;
    }

    public SqlDataAdapter ReturnAdapter(string qry)
    {
        da = new SqlDataAdapter(qry, upcon);
        return da;
    }

    public SqlCommand SelectDataFromCommand(string qry)
    {
        cmd = new SqlCommand(qry, upcon);
        return cmd;
    }

    public void InsertDataFromCommand(SqlCommand cmd1)
    {
        upcon.Open();
        cmd1.ExecuteNonQuery();
        upcon.Close();
    }

    public SqlDataReader SelectDataFromCommand(SqlCommand cmd1)
    {
        upcon.Open();
        dr = cmd1.ExecuteReader();
        return dr;
       
    }

    public DataSet InsertData(SqlDataAdapter da, string TableName)
    {
        ds = new DataSet();
        da.Fill(ds, TableName);
        return ds;
    }

    public static string EncryptRSA(string originalString)
    {
        if (String.IsNullOrEmpty(originalString))
        {
            throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
        }
        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
        StreamWriter writer = new StreamWriter(cryptoStream);
        writer.Write(originalString);
        writer.Flush();
        cryptoStream.FlushFinalBlock();
        writer.Flush();
        return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
    }

    public static string DecryptRSA(string cryptedString)
    {
        if (String.IsNullOrEmpty(cryptedString))
        {
            throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
        }
        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
        CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
        StreamReader reader = new StreamReader(cryptoStream);
        return reader.ReadToEnd();
    }
    
    public SqlCommand stpro(string pname)
    {
        upcon.Open();
        cmd = new SqlCommand("+ pname + ", upcon);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;

    }

    public SqlCommand st()
    {
        cmd = new SqlCommand();
        try
        {
            //upcon.Open();
            cmd.ExecuteScalar();
        }
        catch (Exception e)
        {
            string Er = "Error in GetObject()-> " + e.ToString();
            throw new Exception(Er);
        }
        finally
        {
            upcon.Close();
        }
        return cmd;

    }
    public void impqr()
    {
        //Leapyear//if datepart(dd, cast(cast(datepart(yy, getdate()) as varchar) + '-02-28' as datetime) + 1) = 29 print 'leap year' else print 'not a leap year' 
    //datepart//select datepart(yy,getdate()) as d
       


    }




public bool checkallsession()
     {
        if (string.IsNullOrEmpty(HttpContext.Current.Session["userid"].ToString()) || string.IsNullOrEmpty(HttpContext.Current.Session["iduser"].ToString()) || string.IsNullOrEmpty(HttpContext.Current.Session["lavel"].ToString()) || string.IsNullOrEmpty(HttpContext.Current.Session["disid"].ToString()) || string.IsNullOrEmpty(HttpContext.Current.Session["Username"].ToString()))
       //if (string.IsNullOrEmpty(HttpContext.Current.Session["lavel"].ToString()) )
        
        {
            return false;
        }
        else
        {
            return true;
        }



    }


////    public void ResetFormControlValues(Control ByVal parent)
////{
    
////}
   
    ////Public Sub ResetFormControlValues(ByVal parent As Control)
    ////    For Each c As Control In parent.Controls
    ////        If c.Controls.Count > 0 Then
    ////            ResetFormControlValues(c)
    ////        Else
    ////            Select Case c.[GetType]().ToString()
    ////                Case "System.Web.UI.WebControls.TextBox"
    ////                    DirectCast(c, TextBox).Text = ""
    ////                    Exit Select
    ////                Case "System.Web.UI.WebControls.CheckBox"
    ////                    DirectCast(c, CheckBox).Checked = False
    ////                    Exit Select
    ////                Case "System.Web.UI.WebControls.RadioButton"
    ////                    DirectCast(c, RadioButton).Checked = False
    ////                    Exit Select

    ////            End Select
    ////        End If
    ////    Next
    ////End Sub

    }
