using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Amazon
{
    public class Subscription
    {
        public int idSubscription { get; set; }

        public string AmazonMarketplaceKey { get; set; }
        public string AmazonMerchantKey { get; set; }
        public string AmazonUsername { get; set; }
        
        public string MWSAuthToken { get; set; }
    }
}
