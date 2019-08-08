namespace SEclinicSystem
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.staffID = new System.Windows.Forms.Label();
            this.staffName = new System.Windows.Forms.Label();
            this.SearchPatient = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.gpName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchAptBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delApt = new System.Windows.Forms.Button();
            this.upDateApt = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(543, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // staffID
            // 
            this.staffID.AutoSize = true;
            this.staffID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffID.Location = new System.Drawing.Point(540, 166);
            this.staffID.Name = "staffID";
            this.staffID.Size = new System.Drawing.Size(52, 17);
            this.staffID.TabIndex = 1;
            this.staffID.Text = "staff ID";
            // 
            // staffName
            // 
            this.staffName.AutoSize = true;
            this.staffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffName.Location = new System.Drawing.Point(540, 192);
            this.staffName.Name = "staffName";
            this.staffName.Size = new System.Drawing.Size(76, 17);
            this.staffName.TabIndex = 2;
            this.staffName.Text = "staff Name";
            // 
            // SearchPatient
            // 
            this.SearchPatient.Location = new System.Drawing.Point(18, 12);
            this.SearchPatient.Name = "SearchPatient";
            this.SearchPatient.Size = new System.Drawing.Size(124, 23);
            this.SearchPatient.TabIndex = 3;
            this.SearchPatient.Text = "Search Patient";
            this.SearchPatient.UseVisualStyleBackColor = true;
            this.SearchPatient.Click += new System.EventHandler(this.SearchPatient_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(543, 360);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(75, 38);
            this.logoutBtn.TabIndex = 6;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // gpName
            // 
            this.gpName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.gpName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.gpName.Location = new System.Drawing.Point(77, 65);
            this.gpName.Name = "gpName";
            this.gpName.Size = new System.Drawing.Size(138, 20);
            this.gpName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "GP Name:";
            // 
            // searchAptBtn
            // 
            this.searchAptBtn.Location = new System.Drawing.Point(421, 63);
            this.searchAptBtn.Name = "searchAptBtn";
            this.searchAptBtn.Size = new System.Drawing.Size(75, 23);
            this.searchAptBtn.TabIndex = 9;
            this.searchAptBtn.Text = "Search";
            this.searchAptBtn.UseVisualStyleBackColor = true;
            this.searchAptBtn.Click += new System.EventHandler(this.searchAptBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(478, 234);
            this.dataGridView1.TabIndex = 10;
            // 
            // delApt
            // 
            this.delApt.Location = new System.Drawing.Point(18, 361);
            this.delApt.Name = "delApt";
            this.delApt.Size = new System.Drawing.Size(139, 37);
            this.delApt.TabIndex = 11;
            this.delApt.Text = "Delete Appoinment";
            this.delApt.UseVisualStyleBackColor = true;
            this.delApt.Click += new System.EventHandler(this.delApt_Click);
            // 
            // upDateApt
            // 
            this.upDateApt.Location = new System.Drawing.Point(179, 361);
            this.upDateApt.Name = "upDateApt";
            this.upDateApt.Size = new System.Drawing.Size(139, 37);
            this.upDateApt.TabIndex = 12;
            this.upDateApt.Text = "Update Appoinemnt";
            this.upDateApt.UseVisualStyleBackColor = true;
            this.upDateApt.Click += new System.EventHandler(this.upDateApt_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(221, 65);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(194, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 411);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.upDateApt);
            this.Controls.Add(this.delApt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchAptBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpName);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.SearchPatient);
            this.Controls.Add(this.staffName);
            this.Controls.Add(this.staffID);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label staffID;
        private System.Windows.Forms.Label staffName;
        private System.Windows.Forms.Button SearchPatient;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.TextBox gpName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchAptBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button delApt;
        private System.Windows.Forms.Button upDateApt;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}