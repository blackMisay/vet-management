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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.btnQuantity = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPet = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnServiceLookUp = new System.Windows.Forms.Button();
            this.btnVoidTrans = new System.Windows.Forms.Button();
            this.btnVoidItem = new System.Windows.Forms.Button();
            this.btnItemLookUp = new System.Windows.Forms.Button();
            this.btnNewTrans = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.lblBalance);
            this.panel4.Controls.Add(this.lblDeposit);
            this.panel4.Controls.Add(this.btnQuantity);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lblSubtotal);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(1147, 189);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(378, 416);
            this.panel4.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(140, 266);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(97, 47);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 22);
            this.label6.TabIndex = 25;
            this.label6.Text = "TOTAL AMOUNT:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "BALANCE:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(223, 189);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(57, 27);
            this.lblBalance.TabIndex = 23;
            this.lblBalance.Text = "0.00";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.Location = new System.Drawing.Point(223, 114);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(57, 27);
            this.lblDeposit.TabIndex = 22;
            this.lblDeposit.Text = "0.00";
            // 
            // btnQuantity
            // 
            this.btnQuantity.Image = global::app.Properties.Resources.plus_minus;
            this.btnQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuantity.Location = new System.Drawing.Point(7, 350);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.Size = new System.Drawing.Size(355, 42);
            this.btnQuantity.TabIndex = 9;
            this.btnQuantity.Text = "&Deposit";
            this.btnQuantity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuantity.UseVisualStyleBackColor = true;
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 22);
            this.label7.TabIndex = 21;
            this.label7.Text = "DEPOSIT:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(223, 46);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(57, 27);
            this.lblSubtotal.TabIndex = 20;
            this.lblSubtotal.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "SUB-TOTAL:";
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
            this.dgvTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            // 
            // colPrice
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1513, 171);
            this.panel2.TabIndex = 6;
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
            this.panel1.Size = new System.Drawing.Size(363, 150);
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
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtPet);
            this.panel5.Controls.Add(this.txtName);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(14, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1113, 150);
            this.panel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Client Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pet Name";
            // 
            // txtPet
            // 
            this.txtPet.Location = new System.Drawing.Point(126, 112);
            this.txtPet.Multiline = true;
            this.txtPet.Name = "txtPet";
            this.txtPet.Size = new System.Drawing.Size(229, 28);
            this.txtPet.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(229, 28);
            this.txtName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // btnPayment
            // 
            this.btnPayment.Image = global::app.Properties.Resources.coins;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayment.Location = new System.Drawing.Point(1223, 611);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(150, 42);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "&Payment";
            this.btnPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::app.Properties.Resources.close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(1379, 611);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 42);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnServiceLookUp
            // 
            this.btnServiceLookUp.Image = global::app.Properties.Resources.services_24px;
            this.btnServiceLookUp.Location = new System.Drawing.Point(527, 611);
            this.btnServiceLookUp.Name = "btnServiceLookUp";
            this.btnServiceLookUp.Size = new System.Drawing.Size(199, 42);
            this.btnServiceLookUp.TabIndex = 14;
            this.btnServiceLookUp.Text = "&Service Look-Up";
            this.btnServiceLookUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServiceLookUp.UseVisualStyleBackColor = true;
            this.btnServiceLookUp.Click += new System.EventHandler(this.btnServiceLookUp_Click);
            // 
            // btnVoidTrans
            // 
            this.btnVoidTrans.Image = global::app.Properties.Resources.deleted;
            this.btnVoidTrans.Location = new System.Drawing.Point(937, 611);
            this.btnVoidTrans.Name = "btnVoidTrans";
            this.btnVoidTrans.Size = new System.Drawing.Size(199, 42);
            this.btnVoidTrans.TabIndex = 13;
            this.btnVoidTrans.Text = "&Void Transaction";
            this.btnVoidTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoidTrans.UseVisualStyleBackColor = true;
            // 
            // btnVoidItem
            // 
            this.btnVoidItem.Image = global::app.Properties.Resources.deleted;
            this.btnVoidItem.Location = new System.Drawing.Point(732, 611);
            this.btnVoidItem.Name = "btnVoidItem";
            this.btnVoidItem.Size = new System.Drawing.Size(199, 42);
            this.btnVoidItem.TabIndex = 12;
            this.btnVoidItem.Text = "&Void Item";
            this.btnVoidItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoidItem.UseVisualStyleBackColor = true;
            this.btnVoidItem.Click += new System.EventHandler(this.btnVoidItem_Click);
            // 
            // btnItemLookUp
            // 
            this.btnItemLookUp.Image = global::app.Properties.Resources.procurement;
            this.btnItemLookUp.Location = new System.Drawing.Point(323, 611);
            this.btnItemLookUp.Name = "btnItemLookUp";
            this.btnItemLookUp.Size = new System.Drawing.Size(198, 42);
            this.btnItemLookUp.TabIndex = 11;
            this.btnItemLookUp.Text = "&Item Look-Up";
            this.btnItemLookUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnItemLookUp.UseVisualStyleBackColor = true;
            this.btnItemLookUp.Click += new System.EventHandler(this.btnItemLookUp_Click);
            // 
            // btnNewTrans
            // 
            this.btnNewTrans.Image = global::app.Properties.Resources.icons8_save_button_35;
            this.btnNewTrans.Location = new System.Drawing.Point(118, 611);
            this.btnNewTrans.Name = "btnNewTrans";
            this.btnNewTrans.Size = new System.Drawing.Size(199, 42);
            this.btnNewTrans.TabIndex = 10;
            this.btnNewTrans.Text = "&New Transaction";
            this.btnNewTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewTrans.UseVisualStyleBackColor = true;
            this.btnNewTrans.Click += new System.EventHandler(this.btnNewTrans_Click);
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1537, 680);
            this.Controls.Add(this.btnServiceLookUp);
            this.Controls.Add(this.btnVoidTrans);
            this.Controls.Add(this.btnVoidItem);
            this.Controls.Add(this.btnItemLookUp);
            this.Controls.Add(this.btnNewTrans);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvTransaction);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTransaction";
            this.Text = "SAHAGUN Veterinary Cinic v2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.DataGridView dgvTransaction;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQuantity;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        public  System.Windows.Forms.Label lblBalance;
        public  System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label label7;
        public  System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnServiceLookUp;
        public System.Windows.Forms.Button btnVoidTrans;
        public System.Windows.Forms.Button btnVoidItem;
        public System.Windows.Forms.Button btnItemLookUp;
        private System.Windows.Forms.Button btnNewTrans;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtPet;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    }
}