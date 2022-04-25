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

namespace Lab05
{
    public partial class manPerson : Form
    {
        SqlConnection con;
        public manPerson()
        {
            InitializeComponent();
            txtHireDate.Format = DateTimePickerFormat.Custom;
            txtHireDate.CustomFormat = "dd'/'MM'/'yyyy";
            txtEnrollmentDate.Format = DateTimePickerFormat.Custom;
            txtEnrollmentDate.CustomFormat = "dd'/'MM'/'yyyy";
        }

        private void manPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=DESKTOP-N8JRC5M;Database=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dgvListado.DataSource = dt;
            dgvListado.Refresh();
            con.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "InsertPerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int codigo = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show("Se ha registrado nueva persona con el codigo: "+ codigo);
            con.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "UpdatePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            if (txtHireDate.CustomFormat.Length > 1)
            {
                cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            }
            else { cmd.Parameters.AddWithValue("@HireDate", ""); }
            if (txtEnrollmentDate.CustomFormat.Length > 1)
            {
                cmd.Parameters.AddWithValue("@EnrollmentDate", txtHireDate.Value);
            }
            else { cmd.Parameters.AddWithValue("@EnrollmentDate", ""); }

            int resultado = cmd.ExecuteNonQuery();
            if(resultado > 0)
            {
                MessageBox.Show("Se ha modificado el registro correctamente");
            }
            con.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "DeletePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);

            int resultado = cmd.ExecuteNonQuery();
            if (resultado > 0)
            {
                MessageBox.Show("Se ha eliminado el registro correctamente");
            }
            con.Close();
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                txtPersonID.Text = dgvListado.SelectedRows[0].Cells[0].Value.ToString();
                txtFirstName.Text = dgvListado.SelectedRows[0].Cells[2].Value.ToString();
                txtLastName.Text = dgvListado.SelectedRows[0].Cells[1].Value.ToString();
                if (dgvListado.SelectedRows[0].Cells[3].Value.ToString() != "")
                {
                    txtHireDate.CustomFormat = "dd'/'MM'/'yyyy";
                    txtHireDate.Value = Convert.ToDateTime(dgvListado.SelectedRows[0].Cells[3].Value);
                }
                else
                {
                    txtHireDate.CustomFormat = " ";
                }
                if (dgvListado.SelectedRows[0].Cells[4].Value.ToString() != "")
                {
                    txtEnrollmentDate.CustomFormat = "dd'/'MM'/'yyyy";
                    txtEnrollmentDate.Value = Convert.ToDateTime(dgvListado.SelectedRows[0].Cells[4].Value);
                }
                else
                {
                    txtEnrollmentDate.CustomFormat = " ";
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtPersonID.Text.Length > 0)
            {
                con.Open();
                String sp = "BuscarPersonaId";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dgvListado.DataSource = dt;
                dgvListado.Refresh();
                con.Close();
            }
            else if (txtFirstName.Text.Length > 0)
            {
                con.Open();
                String sp = "BuscarPersonaNombre";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                
                dgvListado.DataSource = dt;
                dgvListado.Refresh();
                con.Close();
            }
        }
    }
}
