using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for EncDec
/// </summary>
public class EncDec
{
    static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
	public EncDec()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //RSA Algo/////
    
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

    ////////////////////////
    //public static string EncryptUserID(string userId)
    //{
    //    ASCIIEncoding textConverter = new ASCIIEncoding();
    //    RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

    //    byte[] encrypted;
    //    byte[] toEncrypt;
    //    byte[] key;
    //    byte[] IV;

    //    rc2CSP.Key = Convert.FromBase64String(ConfigurationSettings.AppSettings["encKey"]);
    //    rc2CSP.IV = Convert.FromBase64String(ConfigurationSettings.AppSettings["IV"]);

    //    //Get the key and IV.
    //    key = rc2CSP.Key;
    //    IV = rc2CSP.IV;

    //    //Get an encryptor.
    //    ICryptoTransform encryptor = rc2CSP.CreateEncryptor(key, IV);

    //    //Encrypt the data.
    //    MemoryStream msEncrypt = new MemoryStream();
    //    CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

    //    //Convert the data to a byte array.
    //    toEncrypt = textConverter.GetBytes(userId);

    //    //Write all data to the crypto stream and flush it.
    //    csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
    //    csEncrypt.FlushFinalBlock();

    //    //Get encrypted array of bytes.
    //    encrypted = msEncrypt.ToArray();
    //    string userIdEnc = Convert.ToBase64String(encrypted);
    //    return userIdEnc;
    //}


    /////////////////////////////////////////////////////////////////////////////////////////////
    //public static string DecryptUserID(string userId)
    //{
    //    byte[] key;
    //    byte[] IV;

    //    ASCIIEncoding textConverter = new ASCIIEncoding();
    //    RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

    //    rc2CSP.Key = Convert.FromBase64String(ConfigurationSettings.AppSettings["encKey"]);
    //    rc2CSP.IV = Convert.FromBase64String(ConfigurationSettings.AppSettings["IV"]);

    //    //Get the key and IV.
    //    key = rc2CSP.Key;
    //    IV = rc2CSP.IV;

    //    byte[] encPwd = Convert.FromBase64String(userId);
    //    ICryptoTransform decryptor = rc2CSP.CreateDecryptor(key, IV);

    //    MemoryStream msDecrypt = new MemoryStream(encPwd);
    //    CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

    //    byte[] fromEncrypt;
    //    fromEncrypt = new byte[encPwd.Length];

    //    //Read the data out of the crypto stream.
    //    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

    //    //Convert the byte array back into a string.
    //    return textConverter.GetString(fromEncrypt);
    //}

//////////////////////
    public static string Encrypt(string plainText,
                                 string passPhrase,
                                 string saltValue,
                                 string hashAlgorithm,
                                 int passwordIterations,
                                 string initVector,
                                 int keySize)
    {
        // Convert strings into byte arrays.
        // Let us assume that strings only contain ASCII codes.
        // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
        // encoding.
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

        // Convert our plaintext into a byte array.
        // Let us assume that plaintext contains UTF8-encoded characters.
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        // First, we must create a password, from which the key will be derived.
        // This password will be generated from the specified passphrase and 
        // salt value. The password will be created using the specified hash 
        // algorithm. Password creation can be done in several iterations.
        PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                        passPhrase,
                                                        saltValueBytes,
                                                        hashAlgorithm,
                                                        passwordIterations);

        // Use the password to generate pseudo-random bytes for the encryption
        // key. Specify the size of the key in bytes (instead of bits).
        byte[] keyBytes = password.GetBytes(keySize / 8);

        // Create uninitialized Rijndael encryption object.
        RijndaelManaged symmetricKey = new RijndaelManaged();

        // It is reasonable to set encryption mode to Cipher Block Chaining
        // (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC;

        // Generate encryptor from the existing key bytes and initialization 
        // vector. Key size will be defined based on the number of the key 
        // bytes.
        ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                         keyBytes,
                                                         initVectorBytes);

        // Define memory stream which will be used to hold encrypted data.
        MemoryStream memoryStream = new MemoryStream();

        // Define cryptographic stream (always use Write mode for encryption).
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                     encryptor,
                                                     CryptoStreamMode.Write);
        // Start encrypting.
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

        // Finish encrypting.
        cryptoStream.FlushFinalBlock();

        // Convert our encrypted data from a memory stream into a byte array.
        byte[] cipherTextBytes = memoryStream.ToArray();

        // Close both streams.
        memoryStream.Close();
        cryptoStream.Close();

        // Convert encrypted data into a base64-encoded string.
        string cipherText = Convert.ToBase64String(cipherTextBytes);

        // Return encrypted string.
        return cipherText;
    }

    public static string Decrypt(string cipherText,
                                 string passPhrase,
                                 string saltValue,
                                 string hashAlgorithm,
                                 int passwordIterations,
                                 string initVector,
                                 int keySize)
    {
        // Convert strings defining encryption key characteristics into byte
        // arrays. Let us assume that strings only contain ASCII codes.
        // If strings include Unicode characters, use Unicode, UTF7, or UTF8
        // encoding.
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

        // Convert our ciphertext into a byte array.
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

        // First, we must create a password, from which the key will be 
        // derived. This password will be generated from the specified 
        // passphrase and salt value. The password will be created using
        // the specified hash algorithm. Password creation can be done in
        // several iterations.
        PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                        passPhrase,
                                                        saltValueBytes,
                                                        hashAlgorithm,
                                                        passwordIterations);

        // Use the password to generate pseudo-random bytes for the encryption
        // key. Specify the size of the key in bytes (instead of bits).
        byte[] keyBytes = password.GetBytes(keySize / 8);

        // Create uninitialized Rijndael encryption object.
        RijndaelManaged symmetricKey = new RijndaelManaged();

        // It is reasonable to set encryption mode to Cipher Block Chaining
        // (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC;

        // Generate decryptor from the existing key bytes and initialization 
        // vector. Key size will be defined based on the number of the key 
        // bytes.
        ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                         keyBytes,
                                                         initVectorBytes);

        // Define memory stream which will be used to hold encrypted data.
        MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

        // Define cryptographic stream (always use Read mode for encryption).
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                      decryptor,
                                                      CryptoStreamMode.Read);

        // Since at this point we don't know what the size of decrypted data
        // will be, allocate the buffer long enough to hold ciphertext;
        // plaintext is never longer than ciphertext.
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];

        // Start decrypting.
        int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                   0,
                                                   plainTextBytes.Length);

        // Close both streams.
        memoryStream.Close();
        cryptoStream.Close();

        // Convert decrypted data into a string. 
        // Let us assume that the original plaintext string was UTF8-encoded.
        string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                   0,
                                                   decryptedByteCount);

        // Return decrypted string.   
        return plainText;
    }
}
