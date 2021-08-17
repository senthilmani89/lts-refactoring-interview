using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace RefactoringTest.ProductService
{
    public class VerifyBrand : IVerifyBrand
    {
        public async Task<bool> IsBrandAllowed(string brandName)
        {
            var sb = new StringBuilder("http://brandservice-test.azurewebsites.net?brandName=");
            //var sb = new StringBuilder("https://www.google.com/");
            sb.Append(brandName);
            var ep = sb.ToString();

            var client = new HttpClient();
            var response = await client.GetAsync(ep);
            var responseString = response.Content.ReadAsStringAsync().Result;
            var isBrandAllowed = bool.Parse(responseString);

            return isBrandAllowed;
        }
    }
}
