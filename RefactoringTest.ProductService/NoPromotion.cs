using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public class NoPromotion : IPromotion
    {
        public bool IsMatch(string promtion)
        {
            return (promtion == null || promtion.Trim() == string.Empty);
        }

        public decimal Calculate(decimal price)
        {
            return price;
        }
    }
}
