using RS.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RS.ViewModels.Catalog.Brands
{
    public class BrandCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BrandTypeEnum Type { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
