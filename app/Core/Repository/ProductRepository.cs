using app.core.model;
using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Net.NetworkInformation;
using System.Windows.Forms;

public class ProductRepository
{
    private UpgradeFile upgradeFile = new UpgradeFile();
    internal readonly string KEY = "Key";
    internal readonly string VALUE = "Value";

    // Get all products with optional search filtering
    public DataTable GetAllProducts(string search = "")
    {
        string sql = @"
        SELECT p.id, p.sku, pb.brandDesc AS brand, p.description, 
               c.name AS category_name, s.name AS supplier_name, 
               p.price, p.stock
        FROM products p
        LEFT JOIN categories c ON p.category_id = c.id
        LEFT JOIN suppliers s ON p.supplier_id = s.id
        LEFT JOIN product_brand pb ON p.brand_id = pb.brandId
        WHERE (@search = '' OR 
               p.sku LIKE @search OR
               pb.brandDesc LIKE @search OR
               p.description LIKE @search OR
               c.name LIKE @search OR
               s.name LIKE @search)
        ORDER BY pb.brandDesc, p.description;
    ";

        var parameters = new Dictionary<string, string>
    {
        { "@search", $"%{search}%" }
    };

        return upgradeFile.Load(sql, parameters);
    }


    // Save or update a product
    public bool SaveProduct(Product product)
    {
        string sql;
        var parameters = new Dictionary<string, object>
    {
        { "@SKU", product.SKU },
        { "@BrandId", product.Brand?.Id },
        { "@Description", product.Description },
        { "@CategoryId", product.Category?.Id },
        { "@SupplierId", product.Supplier?.Id },
        { "@Price", product.Price },
        { "@Stock", product.Stock }
    };

        if (product.Id > 0)
        {
            sql = @"
            UPDATE products
            SET sku = @SKU,
                brand_id = @BrandId,
                description = @Description,
                category_id = @CategoryId,
                supplier_id = @SupplierId,
                price = @Price,
                stock = @Stock
            WHERE id = @Id;
        ";
            parameters.Add("@Id", product.Id);
        }
        else
        {
            sql = @"
            INSERT INTO products 
            (sku, brand_id, description, category_id, supplier_id, price, stock)
            VALUES
            (@SKU, @BrandId, @Description, @CategoryId, @SupplierId, @Price, @Stock);
        ";
        }

        return upgradeFile.Save(sql, parameters);
    }


    // Delete a product by id
    public bool DeleteProduct(int productId)
    {
        string sql = "DELETE FROM products WHERE id = @Id;";
        var parameters = new Dictionary<string, object>
        {
            { "@Id", productId }
        };
        return upgradeFile.Save(sql, parameters);
    }

    // Get all categories
    public DataTable GetCategories()
    {
        string sql = "SELECT id, name FROM categories ORDER BY name;";
        return upgradeFile.Load(sql, null);
    }

    // Get all suppliers
    public DataTable GetSuppliers()
    {
        string sql = "SELECT id, name FROM suppliers ORDER BY name;";
        return upgradeFile.Load(sql, null);
    }

    // Get products filtered by category id
    public DataTable GetProductsByCategoryId(int categoryId)
    {
        const string query = @"
        SELECT 
            p.id,
            p.sku,
            pb.brandDesc AS brand,
            p.description,
            c.name AS category_name,
            s.name AS supplier_name,
            p.price,
            p.stock
        FROM products p
        LEFT JOIN categories c ON p.category_id = c.id
        LEFT JOIN suppliers s ON p.supplier_id = s.id
        LEFT JOIN product_brand pb ON p.brand_id = pb.brandId
        WHERE p.category_id = @CategoryId
        ORDER BY pb.brandDesc, p.description;
    ";

        var parameters = new Dictionary<string, object>
    {
        { "@CategoryId", categoryId }
    };

        return upgradeFile.LoadDataTable(query, parameters);
    }



    public Product DataRowToProduct(DataRow row)
    {
        if (row == null)
            return null;

        return new Product
        {
            Id = row.Field<int>("id"),
            SKU = row.Field<string>("sku"),
            Brand = new Brand
            {
                Description = row.Field<string>("brand")
            },
            Description = row.Field<string>("description"),
            Category = new Category
            {
                Name = row.Field<string>("category_name")
            },
            Supplier = new Supplier
            {
                Name = row.Field<string>("supplier_name")
            },
            Price = row.Field<double>("price"),
            Stock = row.Field<int>("stock")
        };
    }

    public DataRow GetProductDataRow(int productId)
    {
        const string query = @"
        SELECT 
            p.id, 
            p.sku, 
            pb.brandDesc AS brand, 
            p.description, 
            c.name AS category_name,
            s.name AS supplier_name, 
            p.price, 
            p.stock
        FROM products p
        LEFT JOIN categories c ON p.category_id = c.id
        LEFT JOIN suppliers s ON p.supplier_id = s.id
        LEFT JOIN product_brand pb ON p.brand_id = pb.brandId
        WHERE p.id = @productId;
    ";

        var parameters = new Dictionary<string, object>
    {
        { "@productId", productId }
    };

        DataTable result = upgradeFile.LoadDataTable(query, parameters);

        return result.Rows.Count > 0 ? result.Rows[0] : null;
    }

    public void LoadCategory(DataGridView dgv)
    {
        UpgradeFile db = new UpgradeFile(); 
        {
            dgv.DataSource = db.Load("SELECT * FROM categories WHERE isActive=1;");
        }
    }
    public void Populate(ComboBox comboBox)
    {
        UpgradeFile db = new UpgradeFile();
        {
            comboBox.DataSource = db.Populate("SELECT * FROM categories WHERE isActive=1;");
        }
    }
    public int Execute(string query, Dictionary<string, string> parameters)
    {
        UpgradeFile db = new UpgradeFile();
        {
            DataTable dt;
            dt = db.Load(query, parameters);

            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }
    }
    public bool CheckCategory(string description, int currenProductId)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "@Name", description },
                { "@CurrentProductId", currenProductId.ToString() }
            };
        UpgradeFile db = new UpgradeFile();
        {
            int count = Convert.ToInt32(Execute("SELECT COUNT(*) FROM categories WHERE name = @Name AND isActive = 1 AND id <> @CurrentProductId;", parameters));
            return count > 0;
        }
    }

    public bool AddCategory(Category category)
    {
        var parameters = new Dictionary<string, object>
    {
        { "@Name", category.Name }
    };

        var db = new UpgradeFile();

        if (category.Id == 0)
        {
            // Assuming the table has an `isActive` column
            return db.Save("INSERT INTO categories (name, isActive) VALUES (@Name, 1);", parameters);
        }
        else
        {
            parameters.Add("@Id", category.Id);
            return db.Save("UPDATE categories SET name = @Name WHERE id = @Id;", parameters);
        }
    }
    public bool Delete(int Id)
    {
        UpgradeFile db = new UpgradeFile();

        {
            Dictionary<string, object> parameteres = new Dictionary<string, object>()
                {
                    { "@Id", Id.ToString() }
                };
            return db.Save("UPDATE categories SET isActive=0 WHERE id=@Id", parameteres);
        }
    }

    public void LoadBrand(DataGridView dgv)
    {
        UpgradeFile db = new UpgradeFile();
        {
            dgv.DataSource = db.Load("SELECT * FROM product_brand WHERE isDeleted = 0;");
        }
    }





}
