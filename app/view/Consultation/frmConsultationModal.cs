using app.core.model;
using app.core.repository;
using app.Properties;
using app.view.Utilities;
using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace app.view.Consultation
{
    public partial class frmConsultationModal : Form
    {
        private ConsultationRepository consultationRepo = new ConsultationRepository();
        private Diagnosis currentDiagnosis = new Diagnosis();
        private int patientId;
        private List<MedicationWithFrequency> selectedMedications = new List<MedicationWithFrequency>();
        private PrintDocument printPrescriptionDoc;



        public frmConsultationModal(int selectedId)
        {
            InitializeComponent();
            InitializeControls();
            dtConsult.Enabled = false;
        }

        public frmConsultationModal()
        {
            InitializeComponent();
            InitializeControls();
            this.Load += frmConsultationModal_Load;
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private void frmConsultationModal_Load(object sender, EventArgs e)
        {
            cboFollowUp.Items.AddRange(new string[]
            {
                "No follow-up",
                "After 1 week",
                "After 2 weeks",
                "After 1 month"
             });

            cboFollowUp.SelectedIndex = 0;
            dtConsult.Value = DateTime.Now; // Set to current date/time
            //LoadMedicines();
        }
        private void InitializeControls()
        {
            // Enable multiline text for cells
            dgvMedication.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Adjust row height automatically to fit wrapped text
            dgvMedication.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Setup DataGridView columns
            dgvMedication.Columns.Clear();

            dgvMedication.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Medicine",
                HeaderText = "Medicine",
                ReadOnly = true,
                Width = 300,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True  // ✅ Enable word wrap just for this column
                }
            });

            dgvMedication.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Frequency",
                HeaderText = "Frequency",
                ReadOnly = true,
                Width = 150
            });

            dgvMedication.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DaysIntake",
                HeaderText = "Days Intake",
                ReadOnly = false,
                Width = 150
            });

            dgvMedication.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Notes",
                HeaderText = "Notes",
                ReadOnly = false,
                Width = 150
            });

            // General grid settings
            dgvMedication.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            dgvMedication.AllowUserToAddRows = false;
            dgvMedication.AllowUserToResizeColumns = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Step 2: Validate patient selection
            if (patientId == 0)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            // Step 1: Determine follow-up date based on selection
            DateTime? followUpDate = null;

            if (cboFollowUp.SelectedItem != null && cboFollowUp.SelectedItem.ToString() != "No follow-up")
            {
                switch (cboFollowUp.SelectedItem.ToString())
                {
                    case "After 1 week":
                        followUpDate = dtConsult.Value.AddDays(7);
                        break;
                    case "After 2 weeks":
                        followUpDate = dtConsult.Value.AddDays(14);
                        break;
                    case "After 1 month":
                        followUpDate = dtConsult.Value.AddMonths(1);
                        break;
                }
            }

            // Step 3: Create Diagnosis object
            var diag = new Diagnosis
            {
                Id = 0,
                Patient = patientId,
                Weight = txtWeight.Text.Trim(),
                BloodPressure = txtBlood.Text.Trim(),
                HeartRate = txtHeart.Text.Trim(),
                Temperature = txtTemperature.Text.Trim(),
                Complaint = txtComplaint.Text.Trim(),
                Findings = txtFindings.Text.Trim(),
                PlanTreatment = txtTreatment.Text.Trim(),
                ConsultDate = dtConsult.Value,
                MedicationsWithFrequency = new List<MedicationWithFrequency>(selectedMedications),
                FollowUpDate = followUpDate
            };

            // Step 4: Save to repository
            bool result = consultationRepo.Save(diag);
            if (result)
            {
                MessageBox.Show("Consultation saved successfully.");

                ShowPrescriptionPreview(); // 👉 Call this method
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save consultation.");
            }

        }

        private void btnSelectAPatient_Click(object sender, EventArgs e)
        {
            using (var cpf = new frmClientPatientForm())
            {
                if (cpf.ShowDialog() == DialogResult.OK)
                {
                    var patient = cpf.GetPatientDetails();
                    patientId = patient.Id;
                    txtPetName.Text = patient.Name;
                    txtAge.Text = patient.Age;
                    txtType.Text = patient.Specie.Description;
                    txtOwnerName.Text = patient.Client.GetFullName();
                    txtBreed.Text = patient.Breed.Description;
                    txtBirthday.Text = Convert.ToDateTime(patient.BirthDate).ToString("yyyy-MM-dd");
                    txtColor.Text = patient.ColourPattern.Description;

                    
                }
            }
            txtBlood.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        //private void btnAddMedication_Click(object sender, EventArgs e)
        //{
        //    if (dgvMedication.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Please select a medicine row to update.");
        //        return;
        //    }

        //    string frequency = cmbFrequency.SelectedItem?.ToString() ?? "";
        //    string notes = txtOther.Text.Trim();

        //    if (string.IsNullOrWhiteSpace(frequency))
        //    {
        //        MessageBox.Show("Please select a frequency.");
        //        return;
        //    }

        //    var row = dgvMedication.SelectedRows[0];
        //    row.Cells["Frequency"].Value = frequency;
        //    row.Cells["Notes"].Value = notes;

        //    // Update your model if needed
        //    string medDesc = row.Cells["Medicine"].Value?.ToString();
        //    var med = selectedMedications.FirstOrDefault(m => m.MedicineDescription == medDesc);
        //    if (med != null)
        //    {
        //        med.Frequency = frequency;
        //        med.Notes = notes;
        //    }

        //    txtOther.Clear();
        //}

        private void frmConsultationModal_Load_1(object sender, EventArgs e)
        {
            txtWeight.TextChanged += TextBox_CapitalizeFirstLetter;
            txtTemperature.TextChanged += TextBox_CapitalizeFirstLetter;
            txtComplaint.TextChanged += TextBox_CapitalizeFirstLetter;
            txtFindings.TextChanged += TextBox_CapitalizeFirstLetter;
            txtTreatment.TextChanged += TextBox_CapitalizeFirstLetter;
        }

        private void TextBox_CapitalizeFirstLetter(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            int selStart = tb.SelectionStart;
            int selLength = tb.SelectionLength;

            string oldText = tb.Text;
            string newText = CapitalizeFirstLetter(oldText);

            if (oldText != newText)
            {
                tb.Text = newText;
                // Restore the cursor position
                tb.SelectionStart = selStart;
                tb.SelectionLength = selLength;
            }
        }

        private void txtBlood_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '/')
            {
                e.Handled = true; // Reject other characters
            }

            // Optional: Only allow one slash
            if (e.KeyChar == '/' && (sender as TextBox).Text.Contains("/"))
            {
                e.Handled = true;
            }
        }

        private void txtHeart_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Reject the input
            }
        }

        private void txtTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
            !char.IsDigit(e.KeyChar) &&
            e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }

        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            frmMedicines medForm = new frmMedicines();

            if (medForm.ShowDialog() == DialogResult.OK)
            {
                foreach (var med in medForm.SelectedMedicines)
                {
                    bool exists = dgvMedication.Rows
                        .Cast<DataGridViewRow>()
                        .Any(row => row.Cells["Medicine"].Value?.ToString() == med.MedicineDescription &&
                                    row.Cells["Frequency"].Value?.ToString() == med.Frequency &&
                                    row.Cells["DaysIntake"].Value?.ToString() == med.DaysIntake);

                    if (!exists)
                    {
                        dgvMedication.Rows.Add(
                            med.MedicineDescription,
                            med.Frequency,
                            med.DaysIntake,
                            med.Notes
                        );
                        selectedMedications.Add(med);
                    }
                }

            }
        }
        private void ShowPrescriptionPreview()
        {
            printPrescriptionDoc = new PrintDocument();
            printPrescriptionDoc.PrintPage += printDocument1_PrintPage;
            printPrescriptionDoc.DefaultPageSettings.Landscape = false;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printPrescriptionDoc,
                Width = 800,
                Height = 600
            };

            previewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float y = 50f;
            float xMargin = 50f;
            float pageWidth = e.PageBounds.Width;

            // Fonts and brush
            Font titleFont = new Font("Century Gothic", 14, FontStyle.Bold);
            Font headerFont = new Font("Century Gothic", 12, FontStyle.Bold);
            Font regularFont = new Font("Century Gothic", 10);
            Font boldFont = new Font("Century Gothic", 10, FontStyle.Bold);
            Brush black = Brushes.Black;

            // Draw Logo
            try
            {
                Image logo = Resources.logo5;
                int logoW = 300, logoH = 100;
                float logoX = (pageWidth - logoW) / 2;
                g.DrawImage(logo, new Rectangle((int)logoX, (int)y, logoW, logoH));
                y += logoH + 10;
            }
            catch { y += 20; }

            // Clinic Info
            DrawCentered(g, " SAHAGUN VETERINARY CLINIC ", titleFont, black, ref y, pageWidth);
            DrawCentered(g, "6418 Zapote St., Area D Camarin, Caloocan City", regularFont, black, ref y, pageWidth);
            DrawCentered(g, "(02) 990-7151", regularFont, black, ref y, pageWidth);
            y += 20;

            // Date (right-aligned)
            string consultDate = dtConsult.Value.ToString("MMMM dd, yyyy");
            string dateText = $"Date: {consultDate}";
            float dateWidth = g.MeasureString(dateText, regularFont).Width;
            g.DrawString(dateText, regularFont, black, pageWidth - dateWidth - xMargin, y);
            y += 30;

            // Patient Info
            DrawLabelPair(g, "Patient Name:", txtPetName.Text.Trim(), boldFont, regularFont, xMargin, ref y);
            DrawLabelPair(g, "Breed:", txtBreed.Text.Trim(), boldFont, regularFont, xMargin, ref y);
            DrawLabelPair(g, "Species:", txtType.Text.Trim(), boldFont, regularFont, xMargin, ref y);
            DrawLabelPair(g, "Weight (kg):", txtWeight.Text.Trim(), boldFont, regularFont, xMargin, ref y);
            y += 10;

            // ℞ Symbol (centered on left, meds below)
            Font rxFont = new Font("Century Gothic", 50, FontStyle.Bold);
            float rxX = xMargin;
            float rxY = y;

            g.DrawString("℞", rxFont, black, rxX, rxY);

            // Move y below Rx symbol
            y += g.MeasureString("℞", rxFont).Height + 10f;

            // Medication list (start below ℞)
            int index = 1;
            foreach (var med in selectedMedications)
            {
                g.DrawString($"{index++}. {med.MedicineDescription}", boldFont, black, xMargin, y);
                y += 18;
                g.DrawString($"Sig: {med.Frequency} | Duration: {med.DaysIntake} |  Time: {med.Notes}", regularFont, black, xMargin + 20, y);
                y += 25;
            }


            // Doctor Signature (Right aligned)
            string docName = "MA. JENA LORMAINE ESTRELLA D.C.";
            string license = "License No. 8915";
            string ptr = "PTR No. 5510582";

            float docNameWidth = g.MeasureString(docName, boldFont).Width;
            float licenseWidth = g.MeasureString(license, regularFont).Width;
            float ptrWidth = g.MeasureString(ptr, regularFont).Width;

            float docX = pageWidth - docNameWidth - xMargin;
            float licenseX = pageWidth - licenseWidth - xMargin;
            float ptrX = pageWidth - ptrWidth - xMargin;

            y += 20;
            g.DrawString(docName, boldFont, black, docX, y);
            y += 18;
            g.DrawString(license, regularFont, black, licenseX, y);
            y += 18;
            g.DrawString(ptr, regularFont, black, ptrX, y);
            y += 30;

            // Optional Remarks
            //if (!string.IsNullOrWhiteSpace(txtRemarks.Text))
            //{
            //    g.DrawString("Remarks:", boldFont, black, xMargin, y);
            //    y += 18;
            //    g.DrawString(txtRemarks.Text, regularFont, black, xMargin + 20, y);
            //}
        }
        private void DrawCentered(Graphics g, string text, Font font, Brush brush, ref float y, float pageWidth)
        {
            float x = (pageWidth - g.MeasureString(text, font).Width) / 2;
            g.DrawString(text, font, brush, x, y);
            y += font.GetHeight(g) + 5;
        }

        private void DrawLabelPair(Graphics g, string label, string value, Font labelFont, Font valueFont, float x, ref float y)
        {
            float labelWidth = g.MeasureString(label, labelFont).Width;
            g.DrawString(label, labelFont, Brushes.Black, x, y);
            g.DrawString(value, valueFont, Brushes.Black, x + labelWidth + 5, y);
            y += valueFont.GetHeight(g) + 2;
        }

    }
    }
