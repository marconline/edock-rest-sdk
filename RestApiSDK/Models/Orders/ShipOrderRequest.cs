using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class ShipOrderRequest
    {
        public int idOrder { get; set; }
        public string TrackingNumber { get; set; }
        public string Carrier { get; set; }
        public bool isShipped { get; set; }

    }
}
