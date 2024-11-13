using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MySqlConnector;



namespace app.view.Maintenance
{
    public partial class frmMaintenanceModal : Form
    {
        private string backupFolder = @"C:\BackupDatabase";
        private string mysqlDumpPath = @"C:\xampp\mysql\bin\mysqldump";
        
        public frmMaintenanceModal()
        {
            InitializeComponent();
        }



        private void btnBackUp_Click(object sender, EventArgs e)
        {
            // Check if the backup folder exists, if not, create it
            if (!Directory.Exists(backupFolder))
            {
                DialogResult createFolderResult = MessageBox.Show(
                    $"The backup folder '{backupFolder}' does not exist. Do you want to create it?",
                    "Create Backup Folder",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (createFolderResult == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(backupFolder);
                        MessageBox.Show("Backup folder created successfully.", "Folder Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while creating the folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }
                }
                else
                {
                    return;
                }
            }
            if (MessageBox.Show("Are you sure you want to create a backup of the database?", "Backup Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.Filter = "SQL Dump Files (*.sql)|*.sql";
                    saveFileDialog.Title = "Select Backup Destination";
                    saveFileDialog.InitialDirectory = backupFolder; 

                    
                    string defaultFileName = $"dump_{DateTime.Now:yyyyMMdd}.sql";
                    saveFileDialog.FileName = defaultFileName;

                    
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string backupFilePath = saveFileDialog.FileName;

                       
                        string arguments = $"--user=root --password= --host=localhost vcms -r \"{backupFilePath}\"";

                        try
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = mysqlDumpPath;
                            process.StartInfo.Arguments = arguments;
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.RedirectStandardError = true;

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

