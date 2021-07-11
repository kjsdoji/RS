using System;
using System.Collections.Generic;
using System.Text;
using RS.ViewModels.Common;

namespace RS.ViewModels.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}
