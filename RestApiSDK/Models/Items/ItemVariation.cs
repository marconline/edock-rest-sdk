using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public class ItemVariation
    {
        public List<string> VariationImages = new List<string>();
        public int VariationQuantity { get; set; }
        public string VariationSKU { get; set; }
        public Dictionary<string, string> VariationValues = new Dictionary<string, string>();
        public string VariationEAN { get; set; }
        public List<PricingRow> VariationPricingRows = new List<PricingRow>();
        public List<ItemIdentifier> Identifiers { get; set; }
    }
}
