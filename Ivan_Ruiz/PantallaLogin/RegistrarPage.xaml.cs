using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PantallaLogin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrarPage : Page
    {
        public RegistrarPage()
        {
            this.InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string stringKey = "XZ*+2!@#4>.";
            var button = sender as Button;
            var username = txtUsuario.Text;
            var password = txtPassword.Password.ToString();
            var confpass = txtConfirmaPassword.Password.ToString();
            string encryptPass = await EncryptStringHelper(password,stringKey);

            if (password == confpass)
            {
                MySQLCon mysql = new MySQLCon();
                mysql.InsertUser(username, password);
            }
            else
            {
                Msgbox.Show("Los passwords no coinciden.");
            }

            
        }

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
    }

    public static class Msgbox
    {
        static public async void Show(string m)
        {
            var dialog = new MessageDialog(m);
            await dialog.ShowAsync();
        }
    }
    
}
