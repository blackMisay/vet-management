namespace app.view.Immunization
{
    partial class frmImmunization
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImmunization));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVaccination = new System.Windows.Forms.Button();
            this.btnImmunization = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvImmunization = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImmunization)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1467, 56);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vaccination";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnVaccination);
            this.panel2.Controls.Add(this.btnImmunization);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1467, 68);
            this.panel2.TabIndex = 6;
            // 
            // btnVaccination
            // 
            this.btnVaccination.Image = global::app.Properties.Resources.immunity_24px;
            this.btnVaccination.Location = new System.Drawing.Point(13, 11);
            this.btnVaccination.Margin = new System.Windows.Forms.Padding(4);
            this.btnVaccination.Name = "btnVaccination";
            this.btnVaccination.Size = new System.Drawing.Size(249, 47);
            this.btnVaccination.TabIndex = 13;
            this.btnVaccination.Text = "New Vaccination";
            this.btnVaccination.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVaccination.UseVisualStyleBackColor = true;
            this.btnVaccination.Click += new System.EventHandler(this.btnVaccination_Click);
            // 
            // btnImmunization
            // 
            this.btnImmunization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImmunization.BackColor = System.Drawing.Color.White;
            this.btnImmunization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImmunization.Image = global::app.Properties.Resources.diagnosis_24px;
            this.btnImmunization.Location = new System.Drawing.Point(1721, 16);
            this.btnImmunization.Margin = new System.Windows.Forms.Padding(5);
            this.btnImmunization.Name = "btnImmunization";
            this.btnImmunization.Size = new System.Drawing.Size(254, 46);
            this.btnImmunization.TabIndex = 12;
            this.btnImmunization.Text = "&New Vaccination";
            this.btnImmunization.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImmunization.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(1072, 25);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 28);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::app.Properties.Resources.icons8_google_web_search_16;
            this.btnSearch.Location = new System.Drawing.Point(1335, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 38);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvImmunization
            // 
            this.dgvImmunization.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvImmunization.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvImmunization.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImmunization.BackgroundColor = System.Drawing.Color.White;
            this.dgvImmunization.ColumnHeadersHeight = 29;
            this.dgvImmunization.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.name,
            this.Column3,
            this.Column2,
            this.Column1,
            this.Column5,
            this.Column10,
            this.Column6,
            this.Column11,
            this.Column12,
            this.Column4});
            this.dgvImmunization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImmunization.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvImmunization.Location = new System.Drawing.Point(0, 124);
            this.dgvImmunization.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvImmunization.Name = "dgvImmunization";
            this.dgvImmunization.RowHeadersVisible = false;
            this.dgvImmunization.RowHeadersWidth = 51;
            this.dgvImmunization.RowTemplate.Height = 24;
            this.dgvImmunization.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImmunization.Size = new System.Drawing.Size(1467, 650);
            this.dgvImmunization.TabIndex = 7;
            this.dgvImmunization.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImmunication_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "record_id";
            this.Id.HeaderText = "ImmunizationId";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "patient_name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.name.DefaultCellStyle = dataGridViewCellStyle2;
            this.name.HeaderText = "Patient";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "lot_number";
            this.Column3.HeaderText = "Lot Number";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "vaccine_code";
            this.Column2.HeaderText = "Vaccine Code";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "vaccine_name";
            this.Column1.HeaderText = "Vaccine";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "typical_dose";
            this.Column5.HeaderText = "Dose";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "recommended_dosage";
            this.Column10.HeaderText = "Dosage";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "notes";
            this.Column6.HeaderText = "Notes";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "administered_date";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column11.HeaderText = "Administered Date";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "expiration_date";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column12.HeaderText = "Expiration Date";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "veterinarian_name";
            this.Column4.HeaderText = "Veterinarian";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // frmImmunization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 774);
            this.Controls.Add(this.dgvImmunization);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmImmunization";
            this.Text = " SAHAGUN Veterinary Clinic v2.0";
            this.Load += new System.EventHandler(this.frmImmunization_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImmunization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnImmunization;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgvImmunization;
        private System.Windows.Forms.Button btnVaccination;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}