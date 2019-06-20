using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.IO;
using System.Security;
using System.Text;

/// <summary>
/// Summary description for testingSec
/// </summary>
public class testingSec
{
    public Random Random1 = new Random();
	public testingSec()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void csrfinit(string imr)
    {
        string csrf1 = null;
        csrf1 = GenerateRandomCode();
        csrf1 = EncodePassword(csrf1);
        System.Web.HttpContext.Current.Session["CSRF" + imr] = csrf1.ToString().Trim();
    }

    public string EncodePassword(string originalPassword)
    {
        Byte[] originalBytes = null;
        Byte[] encodedBytes = null;
        MD5 md5 = default(MD5);
        md5 = new MD5CryptoServiceProvider();
        originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
        encodedBytes = md5.ComputeHash(originalBytes);
        // Bytes to string
        return (System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes), "-", "").ToLower());
    }
    public void csrfverify(string LoginPage, string imr, string csrf1)
    {
        string sessvalue = null;
        sessvalue = System.Web.HttpContext.Current.Session["CSRF" + imr].ToString().Trim();
        if (sessvalue != csrf1)
        {
            System.Web.HttpContext.Current.Response.Redirect(LoginPage, false);
        }
        else
        {
            csrfinit(imr);
        }
    }

    public string GenerateRandomCode()
    {
        string s = "";
        for (int i = 0; i <= 5; i++)
        {
            s = string.Concat(s, this.Random1.Next(10).ToString());
        }
        return s;
    }
    public void AntiFixationInit(string imr)
    {
        string value = null;
        HttpCookie cookie = null;
        value = GenerateRandomCode();


        if (cookie == null)
        {
            cookie = new HttpCookie("ASPFIXATION" + imr);
        }
        else
        {
            cookie = System.Web.HttpContext.Current.Request.Cookies["ASPFIXATION" + imr];
        }
        cookie.Value = value;
        System.Web.HttpContext.Current.Session["ASPFIXATION" + imr] = value;
        cookie.Expires = DateTime.Now.AddSeconds(300);
        System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
    }
    public void AntiFixationVerify(string LoginPage, string imr)
    {
        string cookie_value = null;
        string session_value = null;
        cookie_value = System.Web.HttpContext.Current.Request.Cookies["ASPFIXATION" + imr].Value.ToString();
        session_value = System.Web.HttpContext.Current.Session["ASPFIXATION" + imr].ToString();
        if (cookie_value != session_value)
        {
            System.Web.HttpContext.Current.Response.Redirect(LoginPage);
        }
        else
        {

            AntiFixationInit(imr);
        }
    }
    public bool SQLInj(string BefString)
    {
        bool flag = true;
        string CheckString = BefString.Replace("'", "''");
        string[] blacklist = new string[]
        {
           "--", ";--", "/*", "*/", "@@", 
                                          "nchar", "varchar", "nvarchar", 
                                         "alter", "begin", "cast", "create", "cursor", "declare", "delete", 
                                         "drop",  "execute", "fetch", "insert", "kill", "open",
                                         "select", "sysobjects", "syscolumns", "table", "update",  "script",
                                         "www", "www2", "union", "select", "union", "drop", "DROP", "&#8212;", "insert"
                                         , "delete", "xp_", "having", "group", "update", "<script>", "</script>", "\"", "<", ">"
                                         , "alert", "language", "javascript", "vbscript", "http", "$", "\\", "'", "#", "%", "^", "&",
                                         "(", ")", "?", "{", "[", "}", "]", "~", "=", "+",
        };

        for (int i = 0; i < blacklist.Length; i++)
        {
            if (BefString.IndexOf(blacklist[i], StringComparison.OrdinalIgnoreCase) >= 0)
            {
                flag = false;
                CheckString = CheckString.Replace(blacklist[i], "");
            }
        }
        return flag;
    }





    public bool SQLInj_SL(string BefString)
    {
        bool flag = true;
        string CheckString = BefString.Replace("'", "''");
        string[] blacklist = new string[]
        {
           "--", ";--", "/*", "*/", "@@", 
                                          "nchar", "varchar", "nvarchar", 
                                         "alter", "begin", "cast", "create", "cursor", "declare", "delete", 
                                         "drop",  "execute", "fetch", "insert", "kill", "open",
                                         "select", "sysobjects", "syscolumns", "table", "update",  "script",
                                         "www", "www2", "union", "select", "union", "drop", "DROP", "&#8212;", "insert"
                                         , "delete", "xp_", "having", "group", "update", "<script>", "</script>",  "<", ">"
                                         , "alert", "language", "javascript", "vbscript", "http", "$", "\\", "'", "#", "%", "^", "&",
                                         "(", ")", "?", "{", "[", "}", "]", "~", "=", "+",
        };

        for (int i = 0; i < blacklist.Length; i++)
        {
            if (BefString.IndexOf(blacklist[i], StringComparison.OrdinalIgnoreCase) >= 0)
            {
                flag = false;
                CheckString = CheckString.Replace(blacklist[i], "");
            }
        }
        return flag;
    }

    public string SQLInj_String(string BefString)
    {
        string SQLInj_String = "";
        string CheckString = BefString.Replace("'", "''");
        string[] blacklist = new string[]
        {
           "--", ";--", "/*", "*/", "@@", 
                                          "nchar", "varchar", "nvarchar", 
                                         "alter", "begin", "cast", "create", "cursor", "declare", "delete", 
                                         "drop",  "execute", "fetch", "insert", "kill", "open",
                                         "select", "sysobjects", "syscolumns", "table", "update",  "script",
                                         "www", "www2", "union", "select", "union", "drop", "DROP", "&#8212;", "insert"
                                         , "delete", "xp_", "having", "group", "update", "<script>", "</script>",  "<", ">"
                                         , "alert", "language", "javascript", "vbscript", "http", "$", "\\", "'", "#", "%", "^", "&",
                                         "(", ")", "?", "{", "[", "}", "]", "~", "=", "+",
        };

        for (int i = 0; i < blacklist.Length; i++)
        {
            if (BefString.IndexOf(blacklist[i], StringComparison.OrdinalIgnoreCase) >= 0)
            {
                
                CheckString = CheckString.Replace(blacklist[i], "");
                SQLInj_String = CheckString;
            }
        }
        return SQLInj_String;
    }



    public void list()
    {
        string[] blacklist = new string[]
        {
           "--", ";--", ";", "/*", "*/", "@@", 
                                         "@", "char", "nchar", "varchar", "nvarchar", 
                                         "alter", "begin", "cast", "create", "cursor", "declare", "delete", 
                                         "drop", "end", "exec", "execute", "fetch", "insert", "kill", "open",
                                         "select", "sys", "sysobjects", "syscolumns", "table", "update", "<", ">", "script",
                                         "www", "www2", "union", "src", "select", "union", "drop", "DROP", ";", "&#8212;", "insert"
                                         , "delete", "xp_", "*", "having", "group", "update", "<script>", "</script>", "\"", "<", ">"
                                         , "alert", "language", "javascript", "vbscript", "http", "$", "\\", "*", "'", "@", "#", "%", "^", "&",
                                         "(", ")", "?", "<", ">", "{", "[", "}", "]", "~", ".", "=", "+", "_", ",", ":", ";"
        };

    }
    //public string CheckInject(string BefString)
    //{
    //    string CheckString = Strings.Replace(BefString, "'", "''");
    //    for (int i = 0; i <= blackList.Length - 1; i++)
    //    {
    //        if ((BefString.IndexOf(blackList(i), StringComparison.OrdinalIgnoreCase) >= 0))
    //        {
    //            CheckString = Strings.Replace(CheckString, blackList(i), "");
    //        }
    //    }
    //    return CheckString;
    //}
    //private string[] blackList = {
    //"--",	";--",	";",	"/*",	"*/",	"char",	"nchar",	"varchar",	"nvarchar",	"alter",
    //"begin",	"cast",	"create",	"cursor",	"declare",	"delete",	"drop",	"exec",	"execute",
    //"fetch",	"insert",	"kill",	"open",	"select",	"sys",	"sysobjects",	"syscolumns",
    //"table",	"update",	"<",	">",	"script",	"www",	"www2",	"union",	"src",	"select",	"union",	"drop",
    //"DROP",	";",	"&#8212;",	"insert",	"delete",	"xp_",	"*",	"or",	"having",
    //"group",	"update",	"<script>",	"</script>",	"\"",
    //"<",	">",	"alert",	"language",	"javascript",	"vbscript",	"http",	"$",	"\\",
    //"*",	"'",	"@",	"#",
    //"%",	"^",
    //"&",	"(",
    //")",	"?",	"<",
    //">",	"{",
    //"[",	"}",
    //"]",	"~",
    //".",	"=",
    //"+",	"_",
    //",",	":",
    //";"
    //};

}
