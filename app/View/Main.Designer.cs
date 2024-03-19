namespace app
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.tspClient = new System.Windows.Forms.ToolStripButton();
            this.tspProduct = new System.Windows.Forms.ToolStripButton();
            this.tspInventory = new System.Windows.Forms.ToolStripButton();
            this.tspReport = new System.Windows.Forms.ToolStripButton();
            this.tspTransact = new System.Windows.Forms.ToolStripButton();
            this.tspAdmin = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(1142, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(105, 34);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnOut
            // 
            this.btnOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.Location = new System.Drawing.Point(1145, 12);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(102, 34);
            this.btnOut.TabIndex = 2;
            this.btnOut.Text = "Logout";
            this.btnOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // tspClient
            // 
            this.tspClient.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspClient.ForeColor = System.Drawing.Color.Black;
            this.tspClient.Image = global::app.Properties.Resources.icons8_client_32;
            this.tspClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspClient.Name = "tspClient";
            this.tspClient.Size = new System.Drawing.Size(62, 61);
            this.tspClient.Tag = "";
            this.tspClient.Text = "Client";
            this.tspClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspClient.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // tspProduct
            // 
            this.tspProduct.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspProduct.ForeColor = System.Drawing.Color.Black;
            this.tspProduct.Image = global::app.Properties.Resources.item;
            this.tspProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspProduct.Name = "tspProduct";
            this.tspProduct.Size = new System.Drawing.Size(87, 61);
            this.tspProduct.Tag = "";
            this.tspProduct.Text = "Products";
            this.tspProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspProduct.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // tspInventory
            // 
            this.tspInventory.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspInventory.ForeColor = System.Drawing.Color.Black;
            this.tspInventory.Image = global::app.Properties.Resources.product;
            this.tspInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspInventory.Name = "tspInventory";
            this.tspInventory.Size = new System.Drawing.Size(92, 61);
            this.tspInventory.Tag = "";
            this.tspInventory.Text = "Inventory";
            this.tspInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspInventory.Click += new System.EventHandler(this.tspInventory_Click);
            // 
            // tspReport
            // 
            this.tspReport.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspReport.ForeColor = System.Drawing.Color.Black;
            this.tspReport.Image = global::app.Properties.Resources.records;
            this.tspReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspReport.Name = "tspReport";
            this.tspReport.Size = new System.Drawing.Size(77, 61);
            this.tspReport.Tag = "";
            this.tspReport.Text = "Reports";
            this.tspReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspReport.Click += new System.EventHandler(this.tspReport_Click);
            // 
            // tspTransact
            // 
            this.tspTransact.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspTransact.ForeColor = System.Drawing.Color.Black;
            this.tspTransact.Image = global::app.Properties.Resources.transaction;
            this.tspTransact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspTransact.Name = "tspTransact";
            this.tspTransact.Size = new System.Drawing.Size(110, 61);
            this.tspTransact.Tag = "";
            this.tspTransact.Text = "Transaction";
            this.tspTransact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspTransact.Click += new System.EventHandler(this.tspTransact_Click);
            // 
            // tspAdmin
            // 
            this.tspAdmin.ForeColor = System.Drawing.Color.Black;
            this.tspAdmin.Image = global::app.Properties.Resources.staff;
            this.tspAdmin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspAdmin.Name = "tspAdmin";
            this.tspAdmin.Size = new System.Drawing.Size(132, 61);
            this.tspAdmin.Tag = "";
            this.tspAdmin.Text = "Administration";
            this.tspAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspAdmin.Click += new System.EventHandler(this.tspAdmin_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolStrip2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspClient,
            this.tspProduct,
            this.tspInventory,
            this.tspReport,
            this.tspTransact,
            this.tspAdmin});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1259, 64);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.TabStop = true;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 578);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1259, 578);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1259, 642);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.ToolStripButton tspClient;
        private System.Windows.Forms.ToolStripButton tspProduct;
        private System.Windows.Forms.ToolStripButton tspInventory;
        private System.Windows.Forms.ToolStripButton tspReport;
        private System.Windows.Forms.ToolStripButton tspTransact;
        private System.Windows.Forms.ToolStripButton tspAdmin;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

