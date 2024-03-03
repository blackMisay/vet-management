namespace app.View.Patient
{
    partial class AddPet
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboSpecies = new System.Windows.Forms.ComboBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.cboBreed = new System.Windows.Forms.ComboBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.dtpdob = new System.Windows.Forms.DateTimePicker();
            this.txtlname = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 440);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 66);
            this.panel2.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(716, 12);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 41);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 14);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(119, 41);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 63);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Add New Pet Details";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel3.Controls.Add(this.btnImage);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(352, 377);
            this.panel3.TabIndex = 12;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(49, 313);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(246, 34);
            this.btnImage.TabIndex = 1;
            this.btnImage.Text = "Add Picture";
            this.btnImage.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(49, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 246);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cboSpecies
            // 
            this.cboSpecies.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboSpecies.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSpecies.FormattingEnabled = true;
            this.cboSpecies.Location = new System.Drawing.Point(271, 259);
            this.cboSpecies.Name = "cboSpecies";
            this.cboSpecies.Size = new System.Drawing.Size(226, 29);
            this.cboSpecies.TabIndex = 72;
            // 
            // cboColor
            // 
            this.cboColor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboColor.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(36, 259);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(226, 29);
            this.cboColor.TabIndex = 70;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(42, 235);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(54, 21);
            this.Label15.TabIndex = 69;
            this.Label15.Text = "Color";
            // 
            // pnlAdd
            // 
            this.pnlAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlAdd.Controls.Add(this.cboBreed);
            this.pnlAdd.Controls.Add(this.cboSpecies);
            this.pnlAdd.Controls.Add(this.Label17);
            this.pnlAdd.Controls.Add(this.cboGender);
            this.pnlAdd.Controls.Add(this.cboColor);
            this.pnlAdd.Controls.Add(this.Label15);
            this.pnlAdd.Controls.Add(this.Label18);
            this.pnlAdd.Controls.Add(this.Label16);
            this.pnlAdd.Controls.Add(this.Label8);
            this.pnlAdd.Controls.Add(this.dtpdob);
            this.pnlAdd.Controls.Add(this.txtlname);
            this.pnlAdd.Controls.Add(this.Label4);
            this.pnlAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdd.Location = new System.Drawing.Point(352, 63);
            this.pnlAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(514, 377);
            this.pnlAdd.TabIndex = 13;
            // 
            // cboBreed
            // 
            this.cboBreed.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboBreed.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBreed.FormattingEnabled = true;
            this.cboBreed.Location = new System.Drawing.Point(271, 194);
            this.cboBreed.Name = "cboBreed";
            this.cboBreed.Size = new System.Drawing.Size(226, 29);
            this.cboBreed.TabIndex = 74;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(276, 170);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(59, 21);
            this.Label17.TabIndex = 73;
            this.Label17.Text = "Breed";
            // 
            // cboGender
            // 
            this.cboGender.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboGender.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(36, 194);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(226, 29);
            this.cboGender.TabIndex = 71;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.BackColor = System.Drawing.Color.Transparent;
            this.Label18.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label18.Location = new System.Drawing.Point(276, 235);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(73, 21);
            this.Label18.TabIndex = 67;
            this.Label18.Text = "Species";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.BackColor = System.Drawing.Color.Transparent;
            this.Label16.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(42, 170);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(74, 21);
            this.Label16.TabIndex = 66;
            this.Label16.Text = "Gender";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(42, 99);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(114, 21);
            this.Label8.TabIndex = 53;
            this.Label8.Text = "Date of Birth";
            // 
            // dtpdob
            // 
            this.dtpdob.CalendarFont = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdob.Location = new System.Drawing.Point(36, 123);
            this.dtpdob.Name = "dtpdob";
            this.dtpdob.Size = new System.Drawing.Size(461, 28);
            this.dtpdob.TabIndex = 52;
            this.dtpdob.Value = new System.DateTime(2024, 4, 4, 0, 0, 0, 0);
            // 
            // txtlname
            // 
            this.txtlname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlname.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlname.Location = new System.Drawing.Point(36, 50);
            this.txtlname.Name = "txtlname";
            this.txtlname.Size = new System.Drawing.Size(461, 28);
            this.txtlname.TabIndex = 48;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(42, 26);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(94, 21);
            this.Label4.TabIndex = 44;
            this.Label4.Text = "Pet Name";
            // 
            // AddPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 506);
            this.ControlBox = false;
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddPet";
            this.Text = "AddPet";
            this.Load += new System.EventHandler(this.AddPet_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnImage;
        internal System.Windows.Forms.ComboBox cboSpecies;
        internal System.Windows.Forms.ComboBox cboColor;
        internal System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Panel pnlAdd;
        internal System.Windows.Forms.ComboBox cboBreed;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.ComboBox cboGender;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.DateTimePicker dtpdob;
        internal System.Windows.Forms.TextBox txtlname;
        internal System.Windows.Forms.Label Label4;
    }
}