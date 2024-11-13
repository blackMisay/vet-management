using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MySqlConnector;



namespace app.view.Maintenance
{
    public partial class frmMaintenanceModal : Form
    {
        private string backupFolder = @"C:\Users\Lyka\Desktop\System SS";
        private string mysqlDumpPath = @"C:\xampp\mysql\bin\mysqldump";
        
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
                    saveFileDialog.InitialDirectory = backupFolder; // Default to the backup folder

                    // Generate a default file name with the current date and time
                    string defaultFileName = $"dump_{DateTime.Now:yyyyMMdd}.sql";
                    saveFileDialog.FileName = defaultFileName; // Set the default file name with date

                    // Show dialog and get the selected file path
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string backupFilePath = saveFileDialog.FileName;

                        // Run mysqldump command to create the backup
                        string arguments = $"--user=root --password= --host=localhost vcms -r \"{backupFilePath}\"";

                        try
                        {
                            // Process to execute mysqldump
                            Process process = new Process();
                            process.StartInfo.FileName = mysqlDumpPath; // Use the path to mysqldump
                            process.StartInfo.Arguments = arguments; // Pass arguments for backup
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.RedirectStandardError = true;

                            process.Start();

                            // Capture the output and error
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            // Check the result of the mysqldump process
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
            string mysqlPath = @"C:\xampp\mysql\bin\mysql.exe";

            // Confirm with the user that they want to restore the database from a backup
            if (MessageBox.Show("Are you sure you want to restore the database from a backup?", "Restore Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Step 1: Allow the user to choose the file path of the dump file to restore from
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "SQL Dump Files (*.sql)|*.sql";
                    openFileDialog.Title = "Select Backup File to Restore";
                    openFileDialog.InitialDirectory = backupFolder; // Default to the backup folder

                    // Show dialog and get the selected file path
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string backupFilePath = openFileDialog.FileName;

                        // Set arguments without input redirection
                        string arguments = $"--user=root --password= --host=localhost vcms";

                        try
                        {
                            // Process to execute mysql restore
                            Process process = new Process();
                            process.StartInfo.FileName = mysqlPath; // Use the path to mysql
                            process.StartInfo.Arguments = arguments; // Pass arguments for restore
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.RedirectStandardInput = true;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.RedirectStandardError = true;

                            process.Start();

                            // Write the SQL file content directly to StandardInput
                            using (StreamReader fileStream = new StreamReader(backupFilePath))
                            {
                                process.StandardInput.Write(fileStream.ReadToEnd());
                            }
                            process.StandardInput.Close();

                            // Capture the output and error
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            // Check the result of the mysql process
                            if (process.ExitCode == 0)
                            {
                                MessageBox.Show("Restore successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Restore failed. Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
    }

