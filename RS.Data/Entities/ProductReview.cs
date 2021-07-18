using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Data.Entities
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public int Rating { get; set; }

    }
}
