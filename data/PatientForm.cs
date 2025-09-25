using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace data
{
    public partial class PatientForm : Form
    {
        private string _role;
        public PatientForm(string role)
        {
            _role = role;
            InitializeComponent();
            ApplyRoleRestrictions();
            LoadPatients();
        }

        private void ApplyRoleRestrictions()
        {
            if (_role == "Admin")
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnArchive.Enabled = true;
                dgvPatients.ReadOnly = false;
            }
            else if (_role == "Staff")
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnArchive.Enabled = false;
                dgvPatients.ReadOnly = false;
            }
            else if (_role == "Doctor")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnArchive.Enabled = false;
                dgvPatients.ReadOnly = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_role == "Doctor") return;
            var sql = "INSERT INTO Patients (FirstName, LastName, DOB, Address, Status) VALUES (@fn, @ln, @dob, @addr, 'Active')";
            var parameters = new Dictionary<string, object>
            {
                {"@fn", txtFirstName.Text.Trim()},
                {"@ln", txtLastName.Text.Trim()},
                {"@dob", dtpDOB.Value.Date},
                {"@addr", txtAddress.Text.Trim()}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadPatients();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_role == "Doctor") return;
            if (dgvPatients.CurrentRow == null) return;
            int patientId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["PatientId"].Value);
            var sql = "UPDATE Patients SET FirstName=@fn, LastName=@ln, DOB=@dob, Address=@addr WHERE PatientId=@id";
            var parameters = new Dictionary<string, object>
            {
                {"@fn", txtFirstName.Text.Trim()},
                {"@ln", txtLastName.Text.Trim()},
                {"@dob", dtpDOB.Value.Date},
                {"@addr", txtAddress.Text.Trim()},
                {"@id", patientId}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadPatients();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (_role != "Admin" || dgvPatients.CurrentRow == null) return;
            int patientId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["PatientId"].Value);
            var sql = "UPDATE Patients SET Status='Archived' WHERE PatientId=@id";
            var parameters = new Dictionary<string, object>
            {
                {"@id", patientId}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadPatients();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtFirstName.Text.Trim();
            string status = ""; // You can add a ComboBox for status selection if needed
            var sql = "SELECT * FROM Patients WHERE (FirstName LIKE @name OR LastName LIKE @name)";
            var parameters = new Dictionary<string, object>
            {
                {"@name", "%" + name + "%"}
            };
            // If you add status filter:
            // sql += " AND Status=@status";
            // parameters.Add("@status", status);
            DataTable dt = DataAccess.GetDataTable(sql, parameters);
            dgvPatients.DataSource = dt;
        }

        private void LoadPatients()
        {
            var sql = "SELECT * FROM Patients WHERE Status='Active'";
            DataTable dt = DataAccess.GetDataTable(sql, null);
            dgvPatients.DataSource = dt;
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
