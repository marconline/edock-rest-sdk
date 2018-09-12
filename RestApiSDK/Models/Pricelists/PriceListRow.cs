using eDock.Common.RestApiSDK.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Pricelists
{
    public class PriceListRow
    {
        public int idPricelist { get; set; }
        public int idItem { get; set; }
        public string SKU { get; set; }
        public string InternalName { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DiscountTypeEnum DiscountTypeId { get; set; }
    }
}
