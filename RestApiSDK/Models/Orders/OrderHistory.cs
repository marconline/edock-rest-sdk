using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class OrderHistory
    {
        public string OrderStatusFromName { get; set; }
        public string OrderStatusToName { get; set; }

        public int OrderStatusFromId { get; set; }
        public int OrderStatusToId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime InsertedOn { get; set; }
        public int OrderHistoryTypeIdType { get; set; }
    }
}
