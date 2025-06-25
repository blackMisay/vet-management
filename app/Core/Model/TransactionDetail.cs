using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.model
{
    public class TransactionDetail
    {
            public int Id { get; set; } // Optional
            public int TransactionPaymentId { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public double UnitPrice { get; set; }
            public double TotalAmount { get; set; }
    }
    }