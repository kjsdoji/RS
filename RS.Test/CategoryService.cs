﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RS.Services;
using RS.Services.Catalog.Categories;
using RS.ViewModels.Catalog.Categories;

namespace RS.Test
{
    public class CategoryService
    {
        private readonly CategoryService _categoryService = new CategoryService();
        const string languageId = "vi";

        //List<CategoryVm> listCategory = _categoryService.GetAll(languageId);
    }
}
