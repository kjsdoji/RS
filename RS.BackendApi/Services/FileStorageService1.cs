﻿using RS.BackendApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace RS.BackendApi.Services
{
    public class FileStorageService1 : IFileStorageService
    {
        private readonly string _imageFolderPath;

        public FileStorageService1(IWebHostEnvironment webHostEnvironment)
        {
            _imageFolderPath = ImageHelper.GetImageFolderPath();
        }

        public string GetFileUrl(string fileName)
        {
            return $"{_imageFolderPath}\\{fileName}";
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var fileName = file == null ? string.Empty : GetFileName(file);
            if (string.IsNullOrEmpty(fileName)) return string.Empty;

            var filePath = Path.Combine(_imageFolderPath, fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_imageFolderPath, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        private string GetFileName(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue
                                        .Parse(file.ContentDisposition)
                                        .FileName
                                        .Trim('"');

            //return $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            return $"{Guid.NewGuid()}.jpeg";
        }
    }
}
