using System;
using System.Collections.Generic;
using System.Text;
using RS.ViewModels.System.Roles;
using System.Threading.Tasks;

namespace RS.Services.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}
