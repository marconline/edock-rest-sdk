using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    [Flags]
    public enum OrderDetailLevelEnum
    {
        BillingAddress = 1,
        ShippingAddress = 2,
        Rows = 4,
        History = 8,
        ExternalSellerReference = 16,
        Payments = 32,
        RowVariationAttributes = 64,
        ContactInformations = 128,
    }
}
