using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public class ItemSearchFilter
    {
        public int? idFolder { get; set; }
        public int? idPricing { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public List<string> SKU { get; set; }
        public List<int> idItems { get; set; }
        public string EAN13 { get; set; }
        public string ProductName { get; set; }
        public bool? ValidEAN13Code { get; set; }
        public int? QuantityLowerThan { get; set; }
        public int? QuantityGreaterThan { get; set; }
    }
}
