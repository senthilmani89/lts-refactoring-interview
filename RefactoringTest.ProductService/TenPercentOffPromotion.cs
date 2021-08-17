using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public class TenPercentOffPromotion : IPromotion
    {
        public bool IsMatch(string promtion)
        {
            return promtion == "10PERCENTOFF";
        }

        public decimal Calculate(decimal price)
        {
            return price - price * 0.1m;
        }
    }
}
