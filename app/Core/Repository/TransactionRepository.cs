using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.repository
{
    internal class TransactionRepository
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int ServiceID { get; set; }
        public int SoapID { get; set; }
        public string Qty { get; set; }
        public int Amount { get; set; }
        public DateTime Date {  get; set; }
    }
}
