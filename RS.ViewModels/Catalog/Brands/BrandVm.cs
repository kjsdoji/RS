using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.ViewModels.Catalog.Brands
{
    public class BrandVm
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Type { get; set; }
        public string ImagePath { get; set; }
    }
}
