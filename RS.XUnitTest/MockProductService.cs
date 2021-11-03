using Moq;
using RS.Services.Catalog.Products;
using RS.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.XUnitTest
{
    class MockProductService: Mock<IProductService>
    {
        public MockProductService MockById(ProductVm results, int productId, string languageId)
        {
            Setup(x => x.GetById(productId, languageId))
                .ReturnsAsync(results);

            return this;
        }
        public MockProductService VerifyGetById(Times times, int productId, string languageId)
        {
            Verify(x => x.GetById(productId, languageId), times);

            return this;
        }
    }
}
