using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RefactoringTest.ProductService
{
    public class FileReader : IFileReader
    {
        public IEnumerable<int> Read(string path)
        {
            return File.ReadAllLines(path).Select(int.Parse);
        }
    }
}
