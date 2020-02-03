using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CommonBusinessComponent 
{
    public class MihiCryptoEngine
    {
        public static string GUEncrypt(string value)
        {
            var keyValue = "bolg-pula-edis20";
            return (GUEncrypt(value, keyValue));
        }

        public static string GUEncrypt(string value, string key)
        {
            try
            {
                byte[] valueArray = Encoding.UTF8.GetBytes(value);
                var tripleDES = new TripleDESCryptoServiceProvider
                {
                    Key = Encoding.UTF8.GetBytes(key),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(valueArray, 0, valueArray.Length);
                tripleDES.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string GUDecrypt(string value)
        {
            var keyValue = "bolg-pula-edis20";
            return (GUDecrypt(value, keyValue));
        }

        public static string GUDecrypt(string value, string key)
        {
            try
            {
                byte[] valueArray = Convert.FromBase64String(value);
                var tripleDES = new TripleDESCryptoServiceProvider
                {
                    Key = Encoding.UTF8.GetBytes(key),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(valueArray, 0, valueArray.Length);
                tripleDES.Clear();
                return Encoding.UTF8.GetString(resultArray);
            }
            catch(Exception ex)
            {

                return string.Empty;
            }
        }


        public static string EncryptQRT(string inputVal)
        {
            try
            {
                string guEKey = "EDISPU0202LABOLG";
                byte[] clearBytes = Encoding.Unicode.GetBytes(inputVal);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(guEKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    aes.Key = rfc2898DeriveBytes.GetBytes(32);
                    aes.IV = rfc2898DeriveBytes.GetBytes(16);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(clearBytes, 0, clearBytes.Length);
                            cryptoStream.Close();
                        }
                        inputVal = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
                return inputVal;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        public static string DecryptQRT(string inputVal)
        {
            try
            {
                string guDKey = "EDISPU0202LABOLG";
                byte[] cipherBytes = Convert.FromBase64String(inputVal);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(guDKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    aes.Key = rfc2898DeriveBytes.GetBytes(32);
                    aes.IV = rfc2898DeriveBytes.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                            cryptoStream.Close();
                        }
                        inputVal = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return inputVal;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
