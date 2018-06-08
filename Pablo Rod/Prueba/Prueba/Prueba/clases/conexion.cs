using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Prueba.clases
{


    class conexion
    {
        public MySqlConnection _conexion;
        public MySqlCommand _comando;
        public conexion()
        {
            _conexion = new MySqlConnection("server=127.0.0.1; database=proj; Uid=root; pwd='';");

        }

        public bool AbrirConexion()
        {

            try
            {
                _conexion.Open();
                return true;

            }

            catch (MySqlException exeption)
            {
                return false;
                throw exeption;
            }

        }

        public bool CerrarConexion()
        {
            try
            {
                _conexion.Close();
                return true;

            }

            catch (MySqlException exeption)
            {
                return false;
                throw exeption;
            }
        }

        public void executeMyQuery(string query)
        {
            try
            {
                _conexion.Open();
                _comando = new MySqlCommand(query, _conexion);



                if (_comando.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Query ejecutado con exito");

                }
                else
                {

                    MessageBox.Show("Query  no ejecutado ");

                }

            }

            catch (MySqlException exeption)
            {
                MessageBox.Show(exeption.Message);


            }

            finally
            {

                _conexion.Close();


            }
        }
    }
}
