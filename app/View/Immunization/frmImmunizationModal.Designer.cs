namespace app.view.Immunization
{
    partial class frmImmunizationModal
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbVaccine = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDosage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLotNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.dtpAdministeredDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPetName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSelectAPatient = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::app.Properties.Resources.icons8_create_16;
            this.btnSave.Location = new System.Drawing.Point(587, 470);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 50);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::app.Properties.Resources.icons8_cancel_16__1_;
            this.btnCancel.Location = new System.Drawing.Point(455, 470);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 50);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbVaccine
            // 
            this.cmbVaccine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaccine.FormattingEnabled = true;
            this.cmbVaccine.Location = new System.Drawing.Point(280, 171);
            this.cmbVaccine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVaccine.Name = "cmbVaccine";
            this.cmbVaccine.Size = new System.Drawing.Size(383, 29);
            this.cmbVaccine.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 174);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "Vaccine";
            // 
            // cmbDosage
            // 
            this.cmbDosage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDosage.FormattingEnabled = true;
            this.cmbDosage.Items.AddRange(new object[] {
            "Full dose",
            "1st dose",
            "2nd dose",
            "3rd dose"});
            this.cmbDosage.Location = new System.Drawing.Point(280, 245);
            this.cmbDosage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDosage.Name = "cmbDosage";
            this.cmbDosage.Size = new System.Drawing.Size(383, 29);
            this.cmbDosage.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 247);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "Dosage";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 78);
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Immunization";
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.Location = new System.Drawing.Point(280, 208);
            this.txtLotNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.Size = new System.Drawing.Size(383, 28);
            this.txtLotNumber.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 211);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lot Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administered date";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.dtpExpirationDate);
            this.panel2.Controls.Add(this.dtpAdministeredDate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtPetName);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnSelectAPatient);
            this.panel2.Controls.Add(this.cmbVaccine);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmbDosage);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtLotNumber);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 375);
            this.panel2.TabIndex = 25;
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpirationDate.Location = new System.Drawing.Point(280, 317);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(383, 28);
            this.dtpExpirationDate.TabIndex = 25;
            // 
            // dtpAdministeredDate
            // 
            this.dtpAdministeredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAdministeredDate.Location = new System.Drawing.Point(280, 282);
            this.dtpAdministeredDate.Name = "dtpAdministeredDate";
            this.dtpAdministeredDate.Size = new System.Drawing.Size(383, 28);
            this.dtpAdministeredDate.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 322);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "Expiration date";
            // 
            // txtPetName
            // 
            this.txtPetName.Enabled = false;
            this.txtPetName.Location = new System.Drawing.Point(280, 134);
            this.txtPetName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPetName.Name = "txtPetName";
            this.txtPetName.Size = new System.Drawing.Size(383, 28);
            this.txtPetName.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(96, 134);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "Pet name";
            // 
            // btnSelectAPatient
            // 
            this.btnSelectAPatient.Location = new System.Drawing.Point(40, 46);
            this.btnSelectAPatient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectAPatient.Name = "btnSelectAPatient";
            this.btnSelectAPatient.Size = new System.Drawing.Size(208, 46);
            this.btnSelectAPatient.TabIndex = 20;
            this.btnSelectAPatient.Text = "Select a Patient";
            this.btnSelectAPatient.UseVisualStyleBackColor = true;
            this.btnSelectAPatient.Click += new System.EventHandler(this.btnSelectAPatient_Click);
            // 
            // frmImmunizationModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 534);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmImmunizationModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImmunizationModal";
            this.Load += new System.EventHandler(this.frmImmunizationModal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbVaccine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDosage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLotNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelectAPatient;
        private System.Windows.Forms.TextBox txtPetName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.DateTimePicker dtpAdministeredDate;
    }
}