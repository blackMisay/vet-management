namespace app.view.Product
{
    partial class frmProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "breedDesc";
            this.Column7.HeaderText = "Breed";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "speciesName";
            this.Column6.HeaderText = "Species";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "sexname";
            this.Column5.HeaderText = "Gender";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "bday";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "Birthday";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.DataPropertyName = "colorName";
            this.Column8.HeaderText = "Color";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1474, 75);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Lists";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnReport);
            this.panel2.Controls.Add(this.btnSaveProduct);
            this.panel2.Controls.Add(this.btnEditProduct);
            this.panel2.Controls.Add(this.btnRemoveProduct);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Location = new System.Drawing.Point(1, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1474, 65);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Search by Category";
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Image = global::app.Properties.Resources.project_management;
            this.btnReport.Location = new System.Drawing.Point(1333, 18);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(129, 31);
            this.btnReport.TabIndex = 16;
            this.btnReport.Text = "&Generate";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click_1);
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProduct.BackColor = System.Drawing.Color.White;
            this.btnSaveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProduct.Image = global::app.Properties.Resources.diagnosis_24px;
            this.btnSaveProduct.Location = new System.Drawing.Point(908, 18);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(199, 31);
            this.btnSaveProduct.TabIndex = 15;
            this.btnSaveProduct.Text = "&Add New Product";
            this.btnSaveProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveProduct.UseVisualStyleBackColor = false;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProduct.BackColor = System.Drawing.Color.White;
            this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProduct.Image = global::app.Properties.Resources.icons8_update_16;
            this.btnEditProduct.Location = new System.Drawing.Point(1113, 18);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(103, 31);
            this.btnEditProduct.TabIndex = 14;
            this.btnEditProduct.Text = "&Update";
            this.btnEditProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditProduct.UseVisualStyleBackColor = false;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveProduct.BackColor = System.Drawing.Color.White;
            this.btnRemoveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveProduct.Image = global::app.Properties.Resources.icons8_remove_16;
            this.btnRemoveProduct.Location = new System.Drawing.Point(1222, 18);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(105, 31);
            this.btnRemoveProduct.TabIndex = 13;
            this.btnRemoveProduct.Text = "&Remove";
            this.btnRemoveProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(195, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(332, 28);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::app.Properties.Resources.icons8_google_web_search_16;
            this.btnSearch.Location = new System.Drawing.Point(533, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 31);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeight = 29;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.type,
            this.Category,
            this.Brand,
            this.Description,
            this.Column1});
            this.dgvProducts.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvProducts.Location = new System.Drawing.Point(1, 153);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(1474, 664);
            this.dgvProducts.TabIndex = 2;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
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
            // Id
            // 
            this.Id.DataPropertyName = "prodID";
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // type
            // 
            this.type.DataPropertyName = "typeDescription";
            this.type.HeaderText = "Type of Product";
            this.type.MinimumWidth = 10;
            this.type.Name = "type";
            this.type.Width = 200;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "categoryDescription";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Category.DefaultCellStyle = dataGridViewCellStyle2;
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 100;
            this.Category.Name = "Category";
            this.Category.Width = 200;
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "brandDesc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Brand.DefaultCellStyle = dataGridViewCellStyle3;
            this.Brand.HeaderText = "Brand";
            this.Brand.MinimumWidth = 50;
            this.Brand.Name = "Brand";
            this.Brand.Width = 200;
            // 
            // Description
            // 

            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "prodDesc";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Description.DefaultCellStyle = dataGridViewCellStyle4;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 400;
            this.Description.Name = "Description";

            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "isDeleted";
            this.Column1.HeaderText = "isDeleted";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 125;
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 820);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProducts";
            this.Text = "Products Management";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;

        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}