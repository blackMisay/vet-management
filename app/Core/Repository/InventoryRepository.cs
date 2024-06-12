using app.core.model;
using app.Core.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                sql = "UPDATE prod_stocks SET stocksNum=@StockNumber, description=@Description, prodID=@ProdID, categID=@CategID, brandID=@BrandID, qty=@Qty, dateReceived=@DateReceived, expDate=@ExpiredDate WHERE stockID=@Id;";
            }
            else
            {
                sql = "INSERT INTO prod_stocks (stockID,stocksNum,description,prodID,categID,brandID,qty,dateReceived,expDate) VALUES(@Id,@StockNumber,@Description,@ProdID,@CategID,@BrandID,@Qty,@DateReceived,@ExpiredDate);";
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            {"@Id", Convert.ToString(inventory.Id)},
            {"@StockNumber",Convert.ToString (inventory.StockNumber) },
            {"@Description", inventory.Description },
            {"@ProdID", inventory.ProdID.Id.ToString() },
            {"@CategID", inventory.CategID.Id.ToString()},
            {"@BrandID", inventory.BrandID.Id.ToString()},
            {"@Qty", Convert.ToString(inventory.Qty)},
            {"@DateReceived", inventory.DateReceived},
            {"@ExpiredDate", inventory.ExpiredDate},
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
                    StockNumber = Convert.ToInt32(row["stocksNum"]),
                    Description = row["description"].ToString(),
                    ProdID = new Product() { Id = Convert.ToInt32(row["prodID"]) },
                    CategID = new ProductCategory() { Id = Convert.ToInt32(row["categID"]) },
                    BrandID = new Brand() { Id = Convert.ToInt32(row["brandID"]) },
                    Qty = Convert.ToInt32(row["qty"]),
                    DateReceived = row["dateReceived"].ToString(),
                    ExpiredDate = row["expDate"].ToString(),
                };
            }
            return null;
        }         
    }
}
