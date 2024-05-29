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
                sql = "UPDATE prod_stocks SET stockID=@Id WHERE stockID=@Id;";
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
            {"@ProdID", Convert.ToString (inventory.ProdID) },
            {"@CategID", Convert.ToString(inventory.CategID)},
            {"@BrandID", Convert.ToString(inventory.BrandID)},
            {"@Qty", Convert.ToString(inventory.Qty)},
            {"@DateReceived", inventory.DateReceived},
            {"@ExpiredDate", inventory.ExpiredDate},
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }
        public bool DeleteInventory(Inventory inventory)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string sql = "UPDATE prod_stocks SET deleted = '1' WHERE id=@Id;";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", inventory.Id);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
}
