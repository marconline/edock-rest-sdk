using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public class Item
    {
        public int? IdItem { get; set; }
        public string SKU { get; set; }
        public string InternalName { get; set; }

        public ItemFolder Folder { get; set; }

        public List<ItemDescription> Descriptions { get; set; }
        public List<PricingRow> PricingRows { get; set; }
        public List<ItemImage> ItemImages { get; set; }
        public List<ItemAttribute> Attributes { get; set; }
        public List<ItemAvailability> Availabilities { get; set; }

        public ItemCondition Condition { get; set; }

        public int? VariatesOn { get; set; }
        public List<ItemVariation> Variations { get; set; }
        public Item VariationFather { get; set; }

        public string Manufacturer { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public List<ItemIdentifier> Identifiers { get; set; }
    }
}
