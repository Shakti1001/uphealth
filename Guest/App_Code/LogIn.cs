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
using System.Security.Cryptography;
using System.Text;
using System.IO;
interface LogInterface
{
    //int NumLegs {set; }
    // string Color { get; set; }

    bool AllowLogin();
}

/// <summary>
/// Summary description for LogIn
/// </summary>
///
public class LogIn : LogInterface
{
    static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
    private string username;
    private string password;

    public void NumLegs(string name, string pass)
    {
        username = name;
        password = pass;
    }
    public bool AllowLogin()
    {
        if (username == "imran")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string Md5AddSecret(string strChange)
    {
        byte[] pass = Encoding.UTF8.GetBytes(strChange);
        MD5 md5 = new MD5CryptoServiceProvider();
        string strPassword = Encoding.UTF8.GetString(md5.ComputeHash(pass));
        return strPassword;
    }    
    public string ROT13Encode(string InputText)
    {
        int i;
        char CurrentCharacter;
        int CurrentCharacterCode;
        string EncodedText = "";

        //Iterate through the length of the input parameter
        for (i = 0; i < InputText.Length; i++)
        {
            //Convert the current character to a char
            CurrentCharacter = System.Convert.ToChar(InputText.Substring(i, 1));

            //Get the character code of the current character
            CurrentCharacterCode = (int)CurrentCharacter;

            //Modify the character code of the character, - this
            //so that "a" becomes "n", "z" becomes "m", "N" becomes "Y" and so on
            if (CurrentCharacterCode >= 97 && CurrentCharacterCode <= 109)
            {
                CurrentCharacterCode = CurrentCharacterCode + 13;
            }
            else

                if (CurrentCharacterCode >= 110 && CurrentCharacterCode <= 122)
                {
                    CurrentCharacterCode = CurrentCharacterCode - 13;
                }
                else

                    if (CurrentCharacterCode >= 65 && CurrentCharacterCode <= 77)
                    {
                        CurrentCharacterCode = CurrentCharacterCode + 13;
                    }
                    else

                        if (CurrentCharacterCode >= 78 && CurrentCharacterCode <= 90)
                        {
                            CurrentCharacterCode = CurrentCharacterCode - 13;
                        }

            //Add the current character to the string to be returned
            EncodedText = EncodedText + (char)CurrentCharacterCode;
        }

        return EncodedText;

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


    
}