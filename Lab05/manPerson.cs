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
            txtEnrollmentDay.Format = DateTimePickerFormat.Custom;
            txtEnrollmentDay.CustomFormat = "dd'/'MM'/'yyyy";
        }

        private void manPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=DESKTOP-N8JRC5M;Database=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }
    }
}
