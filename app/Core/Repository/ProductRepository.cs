using app.core.model;
using System;
using System.Collections.Generic;
using System.Data;
using Core;


namespace app.core.repository
{
    internal class ProductRepository
    {
        int prodId;
        public DataTable SearchProduct(string searchValue)
        {
            string query = "SELECT * FROM vwproduct WHERE `categoryDescription` LIKE @searchValue;";
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

                sql = "UPDATE product SET brandID=@BrandID, prodDesc=@Description, categID=@CategID WHERE prodID=@Id;";

            }
            else
            {
                sql = "INSERT INTO product(prodID,brandID,prodDesc,categID) VALUES(@Id,@BrandID,@Description,@CategID);";
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(product.Id)},
                {"@BrandID", product.BrandID.Id.ToString() },
                {"@Description", product.Description },
                {"@CategID", product.CategID.Id.ToString() }

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
            string query = "SELECT * FROM product WHERE prodID = @Id;";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "@Id", product.Id.ToString() }
            };

            UpgradeFile upgrade = new UpgradeFile();
            DataTable dt = upgrade.Load(query, parameters);  // Ensure Load method properly handles parameters

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];  // Accessing the first row
                return new Product()
                {
                    Id = product.Id,  // Use the provided product ID
                    BrandID = new Brand() { Id = Convert.ToInt32(row["brandID"]) },  // Use column name
                    Description = row["prodDesc"]?.ToString() ?? string.Empty,  // Null-safe description
                    CategID = new ProductCategory() { Id = Convert.ToInt32(row["categID"]) }  // Use column name
                };
            }
            return null;



        }
    }
}