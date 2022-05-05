using CryptSharp.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NTec.API.Services
{
    public class CriptoService
    {
        //public static string Encrypt(string senha)
        //{
        //    try
        //    {
        //        string ToReturn = string.Empty;
        //        string publickey = "12345678";
        //        string secretkey = "87654321";
        //        byte[] secretkeyByte = { };
        //        secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
        //        byte[] publickeybyte = { };
        //        publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
        //        MemoryStream ms = null;
        //        CryptoStream cs = null;
        //        byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(senha);
        //        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        //        {
        //            ms = new MemoryStream();
        //            cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
        //            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
        //            cs.FlushFinalBlock();
        //            ToReturn = Convert.ToBase64String(ms.ToArray());
        //        }
        //        return ToReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //}
        //public static string Decrypt(string senha)
        //{
        //    try
        //    {
        //        string textToDecrypt = "6+PXxVWlBqcUnIdqsMyUHA==";
        //        string ToReturn = "";
        //        string publickey = "12345678";
        //        string secretkey = "87654321";
        //        byte[] privatekeyByte = { };
        //        privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
        //        byte[] publickeybyte = { };
        //        publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
        //        MemoryStream ms = null;
        //        CryptoStream cs = null;
        //        byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
        //        inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
        //        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        //        {
        //            ms = new MemoryStream();
        //            cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
        //            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
        //            cs.FlushFinalBlock();
        //            Encoding encoding = Encoding.UTF8;
        //            ToReturn = encoding.GetString(ms.ToArray());
        //        }
        //        return ToReturn;
        //    }
        //    catch (Exception ae)
        //    {
        //        throw new Exception(ae.Message, ae.InnerException);
        //    }
        //}

        public byte[] CreateHash()
        {
            var salt = new byte[16];

            using (var provider = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                provider.GetBytes(salt);
            }

            return salt;
        }

        public byte[] CreateHash(string pwd)
        {
            var temp = new System.Security.Cryptography.HMACSHA512() { Key = Encoding.UTF8.GetBytes(pwd) };
            var salt = this.CreateHash();
            var password = Pbkdf2.ComputeDerivedKey(temp, salt, UInt16.MaxValue, temp.HashSize / 8);

            return password;
        }
        
    }
}
