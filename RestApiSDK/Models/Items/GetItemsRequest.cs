using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public class GetItemsRequest : PagedRequest
    {
        public bool IncludeVariations { get; set; }
        public bool ApplyFiltersToVariations { get; set; }
    }
}
