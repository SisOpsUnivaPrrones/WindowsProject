using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantallaLogin
{
    public static bool probarConexion()
    {
        MySqlConnection con;
        String servidor = "localhost";
        String puerto = "3306";
        String usuario = "admin";
        String password = "admin";
        String database = "login";

        //Cadena de conexion
        Sesion.cadenaConexion = String.Format("server={0};port={1};user id={2}; password={3}; database={4}", servidor, puerto, usuario, password, database);

        con = new MySqlConnection(Sesion.cadenaConexion);
        con.Open();//se abre la conexion
        if (con.State == System.Data.ConnectionState.Open)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
