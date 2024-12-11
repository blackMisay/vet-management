

using app.Core.Model;
using System;
using System.Windows.Forms;

namespace app.core.model
{
    internal class Transaction
    {
        public int Id { get; set; }
        public Client Client { get; set; }

        public double SubTotal { get; set; }
        public double Total { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
