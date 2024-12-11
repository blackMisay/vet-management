using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.model
{
    internal class TransactionPayment
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public Client Client { get; set; }
        public string Name { get; set; }
        public decimal Total {  get; set; }
        public DateTime Date { get; set; }

    }
}
