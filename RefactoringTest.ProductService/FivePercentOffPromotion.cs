using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public class FivePercentOffPromotion : IPromotion
    {
        public bool IsMatch(string promtion)
        {
            return promtion == "5PERCENTOFF";
        }

        public decimal Calculate(decimal price)
        {
            return price - price * 0.05m;
        }
    }
}
