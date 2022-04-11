using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab03
{
    public partial class frmLogin : Form
    {
        SqlConnection conn;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            String servidor = "DESKTOP-N8JRC5M"; //Nombre del servidor
            String bd = "db_lab03"; //Nombre DB
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;

            String str = "Server=" + servidor + ";Database=" + bd + ";Integrated Security=true"+";";
                
            try
            {
                conn = new SqlConnection(str);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InicioSesion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter paramUser = new SqlParameter();
                paramUser.ParameterName = "@Username";
                paramUser.SqlDbType = SqlDbType.NVarChar;
                paramUser.Value = usuario;

                cmd.Parameters.Add(paramUser);

                SqlParameter paramPass = new SqlParameter();
                paramPass.ParameterName = "@Password";
                paramPass.SqlDbType = SqlDbType.NVarChar;
                paramPass.Value = password;

                cmd.Parameters.Add(paramPass);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if(dt.Rows.Count > 0)
                {
                    txtUsuario.Text = "";
                    txtPassword.Text = "";
                    MessageBox.Show("Inicio sesión satisfactoriamente");
                    Form1 inicio = new Form1(this);
                    inicio.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos!");
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar el servidor: \n" + ex.ToString());
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
