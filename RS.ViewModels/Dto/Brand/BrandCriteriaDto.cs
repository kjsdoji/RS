using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.ViewModels.Dto.Brand
{
    public class BrandCriteriaDto : BaseQueryCriteriaDto
    {
        public int[] Types { get; set; }
    }
}
