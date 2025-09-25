namespace data
{
    partial class DoctorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDoctors;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Button btnAddDoctor;

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
            dgvDoctors = new DataGridView();
            txtDocName = new TextBox();
            txtSpec = new TextBox();
            btnAddDoctor = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).BeginInit();
            SuspendLayout();
            // 
            // dgvDoctors
            // 
            dgvDoctors.Location = new Point(20, 80);
            dgvDoctors.Name = "dgvDoctors";
            dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctors.Size = new Size(400, 200);
            dgvDoctors.TabIndex = 0;
            dgvDoctors.CellDoubleClick += dgvDoctors_CellDoubleClick;
            // 
            // txtDocName
            // 
            txtDocName.Location = new Point(20, 20);
            txtDocName.Name = "txtDocName";
            txtDocName.PlaceholderText = "Doctor Name";
            txtDocName.Size = new Size(180, 23);
            txtDocName.TabIndex = 1;
            // 
            // txtSpec
            // 
            txtSpec.Location = new Point(210, 20);
            txtSpec.Name = "txtSpec";
            txtSpec.PlaceholderText = "Specialization";
            txtSpec.Size = new Size(180, 23);
            txtSpec.TabIndex = 2;
            // 
            // btnAddDoctor
            // 
            btnAddDoctor.Location = new Point(400, 20);
            btnAddDoctor.Name = "btnAddDoctor";
            btnAddDoctor.Size = new Size(80, 30);
            btnAddDoctor.TabIndex = 3;
            btnAddDoctor.Text = "Add Doctor";
            btnAddDoctor.UseVisualStyleBackColor = true;
            btnAddDoctor.Click += btnAddDoctor_Click;
            // 
            // DoctorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 320);
            Controls.Add(dgvDoctors);
            Controls.Add(txtDocName);
            Controls.Add(txtSpec);
            Controls.Add(btnAddDoctor);
            Name = "DoctorForm";
            Text = "Doctor Management";
            Load += DoctorForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
