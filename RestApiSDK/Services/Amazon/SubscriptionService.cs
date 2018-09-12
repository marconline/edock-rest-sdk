using eDock.Common.RestApiSDK.Models;
using eDock.Common.RestApiSDK.Models.Amazon;
using eDock.Common.RestApiSDK.Models.Credentials;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services.Amazon
{
    public class SubscriptionService : BaseRestService
    {
        public SubscriptionService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public PagedResponse<Subscription> GetSubscriptions()
        {
            RestRequest elm = CreateGetRequest("AmazonSubscription");
            IRestResponse<PagedResponse<Subscription>> resp = Client.Get<PagedResponse<Subscription>>(elm);


            if (resp.Data != null)
            {
                return resp.Data;
            }
            else
            {
                return null;
            }
        }

        public Subscription GetSubscription(int idSubscription)
        {
            RestRequest elm = CreateGetRequest("AmazonSubscription");
            elm.AddQueryParameter("id", idSubscription.ToString());
            IRestResponse<Subscription> resp = Client.Get<Subscription>(elm);


            if (resp.Data != null)
            {
                return resp.Data;
            }
            else
            {
                return null;
            }
        }
    }
}
