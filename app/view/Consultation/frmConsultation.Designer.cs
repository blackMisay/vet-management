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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnNewConsultation = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvConsultation = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Size = new System.Drawing.Size(1740, 54);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultations";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnHistory);
            this.panel2.Controls.Add(this.btnNewConsultation);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1740, 70);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Search by (Pet Name)";
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.BackColor = System.Drawing.Color.White;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
            this.btnHistory.Location = new System.Drawing.Point(1497, 20);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(231, 39);
            this.btnHistory.TabIndex = 13;
            this.btnHistory.Text = "Consultation &History";
            this.btnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnNewConsultation
            // 
            this.btnNewConsultation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewConsultation.BackColor = System.Drawing.Color.White;
            this.btnNewConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewConsultation.Image = global::app.Properties.Resources.diagnosis_24px;
            this.btnNewConsultation.Location = new System.Drawing.Point(1293, 20);
            this.btnNewConsultation.Margin = new System.Windows.Forms.Padding(5);
            this.btnNewConsultation.Name = "btnNewConsultation";
            this.btnNewConsultation.Size = new System.Drawing.Size(196, 40);
            this.btnNewConsultation.TabIndex = 12;
            this.btnNewConsultation.Text = "&New Consultation";
            this.btnNewConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewConsultation.UseVisualStyleBackColor = false;
            this.btnNewConsultation.Click += new System.EventHandler(this.btnNewConsultation_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(14, 32);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(295, 28);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::app.Properties.Resources.icons8_google_web_search_16;
            this.btnSearch.Location = new System.Drawing.Point(319, 31);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 31);
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
            this.Owner,
            this.Patient,
            this.Column4,
            this.Column5,
            this.Column1,
            this.date});
            this.dgvConsultation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConsultation.Location = new System.Drawing.Point(0, 124);
            this.dgvConsultation.Margin = new System.Windows.Forms.Padding(5);
            this.dgvConsultation.Name = "dgvConsultation";
            this.dgvConsultation.RowHeadersVisible = false;
            this.dgvConsultation.RowHeadersWidth = 51;
            this.dgvConsultation.RowTemplate.Height = 24;
            this.dgvConsultation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultation.Size = new System.Drawing.Size(1740, 555);
            this.dgvConsultation.TabIndex = 6;
            this.dgvConsultation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultation_CellClick);
            this.dgvConsultation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultation_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "consultation_id";
            dataGridViewCellStyle3.NullValue = null;
            this.Id.DefaultCellStyle = dataGridViewCellStyle3;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Owner
            // 
            this.Owner.DataPropertyName = "client_fullname";
            this.Owner.HeaderText = "Owner";
            this.Owner.MinimumWidth = 200;
            this.Owner.Name = "Owner";
            this.Owner.ReadOnly = true;
            // 
            // Patient
            // 
            this.Patient.DataPropertyName = "petname";
            this.Patient.HeaderText = "Patient Name";
            this.Patient.MinimumWidth = 6;
            this.Patient.Name = "Patient";
            this.Patient.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "complaint";
            this.Column4.HeaderText = "Complaint";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "findings";
            this.Column5.HeaderText = "Findings";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "plantreatment";
            this.Column1.HeaderText = "Treatment";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // date
            // 
            this.date.DataPropertyName = "consult_date";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.date.DefaultCellStyle = dataGridViewCellStyle4;
            this.date.HeaderText = "Consult Date";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // frmConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1740, 679);
            this.Controls.Add(this.dgvConsultation);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConsultation";
            this.Text = " SAHAGUN Veterinary Clinic v2.0";
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
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgvConsultation;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Label label2;
    }
}