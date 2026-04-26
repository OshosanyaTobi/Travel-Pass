using ADODB;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TravelPass.Properties;

namespace TravelPass
{
    class _Encryption
    {
        static TripleDESCryptoServiceProvider myDES = new TripleDESCryptoServiceProvider();
        static MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();

        static Byte[] myMD5Hash(String strVal)
        {
            return myMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strVal));
        }

        public static String Encrypt(String strStringToEncrypt)
        {

            try
            {
                myDES.Key = myMD5Hash("TravelPass");
                myDES.Mode = CipherMode.ECB;
                Byte[] myBuffer = ASCIIEncoding.ASCII.GetBytes(strStringToEncrypt);
                return Convert.ToBase64String(myDES.CreateEncryptor().TransformFinalBlock(myBuffer, 0, myBuffer.Length));
            }
            catch {
                return "dhjfkdlfludyuf";
            };
        }

        public static String Decrypt(String strStringToDecrypt)
        {

            if (strStringToDecrypt.Trim() == "") return "";

            try
            {
                myDES.Key = myMD5Hash("TravelPass");
                myDES.Mode = CipherMode.ECB;
                Byte[] myBuffer = Convert.FromBase64String(strStringToDecrypt);
                return ASCIIEncoding.ASCII.GetString(myDES.CreateDecryptor().TransformFinalBlock(myBuffer, 0, myBuffer.Length));
            }
            catch
            {
                return "fdfyualm fibf";
            }
        }
    }
}
