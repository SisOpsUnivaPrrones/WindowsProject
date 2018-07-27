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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PantallaLogin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ///ConexSQL conex;
        Conex con;
      

        public MainPage()
        {
            this.InitializeComponent();
            //conex = new ConexMySQL();
            con = new Conex();
            
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrarPage));
        }

        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {

            

            if (con.ValidarUsuario(txtUsuario.Text, txtPassword.Password)){
                var message = new MessageDialog("Login exitoso");
                await message.ShowAsync();
            }
            else
            {
                var message = new MessageDialog("Login fallido");
                await message.ShowAsync();
            }

        }
    }
        
}
