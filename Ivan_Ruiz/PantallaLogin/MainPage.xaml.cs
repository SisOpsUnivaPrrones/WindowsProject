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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PantallaLogin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrarPage));
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsuario.Text;
            var pass = txtPassword.Password.ToString();
            MySQLCon mysql = new MySQLCon();
            List<string>[] checkUsers = new List<string>[1000];
            checkUsers = mysql.Select();
            if(username=="NobleSix" && pass == "haha")
            {
                Msgbox.Show("Bienvenido NobleSix");
            }
            else
            {
                Msgbox.Show("Usuario/Password Incorrecto");
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
    }
}
