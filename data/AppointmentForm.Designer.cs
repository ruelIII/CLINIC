namespace data
{
    partial class AppointmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbPatients;
        private System.Windows.Forms.ComboBox cbDoctors;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnUpdateDiagnosis;
        private System.Windows.Forms.Button btnMarkCompleted;
        private System.Windows.Forms.Button btnSearchAppointments;
        private System.Windows.Forms.DataGridView dgvAppointments;

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
            this.cbPatients = new System.Windows.Forms.ComboBox();
            this.cbDoctors = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnUpdateDiagnosis = new System.Windows.Forms.Button();
            this.btnMarkCompleted = new System.Windows.Forms.Button();
            this.btnSearchAppointments = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPatients
            // 
            this.cbPatients.Location = new System.Drawing.Point(20, 20);
            this.cbPatients.Name = "cbPatients";
            this.cbPatients.Size = new System.Drawing.Size(180, 23);
            this.cbPatients.TabIndex = 0;
            // 
            // cbDoctors
            // 
            this.cbDoctors.Location = new System.Drawing.Point(210, 20);
            this.cbDoctors.Name = "cbDoctors";
            this.cbDoctors.Size = new System.Drawing.Size(180, 23);
            this.cbDoctors.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(400, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(180, 23);
            this.dtpDate.TabIndex = 2;
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(590, 20);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(180, 23);
            this.txtDiagnosis.TabIndex = 3;
            this.txtDiagnosis.PlaceholderText = "Diagnosis";
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(20, 60);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(100, 30);
            this.btnSchedule.TabIndex = 4;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnUpdateDiagnosis
            // 
            this.btnUpdateDiagnosis.Location = new System.Drawing.Point(130, 60);
            this.btnUpdateDiagnosis.Name = "btnUpdateDiagnosis";
            this.btnUpdateDiagnosis.Size = new System.Drawing.Size(130, 30);
            this.btnUpdateDiagnosis.TabIndex = 5;
            this.btnUpdateDiagnosis.Text = "Update Diagnosis";
            this.btnUpdateDiagnosis.UseVisualStyleBackColor = true;
            this.btnUpdateDiagnosis.Click += new System.EventHandler(this.btnUpdateDiagnosis_Click);
            // 
            // btnMarkCompleted
            // 
            this.btnMarkCompleted.Location = new System.Drawing.Point(270, 60);
            this.btnMarkCompleted.Name = "btnMarkCompleted";
            this.btnMarkCompleted.Size = new System.Drawing.Size(130, 30);
            this.btnMarkCompleted.TabIndex = 6;
            this.btnMarkCompleted.Text = "Mark Completed";
            this.btnMarkCompleted.UseVisualStyleBackColor = true;
            this.btnMarkCompleted.Click += new System.EventHandler(this.btnMarkCompleted_Click);
            // 
            // btnSearchAppointments
            // 
            this.btnSearchAppointments.Location = new System.Drawing.Point(410, 60);
            this.btnSearchAppointments.Name = "btnSearchAppointments";
            this.btnSearchAppointments.Size = new System.Drawing.Size(130, 30);
            this.btnSearchAppointments.TabIndex = 7;
            this.btnSearchAppointments.Text = "Search";
            this.btnSearchAppointments.UseVisualStyleBackColor = true;
            this.btnSearchAppointments.Click += new System.EventHandler(this.btnSearchAppointments_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.Location = new System.Drawing.Point(20, 110);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new System.Drawing.Size(750, 250);
            this.dgvAppointments.TabIndex = 8;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.cbPatients);
            this.Controls.Add(this.cbDoctors);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.btnUpdateDiagnosis);
            this.Controls.Add(this.btnMarkCompleted);
            this.Controls.Add(this.btnSearchAppointments);
            this.Controls.Add(this.dgvAppointments);
            this.Name = "AppointmentForm";
            this.Text = "Appointment Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
