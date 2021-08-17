using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
   public class WrapperMethod
    {
        IProductRepositoryWrapper _wrapper;

        public WrapperMethod(IProductRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public void SomeMethod(int id, string productName, string productDescription, decimal price, int quantity, string brandName)
        {
             _wrapper.AddProduct(id, productName, productDescription, price, quantity, brandName);

        }
    }
}
