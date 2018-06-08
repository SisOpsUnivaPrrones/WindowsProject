using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Prueba
{
    public partial class Form1 : Form
    {
        clases.conexion conexion = new clases.conexion();
        public Form1()
        {
            InitializeComponent();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void dgv_empeado()
        {
            string selectQuery = "SELECT * FROM empleado2";
            DataTable empleado2 = new DataTable();
            MySqlDataAdapter adaptar = new MySqlDataAdapter(selectQuery, conexion._conexion);
            adaptar.Fill(empleado2);
            dgvempleado.DataSource = empleado2;
        }
        private void dgvempleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtnombre.Text = dgvempleado.CurrentRow.Cells[1].Value.ToString();
            txtapellidop.Text = dgvempleado.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "insert into empleado2 (nombre, password) Values('" + txtnombre.Text + "','" + txtapellidop.Text +"')";
            conexion.executeMyQuery(insertQuery);
            dgv_empeado();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string deleteQuery = "delete from empleado2 where id=" + int.Parse(txtid.Text);
            conexion.executeMyQuery(deleteQuery);
            dgv_empeado();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string updateQuery = "update empleado2 set nombre='" + txtnombre.Text + "',password='" + txtapellidop.Text + "' where id='"+txtid.Text+"'";
            conexion.executeMyQuery(updateQuery);
            dgv_empeado();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader leer;
            string select = "select *from empleado2 where id=" + int.Parse(txtid.Text);
            conexion._comando = new MySqlCommand(select, conexion._conexion);
            conexion.AbrirConexion();
            leer = conexion._comando.ExecuteReader();

            if (leer.Read())
            {
                txtnombre.Text = leer.GetString("Nombre");
                txtapellidop.Text = leer.GetString("password");
                MessageBox.Show("Encontrado");
            }

            else
            {

                MessageBox.Show("Trabajador no encontrado");
            }

            conexion.CerrarConexion();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlDataReader leer;
            string select = "select *from empleado2";
            conexion._comando = new MySqlCommand(select, conexion._conexion);
            conexion.AbrirConexion();
            leer = conexion._comando.ExecuteReader();

            if (leer.Read())
            {
                dgv_empeado();

            }

            else
            {

                MessageBox.Show("Trabajador no encontrado");
            }

            conexion.CerrarConexion();
        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}

