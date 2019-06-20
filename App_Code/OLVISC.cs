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
/// Summary description for OLVISC
/// </summary>
public class OLVISC
{
    static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
    public SqlConnection Olvs;
    public SqlCommand cmd;
    public DataSet ds1;
    public DataSet ds;
    public DataSet dsE;
    public DataSet dsD;
    public DataSet dsE1;
    public DataSet dsD1;
    public DataSet dstimech;
    public SqlDataAdapter da;
    public SqlDataAdapter daE;
    public SqlDataAdapter daD;
    public SqlDataAdapter daE1;
    public SqlDataAdapter daD1;
    public SqlDataAdapter da1;
    public SqlDataAdapter datimech;
    public SqlDataReader dr;
    public SqlDataReader dr1;
    public SqlCommand cmd1;
	public OLVISC()
	{
		//
		// TODO: Add constructor logic here
		//
        Olvs = new SqlConnection(ConfigurationManager.ConnectionStrings["OLVISCon"].ConnectionString);
	}

    public bool check(string name, string pass)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("select id from RDSOuser where userid='" + name + "' and upass='" + EncDec.EncryptRSA(pass) + "'", Olvs);
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
    public bool checklavel(string userid)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT lavel FROM Ucreate  where iduser='" + userid + "'", Olvs);
        ds.Clear();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        else
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "1" || ds.Tables[0].Rows[0][0].ToString() == "2")
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
        adp.SelectCommand = new SqlCommand("SELECT R,A,D,E FROM Ucreate  where iduser='" + userid + "'", Olvs);
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
        adp.SelectCommand = new SqlCommand("SELECT R FROM Ucreate  where iduser='" + userid + "'", Olvs);
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
    public bool checkA(string userid)
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        adp.SelectCommand = new SqlCommand("SELECT A FROM Ucreate  where iduser='" + userid + "'", Olvs);
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
        adp.SelectCommand = new SqlCommand("SELECT D FROM Ucreate  where iduser='" + userid + "'", Olvs);
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
        adp.SelectCommand = new SqlCommand("SELECT  E FROM Ucreate  where iduser='" + userid + "'", Olvs);
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
            return System.Configuration.ConfigurationManager.AppSettings["uphsdpcon"];
        }
    }
    public DataSet Dtimech(string qry1)
    {
        dstimech = new DataSet();
        datimech = new SqlDataAdapter(qry1, Olvs);
        datimech.Fill(dstimech);
        return dstimech;
    }
    public SqlDataReader SelectDB(string qry)
    {
        cmd = new SqlCommand(qry, Olvs);
        Olvs.Open();
        dr1 = cmd.ExecuteReader();
        //Olvs.Close();
        return dr1;
    }

    public SqlCommand InsertDB(string qry)
    {
        cmd = new SqlCommand(qry, Olvs);
        try
        {
            if ((Olvs.State == ConnectionState.Closed))
            {
                Olvs.Open();
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
            if ((Olvs.State == ConnectionState.Open))
            {
                Olvs.Close();
            }

        }
        return cmd;
    }

    public void UpdateDB(string qry)
    {
        cmd = new SqlCommand(qry, Olvs);
        Olvs.Open();
        cmd.ExecuteNonQuery();
        Olvs.Close();
    }

    public void DeleteDB(string qry)
    {
        cmd = new SqlCommand(qry, Olvs);
        Olvs.Open();
        cmd.ExecuteNonQuery();
        Olvs.Close();
    }

    public DataSet DataFill(string qry)
    {
        ds = new DataSet();
        da = new SqlDataAdapter(qry, Olvs);
        da.Fill(ds);
        return ds;

    }

    public DataSet DataFill2(string qry1)
    {
        ds1 = new DataSet();
        da1 = new SqlDataAdapter(qry1, Olvs);
        da1.Fill(ds1);
        return ds1;
    }
    public DataSet DataFillE(string qryE)
    {
        dsE = new DataSet();
        daE = new SqlDataAdapter(qryE, Olvs);
        daE.Fill(dsE);
        return dsE;
    }
    public DataSet DataFillE1(string qryE)
    {
        dsE1 = new DataSet();
        daE1 = new SqlDataAdapter(qryE, Olvs);
        daE1.Fill(dsE1);
        return dsE1;
    }
    public DataSet DataFillD(string qryD)
    {
        dsD = new DataSet();
        daD = new SqlDataAdapter(qryD, Olvs);
        daD.Fill(dsD);
        return dsD;
    }
    public DataSet DataFillD1(string qryD)
    {
        dsD1 = new DataSet();
        daD1 = new SqlDataAdapter(qryD, Olvs);
        daD1.Fill(dsD1);
        return dsD1;
    }

    public void updateData(string qry, DataSet dataSet)
    {
        Olvs.Open();
        ds = new DataSet();
        da = new SqlDataAdapter(qry, Olvs);
        da.Fill(ds);
        SqlCommandBuilder sqlCom = new SqlCommandBuilder(da);
        da.Update(dataSet);
        Olvs.Close();
    }

    public DataTable fillData(DataTable dt, string qry)
    {
        SqlCommand cmd = new SqlCommand(qry, Olvs);
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }

    public DataSet saveData(DataSet ds, string tableName, string qry)
    {
        SqlCommand cmd = new SqlCommand(qry, Olvs);
        da = new SqlDataAdapter(cmd);
        da.Fill(ds, tableName);
        return ds;
    }

    public SqlDataAdapter ReturnAdapter(string qry)
    {
        da = new SqlDataAdapter(qry, Olvs);
        return da;
    }

    public SqlCommand SelectDataFromCommand(string qry)
    {
        cmd = new SqlCommand(qry, Olvs);
        return cmd;
    }

    public void InsertDataFromCommand(SqlCommand cmd1)
    {
        Olvs.Open();
        cmd1.ExecuteNonQuery();
        Olvs.Close();
    }

    public SqlDataReader SelectDataFromCommand(SqlCommand cmd1)
    {
        Olvs.Open();
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
        Olvs.Open();
        cmd = new SqlCommand("+ pname + ", Olvs);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;

    }

    public SqlCommand st()
    {
        cmd = new SqlCommand();
        try
        {
            //Olvs.Open();
            cmd.ExecuteScalar();
        }
        catch (Exception e)
        {
            string Er = "Error in GetObject()-> " + e.ToString();
            throw new Exception(Er);
        }
        finally
        {
            Olvs.Close();
        }
        return cmd;

    }
}
