using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringTest.ProductService
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IEnumerable<IPromotion> promotions;


        public PriceCalculator()
        {
            promotions = new List<IPromotion>
            {
                new NoPromotion(),
                new FivePercentOffPromotion(),
                new TenPercentOffPromotion(),
                new TwentyPercentOffPromotion()

            };
        }

        public decimal CalculatePriceBasedOnPromotion(string promotion, decimal price )
        {
            return promotions.Single(x => x.IsMatch(promotion)).Calculate(price);
        }
    }
}
