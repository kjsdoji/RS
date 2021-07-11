using System;
using System.Collections.Generic;
using System.Text;
using RS.ViewModels.Common;

namespace RS.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string LanguageId { get; set; }

        public int? CategoryId { get; set; }
    }
}
