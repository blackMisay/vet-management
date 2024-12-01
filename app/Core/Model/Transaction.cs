using System;
namespace app.core.model
{
    internal class Transaction
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int ServiceID { get; set; }
        public string Qty { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
