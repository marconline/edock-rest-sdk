using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class Order
    {
        public int? idOrderInt { get; set; }
        public Guid? idOrder { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string OwnerModule { get; set; }
        public int idStatus { get; set; }
        public bool isPaid { get; set; }
        public string Currency { get; set; }

        public List<OrderRow> Rows { get; set; }

        public string ShippingMethod { get; set; }
        public double ShippingCost { get; set; }
        public string PaymentMethod { get; set; }

        public OrderAddress BillingAddress { get; set; }
        public OrderAddress ShippingAddress { get; set; }

        public List<OrderHistory> History { get; set; }

        public string MarketplaceOrderId { get; set; }
        public List<OrderPayment> Payments { get; set; }


        public string Notes { get; set; }
        public string CarrierName { get; set; }
        public string TrackingNumber { get; set; }

        public int idCustomer { get; set; }
        public List<ContactInformations> ContactInformations { get; set; }
    }
}
