using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace data
{
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            var sql = "INSERT INTO Doctors (Name, Specialization) VALUES (@name, @spec)";
            var parameters = new Dictionary<string, object>
            {
                {"@name", txtDocName.Text.Trim()},
                {"@spec", txtSpec.Text.Trim()}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadDoctors();
        }

        private void dgvDoctors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int doctorId = Convert.ToInt32(dgvDoctors.Rows[e.RowIndex].Cells["DoctorId"].Value);
            var sql = "UPDATE Doctors SET Name=@name, Specialization=@spec WHERE DoctorId=@id";
            var parameters = new Dictionary<string, object>
            {
                {"@name", txtDocName.Text.Trim()},
                {"@spec", txtSpec.Text.Trim()},
                {"@id", doctorId}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            var sql = "SELECT * FROM Doctors";
            DataTable dt = DataAccess.GetDataTable(sql, null);
            dgvDoctors.DataSource = dt;
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
