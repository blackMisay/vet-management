namespace app.view.Immunization
{
    partial class frmVaccine
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvVaccine = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typical_dose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recommended_dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recommended_interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccine)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 65);
            this.panel1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vaccine List";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 578);
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1311, 65);
            this.panel2.TabIndex = 26;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::app.Properties.Resources.icons8_edit_button_30;
            this.btnAdd.Location = new System.Drawing.Point(1118, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(181, 47);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Select";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvVaccine
            // 
            this.dgvVaccine.AllowUserToAddRows = false;
            this.dgvVaccine.AllowUserToDeleteRows = false;
            this.dgvVaccine.AllowUserToResizeColumns = false;
            this.dgvVaccine.AllowUserToResizeRows = false;
            this.dgvVaccine.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvVaccine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Code,
            this.Description,
            this.typical_dose,
            this.recommended_dosage,
            this.recommended_interval,
            this.Column1});
            this.dgvVaccine.Location = new System.Drawing.Point(0, 143);
            this.dgvVaccine.Name = "dgvVaccine";
            this.dgvVaccine.RowHeadersVisible = false;
            this.dgvVaccine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvVaccine.RowTemplate.Height = 24;
            this.dgvVaccine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVaccine.Size = new System.Drawing.Size(1311, 426);
            this.dgvVaccine.TabIndex = 27;
            this.dgvVaccine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVaccine_CellClick);
            this.dgvVaccine.Click += new System.EventHandler(this.dgvVaccine_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Location = new System.Drawing.Point(0, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1311, 73);
            this.panel3.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 21);
            this.label2.TabIndex = 31;
            this.label2.Text = "Search by (CODE)";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(316, 32);
            this.txtSearch.TabIndex = 30;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "vaccine_code";
            this.Code.HeaderText = "Code";
            this.Code.MinimumWidth = 6;
            this.Code.Name = "Code";
            this.Code.Visible = false;
            this.Code.Width = 125;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "description";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.DefaultCellStyle = dataGridViewCellStyle1;
            this.Description.FillWeight = 400F;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Width = 1000;
            // 
            // typical_dose
            // 
            this.typical_dose.DataPropertyName = "typical_dose";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typical_dose.DefaultCellStyle = dataGridViewCellStyle2;
            this.typical_dose.HeaderText = "Dose";
            this.typical_dose.MinimumWidth = 6;
            this.typical_dose.Name = "typical_dose";
            this.typical_dose.Visible = false;
            this.typical_dose.Width = 125;
            // 
            // recommended_dosage
            // 
            this.recommended_dosage.DataPropertyName = "recommended_dosage";
            this.recommended_dosage.HeaderText = "Dosage";
            this.recommended_dosage.MinimumWidth = 6;
            this.recommended_dosage.Name = "recommended_dosage";
            this.recommended_dosage.Visible = false;
            this.recommended_dosage.Width = 125;
            // 
            // recommended_interval
            // 
            this.recommended_interval.DataPropertyName = "recommended_interval";
            this.recommended_interval.HeaderText = "Interval";
            this.recommended_interval.MinimumWidth = 6;
            this.recommended_interval.Name = "recommended_interval";
            this.recommended_interval.Visible = false;
            this.recommended_interval.Width = 125;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Price";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // frmVaccine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 643);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvVaccine);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVaccine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVaccine";
            this.Load += new System.EventHandler(this.frmVaccine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccine)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvVaccine;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn typical_dose;
        private System.Windows.Forms.DataGridViewTextBoxColumn recommended_dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn recommended_interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}