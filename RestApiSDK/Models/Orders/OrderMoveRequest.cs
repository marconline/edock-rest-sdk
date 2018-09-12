using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class OrderMoveRequest
    {
        public List<int> OrderId { get; set; }
        public int MoveToStatus { get; set; }
        public bool ApplyCommunicationFlows { get; set; }
    }
}
