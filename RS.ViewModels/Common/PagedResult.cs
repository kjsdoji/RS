using System;
using System.Collections.Generic;
using System.Text;

namespace RS.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
        //test get product for admin
        public int CurrentPage { set; get; }
        public int SortColumn { set; get; }
        public string SortOrder { set; get; }
        public int TotalItems { set; get; }
        public string TotalPages { set; get; }
        //
    }
}
