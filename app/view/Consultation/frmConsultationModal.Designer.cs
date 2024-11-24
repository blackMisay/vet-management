namespace app.view.Consultation
{
    partial class frmConsultationModal
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
            this.txtPetName = new System.Windows.Forms.TextBox();
            this.btnSelectAPatient = new System.Windows.Forms.Button();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.rtxMedication = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rtxPlanTreatment = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rtxtFindings = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtxtComplaintRequest = new System.Windows.Forms.RichTextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPetName
            // 
            this.txtPetName.Enabled = false;
            this.txtPetName.Location = new System.Drawing.Point(119, 111);
            this.txtPetName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPetName.Name = "txtPetName";
            this.txtPetName.Size = new System.Drawing.Size(405, 25);
            this.txtPetName.TabIndex = 21;
            // 
            // btnSelectAPatient
            // 
            this.btnSelectAPatient.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAPatient.Location = new System.Drawing.Point(119, 32);
            this.btnSelectAPatient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectAPatient.Name = "btnSelectAPatient";
            this.btnSelectAPatient.Size = new System.Drawing.Size(405, 48);
            this.btnSelectAPatient.TabIndex = 20;
            this.btnSelectAPatient.Text = "Select a Patient";
            this.btnSelectAPatient.UseVisualStyleBackColor = true;
            this.btnSelectAPatient.Click += new System.EventHandler(this.btnSelectAPatient_Click);
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(393, 180);
            this.txtTemperature.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(131, 25);
            this.txtTemperature.TabIndex = 2;
            this.txtTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(298, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Temperature";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultation";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 111);
            this.panel1.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 218);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 65);
            this.label5.TabIndex = 17;
            this.label5.Text = "Complaint or Request";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::app.Properties.Resources.icons8_create_16;
            this.btnSave.Location = new System.Drawing.Point(419, 782);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 45);
            this.btnSave.TabIndex = 27;
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
            this.btnCancel.Location = new System.Drawing.Point(279, 782);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 45);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(42, 114);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Pet name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtType);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtAge);
            this.panel2.Controls.Add(this.rtxMedication);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.rtxPlanTreatment);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.rtxtFindings);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.rtxtComplaintRequest);
            this.panel2.Controls.Add(this.txtWeight);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPetName);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnSelectAPatient);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTemperature);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 111);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 651);
            this.panel2.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(298, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Type";
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(393, 145);
            this.txtType.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(131, 25);
            this.txtType.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Age";
            // 
            // txtAge
            // 
            this.txtAge.Enabled = false;
            this.txtAge.Location = new System.Drawing.Point(119, 145);
            this.txtAge.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(131, 25);
            this.txtAge.TabIndex = 35;
            // 
            // rtxMedication
            // 
            this.rtxMedication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxMedication.Location = new System.Drawing.Point(119, 522);
            this.rtxMedication.Name = "rtxMedication";
            this.rtxMedication.Size = new System.Drawing.Size(405, 96);
            this.rtxMedication.TabIndex = 34;
            this.rtxMedication.Text = "";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(39, 524);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 69);
            this.label10.TabIndex = 33;
            this.label10.Text = "Medication\r\n(Rx)";
            // 
            // rtxPlanTreatment
            // 
            this.rtxPlanTreatment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxPlanTreatment.Location = new System.Drawing.Point(119, 420);
            this.rtxPlanTreatment.Name = "rtxPlanTreatment";
            this.rtxPlanTreatment.Size = new System.Drawing.Size(405, 96);
            this.rtxPlanTreatment.TabIndex = 32;
            this.rtxPlanTreatment.Text = "";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(42, 420);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 48);
            this.label11.TabIndex = 31;
            this.label11.Text = "Plan or Treatment";
            // 
            // rtxtFindings
            // 
            this.rtxtFindings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtFindings.Location = new System.Drawing.Point(119, 318);
            this.rtxtFindings.Name = "rtxtFindings";
            this.rtxtFindings.Size = new System.Drawing.Size(405, 96);
            this.rtxtFindings.TabIndex = 30;
            this.rtxtFindings.Text = "";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 320);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 48);
            this.label7.TabIndex = 29;
            this.label7.Text = "Findings";
            // 
            // rtxtComplaintRequest
            // 
            this.rtxtComplaintRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtComplaintRequest.Location = new System.Drawing.Point(119, 216);
            this.rtxtComplaintRequest.Name = "rtxtComplaintRequest";
            this.rtxtComplaintRequest.Size = new System.Drawing.Size(405, 96);
            this.rtxtComplaintRequest.TabIndex = 28;
            this.rtxtComplaintRequest.Text = "";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(119, 180);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(131, 25);
            this.txtWeight.TabIndex = 26;
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Weight";
            // 
            // frmConsultationModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 844);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConsultationModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultation Form";
            this.Load += new System.EventHandler(this.frmConsultationModal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtPetName;
        private System.Windows.Forms.Button btnSelectAPatient;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtxtComplaintRequest;
        private System.Windows.Forms.RichTextBox rtxtFindings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtxMedication;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtxPlanTreatment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType;
    }
}