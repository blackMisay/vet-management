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
        int prodId;
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
                sql = "UPDATE product SET brandID=@BrandID, prodDesc=@Description, categID=@CategID, qty=@Quantity, unitPrice=@UnitPrice, amount=@Amount WHERE prodID=@Id;";
            }
            else
            {
                sql = "INSERT INTO product(prodID,brandID,prodDesc,categID,qty,unitPrice,amount) VALUES(@Id,@BrandID,@Description,@CategID,@Quantity,@UnitPrice,@Amount);";
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(product.Id)},
                {"@BrandID", product.BrandID.Id.ToString() },
                {"@Description", product.Description },
                {"@CategID", product.CategID.Id.ToString() },
                {"@Quantity", Convert.ToString(product.Quantity) },
                {"@UnitPrice", Convert.ToString(product.UnitPrice) },
                {"@Amount", Convert.ToString(product.Amount) },
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }
        public bool DeleteProduct(int product)
        {
            string sql = "UPDATE product SET isdeleted = 1 WHERE prodID=@Id;";

            UpgradeFile upgrade = new UpgradeFile();
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@Id", product.ToString() }
                };
                return upgrade.ExecuteQuery(sql, parameters);
        }
        public Product GetProduct(Product product)
        {
            string query = "SELECT * FROM product WHERE prodID=@Id;";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "@Id", product.Id.ToString() }
            };

            UpgradeFile upgrade = new UpgradeFile();
            DataTable dt = upgrade.Load(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Product()
                {
                    Id = product.Id,
                    BrandID = new Brand() { Id = Convert.ToInt32(row["brandID"]) },
                    Description = row["prodDesc"].ToString(),
                    CategID = new ProductCategory() { Id = Convert.ToInt32(row["categID"]) },
                    Quantity = Convert.ToInt32(row["qty"]),
                    UnitPrice = Convert.ToDouble(row["unitPrice"]),
                    Amount = Convert.ToDouble(row["amount"])
                };
            }
            return null;
        }
    }
}