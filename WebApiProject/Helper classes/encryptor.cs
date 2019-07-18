using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Helper_classes
{
    public static class Encryptor
    {

        // private static string EncryptionKey = "MAKV2SPBNI99212";
        private static readonly string EncryptionKey = @"1234123456785678";
        private static readonly string EncryptionIV = @"4566456678997899";
        //public static byte[] EncryptStringToBytes_Aes(string plainText)
        //{
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        encryptor.Padding = PaddingMode.Zeros;
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey,
        //            new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }

        //            plainText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }

        //    return clearBytes;

        //}

        //public static string DecryptStringFromBytes_Aes(byte[] cipherBytes)
        //{
        //    string cipherText = "";
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        encryptor.Padding = PaddingMode.Zeros;                                                                                                                                                                      
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey,
        //            new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }

        //           // cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //           cipherText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }

        //    return cipherText;
        //}



        public static byte[] Encrypt(string toEncrypt)
        {
            byte[] src = Encoding.UTF8.GetBytes(toEncrypt);
            byte[] des = new byte[src.Length];
            using (var encryptor = new AesCryptoServiceProvider())
            {
                 
                encryptor.BlockSize = 128;
                encryptor.KeySize = 128;
                encryptor.IV = Encoding.UTF8.GetBytes(EncryptionIV);
                encryptor.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                encryptor.Mode = CipherMode.CBC;
                encryptor.Padding = PaddingMode.Zeros;
                
                using (ICryptoTransform encrypt = encryptor.CreateEncryptor(encryptor.Key, encryptor.IV))
                {
                    des = encrypt.TransformFinalBlock(src, 0, src.Length);
                    return des;
                }
            }
        }

        public static string Decrypt(byte[] toDecrypt)
        {
            byte[] src = toDecrypt;
            byte[] des = new byte[src.Length];
            using (var encryptor = new AesCryptoServiceProvider())
            {
                encryptor.BlockSize = 128;
                encryptor.KeySize = 128;
                encryptor.IV = Encoding.UTF8.GetBytes(EncryptionIV);
                encryptor.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                encryptor.Mode = CipherMode.CBC;
                encryptor.Padding = PaddingMode.Zeros;
                
                using (ICryptoTransform encrypt = encryptor.CreateDecryptor(encryptor.Key, encryptor.IV))
                {
                    des = encrypt.TransformFinalBlock(src, 0, src.Length);
                    var finalString = Encoding.UTF8.GetString(des);
                    return finalString;
                }
            }
        }
        
    }
}

