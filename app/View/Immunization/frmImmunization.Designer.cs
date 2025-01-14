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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImmunization = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvImmunization = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1465, 65);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vaccination";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnImmunization);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1465, 60);
            this.panel2.TabIndex = 6;
            // 
            // btnImmunization
            // 
            this.btnImmunization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImmunization.BackColor = System.Drawing.Color.White;
            this.btnImmunization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImmunization.Image = global::app.Properties.Resources.diagnosis_24px;
            this.btnImmunization.Location = new System.Drawing.Point(1251, 16);
            this.btnImmunization.Name = "btnImmunization";
            this.btnImmunization.Size = new System.Drawing.Size(202, 31);
            this.btnImmunization.TabIndex = 12;
            this.btnImmunization.Text = "&New Vaccination";
            this.btnImmunization.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImmunization.UseVisualStyleBackColor = false;
            this.btnImmunization.Click += new System.EventHandler(this.btnImmunization_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(110, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(332, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::app.Properties.Resources.icons8_google_web_search_16;
            this.btnSearch.Location = new System.Drawing.Point(9, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 31);
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
            this.dgvImmunization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImmunization.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column4});
            this.dgvImmunization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImmunization.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvImmunization.Location = new System.Drawing.Point(0, 125);
            this.dgvImmunization.Name = "dgvImmunization";
            this.dgvImmunization.RowHeadersVisible = false;
            this.dgvImmunization.RowHeadersWidth = 51;
            this.dgvImmunization.RowTemplate.Height = 24;
            this.dgvImmunization.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImmunization.Size = new System.Drawing.Size(1465, 647);
            this.dgvImmunization.TabIndex = 7;
            this.dgvImmunization.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImmunication_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "patient_vaccine_id";
            this.Id.HeaderText = "ImmunizationId";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Patient";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "vaccine";
            this.Column1.HeaderText = "Vaccine";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "lot_number";
            this.Column3.HeaderText = "Lot Number";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "dosage";
            this.Column10.HeaderText = "Dosage";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
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
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "expiration_date";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column12.HeaderText = "Expiration Date";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "veterinarian_id";
            this.Column4.HeaderText = "Veterinarian";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // frmImmunization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 772);
            this.Controls.Add(this.dgvImmunization);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmImmunization";
            this.Text = "frmImmunization";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}