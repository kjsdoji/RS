using RS.Services.System.Roles;
using RS.Data.EF;
using RS.Data.Entities;
using RS.ViewModels.System.Roles;
using RS.ViewModels.Utilities.Slides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Services.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly RSDbContext _context;

        public SlideService(RSDbContext context)
        {
            _context = context;
        }

        public async Task<List<SlideVm>> GetAll()
        {
            var slides = await _context.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return slides;
        }
    }
}
