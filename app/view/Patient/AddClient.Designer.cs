namespace app.View.Patient
{
    partial class AddClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClient));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.cboBrgy = new System.Windows.Forms.ComboBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.cboRegion = new System.Windows.Forms.ComboBox();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.txtstreet = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtcellnum = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txttellnum = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.dtpdob = new System.Windows.Forms.DateTimePicker();
            this.txtmi = new System.Windows.Forms.TextBox();
            this.txtfname = new System.Windows.Forms.TextBox();
            this.txtlname = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.cmbCivilStat = new System.Windows.Forms.ComboBox();
            this.cmbSuffix = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(20, 20);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 28);
            this.btnCancel.TabIndex = 63;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(763, 20);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(78, 28);
            this.btnAdd.TabIndex = 64;
            this.btnAdd.Text = "Save";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 543);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 66);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Add New Pet Owner";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 63);
            this.panel1.TabIndex = 5;
            // 
            // pnlAdd
            // 
            this.pnlAdd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlAdd.Controls.Add(this.cmbSuffix);
            this.pnlAdd.Controls.Add(this.cmbCivilStat);
            this.pnlAdd.Controls.Add(this.cmbSex);
            this.pnlAdd.Controls.Add(this.cboProvince);
            this.pnlAdd.Controls.Add(this.cboBrgy);
            this.pnlAdd.Controls.Add(this.Label17);
            this.pnlAdd.Controls.Add(this.cboRegion);
            this.pnlAdd.Controls.Add(this.cboCity);
            this.pnlAdd.Controls.Add(this.Label15);
            this.pnlAdd.Controls.Add(this.Label18);
            this.pnlAdd.Controls.Add(this.Label16);
            this.pnlAdd.Controls.Add(this.txtstreet);
            this.pnlAdd.Controls.Add(this.Label14);
            this.pnlAdd.Controls.Add(this.txtemail);
            this.pnlAdd.Controls.Add(this.Label13);
            this.pnlAdd.Controls.Add(this.txtcellnum);
            this.pnlAdd.Controls.Add(this.Label12);
            this.pnlAdd.Controls.Add(this.txttellnum);
            this.pnlAdd.Controls.Add(this.Label11);
            this.pnlAdd.Controls.Add(this.Label10);
            this.pnlAdd.Controls.Add(this.Label9);
            this.pnlAdd.Controls.Add(this.Label8);
            this.pnlAdd.Controls.Add(this.dtpdob);
            this.pnlAdd.Controls.Add(this.txtmi);
            this.pnlAdd.Controls.Add(this.txtfname);
            this.pnlAdd.Controls.Add(this.txtlname);
            this.pnlAdd.Controls.Add(this.Label7);
            this.pnlAdd.Controls.Add(this.Label6);
            this.pnlAdd.Controls.Add(this.Label5);
            this.pnlAdd.Controls.Add(this.Label4);
            this.pnlAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdd.Location = new System.Drawing.Point(0, 63);
            this.pnlAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(854, 480);
            this.pnlAdd.TabIndex = 7;
            this.pnlAdd.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAdd_Paint);
            // 
            // cboProvince
            // 
            this.cboProvince.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboProvince.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(441, 317);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(401, 29);
            this.cboProvince.TabIndex = 60;
            this.cboProvince.SelectedValueChanged += new System.EventHandler(this.cboProvince_SelectedValueChanged);
            // 
            // cboBrgy
            // 
            this.cboBrgy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboBrgy.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBrgy.FormattingEnabled = true;
            this.cboBrgy.Location = new System.Drawing.Point(441, 387);
            this.cboBrgy.Name = "cboBrgy";
            this.cboBrgy.Size = new System.Drawing.Size(401, 29);
            this.cboBrgy.TabIndex = 62;
            this.cboBrgy.Click += new System.EventHandler(this.cboBrgy_Click);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(445, 293);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(82, 21);
            this.Label17.TabIndex = 73;
            this.Label17.Text = "Province";
            // 
            // cboRegion
            // 
            this.cboRegion.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboRegion.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRegion.FormattingEnabled = true;
            this.cboRegion.Location = new System.Drawing.Point(23, 317);
            this.cboRegion.Name = "cboRegion";
            this.cboRegion.Size = new System.Drawing.Size(399, 29);
            this.cboRegion.TabIndex = 59;
            this.cboRegion.SelectionChangeCommitted += new System.EventHandler(this.cboRegion_SelectionChangeCommitted);
            // 
            // cboCity
            // 
            this.cboCity.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboCity.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(23, 387);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(401, 29);
            this.cboCity.TabIndex = 61;
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(25, 361);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(42, 21);
            this.Label15.TabIndex = 69;
            this.Label15.Text = "City";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.BackColor = System.Drawing.Color.Transparent;
            this.Label18.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label18.Location = new System.Drawing.Point(445, 361);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(90, 21);
            this.Label18.TabIndex = 67;
            this.Label18.Text = "Barangay";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.BackColor = System.Drawing.Color.Transparent;
            this.Label16.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(25, 293);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(66, 21);
            this.Label16.TabIndex = 66;
            this.Label16.Text = "Region";
            // 
            // txtstreet
            // 
            this.txtstreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstreet.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstreet.Location = new System.Drawing.Point(20, 253);
            this.txtstreet.Name = "txtstreet";
            this.txtstreet.Size = new System.Drawing.Size(822, 28);
            this.txtstreet.TabIndex = 58;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(25, 229);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(190, 21);
            this.Label14.TabIndex = 64;
            this.Label14.Text = "Subdivision/Street No.";
            // 
            // txtemail
            // 
            this.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtemail.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(481, 183);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(218, 28);
            this.txtemail.TabIndex = 57;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(487, 159);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(124, 21);
            this.Label13.TabIndex = 62;
            this.Label13.Text = "Email Address";
            // 
            // txtcellnum
            // 
            this.txtcellnum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcellnum.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcellnum.Location = new System.Drawing.Point(23, 183);
            this.txtcellnum.Name = "txtcellnum";
            this.txtcellnum.Size = new System.Drawing.Size(217, 28);
            this.txtcellnum.TabIndex = 55;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(25, 159);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(129, 21);
            this.Label12.TabIndex = 60;
            this.Label12.Text = "Cellphone No.";
            // 
            // txttellnum
            // 
            this.txttellnum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttellnum.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttellnum.Location = new System.Drawing.Point(251, 183);
            this.txttellnum.Name = "txttellnum";
            this.txttellnum.Size = new System.Drawing.Size(217, 28);
            this.txttellnum.TabIndex = 56;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(255, 159);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(131, 21);
            this.Label11.TabIndex = 58;
            this.Label11.Text = "Telephone No.";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(487, 93);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(100, 21);
            this.Label10.TabIndex = 56;
            this.Label10.Text = "Civil Status";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(255, 93);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(37, 21);
            this.Label9.TabIndex = 54;
            this.Label9.Text = "Sex";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(33, 93);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(114, 21);
            this.Label8.TabIndex = 53;
            this.Label8.Text = "Date of Birth";
            // 
            // dtpdob
            // 
            this.dtpdob.CalendarFont = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdob.Location = new System.Drawing.Point(22, 117);
            this.dtpdob.Name = "dtpdob";
            this.dtpdob.Size = new System.Drawing.Size(218, 28);
            this.dtpdob.TabIndex = 52;
            this.dtpdob.Value = new System.DateTime(2024, 4, 4, 0, 0, 0, 0);
            // 
            // txtmi
            // 
            this.txtmi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmi.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmi.Location = new System.Drawing.Point(481, 54);
            this.txtmi.Name = "txtmi";
            this.txtmi.Size = new System.Drawing.Size(218, 28);
            this.txtmi.TabIndex = 50;
            // 
            // txtfname
            // 
            this.txtfname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfname.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfname.Location = new System.Drawing.Point(250, 54);
            this.txtfname.Name = "txtfname";
            this.txtfname.Size = new System.Drawing.Size(218, 28);
            this.txtfname.TabIndex = 49;
            // 
            // txtlname
            // 
            this.txtlname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlname.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlname.Location = new System.Drawing.Point(22, 54);
            this.txtlname.Name = "txtlname";
            this.txtlname.Size = new System.Drawing.Size(218, 28);
            this.txtlname.TabIndex = 48;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(712, 30);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(39, 21);
            this.Label7.TabIndex = 47;
            this.Label7.Text = "Ext.";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(487, 30);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(124, 21);
            this.Label6.TabIndex = 46;
            this.Label6.Text = "Middle Name";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(255, 31);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(96, 21);
            this.Label5.TabIndex = 45;
            this.Label5.Text = "First Name";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(24, 31);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(100, 21);
            this.Label4.TabIndex = 44;
            this.Label4.Text = "Last Name";
            // 
            // cmbSex
            // 
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cmbSex.Location = new System.Drawing.Point(250, 116);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(218, 29);
            this.cmbSex.TabIndex = 53;
            this.cmbSex.Text = "Select Gender";
            // 
            // cmbCivilStat
            // 
            this.cmbCivilStat.FormattingEnabled = true;
            this.cmbCivilStat.Items.AddRange(new object[] {
            "Single",
            "Married",
            "Widowed",
            "Separated"});
            this.cmbCivilStat.Location = new System.Drawing.Point(481, 116);
            this.cmbCivilStat.Name = "cmbCivilStat";
            this.cmbCivilStat.Size = new System.Drawing.Size(218, 29);
            this.cmbCivilStat.TabIndex = 54;
            this.cmbCivilStat.Text = "Select Civil Status";
            // 
            // cmbSuffix
            // 
            this.cmbSuffix.FormattingEnabled = true;
            this.cmbSuffix.Items.AddRange(new object[] {
            "Jr.",
            "Sr.",
            "I",
            "II",
            "III",
            "IV"});
            this.cmbSuffix.Location = new System.Drawing.Point(705, 53);
            this.cmbSuffix.Name = "cmbSuffix";
            this.cmbSuffix.Size = new System.Drawing.Size(137, 29);
            this.cmbSuffix.TabIndex = 51;
            // 
            // AddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 609);
            this.ControlBox = false;
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Patient";
            this.Load += new System.EventHandler(this.Patient_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAdd;
        internal System.Windows.Forms.ComboBox cboProvince;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.ComboBox cboBrgy;
        internal System.Windows.Forms.ComboBox cboRegion;
        internal System.Windows.Forms.ComboBox cboCity;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox txtstreet;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtemail;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtcellnum;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txttellnum;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.DateTimePicker dtpdob;
        internal System.Windows.Forms.TextBox txtmi;
        internal System.Windows.Forms.TextBox txtfname;
        internal System.Windows.Forms.TextBox txtlname;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.ComboBox cmbSuffix;
        private System.Windows.Forms.ComboBox cmbCivilStat;
        private System.Windows.Forms.ComboBox cmbSex;
    }
}