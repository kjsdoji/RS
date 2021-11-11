using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.ViewModels.Catalog.Categories
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
