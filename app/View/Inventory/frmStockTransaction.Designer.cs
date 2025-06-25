namespace app.view.Inventory
{
    partial class frmStockTransaction
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
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 65);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Transaction History";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStock.ColumnHeadersHeight = 29;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStock.Location = new System.Drawing.Point(4, 179);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.RowHeadersWidth = 51;
            this.dgvStock.RowTemplate.Height = 24;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(1131, 444);
            this.dgvStock.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFilter);
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.dtTo);
            this.panel2.Controls.Add(this.dtFrom);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbTransactionType);
            this.panel2.Location = new System.Drawing.Point(4, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 109);
            this.panel2.TabIndex = 23;
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Location = new System.Drawing.Point(8, 52);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(161, 41);
            this.cmbTransactionType.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "filtered by:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(724, 57);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(174, 36);
            this.dtpFrom.TabIndex = 2;
            this.dtpFrom.Value = new System.DateTime(2025, 6, 5, 13, 20, 27, 0);
            // 
            // dtFrom
            // 
            this.dtFrom.AutoSize = true;
            this.dtFrom.Location = new System.Drawing.Point(653, 66);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(65, 21);
            this.dtFrom.TabIndex = 3;
            this.dtFrom.Text = "FROM:";
            // 
            // dtTo
            // 
            this.dtTo.AutoSize = true;
            this.dtTo.Location = new System.Drawing.Point(904, 66);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(38, 21);
            this.dtTo.TabIndex = 4;
            this.dtTo.Text = "TO:";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(948, 57);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(174, 36);
            this.dtpTo.TabIndex = 5;
            this.dtpTo.Value = new System.DateTime(2025, 6, 5, 0, 0, 0, 0);
            // 
            // btnFilter
            // 
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Location = new System.Drawing.Point(190, 52);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(170, 41);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Search";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // frmStockTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 626);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStockTransaction";
            this.Text = "frmStockTransaction";
            this.Load += new System.EventHandler(this.frmStockTransaction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label dtTo;
        private System.Windows.Forms.Label dtFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTransactionType;
    }
}