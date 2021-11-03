using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace RS.BackendApi.Services
{
    public interface IFileStorageService
    {
        string GetFileUrl(string fileName);

        Task<string> SaveFileAsync(IFormFile file);

        Task DeleteFileAsync(string fileName);
    }
}
