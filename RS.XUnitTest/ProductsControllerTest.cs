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
        public void ProductsController_GetById()
        {
            //Arrange
            var mockProductVm = new ProductVm()
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

            var mockProductService = new MockProductService().MockById(mockProductVm, 1, "en");

            var controller = new ProductsController(mockProductService.Object);

            //Act

            var result = controller.GetById(1, "en");

            //Assert

            Assert.IsAssignableFrom<IActionResult>(result);
            mockProductService.VerifyGetById(Times.Once(), 1, "en");
        }
    }
}
