using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.model
{
    internal class Product
    {
        public int Id { get; set; }

        public Brand BrandID { get; set; }

        public string Description { get; set; }

        public ProductCategory CategID { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double Amount { get; set; }


    }
}
