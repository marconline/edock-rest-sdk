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
    public class CurrencyService : BaseRestService
    {
        public CurrencyService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }


        public decimal GetRate(string CurrencyFrom, string CurrencyTo)
        {
            RestRequest elm = CreateGetRequest("Currency/Rate");
            elm.AddParameter("CurrencyFrom", CurrencyFrom, ParameterType.QueryString);
            elm.AddParameter("CurrencyTo", CurrencyTo, ParameterType.QueryString);
            IRestResponse<decimal> resp = Client.Execute<decimal>(elm);

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
