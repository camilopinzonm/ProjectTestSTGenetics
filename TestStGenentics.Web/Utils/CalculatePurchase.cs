using TestStGenentics.Shared.ModelResponse;

namespace TestStGenentics.Web.Utils
{
    public class CalculatePurchase
    {

        public static async Task<PurchaseTotals> GetDataCalculate(IList<AnimalResponse> selectedAnimalResponses)
        {
            List<Purchase> purchases = new List<Purchase>();
            PurchaseTotals totals = new PurchaseTotals();
            var NewRow = selectedAnimalResponses.GroupBy(t => t.BreedName).Select(t => new
            {
                Breeds = t.Key,
                CountRows = t.Count(),
                SumRows = t.Sum(ta => ta.Price),
            }).ToList();


            foreach (var item in NewRow)
            {
                Purchase purchase = new Purchase();
                purchase.Breeds = item.Breeds;
                purchase.CountRows = item.CountRows;
                purchase.SumRows = item.SumRows;

                purchases.Add(purchase);

            }
            totals.ListRows = purchases;
            totals.Quantity = purchases.Sum(ta => ta.CountRows).Value;
            totals.TotalAmount = purchases.Sum(ta => ta.SumRows).Value;
            totals.Freight = 1000;
            totals.TotalDto = 0;
            if (totals.Quantity > 10)
            {
                decimal tres = (3 / 100);
                totals.TotalDto = decimal.Multiply(totals.TotalAmount, decimal.Divide(3, 100));
                if (totals.Quantity > 20)
                {
                    totals.Freight = 0;
                }
            } else if (totals.Quantity > 5) {
                decimal cinco = (5 / 100);
                totals.TotalDto = decimal.Multiply(totals.TotalAmount, decimal.Divide(5 , 100));
            }
            
            
            return totals;

        }
    }
}
