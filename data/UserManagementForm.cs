using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace data
{
    public partial class UserManagementForm : Form
    {
        private string _role;
        public UserManagementForm(string role)
        {
            _role = role;
            if (_role != "Admin")
            {
                MessageBox.Show("Access denied. Only Admin can manage users.");
                Close();
                return;
            }
            InitializeComponent();
            cbRole.Items.AddRange(new string[] { "Admin", "Doctor", "Staff" });
            LoadUsers();
        }

        private void LoadUsers()
        {
            var sql = "SELECT UserId, Username, Role FROM Users";
            DataTable dt = DataAccess.GetDataTable(sql, null);
            dgvUsers.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || cbRole.SelectedItem == null)
            {
                MessageBox.Show("All fields are required.");
                return;
            }
            // Check for unique username
            var checkSql = "SELECT COUNT(*) FROM Users WHERE Username=@u";
            var checkParams = new Dictionary<string, object> { {"@u", txtUsername.Text.Trim()} };
            int exists = Convert.ToInt32(DataAccess.ExecuteScalar(checkSql, checkParams));
            if (exists > 0)
            {
                MessageBox.Show("Username already exists.");
                return;
            }
            var sql = "INSERT INTO Users (Username, Password, Role) VALUES (@u, @p, @r)";
            var parameters = new Dictionary<string, object>
            {
                {"@u", txtUsername.Text.Trim()},
                {"@p", txtPassword.Text.Trim()},
                {"@r", cbRole.SelectedItem.ToString()}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadUsers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || cbRole.SelectedItem == null)
            {
                MessageBox.Show("All fields are required.");
                return;
            }
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);
            var sql = "UPDATE Users SET Username=@u, Password=@p, Role=@r WHERE UserId=@id";
            var parameters = new Dictionary<string, object>
            {
                {"@u", txtUsername.Text.Trim()},
                {"@p", txtPassword.Text.Trim()},
                {"@r", cbRole.SelectedItem.ToString()},
                {"@id", userId}
            };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);
            var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;
            var sql = "DELETE FROM Users WHERE UserId=@id";
            var parameters = new Dictionary<string, object> { {"@id", userId} };
            DataAccess.ExecuteNonQuery(sql, parameters);
            LoadUsers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            txtUsername.Text = dgvUsers.CurrentRow.Cells["Username"].Value?.ToString();
            // For security, you may want to leave password blank or fetch it if needed
            txtPassword.Text = "";
            cbRole.SelectedItem = dgvUsers.CurrentRow.Cells["Role"].Value?.ToString();
        }
    }
}
