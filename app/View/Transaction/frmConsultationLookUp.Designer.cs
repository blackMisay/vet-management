namespace app.view.Transaction
{
    partial class frmConsultationLookUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultationLookUp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvConsultation = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.consultation_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pet_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pet_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phonenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobilenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pet_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pet_birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pet_age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.species = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consult_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultation)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.lblDesc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 77);
            this.panel1.TabIndex = 14;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(12, 64);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(0, 23);
            this.lblDesc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultation List";
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::app.Properties.Resources.icons8_edit_16;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(187, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(133, 41);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "&Add";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Image = global::app.Properties.Resources.icons8_cancel_16__1_;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(326, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 41);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvConsultation
            // 
            this.dgvConsultation.AllowUserToAddRows = false;
            this.dgvConsultation.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsultation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consultation_id,
            this.owner_id,
            this.pet_id,
            this.owner_name,
            this.owner_address,
            this.pet_name,
            this.phonenumber,
            this.mobilenumber,
            this.pet_weight,
            this.color,
            this.pet_birthdate,
            this.pet_age,
            this.breed,
            this.species,
            this.gender,
            this.consult_date});
            this.dgvConsultation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConsultation.Location = new System.Drawing.Point(0, 75);
            this.dgvConsultation.Name = "dgvConsultation";
            this.dgvConsultation.RowHeadersVisible = false;
            this.dgvConsultation.RowHeadersWidth = 51;
            this.dgvConsultation.RowTemplate.Height = 24;
            this.dgvConsultation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultation.Size = new System.Drawing.Size(608, 458);
            this.dgvConsultation.TabIndex = 15;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = global::app.Properties.Resources.icons8_cancel_16__1_;
            this.btnRemove.Location = new System.Drawing.Point(465, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(133, 41);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 533);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 58);
            this.panel2.TabIndex = 16;
            // 
            // consultation_id
            // 
            this.consultation_id.DataPropertyName = "consultation_id";
            this.consultation_id.HeaderText = "Consultation ID";
            this.consultation_id.MinimumWidth = 6;
            this.consultation_id.Name = "consultation_id";
            this.consultation_id.Visible = false;
            this.consultation_id.Width = 125;
            // 
            // owner_id
            // 
            this.owner_id.DataPropertyName = "owner_id";
            this.owner_id.HeaderText = "Patient ID";
            this.owner_id.MinimumWidth = 6;
            this.owner_id.Name = "owner_id";
            this.owner_id.Visible = false;
            this.owner_id.Width = 125;
            // 
            // pet_id
            // 
            this.pet_id.DataPropertyName = "pet_id";
            this.pet_id.HeaderText = "Pet ID";
            this.pet_id.MinimumWidth = 6;
            this.pet_id.Name = "pet_id";
            this.pet_id.Visible = false;
            this.pet_id.Width = 125;
            // 
            // owner_name
            // 
            this.owner_name.DataPropertyName = "owner_name";
            this.owner_name.HeaderText = "Owner Name";
            this.owner_name.MinimumWidth = 6;
            this.owner_name.Name = "owner_name";
            this.owner_name.Width = 200;
            // 
            // owner_address
            // 
            this.owner_address.DataPropertyName = "owner_address";
            this.owner_address.HeaderText = "Owner Address";
            this.owner_address.MinimumWidth = 6;
            this.owner_address.Name = "owner_address";
            this.owner_address.Visible = false;
            this.owner_address.Width = 125;
            // 
            // pet_name
            // 
            this.pet_name.DataPropertyName = "pet_name";
            this.pet_name.HeaderText = "Pet Name";
            this.pet_name.MinimumWidth = 6;
            this.pet_name.Name = "pet_name";
            this.pet_name.Width = 200;
            // 
            // phonenumber
            // 
            this.phonenumber.DataPropertyName = "phonenumber";
            this.phonenumber.HeaderText = "Phone Number";
            this.phonenumber.MinimumWidth = 6;
            this.phonenumber.Name = "phonenumber";
            this.phonenumber.Visible = false;
            this.phonenumber.Width = 125;
            // 
            // mobilenumber
            // 
            this.mobilenumber.DataPropertyName = "mobilenumber";
            this.mobilenumber.HeaderText = "Mobile Number";
            this.mobilenumber.MinimumWidth = 6;
            this.mobilenumber.Name = "mobilenumber";
            this.mobilenumber.Visible = false;
            this.mobilenumber.Width = 125;
            // 
            // pet_weight
            // 
            this.pet_weight.DataPropertyName = "pet_weight";
            this.pet_weight.HeaderText = "Pet Weight";
            this.pet_weight.MinimumWidth = 6;
            this.pet_weight.Name = "pet_weight";
            this.pet_weight.Visible = false;
            this.pet_weight.Width = 125;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "Color";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.Visible = false;
            this.color.Width = 125;
            // 
            // pet_birthdate
            // 
            this.pet_birthdate.DataPropertyName = "pet_birthdate";
            this.pet_birthdate.HeaderText = "Pet Birthdate";
            this.pet_birthdate.MinimumWidth = 6;
            this.pet_birthdate.Name = "pet_birthdate";
            this.pet_birthdate.Visible = false;
            this.pet_birthdate.Width = 125;
            // 
            // pet_age
            // 
            this.pet_age.DataPropertyName = "pet_age";
            this.pet_age.HeaderText = "Pet Age";
            this.pet_age.MinimumWidth = 6;
            this.pet_age.Name = "pet_age";
            this.pet_age.Visible = false;
            this.pet_age.Width = 125;
            // 
            // breed
            // 
            this.breed.DataPropertyName = "breed";
            this.breed.HeaderText = "Breed";
            this.breed.MinimumWidth = 6;
            this.breed.Name = "breed";
            this.breed.Visible = false;
            this.breed.Width = 125;
            // 
            // species
            // 
            this.species.DataPropertyName = "species";
            this.species.HeaderText = "Specie";
            this.species.MinimumWidth = 6;
            this.species.Name = "species";
            this.species.Visible = false;
            this.species.Width = 125;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "Gender";
            this.gender.MinimumWidth = 6;
            this.gender.Name = "gender";
            this.gender.Visible = false;
            this.gender.Width = 125;
            // 
            // consult_date
            // 
            this.consult_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.consult_date.DataPropertyName = "consult_date";
            this.consult_date.HeaderText = "Consult Date";
            this.consult_date.MinimumWidth = 6;
            this.consult_date.Name = "consult_date";
            // 
            // frmConsultationLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 591);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvConsultation);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConsultationLookUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAHAGUN Veterinary Clinic v2.0";
            this.Load += new System.EventHandler(this.frmConsultationLookUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvConsultation;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn consultation_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pet_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn pet_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn phonenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobilenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn pet_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn pet_birthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn pet_age;
        private System.Windows.Forms.DataGridViewTextBoxColumn breed;
        private System.Windows.Forms.DataGridViewTextBoxColumn species;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn consult_date;
    }
}