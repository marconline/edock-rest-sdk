using eDock.Common.RestApiSDK.Models;
using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using eDock.Common.RestApiSDK.Models.Items;
using eDock.Common.RestApiSDK.Models.Pricelists;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class PricelistService : BaseRestService
    {
        public PricelistService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public async Task<PagedResponse<PriceListRow>> GetPricingRows(int idPricelist, DateTime? UpsertedOn = null, int Page = 0, int PageSize = 50)
        {
            RestRequest elm = CreateGetRequest("Prices/{idPricelist}");
            elm.AddParameter("idPricelist", idPricelist, ParameterType.UrlSegment);

            if (UpsertedOn.HasValue) elm.AddParameter("ChangedFrom", UpsertedOn.Value.ToString("s") + "Z", ParameterType.QueryString);

            IRestResponse<PagedResponse<PriceListRow>> resp = await Client.ExecuteGetTaskAsync<PagedResponse<PriceListRow>>(elm);
            
            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public async Task<List<PriceList>> GetAllPricelists()
        {
            RestRequest elm = CreateGetRequest("Pricelists");
            IRestResponse<List<PriceList>> resp = await Client.ExecuteGetTaskAsync<List<PriceList>>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;

        }

        public async Task<PriceList> GetPricelist(string Marketplace, string Country = null)
        {
            RestRequest elm = CreateGetRequest("Pricelists");
            elm.AddParameter("ModuleName", Marketplace, ParameterType.QueryString);
            if (!String.IsNullOrEmpty(Country)) elm.AddParameter("SubModuleName", Country, ParameterType.QueryString);

            IRestResponse<PriceList> resp = await Client.ExecuteGetTaskAsync<PriceList>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public async Task<PriceList> GetPricelistById(int idPricelist)
        {
            RestRequest elm = CreateGetRequest("Pricelists/{idPricelist}");
            elm.AddParameter("idPricelist", idPricelist, ParameterType.UrlSegment);

            IRestResponse<PriceList> resp = await Client.ExecuteGetTaskAsync<PriceList>(elm);

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
