using System;
using System.Collections.Generic;
using System.Text;
using RS.ViewModels.Common;

namespace RS.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
