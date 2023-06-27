using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStGenentics.Shared.ModelResponse
{
    public class PurchaseTotals
    {
        public List<Purchase> ListRows { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDto { get; set; }
        public int Freight { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
