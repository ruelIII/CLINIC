namespace data
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPatientManagement = new Button();
            btnDoctorManagement = new Button();
            btnAppointmentManagement = new Button();
            btnUserManagement = new Button();
            SuspendLayout();
            // 
            // btnPatientManagement
            // 
            this.btnPatientManagement.Location = new System.Drawing.Point(30, 30);
            this.btnPatientManagement.Name = "btnPatientManagement";
            this.btnPatientManagement.Size = new System.Drawing.Size(160, 40);
            this.btnPatientManagement.TabIndex = 0;
            this.btnPatientManagement.Text = "Patient Management";
            this.btnPatientManagement.UseVisualStyleBackColor = true;
            this.btnPatientManagement.Click += new System.EventHandler(this.btnPatientManagement_Click);
            // 
            // btnDoctorManagement
            // 
            this.btnDoctorManagement.Location = new System.Drawing.Point(30, 80);
            this.btnDoctorManagement.Name = "btnDoctorManagement";
            this.btnDoctorManagement.Size = new System.Drawing.Size(160, 40);
            this.btnDoctorManagement.TabIndex = 1;
            this.btnDoctorManagement.Text = "Doctor Management";
            this.btnDoctorManagement.UseVisualStyleBackColor = true;
            this.btnDoctorManagement.Click += new System.EventHandler(this.btnDoctorManagement_Click);
            // 
            // btnAppointmentManagement
            // 
            this.btnAppointmentManagement.Location = new System.Drawing.Point(30, 130);
            this.btnAppointmentManagement.Name = "btnAppointmentManagement";
            this.btnAppointmentManagement.Size = new System.Drawing.Size(160, 40);
            this.btnAppointmentManagement.TabIndex = 2;
            this.btnAppointmentManagement.Text = "Appointment Management";
            this.btnAppointmentManagement.UseVisualStyleBackColor = true;
            this.btnAppointmentManagement.Click += new System.EventHandler(this.btnAppointmentManagement_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Location = new System.Drawing.Point(30, 180);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(160, 40);
            this.btnUserManagement.TabIndex = 3;
            this.btnUserManagement.Text = "User Management";
            this.btnUserManagement.UseVisualStyleBackColor = true;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(220, 250);
            Controls.Add(btnPatientManagement);
            Controls.Add(btnDoctorManagement);
            Controls.Add(btnAppointmentManagement);
            Controls.Add(btnUserManagement);
            Name = "MainForm";
            Text = "Main Form";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnPatientManagement;
        private System.Windows.Forms.Button btnDoctorManagement;
        private System.Windows.Forms.Button btnAppointmentManagement;
        private System.Windows.Forms.Button btnUserManagement;
    }
}
