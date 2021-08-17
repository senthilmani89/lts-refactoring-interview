using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public interface IProductRepositoryWrapper
    {
        void AddProduct(int id, string productName, string productDescription, decimal price, int quantity, string brandName);
    }
}
