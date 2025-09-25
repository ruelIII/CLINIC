namespace data
{
    partial class PatientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvPatients = new DataGridView();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtAddress = new TextBox();
            dtpDOB = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnArchive = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.Location = new Point(20, 160);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(540, 200);
            dgvPatients.TabIndex = 0;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(20, 20);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(120, 23);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(150, 20);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(120, 23);
            txtLastName.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(280, 20);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(180, 23);
            txtAddress.TabIndex = 3;
            // 
            // dtpDOB
            // 
            dtpDOB.Location = new Point(470, 20);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(120, 23);
            dtpDOB.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 60);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 30);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(110, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 30);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnArchive
            // 
            btnArchive.Location = new Point(200, 60);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(80, 30);
            btnArchive.TabIndex = 7;
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = true;
            btnArchive.Click += btnArchive_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(290, 60);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 30);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 380);
            Controls.Add(dgvPatients);
            Controls.Add(txtFirstName);
            Controls.Add(txtLastName);
            Controls.Add(txtAddress);
            Controls.Add(dtpDOB);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnArchive);
            Controls.Add(btnSearch);
            Name = "PatientForm";
            Text = "Patient Management";
            Load += PatientForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
