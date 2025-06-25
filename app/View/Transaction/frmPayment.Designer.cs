namespace app.view.Transaction
{
    partial class frmPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblChangeAmount = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPet = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtRefNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCashTendered = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.modeOfPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Amount Tendered:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(252, 17);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(179, 32);
            this.txtTotal.TabIndex = 2;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChangeAmount
            // 
            this.lblChangeAmount.AutoSize = true;
            this.lblChangeAmount.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeAmount.Location = new System.Drawing.Point(152, 64);
            this.lblChangeAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChangeAmount.Name = "lblChangeAmount";
            this.lblChangeAmount.Size = new System.Drawing.Size(101, 23);
            this.lblChangeAmount.TabIndex = 3;
            this.lblChangeAmount.Text = "Change :";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPay.Location = new System.Drawing.Point(653, 10);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(148, 61);
            this.btnPay.TabIndex = 4;
            this.btnPay.Text = "&Proceed";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblPet);
            this.panel1.Controls.Add(this.lblClient);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.txtRefNum);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCashTendered);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboMode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 207);
            this.panel1.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "Pet Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Owner Name:";
            // 
            // lblPet
            // 
            this.lblPet.AutoSize = true;
            this.lblPet.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPet.Location = new System.Drawing.Point(185, 45);
            this.lblPet.Name = "lblPet";
            this.lblPet.Size = new System.Drawing.Size(0, 23);
            this.lblPet.TabIndex = 16;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(185, 10);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(0, 23);
            this.lblClient.TabIndex = 15;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Century Gothic", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(255, 72);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(106, 49);
            this.lblTotalAmount.TabIndex = 13;
            this.lblTotalAmount.Text = "0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(194, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 49);
            this.label8.TabIndex = 14;
            this.label8.Text = "₱ ";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(805, 135);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(142, 60);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "Add Payment";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtRefNum
            // 
            this.txtRefNum.Font = new System.Drawing.Font("Century Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNum.Location = new System.Drawing.Point(463, 164);
            this.txtRefNum.Name = "txtRefNum";
            this.txtRefNum.Size = new System.Drawing.Size(282, 34);
            this.txtRefNum.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(472, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Reference Number:";
            // 
            // txtCashTendered
            // 
            this.txtCashTendered.Font = new System.Drawing.Font("Century Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashTendered.Location = new System.Drawing.Point(227, 164);
            this.txtCashTendered.Name = "txtCashTendered";
            this.txtCashTendered.Size = new System.Drawing.Size(196, 34);
            this.txtCashTendered.TabIndex = 8;
            this.txtCashTendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashTendered.TextChanged += new System.EventHandler(this.txtCashTendered_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(231, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Amount Tendered:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mode of Payment:";
            // 
            // cboMode
            // 
            this.cboMode.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "Cash",
            "GCash",
            "Paymaya"});
            this.cboMode.Location = new System.Drawing.Point(15, 166);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(187, 31);
            this.cboMode.TabIndex = 4;
            this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 64);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "Payment";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::app.Properties.Resources.close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(818, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 61);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel3.Controls.Add(this.btnPay);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 649);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(962, 83);
            this.panel3.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtChange);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtTotal);
            this.panel4.Controls.Add(this.lblChangeAmount);
            this.panel4.Location = new System.Drawing.Point(518, 543);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(442, 100);
            this.panel4.TabIndex = 11;
            // 
            // txtChange
            // 
            this.txtChange.Enabled = false;
            this.txtChange.Font = new System.Drawing.Font("Century Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChange.Location = new System.Drawing.Point(252, 59);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(179, 34);
            this.txtChange.TabIndex = 37;
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChange.TextChanged += new System.EventHandler(this.txtChange_TextChanged);
            // 
            // dgvPayment
            // 
            this.dgvPayment.AllowUserToAddRows = false;
            this.dgvPayment.AllowUserToDeleteRows = false;
            this.dgvPayment.AllowUserToResizeColumns = false;
            this.dgvPayment.AllowUserToResizeRows = false;
            this.dgvPayment.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modeOfPayment,
            this.Reference,
            this.Amount,
            this.Cancel});
            this.dgvPayment.Location = new System.Drawing.Point(0, 279);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.RowHeadersWidth = 51;
            this.dgvPayment.RowTemplate.Height = 24;
            this.dgvPayment.Size = new System.Drawing.Size(960, 258);
            this.dgvPayment.TabIndex = 12;
            this.dgvPayment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayment_CellContentClick);
            this.dgvPayment.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvPayment_RowsAdded);
            this.dgvPayment.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPayment_RowsRemoved);
            // 
            // modeOfPayment
            // 
            this.modeOfPayment.HeaderText = "Mode of Payment";
            this.modeOfPayment.MinimumWidth = 6;
            this.modeOfPayment.Name = "modeOfPayment";
            this.modeOfPayment.Width = 250;
            // 
            // Reference
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Reference.DefaultCellStyle = dataGridViewCellStyle1;
            this.Reference.HeaderText = "Reference Number";
            this.Reference.MinimumWidth = 6;
            this.Reference.Name = "Reference";
            this.Reference.Width = 250;
            // 
            // Amount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.Width = 200;
            // 
            // Cancel
            // 
            this.Cancel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cancel.HeaderText = "Void";
            this.Cancel.MinimumWidth = 6;
            this.Cancel.Name = "Cancel";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 732);
            this.Controls.Add(this.dgvPayment);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAHAGUN Veterinary Clinic v2.0";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblChangeAmount;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.TextBox txtCashTendered;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfirm;
        public System.Windows.Forms.TextBox txtRefNum;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeOfPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cancel;
        public  System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPet;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}