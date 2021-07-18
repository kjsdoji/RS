using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductReviewController(IProductApiClient productApiClient, IHttpContextAccessor httpContextAccessor )
        {
            _productApiClient = productApiClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(int productId, ProductReviewCreateRequest createReviewRequest)
        {
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            Console.WriteLine(host);
            await _productApiClient.AddReview(productId, createReviewRequest);
            return RedirectToAction("Index", "Home");
        }
    }
}
