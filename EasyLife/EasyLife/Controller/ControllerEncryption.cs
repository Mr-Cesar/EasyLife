using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* Encryption */

using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Controller
{
    public class ControllerEncryption
    {
        public static string stEncryptionMD5(string stCadena)
        {
            byte[] BtclearBytes;
            BtclearBytes = new UnicodeEncoding().GetBytes(stCadena);
            byte[] BthashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(BtclearBytes);
            string stHashedText = BitConverter.ToString(BthashedBytes);
            return stHashedText;
        }

        public static string stEncryption3DES(string stCadena, string stKey)
        {
            try
            {
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hashMD5;

                byte[] keyHash, buff;
                string stEncrypted;

                hashMD5 = new MD5CryptoServiceProvider();
                keyHash = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(stKey));

                hashMD5 = null;
                des = new TripleDESCryptoServiceProvider();

                des.Key = keyHash;
                des.Mode = CipherMode.ECB;

                buff = ASCIIEncoding.ASCII.GetBytes(stCadena);
                stEncrypted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));

                return stEncrypted;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
                return null;
            }
        }

        public static string stDecrypt(string stCadena, string stKey)
        {
            try
            {
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hashMD5;

                byte[] keyHash, buff;
                string stDecrypt;

                hashMD5 = new MD5CryptoServiceProvider();
                keyHash = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(stKey));

                hashMD5 = null;
                des = new TripleDESCryptoServiceProvider();

                des.Key = keyHash;
                des.Mode = CipherMode.ECB;

                buff = Convert.FromBase64String(stCadena);
                stDecrypt = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));

                return stDecrypt;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
                return null;
            }
        }
    }
}