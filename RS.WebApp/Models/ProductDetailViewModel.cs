using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS.ViewModels.Catalog.Categories;
using RS.ViewModels.Catalog.ProductImages;
using RS.ViewModels.Catalog.ProductReviews;
using RS.ViewModels.Catalog.Products;

namespace RS.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryVm Category { get; set; }
        public ProductVm Product { get; set; }
        public List<ProductVm> RelatedProducts { get; set; }
        public List<ProductImageViewModel> ProductImages { get; set; }
        public List<ProductReviewViewModel> ProductReviews { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
    }
}
