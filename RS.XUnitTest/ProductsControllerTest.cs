using Microsoft.AspNetCore.Mvc;
using Moq;
using RS.BackendApi.Controllers;
using RS.Data.Entities;
using RS.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RS.XUnitTest
{
    public class ProductsControllerTest
    {
        [Fact]
        public void ProductsController_GetById_ReturnProduct()
        {
            //Arrange
            var mockProductVm1 = new ProductVm()
            {
                Id = 1,
                Price = 200000,
                OriginalPrice = 100000,
                Stock = 0,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                Name = "Men T-Shirt",
                Description = "Men T-Shirt",
                Details = "Men T-Shirt",
                SeoDescription = "Men T-Shirt",
                SeoTitle = "Men T-Shirt",
                SeoAlias = "men-t-shirt",
                LanguageId = "en",
                IsFeatured = null,
                ThumbnailImage = "no-image.jpg",
                Categories = new List<string>() { "Men Shirt" },
                ProductReviews = new List<ProductReview>() {
                    new ProductReview(){}
                }
            };

            var mockProductService1 = new MockProductService().MockById(mockProductVm1, 1, "en");

            var controller1 = new ProductsController(mockProductService1.Object);

            //Act
            var result1 = controller1.GetById(1, "en");

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result1);
            mockProductService1.VerifyGetById(Times.Once(), 1, "en");
        }

        [Fact]
        public void ProductsController_GetById_ReturnNull()
        {
            //Arrange
            ProductVm mockProductVm2 = null;

            var mockProductService2 = new MockProductService().MockById(mockProductVm2, 1, "en");

            var controller2 = new ProductsController(mockProductService2.Object);

            //Act
            var result2 = controller2.GetById(1, "en");

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result2);
            Assert.Equal("Cannot find product", badRequestResult.Value);
        }
    }
}
