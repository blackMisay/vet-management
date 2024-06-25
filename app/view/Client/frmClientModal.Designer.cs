namespace app.view.Client
{
    partial class frmClientModal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpBday = new System.Windows.Forms.DateTimePicker();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboBrgy = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboRegion = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.richHousenum = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Information";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::app.Properties.Resources.icons8_cancel_16__1_;
            this.btnCancel.Location = new System.Drawing.Point(961, 714);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::app.Properties.Resources.icons8_create_16;
            this.btnSave.Location = new System.Drawing.Point(1077, 714);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Create";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "First name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.cboSex);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpBday);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtSuffix);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(32, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1165, 322);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Information";
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cboSex.Location = new System.Drawing.Point(201, 283);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(356, 31);
            this.cboSex.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(50, 281);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 23);
            this.label16.TabIndex = 21;
            this.label16.Text = "Sex";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(782, 137);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(336, 32);
            this.txtEmail.TabIndex = 10;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "",
            "Single",
            "Married",
            "Widowed",
            "Separated",
            ""});
            this.cboStatus.Location = new System.Drawing.Point(201, 246);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(356, 31);
            this.cboStatus.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(604, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 23);
            this.label8.TabIndex = 19;
            this.label8.Text = "Email address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "Civil status";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(782, 101);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(336, 32);
            this.txtPhone.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "Birth date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(604, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Phone number";
            // 
            // dtpBday
            // 
            this.dtpBday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBday.Location = new System.Drawing.Point(201, 210);
            this.dtpBday.Name = "dtpBday";
            this.dtpBday.Size = new System.Drawing.Size(356, 32);
            this.dtpBday.TabIndex = 5;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(782, 65);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(336, 32);
            this.txtMobile.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(604, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 23);
            this.label10.TabIndex = 15;
            this.label10.Text = "Mobile number";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(201, 173);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(356, 32);
            this.txtSuffix.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Suffix";
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(201, 137);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(356, 32);
            this.txtLname.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Last name";
            // 
            // txtMname
            // 
            this.txtMname.Location = new System.Drawing.Point(201, 101);
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(356, 32);
            this.txtMname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Middle name";
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(201, 65);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(356, 32);
            this.txtFname.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.cboBrgy);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cboCity);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cboProvince);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cboRegion);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.richHousenum);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(32, 462);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1165, 226);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // cboBrgy
            // 
            this.cboBrgy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrgy.FormattingEnabled = true;
            this.cboBrgy.Location = new System.Drawing.Point(759, 151);
            this.cboBrgy.Name = "cboBrgy";
            this.cboBrgy.Size = new System.Drawing.Size(356, 31);
            this.cboBrgy.TabIndex = 15;
            this.cboBrgy.Click += new System.EventHandler(this.cboBrgy_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(604, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 23);
            this.label15.TabIndex = 21;
            this.label15.Text = "Barangay";
            // 
            // cboCity
            // 
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(759, 114);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(356, 31);
            this.cboCity.TabIndex = 14;
            this.cboCity.SelectedIndexChanged += new System.EventHandler(this.cboBrgy_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(604, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 23);
            this.label14.TabIndex = 25;
            this.label14.Text = "City";
            // 
            // cboProvince
            // 
            this.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(759, 77);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(356, 31);
            this.cboProvince.TabIndex = 13;
            this.cboProvince.SelectedIndexChanged += new System.EventHandler(this.cboProvince_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(604, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 23);
            this.label13.TabIndex = 23;
            this.label13.Text = "Province";
            // 
            // cboRegion
            // 
            this.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegion.FormattingEnabled = true;
            this.cboRegion.Location = new System.Drawing.Point(759, 41);
            this.cboRegion.Name = "cboRegion";
            this.cboRegion.Size = new System.Drawing.Size(356, 31);
            this.cboRegion.TabIndex = 12;
            this.cboRegion.SelectedIndexChanged += new System.EventHandler(this.cboRegion_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(604, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 23);
            this.label12.TabIndex = 21;
            this.label12.Text = "Region";
            // 
            // richHousenum
            // 
            this.richHousenum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richHousenum.Location = new System.Drawing.Point(224, 41);
            this.richHousenum.Name = "richHousenum";
            this.richHousenum.Size = new System.Drawing.Size(336, 137);
            this.richHousenum.TabIndex = 11;
            this.richHousenum.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "House number";
            // 
            // frmClientModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 778);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmClientModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmClientModal";
            this.Load += new System.EventHandler(this.frmClientModal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox richHousenum;
        public System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox cboProvince;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox cboRegion;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cboBrgy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboSex;
    }
}