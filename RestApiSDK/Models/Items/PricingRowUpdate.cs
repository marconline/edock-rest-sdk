using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public class PricingRowUpdate
    {
        public int idPricelist { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public int? DiscountType { get; set; }
        public decimal? ExpectedCurrentPrice { get; set; }
    }
}
