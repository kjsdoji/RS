using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RS.ApiIntegration;
using RS.ViewModels.Catalog.ProductReviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS.WebApp.Controllers
{
    public class ProductReviewController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        public ProductReviewController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(int productId, ProductReviewCreateRequest createReviewRequest)
        {
            await _productApiClient.AddReview(productId, createReviewRequest);
            return RedirectToAction("Detail", "Product", new {id = productId});
        }
    }
}
