

using System;

namespace app.core.model
{
    internal class Inventory
    {
       public int Id { get; set; }

       public string StockNumber { get; set; }

       public string Description { get; set; }

       public Types TypeID { get; set; }    

       public ProductCategory CategID { get; set; }

       public Brand BrandID { get; set; }

       public int Qty { get; set;}

       public DateTime DateReceived { get; set; }

       public DateTime ExpiredDate { get; set; } 

       
    }
}
