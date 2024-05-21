using app.core.model;
using app.Core.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.core.model;

namespace app.core.repository
{
    internal class ProductRepository
    {
        

        public DataTable SearchProduct(string searchValue)
        {
            string query = "SELECT * FROM vwproduct WHERE `amount` LIKE @searchValue OR `prodDesc` LIKE @searchValue;";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"@searchValue", "%" + searchValue + "%" }
            };
            UpgradeFile upgradeFile = new UpgradeFile();
            return upgradeFile.Load(query, parameters);
        }
        public bool SaveProduct(Product product)
        {
            string sql;

            bool saveState = product.Id > 0 ? true : false;

            if (saveState)
            {
                sql = "UPDATE vwproduct SET prodID=@Id WHERE prodId=@Id;";
            }
            else
            {
                sql = "INSERT INTO vwproduct(prodID,brandID,prodDesc,categID,qty,unitPrice,amount) VALUES(@Id,@BrandID,@Description,@CategID,@Quantity,@UnitPrice,@Amount);";
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(product.Id)},
                {"@BrandID",Convert.ToString(product.BrandID)},
                {"@Description", product.Description },
                {"@CategID", Convert.ToString(product.CategID)},
                {"@Quantity", Convert.ToString(product.Quantity) },
                {"@UnitPrice", Convert.ToString(product.UnitPrice) },
                {"@Amount", Convert.ToString(product.Amount) },
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }
        public bool DeleteProduct(Product product)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string sql = "UPDATE vwproduct SET deleted = '1' WHERE id=@Id;";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", product.Id);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
}