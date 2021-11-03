using RS.Data.EF;
using RS.Data.Entities;
using RS.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Services.Catalog.Brands
{
    public class BrandService : IBrandService
    {
        private readonly RSDbContext _context;
        private readonly IStorageService _storageService;
        public BrandService(RSDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

    }
}
