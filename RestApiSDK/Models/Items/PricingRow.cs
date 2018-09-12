using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public enum DiscountTypeEnum
    {
        Fixed = 1,
        Percentage = 2
    }

    public class PricingRow
    {
        public int PriceListIdPricing { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DiscountTypeEnum? DiscountTypeIdDiscountType { get; set; }
    }
}
