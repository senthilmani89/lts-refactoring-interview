using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoringTest.ProductService
{
    public class ProductService
    {
        private readonly IEnumerable<int> _allAvailableIds = Enumerable.Range(0, 100000000);
        private const string _usedIdsFileName = "used_ids.txt";        


        private IPriceCalculator _priceCalculator;
        private IVerifyBrand _verifyBrand;       
        private IFileReader _fileReader;
       

        public ProductService(IPriceCalculator priceCalculator = null, IVerifyBrand verifyBrand = null, IFileReader fileReader = null)
        {
            _priceCalculator = priceCalculator ?? new PriceCalculator();
            _verifyBrand = verifyBrand ?? new VerifyBrand();
            _fileReader = fileReader ?? new FileReader();
        }

        public bool AddProduct(string productName, string produtcDescription, decimal price, int quantity, string brandName, string promotion)
        {
            bool isValidRequest = validateRequest(productName, produtcDescription, price, quantity, brandName, promotion);

            if (!isValidRequest)
                return false;

            price = _priceCalculator.CalculatePriceBasedOnPromotion(promotion, price);

            var isBrandAllowed = _verifyBrand.IsBrandAllowed(brandName).Result;

            if (!isBrandAllowed)
                return false;

            var usedIds = _fileReader.Read(_usedIdsFileName);

            var id = _allAvailableIds.FirstOrDefault(x => usedIds.All(i => i != x));

            if (id == 0)
                throw new Exception("No available ids left");

            ProductRepository.AddProduct(id, productName, produtcDescription, price, quantity, brandName);

            return true;
        }



        private bool validateRequest(string productName, string produtcDescription, decimal price, int quantity, string brandName, string promotion)
        {
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(produtcDescription))
                return false;

            if (price <= 0 || quantity <= 0)
                return false;

            if (string.IsNullOrEmpty(brandName))
                return false;

            List<string> promotionsTypes = new List<string>() { "5PERCENTOFF", "10PERCENTOFF", "20PERCENTOFF" };
            bool isPresent = promotionsTypes.Any(promotion.Contains);

            if (!string.IsNullOrEmpty(promotion) && !isPresent)
                return false;

            return true;
        }
    }





}