using app.core.model;
using System;
using System.Collections.Generic;
using System.Data;
using Core;
using System.Windows.Forms;
using System.Linq;
using MySqlConnector;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Odbc;

namespace app.core.Repository
{
    internal class InventoryRepository
    {
        UpgradeFile db = new UpgradeFile();
        private readonly UpgradeFile _db;

        public InventoryRepository()
        {
            _db = new UpgradeFile();
        }
        public DataTable LoadAllInventory()
        {
            string sql = "SELECT * FROM vw_inventory_products;";
            return db.Load(sql, null);
        }

        public DataTable SearchInventory(string searchValue)
        {
            string sql = @"
                SELECT * FROM vw_inventory_products 
                WHERE sku LIKE @search OR brand LIKE @search 
                      OR description LIKE @search 
                      OR category LIKE @search 
                      OR supplier LIKE @search
                ORDER BY category, brand, description;";

            var parameters = new Dictionary<string, string>
            {
                {"@search", "%" + searchValue + "%" }
            };

            return db.Load(sql, parameters);
        }

        public bool SaveInventory(Inventory inventory)
        {
            string sql;
            bool saveState = inventory.Id > 0;

            if (saveState)
            {
                sql = "UPDATE products SET sku=@Sku, brand=@Brand, description=@Description, category_id=@CategoryId, supplier_id=@SupplierId, price=@Price, stock=@Stock WHERE id=@Id;";
            }
            else
            {
                sql = "INSERT INTO products (sku, brand, description, category_id, supplier_id, price, stock) VALUES(@Sku, @Brand, @Description, @CategoryId, @SupplierId, @Price, @Stock);";
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"@Id", inventory.Id.ToString()},
                {"@Sku", inventory.Sku},
                {"@Brand", inventory.Brand.Id.ToString()},
                {"@Description", inventory.Description},
                {"@CategoryId", inventory.Category.Id.ToString()},
                {"@SupplierId", inventory.Supplier.Id.ToString()},
                {"@Price", inventory.Price.ToString("F2")},
                {"@Stock", inventory.Stock.ToString()}
            };

            return db.ExecuteQuery(sql, parameters);
        }

        public bool DeleteInventory(int inventoryId)
        {
            string sql = "UPDATE products SET isDeleted = 1 WHERE id = @Id;";
            var parameters = new Dictionary<string, string>
            {
                {"@Id", inventoryId.ToString()}
            };
            return db.ExecuteQuery(sql, parameters);
        }

        public Inventory GetInventory(int id)
        {
            string query = "SELECT * FROM products WHERE id=@Id;";
            var parameters = new Dictionary<string, string>
            {
                {"@Id", id.ToString()}
            };

            DataTable dt = db.Load(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                return new Inventory
                {
                    Id = id,
                    Sku = row["sku"].ToString(),
                    Brand = new Brand { Id = Convert.ToInt32(row["brand_id"]) },
                    Description = row["description"].ToString(),
                    Category = new Category { Id = Convert.ToInt32(row["category_id"]) },
                    Supplier = new Supplier { Id = Convert.ToInt32(row["supplier_id"]) },
                    Price = Convert.ToDouble(row["price"]),
                    Stock = Convert.ToInt32(row["stock"])
                };
            }

            return null;
        }

        public void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && e.Value != null && e.Value != DBNull.Value)
            {
                if (dgv.Columns[e.ColumnIndex].Name == "price")
                {
                    e.Value = Convert.ToDecimal(e.Value).ToString("C2");
                }
            }
        }

        public bool AdjustStock(int productId, int quantity, string movementType, string notes = null)
        {
            string updateSql = movementType == "IN"
                ? "UPDATE products SET stock = stock + @qty WHERE id = @productId"
                : "UPDATE products SET stock = stock - @qty WHERE id = @productId";

            string insertSql = @"
        INSERT INTO product_stock_transactions
        (product_id, transaction_type, quantity, reason, transaction_date)
        VALUES (@productId, @type, @qty, @reason, NOW())";

            var parameters = new Dictionary<string, object>
    {
        {"@productId", productId},
        {"@qty", quantity},
        {"@type", movementType},
        {"@reason", notes ?? ""}
    };

            var upgradeFile = new UpgradeFile();

            using (var conn = new MySqlConnector.MySqlConnection(upgradeFile.ConnectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // You'll need to add the ExecuteNonQuery overload with transaction support to UpgradeFile
                        upgradeFile.ExecuteNonQuery(updateSql, parameters, conn, transaction);
                        upgradeFile.ExecuteNonQuery(insertSql, parameters, conn, transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public DataTable GetStockTransactions(string typeFilter, DateTime fromDate, DateTime toDate)
        {
            string sql = @"
        SELECT t.id, p.description AS Product, t.transaction_type AS Type,
               t.quantity AS Quantity, t.reason AS Reason,
               t.transaction_date AS Date
        FROM product_stock_transactions t
        INNER JOIN products p ON t.product_id = p.id
        WHERE t.transaction_date BETWEEN @from AND @to";

            if (typeFilter != "All")
                sql += " AND t.transaction_type = @type";

            var parameters = new Dictionary<string, string>
    {
        { "@from", fromDate.Date.ToString("yyyy-MM-dd") },
        { "@to", toDate.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd") }
    };

            if (typeFilter != "All")
                parameters.Add("@type", typeFilter);

            return new UpgradeFile().Load(sql, parameters);
        }

        public bool IsStockTrackedItem(int productId)
        {
            string sql = "SELECT is_stock_item FROM products WHERE id = @id";
            var parameters = new Dictionary<string, object> { { "@id", productId } };
            var result = new UpgradeFile().QuerySingle(sql, parameters);

            return result != null && Convert.ToBoolean(result["is_stock_item"]);
        }

        public bool AdjustStockTransactional(
     int productId,
     int quantity,
     string movementType,
     string reason,
     MySqlConnection conn,
     MySqlTransaction transaction)
        {
            string updateSql = movementType == "IN"
                ? "UPDATE products SET stock = stock + @qty WHERE id = @productId"
                : "UPDATE products SET stock = stock - @qty WHERE id = @productId AND stock >= @qty";

            const string insertSql = @"
        INSERT INTO product_stock_transactions 
        (product_id, transaction_type, quantity, reason, transaction_date)
        VALUES 
        (@productId, @type, @qty, @reason, NOW());";

            try
            {
                // 1. Create parameter dictionary
                var parameters = new Dictionary<string, object>
        {
            { "@productId", productId },
            { "@qty", quantity },
            { "@type", movementType },
            { "@reason", reason ?? string.Empty }
        };

                // 2. Update stock in products table
                int rowsAffected = _db.ExecuteNonQuery(updateSql, parameters, conn, transaction);


                if (movementType == "OUT" && rowsAffected == 0)
                {
                    // If trying to reduce stock below available quantity
                    return false;
                }

                // 3. Log stock movement
                _db.ExecuteNonQuery(insertSql, parameters, conn, transaction);

                return true;
            }
            catch (Exception ex)
            {
                // Optionally log ex.Message
                return false;
            }
        }
        public void InventoryLoad(DataGridView dgv, Dictionary<string, int> param)
        {
            
            {
                dgv.DataSource = db.Pagination(
                    "SELECT * FROM vwinventory WHERE qty > 0 ORDER BY productBrand LIMIT @record, @recordCount;",
                    param);
            }
        }

        public void LoadProductBy(DataGridView dgv, Dictionary<string, string> param)
        {
            {
                dgv.DataSource = db.Load("SELECT * FROM vwinventory WHERE qty > 0 AND productBrand LIKE @Brand", param);
            }
        }






    }
}
