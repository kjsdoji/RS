using System;
using System.Collections.Generic;
using System.Text;
using RS.ViewModels.Common;

namespace RS.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
