using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace RefactoringTest.ProductService
{
    public class ProductService
    {
        private readonly IEnumerable<int> _allAvailableIds = Enumerable.Range(0, 100000000);
        private const string _usedIdsFileName = "used_ids.txt";
        
        public bool AddProduct(string productName, string produtcDescirption, decimal price, int quantity, string brandName, string promotion)
        {
            if(string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(produtcDescirption))
                return false;
            
            if(price <= 0 || quantity <= 0)
                return false;

            if(string.IsNullOrEmpty(brandName))
                return false;

            if (promotion == "5PERCENTOFF")
                price = price - price * 0.05m;
            else if (promotion == "10PERCENTOFF")
                price = price - price * 0.1m;
            else if (promotion == "20PERCENTOFF")
                price = price - price * 0.2m;
            else if (!string.IsNullOrEmpty((promotion)))
                throw new ArgumentException("Invalid promotion specified");

            var sb = new StringBuilder();
            sb.Append("http://brandservice-test.azurewebsites.net?brandName=");
            sb.Append(brandName);
            var ep = sb.ToString();
            var c = new HttpClient();
            var r = c.GetAsync(ep).Result.Content.ReadAsStringAsync().Result;
            var isBrandAllowed = bool.Parse(r);

            if (!isBrandAllowed)
                return false;

            var usedIds = File.ReadAllLines(_usedIdsFileName).Select(int.Parse);
            var id = _allAvailableIds.FirstOrDefault(x => usedIds.All(i => i != x));
            
            if(id == 0)
                throw new Exception("No available ids left");
            
            ProductRepository.AddProduct(id, productName, produtcDescirption, price, quantity, brandName);
            
            return true;
        }
    }
}