using RS.ViewModels.System.Roles;
using RS.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RS.Services.Utilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideVm>> GetAll();
    }
}
