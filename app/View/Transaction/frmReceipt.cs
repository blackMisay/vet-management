using app.core.model;
using app.core.repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace app.view.Transaction
{
    public partial class frmReceipt : Form
    {
        private TransactionPayment _payment;
        private List<TransactionDetail> _lines = new List<TransactionDetail>();
        private PrintDocument _printDoc;
        private int _currentLine = 0;
        private List<PaymentDetail> _paymentDetails;

        public frmReceipt(TransactionPayment payment, List<PaymentDetail> paymentDetails)
        {
            InitializeComponent();

            _payment = payment;
            _paymentDetails = paymentDetails;

            _lines = payment.TransactionDetails
                .Select(d => new TransactionDetail
                {
                    Id = d.ProductId,
                    Description = d.Description,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    TotalAmount = d.TotalAmount
                }).ToList();

            // Assign amounts from _paymentDetails
            _payment.GCash = 0;
            _payment.PayMaya = 0;
            _payment.Cash = 0;

            if (_paymentDetails != null)
            {
                foreach (var pd in _paymentDetails)
                {
                    switch (pd.Mode.ToLower())
                    {
                        case "gcash":
                            _payment.GCash += pd.Amount;
                            break;
                        case "paymaya":
                            _payment.PayMaya += pd.Amount;
                            break;
                        case "cash":
                            _payment.Cash += pd.Amount;
                            break;
                    }
                }
            }

            _printDoc = new PrintDocument();
            _printDoc.PrintPage += PrintDocument_PrintPage;

            foreach (PaperSize ps in _printDoc.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName.Equals("Letter", StringComparison.OrdinalIgnoreCase))
                {
                    _printDoc.DefaultPageSettings.PaperSize = ps;
                    break;
                }
            }

            _printDoc.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

        }

        public void ShowPreview()
        {
            using (PrintPreviewDialog dlg = new PrintPreviewDialog())
            {
                dlg.Document = _printDoc;
                dlg.Width = 800;
                dlg.Height = 600;
                dlg.ShowDialog();
            }
        }
           private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float pageWidth = e.MarginBounds.Width;

            Font headerFont = new Font("Century Gothic", 14, FontStyle.Bold);
            Font titleFont = new Font("Century Gothic", 22, FontStyle.Bold);
            Font boldFont = new Font("Century Gothic", 11, FontStyle.Bold);
            Font regFont = new Font("Century Gothic", 10);
            Font italicFont = new Font("Century Gothic", 9, FontStyle.Italic);
            Brush black = Brushes.Black;

            float lineHeight = regFont.GetHeight(g) + 6;

            StringFormat leftAlign = new StringFormat() { Alignment = StringAlignment.Near };
            StringFormat rightAlign = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat centerAlign = new StringFormat() { Alignment = StringAlignment.Center };

            void DrawAligned(string text, Font font, float dx, float dy, float width, StringFormat align, Brush brush = null)
            {
                RectangleF rect = new RectangleF(dx, dy, width, lineHeight);
                g.DrawString(text, font, brush ?? black, rect, align);
            }

            // === Adjusted Column Widths ===
            float colItemWidth = pageWidth * 0.45f;
            float colQtyWidth = pageWidth * 0.15f;
            float colUnitWidth = pageWidth * 0.15f;
            float colAmountWidth = pageWidth * 0.25f;

            float colItemX = x;
            float colQtyX = colItemX + colItemWidth;
            float colUnitX = colQtyX + colQtyWidth;
            float colAmountX = colUnitX + colUnitWidth;

            // === Header Info (Left) ===
            DrawAligned("SAHAGUN", headerFont, x, y, pageWidth, leftAlign); y += headerFont.GetHeight(g);
            DrawAligned("Veterinary Clinic", regFont, x, y, pageWidth, leftAlign); y += lineHeight;
            DrawAligned("6418 Zapote St. Area D.,", regFont, x, y, pageWidth, leftAlign); y += lineHeight;
            DrawAligned("Camarin Caloocan City, Philippines", regFont, x, y, pageWidth, leftAlign); y += lineHeight;
            DrawAligned("Email: sahagunveterinaryclinic@yahoo.com", regFont, x, y, pageWidth, leftAlign); y += lineHeight;
            DrawAligned("Phone: 990-7151", regFont, x, y, pageWidth, leftAlign); y += lineHeight + 30;

           

            // === Invoice Info Box (Right) - moved AFTER the title to avoid overlap ===
            float boxWidth = 230;
            float boxX = x + pageWidth - boxWidth;
            float boxY = y - titleFont.GetHeight(g) - 45; // Position above title
            g.FillRectangle(Brushes.LightGreen, boxX, boxY, boxWidth, 25);
            DrawAligned("Paid", boldFont, boxX + 10, boxY, boxWidth, leftAlign);
            boxY += 50;
            DrawAligned($"Invoice ID: {_payment.InvoiceNumber}", regFont, boxX, boxY, boxWidth, leftAlign); boxY += lineHeight;
            DrawAligned($"Invoice Date: {_payment.Date:dd MMMM yyyy}", regFont, boxX, boxY, boxWidth, leftAlign); boxY += lineHeight;
            DrawAligned($"Due Date: {_payment.Date:dd MMMM yyyy}", regFont, boxX, boxY, boxWidth, leftAlign); boxY += lineHeight;
            DrawAligned("Location: Vetcore", regFont, boxX, boxY, boxWidth, leftAlign);


            // === Title: Official Receipt ===
            // Add vertical space before title
            y += 20;
            DrawAligned("OFFICIAL RECEIPT", titleFont, x, y, pageWidth, centerAlign);
            y += titleFont.GetHeight(g) + 10; // Add extra space after title



            // === Client Info ===
            DrawAligned($"Invoice to: {_payment.Client.FirstName} {_payment.Client.LastName}", boldFont, x, y, pageWidth, leftAlign); y += lineHeight + 10;

            // === Table Headers ===
            DrawAligned("Item name", boldFont, colItemX, y, colItemWidth, leftAlign);
            DrawAligned("Qty", boldFont, colQtyX, y, colQtyWidth, centerAlign);
            DrawAligned("Unit Price (₱)", boldFont, colUnitX, y, colUnitWidth, rightAlign);
            DrawAligned("Amount (₱)", boldFont, colAmountX, y, colAmountWidth, rightAlign);
            y += lineHeight;

            // === Table Items ===
            foreach (var item in _lines)
            {
                string desc = item.Description.Length > 60 ? item.Description.Substring(0, 60) + "..." : item.Description;
                DrawAligned(desc, regFont, colItemX, y, colItemWidth, leftAlign);
                DrawAligned(item.Quantity.ToString(), regFont, colQtyX, y, colQtyWidth, centerAlign);
                DrawAligned(item.UnitPrice.ToString("N2"), regFont, colUnitX, y, colUnitWidth, rightAlign);
                DrawAligned(item.TotalAmount.ToString("N2"), regFont, colAmountX, y, colAmountWidth, rightAlign);
                y += lineHeight;

                if (y > e.MarginBounds.Bottom - 200)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            y += 10;

            // === Totals ===
            float labelX = colAmountX - 110;
            void DrawSummary(string label, double value)
            {
                DrawAligned(label, regFont, labelX, y, 100, leftAlign);
                DrawAligned(value.ToString("N2"), regFont, colAmountX, y, colAmountWidth, rightAlign);
                y += lineHeight;
            }

            DrawSummary("Subtotal", _payment.TotalAmount);
            DrawSummary("Total", _payment.TotalAmount);
            DrawSummary("Less Amount", -_payment.TotalAmount);
            DrawSummary("Change", -_payment.ChangeAmount);
            y += lineHeight + 20;

            // === Payment Section ===
            DrawAligned("Payment", boldFont, x, y, pageWidth, leftAlign); y += lineHeight;
            DrawAligned("For GCASH payments, please use the following details:", regFont, x, y, pageWidth, leftAlign); y += lineHeight;
            DrawAligned("Account name: PHILMER S.", regFont, x, y, pageWidth, leftAlign); y += lineHeight;
            DrawAligned("Account number: 09171374112", regFont, x, y, pageWidth, leftAlign); y += lineHeight;
            DrawAligned("**When paying by gcash, please quote your invoice ID as the reference.", italicFont, x, y, pageWidth, leftAlign); y += lineHeight + 10;
            DrawAligned("Thanks for visiting SAHAGUN VETERINARY CLINIC!", regFont, x, y, pageWidth, leftAlign);

            e.HasMorePages = false;

        }


        private void frmReceipt_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}

