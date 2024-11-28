

namespace app.core.model
{
    internal class Product
    {
        public int Id { get; set; }

        public Brand BrandID { get; set; }

        public string Description { get; set; }

        public ProductCategory CategID { get; set; }

        public Types TypeID { get; set; }
    }
}
