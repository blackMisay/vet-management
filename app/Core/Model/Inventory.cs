using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.model
{
    internal class Inventory
    {
       public int Id { get; set; }

       public int StockNumber { get; set; }

       public string Description { get; set; }

       public Product ProdID { get; set; }    

       public ProductCategory CategID { get; set; }

       public Brand BrandID { get; set; }

       public int Qty { get; set;}

       public string DateReceived { get; set; }

       public string ExpiredDate { get; set; } 

       
    }
}
