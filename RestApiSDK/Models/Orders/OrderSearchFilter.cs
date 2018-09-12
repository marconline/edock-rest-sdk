using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class OrderSearchFilter
    {
        public DateTime? CreatedOnEnd { get; set; }
        public DateTime? CreatedOnStart { get; set; }
        public DateTime? CreatedOneDockEnd { get; set; }
        public DateTime? CreatedOneDockStart { get; set; }
        public DateTime? UpdatedOnEnd { get; set; }
        public DateTime? UpdatedOnStart { get; set; }
        public DateTime? ShippedOnEnd { get; set; }
        public DateTime? ShippedOnStart { get; set; }

        public int? OrderIdGreaterOrEqualThan { get; set; }
        public int? OrderIdLowerOrEqualThan { get; set; }
        public bool? Paid { get; set; }
        public int? idStatusFilter { get; set; }
        public string SKU { get; set; }

        public int? OrderId { get; set; }
        public string CustomerFilter { get; set; }
        public string eBayUsername { get; set; }
        public int? idCountry { get; set; }
        public int? idCounty { get; set; }
        public int? idCurrency { get; set; }
        public int? idPaymentMethod { get; set; }
        public int? ModuleIDFilter { get; set; }
        public string CustomerEmail { get; set; }

        public string MarketplaceOrderId { get; set; }
        public string eBaySellerUser { get; set; }
        public string SellingManagerSalesRecordNumber { get; set; }
    }
}
