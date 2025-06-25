

using System;

namespace app.core.model
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public Brand Brand { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Reason { get; set; }
        public Category Category { get; set; } // category name from view
        public Supplier Supplier { get; set; } // supplier name from view
        public double Price { get; set; }
        public int Stock { get; set; }
        public int LowStockThreshold { get; set; }
        public DateTime DateReceived { get; set; }

       public DateTime ExpiredDate { get; set; } 

       
    }
}
