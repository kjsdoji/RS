using RS.ViewModels.Catalog.Products;
using RS.ViewModels.Common;
using RS.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS.ViewModels.Catalog.ProductReviews;

namespace RS.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<bool> AddReview(ProductReviewCreateRequest request);
        Task<bool> UpdateProduct(ProductUpdateRequest request);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<ProductVm> GetById(int id, string languageId);
        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);
        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
        Task<bool> DeleteProduct(int id);
    }
}
