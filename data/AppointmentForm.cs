using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace data
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            LoadPatients();
            LoadDoctors();
            LoadAppointments();
        }

        private void LoadPatients()
        {
            var sql = "SELECT PatientId, FirstName + ' ' + LastName AS Name FROM Patients WHERE Status='Active'";
            DataTable dt = DataAccess.GetDataTable(sql, null);
            cbPatients.DataSource = dt;
            cbPatients.DisplayMember = "Name";
            cbPatients.ValueMember = "PatientId";
        }

        private void LoadDoctors()
        {
            var sql = "SELECT DoctorId, Name FROM Doctors";
            DataTable dt = DataAccess.GetDataTable(sql, null);
            cbDoctors.DataSource = dt;
            cbDoctors.DisplayMember = "Name";
            cbDoctors.ValueMember = "DoctorId";
        }

        private void LoadAppointments()
        {
            var sql = @"SELECT a.AppointmentId, p.FirstName + ' ' + p.LastName AS Patient, d.Name AS Doctor, a.Date, a.Diagnosis, a.Status
                        FROM Appointments a
                        INNER JOIN Patients p ON a.PatientId = p.PatientId
                        INNER JOIN Doctors d ON a.DoctorId = d.DoctorId";
            DataTable dt = DataAccess.GetDataTable(sql, null);
            dgvAppointments.DataSource = dt;
        }

        private bool ValidateAppointmentFields()
        {
            if (cbPatients.SelectedValue == null || string.IsNullOrWhiteSpace(cbPatients.Text))
            {
                MessageBox.Show("Patient name is required.");
                return false;
            }
            if (cbDoctors.SelectedValue == null || string.IsNullOrWhiteSpace(cbDoctors.Text))
            {
                MessageBox.Show("Doctor is required.");
                return false;
            }
            if (dtpDate.Value == DateTime.MinValue)
            {
                MessageBox.Show("Appointment date is required.");
                return false;
            }
            // Patient DOB check (if needed, can be added here)
            return true;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            if (!ValidateAppointmentFields()) return;
            int patientId = Convert.ToInt32(cbPatients.SelectedValue);
            int doctorId = Convert.ToInt32(cbDoctors.SelectedValue);
            DateTime date = dtpDate.Value;
            string diagnosis = txtDiagnosis.Text.Trim();

            // Validation: Doctor cannot have two appointments at same datetime
            var checkSql = "SELECT COUNT(*) FROM Appointments WHERE DoctorId=@doc AND Date=@date AND Status='Scheduled'";
            var checkParams = new Dictionary<string, object>
            {
                {"@doc", doctorId},
                {"@date", date}
            };
            int count = Convert.ToInt32(DataAccess.ExecuteScalar(checkSql, checkParams));
            if (count > 0)
            {
                MessageBox.Show("Doctor already has an appointment at this time.");
                return;
            }

            // Validation: Archived patients cannot book
            var patientStatusSql = "SELECT Status FROM Patients WHERE PatientId=@pid";
            var patientStatusParams = new Dictionary<string, object> { {"@pid", patientId} };
            string status = DataAccess.ExecuteScalar(patientStatusSql, patientStatusParams)?.ToString();
            if (status != "Active")
            {
                MessageBox.Show("Archived patients cannot book appointments.");
                return;
            }

            var sql = "INSERT INTO Appointments (PatientId, DoctorId, Date, Diagnosis, Status) VALUES (@pid, @doc, @date, @diag, 'Scheduled')";
            var parameters = new Dictionary<string, object>
            {
                {"@pid", patientId},
                {"@doc", doctorId},
                {"@date", date},
                {"@diag", diagnosis}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadAppointments();
        }

        private void btnUpdateDiagnosis_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) return;
            int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentId"].Value);
            var sql = "UPDATE Appointments SET Diagnosis=@diag WHERE AppointmentId=@id";
            var parameters = new Dictionary<string, object>
            {
                {"@diag", txtDiagnosis.Text.Trim()},
                {"@id", appointmentId}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadAppointments();
        }

        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) return;
            int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentId"].Value);
            var sql = "UPDATE Appointments SET Status='Completed' WHERE AppointmentId=@id";
            var parameters = new Dictionary<string, object>
            {
                {"@id", appointmentId}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadAppointments();
        }

        private void btnSearchAppointments_Click(object sender, EventArgs e)
        {
            string doctorName = cbDoctors.Text.Trim();
            string patientName = cbPatients.Text.Trim();
            DateTime fromDate = dtpDate.Value.Date;
            DateTime toDate = dtpDate.Value.Date.AddDays(1); // Example: single day
            var sql = @"SELECT a.AppointmentId, p.FirstName + ' ' + p.LastName AS Patient, d.Name AS Doctor, a.Date, a.Diagnosis, a.Status
                        FROM Appointments a
                        INNER JOIN Patients p ON a.PatientId = p.PatientId
                        INNER JOIN Doctors d ON a.DoctorId = d.DoctorId
                        WHERE (d.Name LIKE @docName OR @docName = '')
                          AND (p.FirstName + ' ' + p.LastName LIKE @patName OR @patName = '')
                          AND (a.Date >= @fromDate AND a.Date < @toDate)";
            var parameters = new Dictionary<string, object>
            {
                {"@docName", "%" + doctorName + "%"},
                {"@patName", "%" + patientName + "%"},
                {"@fromDate", fromDate},
                {"@toDate", toDate}
            };
            DataTable dt = DataAccess.GetDataTable(sql, parameters);
            dgvAppointments.DataSource = dt;
        }
    }
}
