using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RS.ViewModels.Common;
using RS.ViewModels.System.Languages;
using RS.ViewModels.System.Users;

namespace RS.Services.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}
