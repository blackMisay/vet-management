

namespace app.core.model
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public Brand Brand { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
