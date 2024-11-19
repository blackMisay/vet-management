using app.core.model;
using System;
using System.Collections.Generic;
using System.Data;
using Core;
using System.Windows.Forms;
using app.view.Inventory;

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
                sql = "UPDATE prod_stocks SET stocksNum=@StockNumber, description=@Description, typeID=@TypeID, categID=@CategID, brandID=@BrandID, qty=@Qty, unitPrice=@UnitPrice, totalAmount=@TotalAmount, dateReceived=@DateReceived, expDate=@ExpiredDate WHERE stockID=@Id;";
            }
            else
            {
                sql = "INSERT INTO prod_stocks (stockID,stocksNum,description,typeID,categID,brandID,qty,unitPrice,totalAmount,dateReceived,expDate) VALUES(@Id,@StockNumber,@Description,@TypeID,@CategID,@BrandID,@Qty,@UnitPrice,@TotalAmount@DateReceived,@ExpiredDate);";
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(inventory.Id)},
                {"@StockNumber", inventory.StockNumber},
                {"@Description", inventory.Description},
                {"@TypeID", inventory.TypeID.Id.ToString()},
                {"@CategID", inventory.CategID.Id.ToString()},
                {"@BrandID", inventory.BrandID.Id.ToString()},
                {"@Qty", Convert.ToString(inventory.Qty)},
                {"@QUnitPrice", Convert.ToString(inventory.UnitPrice)},
                {"@TotalAmount", Convert.ToString(inventory.TotalAmount)},
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
                return new Inventory()
                {
                    Id = inventory.Id,
                    StockNumber = row["stocksNum"].ToString(),
                    Description = row["description"].ToString(),
                    TypeID = new Types() { Id = Convert.ToInt32(row["typeID"]) },
                    CategID = new ProductCategory() { Id = Convert.ToInt32(row["categID"]) },
                    BrandID = new Brand() { Id = Convert.ToInt32(row["brandID"]) },
                    Qty = Convert.ToInt32(row["qty"]),
                    UnitPrice = Convert.ToInt32(row["unitPrice"]),
                    TotalAmount = Convert.ToInt32(row["totalAmount"]),
                    // Parse the DateTime correctly and set it as DateTime type
                    DateReceived = DateTime.Parse(row["dateReceived"].ToString()).Date,  // Store as DateTime
                    ExpiredDate = DateTime.Parse(row["expDate"].ToString()).Date,       // Store as DateTime
                };
            }
            return null;


        }
        public string GetLastStockNumberFromDatabase()
        {
            try
            {
                // SQL query to fetch the last stock number where isDeleted = 0
                string query = " SELECT stocksNum FROM prod_stocks WHERE isDeleted = 0 ORDER BY stocksNum DESC LIMIT 1; ";

                // Create parameters for the query (if needed, for example, in case of parameterized queries)
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                // Execute the query using UpgradeFile
                UpgradeFile upgradeFile = new UpgradeFile();
                DataTable resultTable = upgradeFile.Load(query, parameters);

                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    // Ensure StockNumber is returned as a string (or cast accordingly)
                    var stockNumber = resultTable.Rows[0]["stocksNum"];

                    // If StockNumber is not null or DBNull
                    if (stockNumber != DBNull.Value)
                    {
                        return stockNumber.ToString();  // Return the StockNumber as a string
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching last stock number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;  // Return null if there's an issue or no data found

        }
        public string GenerateNextStockNumber()
        {
            string prefix = "SN";
            int nextNumber = 1;  // Default start value

            // Get the last stock number from the database (this is just an example, you should retrieve the actual last stock number from the DB)
            string lastStockNumber = GetLastStockNumberFromDatabase();  // Replace with your actual logic to get the last stock number

            if (!string.IsNullOrEmpty(lastStockNumber))
            {
                // Strip "SN" and convert to integer
                int lastNumber = Convert.ToInt32(lastStockNumber.Substring(2));  // Remove "SN" prefix
                nextNumber = lastNumber + 1;  // Increment the last number
            }

            return prefix + nextNumber.ToString("D8");  // Format as SN00000001 (8 digits)
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
    }
}
