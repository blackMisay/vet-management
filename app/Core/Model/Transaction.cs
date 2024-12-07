

using app.Core.Model;
using System;
using System.Windows.Forms;

namespace app.core.model
{
    internal class Transaction
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public Services Services { get; set; }
        public double ServiceAmount { get; set; }
        public double Total { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
