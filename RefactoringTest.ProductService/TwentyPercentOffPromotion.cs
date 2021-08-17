using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public class TwentyPercentOffPromotion : IPromotion
    {
        public bool IsMatch(string promtion)
        {
            return promtion == "20PERCENTOFF";
        }

        public decimal Calculate(decimal price)
        {
            return price - price * 0.2m;
        }
    }
}
