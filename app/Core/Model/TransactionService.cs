using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.model
{
    internal class TransactionService
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public Client Client { get; set; }
        public Services Service { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

    }
}
