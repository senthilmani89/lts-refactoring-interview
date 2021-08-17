using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTest.ProductService
{
    public interface IFileReader
    {
        IEnumerable<int> Read(string path);
    }
}
