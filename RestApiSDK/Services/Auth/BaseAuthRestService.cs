using eDock.Common.RestApiSDK.Models.Credentials;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services.Auth
{
    public class BaseAuthRestService
    {
        protected RestClient Client;
        //private Encryptor Encryptor = new Encryptor();

        protected string TokenEndpointFragment = "/Connect/Token";

        public BaseAuthRestService(eDockClientCredentials Credentials)
        {
            Client = new RestClient("https://auth.edock.it/identity");
            Client.Authenticator = new HttpBasicAuthenticator(Credentials.ClientId, Credentials.ClientSecret);
        }
    }
}
