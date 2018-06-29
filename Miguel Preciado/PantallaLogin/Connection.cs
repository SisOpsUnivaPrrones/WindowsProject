using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantallaLogin
{
    public class Connection
    {
        public ObservableCollection<Usuario> GetUsuario(string connectionString)
        {
            const string GetProductsQuery = "select * from usuarios ";

            var products = new ObservableCollection<Usuario>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var usuario = new Usuario();
                                    usuario.usuario = reader.GetString(0);
                                    usuario.pass = reader.GetString(1);
                                    usuario.Add(usuario);
                                }
                            }
                        }
                    }
                }
                return products;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
}