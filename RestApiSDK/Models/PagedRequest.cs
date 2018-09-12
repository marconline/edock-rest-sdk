using eDock.Common.RestApiSDK.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models
{
    public class PagedRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<RequestFilter> filters { get; set; }
        public List<ItemDetail> details { get; set; }

        public Sort sort { get; set; }
    }
}
