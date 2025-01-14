using app.core.model;
using System;
using System.Collections.Generic;
using System.Data;
using Core;
using System.Windows.Forms;
using app.view.Inventory;
using System.Linq;

namespace app.core.Repository
{
    internal class InventoryRepository
    {
        int inventoryId;
        UpgradeFile upgradeFile;

        public DataTable SearchInventory(string searchValue)
        {
            string query = "SELECT * FROM vwinventory WHERE `stocksNum` LIKE @searchValue OR `description` LIKE @searchValue OR `prodDesc` LIKE @searchValue;";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"@searchValue", "%" + searchValue + "%" }
            };
            UpgradeFile upgradeFile = new UpgradeFile();
            return upgradeFile.Load(query, parameters);
        }

        public bool SaveInventory(Inventory inventory)
        {
            string sql;

            bool saveState = inventory.Id > 0 ? true : false;

            if (saveState)
            {
                sql = "UPDATE prod_stocks SET batchNum=@BatchNumber, description=@Description, typeID=@TypeID, categID=@CategID, brandID=@BrandID, qty=@Qty,dateReceived=@DateReceived, expDate=@ExpiredDate WHERE stockID=@Id;";
            }
            else
            {
                sql = "INSERT INTO prod_stocks (stockID,batchNum,description,typeID,categID,brandID,qty,dateReceived,expDate) VALUES(@Id,@BatchNumber,@Description,@TypeID,@CategID,@BrandID,@Qty,@DateReceived,@ExpiredDate);";
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(inventory.Id)},
                {"@BatchNumber", inventory.BatchNumber},
                {"@Description", inventory.Description},
                {"@TypeID", inventory.TypeID.Id.ToString()},
                {"@CategID", inventory.CategID.Id.ToString()},
                {"@BrandID", inventory.BrandID.Id.ToString()},
                {"@Qty", Convert.ToString(inventory.Qty)},
                {"@DateReceived", inventory.DateReceived.ToString("yyyy-MM-dd")},
                {"@ExpiredDate", inventory.ExpiredDate.ToString("yyyy-MM-dd")}
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;

        }
        public bool DeleteInventory(int inventory)
        {
            string sql = "UPDATE prod_stocks SET isDeleted = '1' WHERE stockID=@Id;";

            UpgradeFile upgrade = new UpgradeFile();
            Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@Id", inventory.ToString() }
                };
            return upgrade.ExecuteQuery(sql, parameters);
        }
        public Inventory GetInventory(Inventory inventory)
        {
            string query = "SELECT * FROM prod_stocks WHERE stockID=@Id;";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "@Id", inventory.Id.ToString() }
            };

            UpgradeFile upgrade = new UpgradeFile();
            DataTable dt = upgrade.Load(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                DateTime expiredDate = DateTime.Parse(row["expDate"].ToString()).Date;

                Inventory resultInventory = new Inventory()
                {
                    Id = inventory.Id,
                    BatchNumber = row["batchNum"].ToString(),
                    Description = row["description"].ToString(),
                    TypeID = new Types() { Id = Convert.ToInt32(row["typeID"]) },
                    CategID = new ProductCategory() { Id = Convert.ToInt32(row["categID"]) },
                    BrandID = new Brand() { Id = Convert.ToInt32(row["brandID"]) },
                    Qty = Convert.ToInt32(row["qty"]),
                    DateReceived = DateTime.Parse(row["dateReceived"].ToString()).Date,
                    ExpiredDate = expiredDate,
                };

                // Notify if product is about to expire within 30 days but is not expired yet
                DateTime today = DateTime.Now.Date;
                TimeSpan daysUntilExpiry = expiredDate - today;

                if (daysUntilExpiry.TotalDays > 0 && daysUntilExpiry.TotalDays <= 30)
                {
                    MessageBox.Show($"The product '{resultInventory.Description}' (Batch: {resultInventory.BatchNumber}) will expire in {daysUntilExpiry.TotalDays} day(s) on {expiredDate:MM/dd/yyyy}.",
                                    "Expiration Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return resultInventory;
            }
            return null;

        }

        public void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView; // Get the DataGridView instance from the sender

            if (dgv != null)
            {
                // Check if the current column is one of the date columns
                if (dgv.Columns[e.ColumnIndex].Name == "dateReceived" || dgv.Columns[e.ColumnIndex].Name == "expDate")
                {
                    // If the value is not null, format it
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        e.Value = Convert.ToDateTime(e.Value).ToString("MM-dd-yyyy");
                    }
                }
            }
        }

        public void CheckForExpiringProducts()
        {
            string query = "SELECT * FROM prod_stocks;";
            UpgradeFile upgrade = new UpgradeFile();
            DataTable dt = upgrade.Load(query, null);  // Assuming no parameters needed to fetch all products

            DateTime today = DateTime.Now.Date;
            DateTime warningThreshold = today.AddDays(30);
            List<string> warningMessages = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                DateTime expiredDate = DateTime.Parse(row["expDate"].ToString()).Date;

                if (expiredDate > today && expiredDate <= warningThreshold)
                {
                    string productName = row["description"].ToString();
                    string batchNumber = row["batchNum"].ToString();
                    int daysUntilExpiry = (expiredDate - today).Days;

                    warningMessages.Add($"Product '{productName}' (Batch: {batchNumber}) will expire in {daysUntilExpiry} day(s) on {expiredDate:MM/dd/yyyy}.");
                }
            }

            if (warningMessages.Any())
            {
                string message = string.Join(Environment.NewLine, warningMessages);
                MessageBox.Show(message, "Expiration Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
