using System;
using System.Windows.Forms;

namespace data
{
    public partial class MainForm : Form
    {
        private string _role;
        private int _userId;

        public MainForm(string role, int userId)
        {
            _role = role;
            _userId = userId;
            InitializeComponent();
            ConfigureButtonsByRole();
        }

        private void ConfigureButtonsByRole()
        {
            btnPatientManagement.Visible = _role == "Admin" || _role == "Staff";
            btnDoctorManagement.Visible = _role == "Admin";
            btnAppointmentManagement.Visible = _role == "Admin" || _role == "Doctor" || _role == "Staff";
            btnUserManagement.Visible = _role == "Admin";

            // Limiting functionality for Staff and Doctor
            if (_role == "Staff")
            {
                btnPatientManagement.Enabled = true; // limited logic can be added on click
                btnAppointmentManagement.Enabled = true; // limited logic can be added on click
                btnDoctorManagement.Enabled = false;
                btnUserManagement.Enabled = false;
            }
            if (_role == "Doctor")
            {
                btnAppointmentManagement.Enabled = true; // filter by _userId (doctor)
                btnPatientManagement.Enabled = false;
                btnDoctorManagement.Enabled = false;
                btnUserManagement.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPatientManagement_Click(object sender, EventArgs e)
        {
            var patientForm = new PatientForm(_role);
            patientForm.ShowDialog();
        }

        private void btnDoctorManagement_Click(object sender, EventArgs e)
        {
            var doctorForm = new DoctorForm();
            doctorForm.ShowDialog();
        }

        private void btnAppointmentManagement_Click(object sender, EventArgs e)
        {
            var appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            var userForm = new UserManagementForm(_role);
            userForm.ShowDialog();
        }
    }
}
