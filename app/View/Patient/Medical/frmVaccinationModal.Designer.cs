namespace app.view.Patient.Medical
{
    partial class frmVaccinationModal
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
            this.cmbVax = new System.Windows.Forms.ComboBox();
            this.txtVaxDescription = new System.Windows.Forms.TextBox();
            this.dtpVaxDate = new System.Windows.Forms.DateTimePicker();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.chkUpdateWeight = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbVaxShot = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbVax
            // 
            this.cmbVax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVax.FormattingEnabled = true;
            this.cmbVax.Location = new System.Drawing.Point(132, 180);
            this.cmbVax.Name = "cmbVax";
            this.cmbVax.Size = new System.Drawing.Size(242, 31);
            this.cmbVax.TabIndex = 0;
            // 
            // txtVaxDescription
            // 
            this.txtVaxDescription.Location = new System.Drawing.Point(132, 218);
            this.txtVaxDescription.Multiline = true;
            this.txtVaxDescription.Name = "txtVaxDescription";
            this.txtVaxDescription.Size = new System.Drawing.Size(242, 141);
            this.txtVaxDescription.TabIndex = 1;
            // 
            // dtpVaxDate
            // 
            this.dtpVaxDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVaxDate.Location = new System.Drawing.Point(132, 144);
            this.dtpVaxDate.Name = "dtpVaxDate";
            this.dtpVaxDate.Size = new System.Drawing.Size(242, 30);
            this.dtpVaxDate.TabIndex = 2;
            this.dtpVaxDate.ValueChanged += new System.EventHandler(this.dtpVaxDate_ValueChanged);
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(132, 438);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(152, 30);
            this.txtWeight.TabIndex = 3;
            // 
            // chkUpdateWeight
            // 
            this.chkUpdateWeight.AutoSize = true;
            this.chkUpdateWeight.Location = new System.Drawing.Point(132, 405);
            this.chkUpdateWeight.Name = "chkUpdateWeight";
            this.chkUpdateWeight.Size = new System.Drawing.Size(152, 27);
            this.chkUpdateWeight.TabIndex = 4;
            this.chkUpdateWeight.Text = "Update weight?";
            this.chkUpdateWeight.UseVisualStyleBackColor = true;
            this.chkUpdateWeight.CheckedChanged += new System.EventHandler(this.chkUpdateWeight_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(132, 512);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 44);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(256, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 44);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Vaccine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Weight";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 41);
            this.label5.TabIndex = 11;
            this.label5.Text = "Vaccine Form";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Shot";
            // 
            // cmbVaxShot
            // 
            this.cmbVaxShot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaxShot.FormattingEnabled = true;
            this.cmbVaxShot.Items.AddRange(new object[] {
            "Full",
            "First",
            "Second",
            "Third"});
            this.cmbVaxShot.Location = new System.Drawing.Point(132, 365);
            this.cmbVaxShot.Name = "cmbVaxShot";
            this.cmbVaxShot.Size = new System.Drawing.Size(242, 31);
            this.cmbVaxShot.TabIndex = 12;
            // 
            // frmVaccinationModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(413, 592);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbVaxShot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkUpdateWeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.dtpVaxDate);
            this.Controls.Add(this.txtVaxDescription);
            this.Controls.Add(this.cmbVax);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVaccinationModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vaccination";
            this.Load += new System.EventHandler(this.frmVaccinationModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVax;
        private System.Windows.Forms.TextBox txtVaxDescription;
        private System.Windows.Forms.DateTimePicker dtpVaxDate;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.CheckBox chkUpdateWeight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbVaxShot;
    }
}