using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS.ViewModels.Catalog.Products;
using RS.ViewModels.Utilities.Slides;

namespace RS.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVm> Slides { get; set; }

        public List<ProductVm> FeaturedProducts { get; set; }

        public List<ProductVm> LatestProducts { get; set; }
    }
}
