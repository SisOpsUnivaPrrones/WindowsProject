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
using MySql.Data.MySqlClient;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PantallaLogin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page{
        public MainPage(){
            this.InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e){
            Frame.Navigate(typeof(RegistrarPage));
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e){
            string user = txtUsuario.Text;
            string pass = txtPassword.Password;
            MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = Checocampeon#F1 ;database = Login");
            string query = "select count(*) from Usuarios where nombre = '" + txtUsuario.Text + "' and pswd= '" + txtPassword.Password + "'";
            MySqlCommand com = new MySqlCommand(query, conn);
            //MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from Usuarios where nombre = '" + txtUsuario.Text + "' and pswd= '" + txtPassword.Password + "'", conn);
            //DataTable dt = new DataTable();
            /**
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Datos correctos", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Datos incorrectos", "alter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }
    }
}
