using System;
using System.IO;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Web.UI.WebControls.WebParts;

namespace BCL.Security.CryptoGraphy
{
    public class Encryptor
    {
        public static string Encrypt(string clearText, string password, byte[] salt)
        {
            // Turn text to bytes
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.Close();

            byte[] EncryptedData = ms.ToArray();

            return Convert.ToBase64String(EncryptedData);
        }

        public static string Decrypt(string cipherText, string password,
           byte[] salt)
        {
            // Convert text to byte
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherBytes, 0, cipherBytes.Length);
            cs.Close();

            byte[] DecryptedData = ms.ToArray();

            return Encoding.Unicode.GetString(DecryptedData);
        }
    }
}
