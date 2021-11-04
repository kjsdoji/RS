using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
    }
}
