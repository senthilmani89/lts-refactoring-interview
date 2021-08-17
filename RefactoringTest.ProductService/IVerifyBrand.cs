using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringTest.ProductService
{
    public interface IVerifyBrand
    {
        Task<bool> IsBrandAllowed(string brandName);
    }
}
