namespace app.view.Transaction
{
    partial class frmPayment
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
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnterAmount = new System.Windows.Forms.TextBox();
            this.lblChangeAmount = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(86, 128);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(108, 20);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Amount:";
            // 
            // txtEnterAmount
            // 
            this.txtEnterAmount.Location = new System.Drawing.Point(204, 169);
            this.txtEnterAmount.Name = "txtEnterAmount";
            this.txtEnterAmount.Size = new System.Drawing.Size(223, 26);
            this.txtEnterAmount.TabIndex = 2;
            this.txtEnterAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChangeAmount
            // 
            this.lblChangeAmount.AutoSize = true;
            this.lblChangeAmount.Location = new System.Drawing.Point(86, 243);
            this.lblChangeAmount.Name = "lblChangeAmount";
            this.lblChangeAmount.Size = new System.Drawing.Size(129, 20);
            this.lblChangeAmount.TabIndex = 3;
            this.lblChangeAmount.Text = "Change Amount:";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(90, 289);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(337, 64);
            this.btnPay.TabIndex = 4;
            this.btnPay.Text = "&Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 383);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblChangeAmount);
            this.Controls.Add(this.txtEnterAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalAmount);
            this.Name = "frmPayment";
            this.Text = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEnterAmount;
        private System.Windows.Forms.Label lblChangeAmount;
        private System.Windows.Forms.Button btnPay;
    }
}