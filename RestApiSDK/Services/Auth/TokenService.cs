using eDock.Common.RestApiSDK.Models.Auth;
using eDock.Common.RestApiSDK.Models.Credentials;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services.Auth
{
    public class TokenService : BaseAuthRestService
    {
        public TokenService(eDockClientCredentials Credentials)
            : base(Credentials)
        {
        }

        public async Task<TokenResponse> RefreshAccessToken(string RefreshToken)
        {
            RestRequest elm = new RestRequest(base.TokenEndpointFragment, Method.POST);
            elm.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            elm.AddParameter("grant_type", "refresh_token");
            elm.AddParameter("refresh_token", RefreshToken);

            IRestResponse<TokenResponse> resp  = Client.Execute<TokenResponse>(elm);

            if (resp.StatusCode == HttpStatusCode.OK)
                return resp.Data;
            else
                return null;

        }
    }
}
