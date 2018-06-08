using System;
using UWPLoginPage.Common;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPLoginPage
{

    public sealed partial class MainPage : Page
    {
        Database db;
        public MainPage()
        {
            this.InitializeComponent();
            db = new Database();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(db.Login(txtUser.Text,ComputeSha(txtPassword.Password+txtUser.Text)))
            {
                var message = new MessageDialog("Inicio sesion exitosamente");
                await message.ShowAsync();
            }
            else
            {
                var message = new MessageDialog("Fallo el inicio de sesion");
                await message.ShowAsync();
            }
        }

        private static string ComputeSha(string str)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            var res = CryptographicBuffer.EncodeToHexString(hashed);
            return res;
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
