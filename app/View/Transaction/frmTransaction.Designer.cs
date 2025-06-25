namespace app.view.Transaction
{
    partial class frmTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDate = new System.Windows.Forms.Label();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtSpecie = new System.Windows.Forms.TextBox();
            this.txtBreed = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBday = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPet = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnServiceLookUp = new System.Windows.Forms.Button();
            this.btnVoidTrans = new System.Windows.Forms.Button();
            this.btnVoidItem = new System.Windows.Forms.Button();
            this.btnItemLookUp = new System.Windows.Forms.Button();
            this.btnNewTrans = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.lblDoctorFee = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddConsult = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(144, 17);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 19);
            this.lblDate.TabIndex = 7;
            // 
            // dgvTransaction
            // 
            this.dgvTransaction.AllowUserToAddRows = false;
            this.dgvTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransaction.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colClientId,
            this.colDescription,
            this.colQuantity,
            this.colPrice});
            this.dgvTransaction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTransaction.Location = new System.Drawing.Point(12, 189);
            this.dgvTransaction.Name = "dgvTransaction";
            this.dgvTransaction.RowHeadersVisible = false;
            this.dgvTransaction.RowHeadersWidth = 51;
            this.dgvTransaction.RowTemplate.Height = 24;
            this.dgvTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransaction.Size = new System.Drawing.Size(1128, 416);
            this.dgvTransaction.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1513, 171);
            this.panel2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtColor);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtWeight);
            this.groupBox2.Controls.Add(this.txtGender);
            this.groupBox2.Controls.Add(this.txtSpecie);
            this.groupBox2.Controls.Add(this.txtBreed);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtBday);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtAge);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPet);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(559, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 158);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pet Information";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(286, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 21);
            this.label14.TabIndex = 23;
            this.label14.Text = "Color";
            // 
            // txtColor
            // 
            this.txtColor.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.Location = new System.Drawing.Point(361, 123);
            this.txtColor.Multiline = true;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(201, 28);
            this.txtColor.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(286, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 21);
            this.label13.TabIndex = 21;
            this.label13.Text = "Gender";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(286, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 21);
            this.label12.TabIndex = 19;
            this.label12.Text = "Weight";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(361, 89);
            this.txtWeight.Multiline = true;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(201, 28);
            this.txtWeight.TabIndex = 18;
            // 
            // txtGender
            // 
            this.txtGender.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.Location = new System.Drawing.Point(361, 58);
            this.txtGender.Multiline = true;
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(201, 28);
            this.txtGender.TabIndex = 20;
            // 
            // txtSpecie
            // 
            this.txtSpecie.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecie.Location = new System.Drawing.Point(106, 126);
            this.txtSpecie.Multiline = true;
            this.txtSpecie.Name = "txtSpecie";
            this.txtSpecie.Size = new System.Drawing.Size(174, 28);
            this.txtSpecie.TabIndex = 12;
            // 
            // txtBreed
            // 
            this.txtBreed.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBreed.Location = new System.Drawing.Point(106, 94);
            this.txtBreed.Multiline = true;
            this.txtBreed.Name = "txtBreed";
            this.txtBreed.Size = new System.Drawing.Size(174, 28);
            this.txtBreed.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(286, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 21);
            this.label11.TabIndex = 17;
            this.label11.Text = "Birthday";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "Specie";
            // 
            // txtBday
            // 
            this.txtBday.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBday.Location = new System.Drawing.Point(361, 25);
            this.txtBday.Multiline = true;
            this.txtBday.Name = "txtBday";
            this.txtBday.Size = new System.Drawing.Size(201, 28);
            this.txtBday.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 21);
            this.label8.TabIndex = 11;
            this.label8.Text = "Breed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 21);
            this.label10.TabIndex = 15;
            this.label10.Text = "Age";
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(106, 60);
            this.txtAge.Multiline = true;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(174, 28);
            this.txtAge.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pet Name";
            // 
            // txtPet
            // 
            this.txtPet.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPet.Location = new System.Drawing.Point(106, 27);
            this.txtPet.Multiline = true;
            this.txtPet.Name = "txtPet";
            this.txtPet.Size = new System.Drawing.Size(174, 28);
            this.txtPet.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContact);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtOwner);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 158);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Owner Information";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(133, 61);
            this.txtContact.Multiline = true;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(392, 28);
            this.txtContact.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Contact";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(133, 95);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(392, 57);
            this.txtAddress.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Address";
            // 
            // txtOwner
            // 
            this.txtOwner.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwner.Location = new System.Drawing.Point(133, 27);
            this.txtOwner.Multiline = true;
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(392, 28);
            this.txtOwner.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Owner Name";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblInvoice);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Location = new System.Drawing.Point(1134, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 158);
            this.panel1.TabIndex = 15;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblInvoice.Location = new System.Drawing.Point(0, 92);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(305, 39);
            this.lblInvoice.TabIndex = 11;
            this.lblInvoice.Text = "0000000000000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Invoice No. :";
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.Image = global::app.Properties.Resources.coins;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayment.Location = new System.Drawing.Point(18, 280);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(344, 57);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "&Payment";
            this.btnPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::app.Properties.Resources.close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(1391, 618);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 46);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnServiceLookUp
            // 
            this.btnServiceLookUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnServiceLookUp.Image = global::app.Properties.Resources.services_24px;
            this.btnServiceLookUp.Location = new System.Drawing.Point(497, 611);
            this.btnServiceLookUp.Name = "btnServiceLookUp";
            this.btnServiceLookUp.Size = new System.Drawing.Size(253, 57);
            this.btnServiceLookUp.TabIndex = 14;
            this.btnServiceLookUp.Text = "&Select Services Rendered";
            this.btnServiceLookUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServiceLookUp.UseVisualStyleBackColor = true;
            this.btnServiceLookUp.Click += new System.EventHandler(this.btnServiceLookUp_Click);
            // 
            // btnVoidTrans
            // 
            this.btnVoidTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoidTrans.Image = global::app.Properties.Resources.deleted;
            this.btnVoidTrans.Location = new System.Drawing.Point(172, 343);
            this.btnVoidTrans.Name = "btnVoidTrans";
            this.btnVoidTrans.Size = new System.Drawing.Size(190, 57);
            this.btnVoidTrans.TabIndex = 13;
            this.btnVoidTrans.Text = "&Void Transaction";
            this.btnVoidTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoidTrans.UseVisualStyleBackColor = true;
            this.btnVoidTrans.Click += new System.EventHandler(this.btnVoidTrans_Click);
            // 
            // btnVoidItem
            // 
            this.btnVoidItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoidItem.Image = global::app.Properties.Resources.deleted;
            this.btnVoidItem.Location = new System.Drawing.Point(18, 343);
            this.btnVoidItem.Name = "btnVoidItem";
            this.btnVoidItem.Size = new System.Drawing.Size(141, 57);
            this.btnVoidItem.TabIndex = 12;
            this.btnVoidItem.Text = "&Void Item";
            this.btnVoidItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoidItem.UseVisualStyleBackColor = true;
            this.btnVoidItem.Click += new System.EventHandler(this.btnVoidItem_Click);
            // 
            // btnItemLookUp
            // 
            this.btnItemLookUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnItemLookUp.Image = global::app.Properties.Resources.procurement;
            this.btnItemLookUp.Location = new System.Drawing.Point(238, 611);
            this.btnItemLookUp.Name = "btnItemLookUp";
            this.btnItemLookUp.Size = new System.Drawing.Size(253, 57);
            this.btnItemLookUp.TabIndex = 11;
            this.btnItemLookUp.Text = "&Select Item Purchased";
            this.btnItemLookUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnItemLookUp.UseVisualStyleBackColor = true;
            this.btnItemLookUp.Click += new System.EventHandler(this.btnItemLookUp_Click);
            // 
            // btnNewTrans
            // 
            this.btnNewTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewTrans.Image = global::app.Properties.Resources.icons8_save_button_35;
            this.btnNewTrans.Location = new System.Drawing.Point(26, 611);
            this.btnNewTrans.Name = "btnNewTrans";
            this.btnNewTrans.Size = new System.Drawing.Size(206, 57);
            this.btnNewTrans.TabIndex = 10;
            this.btnNewTrans.Text = "&New Transaction";
            this.btnNewTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewTrans.UseVisualStyleBackColor = true;
            this.btnNewTrans.Click += new System.EventHandler(this.btnNewTrans_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.lblDoctorFee);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lblSubtotal);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblTotalAmount);
            this.panel3.Controls.Add(this.btnVoidItem);
            this.panel3.Controls.Add(this.btnVoidTrans);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btnPayment);
            this.panel3.Location = new System.Drawing.Point(1147, 189);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 416);
            this.panel3.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(140, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 44);
            this.label19.TabIndex = 66;
            this.label19.Text = "₱";
            // 
            // lblDoctorFee
            // 
            this.lblDoctorFee.AutoSize = true;
            this.lblDoctorFee.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorFee.ForeColor = System.Drawing.Color.Black;
            this.lblDoctorFee.Location = new System.Drawing.Point(194, 58);
            this.lblDoctorFee.Name = "lblDoctorFee";
            this.lblDoctorFee.Size = new System.Drawing.Size(92, 44);
            this.lblDoctorFee.TabIndex = 65;
            this.lblDoctorFee.Text = "0.00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(140, 139);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 44);
            this.label17.TabIndex = 64;
            this.label17.Text = "₱";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubtotal.Location = new System.Drawing.Point(194, 139);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(92, 44);
            this.lblSubtotal.TabIndex = 63;
            this.lblSubtotal.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 112);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(122, 27);
            this.label16.TabIndex = 62;
            this.label16.Text = "Sub-Total:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(206, 27);
            this.label15.TabIndex = 61;
            this.label15.Text = "Consultation Fee:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(139, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 49);
            this.label6.TabIndex = 60;
            this.label6.Text = "₱";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(193, 228);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(106, 49);
            this.lblTotalAmount.TabIndex = 16;
            this.lblTotalAmount.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 27);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total Amount:";
            // 
            // btnAddConsult
            // 
            this.btnAddConsult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddConsult.Image = global::app.Properties.Resources.prescription_24px;
            this.btnAddConsult.Location = new System.Drawing.Point(756, 611);
            this.btnAddConsult.Name = "btnAddConsult";
            this.btnAddConsult.Size = new System.Drawing.Size(253, 57);
            this.btnAddConsult.TabIndex = 16;
            this.btnAddConsult.Text = "&Select Consultation";
            this.btnAddConsult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddConsult.UseVisualStyleBackColor = true;
            this.btnAddConsult.Click += new System.EventHandler(this.btnAddConsult_Click);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colClientId
            // 
            this.colClientId.HeaderText = "ClientId";
            this.colClientId.MinimumWidth = 6;
            this.colClientId.Name = "colClientId";
            this.colClientId.Visible = false;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.MinimumWidth = 6;
            this.colDescription.Name = "colDescription";
            // 
            // colQuantity
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            // 
            // colPrice
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1537, 680);
            this.Controls.Add(this.btnAddConsult);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnServiceLookUp);
            this.Controls.Add(this.btnItemLookUp);
            this.Controls.Add(this.btnNewTrans);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvTransaction);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTransaction";
            this.Text = "SAHAGUN Veterinary Cinic v2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dgvTransaction;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnServiceLookUp;
        public System.Windows.Forms.Button btnVoidTrans;
        public System.Windows.Forms.Button btnVoidItem;
        public System.Windows.Forms.Button btnItemLookUp;
        private System.Windows.Forms.Button btnNewTrans;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPet;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtBreed;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtSpecie;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtBday;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtAge;
        public System.Windows.Forms.Button btnAddConsult;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label lblDoctorFee;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    }
}