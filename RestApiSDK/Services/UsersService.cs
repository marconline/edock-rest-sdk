using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class UsersService: BaseRestService
    {
        public UsersService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public bool IsKeyEnabled(string ArbiterKey)
        {
            RestRequest elm = CreateGetRequest("Users/GetProfileKeyEnabled");
            elm.AddParameter("ArbiterKey", ArbiterKey, ParameterType.QueryString);

            IRestResponse<bool> resp = Client.Execute<bool>(elm);
            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }
    }
}
