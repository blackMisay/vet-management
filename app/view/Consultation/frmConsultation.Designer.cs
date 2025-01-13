namespace app.view.Consultation
{
    partial class frmConsultation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewConsultation = new System.Windows.Forms.Button();
            this.btnEditConsultation = new System.Windows.Forms.Button();
            this.btnRemoveConsultation = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvConsultation = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1740, 78);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultations";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNewConsultation);
            this.panel2.Controls.Add(this.btnEditConsultation);
            this.panel2.Controls.Add(this.btnRemoveConsultation);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1740, 98);
            this.panel2.TabIndex = 5;
            // 
            // btnNewConsultation
            // 
            this.btnNewConsultation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewConsultation.BackColor = System.Drawing.Color.White;
            this.btnNewConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewConsultation.Image = global::app.Properties.Resources.diagnosis_24px;
            this.btnNewConsultation.Location = new System.Drawing.Point(1297, 26);
            this.btnNewConsultation.Margin = new System.Windows.Forms.Padding(5);
            this.btnNewConsultation.Name = "btnNewConsultation";
            this.btnNewConsultation.Size = new System.Drawing.Size(196, 49);
            this.btnNewConsultation.TabIndex = 12;
            this.btnNewConsultation.Text = "&New Consultation";
            this.btnNewConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewConsultation.UseVisualStyleBackColor = false;
            this.btnNewConsultation.Click += new System.EventHandler(this.btnNewConsultation_Click);
            // 
            // btnEditConsultation
            // 
            this.btnEditConsultation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditConsultation.BackColor = System.Drawing.Color.White;
            this.btnEditConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditConsultation.Image = global::app.Properties.Resources.icons8_update_16;
            this.btnEditConsultation.Location = new System.Drawing.Point(1503, 26);
            this.btnEditConsultation.Margin = new System.Windows.Forms.Padding(5);
            this.btnEditConsultation.Name = "btnEditConsultation";
            this.btnEditConsultation.Size = new System.Drawing.Size(105, 49);
            this.btnEditConsultation.TabIndex = 11;
            this.btnEditConsultation.Text = "&Update";
            this.btnEditConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditConsultation.UseVisualStyleBackColor = false;
            this.btnEditConsultation.Click += new System.EventHandler(this.btnEditConsultation_Click);
            // 
            // btnRemoveConsultation
            // 
            this.btnRemoveConsultation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveConsultation.BackColor = System.Drawing.Color.White;
            this.btnRemoveConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveConsultation.Image = global::app.Properties.Resources.icons8_remove_16;
            this.btnRemoveConsultation.Location = new System.Drawing.Point(1618, 26);
            this.btnRemoveConsultation.Margin = new System.Windows.Forms.Padding(5);
            this.btnRemoveConsultation.Name = "btnRemoveConsultation";
            this.btnRemoveConsultation.Size = new System.Drawing.Size(108, 49);
            this.btnRemoveConsultation.TabIndex = 10;
            this.btnRemoveConsultation.Text = "&Remove";
            this.btnRemoveConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveConsultation.UseVisualStyleBackColor = false;
            this.btnRemoveConsultation.Click += new System.EventHandler(this.btnRemoveConsultation_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(129, 38);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(295, 28);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::app.Properties.Resources.icons8_google_web_search_16;
            this.btnSearch.Location = new System.Drawing.Point(24, 27);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 49);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvConsultation
            // 
            this.dgvConsultation.AllowUserToAddRows = false;
            this.dgvConsultation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsultation.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsultation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column2,
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column3});
            this.dgvConsultation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConsultation.Location = new System.Drawing.Point(0, 176);
            this.dgvConsultation.Margin = new System.Windows.Forms.Padding(5);
            this.dgvConsultation.Name = "dgvConsultation";
            this.dgvConsultation.RowHeadersVisible = false;
            this.dgvConsultation.RowHeadersWidth = 51;
            this.dgvConsultation.RowTemplate.Height = 24;
            this.dgvConsultation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultation.Size = new System.Drawing.Size(1740, 879);
            this.dgvConsultation.TabIndex = 6;
            this.dgvConsultation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultation_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            dataGridViewCellStyle5.NullValue = null;
            this.Id.DefaultCellStyle = dataGridViewCellStyle5;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "client_fullname";
            this.Column2.HeaderText = "Owner";
            this.Column2.MinimumWidth = 200;
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "petname";
            this.Column1.HeaderText = "Patient Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "complaint";
            this.Column4.HeaderText = "Complaint";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "findings";
            this.Column5.HeaderText = "Findings";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "date";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column3.HeaderText = "Consult Date";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // frmConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1740, 1055);
            this.Controls.Add(this.dgvConsultation);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConsultation";
            this.Text = "frmConsultation";
            this.Load += new System.EventHandler(this.frmConsultation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewConsultation;
        private System.Windows.Forms.Button btnEditConsultation;
        private System.Windows.Forms.Button btnRemoveConsultation;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgvConsultation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}