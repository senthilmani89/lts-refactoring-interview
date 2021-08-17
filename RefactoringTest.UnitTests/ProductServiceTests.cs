using Moq;
using NUnit.Framework;
using RefactoringTest.ProductService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefactoringTest.UnitTests
{
    [TestFixture]
    public class ProductServiceTests
    {

        private class TestWrapper : IProductRepositoryWrapper
        {
            public void AddProduct(int id, string productName, string productDescription, decimal price, int quantity, string brandName)
            {
                
            }
        }



        [Test]
        [TestCase("ProductName", "ProductDescription", 10, 1, "NewBrand", "5PERCENTOFF")]
        public void AddProduct_WhenCalled_ReturnsTrue(string productName, string productDescription, decimal price, int quantity, string brandName, string promotion)
        {
            //Arrange

            var priceCalculator = new Mock<IPriceCalculator>();
            priceCalculator.Setup(x => x.CalculatePriceBasedOnPromotion(promotion, price)).Returns(5);

            var verifyBrand = new Mock<IVerifyBrand>();
            verifyBrand.Setup(x => x.IsBrandAllowed(brandName)).ReturnsAsync(true);

            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(x => x.Read("used_ids.txt")).Returns(new List<int>() { 0,1, 2, 3, 4, 5 });

            //var wrapper = new TestWrapper();
           
            // var wm = new WrapperMethod(wrapper);
            
            // wm.SomeMethod(6, productName, productDescription, price, quantity, brandName);



            //ProductRepository.AddProduct.(id, productName, productDescription, price, quantity, brandName);

          

            var productService = new ProductService.ProductService(priceCalculator.Object , verifyBrand.Object, fileReader.Object);

            //Act
            var result = productService.AddProduct(productName, productDescription, price, quantity, brandName, promotion);


            priceCalculator.Verify(x => x.CalculatePriceBasedOnPromotion(promotion, price));

            verifyBrand.Verify(x => x.IsBrandAllowed(brandName));

            fileReader.Verify(x => x.Read("used_ids.txt"));

            //Assert
            Assert.That(result, Is.True);
        }
    }
}