using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RS.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using RS.Utilities.Constants;
using RS.ViewModels.Dto;
using RS.ViewModels.Dto.Brand;
using RS.Data.Enums;
using RS.Data.Entities;
using RS.BackendApi.Extensions;
using RS.ViewModels.Catalog.Brands;
using RS.BackendApi.Services;

namespace RS.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly RSDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public BrandsController(
            RSDbContext context,
            IFileStorageService fileStorageService,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PagedResponseDto<BrandDto>>> GetBrands(
            [FromQuery] BrandCriteriaDto brandCriteriaDto,
            CancellationToken cancellationToken)
        {
            var brandQuery = _context
                                .Brands
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();
            brandQuery = BrandFilter(brandQuery, brandCriteriaDto);

            var pagedBrands = await brandQuery
                                .AsNoTracking()
                                .PaginateAsync(brandCriteriaDto, cancellationToken);

            var brandDto = _mapper.Map<IEnumerable<BrandDto>>(pagedBrands.Items);
            return new PagedResponseDto<BrandDto>
            {
                CurrentPage = pagedBrands.CurrentPage,
                TotalPages = pagedBrands.TotalPages,
                TotalItems = pagedBrands.TotalItems,
                Search = brandCriteriaDto.Search,
                SortColumn = brandCriteriaDto.SortColumn,
                SortOrder = brandCriteriaDto.SortOrder,
                Limit = brandCriteriaDto.Limit,
                Items = brandDto
            };
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BrandVm>> GetBrand(int id)
        {
            var brand = await _context
                                .Brands
                                .Where(x => !x.IsDeleted && x.Id == id)
                                .FirstOrDefaultAsync();

            if (brand == null)
            {
                return NotFound();
            }

            var brandVm = new BrandVm
            {
                Id = brand.Id,
                Name = brand.Name,
                Type = (int)brand.Type,
                ImagePath = _fileStorageService.GetFileUrl(brand.ImageName)
            };

            return brandVm;
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutBrand([FromRoute] int id, [FromForm] BrandCreateRequest brandCreateRequest)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            brand.Type = (int)brandCreateRequest.Type;

            if (brandCreateRequest.ImageFile != null)
            {
                brand.ImageName = await _fileStorageService.SaveFileAsync(brandCreateRequest.ImageFile);
            }

            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();

            return Ok(brand);
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BrandVm>> PostBrand([FromForm] BrandCreateRequest brandCreateRequest)
        {
            var brand = new Brand
            {
                Name = brandCreateRequest.Name,
                Type = (int)brandCreateRequest.Type,
                ImageName = string.Empty
            };

            if (brandCreateRequest.ImageFile != null)
            {
                brand.ImageName = await _fileStorageService.SaveFileAsync(brandCreateRequest.ImageFile);
            }

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = brand.Id }, new BrandVm { Id = brand.Id, Name = brand.Name });
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            //_context.Brands.Remove(brand);
            brand.IsDeleted = true;
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        #region Private Method
        private IQueryable<Brand> BrandFilter(
            IQueryable<Brand> brandQuery,
            BrandCriteriaDto brandCriteriaDto)
        {
            if (!String.IsNullOrEmpty(brandCriteriaDto.Search))
            {
                brandQuery = brandQuery.Where(b =>
                    b.Name.Contains(brandCriteriaDto.Search));
            }

            if (brandCriteriaDto.Types != null &&
                brandCriteriaDto.Types.Count() > 0 &&
               !brandCriteriaDto.Types.Any(x => x == (int)BrandTypeEnum.All))
            {
                brandQuery = brandQuery.Where(x =>
                    brandCriteriaDto.Types.Any(t => t == x.Type));
            }

            return brandQuery;
        }
        #endregion
    }
}
