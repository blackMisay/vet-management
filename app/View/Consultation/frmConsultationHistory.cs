using app.core.repository;
using app.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Consultation
{
    public partial class frmConsultationHistory : Form
    {
        private readonly ConsultationRepository repo = new ConsultationRepository();
        private int selectedOwnerId = 0;
        private int selectedPetId = 0;

        private Dictionary<int, app.core.model.Diagnosis> selectedDiagnosis;

        public frmConsultationHistory(Dictionary<int, app.core.model.Diagnosis> diagnosis)
        {
            InitializeComponent();

            selectedDiagnosis = new Dictionary<int, app.core.model.Diagnosis>();
            selectedDiagnosis = diagnosis;
        }

        public Dictionary<int, app.core.model.Diagnosis> GetAllDiagnosis()
        {
            return selectedDiagnosis;
        }

        public frmConsultationHistory()
        {
            InitializeComponent();

            this.Load += frmOwnerConsultationExplorer_Load;
            this.dgvOwners.CellClick += dgvOwners_CellClick;
            this.dgvPets.CellClick += dgvPets_CellClick;
        }

        private void frmOwnerConsultationExplorer_Load(object sender, EventArgs e)
        {
            dgvOwners.DataSource = repo.GetUniqueOwnersWithConsultations();
            SetupConsultationGrid(); // Initialize consultation grid structure
        }

        private void dgvOwners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedOwnerId = Convert.ToInt32(dgvOwners.Rows[e.RowIndex].Cells["owner_id"].Value);
            dgvPets.DataSource = repo.GetPetsByOwner(selectedOwnerId, selectedPetId);


            // Clear consultation data when owner changes
            dgvConsultation.DataSource = null;
            selectedPetId = 0;
        }

        private void dgvPets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || selectedOwnerId == 0) return;

            selectedPetId = Convert.ToInt32(dgvPets.Rows[e.RowIndex].Cells["pet_id"].Value);
            dgvConsultation.DataSource = repo.GetConsultationHistoryByOwnerAndPet(selectedOwnerId, selectedPetId);
        }

        private void SetupConsultationGrid()
        {
            dgvConsultation.AutoGenerateColumns = false;
            dgvConsultation.Columns.Clear();

            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "weight",
                HeaderText = "Weight",
                DataPropertyName = "weight",
                Width = 100
            });
            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "temperature",
                HeaderText = "Temperature",
                DataPropertyName = "temperature",
                Width = 100
            });
            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "blood_pressure",
                HeaderText = "Blood Pressure",
                DataPropertyName = "blood_pressure",
                Width = 135
            });
            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "heart_rate",
                HeaderText = "Heart Rate",
                DataPropertyName = "heart_rate",
                Width = 135
            });
            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "complaint",
                HeaderText = "Complaint",
                DataPropertyName = "complaint",
                Width = 250
            });

            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "findings",
                HeaderText = "Findings",
                DataPropertyName = "findings",
                Width = 200
            });

            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "treatment",
                HeaderText = "Treatment",
                DataPropertyName = "plantreatment",
                Width = 200
            });

            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "medications",
                HeaderText = "Medication",
                DataPropertyName = "medications",
                Width = 300
            });

            dgvConsultation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "consultation_date",
                HeaderText = "Consult Date",
                DataPropertyName = "consult_date",
                Width = 150
            });


            // Add other columns if needed
        }


        private DataTable consultationHistory;
        private int currentPageIndex;
        private string[] pages;
        private DataTable currentPrintData;
        private int currentPrintRow = 0;  // To keep track of which row we're printing across pages



        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Fonts and layout settings
            Font headerFont = new Font("Century Gothic", 14, FontStyle.Bold);
            Font subHeaderFont = new Font("Century Gothic", 10, FontStyle.Bold);
            Font bodyFont = new Font("Century Gothic", 10);

            int lineHeight = bodyFont.Height + 4;
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int yPos = topMargin;

            // Print report title
            e.Graphics.DrawString("Pet Consultation History Report", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight * 2;

            string printDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            e.Graphics.DrawString($"Report generated: {printDateTime}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight * 2;

            // Print owner & pet info
            if (currentPrintData.Rows.Count > 0)
            {
                var firstRow = currentPrintData.Rows[0];
                string owner = firstRow["owner_name"].ToString();
                string pet = firstRow["pet_name"].ToString();
                string weight = firstRow["weight"].ToString();
                string temperature = firstRow["temperature"].ToString();
                string pressure = firstRow["blood_pressure"].ToString();
                string heart = firstRow["heart_rate"].ToString();

                e.Graphics.DrawString($"Owner Name: {owner}", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;
                e.Graphics.DrawString($"Pet Name: {pet}", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;
                e.Graphics.DrawString($"Weight: {weight} kg", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;
                e.Graphics.DrawString($"Temperature: {temperature} °C", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;
                e.Graphics.DrawString($"Blood Pressure: {pressure} bpm", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;
                e.Graphics.DrawString($"Blood Rate: {heart} mmHg", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight * 2;
            }


            // Column positions (landscape)
            int colConsultDateX = leftMargin;
            int colComplaintX = leftMargin + 100;
            int colFindingsX = leftMargin + 300;
            int colMedicationsX = leftMargin + 500;

            int complaintWidth = colFindingsX - colComplaintX - 10;
            int findingsWidth = colMedicationsX - colFindingsX - 10;
            int medicationsWidth = e.MarginBounds.Right - colMedicationsX - 10;

            // Column headers
            e.Graphics.DrawString("Date", subHeaderFont, Brushes.Black, colConsultDateX, yPos);
            e.Graphics.DrawString("Complaint", subHeaderFont, Brushes.Black, colComplaintX, yPos);
            e.Graphics.DrawString("Findings", subHeaderFont, Brushes.Black, colFindingsX, yPos);
            e.Graphics.DrawString("Medications", subHeaderFont, Brushes.Black, colMedicationsX, yPos);
            yPos += lineHeight;

            // Underline
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 4;

            // Print rows
            while (currentPrintRow < currentPrintData.Rows.Count)
            {
                DataRow row = currentPrintData.Rows[currentPrintRow];

                string consultDate = Convert.ToDateTime(row["consult_date"]).ToString("yyyy-MM-dd");
                string complaint = row["complaint"].ToString();
                string findings = row["findings"].ToString();
                string medications = row["medications"].ToString();

                var wrappedComplaint = WrapText(e.Graphics, complaint, bodyFont, complaintWidth);
                var wrappedFindings = WrapText(e.Graphics, findings, bodyFont, findingsWidth);
                var wrappedMedications = WrapText(e.Graphics, medications, bodyFont, medicationsWidth);

                int maxLines = Math.Max(wrappedComplaint.Count, Math.Max(wrappedFindings.Count, wrappedMedications.Count));
                int rowHeight = Math.Max(lineHeight * 2, lineHeight * maxLines);

                if (yPos + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                // Draw columns
                e.Graphics.DrawString(consultDate, bodyFont, Brushes.Black, colConsultDateX, yPos);

                for (int i = 0; i < maxLines; i++)
                {
                    if (i < wrappedComplaint.Count)
                        e.Graphics.DrawString(wrappedComplaint[i], bodyFont, Brushes.Black, colComplaintX, yPos + (i * lineHeight));
                    if (i < wrappedFindings.Count)
                        e.Graphics.DrawString(wrappedFindings[i], bodyFont, Brushes.Black, colFindingsX, yPos + (i * lineHeight));
                    if (i < wrappedMedications.Count)
                        e.Graphics.DrawString(wrappedMedications[i], bodyFont, Brushes.Black, colMedicationsX, yPos + (i * lineHeight));
                }

                yPos += rowHeight;
                currentPrintRow++;
            }

            e.HasMorePages = false;
        }

        private List<string> WrapText(Graphics graphics, string text, Font font, int maxWidth)
        {
            List<string> lines = new List<string>();
            string[] words = text.Split(' ');
            string currentLine = "";

            foreach (string word in words)
            {
                string testLine = string.IsNullOrEmpty(currentLine) ? word : currentLine + " " + word;
                SizeF size = graphics.MeasureString(testLine, font);
                if (size.Width > maxWidth)
                {
                    lines.Add(currentLine);
                    currentLine = word;
                }
                else
                {
                    currentLine = testLine;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
                lines.Add(currentLine);

            return lines;
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Load your data into currentPrintData before printing
            currentPrintData = LoadConsultationData(); // Replace with your actual data source

            if (currentPrintData == null || currentPrintData.Rows.Count == 0)
            {
                MessageBox.Show("No consultation data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            currentPrintRow = 0;

            printDocument1.DefaultPageSettings.Landscape = true;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;
            previewDialog.WindowState = FormWindowState.Maximized;
            previewDialog.ShowDialog();
        }

        private DataTable LoadConsultationData()
        {
            var repo = new ConsultationRepository();
            return repo.GetConsultationHistoryByOwnerAndPet(selectedOwnerId, selectedPetId);
        }


    }
}
