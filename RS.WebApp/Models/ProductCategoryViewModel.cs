using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS.ViewModels.Catalog.Categories;
using RS.ViewModels.Catalog.Products;
using RS.ViewModels.Common;

namespace RS.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductVm> Products { get; set; }
    }
}
