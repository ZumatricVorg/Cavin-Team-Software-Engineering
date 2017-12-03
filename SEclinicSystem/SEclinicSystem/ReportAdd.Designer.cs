namespace SEclinicSystem
{
    partial class ReportAdd
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
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddReport = new System.Windows.Forms.Button();
            this.txtAppointmentID = new System.Windows.Forms.TextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtGPName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(200, 448);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(430, 106);
            this.txtRemarks.TabIndex = 44;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(200, 152);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(430, 278);
            this.txtDescription.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 448);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 42;
            this.label8.Text = "Remarks: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "Description: ";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(75, 19);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(108, 17);
            this.label.TabIndex = 39;
            this.label.Text = "AppointmentID: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "Patient Name:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(479, 587);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(151, 43);
            this.btnBack.TabIndex = 32;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddReport
            // 
            this.btnAddReport.Location = new System.Drawing.Point(200, 587);
            this.btnAddReport.Name = "btnAddReport";
            this.btnAddReport.Size = new System.Drawing.Size(147, 43);
            this.btnAddReport.TabIndex = 31;
            this.btnAddReport.Text = "Add Report";
            this.btnAddReport.UseVisualStyleBackColor = true;
            this.btnAddReport.Click += new System.EventHandler(this.btnAddReport_Click);
            // 
            // txtAppointmentID
            // 
            this.txtAppointmentID.Location = new System.Drawing.Point(200, 19);
            this.txtAppointmentID.Name = "txtAppointmentID";
            this.txtAppointmentID.Size = new System.Drawing.Size(206, 22);
            this.txtAppointmentID.TabIndex = 45;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(200, 57);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(430, 22);
            this.txtPatientName.TabIndex = 46;
            // 
            // txtGPName
            // 
            this.txtGPName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtGPName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtGPName.Location = new System.Drawing.Point(200, 100);
            this.txtGPName.Name = "txtGPName";
            this.txtGPName.Size = new System.Drawing.Size(430, 22);
            this.txtGPName.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "GP Name:";
            // 
            // ReportAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 654);
            this.Controls.Add(this.txtGPName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.txtAppointmentID);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddReport);
            this.Name = "ReportAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddReport;
        private System.Windows.Forms.TextBox txtAppointmentID;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtGPName;
        private System.Windows.Forms.Label label1;
    }
}