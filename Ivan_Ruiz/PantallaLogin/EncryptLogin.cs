using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;

namespace PantallaLogin
{
    public class EncryptLogin
    {

        private static byte[] IV = { 12, 11, 12, 55, 0, 108, 121, 54 };
        private static string stringKey = "XZ*+2!@#4>.";
        private static BinaryStringEncoding encoding;
        private static byte[] keyByte;
        private static SymmetricKeyAlgorithmProvider objAlg;
        private static CryptographicKey Key;


        private async Task<string> EncryptStringHelper(string plainString, string key)  
        {  
            try  
            {  
                var hashKey = GetMD5Hash(key);  
                var decryptBuffer = CryptographicBuffer.ConvertStringToBinary(plainString, BinaryStringEncoding.Utf8);  
                var AES = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);  
                var symmetricKey = AES.CreateSymmetricKey(hashKey);  
                var encryptedBuffer = CryptographicEngine.Encrypt(symmetricKey, decryptBuffer, null);  
                var encryptedString = CryptographicBuffer.EncodeToBase64String(encryptedBuffer);  
                return encryptedString;  
            }  
            catch (Exception ex)  
            {  
                return "";  
            }  
        }  
        private async Task<string> DecryptStringHelper(string encryptedString, string key)  
        {  
            try  
            {  
                var hashKey = GetMD5Hash(key);  
                IBuffer decryptBuffer = CryptographicBuffer.DecodeFromBase64String(encryptedString);  
                var AES = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);  
                var symmetricKey = AES.CreateSymmetricKey(hashKey);  
                var decryptedBuffer = CryptographicEngine.Decrypt(symmetricKey, decryptBuffer, null);  
                string decryptedString = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, decryptedBuffer);  
                return decryptedString;  
            }  
            catch (Exception ex)  
            {  
                return "";  
            }  
        }  
        private static IBuffer GetMD5Hash(string key)  
        {  
            IBuffer bufferUTF8Msg = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);  
            HashAlgorithmProvider hashAlgorithmProvider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);  
            IBuffer hashBuffer = hashAlgorithmProvider.HashData(bufferUTF8Msg);  
            if (hashBuffer.Length != hashAlgorithmProvider.HashLength)  
            {  
                throw new Exception("There was an error creating the hash");  
            }  
            return hashBuffer;  
        }  

        public static string Encrypt(String strMsg)
        {
            IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary(strMsg, encoding);
            IBuffer buffEncrypt = CryptographicEngine.Encrypt(Key, buffMsg, IV.AsBuffer());
            return CryptographicBuffer.EncodeToBase64String(buffEncrypt);
        }

        public static string Decrypt(String strMsg)
        {
            Byte[] bb = Convert.FromBase64String(strMsg);
            IBuffer buffEncrypt = CryptographicEngine.Decrypt(Key, bb.AsBuffer(), IV.AsBuffer());
            return CryptographicBuffer.ConvertBinaryToString(encoding, buffEncrypt);
        }

        //public string EncryptString(string inputString)
        //{
        //    MemoryStream memStream = null;
        //    try
        //    {
        //        byte[] key = { };
        //        byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
        //        string encryptKey = "aXb2uy4z"; // MUST be 8 characters
        //        key = Encoding.UTF8.GetBytes(encryptKey);
        //        byte[] byteInput = Encoding.UTF8.GetBytes(inputString);
        //        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        //        memStream = new MemoryStream();
        //        ICryptoTransform transform = provider.CreateEncryptor(key, IV);
        //        CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
        //        cryptoStream.Write(byteInput, 0, byteInput.Length);
        //        cryptoStream.FlushFinalBlock();

        //    }
        //    catch (Exception ex)
        //    {
        //        Msgbox.Show(ex.Message);
        //    }
        //    return Convert.ToBase64String(memStream.ToArray());
        //}

        //public string DecryptString(string inputString)
        //{
        //    MemoryStream memStream = null;
        //    try
        //    {
        //        byte[] key = { };
        //        byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
        //        string encryptKey = "aXb2uy4z"; // MUST be 8 characters
        //        key = Encoding.UTF8.GetBytes(encryptKey);
        //        byte[] byteInput = new byte[inputString.Length];
        //        byteInput = Convert.FromBase64String(inputString);
        //        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        //        memStream = new MemoryStream();
        //        ICryptoTransform transform = provider.CreateDecryptor(key, IV);
        //        CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
        //        cryptoStream.Write(byteInput, 0, byteInput.Length);
        //        cryptoStream.FlushFinalBlock();
        //    }
        //    catch (Exception ex)
        //    {
        //        Msgbox.Show(ex.Message);
        //    }

        //}

        public static class Msgbox
        {
            static public async void Show(string m)
            {
                var dialog = new MessageDialog(m);
                await dialog.ShowAsync();
            }
        }
    }
}