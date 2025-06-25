namespace app.view.Consultation
{
    partial class frmConsultationHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultationHistory));
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvPets = new System.Windows.Forms.DataGridView();
            this.total_consultations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOwners = new System.Windows.Forms.DataGridView();
            this.dgvConsultation = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pet_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pet_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.species = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultation)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel5.Controls.Add(this.label13);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1570, 63);
            this.panel5.TabIndex = 31;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(1274, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(254, 39);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate Record";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(8, 9);
            this.label13.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(333, 39);
            this.label13.TabIndex = 0;
            this.label13.Text = "Consultation History";
            // 
            // dgvPets
            // 
            this.dgvPets.AllowDrop = true;
            this.dgvPets.AllowUserToAddRows = false;
            this.dgvPets.AllowUserToDeleteRows = false;
            this.dgvPets.AllowUserToResizeColumns = false;
            this.dgvPets.AllowUserToResizeRows = false;
            this.dgvPets.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pet_id,
            this.pet_name,
            this.species,
            this.breed});
            this.dgvPets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPets.Location = new System.Drawing.Point(751, 65);
            this.dgvPets.Name = "dgvPets";
            this.dgvPets.RowHeadersVisible = false;
            this.dgvPets.RowHeadersWidth = 51;
            this.dgvPets.RowTemplate.Height = 24;
            this.dgvPets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPets.Size = new System.Drawing.Size(784, 285);
            this.dgvPets.TabIndex = 33;
            this.dgvPets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPets_CellClick);
            // 
            // total_consultations
            // 
            this.total_consultations.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total_consultations.DataPropertyName = "total_consultations";
            this.total_consultations.HeaderText = "Total Consultations";
            this.total_consultations.MinimumWidth = 6;
            this.total_consultations.Name = "total_consultations";
            // 
            // owner_name
            // 
            this.owner_name.DataPropertyName = "owner_name";
            this.owner_name.HeaderText = "Owner Name";
            this.owner_name.MinimumWidth = 6;
            this.owner_name.Name = "owner_name";
            this.owner_name.Width = 300;
            // 
            // owner_id
            // 
            this.owner_id.DataPropertyName = "owner_id";
            this.owner_id.HeaderText = "Id";
            this.owner_id.MinimumWidth = 6;
            this.owner_id.Name = "owner_id";
            this.owner_id.Visible = false;
            this.owner_id.Width = 125;
            // 
            // dgvOwners
            // 
            this.dgvOwners.AllowUserToAddRows = false;
            this.dgvOwners.AllowUserToDeleteRows = false;
            this.dgvOwners.AllowUserToResizeColumns = false;
            this.dgvOwners.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOwners.ColumnHeadersHeight = 29;
            this.dgvOwners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOwners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.owner_id,
            this.owner_name,
            this.total_consultations});
            this.dgvOwners.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOwners.Location = new System.Drawing.Point(0, 65);
            this.dgvOwners.Name = "dgvOwners";
            this.dgvOwners.RowHeadersVisible = false;
            this.dgvOwners.RowHeadersWidth = 51;
            this.dgvOwners.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOwners.RowTemplate.Height = 24;
            this.dgvOwners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOwners.Size = new System.Drawing.Size(754, 285);
            this.dgvOwners.TabIndex = 32;
            this.dgvOwners.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOwners_CellClick);
            // 
            // dgvConsultation
            // 
            this.dgvConsultation.AllowUserToAddRows = false;
            this.dgvConsultation.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvConsultation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dgvConsultation.Location = new System.Drawing.Point(0, 348);
            this.dgvConsultation.Name = "dgvConsultation";
            this.dgvConsultation.ReadOnly = true;
            this.dgvConsultation.RowHeadersVisible = false;
            this.dgvConsultation.RowHeadersWidth = 51;
            this.dgvConsultation.RowTemplate.Height = 24;
            this.dgvConsultation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultation.Size = new System.Drawing.Size(1535, 414);
            this.dgvConsultation.TabIndex = 34;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 764);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1570, 55);
            this.panel1.TabIndex = 32;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "consultation_id";
            this.Column1.HeaderText = "Id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "owner_id";
            this.Column2.HeaderText = "Owner";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "pet_id";
            this.Column3.HeaderText = "Pet Name";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "blood_pressure";
            this.Column4.HeaderText = "Blood Pressure";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "heart_rate";
            this.Column5.HeaderText = "Heart Rate";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "weight";
            this.Column6.HeaderText = "Weight";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "temperature";
            this.Column7.HeaderText = "Temperature";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "complaint";
            this.Column8.HeaderText = "Complaint";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "findings";
            this.Column9.HeaderText = "Finding";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 150;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "plantreatment";
            this.Column10.HeaderText = "Treatment";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 200;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "medications";
            this.Column11.HeaderText = "Medication";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 300;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column12.DataPropertyName = "consult_date";
            this.Column12.HeaderText = "Consult Date";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // pet_id
            // 
            this.pet_id.DataPropertyName = "pet_id";
            this.pet_id.HeaderText = "Id";
            this.pet_id.MinimumWidth = 6;
            this.pet_id.Name = "pet_id";
            this.pet_id.Visible = false;
            this.pet_id.Width = 125;
            // 
            // pet_name
            // 
            this.pet_name.DataPropertyName = "pet_name";
            this.pet_name.HeaderText = "Pet Name";
            this.pet_name.MinimumWidth = 6;
            this.pet_name.Name = "pet_name";
            this.pet_name.Width = 250;
            // 
            // species
            // 
            this.species.DataPropertyName = "species";
            this.species.HeaderText = "Specie";
            this.species.MinimumWidth = 6;
            this.species.Name = "species";
            this.species.Width = 250;
            // 
            // breed
            // 
            this.breed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.breed.DataPropertyName = "breed";
            this.breed.HeaderText = "Breed";
            this.breed.MinimumWidth = 6;
            this.breed.Name = "breed";
            // 
            // frmConsultationHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 819);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvConsultation);
            this.Controls.Add(this.dgvPets);
            this.Controls.Add(this.dgvOwners);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConsultationHistory";
            this.Text = "frmConsultationHistory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvPets;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_consultations;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_id;
        private System.Windows.Forms.DataGridView dgvOwners;
        private System.Windows.Forms.DataGridView dgvConsultation;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn pet_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pet_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn species;
        private System.Windows.Forms.DataGridViewTextBoxColumn breed;
    }
}