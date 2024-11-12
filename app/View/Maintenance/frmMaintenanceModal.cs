using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;



namespace app.view.Maintenance
{
    public partial class frmMaintenanceModal : Form
    {
        private string backupFolder = @"C:\Users\Lyka\Desktop\System SS";
        private string mysqlDumpPath = @"C:\xampp\mysql\bin\mysqldump";
        private string mysqlPath = @"C:\xampp\mysql\bin";
        public frmMaintenanceModal()
        {
            InitializeComponent();
        }



        private void btnBackUp_Click(object sender, EventArgs e)
        {
            // Confirm with the user that they want to create a backup of the database
            if (MessageBox.Show("Are you sure you want to create a backup of the database?", "Backup Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Step 1: Allow the user to choose the file path for the dump file
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.Filter = "SQL Dump Files (*.sql)|*.sql";
                    saveFileDialog.Title = "Select Backup Destination";
                    saveFileDialog.InitialDirectory = backupFolder;
                    saveFileDialog.FileName = "dump_backup.sql";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string backupFilePath = saveFileDialog.FileName;

                        // Run mysqldump command to create the backup
                        string arguments = $"--user={"root"} --password={""} --host={"localhost"} {"vcms"} -r \"{backupFilePath}\"";

                        Process process = new Process();
                        process.StartInfo.FileName = mysqlDumpPath;
                        process.StartInfo.Arguments = arguments;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;

                        try
                        {
                            process.Start();

                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            if (process.ExitCode == 0)
                            {
                                MessageBox.Show("Backup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Backup failed. Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            // Define the folder where the original file should be restored
            string restoreFolder = @"C:\Users\Lyka\Desktop\System SS"; 
            string defaultFileName = "dump.sql";

            // Open OpenFileDialog to allow the user to select the backup file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Dump Files (*.sql)|*.sql"; 
                openFileDialog.Title = "Select Backup File to Restore";
                openFileDialog.InitialDirectory = @"C:\Users\Lyka\Desktop\System SS"; 

                // If the user selects a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = openFileDialog.FileName;

                    
                    string restoreFilePath = Path.Combine(restoreFolder, defaultFileName);

                    // Check if the backup file exists before proceeding
                    if (!File.Exists(backupFilePath))
                    {
                        MessageBox.Show("The backup file does not exist. Please check the file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        if (!Directory.Exists(restoreFolder))
                        {
                            MessageBox.Show("The restore folder does not exist. Please check the folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        File.Copy(backupFilePath, restoreFilePath, overwrite: true);

                       
                        MessageBox.Show("Restore successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Restore failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Restore action canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}



