using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Store
{
    public class InAppItemRow
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
