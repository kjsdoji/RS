using System;
using System.Collections.Generic;
using System.Text;

namespace RS.ViewModels.Catalog.ProductReviews
{
    public class ProductReviewCreateRequest
    {
        //public int ProductId { set; get; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
