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
        DataSet ds = new DataSet();
        DataTable tablePerson = new DataTable();
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
            tablePerson.Clear();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            adapter.Fill(ds,"Person");
            
            tablePerson = ds.Tables["Person"];
            //Console.WriteLine(tablePerson.Rows.Count);
            dgvListado.DataSource = tablePerson;
            dgvListado.Update();
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InsertPerson", con);

            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50, "LastName");
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50, "FirstName");
            cmd.Parameters.Add("@HireDate", SqlDbType.Date).SourceColumn = "HireDate";
            cmd.Parameters.Add("@EnrollmentDate", SqlDbType.Date).SourceColumn = "EnrollmentDate";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = cmd;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            DataRow fila = tablePerson.NewRow();
            fila["LastName"] = txtLastName.Text;
            fila["FirstName"] = txtFirstName.Text;

            if(txtHireDate.Checked == true)
                fila["HireDate"] = txtHireDate.Value;
            else
                fila["HireDate"] = Convert.DBNull;
   
            if (txtEnrollmentDate.Checked == true)
                fila["EnrollmentDate"] = txtHireDate.Value;
            else
                fila["EnrollmentDate"] = Convert.DBNull;

            tablePerson.Rows.Add(fila);

            adapter.Update(tablePerson);
            dgvListado.Refresh();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("UpdatePerson", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PersonID", SqlDbType.VarChar).SourceColumn = "PersonID";
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).SourceColumn = "LastName";
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).SourceColumn = "FirstName";
            cmd.Parameters.Add("@HireDate", SqlDbType.DateTime).SourceColumn = "HireDate";
            cmd.Parameters.Add("@EnrollmentDate", SqlDbType.DateTime).SourceColumn = "EnrollmentDate";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = cmd;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

            DataRow[] fila = tablePerson.Select("PersonID = '"+txtPersonID.Text+"'");
            fila[0]["LastName"] = txtLastName.Text;
            fila[0]["FirstName"] = txtFirstName.Text;

            if (txtHireDate.Checked == true)
            {
                fila[0]["HireDate"] = txtHireDate.Value;
            }
            else { fila[0]["HireDate"] = Convert.DBNull; }
            if (txtEnrollmentDate.Checked == true)
            {
                fila[0]["EnrollmentDate"] = txtEnrollmentDate.Value;
            }
            else { fila[0]["EnrollmentDate"] = Convert.DBNull; }

            adapter.Update(tablePerson);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DeletePerson", con);
            cmd.Parameters.Add("@PersonID", SqlDbType.Int).SourceColumn = "PersonID";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = cmd;
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

            DataRow[] fila = tablePerson.Select("PersonID = '"+txtPersonID.Text+"'");
            //tablePerson.Rows.Remove(fila[0]);
            fila[0].Delete();
            adapter.Update(tablePerson);
            
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                txtPersonID.Text = dgvListado.SelectedRows[0].Cells[0].Value.ToString();
                txtFirstName.Text = dgvListado.SelectedRows[0].Cells[2].Value.ToString();
                txtLastName.Text = dgvListado.SelectedRows[0].Cells[1].Value.ToString();

                String hireDate = dgvListado.SelectedRows[0].Cells[3].Value.ToString();
                if (String.IsNullOrEmpty(hireDate))
                {
                    txtHireDate.Checked = false;
                }
                else
                {
                    txtHireDate.Value = Convert.ToDateTime(hireDate);
                }

                String enrollmentDate = dgvListado.SelectedRows[0].Cells[4].Value.ToString();
                if (String.IsNullOrEmpty(enrollmentDate))
                {
                    txtEnrollmentDate.Checked = false;
                }
                else
                {
                    txtEnrollmentDate.Value = Convert.ToDateTime(enrollmentDate);
                }
            }
        }

        private void txtEnrollmentDate_ValueChanged(object sender, EventArgs e)
        {
            txtEnrollmentDate.CustomFormat = "dd'/'MM'/'yyyy";
        }

        private void btnOrdenApellido_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.Sort = "LastName ASC";
            dgvListado.DataSource = dv;
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "PersonID = '"+ txtPersonID.Text +"'";
            dgvListado.DataSource = dv;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPersonID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtHireDate.Checked = false;
            txtEnrollmentDate.Checked = false;
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "FirstName LIKE '"+txtFirstName.Text+"*'";
            dgvListado.DataSource = dv;
        }

        private void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "LastName LIKE '" + txtLastName.Text + "*'";
            dgvListado.DataSource = dv;
        }

        private void btnBuscarContrato_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "HireDate = '#" + txtHireDate.Value + "#'";
            dgvListado.DataSource = dv;
        }

        private void btnBuscarInsc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "EnrollmentDate = '#" + txtEnrollmentDate.Value + "#'";
            dgvListado.DataSource = dv;
        }
    }
}
