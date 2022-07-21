using System;
using System.Collections.Generic;
using System.IO;
 
using System.Security.Cryptography;
using System.Text;

namespace NASMB.Utils
{
    public class AESEncrypt
    {
        #region ===========加密============
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        //public static []values Encrypt(string Text)
        //{
        //    return Encrypt(Text, "meig");
        //}

        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static byte[] Encrypt(string plainText, byte[] sKey)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (sKey == null || sKey.Length <= 0)
                throw new ArgumentNullException("Key");

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
              //  aesAlg.Mode = CipherMode.CBC;
                aesAlg.Key = sKey;
                aesAlg.IV = sKey.Take(16).ToArray();
              //  Array.Copy(sKey, , 16);
               // aesAlg.Padding = PaddingMode.PKCS7;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                      //  StringBuilder ret = new StringBuilder();

                        return msEncrypt.ToArray();
                        //foreach (byte b in msEncrypt.ToArray())
                        //{
                        //    ret.AppendFormat("{0:X2}", b);
                        //}
                        //// Return the encrypted string from the memory stream.
                        //return ret.ToString();
                    }
                }
            }
        }

        #endregion


        #region ========解密========
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        //public static string Decrypt(string Text)
        //{
        //    return Decrypt(Text, "meig");
        //}

        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(byte[] cipherText, byte[] sKey)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (sKey == null || sKey.Length <= 0)
                throw new ArgumentNullException("Key");
 

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                //aesAlg.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 16));
                //aesAlg.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 16)); 
                aesAlg.Key = sKey;
                aesAlg.IV = sKey.Take(16).ToArray();


                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
          //     aesAlg.Padding = PaddingMode.PKCS7;

                //return System.Text.Encoding.Default.GetString(aesAlg.DecryptCbc(cipherText, aesAlg.IV));
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            //Read the decrypted userData from the decrypting stream
                            // and place them in a string.
                   
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
        #endregion 
    }
}
