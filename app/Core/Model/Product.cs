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

        public int BrandID { get; set; }

        public string Description { get; set; }

        public int CategID { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public int Amount { get; set; }


    }
}
