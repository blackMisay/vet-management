namespace app.view
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMedicalRecords = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnVaccination = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnConsultation = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.toolTip_Main = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1420, 44);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.button1);
            this.pnlMenu.Controls.Add(this.btnMedicalRecords);
            this.pnlMenu.Controls.Add(this.btnAccount);
            this.pnlMenu.Controls.Add(this.btnServices);
            this.pnlMenu.Controls.Add(this.btnVaccination);
            this.pnlMenu.Controls.Add(this.btnInventory);
            this.pnlMenu.Controls.Add(this.btnItem);
            this.pnlMenu.Controls.Add(this.btnConsultation);
            this.pnlMenu.Controls.Add(this.btnClient);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 44);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
            this.pnlMenu.Size = new System.Drawing.Size(1420, 75);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnDashboard.Image = global::app.Properties.Resources.healthdashboard_24px;
            this.btnDashboard.Location = new System.Drawing.Point(9, 11);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(105, 56);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnDashboard, "Dashboard");
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnLogout.Image = global::app.Properties.Resources.logout_24px;
            this.btnLogout.Location = new System.Drawing.Point(1302, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(105, 56);
            this.btnLogout.TabIndex = 17;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnLogout, "Logout");
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnSettings.Image = global::app.Properties.Resources.medsettings_24px;
            this.btnSettings.Location = new System.Drawing.Point(1191, 13);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(105, 56);
            this.btnSettings.TabIndex = 20;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnSettings, "Settings");
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.button1.Image = global::app.Properties.Resources.medical_record_24px;
            this.button1.Location = new System.Drawing.Point(120, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 56);
            this.button1.TabIndex = 7;
            this.button1.Text = "Transaction";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnMedicalRecords_Click);
            // 
            // btnMedicalRecords
            // 
            this.btnMedicalRecords.BackColor = System.Drawing.Color.White;
            this.btnMedicalRecords.FlatAppearance.BorderSize = 0;
            this.btnMedicalRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMedicalRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicalRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicalRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnMedicalRecords.Image = global::app.Properties.Resources.medical_record_24px;
            this.btnMedicalRecords.Location = new System.Drawing.Point(118, 11);
            this.btnMedicalRecords.Name = "btnMedicalRecords";
            this.btnMedicalRecords.Size = new System.Drawing.Size(105, 56);
            this.btnMedicalRecords.TabIndex = 7;
            this.toolTip_Main.SetToolTip(this.btnMedicalRecords, "Medical Record");
            this.btnMedicalRecords.UseVisualStyleBackColor = false;
            this.btnMedicalRecords.Click += new System.EventHandler(this.btnMedicalRecords_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.White;
            this.btnAccount.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnAccount.Image = global::app.Properties.Resources.user;
            this.btnAccount.Location = new System.Drawing.Point(897, 11);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(105, 56);
            this.btnAccount.TabIndex = 23;
            this.btnAccount.Text = "Account Management";
            this.btnAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnAccount, "Accounts");
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnServices
            // 
            this.btnServices.BackColor = System.Drawing.Color.White;
            this.btnServices.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnServices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServices.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnServices.Image = global::app.Properties.Resources.services_24px;
            this.btnServices.Location = new System.Drawing.Point(786, 11);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(105, 56);
            this.btnServices.TabIndex = 21;
            this.btnServices.Text = "Services";
            this.btnServices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnServices, "Services");
            this.btnServices.UseVisualStyleBackColor = false;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // btnVaccination
            // 
            this.btnVaccination.BackColor = System.Drawing.Color.White;
            this.btnVaccination.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVaccination.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVaccination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVaccination.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVaccination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnVaccination.Image = global::app.Properties.Resources.immunity_24px;
            this.btnVaccination.Location = new System.Drawing.Point(453, 11);
            this.btnVaccination.Name = "btnVaccination";
            this.btnVaccination.Size = new System.Drawing.Size(105, 56);
            this.btnVaccination.TabIndex = 25;
            this.btnVaccination.Text = "Vaccination";
            this.btnVaccination.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnVaccination, "Vaccination");
            this.btnVaccination.UseVisualStyleBackColor = false;
            this.btnVaccination.Click += new System.EventHandler(this.btnVaccination_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.White;
            this.btnInventory.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnInventory.Image = global::app.Properties.Resources.medinventory_24px;
            this.btnInventory.Location = new System.Drawing.Point(675, 11);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(105, 56);
            this.btnInventory.TabIndex = 15;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnInventory, "Inventory");
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnItem
            // 
            this.btnItem.BackColor = System.Drawing.Color.White;
            this.btnItem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItem.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnItem.Image = global::app.Properties.Resources.items_24px;
            this.btnItem.Location = new System.Drawing.Point(564, 11);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(105, 56);
            this.btnItem.TabIndex = 13;
            this.btnItem.Text = "Items";
            this.btnItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnItem, "Items");
            this.btnItem.UseVisualStyleBackColor = false;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // btnConsultation
            // 
            this.btnConsultation.BackColor = System.Drawing.Color.White;
            this.btnConsultation.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConsultation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultation.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnConsultation.Image = global::app.Properties.Resources.diagnosis_24px;
            this.btnConsultation.Location = new System.Drawing.Point(342, 11);
            this.btnConsultation.Name = "btnConsultation";
            this.btnConsultation.Size = new System.Drawing.Size(105, 56);
            this.btnConsultation.TabIndex = 11;
            this.btnConsultation.Text = "Consultation";
            this.btnConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnConsultation, "Diagnosis");
            this.btnConsultation.UseVisualStyleBackColor = false;
            this.btnConsultation.Click += new System.EventHandler(this.btnConsultation_Click);
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.White;
            this.btnClient.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnClient.Image = global::app.Properties.Resources.owner_24px;
            this.btnClient.Location = new System.Drawing.Point(231, 11);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(105, 56);
            this.btnClient.TabIndex = 9;
            this.btnClient.Text = "Client Record";
            this.btnClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip_Main.SetToolTip(this.btnClient, "Client");
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 656);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1420, 24);
            this.pnlFooter.TabIndex = 2;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 119);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1420, 537);
            this.pnlBody.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(391, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "SAHAGUN VETERINARY CLINIC";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1420, 680);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Veterinary Clinic Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnMedicalRecords;
        private System.Windows.Forms.Button btnConsultation;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.ToolTip toolTip_Main;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnVaccination;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}