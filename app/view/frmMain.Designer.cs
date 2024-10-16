﻿namespace app.view
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
            this.btnServices = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlInventorySpacer = new System.Windows.Forms.Panel();
            this.btnInventory = new System.Windows.Forms.Button();
            this.pnlItemSpacer = new System.Windows.Forms.Panel();
            this.btnItem = new System.Windows.Forms.Button();
            this.pnlDiagnosisSpacer = new System.Windows.Forms.Panel();
            this.btnDiagnosis = new System.Windows.Forms.Button();
            this.pnlClientSpacer = new System.Windows.Forms.Panel();
            this.btnClient = new System.Windows.Forms.Button();
            this.pnlViewMedicalRecordSpacer = new System.Windows.Forms.Panel();
            this.btnMedicalRecords = new System.Windows.Forms.Button();
            this.pnlDashboardSpacer = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.toolTip_Main = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1420, 44);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.btnServices);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.panel1);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.pnlInventorySpacer);
            this.pnlMenu.Controls.Add(this.btnInventory);
            this.pnlMenu.Controls.Add(this.pnlItemSpacer);
            this.pnlMenu.Controls.Add(this.btnItem);
            this.pnlMenu.Controls.Add(this.pnlDiagnosisSpacer);
            this.pnlMenu.Controls.Add(this.btnDiagnosis);
            this.pnlMenu.Controls.Add(this.pnlClientSpacer);
            this.pnlMenu.Controls.Add(this.btnClient);
            this.pnlMenu.Controls.Add(this.pnlViewMedicalRecordSpacer);
            this.pnlMenu.Controls.Add(this.btnMedicalRecords);
            this.pnlMenu.Controls.Add(this.pnlDashboardSpacer);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.btnToggle);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 44);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
            this.pnlMenu.Size = new System.Drawing.Size(70, 599);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnServices
            // 
            this.btnServices.BackColor = System.Drawing.Color.White;
            this.btnServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServices.FlatAppearance.BorderSize = 0;
            this.btnServices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServices.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnServices.Image = global::app.Properties.Resources.services_24px;
            this.btnServices.Location = new System.Drawing.Point(10, 413);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(50, 50);
            this.btnServices.TabIndex = 21;
            this.toolTip_Main.SetToolTip(this.btnServices, "Services");
            this.btnServices.UseVisualStyleBackColor = false;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnSettings.Image = global::app.Properties.Resources.medsettings_24px;
            this.btnSettings.Location = new System.Drawing.Point(10, 484);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(50, 50);
            this.btnSettings.TabIndex = 20;
            this.toolTip_Main.SetToolTip(this.btnSettings, "Settings");
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 534);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(13, 5, 13, 0);
            this.panel1.Size = new System.Drawing.Size(50, 10);
            this.panel1.TabIndex = 18;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnLogout.Image = global::app.Properties.Resources.logout_24px;
            this.btnLogout.Location = new System.Drawing.Point(10, 544);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(50, 50);
            this.btnLogout.TabIndex = 17;
            this.toolTip_Main.SetToolTip(this.btnLogout, "Logout");
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlInventorySpacer
            // 
            this.pnlInventorySpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInventorySpacer.Location = new System.Drawing.Point(10, 403);
            this.pnlInventorySpacer.Name = "pnlInventorySpacer";
            this.pnlInventorySpacer.Padding = new System.Windows.Forms.Padding(13, 5, 13, 0);
            this.pnlInventorySpacer.Size = new System.Drawing.Size(50, 10);
            this.pnlInventorySpacer.TabIndex = 16;
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.White;
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnInventory.Image = global::app.Properties.Resources.medinventory_24px;
            this.btnInventory.Location = new System.Drawing.Point(10, 353);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(50, 50);
            this.btnInventory.TabIndex = 15;
            this.toolTip_Main.SetToolTip(this.btnInventory, "Inventory");
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // pnlItemSpacer
            // 
            this.pnlItemSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlItemSpacer.Location = new System.Drawing.Point(10, 343);
            this.pnlItemSpacer.Name = "pnlItemSpacer";
            this.pnlItemSpacer.Padding = new System.Windows.Forms.Padding(13, 5, 13, 0);
            this.pnlItemSpacer.Size = new System.Drawing.Size(50, 10);
            this.pnlItemSpacer.TabIndex = 14;
            // 
            // btnItem
            // 
            this.btnItem.BackColor = System.Drawing.Color.White;
            this.btnItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnItem.FlatAppearance.BorderSize = 0;
            this.btnItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnItem.Image = global::app.Properties.Resources.items_24px;
            this.btnItem.Location = new System.Drawing.Point(10, 293);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(50, 50);
            this.btnItem.TabIndex = 13;
            this.toolTip_Main.SetToolTip(this.btnItem, "Items");
            this.btnItem.UseVisualStyleBackColor = false;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // pnlDiagnosisSpacer
            // 
            this.pnlDiagnosisSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDiagnosisSpacer.Location = new System.Drawing.Point(10, 283);
            this.pnlDiagnosisSpacer.Name = "pnlDiagnosisSpacer";
            this.pnlDiagnosisSpacer.Padding = new System.Windows.Forms.Padding(13, 5, 13, 0);
            this.pnlDiagnosisSpacer.Size = new System.Drawing.Size(50, 10);
            this.pnlDiagnosisSpacer.TabIndex = 12;
            // 
            // btnDiagnosis
            // 
            this.btnDiagnosis.BackColor = System.Drawing.Color.White;
            this.btnDiagnosis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDiagnosis.FlatAppearance.BorderSize = 0;
            this.btnDiagnosis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDiagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiagnosis.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnDiagnosis.Image = global::app.Properties.Resources.diagnosis_24px;
            this.btnDiagnosis.Location = new System.Drawing.Point(10, 233);
            this.btnDiagnosis.Name = "btnDiagnosis";
            this.btnDiagnosis.Size = new System.Drawing.Size(50, 50);
            this.btnDiagnosis.TabIndex = 11;
            this.toolTip_Main.SetToolTip(this.btnDiagnosis, "Diagnosis");
            this.btnDiagnosis.UseVisualStyleBackColor = false;
            this.btnDiagnosis.Click += new System.EventHandler(this.btnDiagnosis_Click);
            // 
            // pnlClientSpacer
            // 
            this.pnlClientSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClientSpacer.Location = new System.Drawing.Point(10, 223);
            this.pnlClientSpacer.Name = "pnlClientSpacer";
            this.pnlClientSpacer.Padding = new System.Windows.Forms.Padding(13, 5, 13, 0);
            this.pnlClientSpacer.Size = new System.Drawing.Size(50, 10);
            this.pnlClientSpacer.TabIndex = 10;
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.White;
            this.btnClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClient.FlatAppearance.BorderSize = 0;
            this.btnClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnClient.Image = global::app.Properties.Resources.owner_24px;
            this.btnClient.Location = new System.Drawing.Point(10, 173);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(50, 50);
            this.btnClient.TabIndex = 9;
            this.toolTip_Main.SetToolTip(this.btnClient, "Client");
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // pnlViewMedicalRecordSpacer
            // 
            this.pnlViewMedicalRecordSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlViewMedicalRecordSpacer.Location = new System.Drawing.Point(10, 163);
            this.pnlViewMedicalRecordSpacer.Name = "pnlViewMedicalRecordSpacer";
            this.pnlViewMedicalRecordSpacer.Padding = new System.Windows.Forms.Padding(13, 5, 13, 0);
            this.pnlViewMedicalRecordSpacer.Size = new System.Drawing.Size(50, 10);
            this.pnlViewMedicalRecordSpacer.TabIndex = 8;
            // 
            // btnMedicalRecords
            // 
            this.btnMedicalRecords.BackColor = System.Drawing.Color.White;
            this.btnMedicalRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedicalRecords.FlatAppearance.BorderSize = 0;
            this.btnMedicalRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMedicalRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicalRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicalRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnMedicalRecords.Image = global::app.Properties.Resources.medical_record_24px;
            this.btnMedicalRecords.Location = new System.Drawing.Point(10, 113);
            this.btnMedicalRecords.Name = "btnMedicalRecords";
            this.btnMedicalRecords.Size = new System.Drawing.Size(50, 50);
            this.btnMedicalRecords.TabIndex = 7;
            this.toolTip_Main.SetToolTip(this.btnMedicalRecords, "Medical Record");
            this.btnMedicalRecords.UseVisualStyleBackColor = false;
            this.btnMedicalRecords.Click += new System.EventHandler(this.btnMedicalRecords_Click);
            // 
            // pnlDashboardSpacer
            // 
            this.pnlDashboardSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboardSpacer.Location = new System.Drawing.Point(10, 103);
            this.pnlDashboardSpacer.Name = "pnlDashboardSpacer";
            this.pnlDashboardSpacer.Padding = new System.Windows.Forms.Padding(13, 5, 13, 0);
            this.pnlDashboardSpacer.Size = new System.Drawing.Size(50, 10);
            this.pnlDashboardSpacer.TabIndex = 6;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
            this.btnDashboard.Image = global::app.Properties.Resources.healthdashboard_24px;
            this.btnDashboard.Location = new System.Drawing.Point(10, 53);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(50, 50);
            this.btnDashboard.TabIndex = 1;
            this.toolTip_Main.SetToolTip(this.btnDashboard, "Dashboard");
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnToggle
            // 
            this.btnToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToggle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Image = global::app.Properties.Resources.main_menu_24px;
            this.btnToggle.Location = new System.Drawing.Point(10, 0);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(50, 53);
            this.btnToggle.TabIndex = 0;
            this.toolTip_Main.SetToolTip(this.btnToggle, "Toggle sidebar");
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(212)))), ((int)(((byte)(175)))));
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 643);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1420, 24);
            this.pnlFooter.TabIndex = 2;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(70, 44);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1350, 599);
            this.pnlBody.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1420, 667);
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
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Panel pnlDashboardSpacer;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlClientSpacer;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Panel pnlViewMedicalRecordSpacer;
        private System.Windows.Forms.Button btnMedicalRecords;
        private System.Windows.Forms.Panel pnlDiagnosisSpacer;
        private System.Windows.Forms.Button btnDiagnosis;
        private System.Windows.Forms.Panel pnlInventorySpacer;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Panel pnlItemSpacer;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.ToolTip toolTip_Main;
    }
}