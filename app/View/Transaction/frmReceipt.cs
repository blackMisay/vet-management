using app.core.model;
using app.core.repository;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace app.view.Transaction
{
    public partial class frmReceipt : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private TransactionPayment currentPayment; // store loaded payment here
        private Font headerFont = new Font("Century Gothic", 14, FontStyle.Bold);
        private Font contentFont = new Font("Century Gothic", 10);
        private Font italicFont = new Font("Century Gothic", 10, FontStyle.Italic);

        public frmReceipt(TransactionPayment payment)
        {
            InitializeComponent();
            printDocument.PrintPage += PrintPage;
            printPreviewDialog.Document = printDocument;
            this.currentPayment = payment;
        }

        public void ShowPreview()
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 850, 1100);
            doc.PrintPage += PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = doc,
                Width = 800,
                Height = 600
            };
            preview.ShowDialog();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            if (currentPayment == null)
            {
                e.Graphics.DrawString("No payment to print.", new Font("Arial", 12), Brushes.Black, 50, 50);
                return;
            }

            Graphics g = e.Graphics;
            int leftMargin = 50;
            Font headerFont = new Font("Century Gothic", 16, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 12, FontStyle.Bold);
            Font contentFont = new Font("Arial", 10);
            int y = 20;
            int lineHeight = (int)contentFont.GetHeight(g) + 5;

            // Clinic Header
            g.DrawString("SAHAGUN VETERINARY CLINIC", headerFont, Brushes.Black, leftMargin, y); y += 30;
            g.DrawString("6418 Zapote Street Area D., Camarin Road, Caloocan City", contentFont, Brushes.Black, leftMargin, y); y += 20;
            g.DrawString("Contact: 0999-999-9999", contentFont, Brushes.Black, leftMargin, y); y += 30;

            // Receipt Header
            g.DrawString("RECEIPT", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, leftMargin, y); y += lineHeight * 2;

            g.DrawString($"Invoice #: {currentPayment.InvoiceNumber}", contentFont, Brushes.Black, leftMargin, y); y += lineHeight;
            g.DrawString($"Date: {currentPayment.Date:yyyy-MM-dd HH:mm}", contentFont, Brushes.Black, leftMargin, y); y += lineHeight;

            // Client & Pet
            string clientName = $"{currentPayment.Client?.FirstName} {currentPayment.Client?.LastName}".Trim();
            g.DrawString($"Client: {clientName}", contentFont, Brushes.Black, leftMargin, y); y += lineHeight;
            g.DrawString($"Pet: {currentPayment.Pet?.Name}", contentFont, Brushes.Black, leftMargin, y); y += lineHeight * 2;

            // Items / Services
            g.DrawString("Items / Services:", subHeaderFont, Brushes.Black, leftMargin, y); y += lineHeight;
            foreach (var detail in currentPayment.TransactionDetails)
            {
                string line = $"{detail.Description} x{detail.Quantity} @ {detail.Price:C}";
                g.DrawString(line, contentFont, Brushes.Black, leftMargin, y); y += lineHeight;
            }

            y += lineHeight;

            // Payment Breakdown
            g.DrawString("Payment Details:", subHeaderFont, Brushes.Black, leftMargin, y); y += lineHeight;

            foreach (var pd in currentPayment.PaymentDetails)
            {
                string line = $"{pd.Mode} | Ref: {pd.ReferenceNumber} | Amount: {pd.Amount:C}";
                g.DrawString(line, contentFont, Brushes.Black, leftMargin, y); y += lineHeight;
            }

            y += lineHeight;

            // Total and Change
            g.DrawString($"Total: {currentPayment.TotalAmount:C}", subHeaderFont, Brushes.Black, leftMargin, y); y += lineHeight;
            g.DrawString($"Change: {currentPayment.ChangeAmount:C}", subHeaderFont, Brushes.Black, leftMargin, y); y += lineHeight * 2;

            // Footer
            g.DrawString("Thank you for trusting Sahagun Veterinary Clinic!", contentFont, Brushes.Black, leftMargin, y); y += lineHeight;

        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {

        }

        
    }
}

