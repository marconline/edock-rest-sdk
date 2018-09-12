using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using eDock.Common.RestApiSDK.Models.Tracking;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class TrackingService : BaseRestService
    {
        public TrackingService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public async Task Track(string EventId, TrackingModel Model = null)
        {
            RestRequest elm = CreateRequest<TrackingModel>("Track/Event/{EventId}", Method.POST, Model);
            elm.AddParameter("EventId", EventId, ParameterType.UrlSegment);

            IRestResponse resp = await Client.ExecuteTaskAsync(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK && resp.StatusCode != HttpStatusCode.NoContent)
            {
                throw new eDockAPIException();
            }

            return;
        }

        public async Task SetProperties(TrackingModel Model)
        {
            RestRequest elm = CreateRequest<TrackingModel>("Track/Properties", Method.POST, Model);
            IRestResponse resp = await Client.ExecuteTaskAsync(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK && resp.StatusCode != HttpStatusCode.NoContent)
            {
                throw new eDockAPIException();
            }

            return;
        }
    }
}
