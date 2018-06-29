using System;
using UWPLoginPage.Common;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;


namespace UWPLoginPage
{
    public sealed partial class RegisterPage : Page
    {
        Database db;
        public RegisterPage()
        {
            this.InitializeComponent();
            db = new Database();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Handle Back Button
            SystemNavigationManager.GetForCurrentView().BackRequested += RegisterPage_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            //Remove Handle Back Button
            SystemNavigationManager.GetForCurrentView().BackRequested -= RegisterPage_BackRequested;

        }

        private void RegisterPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
           int code =  db.Register(new Common.User() {
                UserName = txtUserName.Text.Trim(),
                Password = ComputeSha(txtPassword.Password+txtUserName.Text.Trim()),
                Email = txtEmail.Text.Trim()
            });
            if(code == -1)
            {
                var message = new MessageDialog("Registro error");
                await message.ShowAsync();
            }
            else
            {
                var message = new MessageDialog("Registro correcto");
                await message.ShowAsync();
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private static string ComputeSha(string str)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            var res = CryptographicBuffer.EncodeToHexString(hashed);
            return res;
        }

    }
}
