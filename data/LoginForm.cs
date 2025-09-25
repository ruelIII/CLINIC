using System;
using System.Data;
using System.Windows.Forms;

namespace data
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            var sql = "SELECT UserId, Role FROM Users WHERE Username=@u AND Password=@p";
            var parameters = new System.Collections.Generic.Dictionary<string, object>
            {
                {"@u", username},
                {"@p", password}
            };
            DataTable dt = DataAccess.GetDataTable(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                string role = dt.Rows[0]["Role"].ToString();
                var mainForm = new MainForm(role, userId);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid login", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
