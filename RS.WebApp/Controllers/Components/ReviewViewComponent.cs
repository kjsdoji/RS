using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS.ApiIntegration;
using RS.ViewModels.Catalog.ProductReviews;
using RS.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS.WebApp.Controllers.Components
{
    public class ReviewViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewViewComponent(IProductApiClient productApiClient, IHttpContextAccessor httpContextAccessor)
        {
            _productApiClient = productApiClient;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public async Task<IViewComponentResult> Add(int productId, ProductReviewCreateRequest createReviewRequest)
        {
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            Console.WriteLine(host);
            var review = await _productApiClient.AddReview(productId, createReviewRequest);
            return View(review);
        }
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
