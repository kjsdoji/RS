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
using RS.ViewModels.Catalog.Categories;
using RS.BackendApi.Services;

namespace RS.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly RSDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public CategoryController(
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
        public async Task<ActionResult<PagedResponseDto<CategoryVm>>> GetCategories(
            [FromQuery] BaseQueryCriteriaDto categoryCriteriaDto,
            CancellationToken cancellationToken)
        {
            var categoriesQuery = from c in _context.Categories
                                join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                                where ct.LanguageId == "en"
                                select new { c, ct };
            var temp = categoriesQuery.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            });

            var pagedCategories = await temp
                                .AsNoTracking()
                                .PaginateAsync(categoryCriteriaDto, cancellationToken);

            var categoryVm = _mapper.Map<IEnumerable<CategoryVm>>(pagedCategories.Items);
            return new PagedResponseDto<CategoryVm>
            {
                CurrentPage = pagedCategories.CurrentPage,
                TotalPages = pagedCategories.TotalPages,
                TotalItems = pagedCategories.TotalItems,
                Search = categoryCriteriaDto.Search,
                SortColumn = categoryCriteriaDto.SortColumn,
                SortOrder = categoryCriteriaDto.SortOrder,
                Limit = categoryCriteriaDto.Limit,
                Items = categoryVm
            };
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<CategoryVm>> GetCategory(int id)
        {
            var categoryQuery = from c in _context.Categories
                                join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                                where ct.LanguageId == "en" && c.Id == id
                                select new { c, ct };
            var category = await categoryQuery.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            var categoryVm = new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId
            };

            return categoryVm;
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutCategory([FromRoute] int id, [FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var categoryTranslations = await _context.CategoryTranslations.FindAsync(id);

            if (categoryTranslations == null)
            {
                return NotFound();
            }

            categoryTranslations.Name = categoryCreateRequest.Name;
            _context.CategoryTranslations.Update(categoryTranslations);
            await _context.SaveChangesAsync();

            return Ok(categoryTranslations);
        }

        [HttpPost]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PostCategory([FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var languages = _context.Languages;
            var categoryTranslations = new List<CategoryTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == "en")
                {
                    categoryTranslations.Add(new CategoryTranslation()
                    {
                        Name = categoryCreateRequest.Name,
                        LanguageId = "en"
                    });
                }
                else
                {
                    categoryTranslations.Add(new CategoryTranslation()
                    {
                        Name = categoryCreateRequest.Name + "vi",
                        LanguageId = "vi"
                    });
                }
            }
            var category = new Category()
            {
                IsShowOnHome = true,
                SortOrder = 1,
                CategoryTranslations = categoryTranslations
            };



            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, new Category { Id = category.Id });
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            //brand.IsDeleted = true;
            //_context.Brands.Update(brand);
            await _context.SaveChangesAsync();

            return Ok(true);
        }
    }
}
