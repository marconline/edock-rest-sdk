using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Store
{
    public class InAppPurchase
    {
        public InAppPurchase()
        {
            Items = new List<InAppItemRow>();
        }

        public List<InAppItemRow> Items { get; set; }
    }
}
