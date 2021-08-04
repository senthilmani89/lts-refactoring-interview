using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RefactoringTest.ProductService
{
    public class ProductFunctions
    {
        private readonly ProductService _productService;
        
        public ProductFunctions(ProductService productService)
        {
            _productService = productService;
        }

        [FunctionName("AddProduct")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("Add product request received");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Product>(requestBody);
            var addProductResult = _productService.AddProduct(data.ProductName, data.ProductDescription, data.Price, data.Quantity, data.BrandName, data.Promotion);

            return new OkObjectResult(addProductResult);
        }
    }
}
