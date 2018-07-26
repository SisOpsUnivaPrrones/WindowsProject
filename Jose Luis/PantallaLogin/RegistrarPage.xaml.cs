using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PantallaLogin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrarPage : Page
    {
        Conex con;
        public RegistrarPage()
        {
            this.InitializeComponent();
            con = new Conex();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(txtPassword.Password == txtConfirmaPassword.Password)
            {
                con.CrearUsuario(txtUsuario.Text.Trim(), txtPassword.Password);
                var message = new MessageDialog("Registro exitoso");
                await message.ShowAsync();
            }
            else
            {
                var message = new MessageDialog("Error: Contraseñas diferentes");
                await message.ShowAsync();
            }
            
        }
    }
}
