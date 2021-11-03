﻿using RS.ViewModels.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.ViewModels.Dto
{
    public class BaseQueryCriteriaDto
    {
        public string Search { get; set; }
        public SortOrderEnum SortOrder { get; set; }
        public string SortColumn { get; set; }
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
