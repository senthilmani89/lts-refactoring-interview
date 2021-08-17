using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public interface IPromotion
    {
        bool IsMatch(string promotion);

        decimal Calculate(decimal price);
    }
}
