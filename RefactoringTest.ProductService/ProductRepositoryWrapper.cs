using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public class ProductRepositoryWrapper
    {
        public void AddProduct(int id, string productName, string productDescription, decimal price, int quantity, string brandName)
        {

            ProductRepository.AddProduct(id, productName, productDescription, price, quantity, brandName);
        }
    }
}
