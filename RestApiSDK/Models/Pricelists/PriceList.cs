using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Pricelists
{
    public class PriceList
    {
        public string BaseCurrencyAbbreviation { get; set; }
        public string BaseCurrencyName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int idPricing { get; set; }
        public bool? isDiscountEnabled { get; set; }
        public bool? isSync { get; set; }
        public string Name { get; set; }

        public List<PriceListModule> Modules { get; set; }
    }
}
