using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public interface IPriceCalculator
    {
        decimal CalculatePriceBasedOnPromotion(string promotion, decimal price);
    }
}
