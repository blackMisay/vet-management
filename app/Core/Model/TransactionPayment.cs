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
        public string InvoiceNumber { get; set; }
        public Client Client { get; set; }
        public Pet Pet { get; set; }
        public string Name { get; set; }
        public double Cash { get; set; }
        public double GCash { get; set; }
        public string GCashReferenceNumber { get; set; }
        public double PayMaya { get; set; }
        public string PayMayaReferenceNumber { get; set; }
        public double SubTotalAmount { get; set; }
        public double TotalAmount {  get; set; }
        public double ChangeAmount { get; set; }
        public DateTime Date { get; set; }

    }
}