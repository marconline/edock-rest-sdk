using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using eDock.Common.RestApiSDK.Models.Folders;
using eDock.Common.RestApiSDK.Models.Store;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class StoreService : BaseRestService
    {
        public StoreService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public async Task<InAppPurchaseResult> Purchase(InAppPurchase Purchase)
        {
            RestRequest elm = CreateRequest<InAppPurchase>("Store/Purchase", Method.POST, Purchase);

            var body = elm.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault();
            string req = body.Value.ToString();

            IRestResponse<InAppPurchaseResult> resp = await Client.ExecuteTaskAsync<InAppPurchaseResult>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }
    }
}
