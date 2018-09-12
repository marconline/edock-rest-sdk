using eDock.Common.RestApiSDK.Models.Credentials;
using log4net;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public abstract class BaseRestService
    {
        protected RestClient Client;

        public BaseRestService(eDockCredentials Credentials)
        {
            Client = new RestClient("https://rest.edock.it/api");
            Client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Credentials.AuthToken, "Bearer");
            Client.AddDefaultHeader("Content-Type", "application/json");
        }

        public RestRequest CreateGetRequest(string BaseURL)
        {
            RestRequest elm = new RestRequest(BaseURL, Method.GET);
            elm.RequestFormat = DataFormat.Json;
            return elm;
        }

        public RestRequest CreateRequest<T>(string BaseURL, Method Method, T body)
        {
            return CreateRequest<T>(BaseURL, Method, body, NewtonsoftJsonSerializer.Default);
        }

        public RestRequest CreateRequest<T>(string BaseURL, Method Method, T body, ISerializer Serializer)
        {
            RestRequest elm = new RestRequest(BaseURL, Method);
            elm.JsonSerializer = Serializer;

            elm.RequestFormat = DataFormat.Json;
            elm.AddJsonBody(body);
            return elm;
        }

        public void LogRequest(RestRequest req)
        {
            var body = req.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault();
            if (body != null)
            {
                ILog log = log4net.LogManager.GetLogger("test");
                log.Info(body.Value);
            }
        }

    }
}
