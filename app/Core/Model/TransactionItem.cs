using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.model
{
    internal class TransactionItem
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public Product Product { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }

    }
}
